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

namespace TaiyoBussan
{
   
    public abstract class DynamicEditPage : BaseDynamicEdit
    {
        
        public abstract String EditTitle
        {
            get;
        }

        public abstract String EditTeaser
        {
            get;
        }

        


        //for DynamicEditPage only
        public int NewIndex = 0;

        public bool IsEdit = false;

        public int EditingIndex = 0;


        protected static Boolean _hasFirst = false;

        public static void ResetFirst()
        {
            _hasFirst = false;
        }


        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            //NOTE: 
            //here we will reset the static flag as it is kept alive through the .NET session
            ResetFirst();
        }
       
    }
}