using System;
using Traveller.Models.Vehicles.Enums;
using Traveller.Models.Vehicles.Abstractions;
using System.Text;

namespace Traveller.Models.Vehicles
{
    public class Train : Vehicle
    {
        private int carts;

        public Train(int passengerCapacity, decimal pricePerKilometer, int carts) 
            : base(passengerCapacity, pricePerKilometer)
        {
            this.Carts = carts;
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
                if (value < 30 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("A train cannot have less than 30 passengers or more than 150 passengers.");
                }

                base.PassangerCapacity = value;
            }
        }

        public int Carts
        {
            get
            {
                return this.carts;
            }
            private set
            {
                if (value < 1 || value > 15)
                {
                    throw new ArgumentOutOfRangeException("A train cannot have less than 1 cart or more than 15 carts.");
                }

                this.carts = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Train ----");
            sb.AppendLine(base.ToString());
            sb.Append("Carts amount: " + this.carts);

            return sb.ToString();
        }
    }
}
