using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Localization;

namespace TaiyoBussan
{
    /// <summary>
    /// Summary description for WebMaster
    /// </summary>
    public abstract class TBWebMaster : MasterPage
    {
        public abstract DropDownList LanguageDropDown
        {
            get;
        }

        public String JS_WYSIWYG_Language
        {
            get
            {
                return ((TBWebPage)this.Page).Locale.WYSIWYGCode;
            }
        }

        public void SetLanguageHeader()
        {
            //Set the language in the HTML base element

            HtmlGenericControl html = (HtmlGenericControl)this.Page.Header.Parent;

            BaseLocale baseLocale = ((TBWebPage)this.Page).Locale;
            
            string lang = baseLocale.RegionCode;

            html.Attributes.Add("lang", lang);
            html.Attributes.Add("xml:lang", lang);
        }




        protected override void OnInit(EventArgs e)
        {
            this.LanguageDropDown.SelectedIndexChanged += new EventHandler(LanguageDropDown_Changed);

            base.OnInit(e);
        }


        public void LanguageDropDown_Changed(object sender, EventArgs e)
        {
            BaseLocale locale = null;

            locale = Locales.FindLocaleByName(this.LanguageDropDown.SelectedValue);

            ((TBWebPage)this.Page).Locale = locale;

            //NOTE: this is not a good solution to the Singleton pattern
            DynamicEdit.ResetFirst();
            DynamicEditPage.ResetFirst();

            Response.Redirect(Request.Url.AbsoluteUri, true);

        }




        protected override void OnPreRender(EventArgs e)
        {

            //ensure the language bar is selected
            this.LanguageDropDown.SelectedValue = ((TBWebPage)this.Page).Locale.Name;

            base.OnPreRender(e);
        }

        public void CheckFlags()
        {
            //handle flag clicks 
            //NOTE: this has been handled by GET to allow for Googlebots to search
            if (Request["lang"] != null)
            {
                switch (Request["lang"])
                {
                    case "en":
                        ((TBWebPage)this.Page).Locale = Locales.America;
                        break;
                    case "pt":
                        ((TBWebPage)this.Page).Locale = Locales.Brazil;
                        break;
                    case "ja":
                        ((TBWebPage)this.Page).Locale = Locales.Japan;
                        break;
                    case "es":
                        ((TBWebPage)this.Page).Locale = Locales.Peru;
                        break;
                }


                string uri = Request.Url.AbsoluteUri;

                uri = System.Text.RegularExpressions.Regex.Replace(uri, "lang=..", "");

                //NOTE: this is not a good solution to the Singleton pattern
                DynamicEdit.ResetFirst();
                DynamicEditPage.ResetFirst();

                //redirect with the new language
                Response.Redirect(uri, true);

            }
        }
    }
}