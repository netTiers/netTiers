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

                    profile.CartCollection.Add(new Cart() {ItemId = itemId, UniqueId = profile.UniqueId, IsShoppingCart = true});
                    var profileService = new ProfileService();
                    profileService.Save(profile);

                    // Redirect to prevent duplictations in the cart if user hits "Refresh"
                    Response.Redirect("~/ShoppingCart.aspx", true);
                }
            }
        }
    }
}