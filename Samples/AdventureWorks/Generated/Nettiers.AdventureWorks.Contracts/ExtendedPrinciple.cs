
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Principal;

namespace Nettiers.AdventureWorks.Contracts
{
    /// <summary>
    /// This class is used to extend the Thread.CurrentPrincipal object and add
    /// our own custom properties and methods.
    /// </summary>
    public class ExtendedPrincipal : IPrincipal
    {
        #region Fields

        private IIdentity _identity;
        private IUser _user;
        private string _userName;
        
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Extended Principal Constructor
        /// </summary>
        public ExtendedPrincipal(IIdentity identity)
        {
            _identity = identity;
            _userName = identity.Name;
        }

        #endregion Constructors

        #region IPrincipal Members

        /// <summary>
        /// Identity
        /// </summary>
        /// <returns>IIdentity</returns>
        public IIdentity Identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// IsInRole
        /// </summary>
        /// <param name="RoleGuid">Role Guid</param>
        /// <returns>bool</returns>
        public bool IsInRole(Guid RoleGuid)
        {
            return false;
        }

        /// <summary>
        /// IsInRole
        /// </summary>
        /// <param name="roleGuid">role Guid</param>
        /// <returns>bool</returns>
        public bool IsInRole(string roleGuid)
        {
            return false;
        }

        /// <summary>
        /// CanPerformCommand
        /// </summary>
        /// <param name="CommandGuid">Command Guid</param>
        /// <returns>bool</returns>
        public bool CanPerformCommand(Guid CommandGuid)
        {
            return CanPerformCommand(CommandGuid.ToString());
        }

        /// <summary>
        /// CanPerformCommand
        /// </summary>
        /// <param name="CommandGuid">Command Guid</param>
        /// <returns>bool</returns>
        public bool CanPerformCommand(string CommandGuid)
        {
            return false;
        }

        #endregion IPrincipal Members

        #region Public Properties

        /// <summary>
        /// Username
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// UserDetail
        /// </summary>
        public IUser UserDetail
        {
            get { return _user; }
            set { _user = value; }
        }

    	#endregion Public Properties

        #region Public Methods

        #endregion Public Methods
    }
}
