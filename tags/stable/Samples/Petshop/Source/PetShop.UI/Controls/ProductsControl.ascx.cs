using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetShop.Services;

namespace PetShop.UI.Controls
{
    public partial class ProductsControl : UserControl
    {
        /// <summary>
        /// Rebind control 
        /// </summary>
        protected void PageChanged(object sender, DataGridPageChangedEventArgs e)
        {
            //reset index
            productsList.CurrentPageIndex = e.NewPageIndex;

            //get category id
            string categoryId = Request.QueryString["categoryId"];

            //bind data
            var productService = new ProductService();
            productsList.DataSource = productService.GetByCategoryId(categoryId);
            productsList.DataBind();
        }
    }
}