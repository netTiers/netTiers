using System;
using System.Web.UI.WebControls;

using PetShop.Business;
using PetShop.Services;
using PetShop.Services.CustomCode;

namespace PetShop.UI.Controls
{
    public partial class WishListControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// Handle Page load event
        /// </summary>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCart();
            }
        }

        /// <summary>
        /// Bind repeater to Cart object in Profile
        /// </summary>
        private void BindCart()
        {
            Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);

           TList<Cart> wishList = profile.WishList;
            if (wishList.Count > 0)
            {
                repWishList.DataSource = wishList;
                repWishList.DataBind();
            }
            else
            {
                repWishList.Visible = false;
                lblMsg.Text = "Your wish list is empty.";
            }
        }

        /// <summary>
        /// Handler for Delete/Move buttons
        /// </summary>
        protected void CartItem_Command(object sender, CommandEventArgs e)
        {
            Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
            var cartService = new CartService();
            switch (e.CommandName)
            {
                case "Del":
                    cartService.Delete(profile.CartCollection.Find(c => c.ItemId == e.CommandArgument.ToString()));
                    break;
                case "Move":
                    cartService.Delete(profile.CartCollection.Find(c => c.ItemId == e.CommandArgument.ToString()));
                    profile.CartCollection.Add(new Cart() { ItemId = e.CommandArgument.ToString(), UniqueId = profile.UniqueId, IsShoppingCart = true });
                    break;
            }

            BindCart();
        }
    }
}
