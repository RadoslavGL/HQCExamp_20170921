using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var vehicles = Engine.Instance.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}
