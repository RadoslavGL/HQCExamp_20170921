using System;
using Traveller.Models.Vehicles.Enums;
using Traveller.Models.Vehicles.Abstractions;
using System.Text;

namespace Traveller.Models.Vehicles
{
    public class Bus : Vehicle
    {        
        public Bus(int passengerCapacity, decimal pricePerKilometer) 
            : base(passengerCapacity, pricePerKilometer)
        {
        }

        public override VehicleType Type
        {
            get
            {
                return VehicleType.Land;
            }
        }

        public override int PassangerCapacity
        {            
            protected set
            {
                if (value < 10 || value > 50)
                {
                    throw new ArgumentOutOfRangeException("A bus cannot have less than 10 passengers or more than 50 passengers.");
                }

                base.PassangerCapacity = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Bus ----");
            sb.Append(base.ToString());

            return sb.ToString();
        }
    }
}
