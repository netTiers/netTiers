using System;
using PetShop.Controls;

namespace PetShop.UI
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private const string HEADER_PREFIX = ".NET Pet Shop :: {0}";

        /// <summary>
        /// Create page header on Page PreRender event
        /// </summary>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ltlHeader.Text = Page.Header.Title;
            Page.Header.Title = string.Format(HEADER_PREFIX, Page.Header.Title);
        }

        /// <summary>
        /// Redirect to Search page
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            WebUtility.SearchRedirect(txtSearch.Text);
        }
    }
}
