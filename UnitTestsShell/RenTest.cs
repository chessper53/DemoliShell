using DemoliShell.Commands;
using DemoliShell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestsShell;

namespace UnitTeystsShell
{
    [TestClass]
    public class RenTest
    {
        [TestMethod]
        public void DirectoryNamedDir2_RenCommandExecute_DirectoyDir2RenamedTo_NewName()
        {
            // Arrange
            ShellWorkspace shellWorkspace = new ShellWorkspace();

            DemoliShell.Filesystem.Directory dir = new DemoliShell.Filesystem.Directory();
            dir.ParentDirectory = shellWorkspace.CurrentDirectory;
            dir.Name = "dir";

            DemoliShell.Filesystem.Directory dir2 = new DemoliShell.Filesystem.Directory();
            dir2.ParentDirectory = dir;
            dir2.Name = "dir2";
            dir.FilesystemItems.Add(dir2);

            DemoliShell.Filesystem.Directory dir3 = new DemoliShell.Filesystem.Directory();
            dir3.ParentDirectory = dir;
            dir3.Name = "dir3";
            dir.FilesystemItems.Add(dir3);
            shellWorkspace.CurrentDirectory.FilesystemItems.Add(dir);

            RenCommand command = new RenCommand(new TestCommandOutputWriter());
            command.CommandContext.ShellWorkspace = shellWorkspace;
            command.CommandContext.Parameters = new List<string>
            {
                "dir2",
                "newName"
            };
            DemoliShell.Filesystem.Directory expected = dir;
            
            // Act
            command.Execute();

            // Assert
            Assert.IsTrue(shellWorkspace.CurrentDirectory.FilesystemItems.Any(item => item == expected));
        }
    }
}
