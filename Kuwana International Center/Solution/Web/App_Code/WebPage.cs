using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;
using System.Xml;
using Localization;
using TaiyoBussan;

namespace TaiyoBussan.KIC
{
    /// <summary>
    /// The base page class for any webpage within the KIC website.
    /// </summary>
    public class WebPage : TBWebPage
    {
        //public static ArrayList DynamicEditControls = new ArrayList();

        protected override String LanguageCookieKey
        {
            get
            {
                return "KIC_Language";
            }
        }

        protected override String ThemeName
        {
            get
            {
                return "Main";
            }
        }
        

        public WebPage()
            : base()
        {

        }

       
    }
}
