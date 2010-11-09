using System;
using PetShop.Controls;

namespace PetShop.UI
{
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get page header and title
            Page.Title = WebUtility.GetProductName(Request.QueryString["productId"]);
        }
    }
}
