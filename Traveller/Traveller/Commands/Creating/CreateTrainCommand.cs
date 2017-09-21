using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;

namespace Traveller.Commands.Creating
{
    public class CreateTrainCommand : ICommand
    {
        private readonly ITravellerFactory travellerFactory;
        private readonly IDatabase database;

        public CreateTrainCommand(ITravellerFactory travellerFactory, IDatabase database)
        {
            Guard.WhenArgument(travellerFactory, "travellerFactory").IsNull().Throw();
            Guard.WhenArgument(database, "database").IsNull().Throw();

            this.travellerFactory = travellerFactory;
            this.database = database;
        }

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

            var train = this.travellerFactory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            this.database.Vehicles.Add(train);

            return $"Vehicle with ID {this.database.Vehicles.Count - 1} was created.";
        }
    }
}
