using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using PetShop.Business;
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
            var categoryService = new CategoryService();
            productsList.DataSource = categoryService.GetByCategoryId(categoryId).ProductCollection;
            productsList.DataBind();
        }
    }
}