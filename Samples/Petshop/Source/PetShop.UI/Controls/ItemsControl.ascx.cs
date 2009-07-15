using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using PetShop.Business;
using PetShop.Services;

namespace PetShop.UI.Controls
{
    public partial class ItemsControl : UserControl
    {
        /// <summary>
        /// Rebind control 
        /// </summary>
        protected void PageChanged(object sender, DataGridPageChangedEventArgs e)
        {
            //reset index
            itemsGrid.CurrentPageIndex = e.NewPageIndex;

            //get category id
            string productId = Request.QueryString["productId"];

            var productService = new ProductService();
            itemsGrid.DataSource = productService.GetByProductId(productId).ItemCollection;
            itemsGrid.DataBind();
        }
    }
}