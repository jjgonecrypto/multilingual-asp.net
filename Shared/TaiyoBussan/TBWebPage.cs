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
using System.Net.Mail;
using System.Net;
using Localization;

namespace TaiyoBussan
{
    /// <summary>
    /// The base page class for any webpage within the Taiyo Bussan catchment.
    /// </summary>
    public abstract class TBWebPage : Page
    {
        //public static ArrayList DynamicEditControls = new ArrayList();


        protected abstract String LanguageCookieKey
        {
            get;
        }

        protected abstract String ThemeName
        {
            get;
        }


        private BaseLocale _currentLocale = null;


        public BaseLocale Locale
        {
            get
            {

                //need to get the current value - as cookie isn't refreshed till next load
                if (_currentLocale != null)
                {
                    return _currentLocale;
                } 
                else if (Request.Cookies[LanguageCookieKey] != null)
                {
                    return Locales.FindLocale(Request.Cookies[LanguageCookieKey].Value);
                }
                else
                {
                    BaseLocale locale = null;

                    //set default language

                    //try via browser (search only for language)
                    if (this.Request.UserLanguages.Length > 0)
                    {
                        foreach (string lang in this.Request.UserLanguages)
                        {
                            BaseLocale tmp = Locales.FindLocaleByCode(lang.Substring(0,2));

                            if (tmp != null)
                            {
                                return tmp;
                            }

                        }
                    }


                    //default to English if no apt locale in the user's browser
                    return Locales.America;
                }

            }
            set
            {
                _currentLocale = value;

                HttpCookie cookie = new HttpCookie(LanguageCookieKey, value.RegionCode);
                
                //Set expiration of language to 1 year
                cookie.Expires = DateTime.Now.AddYears(1);
                
                Response.Cookies.Add(cookie);
            }
        }

        public TBWebPage()
            : base()
        {

        }

        public void Page_PreInit(object sender, EventArgs e)
        {
            this.Page.Theme = this.ThemeName;

            
            
            this.Request.ContentEncoding = System.Text.UTF8Encoding.UTF8;

            this.Response.HeaderEncoding = System.Text.UTF8Encoding.UTF8;

            this.Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;

        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);


            //Set the language - early in the page cycle


            this.DoLanguage();

            ((TBWebMaster)(this.Master)).SetLanguageHeader();

            //if admin is logged in, don't enforce loading of default culture info
            if (AdminUtil.IsAdminLoggedIn())
            {
                Localization.ResourceManager.LoadDefault = false;
            }

            

            //activate all DynamicEdit controls that OnSubmit 
            //should call the event handler in this class
          /*  if (AdminUtil.IsAdminLoggedIn())
            {
                //loop through the page for DynamicEdit controls
                //and set their OnSubmit to this object
                IEnumerator allCtrls = DynamicEditControls.GetEnumerator();

                
                while (allCtrls.MoveNext())
                {
                    DynamicEdit de = (DynamicEdit)allCtrls.Current;

                    de.OnSubmit += new EventHandler(DynamicEdit_Submit);
                }

            }*/

        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
        }


        protected void DoLanguage()
        {

            CultureInfo c = Locale.Culture;
            Thread.CurrentThread.CurrentCulture = c;
            Thread.CurrentThread.CurrentUICulture = c;

        }

       

        /// <summary>
        /// Uses ASP.NET 2.0 built-in encryption to modify the web.config 
        /// file and encrypt the appSettings.
        /// 
        /// Source: http://davidhayden.com/blog/dave/archive/2005/11/17/2572.aspx
        /// </summary>
        private void ProtectSection()
        {
            //This area can be changed.
            string sectionName = "appSettings";

            //NOTE: 
            //this uses the machine's key for encryption, and therefore 
            //shouldn't be used on sites with multiple servers
            //the alternative is RSA Protected, but is more complicated.
            //http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag2/html/paght000006.asp
            string provider = "DataProtectionConfigurationProvider";


            Configuration config =
                WebConfigurationManager.
                    OpenWebConfiguration(Request.ApplicationPath);

            ConfigurationSection section =
                         config.GetSection(sectionName);

            if (section != null &&
                      !section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection(provider);
                config.Save();
            }
        }

         
        /// <summary>
        /// Uses ASP.NET 2.0 built-in encryption to modify the web.config 
        /// file and dencrypt the appSettings.
        /// 
        private void UnProtectSection()
        {
            string sectionName = "appSettings";

            Configuration config =
                WebConfigurationManager.
                    OpenWebConfiguration(Request.ApplicationPath);

            ConfigurationSection section =
                      config.GetSection(sectionName);

            if (section != null &&
                  section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
                config.Save();
            }
        }
        


