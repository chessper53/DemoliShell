using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoliShell;
using DemoliShell.Commands;
using Moq;

namespace UnitTestsShell
{
    public interface IConsoleWrapper
    {
        ConsoleColor ForegroundColor { get; set; }
    }

    [TestClass]
    public class SetColorCommandTest
    {
        [TestMethod]
        public void SetColorGreen_ExecuteSetColor_ExpectedColor_Green()
        {
            // Arrange
            var mockConsole = new Mock<IConsoleWrapper>();
            var setColorCommand = new SetColorCommand();
            setColorCommand.Parameters = new List<string> { "Green" };
            mockConsole.SetupProperty(c => c.ForegroundColor);

            // Act
            setColorCommand.Execute();

            // Assert
            mockConsole.VerifySet(c => c.ForegroundColor = ConsoleColor.Green, Times.Once);
        }
    }
}
