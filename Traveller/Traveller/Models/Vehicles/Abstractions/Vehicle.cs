using System;
using System.Text;

using Traveller.Models.Vehicles.Enums;

namespace Traveller.Models.Vehicles.Abstractions
{
    public abstract class Vehicle : IVehicle
    {
        private int passengerCapacity;
        private decimal pricePerKilometer;

        protected Vehicle(int passengerCapacity, decimal pricePerKilometer)
        {
            this.PassangerCapacity = passengerCapacity;
            this.PricePerKilometer = pricePerKilometer;
        }

        public virtual int PassangerCapacity
        {
            get
            {
                return this.passengerCapacity;
            }
            protected set
            {
                if (value < 1 || value > 800)
                {
                    throw new ArgumentOutOfRangeException("A vehicle with less than 1 passengers or more than 800 passengers cannot exist!");
                }

                this.passengerCapacity = value;
            }
        }

        public virtual decimal PricePerKilometer
        {
            get
            {
                return this.pricePerKilometer;
            }
            protected set
            {
                if (value < 0.10m || value > 2.50m)
                {
                    throw new ArgumentOutOfRangeException("A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!");
                }

                this.pricePerKilometer = value;
            }
        }

        public abstract VehicleType Type { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Passenger capacity: " + this.PassangerCapacity);
            sb.AppendLine("Price per kilometer: " + this.PricePerKilometer);
            sb.Append("Vehicle type: " + this.Type);

            return sb.ToString();
        }
    }
}
