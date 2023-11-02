using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DemoliShell.Filesystem;

namespace DemoliShell.Filesystem
{
    public class PathHandler
    {
        CommandOutputWriter outputWriter = new CommandOutputWriter();

        public string GetFullPath(Directory currentDirectory, Drive drive)
        {
            string fullPath = "";

            bool parentDirExists = true;
            Directory loopDir = currentDirectory;

            do
            {
                if(loopDir.ParentDirectory != null)
                {
                    fullPath = "\\" + loopDir.Name + fullPath;
                }
                else
                {
                    fullPath = loopDir.Name + fullPath;
                }

                if (loopDir.ParentDirectory != null)
                {


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

        public Directory GetDirectory(string path, Directory currentDir, Drive drive)
        {
            Directory resultDir = currentDir;
            string pattern = @"\w{1}:";
            bool pathexist = false;

            Regex regex = new Regex(pattern);

            string[] splitted = path.Split('\\');


            foreach(string word in splitted)
            {
                MatchCollection matches = regex.Matches(word);

                if (word.Equals(".."))
                {
                    if(resultDir.ParentDirectory != null)
                    {
                        resultDir = resultDir.ParentDirectory;
                    }
                }
                else if (matches.Count > 0)
                {
                    resultDir = drive.RootDirectory;
                    pathexist = true;
                }
                else
                {
                    foreach (FilesystemItem item in resultDir.FilesystemItems)
                    {
                        if (item.Name == word && item is Directory)
                        {
                            resultDir = item as Directory;
                            pathexist = true;
                            break;
                        }
                    }
                    if (!pathexist)
                    {
                        outputWriter.WriteLine("Your Path is invalid!");
                    }
                }
            }

            return resultDir;
        }
    }
}