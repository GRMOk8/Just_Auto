using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppXML
{
    [XmlRoot("Catalog")]
    
    public class Root
    {
        [XmlElement("Car")]
        public List<Car> Children { get; set; }
    }
}
