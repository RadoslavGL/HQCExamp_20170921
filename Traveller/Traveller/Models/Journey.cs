using System;
using System.Text;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;


namespace Traveller.Models
{
    public class Journey : IJourney
    {
        private string startingLocation;
        private string destination;
        private int distance;

        public Journey(string startingLocation, string destination, int distance, IVehicle vehicle)
        {
            this.StartLocation = startingLocation;
            this.Destination = destination;
            this.Distance = distance;
            this.Vehicle = vehicle;
        }

        public string StartLocation
        {
            get
            {
                return this.startingLocation;
            }
            private set
            {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("The StartingLocation's length cannot be less than 5 or more than 25 symbols long.");
                }

                this.startingLocation = value;
            }
        }

        public string Destination
        {
            get
            {
                return this.destination;
            }
            private set
            {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("The Destination's length cannot be less than 5 or more than 25 symbols long.");
                }

                this.destination = value;
            }
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
            private set
            {
                if (value < 5 || value > 5000)
                {
                    throw new ArgumentOutOfRangeException("The Distance cannot be less than 5 or more than 5000 kilometers.");
                }

                this.distance = value;
            }
        }

        public IVehicle Vehicle { get; private set; }

        public decimal CalculateTravelCosts()
        {
            return this.Distance * Vehicle.PricePerKilometer;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Journey ----");
            sb.AppendLine("Start location: " + this.StartLocation);
            sb.AppendLine("Destination: " + this.Destination);
            sb.AppendLine("Distance: " + this.Distance);
            sb.AppendLine("Vehicle type: " + this.Vehicle.Type);
            sb.Append("Travel costs: " + this.CalculateTravelCosts());

            return sb.ToString();
        }
    }
}
