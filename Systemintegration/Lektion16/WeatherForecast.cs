using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.WebRequestMethods;

namespace Lektion16
{
    internal class WeatherForecast
    {
        private string _url = "";
        private string _appkey = "bb1aa08a4298a69ce7dc213c6a469429";
        public string City { get; set; }
        public string Units { get; set; }
        public string type { get; set; } // Current weather or forecast


        public WeatherForecast(string city, string type, string units)
        {
            Units = units;
            City = city;
            this.type = type;

            _url = $"https://api.openweathermap.org/data/2.5/{type}?q={city}&mode=xml&units={units}&APPID={_appkey}";

        }

        public void GetConditions()
        {
            Console.WriteLine(GetFormattedXML());
        }

        public void SendForecast(MessageQueue messageQueue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (messageQueue.Path == @".\Private$\AirTrafficControl")
            {
                string xml = GetFormattedXML();
                xmlDoc.LoadXml(xml);


                List<XmlNode> conditions = new List<XmlNode>();
                conditions.Add(xmlDoc.SelectSingleNode("location/name"));
                conditions.Add(xmlDoc.SelectSingleNode("location/location"));
                conditions.Add(xmlDoc.SelectSingleNode("location/country"));
                conditions.Add(xmlDoc.SelectSingleNode("forecast/time/temperature"));
                conditions.Add(xmlDoc.SelectSingleNode("forecast/time/humidity"));
                conditions.Add(xmlDoc.SelectSingleNode("forecast/time/pressure"));
                conditions.Add(xmlDoc.SelectSingleNode("forecast/time/windSpeed"));
                conditions.Add(xmlDoc.SelectSingleNode("forecast/time/windGust"));
                conditions.Add(xmlDoc.SelectSingleNode("forecast/time/windDirection"));
                conditions.Add(xmlDoc.SelectSingleNode("forecast/time/clouds"));
                conditions.Add(xmlDoc.SelectSingleNode("forecast/time/visibility"));





            }

        }


        private string GetFormattedXML()
        {
            using (WebClient client = new WebClient())
            {
                string xml = client.DownloadString(_url);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                using (StringWriter stringWriter = new StringWriter())
                {
                    XmlTextWriter xmltextwriter = new XmlTextWriter(stringWriter);
                    xmltextwriter.Formatting = Formatting.Indented;
                    xmlDoc.WriteTo(xmltextwriter);
                    // Return the result.
                    return stringWriter.ToString();

                }

            }


        }
    }

}
