using System;
using PetShop.Controls;

namespace PetShop.UI
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get page header and title
            Page.Title = WebUtility.GetCategoryName(Request.QueryString["categoryId"]);
        }
    }
}
