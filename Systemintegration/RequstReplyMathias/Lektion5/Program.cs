using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lektion5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String Request = @".\Private$\BluffCityRequestQueueAIC";
            String ReplySAS = @".\Private$\BluffCityReplyQueueSAS";
            String ReplySW = @".\Private$\BluffCityReplyQueueSW";
            String ReplyKLM = @".\Private$\BluffCityReplyQueueKLM";
            String Invalid = @".\Private$\InvalidQueue";

            Requestor SAS1 = new Requestor(Request, ReplySAS, "SK123");
            Requestor KLM = new Requestor(Request, ReplyKLM, "KL124");
            Requestor SW = new Requestor(Request, ReplySW, "SW125");
            AIC Aic = new AIC(Request, Invalid);

            SAS1.Send();
            SAS1.ReceiveSync();
            KLM.Send();
            KLM.ReceiveSync();
            SW.Send();
            SW.ReceiveSync();
        }
    }
}
