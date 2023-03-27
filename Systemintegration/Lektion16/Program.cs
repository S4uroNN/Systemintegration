using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lektion16
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MessageQueue AirTrafic = null;
            MessageQueue AirportInformationCenter = null;
            MessageQueue SAS = null;
            MessageQueue KLM = null;
            MessageQueue Southwest = null;

            //Air Traffic Control
            if (MessageQueue.Exists(@".\Private$\AirTrafficControl"))
            {
                AirTrafic = new MessageQueue(@".\Private$\AirTrafficControl");
                AirTrafic.Label = "Air Trafic Control Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\AirTrafficControl");
                AirTrafic = new MessageQueue(@".\Private$\AirTrafficControl");
                AirTrafic.Label = "Newly Created Queue";
            }

            //Airport Information center
            if (MessageQueue.Exists(@".\Private$\AirportInformationCenter"))
            {
                AirportInformationCenter = new MessageQueue(@".\Private$\AirportInformationCenter");
                AirportInformationCenter.Label = "Airport Information Center Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\AirportInformationCenter");
                AirportInformationCenter = new MessageQueue(@".\Private$\AirportInformationCenter");
                AirportInformationCenter.Label = "Newly Created Queue";
            }

            //Sas
            if (MessageQueue.Exists(@".\Private$\airportcompanysas"))
            {
                SAS = new MessageQueue(@".\Private$\airportcompanysas");
                SAS.Label = "SAS Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\airportcompanysas");
                SAS = new MessageQueue(@".\Private$\airportcompanysas");
                SAS.Label = "Newly Created Queue";
            }

            //KLM
            if (MessageQueue.Exists(@".\Private$\airportcompanyklm"))
            {
                KLM = new MessageQueue(@".\Private$\airportcompanyklm");
                KLM.Label = "KLM Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\airportcompanyklm");
                KLM = new MessageQueue(@".\Private$\airportcompanyklm");
                KLM.Label = "Newly Created Queue";
            }


            //SW
            if (MessageQueue.Exists(@".\Private$\airportcompanysw"))
            {
                Southwest = new MessageQueue(@".\Private$\airportcompanysw");
                Southwest.Label = "Southwest Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\airportcompanysas");
                Southwest = new MessageQueue(@".\Private$\airportcompanysw");
                Southwest.Label = "Newly Created Queue";
            }


            WeatherForecast wf = new WeatherForecast("holstebro", "weather", "metric");

            wf.GetConditions();
            Console.ReadLine();
        }
    }
}
