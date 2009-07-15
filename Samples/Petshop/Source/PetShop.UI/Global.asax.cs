using System;
using System.Diagnostics;
using System.Web.Profile;
using System.Web.Security;
using PetShop.Business;
using PetShop.Services;
using PB = PetShop.Services.CustomCode;
using ProfileManager=System.Web.Profile.ProfileManager;

namespace PetShop.UI
{
    public class Global : System.Web.HttpApplication
    {
        // Carry over profile property values from an anonymous to an authenticated state 
        protected void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs e)
        {
            Profile anonymousProfile = PB.ProfileManager.Instance.GetAnonymousUser();
            Profile profile = PB.ProfileManager.Instance.GetCurrentUser(e.Context.User.Identity.Name);

            //Merge anonymous shopping cart items to the authenticated shopping cart items
            foreach (Cart item in anonymousProfile.CartCollection)
                profile.CartCollection.Add(new Cart() { ItemId = item.ItemId, UniqueId = profile.UniqueId, IsShoppingCart = true, Quantity = item.Quantity});

            //Merge anonymous wishlist items to the authenticated wishlist items
            foreach (Cart item in anonymousProfile.WishList)
                profile.WishList.Add(new Cart() { ItemId = item.ItemId, UniqueId = profile.UniqueId, IsShoppingCart = false, Quantity = item.Quantity });


            var profileService = new ProfileService();
            profileService.Save(profile);

            // Clean up anonymous profile
            ProfileManager.DeleteProfile(e.AnonymousID);
            AnonymousIdentificationModule.ClearAnonymousIdentifier();

            //Clear the cart.
            anonymousProfile.CartCollection.Clear();
            anonymousProfile.WishList.Clear();
            profileService.Save(anonymousProfile);
        }

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError().GetBaseException();
            EventLog.WriteEntry(".NET Pet Shop 4.0", exception.ToString(), EventLogEntryType.Error);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}