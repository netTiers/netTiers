using System;
using System.Web.UI;

using PetShop.Business;
using PetShop.Services;
using PetShop.Services.CustomCode;

namespace PetShop.UI
{
    public partial class ShoppingCart : Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string itemId = Request.QueryString["addItem"];
                if (!string.IsNullOrEmpty(itemId))
                {
                    Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
                    AddCartItem(ref profile, itemId, 1);

                    var profileService = new ProfileService();
                    profileService.Save(profile);

                    // Redirect to prevent duplictations in the cart if user hits "Refresh"
                    Response.Redirect("~/ShoppingCart.aspx", true);
                }
            }
        }

        private static void AddCartItem(ref Profile profile, string itemId, int quantity)
        {
            int index = 0;
            bool found = false;

            foreach (Cart cart in profile.CartCollection)
            {
                if (cart.ItemId == itemId)
                {
                    found = true;
                    break;
                }

                index++;
            }

            if (found)
                profile.CartCollection[index].Quantity += quantity;
            else
            {
                Item item = new ItemService().GetByItemId(itemId);
                Product product = new ProductService().GetByProductId(item.ProductId);
                Cart cart = new Cart
                                {
                                    UniqueId = profile.UniqueId,
                                    ItemId = itemId,
                                    Name = item.Name,
                                    ProductId = item.ProductId,
                                    IsShoppingCart = true,
                                    Price = item.ListPrice ?? item.UnitCost ?? 0,
                                    Type = product.Name,
                                    CategoryId = product.CategoryId,
                                    Quantity = quantity
                                };

                profile.CartCollection.Add(cart);
            }
        }
    }
}