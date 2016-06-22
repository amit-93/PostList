using System;
using System.Collections.Generic;
using System.Reflection;

namespace PostList
{
    public class Formatter
    {

        public static IFormatter GetFormatter(string Format)
        {
            string ClassName = "";
            IFormatter IFormat = null;
            string AssemblyName="";

            try
            {
                AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

                if (AppConfig.ConfigValue == null || AppConfig.ConfigValue.Count == 0 || string.IsNullOrWhiteSpace(AssemblyName))
                {
                    ExceptionHandling.ShowException(Constant.Error);
                    return null;
                }

                ClassName = AppConfig.ConfigValue[Format];
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

