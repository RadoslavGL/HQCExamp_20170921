using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var journeys = Engine.Instance.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
