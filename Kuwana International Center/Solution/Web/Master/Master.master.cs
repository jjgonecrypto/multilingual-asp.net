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
using System.Globalization;
using Localization;

namespace TaiyoBussan.KIC
{
    public partial class Master : WebMaster
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

            this.CheckFlags();

            //update the flag links to point to the current page with a new language setting
            lnkLangEnglish.NavigateUrl = this.Request.Url.AbsolutePath + "?lang=en";
            lnkLangSpanish.NavigateUrl = this.Request.Url.AbsolutePath + "?lang=es";
            lnkLangPortuguese.NavigateUrl = this.Request.Url.AbsolutePath + "?lang=pt";
            lnkLangJapanese.NavigateUrl = this.Request.Url.AbsolutePath + "?lang=ja";


            if (((WebPage)this.Page).Locale == Locales.Japan)
            {
                //turn on sans-serif for japanese
                divMaster.Attributes["class"] = "Master Japanese";
            }
            else
            {
                divMaster.Attributes["class"] = "Master";
            }
            //TODO: show warning if cookies not enabled
            //(Must be done via reload)


            //Show editing info if admin is logged in
            if (AdminUtil.IsAdminLoggedIn())
            {
                plhAdmin.Visible = true;
            }
        }

        
        /*
        protected override void OnInit(EventArgs e)
        {
            this.drpLanguage.SelectedIndexChanged += new EventHandler(drpLanguage_Changed);
            
            base.OnInit(e);
        }
         * */


        
        
    }
}