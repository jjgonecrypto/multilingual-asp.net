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
    
    public abstract class BaseDynamicEdit : UserControl
    {
        private bool _editActive = true;
        private String _key = null;
        protected bool _isFirst = false;



        /// <summary>
        /// Gets or sets the status of the editing box, if it should appear on a click.
        /// </summary>
        public bool EditingActive
        {
            get
            {
                return _editActive;
            }
            set
            {
                _editActive = value;
            }
        }

        
        /// <summary>
        /// The unique key that this editing field represents
        /// </summary>
        public String Key
        {
            get
            {
                return this._key;
            }
            set
            {
                this._key = value;
            }
        }


        //for teseting in UserCOntrol only
        //- as a custom control, this will be determined by the base class.
        public Boolean IsFirst
        {
            get
            {
                return _isFirst;
            }
        }

        public event EventHandler OnSubmit;

        public abstract String EditText
        {
            get;
        }
 

        
        protected void Submit_Clicked(object sender, EventArgs e)
        {
            OnSubmit(sender, e);
        }

        

    }
}