using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Creating;
using Traveller.Core.Contracts;

namespace Traveller.UnitTests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnAnInstanceOfTicketClass_WhenParametersAreCorrect()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            // Act
            var ticketCreation = new CreateTicketCommand(travellerFactoryMock.Object, databaseMock.Object);

            // Assert
            Assert.IsNotNull(ticketCreation);
        }

        [TestMethod]
        public void ThrowsException_WhenTravellerFactoryIsNull()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTicketCommand(null, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsException_WhenDatabaseIsNull()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTicketCommand(travellerFactoryMock.Object, null));
        }
    }
}
