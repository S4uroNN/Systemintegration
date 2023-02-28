using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Opgave1
{
    internal class Splitter
    {
        protected MessageQueue inQueue;
        protected MessageQueue passengerQueue;
        protected MessageQueue luggageQueue;

        public Splitter(MessageQueue inQueue, MessageQueue passengerQueue, MessageQueue luggageQueue)
        {
            this.inQueue = inQueue;

            
            string Label = inQueue.Label;
            this.passengerQueue = passengerQueue;
            this.luggageQueue = luggageQueue;
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage); //Set handler on queue
            inQueue.BeginReceive();
        }

        public void OnMessage(object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);
            string label = message.Label;
            XmlDocument xml = new XmlDocument();
            string XmlDocument = null;
            Console.WriteLine(label);
            Stream body = message.BodyStream;
            StreamReader reader = new StreamReader(body);
            XmlDocument = reader.ReadToEnd().ToString();
            xml.LoadXml(XmlDocument);

            XmlNode flight = xml.SelectSingleNode("/FlightDetailsInfoResponse/Flight");
            XmlNode passanger = xml.SelectSingleNode("/FlightDetailsInfoResponse/Passenger");
            passanger.PrependChild(flight);
            XmlNodeList luggagelist = xml.SelectNodes("/FlightDetailsInfoResponse/Luggage");
            

            Console.WriteLine(passanger.InnerText);

            if (passanger != null)
            {
                //string reservationString = passanger.SelectSingleNode("ReservationNumer").Value.ToString();
                //string firstNameString = passanger.SelectSingleNode("FirstName").Value.ToString();
                //string lastNameString = passanger.SelectSingleNode("LastName").Value.ToString();
                //Console.WriteLine("Reservation Number: " + reservationString);
                //Console.WriteLine("First Name: " + firstNameString);
                //Console.WriteLine("Last Name: " + lastNameString);

                passengerQueue.Send(passanger, ""+ luggagelist.Count);
                Console.WriteLine("Besked Sendt");

                foreach (XmlNode item in luggagelist)
                {
                    luggageQueue.Send(item, luggagelist.Count + "");
                    Console.WriteLine("Besked Sendt"); 

                }
            }

            mq.BeginReceive();
        }
    }
}

