using System;

namespace PostList
{
    public class Formatter
    {

        public static IFormatter GetFormter(string Format)
        {
            IFormatter IFormat=null;
            try
            {
                switch (Format)
                {
                    case "Plain":
                            IFormat=new PlainData();
                        break;
                    case "Json":
                           IFormat=new JSonData();
                        break;
                    case "Html":
                         IFormat=new HtmlData();
                        break;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return IFormat;
        }
        }
      
    }

