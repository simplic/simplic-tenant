using Simplic.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.Tenant.UnitTest.Mocking
{
    class ConfigurationMock : IConfigurationService
    {
        public T GetValue<T>(string configurationName, string pluginName, string userName, bool noCaching = false)
        {
            return default(T);
        }

        public IEnumerable<ConfigurationValue> GetValues<T>(string pluginName, string userName)
        {
            return new ConfigurationValue[] {  };
        }

        public void SetValue<T>(string configurationName, string pluginName, string userName, T value)
        {
            
        }
    }
}
