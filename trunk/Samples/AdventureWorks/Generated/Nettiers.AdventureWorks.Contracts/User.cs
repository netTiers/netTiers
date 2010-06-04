
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nettiers.AdventureWorks.Contracts
{
    /// <summary>
    /// A class to contain a reference for the UserId and Username values.
    /// </summary>
    public class User : IUser
    {
        private int? userID;
        private string username = string.Empty;

        #region IUser Members

        /// <summary>
        /// The UserId
        /// </summary>
        public int? UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// The Username
        /// </summary>
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        #endregion
    }
}
