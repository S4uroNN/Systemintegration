using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageQueue inQueue = null;
            MessageQueue passangerQueue = null;
            MessageQueue luggageQueue = null;
            MessageQueue resequenceQueue = null;

            


            if (MessageQueue.Exists(@".\private$\airportcheckinoutput"))
            {
                inQueue = new MessageQueue(@".\private$\airportcheckinoutput");
                inQueue.Label = "GateInfo Queue";
            }
            else
            {
                MessageQueue.Create(@".\private$\airportcheckinoutput");
                inQueue = new MessageQueue(@".\private$\airportcheckinoutput");
                inQueue.Label = "GateInfo Queue";
            }

            if (MessageQueue.Exists(@".\private$\airportpassangercheck"))
            {
                passangerQueue = new MessageQueue(@".\private$\airportpassangercheck");
                passangerQueue.Label = "Passenger Queue";
            }
            else
            {
                MessageQueue.Create(@".\private$\airportpassangercheck");
                passangerQueue = new MessageQueue(@".\private$\airportpassangercheck");
                passangerQueue.Label = "Passanger Queue";
            }
            if (MessageQueue.Exists(@".\private$\airportluggagecheck"))
            {
                luggageQueue = new MessageQueue(@".\private$\airportluggagecheck");
                luggageQueue.Label = "Lugagge Queue";
            }
            else
            {
                MessageQueue.Create(@".\private$\airportluggagecheck");
                luggageQueue = new MessageQueue(@".\private$\airportluggagecheck");
                luggageQueue.Label = "Luggage Queue";
            }

            if (MessageQueue.Exists(@".\private$\airportresequencer"))
            {
                resequenceQueue = new MessageQueue(@".\private$\airportresequencer");
                resequenceQueue.Label = "Resequence Queue";
            }
            else
            {
                MessageQueue.Create(@".\private$\airportresequencer");
                resequenceQueue = new MessageQueue(@".\private$\airportresequencer");
                resequenceQueue.Label = "Resequence Queue";
            }



            Splitter splitter = new Splitter(inQueue,passangerQueue,luggageQueue);
            //Resequencer resequencer = new Resequencer(luggageQueue, resequenceQueue);

            Console.ReadLine();
            

        }
    }
}
