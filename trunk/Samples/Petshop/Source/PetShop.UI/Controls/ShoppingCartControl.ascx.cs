using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using PetShop.Business;
using PetShop.Controls;
using PetShop.Services;
using PetShop.Services.CustomCode;

namespace PetShop.UI.Controls
{
    public partial class ShoppingCartControl : UserControl
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
            TList<Cart> items = profile.CartCollection;
            if (items.Count > 0)
            {
                repShoppingCart.DataSource = items;
                repShoppingCart.DataBind();
                PrintTotal();
                plhTotal.Visible = true;
            }
            else
            {
                repShoppingCart.Visible = false;
                plhTotal.Visible = false;
                lblMsg.Text = "Your cart is empty.";
            }
        }

        /// <summary>
        /// Recalculate the total
        /// </summary>
        private void PrintTotal()
        {
            Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
            if (profile.CartCollection.Count > 0)
                ltlTotal.Text = profile.CartCollection.Sum(c => c.Total).ToString("c");
        }

        /// <summary>
        /// Calculate total
        /// </summary>
        protected void BtnTotal_Click(object sender, ImageClickEventArgs e)
        {
            Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
            
            foreach (RepeaterItem row in repShoppingCart.Items)
            {

                // todo deep save
                TextBox txtQuantity = (TextBox) row.FindControl("txtQuantity");
                ImageButton btnDelete = (ImageButton) row.FindControl("btnDelete");
                TList<Cart> itemsToDelete = new TList<Cart>();
                var cartService = new CartService();
                int quantity;
                if (int.TryParse(WebUtility.InputText(txtQuantity.Text, 10), out quantity))
                {
                    string itemId = btnDelete.CommandArgument;
                    if (quantity > 0)
                    {
                        profile.CartCollection.Find(c => c.ItemId == itemId).Quantity = quantity;
                        cartService.Save(profile.CartCollection.Find(c => c.ItemId == itemId));
                    }
                        
                    else if (quantity == 0)
                    {
                        cartService.Delete(profile.CartCollection.Find(c => c.ItemId == itemId));
                    }

                }
            }


            BindCart();
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
                    profile.WishList.Add(new Cart { ItemId = e.CommandArgument.ToString(), UniqueId = profile.UniqueId, IsShoppingCart = false });
                    break;
            }

        
            BindCart();
        }
    }
}