using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave3MessageTransformation
{
    public class CanonicalDataModel
    {
        public string Airline { get; set; } //bare navnet
        public string FlightNo { get; set; }//behold det som det er?
        public string Destination { get; set;} //Bare behold navnet som det er
        public string Origin { get; set; } // -||-
        public string ArrivalDeparture { get; set; } //A eller D. hvis tom, så fx null
        public DateTime Date { get; set; } // fx 03/06/2017 16:45


        public CanonicalDataModel(string airline, string flightNo, string destination, 
            string origin, string arrivalDeparture, DateTime date)
        {
            this.Airline = airline;
            this.FlightNo = flightNo;
            this.Destination = destination;
            this.Origin = origin;
            this.ArrivalDeparture = arrivalDeparture;
            this.Date = date;

        }

        public CanonicalDataModel() { }

        public override string ToString()
        {
            return Airline + ", " + FlightNo + ", " + Destination + ", " + Origin + ", " + ArrivalDeparture + ", " + Date;
        }


    }
}
