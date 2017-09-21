using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;

namespace Traveller.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        public void ReturnValidICommand_WhenParametersAreCorrect()
        {
            // Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();

            string fullCommandDummy = "validCommandName 80 0.4 3";
            string stringCommandName = "validCommandName";

            commandFactoryMock.Setup(m => m.ReturnCommand(stringCommandName)).Returns(commandMock.Object);

            CommandParser parser = new CommandParser(commandFactoryMock.Object);

            // Act
            var result = parser.ParseCommand(fullCommandDummy);

            // Assert;
            Assert.AreSame(commandMock.Object, result);

        }

    }
}
