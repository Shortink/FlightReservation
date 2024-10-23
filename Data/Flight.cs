using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservation.Data
{
    public class Flight
    {
        string flightNumber;
        string airline;
        string origin;
        string destination;
        string day;
        string time;
        int temp; // idk what this is supposed to be
        double cost;


        public string FlightNumber { get => flightNumber; set => flightNumber = value; }
        public string Airline { get => airline; set => airline = value; }
        public string Origin { get => origin; set => origin = value; }
        public string Destination { get => destination; set => destination = value; }
        public string Day { get => day; set => day = value; }
        public string Time { get => time; set => time = value; }
        public int Temp { get => temp; set => temp = value; }
        public double Cost { get => cost; set => cost = value; }

        public Flight()
        {
        }

        public Flight(string flightNumber, string airline, string origin, string destination, string day, string time, int temp, double cost)
        {
            this.flightNumber = flightNumber;
            this.airline = airline;
            this.origin = origin;
            this.destination = destination;
            this.day = day;
            this.time = time;
            this.temp = temp;
            this.cost = cost;
        }
    }
}
