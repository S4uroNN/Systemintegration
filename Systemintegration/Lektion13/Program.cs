using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lektion13
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MessageQueue inQueue = new MessageQueue(@".\Private$\AirportCustoms");

            MessageQueue dkQueue = null;
            if (MessageQueue.Exists(@".\Private$\DKNationalityQueue"))
            {
                dkQueue = new MessageQueue(@".\Private$\DKNationalityQueue");
                dkQueue.Label = "DK Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\DKNationalityQueue");
                dkQueue = new MessageQueue(@".\Private$\DKNationalityQueue");
                dkQueue.Label = "Newly Created Queue";
            }
            
            MessageQueue USAQueue = null;
            if (MessageQueue.Exists(@".\Private$\USANationalityQueue"))
            {
                USAQueue = new MessageQueue(@".\Private$\USANationalityQueue");
                USAQueue .Label = "USA Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\USANationalityQueue");
                USAQueue = new MessageQueue(@".\Private$\USANationalityQueue");
                USAQueue.Label = "Newly Created Queue";
            }


            RecipientList list = new RecipientList(inQueue);

            list.AddQueue("DK", dkQueue);
            list.AddQueue("USA", USAQueue);

            Console.ReadLine();
        }
    }
}
