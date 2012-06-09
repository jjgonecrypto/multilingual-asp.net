using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TaiyoBussan;

namespace TaiyoBussan.Trading
{
    /// <summary>
    /// Summary description for TradingWebPage
    /// </summary>
    public class TradingWebPage : TBWebPage
    {
        protected override String LanguageCookieKey
        {
            get
            {
                return "TBTrading_Lang";
            }
        }

        protected override String ThemeName
        {
            get
            {
                return "Main";
            }
        }

        public TradingPages PageName;

        
       

        public TradingWebPage()
        {
           
        }
    }
}