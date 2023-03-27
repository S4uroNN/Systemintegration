using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace InformationTranslater
{
    internal class Translator
    {
        MessageQueue inqueue;

        public String Airline { get; set; }
        public String FlightNo { get; set; }
        public String Origin { get; set; }
        public String Status { get; set; }
        public String Destination { get; set; }
        public String IncomingFromDestination { get; set; }
        public DateTime DateTime { get; set; }
        


    }
}
