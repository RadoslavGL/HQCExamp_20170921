using Ninject.Modules;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Core.Providers;

namespace Traveller.Ninject
{
    public class TravellerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<ITravellerFactory>().To<TravellerFactory>().InSingletonScope();


            this.Bind<ICommand>().To<CreateAirplaneCommand>().Named("CreateAirplane");
            this.Bind<ICommand>().To<CreateBusCommand>().Named("CreateBus");
            this.Bind<ICommand>().To<CreateJourneyCommand>().Named("CreateJourney");
            this.Bind<ICommand>().To<CreateTicketCommand>().Named("CreateTicket");
            this.Bind<ICommand>().To<CreateTrainCommand>().Named("CreateTrain");

            this.Bind<ICommand>().To<ListJourneysCommand>().Named("ListJourneys");
            this.Bind<ICommand>().To<ListTicketsCommand>().Named("ListTickets");
            this.Bind<ICommand>().To<ListVehiclesCommand>().Named("ListVehicles");
        }
    }
}
