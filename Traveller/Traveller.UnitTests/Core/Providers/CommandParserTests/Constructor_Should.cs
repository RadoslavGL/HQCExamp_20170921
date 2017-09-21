using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;

namespace Traveller.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnAnInstanceOfCommandParserClass_WhenParametersAreCorrect()
        {
            // Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();

            // Act
            var parserCreation = new CommandParser(commandFactoryMock.Object);

            // Assert
            Assert.IsNotNull(parserCreation);
        }

        [TestMethod]
        public void ThrowsException_WhenCommandFactoryIsNull()
        {
            // Arrange

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandParser(null));
        }
    }
}
