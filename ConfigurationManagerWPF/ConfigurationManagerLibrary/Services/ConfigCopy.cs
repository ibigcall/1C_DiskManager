using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using ConfigurationManagerLibrary.Data;

namespace ConfigurationManagerLibrary.Services
{
  public  class ConfigurationCopy : IConfigCopy
    {
        public void CopyConfigs(string localpath, ObservableCollection<Configuration> configs, int CounterOfObject)
        {
           DirectoryInfo SetUpdDirec = new DirectoryInfo (Path.Combine(configs[CounterOfObject].VersionInfoPath + "\\..\\"));
            DirectoryInfo VersionDirec = new DirectoryInfo(Path.Combine(configs[CounterOfObject].VersionInfoPath + "\\..\\..\\"));
            DirectoryInfo NameDirec = new DirectoryInfo(Path.Combine(configs[CounterOfObject].VersionInfoPath + "\\..\\..\\..\\"));
            DirectoryInfo TargetDirectory = new DirectoryInfo(localpath+"\\"+NameDirec.Name);
            if (!TargetDirectory.Exists)
            {
                TargetDirectory.Create();
            }
            DirectoryInfo LocalNameDirectory = new DirectoryInfo(localpath + "\\" + NameDirec.Name + "\\" + VersionDirec.Name);
            if (!LocalNameDirectory.Exists)
            {
                LocalNameDirectory.Create();
            }
            DirectoryInfo LocalVersionDirectory = new DirectoryInfo(localpath + "\\" + NameDirec.Name + "\\" + VersionDirec.Name + "\\" + SetUpdDirec.Name);
            if (!LocalVersionDirectory.Exists)
            {
                LocalVersionDirectory.Create();
            }

            DirectoryInfo TargetFinalPath = new DirectoryInfo(localpath + "\\" + NameDirec.Name + "\\" + VersionDirec.Name + "\\" + SetUpdDirec.Name + "\\");

            foreach (FileInfo files in SetUpdDirec.GetFiles())
              {
                   System.Windows.Forms.MessageBox.Show(files.Name);
                  files.CopyTo(TargetFinalPath + files.Name, true);
              }
                    
                
            
          


        }
    }
}
