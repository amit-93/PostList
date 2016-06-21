using System;
using System.Collections.Generic;
using System.Reflection;

namespace PostList
{
    public class Formatter
    {

        static List<string> ConfigKey;
        static Dictionary<string, string> ConfigValue;


        public static IFormatter GetFormatter(string Format)
        {
            string ClassName = "";
            IFormatter IFormat = null;
            string AssemblyName="";

            try
            {
                ConfigKey = new List<string>();
                ConfigKey.Add(Constant.Plain);
                ConfigKey.Add(Constant.Json);
                ConfigKey.Add(Constant.Html);
                ConfigValue = AppConfig.ReadConfig(ConfigKey);
                AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

                if (ConfigValue == null || ConfigValue.Count == 0 || string.IsNullOrWhiteSpace(AssemblyName))
                {
                    ExceptionHandling.ShowException(Constant.Error);
                    return null;
                }

                ClassName = ConfigValue[Format];
                Assembly asm = Assembly.Load(AssemblyName); 
                Type type = asm.GetType(AssemblyName+"."+ ClassName);
                var obj = Activator.CreateInstance(type);
                IFormat = (IFormatter)obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return IFormat;
        }
        }
      
    }

