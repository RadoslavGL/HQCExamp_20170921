using Traveller.Models.Vehicles.Enums;

namespace Traveller.Models.Vehicles.Abstractions
{
    public interface IVehicle
    {
        int PassangerCapacity { get; }

        decimal PricePerKilometer { get; }

        VehicleType Type { get; }
    }
}
