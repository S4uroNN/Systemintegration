using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave3MessageTransformation
{
    internal class Program
    {
        static void Main(string[] args)
        {


            SAS sas = new SAS("SAS", "SK 249", "JFK", "CPH", "D", "6. Marts 2017", "16:45");

           Console.WriteLine(SAS.translator(sas));




        }
    }
}
