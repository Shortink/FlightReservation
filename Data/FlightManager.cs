using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservation.Data
{
    public class FlightManager
    {
        static string airportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\res\\airports.csv");
        string flightPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\res\\flights.csv");

        public static List<Flight> flights = new();
        public static List<string> airports = new();
        

        public FlightManager()
        {
            LoadFlights();
        }

        public void LoadFlights()
        {
            foreach (string line in File.ReadAllLines(flightPath))
            {
                string[] parts = line.Split(',');
                string flightNumber = parts[0];
                string airline = parts[1];
                string origin = parts[2];
                string destination = parts[3];
                string day = parts[4];
                string time = parts[5];
                int temp = int.Parse(parts[6]);
                double cost = double.Parse(parts[7]);

                flights.Add(new Flight(flightNumber, airline, origin, destination, day, time, temp, cost));
            }
        }

        //store all airports in a list to be used in airport picker when searching for flights
        public static List<string> GetAirports()
        {
            foreach (string line in File.ReadAllLines(airportPath))
            {
                string[] parts = line.Split(',');
                airports.Add(parts[0]);
            }
            return airports;
        }

        public static List<Flight> DailyFlights()  //returns the first 5 flights of the current day to be displayed on the flight page
        {
            DateTime dt = DateTime.Now;
            List<Flight> dailyFlight = flights.FindAll(flight => flight.Day == dt.DayOfWeek.ToString());
            dailyFlight.RemoveRange(5, dailyFlight.Count - 5);
            return dailyFlight;
        }


        public static List<Flight> FlightFinder(string? origin, string? destination, string? day) 
        {
            if (day == "Any")
            {
                List<Flight> foundFlights = flights.FindAll(flight => flight.Origin == origin && flight.Destination == destination);
                return foundFlights;
            }
            else
            {
                List<Flight> foundFlights = flights.FindAll(flight => flight.Origin == origin && flight.Destination == destination && flight.Day == day);
                return foundFlights;
            }
        }

    }
}
