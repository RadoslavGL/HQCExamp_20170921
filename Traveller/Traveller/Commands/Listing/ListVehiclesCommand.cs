using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ICommand
    {
        private readonly IDatabase database;

        public ListVehiclesCommand(IDatabase database)
        {
            Guard.WhenArgument(database, "database").IsNull().Throw();

            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var vehicles = this.database.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}
