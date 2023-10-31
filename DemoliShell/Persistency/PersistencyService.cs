using DemoliShell.Filesystem;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Persistency
{
    internal class PersistencyService
    {
        public const string Filename = "Filesystem.json";
        public PersistencyService() { }
        public static Drive Load() {
            if (System.IO.File.Exists(Filename))
            {
                string json = System.IO.File.ReadAllText(Filename);
                return JsonConvert.DeserializeObject<Drive>(json);
            }
            else
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                DriveInfo winDrive = drives[0];
                Filesystem.Directory rootDir = new Filesystem.Directory(new List<FilesystemItem>(), "\\", DateTime.Now);

                // Dynamic Entity Management Operations for Large Integrated Storage Harnessing Efficiency and Resilience
                return new Drive(rootDir, "C:" ,winDrive.VolumeLabel, "Demolisher", winDrive.DriveType.ToString());
            }

            return null;
        }
        public static void Save(Drive driver)
        {
            string json = JsonConvert.SerializeObject(driver, Formatting.Indented);
            System.IO.File.WriteAllText(Filename, json);
        }
    }
}
