using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace XmlToJson
{
    class Program
    {
        static void Main(string[] args)
        {

            var xml = @"
                        <Invoice>
                            <EmployeeID>1002941</EmployeeID>
                            <User FirstName='Johnny' SurName='Abhrama'>
                            <LastName>Dep</LastName>
                            </User>
                            <TimeStamp>1/1/2017 00:01</TimeStamp>
                        </Invoice>";
            var m = GetModelFromJson(ConvertToJson(ReadXML(xml)));
            Console.WriteLine(m);
            Console.Read();


        }
        public static XmlDocument ReadXML(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc;
        }

        public static string ConvertToJson(XmlDocument doc)
        {
            return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
        }
        public static Invoice GetModelFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Invoice>(json);
        }
    }
    public class Invoice
    {
        public int EmployeeID { get; set; }
        public User User { get; set; }
       
        public DateTime Timestamp { get; set; }
    }
    public class User
    {
        [JsonProperty("@FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("@SurName")]
        public string SurName { get; set; }
        public string LastName { get; set; }
    }
}
