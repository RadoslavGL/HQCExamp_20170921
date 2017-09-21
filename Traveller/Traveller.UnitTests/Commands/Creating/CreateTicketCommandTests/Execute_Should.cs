using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Creating;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;

namespace Traveller.UnitTests.Commands.Creating.CreateTicketCommandTests
{
    //execute works - done, execute writes, execute throws exception
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateTicketAndAddItToDatabase_WhenParametersAreCorrect()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstJourneyMock = new Mock<IJourney>();
            var secondJourneyMock = new Mock<IJourney>();
            var ticketMock = new Mock<ITicket>();
            List<ITicket> tickets = new List<ITicket>();
            List<IJourney> journeys = new List<IJourney>()
            {
                firstJourneyMock.Object,
                secondJourneyMock.Object
            };

            decimal administrativeCosts = 100;

            List<string> parameters = new List<string>()
            {
                "1",
                "100"
            };

            travellerFactoryMock.Setup(m => m.CreateTicket(secondJourneyMock.Object, administrativeCosts))
                .Returns(ticketMock.Object);

            databaseMock.Setup(m => m.Journeys).Returns(journeys);
            databaseMock.Setup(m => m.Tickets).Returns(tickets);

            CreateTicketCommand command = 
                new CreateTicketCommand(travellerFactoryMock.Object, databaseMock.Object);

            // Act
            command.Execute(parameters);

            // Assert
            Assert.AreEqual(1, databaseMock.Object.Tickets.Count);
            Assert.AreSame(ticketMock.Object, databaseMock.Object.Tickets.Single());
        }

        [TestMethod]
        public void UponCreatingWritesACorrectMessage_WhenParametersAreCorrect()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstJourneyMock = new Mock<IJourney>();
            var firstTicketMock = new Mock<ITicket>();
            var secondTicketMock = new Mock<ITicket>();
            List<ITicket> tickets = new List<ITicket>()
            {
                firstTicketMock.Object
            };
            List<IJourney> journeys = new List<IJourney>()
            {
                firstJourneyMock.Object
            };

            decimal administrativeCosts = 100;

            List<string> parameters = new List<string>()
            {
                "0",
                "100"
            };

            string expectedResult = "Ticket with ID 1 was created.";

            travellerFactoryMock.Setup(m => m.CreateTicket(firstJourneyMock.Object, administrativeCosts))
                .Returns(secondTicketMock.Object);

            databaseMock.Setup(m => m.Journeys).Returns(journeys);
            databaseMock.Setup(m => m.Tickets).Returns(tickets);

            CreateTicketCommand command =
                new CreateTicketCommand(travellerFactoryMock.Object, databaseMock.Object);

            // Act
            string result = command.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ThrowsExceptionWithSpecificText_WhenParametersAreNotInCorrectFormat()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstJourneyMock = new Mock<IJourney>();
            var secondJourneyMock = new Mock<IJourney>();
            var ticketMock = new Mock<ITicket>();
            List<ITicket> tickets = new List<ITicket>();
            List<IJourney> journeys = new List<IJourney>()
            {
                firstJourneyMock.Object,
                secondJourneyMock.Object
            };

            decimal administrativeCosts = 100;

            List<string> parameters = new List<string>()
            {
                "1",
                "100"
            };

            string expectedResult = "Failed to parse CreateTicket command parameters.";

            travellerFactoryMock.Setup(m => m.CreateTicket(secondJourneyMock.Object, administrativeCosts)).Returns(ticketMock.Object);

            databaseMock.Setup(m => m.Journeys).Throws(new ArgumentException());
            databaseMock.Setup(m => m.Tickets).Returns(tickets);

            CreateTicketCommand command =
                new CreateTicketCommand(travellerFactoryMock.Object, databaseMock.Object);

            // Act
            string result = command.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
