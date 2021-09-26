using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects
{
    [XmlType("Car")]
   public class CarInputModel
    {
        public CarInputModel()
        {
            CarPartsInputModel = new HashSet<CarPartsInputModel>();
        }

        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }
        [XmlArray("parts")]
        public HashSet<CarPartsInputModel> CarPartsInputModel { get; set; }
    }

    [XmlType("partId")]
    public class CarPartsInputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
