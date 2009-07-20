using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Business;

namespace PetShop.Services.CustomCode
{
    public class ProfileManager
    {
        #region Private Members

        private const string _ANONYMOUS_USERNAME = "Anonymous";

        #endregion

        #region Instance

        public static ProfileManager Instance
        {
            get { return Nested.Current; }
        }

        private class Nested
        {
            static Nested()
            {
                Current = new ProfileManager();
            }

            /// <summary>
            /// Current singleton instance.
            /// </summary>
            internal readonly static ProfileManager Current;
        }

        #endregion

        /// <summary>
        /// Gets the Anonymous user.
        /// </summary>
        /// <returns>The Anonymous user</returns>
        public Profile GetAnonymousUser()
        {
            return GetCurrentUser(_ANONYMOUS_USERNAME);
        }

        /// <summary>
        /// Gets a user by the username.
        /// </summary>
        /// <param name="username">the username.</param>
        /// <returns>The user if it is found, otherwise returns the anonymous user.</returns>
        public Profile GetCurrentUser(string username)
        {
            //Make sure the username is not empty.
            if (string.IsNullOrEmpty(username.Trim()))
            {
                username = _ANONYMOUS_USERNAME;
            }

            //Get the profile.
            var profileService = new ProfileService();
            Profile profile = profileService.GetByUsernameApplicationName(username, ".NET Pet Shop 4.0");

            //Check to see if the profile exists.
            if (profile == null)
            {
                //If the username is the Anonymous user then create it.
                if (username == _ANONYMOUS_USERNAME)
                    return CreateUser(username, true);

                return CreateUser(username, false);
            }

            //return profile.
            return profile;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="isAnonymous">True if the the user anonymous.</param>
        /// <returns>A newly created user.</returns>
        public Profile CreateUser(string username, bool isAnonymous)
        {
            var profile = new Profile();
            profile.Username = username;
            profile.ApplicationName = ".NET Pet Shop 4.0";
            profile.IsAnonymous = isAnonymous;
            profile.LastActivityDate = DateTime.Now;
            profile.LastUpdatedDate = DateTime.Now;

            var profileService = new ProfileService();
            profileService.Save(profile);

            return profile;
        }
    }
}
