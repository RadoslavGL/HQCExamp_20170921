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
    public class ParseParameters_Should
    {
        [TestMethod]
        public void ReturnListOfStrings_WhenTheCommandContainsMoreThanOneWord()
        {
            // Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();
            string fullCommandDummy = "validName moreParameters moreParameters moreParameters";
            List<string> fullCommandDummySplit = fullCommandDummy.Split().ToList();
            IList<string> expectedResult = new List<string>()
            {
                "moreParameters",
                "moreParameters",
                "moreParameters"
            };
            //var expectedAdditionalParametersCount = fullCommandDummySplit.Count() - 1;

            commandFactoryMock.Setup(m => m.ReturnCommand(fullCommandDummy)).Returns(commandMock.Object);

            CommandParser parser = new CommandParser(commandFactoryMock.Object);

            // Act
            var result = parser.ParseParameters(fullCommandDummy);

            // Assert
            //Assert.IsInstanceOfType(result, typeof(IList<string>));
            //Assert.AreEqual(result.Count, expectedAdditionalParametersCount);
            CollectionAssert.AreEquivalent(result.ToList(), expectedResult.ToList());

        }

        [TestMethod]
        public void ReturnAnEmptyList_WhenTheCommandContainsOneWord()
        {
            // Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();
            string fullCommandDummy = "validName";
            List<string> fullCommandDummySplit = fullCommandDummy.Split().ToList();

            List<string> expectedResult = new List<string>();

            commandFactoryMock.Setup(m => m.ReturnCommand(fullCommandDummy)).Returns(commandMock.Object);

            CommandParser parser = new CommandParser(commandFactoryMock.Object);

            // Act
            var result = parser.ParseParameters(fullCommandDummy);

            // Assert
            CollectionAssert.AreEquivalent(result.ToList(), expectedResult);
            //Assert.AreEqual(0, result.Count);

        }
    }
}
