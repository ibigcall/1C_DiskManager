using System;
using System.Collections.Generic;
using System.Text;
using ConfigurationManagerLibrary.Data;

namespace ConfigurationManagerLibrary.Services
{
    public interface IConfigurationProvider
    {
        List<Configuration> GetConfigurations();
    }
}
