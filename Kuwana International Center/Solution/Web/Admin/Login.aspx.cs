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

namespace TaiyoBussan.KIC
{
    public partial class Admin_Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["lx"] == "1")
            {
                //do logout 
                AdminUtil.Logout();

                Response.Redirect("~", true);
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            this.Theme = "Main";

        }

        protected override void OnInit(EventArgs e)
        {

            this.btnSubmit.Click += new EventHandler(btnSubmit_Click);


            base.OnInit(e);

        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            //TODO: validate this user 

                //Set some session value 


            if (AdminUtil.CheckLoginCredentials(txtUsername.Text, txtPassword.Text))
            {
 
                //redirect to the home page
                Response.Redirect("~/", true);

            }
            else
            {
                //show error if invalid login
                this.lblError.Text = "Invalid username/password. <br>";
            }
              
                
               
        }
    }
}