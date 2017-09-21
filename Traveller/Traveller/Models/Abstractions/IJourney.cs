using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Models.Abstractions
{
    public interface IJourney
    {
        string StartLocation { get; }

        string Destination { get; }

        int Distance { get; }

        IVehicle Vehicle { get; }

        decimal CalculateTravelCosts();
    }
}
