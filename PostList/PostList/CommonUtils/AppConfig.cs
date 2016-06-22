using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace PostList
{
    public class AppConfig
    {
        public static Dictionary<string, string> ConfigValue = null;

        public static Dictionary<string, string> ReadConfig()
        {
            string Exception = "";
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Exception = Constant.Error;
                }
                else
                {
                    var Section = (NameValueCollection)ConfigurationManager.GetSection("appSettings");
                    ConfigValue = new Dictionary<string, string>();
                    foreach (var key in Section.AllKeys)
                    {
                        ConfigValue.Add(key,Section[key].ToString());
                    }
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
