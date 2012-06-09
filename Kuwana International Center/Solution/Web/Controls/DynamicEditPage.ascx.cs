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
using System.Xml;
using Localization;

namespace TaiyoBussan.KIC
{
    

    public partial class DynamicEditPage_imp : DynamicEditPage
    {

        public override String EditTitle
        {
            get
            {
                return txtTitle.Text;
            }
        }
        public override String EditTeaser
        {
            get
            {
                return txtTeaser.Text;
            }
        }
        public override String EditText
        {
            get
            {
                return txtText.Text;
            }
        }

        public static string PageIndexQueryVariable = "page_index";
        
        public XmlDocument Document = null;

        
        public event EventHandler OnDelete;


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
            //NOTE: the following is too tightly bound to be generic

            //--> probably should occur as an extension or something
            //the solution would be to have some delegate be called in the base 
            //webpage that does some action in this initialise

            this.EditingActive = AdminUtil.EditStatus;

            //bind this event to the base page event handler
            this.OnSubmit += new EventHandler(((WebPage)this.Page).DynamicEditPage_Submit);

            this.OnDelete += new EventHandler(((WebPage)this.Page).DynamicEditPage_Delete);

            //this is required for a UserControl (handled by custom control though)
            if (!_hasFirst)
            {
                //set this as the first instance of the control in the page
                _isFirst = true;
                _hasFirst = true;
            }

            lnkGoEdit.Click += new EventHandler(lnkGoEdit_Clicked);

            lnkBackToNormal.Click += new EventHandler(lnkBackToNormal_Clicked);


            //keep a record of this repeater
            //NOTE: the reason we dont edit the pages here is because a 
            //control will always cause validateRequest to fire even if in the 
            //page directive it is explicitly set to false.
       //     this.PageEditRepeater = this.rptPagesForEdit;

           // this.rptPagesForEdit.ItemCommand += new RepeaterCommandEventHandler(PagesForEdit_ItemCommand);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            
            //5es" element for this page
            string filename = ResourceManager.GetCurrentFilename();
            
            Document = new XmlDocument();
            Document.PreserveWhitespace = true;
            
            Document.Load(filename);

            XmlNodeList list = Document.SelectNodes("Resource/pages[@name='" + this.Key + "']/page");
            
           
            
            if (!EditingActive)
            {
                if (AdminUtil.IsAdminLoggedIn())
                {
                    pnlEditInfo.Visible = true;
                }

                plhPlain.Visible = true;
                pnlEditor.Visible = false;

                rptBookmarks.DataSource = list;

                rptBookmarks.DataBind();

                //bind to rptPages also

                rptPages.DataSource = list;

                rptPages.DataBind();
            }
            else
            {

                //toggle the viewing panels for editing
                plhPlain.Visible = false;
                pnlEditor.Visible = true;


                //work out what the next index should be
                XmlNodeList tmp = Document.SelectNodes("Resource/pages[@name='" + this.Key + "']/page[@index]");
                int index = -1;

                //loop through the found pages to calculate the next index
                foreach (XmlNode x in tmp)
                {
                    if (int.Parse(x.Attributes["index"].Value) > index)
                    {
                        index = int.Parse(x.Attributes["index"].Value);
                    }
                }

                this.NewIndex = index + 1;

                //bind to rptPagesForEdit
                rptPagesForEdit.DataSource = list;

                rptPagesForEdit.DataBind();

            
                //here we are editing a particular page
                if (Request.QueryString[PageIndexQueryVariable] != null)
                {
                    IsEdit = true;

                    EditingIndex = int.Parse(Request.QueryString[PageIndexQueryVariable]);

                    if (Request.QueryString["d"] == "1")
                    {
                        //do delete of this item then return
                        OnDelete(sender, e);

                        return;
                    }

                    if (!IsPostBack)
                    {
                        XmlElement element = (XmlElement)Document.SelectSingleNode("Resource/pages[@name='" + this.Key + "']/page[@index='" + EditingIndex + "']");

                        txtTitle.Text = element.SelectSingleNode("title").InnerXml;

                        txtTeaser.Text = element.SelectSingleNode("teaser").InnerXml;

                        txtText.Text = element.SelectSingleNode("text").InnerXml;

                    }

                    litTitle.Key = "pagesEditingTitle";
                }
                else
                {
                    litTitle.Key = "pagesAddingTitle";
                }
            
            }


        }


        protected void Cancel_Clicked(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }

        protected void lnkGoEdit_Clicked(object sender, EventArgs e)
        {
            AdminUtil.EditStatus = true;

            Response.Redirect(Page.Request.Url.AbsoluteUri.ToString(), true);
        }

        protected void lnkBackToNormal_Clicked(object sender, EventArgs e)
        {
            AdminUtil.EditStatus = false;

            Response.Redirect(Page.Request.Url.AbsoluteUri.ToString(), true);
        }

        
    }
}