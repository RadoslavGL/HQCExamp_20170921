using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Factories;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            var bus = TravellerFactory.Instance.CreateBus(passengerCapacity, pricePerKilometer);
            Engine.Instance.Vehicles.Add(bus);

            return $"Vehicle with ID {Engine.Instance.Vehicles.Count - 1} was created.";
        }
    }
}
