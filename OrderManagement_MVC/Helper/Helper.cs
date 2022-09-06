using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace OrderManagement_MVC.Helper
{
    public class Helper
    {
        protected static CultureInfo En = new CultureInfo("en-US");
        protected static CultureInfo Fr = new CultureInfo("fr-CA");
        public static CultureInfo Culture;

        Helper()
        {
            En = new CultureInfo("en-US");
            Fr = new CultureInfo("fr-CA");
        }

        public static int Lang
        {
            get
            {
                if (Culture != null)
                {
                    switch (Culture.Name.ToLower())
                    {
                        case "fr-ca":
                            return 1;
                        case "en-us":
                            return 0;
                        default:
                            return 0;
                    }
                }

                return 0;
            }
        }

        public static int CurrentCulture
        {
            set
            {
                switch (value)
                {
                    case 1:
                        Culture = Fr;
                        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = Fr;
                        break;
                    case 0:
                        Culture = En;
                        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = En;
                        break;
                    default:
                        Culture = En;
                        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = En;
                        break;
                }
            }
        }
    }
}