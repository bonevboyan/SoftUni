using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Output
{
    [XmlType("part")]
    public class CarPartsInfoOutputModel
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}