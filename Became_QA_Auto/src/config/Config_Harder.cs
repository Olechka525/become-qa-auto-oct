using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Became_QA_Auto.src.config
{
    //Class is done using Singleton.
    public class Config_Harder
    {
        List<IConfigProvider> configProviders;

        private static Config_Harder instance;
        static readonly List<IConfigProvider> list = new List<IConfigProvider> { new OSConfigProvider(), new JSONConfigProvider() };

        private static readonly Dictionary<string, string> configDictionary = new Dictionary<string, string>()
        {
            {"USERNAME", "default - Tester" },
            {"BQA_ENV", "default - BQA_ENV"},
            {"PARAMETER_JSON", "default - TesterJSON"},
        };
        
        private Config_Harder(List<IConfigProvider> configProviders)
        {  
            this.configProviders = configProviders;

            Register("USERNAME");
            Register("BQA_ENV");
            Register("PARAMETER_JSON");
        }
        public void Register(string parameterName)
        {
           foreach (var provider in configProviders)
            {
                    string value = provider.Get(parameterName);
                if (value != null)
                {
                    configDictionary[parameterName] = value;
                    return;
                }
                else
                    continue;
                    //throw new Exception($"{parameterName} name is missing in config providers");
            }
        }
        public string Get(string parameterName)
        {
            if (configDictionary.TryGetValue(parameterName, out string value) == false)
                throw new Exception($"Please register '{parameterName}' before usage!");
            return value;
        }
        public static Config_Harder GetInstance()
        {
            if (instance == null)
            {
                instance = new Config_Harder(list);
            }
            return instance;
        }
    }
    public interface IConfigProvider
    {
        string Get(string parameterName);
    }
    public class OSConfigProvider : IConfigProvider
    {
        public string Get(string parameterName)
        {
            var value = Environment.GetEnvironmentVariable(parameterName);
            return value;
        }
    }

    public class JSONConfigProvider : IConfigProvider
    {
        public static Dictionary<string, string> ReadJson(string path)
        {
            var text = File.ReadAllText(path);
            var myDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
            return myDictionary;
        }
        public string Get(string parameterName)
        {
            ReadJson(".\\src\\config\\envs\\qa.json").TryGetValue(parameterName, out string value);
            return value;
        }
    }
}
