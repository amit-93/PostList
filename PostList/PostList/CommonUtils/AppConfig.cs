using System;
using System.Collections.Generic;
using System.Configuration;

namespace PostList
{
    public class AppConfig
    {

        public static Dictionary<string, string> ReadConfig(List<string> ConfigKey)
        {
            string Exception = "";
            Dictionary<string, string> ConfigValue = new Dictionary<string, string>();

            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Exception = Constant.Error;
                }
                else
                {
                    foreach (var key in ConfigKey)
                    {
                        ConfigValue.Add(key,appSettings[key]);
                    }

                    if (ConfigValue.Count==0)
                        Exception = Constant.Error;
                }


                if (!string.IsNullOrWhiteSpace(Exception))
                {
                    ExceptionHandling.ShowException(Exception);
                }

                return ConfigValue;

            }
            catch (ConfigurationErrorsException ex)
            {
                ExceptionHandling.ShowException(ex.Message);
            }
            return ConfigValue;

        }

    }
}
