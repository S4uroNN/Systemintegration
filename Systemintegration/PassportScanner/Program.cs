using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PassportScanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\AirportCustoms"))
            {
                messageQueue = new MessageQueue(@".\Private$\AirportCustoms");
                messageQueue.Label = "Customs Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\AirportCustoms");
                messageQueue = new MessageQueue(@".\Private$\AirportCustoms");
                messageQueue.Label = "Newly Created Queue";
            }

            

            //XElement CheckInFile = XElement.Load(@"CheckeInPassenger.xml");
            XElement CheckInFile = XElement.Load(@"CheckedInPassenger.xml");
            Console.WriteLine(CheckInFile);
            string Label = "Passenger";
            
            

            messageQueue.Send(CheckInFile, Label);
            Console.ReadLine();

           
        }
    }
}
