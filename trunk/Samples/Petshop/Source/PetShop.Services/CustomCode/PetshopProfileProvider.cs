using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Profile;
using PetShop.Business;

namespace PetShop.Services.CustomCode
{
    public sealed class PetShopProfileProvider : ProfileProvider
    {
        #region Private Memebers

        private const string _ERR_INVALID_PARAMETER = "Invalid Profile parameter:";
        private const string _PROFILE_ACCOUNT = "Account";
        private const string _PROFILE_SHOPPINGCART = "ShoppingCart";
        private const string _PROFILE_WISHLIST = "WishList";
        private static string _applicationName = ".NET Pet Shop 4.0";

        #endregion

        #region Overrides of SettingsProvider

        /// <summary>
        /// Gets or sets the name of the currently running application.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that contains the application's shortened name, which does not contain a full path or extension, for example, SimpleAppSettings.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        /// <summary>
        /// Returns the collection of settings property values for the specified application instance and settings property group.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Configuration.SettingsPropertyValueCollection"/> containing the values for the specified settings property group.
        /// </returns>
        /// <param name="context">A <see cref="T:System.Configuration.SettingsContext"/> describing the current application use.
        ///                 </param><param name="collection">A <see cref="T:System.Configuration.SettingsPropertyCollection"/> containing the settings property group whose values are to be retrieved.
        ///                 </param><filterpriority>2</filterpriority>
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            var username = (string)context["UserName"];
            var isAuthenticated = (bool)context["IsAuthenticated"];
            Profile profile = ProfileManager.Instance.GetCurrentUser(username);

            var svc = new SettingsPropertyValueCollection();

            foreach (SettingsProperty prop in collection)
            {
                var pv = new SettingsPropertyValue(prop);

                switch (pv.Property.Name)
                {
                    case _PROFILE_SHOPPINGCART:
                        pv.PropertyValue = new CartService().GetByUniqueId(profile.UniqueId);
                        break;
                    case _PROFILE_WISHLIST:
                        pv.PropertyValue = new CartService().GetByUniqueId(profile.UniqueId);
                        break;
                    case _PROFILE_ACCOUNT:
                        if (isAuthenticated)
                            pv.PropertyValue = new Address(profile);
                        break;
                    default:
                        throw new ApplicationException(string.Format("{0} name.", _ERR_INVALID_PARAMETER));
                }

                svc.Add(pv);
            }
            return svc;
        }

        /// <summary>
        /// Sets the values of the specified group of property settings.
        /// </summary>
        /// <param name="context">A <see cref="T:System.Configuration.SettingsContext"/> describing the current application usage.
        ///                 </param><param name="collection">A <see cref="T:System.Configuration.SettingsPropertyValueCollection"/> representing the group of property settings to set.
        ///                 </param><filterpriority>2</filterpriority>
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            var username = (string)context["UserName"];
            if (string.IsNullOrEmpty(username) || username.Length > 256 || username.IndexOf(",") > 0)
                throw new ApplicationException(string.Format("{0} user name.", _ERR_INVALID_PARAMETER));


            var isAuthenticated = (bool)context["IsAuthenticated"];

            Profile profile = ProfileManager.Instance.GetCurrentUser(username);

            foreach (SettingsPropertyValue pv in collection)
            {
                if (pv.PropertyValue != null)
                {
                    switch (pv.Property.Name)
                    {
                        case _PROFILE_SHOPPINGCART:
                            profile.CartCollection.Add((Cart)pv.PropertyValue);
                            break;
                        case _PROFILE_WISHLIST:
                            profile.WishList.Add((Cart)pv.PropertyValue);
                            break;
                        case _PROFILE_ACCOUNT:
                            if (isAuthenticated)
                            {
                                if (profile.AccountCollection.Count > 0)
                                {
                                    Account account = profile.AccountCollection[0];
                                    UpdateAccount(ref account, (Address)pv.PropertyValue);
                                }
                                else
                                {
                                    Account account = profile.AccountCollection.AddNew();
                                    account.UniqueId = profile.UniqueId;

                                    UpdateAccount(ref account, (Address)pv.PropertyValue);
                                }
                            }

                            break;
                        default:
                            throw new ApplicationException(_ERR_INVALID_PARAMETER + " name.");
                    }
                }
            }

