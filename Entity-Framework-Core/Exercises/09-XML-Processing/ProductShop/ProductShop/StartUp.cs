using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            var result = GetUsersWithProducts(db);
            Console.WriteLine(result);
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string root = "Users";

            var xmlSerializer = new XmlSerializer(typeof(UserInputView[]), new XmlRootAttribute(root));

            var fileReader = new StringReader(inputXml);

            var usersDto = xmlSerializer.Deserialize(fileReader) as UserInputView[];

            var users = usersDto
                .Select(x => new User
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                })
                .ToArray();

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            string root = "Products";

            var xmlSerializer = new XmlSerializer(typeof(ProductInputView[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var productsDto = xmlSerializer.Deserialize(textReader) as ProductInputView[];

            var products = productsDto
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x.BuyerId,
                })
                .ToArray();

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string root = "Categories";

            var xmlSerializer = new XmlSerializer(typeof(CategoriesInputView[]), new XmlRootAttribute(root));

            var fileReader = new StringReader(inputXml);

            var dtoCategoriesDtp = xmlSerializer.Deserialize(fileReader) as CategoriesInputView[];

            var categories = dtoCategoriesDtp
                .Select(x => new Category
                {
                    Name = x.Name,
                })
                .ToArray();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string root = "CategoryProducts";

            var xmlSerializer = new XmlSerializer(typeof(CategoryProductInputView[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var categoryProductsDto = xmlSerializer.Deserialize(textReader) as CategoryProductInputView[];

            var categoryProducts = categoryProductsDto
                .Select(x => new CategoryProduct
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId,
                })
                .ToArray();

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            string root = "Products";

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductOutputView
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerName = x.Buyer.FirstName + " " + x.Buyer.LastName,
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var xmlSerializer = new XmlSerializer(typeof(ProductOutputView[]), new XmlRootAttribute(root));

            xmlSerializer.Serialize(textWriter, products, ns);

            var result = textWriter.ToString();

            return result;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            string root = "Users";

            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new UserOutputView
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserProducts = x.ProductsSold.Select(p => new UserProductsOutputView
                    {
                        Name = p.Name,
                        Price = p.Price,
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var textReader = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var xmlSerializer = new XmlSerializer(typeof(UserOutputView[]), new XmlRootAttribute(root));

            xmlSerializer.Serialize(textReader, users, ns);

            string result = textReader.ToString();

            return result;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            string root = "Categories";

            var categories = context.Categories
                .Select(x => new CategoryOutputView
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price),
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var textWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var xmlSerializer = new XmlSerializer(typeof(CategoryOutputView[]), new XmlRootAttribute(root));

            xmlSerializer.Serialize(textWriter, categories, ns);

            string result = textWriter.ToString();

            return result;
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string root = "Users";

            var users = new AllUsers()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                UsersProducts = context.Users
                    .ToArray()
                    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .Take(10)
                    .Select(u => new UsersProductsOutputView()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        SoldProducts = new SoldProductOutputView()
                        {
                            Count = u.ProductsSold.Count(ps => ps.Buyer != null),
                            ProductsInformation = u.ProductsSold
                                .ToArray()
                                .Where(ps => ps.Buyer != null)
                                .Select(ps => new ProductInformation()
                                {
                                    Name = ps.Name,
                                    Price = ps.Price
                                })
                                .OrderByDescending(p => p.Price)
                                .ToArray()
                        }
                    })
                    .ToArray()
            };

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var xmlSerializer = new XmlSerializer(typeof(AllUsers), new XmlRootAttribute(root));

            xmlSerializer.Serialize(textWriter, users, ns);

            string result = textWriter.ToString();

            return result;
        }
    }
}
