using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationManagerLibrary.Data;
using ConfigurationManagerLibrary.Services;
using System.Collections.ObjectModel;

namespace ConfigurationManagerWPF
{
    public class Menu_Actions 
    {
        public void install(System.Windows.Controls.ListBox Listbox, ObservableCollection<Configuration> Configurations)
        {
            int a = Listbox.SelectedIndex;

            System.Diagnostics.Process install = new System.Diagnostics.Process();
            string filename = System.IO.Path.Combine(Configurations[a].VersionInfoPath + "\\..\\" + "\\setup.exe");
            install.StartInfo.FileName = filename;
            install.Start();
        }

        public int delete(System.Windows.Controls.ListBox Listbox, ObservableCollection<Configuration> Configurations)
        {
            return 0;
        }
        public void copy(string localpath, ObservableCollection<Configuration> configs, int CounterOfObject)
        {
            ConfigurationCopy copy = new ConfigurationCopy();
            copy.CopyConfigs(localpath, configs, CounterOfObject);
        }
    }
}
