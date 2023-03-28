using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave3MessageTransformation
{
    internal class SAS
    {

        public string Airline { get; set; } //SAS 
        public string FlightNo { get; set; } //SK 239 
        public string Destination { get; set; } //JFK  
        public string Origin { get; set; }  //CPH 
        public string ArrivalDeparture { get; set; } //D 
        public string Dato { get; set; }   //6. marts 2017 
        public string Tidspunkt { get; set; } //16:45 

        public static Dictionary<string, string> MonthTranslator = new Dictionary<string, string>();

        

        public SAS(string airline, string flightNo, string destination, string origin, string arivalDeparture, string dato, string tidspunkt)
        {
            Airline = airline;
            FlightNo = flightNo;
            Destination = destination;
            Origin = origin;
            ArrivalDeparture = arivalDeparture;
            this.Dato = dato;
            this.Tidspunkt = tidspunkt;
        }


        public static CanonicalDataModel translator(SAS sas)
        {      
            MonthTranslator.Add("Januar", "1");
            MonthTranslator.Add("Februar", "2");
            MonthTranslator.Add("Marts", "3");
            MonthTranslator.Add("April", "4");
            MonthTranslator.Add("Maj", "5");
            MonthTranslator.Add("Juni", "6");
            MonthTranslator.Add("Juli", "7");
            MonthTranslator.Add("August", "8");
            MonthTranslator.Add("September", "9");
            MonthTranslator.Add("Oktober", "10");
            MonthTranslator.Add("November", "11");
            MonthTranslator.Add("December", "12");

            CanonicalDataModel translated = new CanonicalDataModel();
            translated.Airline = sas.Airline;
            translated.FlightNo = sas.FlightNo;
            translated.Destination = sas.Destination;
            translated.Origin = sas.Origin;
            translated.ArrivalDeparture = sas.ArrivalDeparture;

            string[] datoArray = sas.Dato.Split(' ');
            string[] klokkeslaet = sas.Tidspunkt.Split(':');

            int dag = int.Parse(datoArray[0].Substring(0, datoArray[0].Length-1));
            int maaned = int.Parse(MonthTranslator[datoArray[1]]);
            int aar = int.Parse(datoArray[2]);
            int timer = int.Parse(klokkeslaet[0]);
            int minutter = int.Parse(klokkeslaet[1]);

            DateTime tidspunkt = new DateTime(aar, maaned, dag, timer, minutter, 0);
            translated.Date= tidspunkt;

            return translated;
        }
        public override string ToString()
        {
            return Airline + ", " + FlightNo + ", "+ Destination + ", " + Origin + ", " + ArrivalDeparture + ", " + Dato + ", " + Tidspunkt;
        }

    }
}
