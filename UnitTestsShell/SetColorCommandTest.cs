using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoliShell;
using DemoliShell.Commands;
using Moq;

namespace UnitTestsShell
{
    [TestClass]
    public class SetColorCommandTest
    {
        [TestMethod]
        public void SetColorGreen_ExecuteSetColor_ExpectedColor_Green()
        {
            // Arrange
            SetColorCommand command = new SetColorCommand(new TestCommandOutputWriter());
            command.CommandContext.Parameters = new List<string>
            {
                "green"
            };
            ConsoleColor expected = ConsoleColor.Green;

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(expected, command.CommandContext.OutputWriter.ForegroundColor);
        }
    }
}
