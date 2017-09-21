using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Factories;
using Traveller.Models;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                journey = Engine.Instance.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = TravellerFactory.Instance.CreateTicket(journey, administrativeCosts);
            Engine.Instance.Tickets.Add(ticket);

            return $"Ticket with ID {Engine.Instance.Tickets.Count - 1} was created.";
        }
    }
}
