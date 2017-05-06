using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

using DbBank.XML;

namespace DbBank
{
    public class ParseXml
    {
        public ParseXml(BankDb dbConnect)
        {
            string path = "kurs.xml";
            banks Banks = null;
            XDocument xmlDoc = XDocument.Load("http://www.obmennik.by/xml/kurs.xml");
            xmlDoc.Save(path);
            using (FileStream ff = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(banks));
                Banks = (banks)xml.Deserialize(ff);
            }
            dbConnect.UpdateKurs(Banks);
        }
    }
}
