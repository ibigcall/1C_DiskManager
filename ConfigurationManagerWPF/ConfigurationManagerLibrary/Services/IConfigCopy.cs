using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ConfigurationManagerLibrary.Data;


namespace ConfigurationManagerLibrary.Services
{
    interface IConfigCopy
    {
        void CopyConfigs( string ExistingPath, ObservableCollection<Configuration> configs, int CounterOfObject);
    }
}
