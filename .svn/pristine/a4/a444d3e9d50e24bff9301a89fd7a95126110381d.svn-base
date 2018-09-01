using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib
{
    public class Sessions
    {
        public static string c_SessionEnableMenu = "EnableMenu";
                
        public static bool EnableMenu()
        {
            bool b = false;
            if (System.Web.HttpContext.Current.Session[c_SessionEnableMenu] != null)
                b = true;

            System.Web.HttpContext.Current.Session[c_SessionEnableMenu] = b;
            return (bool)System.Web.HttpContext.Current.Session[c_SessionEnableMenu];
        }

    }
}
