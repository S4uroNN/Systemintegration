using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Opgave1
{
    internal class Aggregator
    {
        private MessageQueue _passengerQueue;
        private MessageQueue _luggageQueue;
        private MessageQueue _outQueue;

        private Dictionary<string, XmlNode[]> passangerAndLuggage = new Dictionary<string, XmlNode[]>();

        public Aggregator(MessageQueue passengerQueue, MessageQueue luggageQueue, MessageQueue outQueue)
        {
            _passengerQueue = passengerQueue;
            _luggageQueue = luggageQueue;
            _outQueue = outQueue;

            _passengerQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage); //Set handler on queue
            _passengerQueue.BeginReceive();
            _luggageQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage); //Set handler on queue
            _luggageQueue.BeginReceive();
        }

        public void OnMessage(object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);
            string label = message.Label;
            XmlDocument xml = new XmlDocument();
            string XmlDocument = null;
            Stream body = message.BodyStream;
            StreamReader reader = new StreamReader(body);
            XmlDocument = reader.ReadToEnd().ToString();
            xml.LoadXml(XmlDocument);

            //XmlNode reservation = xml.SelectSingleNode("Luggage/Id");

        }

    }
}
