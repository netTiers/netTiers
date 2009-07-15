using System;
using PetShop.Business;
using PetShop.Services;
using PetShop.Services.CustomCode;

namespace PetShop.UI
{
    public partial class UserProfile : System.Web.UI.Page
    {
        /// <summary>
        /// Update profile
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
            if (AddressForm.IsValid)
            {
                if (profile.AccountCollection.Count > 0)
                {
                    Account account = profile.AccountCollection[0];
                    UpdateAccount(ref account, AddressForm.Address);
                }
                else
                {
                    Account account = profile.AccountCollection.AddNew();
                    account.UniqueId = profile.UniqueId;

                    UpdateAccount(ref account, AddressForm.Address);
                }

                var profileService = new ProfileService();
                profileService.Save(profile);
            }

            lblMessage.Text = "Your profile information has been successfully updated.<br>&nbsp;";
        }

        /// <summary>
        /// Updates an account from an address.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="address">The address.</param>
        private static void UpdateAccount(ref Account account, Address address)
        {
            account.FirstName = address.FirstName;
            account.LastName = address.LastName;
            account.Address1 = address.Address1;
            account.Address2 = address.Address2;
            account.City = address.City;
            account.State = address.State;
            account.Zip = address.Zip;
            account.Country = address.Country;
            account.Phone = address.Phone;
            account.Email = address.Email;
        }

        /// <summary>
        /// Handle Page load event 
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
                Response.Redirect("~/SignIn.aspx");

            if (!IsPostBack)
                BindUser();
        }

        /// <summary>
        /// Bind controls to profile
        /// </summary>
        private void BindUser()
        {
            Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
            AddressForm.Address = new Address(profile);
        }
    }
}
