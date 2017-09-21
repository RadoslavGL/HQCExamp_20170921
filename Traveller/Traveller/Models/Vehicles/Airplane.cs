using Traveller.Models.Vehicles.Enums;
using Traveller.Models.Vehicles.Abstractions;

using System.Text;
using System;

namespace Traveller.Models.Vehicles
{
    public class Airplane : Vehicle
    {
        public Airplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood) 
            : base(passengerCapacity, pricePerKilometer)
        {
            this.HasFreeFood = hasFreeFood;
        }

        public override VehicleType Type
        {
            get
            {
                return VehicleType.Air;
            }
        }

        public bool HasFreeFood { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Airplane ----");
            sb.AppendLine(base.ToString());
            sb.Append("Has free food: " + this.HasFreeFood);

            return sb.ToString();
        }
    }
}
