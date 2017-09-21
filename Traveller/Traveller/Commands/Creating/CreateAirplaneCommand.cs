using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Factories;

namespace Traveller.Commands.Creating
{
    public class CreateAirplaneCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            bool hasFreeFood;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                hasFreeFood = bool.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            var airplane = TravellerFactory.Instance.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            Engine.Instance.Vehicles.Add(airplane);

            return $"Vehicle with ID {Engine.Instance.Vehicles.Count - 1} was created.";
        }
    }
}
