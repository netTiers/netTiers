using System;
using PetShop.Business;
using PetShop.Services;
using PetShop.Services.CustomCode;

namespace PetShop.UI
{
    public partial class WishList : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string itemId = Request.QueryString["addItem"];
                if (!string.IsNullOrEmpty(itemId))
                {
                    Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
                    profile.WishList.Add(new Cart()
                                             {ItemId = itemId, UniqueId = profile.UniqueId, IsShoppingCart = false});
                    var profileService = new ProfileService();
                    profileService.Save(profile);

                    // Redirect to prevent duplictations in the wish list if user hits "Refresh"
                    Response.Redirect("~/WishList.aspx", true);
                }
            }
        }
    }
}
