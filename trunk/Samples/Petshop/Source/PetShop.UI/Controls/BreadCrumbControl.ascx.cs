using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PetShop.Controls;

namespace PetShop.UI.Controls
{
    public partial class BreadCrumbControl : System.Web.UI.UserControl
    {
        private const string PRODUCTS_URL = "~/Products.aspx?page=0&categoryId={0}";
        private const string ITEMS_URL = "~/Items.aspx?categoryId={0}&productId={1}";
        private const string DIVIDER = "&nbsp;&#062;&nbsp;";

        protected void Page_Load(object sender, EventArgs e)
        {
            string categoryId = Request.QueryString["categoryId"];

            if (!string.IsNullOrEmpty(categoryId))
            {

                // process Home Page link
                HtmlAnchor lnkHome = new HtmlAnchor {InnerText = "Home", HRef = "~/Default.aspx"};
                plhControl.Controls.Add(lnkHome);
                plhControl.Controls.Add(GetDivider());

                // Process Product page link
                HtmlAnchor lnkProducts = new HtmlAnchor
                                             {
                                                 InnerText = WebUtility.GetCategoryName(categoryId),
                                                 HRef = string.Format(PRODUCTS_URL, categoryId)
                                             };
                plhControl.Controls.Add(lnkProducts);
                
                string productId = Request.QueryString["productId"];
                if (!string.IsNullOrEmpty(productId))
                {

                    // Process Item page link
                    plhControl.Controls.Add(GetDivider());
                    HtmlAnchor lnkItemDetails = new HtmlAnchor
                                                    {
                                                        InnerText = WebUtility.GetProductName(productId),
                                                        HRef = string.Format(ITEMS_URL, categoryId, productId)
                                                    };

                    plhControl.Controls.Add(lnkItemDetails);
                }
            }
        }

        /// <summary>
        /// Create a breadcrumb nodes divider
        /// </summary>
        /// <returns>Literal control containing formatted divider</returns>
        private static Literal GetDivider()
        {
            return new Literal { Text = DIVIDER };
        }
    }
}