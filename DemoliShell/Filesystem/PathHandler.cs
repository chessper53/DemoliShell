using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Filesystem
{
    public class PathHandler
    {
        public string GetFullPath(Directory currentDirectory, Drive drive)
        {
            string fullPath = "";

            bool parentDirExists = true;
            Directory loopDir = currentDirectory;

            do
            {
                if (loopDir.ParentDirectory != null)
                {
                    fullPath = "\\" + loopDir.Name + fullPath;

                    loopDir = loopDir.ParentDirectory;
                }
                else
                {
                    parentDirExists = false;
                }
            } while (parentDirExists);

            fullPath = drive.Label + ":" + fullPath;

            return fullPath;
        }
    }
}
