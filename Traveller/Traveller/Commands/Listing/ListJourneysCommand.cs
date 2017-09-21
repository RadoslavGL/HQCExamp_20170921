using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ICommand
    {
        private readonly IDatabase database;

        public ListJourneysCommand(IDatabase database)
        {
            Guard.WhenArgument(database, "database").IsNull().Throw();

            this.database = database;
            
        }

        public string Execute(IList<string> parameters)
        {
            var journeys = this.database.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
