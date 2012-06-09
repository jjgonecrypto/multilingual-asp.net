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
    public enum DynamicEditEditorType
    {
        Empty = 0,
        Simple = 1,
        Advanced = 2
    }

    public enum DynamicEditType
    {
        Literal = 0
        //HyperLink = 1

    }

    
    public abstract class DynamicEdit : BaseDynamicEdit
    {
        

        public DynamicEditType Type = DynamicEditType.Literal; 
       

        public DynamicEditEditorType EditType = DynamicEditEditorType.Advanced;


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