#region Using directives
using System;
using System.ComponentModel;
using System.Security;
using System.Web.Security;
using System.Security.Principal;
using System.Web.Profile;
using PetShop.Business;
using PetShop.Data;

using Microsoft.Practices.EnterpriseLibrary.Security;
#endregion Using directives

namespace PetShop.Services
{
	/// <summary>
	/// The class that is available in case role based security is required at runtime.  
	/// It will be made availabe through the entities themselves.
	/// </summary>
	public partial class SecurityContextBase<Entity> where Entity : IEntity, new()
	{
		#region Fields
        private object profile = null;
        private IIdentity identity = null;
        private IPrincipal principal = null;
		private IAuthorizationProvider ruleProvider = null;
		//private ISecurityCacheProvider securityCacheProvider = null; 
		private static readonly string ruleProviderKey = "NetTiers.RuleProvider";
		private static object syncObject = new object();
		#endregion Fields
		
		#region Properties
        /// <summary>
        /// The Current IIdentity.
        /// </summary>
        public virtual IIdentity Identity
        {
            get { return identity; }
            set { identity = value; }
        }

        /// <summary>
        /// The Current Profile .
        /// </summary>
        public virtual object Profile
        {
            get { return profile; }
            set { profile = value; }
        }

        /// <summary>
        ///  The Current IPrincipal .
        /// </summary>
        public virtual IPrincipal Principal
        {
            get { return principal; }
            set { principal = value; }
        }
		
		/// <summary>
		///  The Current Authorization Rule Provider
		/// </summary>
		public IAuthorizationProvider RuleProvider
		{
			get{ 
					if (ruleProvider == null)
					{
						lock(syncObject)
						{
							ruleProvider = AuthorizationFactory.GetAuthorizationProvider(ruleProviderKey);
						}
					}
					return ruleProvider;
				}	
			set
			{
				lock(syncObject)
				{
					ruleProvider = value;	
				}
			}
		}
		#endregion Properties
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SecurityContext class.
		/// </summary>
		public SecurityContextBase()
		{
			this.Identity = System.Threading.Thread.CurrentPrincipal.Identity;
			this.Principal = System.Threading.Thread.CurrentPrincipal;
		}
		#endregion Constructors		
		
		#region Public methods
		/// <summary>
		/// Determine whether user is authorized for the rule based on the rule provider
		/// </summary>
		public virtual bool IsAuthorized(string ruleToCheck)
		{			
			try
			{
				if (ConnectionScope.Current.DataProvider.EnableMethodAuthorization)
				{
					return RuleProvider.Authorize(Principal, string.Format("{0}.{1}", typeof(Entity).FullName , ruleToCheck));
				}
			}
			catch ( Exception )
			{
				//Method has yet to be configured in config file
				//throw;
			}
			
			return true;
		}
		#endregion Public methods		
	}
}
