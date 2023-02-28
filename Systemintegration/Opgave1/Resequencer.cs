using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Opgave1
{
    internal class Resequencer
    {
        private MessageQueue _inQueue;
        private MessageQueue _outQueue;

        public int Count { get; set; }
        //#protected List<XmlNode> MessageList = new List<XmlNode>();
        private readonly Dictionary<string, XmlNode[]> messages = new Dictionary<string, XmlNode[]>();




        public Resequencer(MessageQueue inQueue, MessageQueue outQueue)
        {
            _inQueue = inQueue;
            _outQueue = outQueue;
            Count = 1;

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
            Stream body = message.BodyStream;
            StreamReader reader = new StreamReader(body);
            XmlDocument = reader.ReadToEnd().ToString();
            xml.LoadXml(XmlDocument);

            //XmlNode reservation = xml.SelectSingleNode("Luggage/Id");
            XmlNode identifikation = xml.SelectSingleNode("Luggage/Identification");
            //int idNumber = Int32.Parse(identifikation.InnerText);
            string idNumber = xml.SelectSingleNode("/Luggage/Id").InnerText;

            XmlNode identification = xml.SelectSingleNode("/Luggage/Identification");
            int identificationNumber = Int32.Parse(identification.InnerText);

            if (!messages.ContainsKey(idNumber))
            {
                messages.Add(idNumber, new XmlNode[Int32.Parse(label)]);
                messages[idNumber][identificationNumber-1] = xml.SelectSingleNode("/Luggage");
            }
            else
            {
                messages[idNumber][identificationNumber-1] = xml.SelectSingleNode("/Luggage");
                if (messages[idNumber].Length == Int32.Parse(label))
                {
                    foreach (XmlNode node in messages[idNumber])
                    {
                        _outQueue.Send(node);
                    }
                    messages.Remove(idNumber);
                }
            }


            //if (idNumber == Count)
            //{
            //    _outQueue.Send(message);

            //    Count++;
            //    foreach (XmlNode node in MessageList)
            //    {
            //        if (Int32.Parse(node.SelectSingleNode("Luggage/Identification").InnerText) == Count)
            //        {
            //            _outQueue.Send(node);
            //            Count++;
            //            Console.WriteLine(node.InnerText);
            //        }
            //    }
            //    if (Count == Int32.Parse(label))
            //    {
            //        Count = 1;
            //    }
            //}
            //else
            //{
            //    MessageList.Add(xml.SelectSingleNode("Luggage"));

            //}


            mq.BeginReceive();
        }
    }
}
