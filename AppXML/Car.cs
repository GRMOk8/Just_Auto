using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace AppXML
{
    public class Car
    {
        [XmlElement("Marka")]
        public string Marka { get; set; }
        [XmlElement("Model")]
        public string Model { get; set; }
        [XmlElement("Komplectacia")]
        public string Komplectacia { get; set; }
    }
}
