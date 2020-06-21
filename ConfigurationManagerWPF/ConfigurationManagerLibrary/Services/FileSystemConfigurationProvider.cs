using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Text;
using ConfigurationManagerLibrary.Data;

namespace ConfigurationManagerLibrary.Services
{
    public class FileSystemConfigurationProvider : IConfigurationProvider
    {
       
        public List<Configuration> GetConfigurations()
        {

            var result = new List<Configuration>();

            var disks = DriveInfo.GetDrives();
            bool diskisready = false;

            foreach (var disk in disks)
            {
                if (disk.DriveType.ToString() == "CDRom" && disk.IsReady)
                {
                    diskisready = true;
                    var root = disk.Name;

                    var files = Directory.GetFiles(root, "VerInfo.txt", SearchOption.AllDirectories);

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
                    /*   result.AddRange(files.Select(file => new Configuration
                       {
                           Name = new DirectoryInfo(Path.Combine(file, "..\\..\\..")).Name,
                           VersionInfoPath = Path.GetFullPath(file),
                           Version = File.ReadAllText(file),
                           UpdOrSetup = new DirectoryInfo(Path.Combine(file, "..")).Name
                       }))*/;
                }
            
                
                
            }
            if (diskisready == false)
            {
                System.Windows.Forms.MessageBox.Show("Оптический диск не найден");
            }

            return result;
        }
    }
}