            profile.LastActivityDate = DateTime.Now;
            profile.LastUpdatedDate = DateTime.Now;
            new ProfileService().Save(profile);
        }

        #endregion

        #region Overrides of ProfileProvider

        /// <summary>
        /// When overridden in a derived class, deletes profile properties and information for the supplied list of profiles.
        /// </summary>
        /// <returns>
        /// The number of profiles deleted from the data source.
        /// </returns>
        /// <param name="profiles">A <see cref="T:System.Web.Profile.ProfileInfoCollection"/>  of information about profiles that are to be deleted.
        ///                 </param>
        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            int deleteCount = 0;

            foreach (ProfileInfo p in profiles)
                if (DeleteProfile(p.UserName))
                    deleteCount++;

            return deleteCount;
        }

        /// <summary>
        /// When overridden in a derived class, deletes profile properties and information for profiles that match the supplied list of user names.
        /// </summary>
        /// <returns>
        /// The number of profiles deleted from the data source.
        /// </returns>
        /// <param name="usernames">A string array of user names for profiles to be deleted.
        ///                 </param>
        public override int DeleteProfiles(string[] usernames)
        {
            int deleteCount = 0;

            foreach (string user in usernames)
                if (DeleteProfile(user))
                    deleteCount++;

            return deleteCount;
        }

        /// <summary>
        /// When overridden in a derived class, deletes all user-profile data for profiles in which the last activity date occurred before the specified date.
        /// </summary>
        /// <returns>
        /// The number of profiles deleted from the data source.
        /// </returns>
        /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"/> values, specifying whether anonymous, authenticated, or both types of profiles are deleted.
        ///                 </param><param name="userInactiveSinceDate">A <see cref="T:System.DateTime"/> that identifies which user profiles are considered inactive. If the <see cref="P:System.Web.Profile.ProfileInfo.LastActivityDate"/>  value of a user profile occurs on or before this date and time, the profile is considered inactive.
        ///                 </param>
        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            int count = 0;
            var profileService = new ProfileService();
            foreach (var profile in profileService.GetAll())
            {
                if (profile.LastActivityDate.Value < userInactiveSinceDate)
                {
                    DeleteProfile(profile.Username);
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// When overridden in a derived class, returns the number of profiles in which the last activity date occurred on or before the specified date.
        /// </summary>
        /// <returns>
        /// The number of profiles in which the last activity date occurred on or before the specified date.
        /// </returns>
        /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"/> values, specifying whether anonymous, authenticated, or both types of profiles are returned.
        ///                 </param><param name="userInactiveSinceDate">A <see cref="T:System.DateTime"/> that identifies which user profiles are considered inactive. If the <see cref="P:System.Web.Profile.ProfileInfo.LastActivityDate"/>  of a user profile occurs on or before this date and time, the profile is considered inactive.
        ///                 </param>
        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            var profileList = new TList<Profile>();
            var profileService = new ProfileService();
            foreach (var item in profileService.GetAll())
            {
                if (item.LastActivityDate.Value < userInactiveSinceDate)
                {
                    profileList.Add(item);
                }
            }

            return profileList.Count;
        }

        /// <summary>
        /// When overridden in a derived class, retrieves user profile data for all profiles in the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Web.Profile.ProfileInfoCollection"/> containing user-profile information for all profiles in the data source.
        /// </returns>
        /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"/> values, specifying whether anonymous, authenticated, or both types of profiles are returned.
        ///                 </param><param name="pageIndex">The index of the page of results to return.
        ///                 </param><param name="pageSize">The size of the page of results to return.
        ///                 </param><param name="totalRecords">When this method returns, contains the total number of profiles.
        ///                 </param>
        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            if (pageIndex < 1 || pageSize < 1)
                throw new ApplicationException(string.Format("{0} page index.", _ERR_INVALID_PARAMETER));

            ProfileInfoCollection profiles = new ProfileInfoCollection();

            int counter = 0;
            int startIndex = pageSize * (pageIndex - 1);
            int endIndex = startIndex + pageSize - 1;

            TList<Profile> profileList = new ProfileService().GetAll();
            totalRecords = profileList.Count;

            foreach (Profile profile in profileList)
            {
                if (counter >= startIndex)
                {
                    profiles.Add(new ProfileInfo(profile.Username, profile.IsAnonymous.Value, profile.LastActivityDate.Value, profile.LastUpdatedDate.Value, 0));
                }

                if (counter >= endIndex)
                {
                    break;
                }

                counter++;
            }

            return profiles;
        }

        /// <summary>
        /// When overridden in a derived class, retrieves user-profile data from the data source for profiles in which the last activity date occurred on or before the specified date.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Web.Profile.ProfileInfoCollection"/> containing user-profile information about the inactive profiles.
        /// </returns>
        /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"/> values, specifying whether anonymous, authenticated, or both types of profiles are returned.
        ///                 </param><param name="userInactiveSinceDate">A <see cref="T:System.DateTime"/> that identifies which user profiles are considered inactive. If the <see cref="P:System.Web.Profile.ProfileInfo.LastActivityDate"/>  of a user profile occurs on or before this date and time, the profile is considered inactive.
        ///                 </param><param name="pageIndex">The index of the page of results to return.
        ///                 </param><param name="pageSize">The size of the page of results to return.
        ///                 </param><param name="totalRecords">When this method returns, contains the total number of profiles.
        ///                 </param>
        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            if (pageIndex < 1 || pageSize < 1)
                throw new ApplicationException(string.Format("{0} page index.", _ERR_INVALID_PARAMETER));

            ProfileInfoCollection profiles = new ProfileInfoCollection();

            int counter = 0;
            int startIndex = pageSize * (pageIndex - 1);
            int endIndex = startIndex + pageSize - 1;

            var profileList = new TList<Profile>();
            var profileService = new ProfileService();
            foreach (var item in profileService.GetAll())
            {
                if (item.LastActivityDate.Value < userInactiveSinceDate)
                {
                    profileList.Add(item);
                }
            }

            totalRecords = profileList.Count;

            foreach (Profile profile in profileList)
            {
                if (counter >= startIndex)
                {
                    profiles.Add(new ProfileInfo(profile.Username, profile.IsAnonymous.Value, profile.LastActivityDate.Value, profile.LastUpdatedDate.Value, 0));
                }

                if (counter >= endIndex)
                {
                    break;
                }

                counter++;
            }

            return profiles;
        }

        /// <summary>
        /// When overridden in a derived class, retrieves profile information for profiles in which the user name matches the specified user names.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Web.Profile.ProfileInfoCollection"/> containing user-profile information for profiles where the user name matches the supplied <paramref name="usernameToMatch"/> parameter.
        /// </returns>
        /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"/> values, specifying whether anonymous, authenticated, or both types of profiles are returned.
        ///                 </param><param name="usernameToMatch">The user name to search for.
        ///                 </param><param name="pageIndex">The index of the page of results to return.
        ///                 </param><param name="pageSize">The size of the page of results to return.
        ///                 </param><param name="totalRecords">When this method returns, contains the total number of profiles.
        ///                 </param>
        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            if (pageIndex < 1 || pageSize < 1)
                throw new ApplicationException(string.Format("{0} page index.", _ERR_INVALID_PARAMETER));

            ProfileInfoCollection profiles = new ProfileInfoCollection();

            int counter = 0;
            int startIndex = pageSize * (pageIndex - 1);
            int endIndex = startIndex + pageSize - 1;

            var foundProfile = new ProfileService().GetByUsernameApplicationName(usernameToMatch, this.ApplicationName);
            //totalRecords = profileList.Count;
            totalRecords = 0;
            if (foundProfile != null)
            {
                totalRecords = 1;
                profiles.Add(new ProfileInfo(foundProfile.Username, foundProfile.IsAnonymous.Value, foundProfile.LastActivityDate.Value, foundProfile.LastUpdatedDate.Value, 0));
            }

            return profiles;
        }

        /// <summary>
        /// When overridden in a derived class, retrieves profile information for profiles in which the last activity date occurred on or before the specified date and the user name matches the specified user name.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Web.Profile.ProfileInfoCollection"/> containing user profile information for inactive profiles where the user name matches the supplied <paramref name="usernameToMatch"/> parameter.
        /// </returns>
        /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"/> values, specifying whether anonymous, authenticated, or both types of profiles are returned.
        ///                 </param><param name="usernameToMatch">The user name to search for.
        ///                 </param><param name="userInactiveSinceDate">A <see cref="T:System.DateTime"/> that identifies which user profiles are considered inactive. If the <see cref="P:System.Web.Profile.ProfileInfo.LastActivityDate"/> value of a user profile occurs on or before this date and time, the profile is considered inactive.
        ///                 </param><param name="pageIndex">The index of the page of results to return.
        ///                 </param><param name="pageSize">The size of the page of results to return.
        ///                 </param><param name="totalRecords">When this method returns, contains the total number of profiles.
        ///                 </param>
        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Method(s)

        /// <summary>
        /// Updartes an account from an address class.
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
        /// Deletes profile data from the database for the specified user name.
        /// </summary>
        /// <param name="username">username.</param>
        /// <returns>true if it was deleted.</returns>
        private static bool DeleteProfile(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length > 256 || username.IndexOf(",") > 0)
                throw new ApplicationException(_ERR_INVALID_PARAMETER + " user name.");

            Profile profile = ProfileManager.Instance.GetCurrentUser(username);
            return new ProfileService().Delete(profile);

        }

        #endregion
    }
}
