using System;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            var itemService = new ItemService();
            itemsGrid.DataSource = itemService.GetByProductId(productId);
            itemsGrid.DataBind();
        }
    }
}