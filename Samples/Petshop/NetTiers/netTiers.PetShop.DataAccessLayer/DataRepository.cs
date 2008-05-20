
#region Using directives

using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;
using netTiers.PetShop.DataAccessLayer.Bases;

#endregion

namespace netTiers.PetShop.DataAccessLayer
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static NetTiersProvider _provider = null;
        private static NetTiersProviderCollection _providers = null;
        
        private static volatile object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Get a reference to the <imageService> section
                        NetTiersServiceSection section = (NetTiersServiceSection)WebConfigurationManager.GetSection("netTiersService");

                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(NetTiersProvider));
                        _provider = _providers[section.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}	
		
		#region "Static properties"
		
		
		
		#region "CategoryProvider"
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Category"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CategoryProviderBase CategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CategoryProvider;
			}
		}
		
		#endregion
		
		
		
		#region "CreditCardProvider"
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CreditCard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CreditCardProviderBase CreditCardProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CreditCardProvider;
			}
		}
		
		#endregion
		
		
		
		#region "ProductProvider"
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductProviderBase ProductProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductProvider;
			}
		}
		
		#endregion
		
		
		
		#region "ItemProvider"
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Item"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ItemProviderBase ItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemProvider;
			}
		}
		
		#endregion
		
		
		
		#region "AccountProvider"
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Account"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static AccountProviderBase AccountProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AccountProvider;
			}
		}
		
		#endregion
		
		
		
		
		#region "ExtendedItemProvider"
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ExtendedItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ExtendedItemProviderBase ExtendedItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ExtendedItemProvider;
			}
		}
		
		#endregion
		
		#endregion
		
	}
}
