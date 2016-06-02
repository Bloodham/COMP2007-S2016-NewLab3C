using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * @Author: Ryan Jameson
 * @Date: May 26, 2016
 * @Version: 0.0.1 - added SetActivePage method
 * 
 */

namespace COMP2007_S2016_Lab3C
{
    public partial class Navabar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetActivePage();
        }

        /**
         * This method adds a css class of "active" to list items 
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         * 
         * 
         */


        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Contact":
                    contact.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}