using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBank.XML
{

    public class Rootobject
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public string[] phoneNumbers { get; set; }
    }

    public class Address
    {
        public string streetAddress { get; set; }
        public string city { get; set; }
        public int postalCode { get; set; }
    }

}
