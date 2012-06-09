using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

namespace TaiyoBussan
{
    public static class AdminUtil
    {
        private static String AdminUsernameKey = "adminUsername";
        
        private static String AdminPasswordKey = "adminPassword";

        private static String AdminSessionKey = "Administrator";

        private static String AdminEditStatusKey = "AdminEditStatus";


        public static Boolean EditStatus
        {
            get
            {
                if (!IsAdminLoggedIn())
                {
                    return false;
                }

                if (HttpContext.Current.Session[AdminEditStatusKey] == null)
                {
                    return false;
                }
                else
                {
                    return (Boolean)HttpContext.Current.Session[AdminEditStatusKey];
                }
            }
            set
            {
                HttpContext.Current.Session[AdminEditStatusKey] = value;
            }
        }


        /// <summary>
        /// Check to see if administrator is currently logged in
        /// </summary>
        /// <returns></returns>
        public static Boolean IsAdminLoggedIn()
        {


//TEMP!!
//return true;



            if (HttpContext.Current.Session[AdminSessionKey] == null)
            {
                return false;
            }
            return ((Boolean)HttpContext.Current.Session[AdminSessionKey]) == true;
        }

        /// <summary>
        /// Perform login of administrator
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Status of login - Successful or not.</returns>
        public static Boolean CheckLoginCredentials(string username, string password)
        {
            // check credientials
            if (username != WebConfigurationManager.AppSettings[AdminUsernameKey] ||
                password != WebConfigurationManager.AppSettings[AdminPasswordKey])
            {
                return false;
            }

            HttpContext.Current.Session[AdminSessionKey] = true;

            HttpContext.Current.Session.Timeout = 30;

            return true;
        }

        /// <summary>
        /// Log out the current administrator.
        /// </summary>
        public static void Logout()
        {
            HttpContext.Current.Session.RemoveAll();

            HttpContext.Current.Session.Abandon();
        }

    }
}