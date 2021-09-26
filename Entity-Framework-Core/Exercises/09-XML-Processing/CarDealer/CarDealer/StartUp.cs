using AutoMapper;
using CarDealer.Data;
using CarDealer.DataTransferObjects;
using CarDealer.DataTransferObjects.Output;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            var result = GetSalesWithAppliedDiscount(db);
            Console.WriteLine(result);
        }
        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
              {
                  cfg.AddProfile<CarDealerProfile>();
              });

            mapper = config.CreateMapper();
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string root = "Suppliers";

            var xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]),
               new XmlRootAttribute(root));

            var textRead = new StringReader(inputXml);


            var suppliersDto = xmlSerializer.Deserialize(textRead) as SupplierInputModel[];

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.isImporter,
            })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {

            string root = "Parts";

            var xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute(root));

            var textRead = new StringReader(inputXml);

            var partsDto = xmlSerializer.Deserialize(textRead) as PartInputModel[];

            var supplierIds = context.Suppliers.Select(x => x.Id).ToArray();

            var parts = partsDto
                .Where(x => supplierIds.Contains(x.SupplierId))
                .Select(X => new Part
                {
                    Name = X.Name,
                    Price = X.Price,
                    Quantity = X.Quantity,
                    SupplierId = X.SupplierId,
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string root = "Cars";

            var xmlInitializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute(root));

            var fileReader = new StringReader(inputXml);

            var carDTO = xmlInitializer.Deserialize(fileReader) as CarInputModel[];

            var allCarPartsIds = context.Parts.Select(x => x.Id).ToList();

            var cars = carDTO
                .Select(x => new Car
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    PartCars = x.CarPartsInputModel.Select(x => x.Id)
                        .Intersect(allCarPartsIds)
                        .Select(part => new PartCar
                        {
                            PartId = part
                        })
                        .ToList()
                })
                .ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string root = "Customers";

            var xmlSerializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute(root));

            var textRead = new StringReader(inputXml);

            var customerDto = xmlSerializer.Deserialize(textRead) as CustomerInputModel[];

            var customer = customerDto
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.isYoungDriver,
                })
                .ToArray();

            context.Customers.AddRange(customer);
            context.SaveChanges();

            return $"Successfully imported {customer.Count()}";

        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string root = "Sales";

            var xmlInitializer = new XmlSerializer(typeof(SalesInputModel[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var salesDto = xmlInitializer.Deserialize(textReader) as SalesInputModel[];

            var allSales = context.Cars.Select(x => x.Id);

            var sales = salesDto
                .Where(x => allSales.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount,
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            string root = "cars";

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(X => new CarOutputModel
                {
                    Model = X.Model,
                    Make = X.Make,
                    TravelledDistance = X.TravelledDistance,
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]),
                new XmlRootAttribute(root));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, ns);

            var result = textWriter.ToString();

            return result;
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            string root = "cars";

            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarBMVOutputModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var xmlSerialize = new XmlSerializer(typeof(CarBMVOutputModel[]), new XmlRootAttribute(root));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerialize.Serialize(textWriter, cars, ns);

            var result = textWriter.ToString();

            return result;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            string root = "suppliers";

            var suppilers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new SupplierOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count,
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(SupplierOutputModel[]), new XmlRootAttribute(root));

            var textReader = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textReader, suppilers, ns);

            var result = textReader.ToString();

            return result;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            string root = "cars";

            var cars = context.Cars
                .Select(x => new CarPartsOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    CarParts = x.PartCars
                       .Select(p => new CarPartsInfoOutputModel
                       {
                           Name = p.Part.Name,
                           Price = p.Part.Price,
                       })
                       .OrderByDescending(p => p.Price)
                       .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CarPartsOutputModel[]), new XmlRootAttribute(root));

            var fileWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(fileWriter, cars, ns);

            var result = fileWriter.ToString();

            return result;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            string root = "customers";

            var customers = context.Customers
                 .Where(c => c.Sales.Count != 0)
                 .Select(c => new CustomerOutputModel
                 {
                     FullName = c.Name,
                     BoughtCars = c.Sales.Count,
                     SpentMoney = c.Sales
                         .SelectMany(s => s.Car.PartCars)
                         .Sum(p => p.Part.Price)
                 })
                 .OrderByDescending(c => c.SpentMoney)
                 .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CustomerOutputModel[]), new XmlRootAttribute(root));

            var fileWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(fileWriter, customers, ns);

            var result = fileWriter.ToString();

            return result;
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            string root = "sales";

            var sales = context.Sales
                     .Select(s => new SaleOutputModel
                     {
                         Car = new CarSaleOutputModel
                         {
                             Make = s.Car.Make,
                             Model = s.Car.Model,
                             TravelledDistance = s.Car.TravelledDistance
                         },
                         Discount = s.Discount,
                         CustomerName = s.Customer.Name,
                         Price = s.Car.PartCars
                             .Sum(p => p.Part.Price),
                         PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price)
                             - (s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100)
                     })
                     .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(SaleOutputModel[]), new XmlRootAttribute(root));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, sales, ns);

            string result = textWriter.ToString();

            return result;
        }
    }
}

