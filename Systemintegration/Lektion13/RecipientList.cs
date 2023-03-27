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

namespace Lektion13
{
    internal class RecipientList
    {
        private MessageQueue _inqueue;
        private Dictionary<String, MessageQueue> nationalityQueues = new Dictionary<String, MessageQueue>();

        public RecipientList(MessageQueue inq)
        {
            _inqueue = inq;


            _inqueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage); //Set handler on queue
            _inqueue.BeginReceive();
        }

        public void AddQueue(String queueName, MessageQueue outquue)
        {
            nationalityQueues.Add(queueName, outquue);
        }
        public void RemoveQueue(String queueName)
        {
            nationalityQueues.Remove(queueName);
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

            XmlNodeList passportNationality = xml.SelectNodes("/CBPArrivalInfo/Passport/Nationality");

            if(passportNationality != null)
            {
                if(passportNationality.Count > 1)
                {
                    Message copiedMessage = message;
                    foreach (XmlNode item in passportNationality)
                    {
                        if (item.InnerText.Equals("DK"))
                        {
                            nationalityQueues[item.InnerText].Send(copiedMessage);
                        }
                        if (item.InnerText.Equals("USA"))
                        {
                            nationalityQueues[item.InnerText].Send(copiedMessage);
                        }
                    }
                }
                else
                {
                    foreach (XmlNode item in passportNationality)
                    {
                        if (item.InnerText.Equals("DK"))
                        {
                            nationalityQueues[item.InnerText].Send(message);
                        }
                        if (item.InnerText.Equals("USA"))
                        {
                            nationalityQueues[item.InnerText].Send(message);
                        }
                    }
                }
            }



            mq.BeginReceive();

        }
    }
}
