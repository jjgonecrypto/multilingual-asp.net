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
using Localization;

namespace TaiyoBussan.Trading
{
    

    public partial class DynamicEdit_imp : DynamicEdit
    {
        public String EmptyText = "[nothing is set. click to set text]";

        //public String NavigateUrl = null;


        public override String EditText
        {
            get
            {
                return this.txtForEdit.Text;
            }
        }


       

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //NOTE: the following is too tightly bound to be generic

            //--> probably should occur as an extension or something
            //the solution would be to have some delegate be called in the base 
            //webpage that does some action in this initialise

            //bind this event to the base page event handler
            this.OnSubmit += new EventHandler(((TBWebPage)this.Page).DynamicEdit_Submit);

            this.EditingActive = AdminUtil.IsAdminLoggedIn();

            //this is required for a UserControl (handled by custom control though)
            if (!_hasFirst)
            {
                //set this as the first instance of the control in the page
                _isFirst = true;
                _hasFirst = true;
            }
        }

        

        protected void Page_Load(object sender, EventArgs e)
        {
            

            //add the localization control
            //NOTE: when this becomes a custom control, the control should be passed 
            //in as a child
            /*
            switch (this.Type)
            {
                case DynamicEditType.HyperLink:
                    LocalizedHyperLink hyperlink = new LocalizedHyperLink();

                    if (EditingActive)
                    {
                        //hyperlink text should just be simple [Go]

                    }
                    hyperlink.Key = this.Key;
                    hyperlink.NavigateUrl = this.NavigateUrl;
                    hyperlink.ReplaceText = EmptyText;
                    plhText.Controls.Add(hyperlink);
                    break;
                default:
                    LocalizedLiteral literal = new LocalizedLiteral();
                    literal.Key = this.Key;
                    literal.ReplaceText = EmptyText;
                    plhText.Controls.Add(literal);
                    break;

            }
            */


            LocalizedLiteral literal = new LocalizedLiteral();
            literal.Key = this.Key;
            
            if (IsFirst && EditingActive)
            {
                plhScriptOnce.Visible = true;
            }


            if (!EditingActive)
            {
                editingData.Visible = false;
                plhScriptAlways.Visible = false;

            }
            else
            {
                literal.ReplaceText = EmptyText;
                

                btnCancel.OnClientClick = "jsi.aspdotnet.getControlInstance('" + this.UniqueID + "').lock(); return false;";

                containingData.Attributes.Add("onclick", "jsi.aspdotnet.getControlInstance('" + this.UniqueID + "').edit();");
                containingData.Attributes.Add("onmouseover", "this.style.cursor='pointer';");

                //show the required javascript for this control if it is the first instance of itself
                if (this.IsFirst)
                {
                    plhScriptOnce.Visible = true;
                }

                txtForEdit.CssClass = "tinymce" + EditType.ToString();

                //add the content inside the textbox as well
               // LocalizedLiteral literalInside = new LocalizedLiteral();
                //literalInside.Key = this.Key;

                //txtForEdit.Controls.Add(literalInside);
                
            }

            plhText.Controls.Add(literal);



        }


        
    }
}