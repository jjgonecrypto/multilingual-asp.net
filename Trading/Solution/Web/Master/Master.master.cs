using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace TaiyoBussan.Trading
{
    public partial class MasterPage : TradingWebMaster
    {
        public override DropDownList LanguageDropDown
        {
            get
            {
                return this.drpLanguage;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //toggle admin panel if logged in
            if (AdminUtil.IsAdminLoggedIn())
            {
                plhAdmin.Visible = true;
            }

            //toggle link buttons if they aren't used
            switch (((TradingWebPage)this.Page).PageName)
            {
                case TradingPages.Contact:
                    divLnkContact.Attributes["class"] = divLnkContact.Attributes["class"] + " Deactive";
                    lnkContact.NavigateUrl = "";
                    break;
                case TradingPages.Home:
                    divLnkHome.Attributes["class"] = divLnkHome.Attributes["class"] + " Deactive";
                    lnkHome.NavigateUrl = "";
                    break;
            }

            //handle any flag clicks
            this.CheckFlags();
            

            //update the flag links to point to the current page with a new language setting
            lnkLangEnglish.NavigateUrl = this.Request.Url.AbsolutePath + "?lang=en";
            lnkLangPortuguese.NavigateUrl = this.Request.Url.AbsolutePath + "?lang=pt";
            lnkLangJapanese.NavigateUrl = this.Request.Url.AbsolutePath + "?lang=ja";




        }


        





    }
}