using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class AllUsers
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UsersProductsOutputView[] UsersProducts { get; set; }

    }

    [XmlType("User")]
    public class UsersProductsOutputView
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        public SoldProductOutputView SoldProducts { get; set; }
    }

    [XmlType("SoldProducts")]
    public class SoldProductOutputView
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductInformation[] ProductsInformation { get; set; }
    }

    [XmlType("Product")]
    public class ProductInformation
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }

}
