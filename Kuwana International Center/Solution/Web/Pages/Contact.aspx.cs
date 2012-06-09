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
using System.Net.Mail;
using System.Net;
using System.Xml;

namespace TaiyoBussan.KIC
{
    public partial class ContactPage : WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected override void OnInit(EventArgs e)
        {
            //use the event in the base page
            this.btnSubmit.Click += new EventHandler(ContactEmail_Submit);

            base.OnInit(e);
        }



        public void ContactEmail_Submit(object o, EventArgs e)
        {
            Util.SendWebmail(new Webmail(txtName.Text, txtNEmail.Text, txtMessage.Text), this.Locale);

            //clear data
            txtName.Text = "";
            txtNEmail.Text = "";
            txtMessage.Text = "";

            pnlSuccess.Visible = true;
        }

        

    }
}
