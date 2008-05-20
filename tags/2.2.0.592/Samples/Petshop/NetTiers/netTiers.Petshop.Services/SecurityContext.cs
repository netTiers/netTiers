
using System;
using System.ComponentModel;
using System.Security;
using System.Web.Security;
using System.Security.Principal;
using System.Web.Profile;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

using Microsoft.Practices.EnterpriseLibrary.Security;
//using Microsoft.Practices.EnterpriseLibrary.Security.Cache.CachingStore;

namespace netTiers.Petshop.Services
{
	/// <summary>
	/// The class that is available in case role based security is required at runtime.  
	/// It will be made availabe through the entities themselves.
	/// </summary>
	public class SecurityContext<Entity> where Entity : IEntity, new()
	{
		/// <summary>
		/// Initializes a new instance of the SecurityContext class.
		/// </summary>
		public SecurityContext()
		{
			this.Identity = System.Threading.Thread.CurrentPrincipal.Identity;
			this.Principal = System.Threading.Thread.CurrentPrincipal;
		}
		
		
        private object profile = null;
        private IIdentity identity = null;
        private IPrincipal principal = null;
		private IAuthorizationProvider ruleProvider = null;
		//private ISecurityCacheProvider securityCacheProvider = null; 
		private static readonly string ruleProviderKey = "NetTiers.RuleProvider";
		private static object syncObject = new object();
		
        /// <summary>
        /// The Current IIdentity .
        /// </summary>
        public IIdentity Identity
        {
            get { return identity; }
            set { identity = value; }
        }

        /// <summary>
        /// The Current Profile .
        /// </summary>
        public object Profile
        {
            get { return profile; }
            set { profile = value; }
        }

        /// <summary>
        ///  The Current IPrincipal .
        /// </summary>
        public IPrincipal Principal
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
		
		/// <summary>
		/// Determine whether user is authorized for the rule based on the rule provider
		/// </summary>
		public bool IsAuthorized(string ruleToCheck)
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
	}

    /// <summary>
    /// Used to create a general view of the current context.  
    /// Useful for firing events and giving the UI a picture of 
    /// current State of Operation.
    /// </summary>
    /// <typeparam name="Entity">The Entity object</typeparam>
    /// <typeparam name="Domain">Type that holds </typeparam>
	public class ContextView<Entity, Domain> where Entity : IEntity, new() where Domain : class
	{
		private Entity persistingObject;
		private TransactionManager transactionManager; 
		private SecurityContext<Entity> securityContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextView&lt;Entity, Domain&gt;"/> class.
        /// </summary>
		public ContextView()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextView&lt;Entity, Domain&gt;"/> class.
        /// </summary>
        /// <param name="persistingObject">The persisting object.</param>
        /// <param name="securityContext">The security context.</param>
        public ContextView(Entity persistingObject, SecurityContext<Entity> securityContext)
		{
			this.persistingObject = persistingObject;
			this.securityContext = securityContext;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextView&lt;Entity, Domain&gt;"/> class.
        /// </summary>
        /// <param name="persistingObject">The persisting object.</param>
        /// <param name="securityContext">The security context.</param>
        /// <param name="transactionManager">The transaction manager.</param>
        public ContextView(Entity persistingObject, SecurityContext<Entity> securityContext, TransactionManager transactionManager)
		{
			this.persistingObject = persistingObject;
			this.securityContext = securityContext;
			this.transactionManager = transactionManager;
		}

        /// <summary>
        /// Gets or sets the persisting object.
        /// </summary>
        /// <value>The persisting object.</value>
		public Entity PersistingObject
		{
			get
			{
				return persistingObject;	
			}	
			set
			{
				persistingObject = value;	
			}
		}

        /// <summary>
        /// Gets or sets the security context.
        /// </summary>
        /// <value>The security context.</value>
        public SecurityContext<Entity> SecurityContext
		{
			get
			{
                return securityContext; 	
			}	
			set
			{
				securityContext = value;	
			}
		}

        /// <summary>
        /// Gets or sets the transaction manager.
        /// </summary>
        /// <value>The transaction manager.</value>
		public TransactionManager TransactionManager
		{
			get
			{
				return transactionManager;
			}
			set
			{
				transactionManager = value;
			}
		}
	}	
}
