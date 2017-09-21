using Traveller.Core.Contracts;
using Traveller.Models;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Factories
{
    public class TravellerFactory : ITravellerFactory
    {
        private static readonly ITravellerFactory instanceHolder = new TravellerFactory();

        private TravellerFactory()
        {
        }

        public static ITravellerFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public IVehicle CreateBus(int passengerCapacity, decimal pricePerKilometer)
        {
            return new Bus(passengerCapacity, pricePerKilometer);
        }

        public IVehicle CreateAirplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood)
        {
            return new Airplane(passengerCapacity, pricePerKilometer, hasFreeFood);
        }

        public IVehicle CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts)
        {
            return new Train(passengerCapacity, pricePerKilometer, carts);
        }
        
        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            return new Journey(startLocation, destination, distance, vehicle);
        }

        public ITicket CreateTicket(IJourney journey, decimal administrativeCosts)
        {
            return new Ticket(journey, administrativeCosts);
        }
    }
}
