using System.Text;
using Traveller.Models.Abstractions;

namespace Traveller.Models
{
    public class Ticket : ITicket
    {
        public Ticket(IJourney journey, decimal administrativeCosts)
        {
            this.Journey = journey;
            this.AdministrativeCosts = administrativeCosts;
        }

        public IJourney Journey { get; private set; }

        public decimal AdministrativeCosts { get; private set; }

        public decimal CalculatePrice()
        {
            return this.AdministrativeCosts + this.Journey.CalculateTravelCosts();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Ticket ----");
            sb.AppendLine("Destination: " + this.Journey.Destination);
            sb.Append("Price: " + this.CalculatePrice());

            return sb.ToString();
        }
    }
}