        /// <summary>
        /// Update the XML resource file with the appropriate data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DynamicEdit_Submit(object sender, EventArgs e)
        {
            if (!AdminUtil.IsAdminLoggedIn())
            {
                throw new Exception("Cannot modify XML - Admin not logged in.");
            }

            //get the sender control
            DynamicEdit control = (DynamicEdit)((WebControl)sender).NamingContainer;    
          
            //get the Key from the control
            String key = control.Key;

            //open the appropriate language XML file
            XmlDocument doc = new XmlDocument();

            string filename = Localization.ResourceManager.GetCurrentFilename();
            
            doc.PreserveWhitespace = true;
            
            doc.Load(filename);

            //find the node with the matching key
            XmlNode node = doc.SelectSingleNode("Resource/item[@name='" + key + "']");

            if (node != null)
            {
                //enter this data into the node
                node.InnerXml = control.EditText;
            }
            else
            {
                //else create a node with the key 
                XmlNode root = doc.SelectSingleNode("Resource");
                XmlElement item = doc.CreateElement("item");
                item.SetAttribute("name",key);
                item.InnerXml = control.EditText;

                root.AppendChild(item);
            }

            //save the xml file
            doc.Save(filename);

            //clear the cache of text
            Localization.ResourceManager.ClearCache();
        }

        //the data has been submitted for an edit 
        public void DynamicEditPage_Submit(object sender, EventArgs e)
        {
            DynamicEditPage dep = ((DynamicEditPage)(((Button)sender).NamingContainer));


            //open the appropriate language XML file
            XmlDocument doc = new XmlDocument();

            string filename = Localization.ResourceManager.GetCurrentFilename();

            doc.PreserveWhitespace = true;

            doc.Load(filename);

            

            if (dep.IsEdit)
            {
                //update xml

                //find the node with the matching key
                XmlElement page = (XmlElement)doc.SelectSingleNode("Resource/pages[@name='" + dep.Key + "']/page[@index='" + dep.EditingIndex.ToString() + "']");


                page.SelectSingleNode("title").InnerXml = dep.EditTitle;
                page.SelectSingleNode("teaser").InnerXml = dep.EditTeaser;
                page.SelectSingleNode("text").InnerXml = dep.EditText;


            }
            else
            {
                //create page in xml
                XmlElement pages = (XmlElement)doc.SelectSingleNode("Resource/pages[@name='" + dep.Key + "']");

                //add a new pages section if none found
                if (pages == null)
                {
                    XmlElement root = (XmlElement)doc.SelectSingleNode("Resource");
                    pages = doc.CreateElement("pages");

                    XmlAttribute key = doc.CreateAttribute("name");
                    key.Value = dep.Key;

                    pages.Attributes.Append(key);

                    pages = (XmlElement) root.AppendChild(pages);

                }

                XmlElement page = doc.CreateElement("page");
                page.SetAttribute("index", dep.NewIndex.ToString());

                XmlElement title = doc.CreateElement("title");
                title.InnerXml = dep.EditTitle;
                XmlElement teaser = doc.CreateElement("teaser");
                teaser.InnerXml = dep.EditTeaser;
                XmlElement text = doc.CreateElement("text");
                text.InnerXml = dep.EditText;

                page.AppendChild(title);

                pages.AppendChild(doc.CreateTextNode("\r\n\t"));
                page.AppendChild(teaser);

                pages.AppendChild(doc.CreateTextNode("\r\n\t"));
                page.AppendChild(text);

                pages.AppendChild(doc.CreateTextNode("\r\n\t"));

                pages.AppendChild(page);

            }

            doc.Save(filename);

            //remove the query string from the file
            Response.Redirect(Request.Path + "?s=1", true);

        }

        /// <summary>
        /// Removes a page from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DynamicEditPage_Delete(object sender, EventArgs e)
        {
            DynamicEditPage dep = (DynamicEditPage)sender;

            //open the appropriate language XML file
            XmlDocument doc = new XmlDocument();

            string filename = Localization.ResourceManager.GetCurrentFilename();

            doc.PreserveWhitespace = true;

            doc.Load(filename);


            //find the node with the matching key
            XmlElement page = (XmlElement)doc.SelectSingleNode("Resource/pages[@name='" + dep.Key + "']/page[@index='" + dep.EditingIndex.ToString() + "']");

            //delete the row
            page.ParentNode.RemoveChild(page);

            doc.Save(filename);

            //remove the query string from the file
            Response.Redirect(Request.Path + "?ds=1", true);

        }

       
       

        

    }
}
