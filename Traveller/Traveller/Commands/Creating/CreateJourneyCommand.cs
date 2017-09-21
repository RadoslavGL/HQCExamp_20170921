using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Factories;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateJourneyCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = parameters[0];
                destination = parameters[1];
                distance = int.Parse(parameters[2]);
                vehicle = Engine.Instance.Vehicles[int.Parse(parameters[3])];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateJourney command parameters.");
            }

            var journey = TravellerFactory.Instance.CreateJourney(startLocation, destination, distance, vehicle);
            Engine.Instance.Journeys.Add(journey);

            return $"Journey with ID {Engine.Instance.Journeys.Count - 1} was created.";
        }
    }
}
