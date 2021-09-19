using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            string json = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportCategories(db, json));

            json = File.ReadAllText("../../../Datasets/users.json");
            Console.WriteLine(ImportUsers(db, json));

            json = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportProducts(db, json));

            json = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(db, json));

            Console.WriteLine(GetUsersWithProducts(db));
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {context.Users.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {context.Products.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(inputJson).Where(x => x.Name != null).ToList();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {context.Categories.Count()}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {context.CategoryProducts.Count()}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Select(x => new 
                {
                    name = x.Name, 
                    price = x.Price, 
                    seller = x.Seller.FirstName + ' ' + x.Seller.LastName 
                })
                .OrderBy(x => x.price)
                .Where(x => x.price >= 500 && x.price <= 1000)
                .ToList();
            string json = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);
            return json;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = $"{x.CategoryProducts.Select(c => c.Product.Price).Average():f2}",
                    totalRevenue = $"{x.CategoryProducts.Select(c => c.Product.Price).Sum():f2}"
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToList()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(p => p.Buyer != null),
                        products = u.ProductsSold
                            .ToList()
                            .Where(p => p.Buyer != null)
                            .Select(p => new 
                            {
                                name = p.Name,
                                price = p.Price
                            })
                            .ToList()
                    }
                })
                .ToList();

            var usersWithProducts = new 
            {
                usersCount = users.Count,
                users
            };

            var json = JsonConvert.SerializeObject(usersWithProducts, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }
    }
}