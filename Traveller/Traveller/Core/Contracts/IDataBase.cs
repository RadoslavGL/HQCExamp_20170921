using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Contracts
{
    public interface IDatabase
    {
        IList<IVehicle> Vehicles
        {
            get;
        }

        IList<IJourney> Journeys
        {
            get;
        }

        IList<ITicket> Tickets
        {
            get;
        }

    }
}
