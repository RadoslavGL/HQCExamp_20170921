using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var tickets = Engine.Instance.Tickets;

            if (tickets.Count == 0)
            {
                return "There are no registered tickets.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, tickets);
        }
    }
}
