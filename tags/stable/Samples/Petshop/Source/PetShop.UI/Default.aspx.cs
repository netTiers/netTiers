using System;
using PetShop.Controls;

namespace PetShop.UI
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Redirect to Search page
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            WebUtility.SearchRedirect(txtSearch.Text);
        }
    }
}
