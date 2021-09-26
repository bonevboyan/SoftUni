using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects
{
    [XmlType("Supplier")]
  public class SupplierInputModel
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("isImporter")]
        public bool isImporter { get; set; }

    }
}
