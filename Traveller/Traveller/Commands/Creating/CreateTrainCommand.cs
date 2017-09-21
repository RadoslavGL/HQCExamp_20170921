using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Factories;

namespace Traveller.Commands.Creating
{
    public class CreateTrainCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }

            var train = TravellerFactory.Instance.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            Engine.Instance.Vehicles.Add(train);

            return $"Vehicle with ID {Engine.Instance.Vehicles.Count - 1} was created.";
        }
    }
}
