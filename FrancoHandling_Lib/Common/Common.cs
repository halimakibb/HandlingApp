﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FrancoHandling_Lib
{
    public class Common
    {
        public static string GetIP4Address()
        {
            string IP4Address = string.Empty;

            if (HttpContext.Current != null)
            {
                foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
                {
                    if (IPA.AddressFamily.ToString() == "InterNetwork")
                    {
                        IP4Address = IPA.ToString();
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }

            if (!string.IsNullOrEmpty(IP4Address))
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            return IP4Address;
        }

        public static string GetHostName
        {
            get { return Dns.GetHostName().ToString(); }
        }
    }
}
