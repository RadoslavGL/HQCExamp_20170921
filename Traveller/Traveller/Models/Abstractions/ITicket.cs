namespace Traveller.Models.Abstractions
{
    public interface ITicket
    {
        IJourney Journey { get; }

        decimal AdministrativeCosts { get; }

        decimal CalculatePrice();
    }
}
