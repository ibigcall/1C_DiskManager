using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using ConfigurationManagerLibrary.Data;

namespace ConfigurationManagerLibrary.Services
{
    public class LocalConfiguratorProvider : IConfigurationProvider
    {

      
        public List<Configuration> GetConfigurations()
        {
            var result = new List<Configuration>();

            var disks = DriveInfo.GetDrives();
            
            foreach (var disk in disks)
            {
                if (disk.Name== "C:\\" )
                {
                    var root = disk.Name;
                    var files = new List<string>();
                    try
                    {
                        files.AddRange(Directory.GetFiles(root, "VerInfo.txt", SearchOption.TopDirectoryOnly));
                        foreach (var directory in Directory.GetDirectories(root))
                            try
                            {
                                files.AddRange(Directory.GetFiles(directory, "VerInfo.txt", SearchOption.AllDirectories));
                            }
                            catch (System.UnauthorizedAccessException)
                            {

                            }
                    }
                    catch (System.UnauthorizedAccessException)
                    {
                         
                    }

                    foreach (var file in files)
                    {
                        result.Add(new Configuration
                        {
                            Name = new DirectoryInfo(Path.Combine(file, "..\\..\\..")).Name,
                            VersionInfoPath = Path.GetFullPath(file),
                            Version = File.ReadAllText(file),
                            UpdOrSetup = new DirectoryInfo(Path.Combine(file, "..")).Name
                        });
                    }
                ;
                }
            }

            return result;
        }
    }
}
