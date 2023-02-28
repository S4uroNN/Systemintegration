using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lektion5
{
    public class Requestor
    {
        private MessageQueue requestQueue;
        private MessageQueue replyQueue;
        private string flight;

        public Requestor(string requestQueueName, string replyQueueName, string flight)
        {
            if (!MessageQueue.Exists(replyQueueName))
            {
                MessageQueue.Create(replyQueueName);
            }
            requestQueue = new MessageQueue(requestQueueName);
            replyQueue = new MessageQueue(replyQueueName);
            this.flight = flight;
            replyQueue.MessageReadPropertyFilter.SetAll();
            ((XmlMessageFormatter)replyQueue.Formatter).TargetTypeNames = new string[] { "System.String,mscorlib" };
        }

        public void Send()
        {            
            Message requestMessage = new Message();

            requestMessage.Body = flight;
            requestMessage.Label = flight.Substring(0, 2);
            requestMessage.ResponseQueue = replyQueue;
            TimeSpan span = TimeSpan.FromSeconds(20);
            requestMessage.TimeToBeReceived = span;
            Console.WriteLine(requestMessage.TimeToBeReceived);
            requestQueue.Send(requestMessage);
        }

        public void ReceiveSync()
        {
            //Message replyMessage = replyQueue.Receive();
            //MessageQueue.Delete(replyQueue.Path);
            Console.ReadLine();
        }
    }
}