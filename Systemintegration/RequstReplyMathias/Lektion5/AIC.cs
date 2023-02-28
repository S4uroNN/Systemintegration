using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Data;

namespace Lektion5
{
    public class AIC
    {
        private MessageQueue invalidQueue;
        private Dictionary<string, string> etaMessages = new Dictionary<string, string>();

        public AIC(String requestQueueName, String invalidQueueName)
        {
            etaMessages.Add("SK123", "2340");
            etaMessages.Add("KL124", "2240");
            etaMessages.Add("SW125", "2140");
            etaMessages.Add("SK126", "2040");
            etaMessages.Add("SW127", "1940");

            MessageQueue requestQueue = new MessageQueue(requestQueueName);
            invalidQueue = new MessageQueue(invalidQueueName);

            requestQueue.MessageReadPropertyFilter.SetAll();
            ((XmlMessageFormatter)requestQueue.Formatter).TargetTypeNames = new string[] { "System.String,mscorlib" };

            try
            {
                requestQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnReceiveCompleted);
                requestQueue.BeginReceive();
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Noget er galt");
            }
        }

        public void OnReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue requestQueue = (MessageQueue)source;
            Message requestMessage = requestQueue.EndReceive(asyncResult.AsyncResult);

            try
            {
                MessageQueue replyQueue = requestMessage.ResponseQueue;
                Message replyMessage = new Message();
                string contents = requestMessage.Body.ToString();
                string label = requestMessage.Label;

                contents = etaMessages[contents];
                replyMessage.Body = contents;
                replyMessage.CorrelationId = requestMessage.Id;

                replyQueue.Send(replyMessage);
            }
            catch (Exception)
            {
                requestMessage.CorrelationId = requestMessage.Id;

                invalidQueue.Send(requestMessage);
            }

            requestQueue.BeginReceive();
        }
    }
}
