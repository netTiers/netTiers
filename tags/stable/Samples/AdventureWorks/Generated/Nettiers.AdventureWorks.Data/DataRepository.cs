#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
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
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

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
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("Nettiers.AdventureWorks.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.9.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					// use default ConnectionStrings if _section has already been discovered
					if ( _config == null && _section != null )
					{
						return WebConfigurationManager.ConnectionStrings;
					}
					
					return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region SalesTerritoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesTerritory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesTerritoryProviderBase SalesTerritoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesTerritoryProvider;
			}
		}
		
		#endregion
		
		#region LocationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Location"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LocationProviderBase LocationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LocationProvider;
			}
		}
		
		#endregion
		
		#region SalesReasonProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesReasonProviderBase SalesReasonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesReasonProvider;
			}
		}
		
		#endregion
		
		#region SalesPersonQuotaHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesPersonQuotaHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesPersonQuotaHistoryProviderBase SalesPersonQuotaHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesPersonQuotaHistoryProvider;
			}
		}
		
		#endregion
		
		#region SalesOrderHeaderProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesOrderHeader"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesOrderHeaderProviderBase SalesOrderHeaderProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesOrderHeaderProvider;
			}
		}
		
		#endregion
		
		#region SalesOrderHeaderSalesReasonProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesOrderHeaderSalesReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesOrderHeaderSalesReasonProviderBase SalesOrderHeaderSalesReasonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesOrderHeaderSalesReasonProvider;
			}
		}
		
		#endregion
		
		#region ProductModelProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductModel"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductModelProviderBase ProductModelProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductModelProvider;
			}
		}
		
		#endregion
		
		#region SalesTaxRateProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesTaxRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesTaxRateProviderBase SalesTaxRateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesTaxRateProvider;
			}
		}
		
		#endregion
		
		#region SalesPersonProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesPerson"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesPersonProviderBase SalesPersonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesPersonProvider;
			}
		}
		
		#endregion
		
		#region ProductCategoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductCategoryProviderBase ProductCategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductCategoryProvider;
			}
		}
		
		#endregion
		
		#region ProductSubcategoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductSubcategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductSubcategoryProviderBase ProductSubcategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductSubcategoryProvider;
			}
		}
		
		#endregion
		
		#region ProductProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductProviderBase ProductProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductProvider;
			}
		}
		
		#endregion
		
		#region SalesTerritoryHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesTerritoryHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesTerritoryHistoryProviderBase SalesTerritoryHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesTerritoryHistoryProvider;
			}
		}
		
		#endregion
		
		#region PurchaseOrderDetailProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PurchaseOrderDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PurchaseOrderDetailProviderBase PurchaseOrderDetailProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PurchaseOrderDetailProvider;
			}
		}
		
		#endregion
		
		#region SalesOrderDetailProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesOrderDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesOrderDetailProviderBase SalesOrderDetailProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesOrderDetailProvider;
			}
		}
		
		#endregion
		
		#region ProductProductPhotoProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductProductPhoto"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductProductPhotoProviderBase ProductProductPhotoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductProductPhotoProvider;
			}
		}
		
		#endregion
		
		#region ProductReviewProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductReview"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductReviewProviderBase ProductReviewProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductReviewProvider;
			}
		}
		
		#endregion
		
		#region PurchaseOrderHeaderProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PurchaseOrderHeader"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PurchaseOrderHeaderProviderBase PurchaseOrderHeaderProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PurchaseOrderHeaderProvider;
			}
		}
		
		#endregion
		
		#region ProductVendorProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductVendor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductVendorProviderBase ProductVendorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductVendorProvider;
			}
		}
		
		#endregion
		
		#region ScrapReasonProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ScrapReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ScrapReasonProviderBase ScrapReasonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ScrapReasonProvider;
			}
		}
		
		#endregion
		
		#region UnitMeasureProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="UnitMeasure"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UnitMeasureProviderBase UnitMeasureProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UnitMeasureProvider;
			}
		}
		
		#endregion
		
		#region ShiftProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Shift"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ShiftProviderBase ShiftProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ShiftProvider;
			}
		}
		
		#endregion
		
		#region TransactionHistoryArchiveProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TransactionHistoryArchive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TransactionHistoryArchiveProviderBase TransactionHistoryArchiveProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TransactionHistoryArchiveProvider;
			}
		}
		
		#endregion
		
		#region VendorProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vendor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VendorProviderBase VendorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VendorProvider;
			}
		}
		
		#endregion
		
		#region AddressProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Address"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AddressProviderBase AddressProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AddressProvider;
			}
		}
		
		#endregion
		
		#region WorkOrderProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="WorkOrder"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WorkOrderProviderBase WorkOrderProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WorkOrderProvider;
			}
		}
		
		#endregion
		
		#region VendorAddressProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VendorAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VendorAddressProviderBase VendorAddressProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VendorAddressProvider;
			}
		}
		
		#endregion
		
		#region TransactionHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TransactionHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TransactionHistoryProviderBase TransactionHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TransactionHistoryProvider;
			}
		}
		
		#endregion
		
		#region VendorContactProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VendorContact"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VendorContactProviderBase VendorContactProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VendorContactProvider;
			}
		}
		
		#endregion
		
		#region TimestampPkProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TimestampPk"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TimestampPkProviderBase TimestampPkProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TimestampPkProvider;
			}
		}
		
		#endregion
		
		#region ShoppingCartItemProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ShoppingCartItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ShoppingCartItemProviderBase ShoppingCartItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ShoppingCartItemProvider;
			}
		}
		
		#endregion
		
		#region TestVariantProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TestVariant"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TestVariantProviderBase TestVariantProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TestVariantProvider;
			}
		}
		
		#endregion
		
		#region SpecialOfferProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SpecialOffer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SpecialOfferProviderBase SpecialOfferProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SpecialOfferProvider;
			}
		}
		
		#endregion
		
		#region ShipMethodProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ShipMethod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ShipMethodProviderBase ShipMethodProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ShipMethodProvider;
			}
		}
		
		#endregion
		
		#region SpecialOfferProductProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SpecialOfferProduct"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SpecialOfferProductProviderBase SpecialOfferProductProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SpecialOfferProductProvider;
			}
		}
		
		#endregion
		
		#region StateProvinceProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="StateProvince"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static StateProvinceProviderBase StateProvinceProvider
		{
			get 
			{
				LoadProviders();
				return _provider.StateProvinceProvider;
			}
		}
		
		#endregion
		
		#region StoreProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Store"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static StoreProviderBase StoreProvider
		{
			get 
			{
				LoadProviders();
				return _provider.StoreProvider;
			}
		}
		
		#endregion
		
		#region ProductPhotoProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductPhoto"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductPhotoProviderBase ProductPhotoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductPhotoProvider;
			}
		}
		
		#endregion
		
		#region StoreContactProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="StoreContact"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static StoreContactProviderBase StoreContactProvider
		{
			get 
			{
				LoadProviders();
				return _provider.StoreContactProvider;
			}
		}
		
		#endregion
		
		#region ProductModelProductDescriptionCultureProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductModelProductDescriptionCulture"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductModelProductDescriptionCultureProviderBase ProductModelProductDescriptionCultureProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductModelProductDescriptionCultureProvider;
			}
		}
		
		#endregion
		
		#region CurrencyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Currency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CurrencyProviderBase CurrencyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CurrencyProvider;
			}
		}
		
		#endregion
		
		#region CustomerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Customer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerProviderBase CustomerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerProvider;
			}
		}
		
		#endregion
		
		#region CurrencyRateProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CurrencyRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CurrencyRateProviderBase CurrencyRateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CurrencyRateProvider;
			}
		}
		
		#endregion
		
		#region DepartmentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Department"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DepartmentProviderBase DepartmentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DepartmentProvider;
			}
		}
		
		#endregion
		
		#region CustomerAddressProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerAddressProviderBase CustomerAddressProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerAddressProvider;
			}
		}
		
		#endregion
		
		#region CultureProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Culture"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CultureProviderBase CultureProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CultureProvider;
			}
		}
		
		#endregion
		
		#region DatabaseLogProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DatabaseLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DatabaseLogProviderBase DatabaseLogProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DatabaseLogProvider;
			}
		}
		
		#endregion
		
		#region CreditCardProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CreditCard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CreditCardProviderBase CreditCardProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CreditCardProvider;
			}
		}
		
		#endregion
		
		#region BillOfMaterialsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BillOfMaterials"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BillOfMaterialsProviderBase BillOfMaterialsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BillOfMaterialsProvider;
			}
		}
		
		#endregion
		
		#region CountryRegionCurrencyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CountryRegionCurrency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CountryRegionCurrencyProviderBase CountryRegionCurrencyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CountryRegionCurrencyProvider;
			}
		}
		
		#endregion
		
		#region ContactProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Contact"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ContactProviderBase ContactProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ContactProvider;
			}
		}
		
		#endregion
		
		#region AwBuildVersionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AwBuildVersion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AwBuildVersionProviderBase AwBuildVersionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AwBuildVersionProvider;
			}
		}
		
		#endregion
		
		#region CountryRegionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CountryRegion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CountryRegionProviderBase CountryRegionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CountryRegionProvider;
			}
		}
		
		#endregion
		
		#region ContactCreditCardProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ContactCreditCard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ContactCreditCardProviderBase ContactCreditCardProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ContactCreditCardProvider;
			}
		}
		
		#endregion
		
		#region DocumentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Document"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DocumentProviderBase DocumentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DocumentProvider;
			}
		}
		
		#endregion
		
		#region ContactTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ContactType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ContactTypeProviderBase ContactTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ContactTypeProvider;
			}
		}
		
		#endregion
		
		#region EmployeeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Employee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeeProviderBase EmployeeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeeProvider;
			}
		}
		
		#endregion
		
		#region ProductDocumentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductDocument"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductDocumentProviderBase ProductDocumentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductDocumentProvider;
			}
		}
		
		#endregion
		
		#region EmployeeAddressProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmployeeAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeeAddressProviderBase EmployeeAddressProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeeAddressProvider;
			}
		}
		
		#endregion
		
		#region ProductInventoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductInventory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductInventoryProviderBase ProductInventoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductInventoryProvider;
			}
		}
		
		#endregion
		
		#region ProductDescriptionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductDescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductDescriptionProviderBase ProductDescriptionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductDescriptionProvider;
			}
		}
		
		#endregion
		
		#region ProductModelIllustrationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductModelIllustration"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductModelIllustrationProviderBase ProductModelIllustrationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductModelIllustrationProvider;
			}
		}
		
		#endregion
		
		#region ProductListPriceHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductListPriceHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductListPriceHistoryProviderBase ProductListPriceHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductListPriceHistoryProvider;
			}
		}
		
		#endregion
		
		#region ProductCostHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductCostHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductCostHistoryProviderBase ProductCostHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductCostHistoryProvider;
			}
		}
		
		#endregion
		
		#region WorkOrderRoutingProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="WorkOrderRouting"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WorkOrderRoutingProviderBase WorkOrderRoutingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WorkOrderRoutingProvider;
			}
		}
		
		#endregion
		
		#region NullFkeyParentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="NullFkeyParent"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static NullFkeyParentProviderBase NullFkeyParentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.NullFkeyParentProvider;
			}
		}
		
		#endregion
		
		#region EmployeePayHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmployeePayHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeePayHistoryProviderBase EmployeePayHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeePayHistoryProvider;
			}
		}
		
		#endregion
		
		#region NullFkeyChildProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="NullFkeyChild"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static NullFkeyChildProviderBase NullFkeyChildProvider
		{
			get 
			{
				LoadProviders();
				return _provider.NullFkeyChildProvider;
			}
		}
		
		#endregion
		
		#region ErrorLogProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ErrorLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ErrorLogProviderBase ErrorLogProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ErrorLogProvider;
			}
		}
		
		#endregion
		
		#region EmployeeDepartmentHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmployeeDepartmentHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeeDepartmentHistoryProviderBase EmployeeDepartmentHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeeDepartmentHistoryProvider;
			}
		}
		
		#endregion
		
		#region JobCandidateProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobCandidate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobCandidateProviderBase JobCandidateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobCandidateProvider;
			}
		}
		
		#endregion
		
		#region IllustrationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Illustration"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static IllustrationProviderBase IllustrationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.IllustrationProvider;
			}
		}
		
		#endregion
		
		#region AddressTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AddressType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AddressTypeProviderBase AddressTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AddressTypeProvider;
			}
		}
		
		#endregion
		
		#region IndividualProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Individual"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static IndividualProviderBase IndividualProvider
		{
			get 
			{
				LoadProviders();
				return _provider.IndividualProvider;
			}
		}
		
		#endregion
		
		
		#region VAdditionalContactInfoProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VAdditionalContactInfo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VAdditionalContactInfoProviderBase VAdditionalContactInfoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VAdditionalContactInfoProvider;
			}
		}
		
		#endregion
		
		#region VEmployeeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VEmployee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VEmployeeProviderBase VEmployeeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VEmployeeProvider;
			}
		}
		
		#endregion
		
		#region VEmployeeDepartmentProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VEmployeeDepartment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VEmployeeDepartmentProviderBase VEmployeeDepartmentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VEmployeeDepartmentProvider;
			}
		}
		
		#endregion
		
		#region VEmployeeDepartmentHistoryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VEmployeeDepartmentHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VEmployeeDepartmentHistoryProviderBase VEmployeeDepartmentHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VEmployeeDepartmentHistoryProvider;
			}
		}
		
		#endregion
		
		#region VIndividualCustomerProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VIndividualCustomer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VIndividualCustomerProviderBase VIndividualCustomerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VIndividualCustomerProvider;
			}
		}
		
		#endregion
		
		#region VIndividualDemographicsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VIndividualDemographics"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VIndividualDemographicsProviderBase VIndividualDemographicsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VIndividualDemographicsProvider;
			}
		}
		
		#endregion
		
		#region VJobCandidateProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VJobCandidate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VJobCandidateProviderBase VJobCandidateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VJobCandidateProvider;
			}
		}
		
		#endregion
		
		#region VJobCandidateEducationProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VJobCandidateEducation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VJobCandidateEducationProviderBase VJobCandidateEducationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VJobCandidateEducationProvider;
			}
		}
		
		#endregion
		
		#region VJobCandidateEmploymentProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VJobCandidateEmployment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VJobCandidateEmploymentProviderBase VJobCandidateEmploymentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VJobCandidateEmploymentProvider;
			}
		}
		
		#endregion
		
		#region VProductAndDescriptionProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VProductAndDescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VProductAndDescriptionProviderBase VProductAndDescriptionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VProductAndDescriptionProvider;
			}
		}
		
		#endregion
		
		#region VProductModelCatalogDescriptionProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VProductModelCatalogDescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VProductModelCatalogDescriptionProviderBase VProductModelCatalogDescriptionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VProductModelCatalogDescriptionProvider;
			}
		}
		
		#endregion
		
		#region VProductModelInstructionsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VProductModelInstructions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VProductModelInstructionsProviderBase VProductModelInstructionsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VProductModelInstructionsProvider;
			}
		}
		
		#endregion
		
		#region VSalesPersonProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VSalesPerson"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VSalesPersonProviderBase VSalesPersonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VSalesPersonProvider;
			}
		}
		
		#endregion
		
		#region VSalesPersonSalesByFiscalYearsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VSalesPersonSalesByFiscalYears"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VSalesPersonSalesByFiscalYearsProviderBase VSalesPersonSalesByFiscalYearsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VSalesPersonSalesByFiscalYearsProvider;
			}
		}
		
		#endregion
		
		#region VStateProvinceCountryRegionProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VStateProvinceCountryRegion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VStateProvinceCountryRegionProviderBase VStateProvinceCountryRegionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VStateProvinceCountryRegionProvider;
			}
		}
		
		#endregion
		
		#region VStoreWithDemographicsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VStoreWithDemographics"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VStoreWithDemographicsProviderBase VStoreWithDemographicsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VStoreWithDemographicsProvider;
			}
		}
		
		#endregion
		
		#region VVendorProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VVendor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VVendorProviderBase VVendorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VVendorProvider;
			}
		}
		
		#endregion
		
		#endregion
	}
	
	#region Query/Filters
		
	#region SalesTerritoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryFilters : SalesTerritoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryFilters class.
		/// </summary>
		public SalesTerritoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTerritoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTerritoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTerritoryFilters
	
	#region SalesTerritoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesTerritoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesTerritory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryQuery : SalesTerritoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryQuery class.
		/// </summary>
		public SalesTerritoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTerritoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTerritoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTerritoryQuery
		
	#region LocationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LocationFilters : LocationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationFilters class.
		/// </summary>
		public LocationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LocationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LocationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LocationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LocationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LocationFilters
	
	#region LocationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LocationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LocationQuery : LocationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationQuery class.
		/// </summary>
		public LocationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LocationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LocationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LocationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LocationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LocationQuery
		
	#region SalesReasonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesReasonFilters : SalesReasonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesReasonFilters class.
		/// </summary>
		public SalesReasonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesReasonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesReasonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesReasonFilters
	
	#region SalesReasonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesReasonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesReasonQuery : SalesReasonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesReasonQuery class.
		/// </summary>
		public SalesReasonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesReasonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesReasonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesReasonQuery
		
	#region SalesPersonQuotaHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPersonQuotaHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonQuotaHistoryFilters : SalesPersonQuotaHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryFilters class.
		/// </summary>
		public SalesPersonQuotaHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonQuotaHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonQuotaHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonQuotaHistoryFilters
	
	#region SalesPersonQuotaHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesPersonQuotaHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesPersonQuotaHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonQuotaHistoryQuery : SalesPersonQuotaHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryQuery class.
		/// </summary>
		public SalesPersonQuotaHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonQuotaHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuotaHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonQuotaHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonQuotaHistoryQuery
		
	#region SalesOrderHeaderFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderFilters : SalesOrderHeaderFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderFilters class.
		/// </summary>
		public SalesOrderHeaderFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderHeaderFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderHeaderFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderHeaderFilters
	
	#region SalesOrderHeaderQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesOrderHeaderParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderQuery : SalesOrderHeaderParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderQuery class.
		/// </summary>
		public SalesOrderHeaderQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderHeaderQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderHeaderQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderHeaderQuery
		
	#region SalesOrderHeaderSalesReasonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeaderSalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderSalesReasonFilters : SalesOrderHeaderSalesReasonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonFilters class.
		/// </summary>
		public SalesOrderHeaderSalesReasonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderHeaderSalesReasonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderHeaderSalesReasonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderHeaderSalesReasonFilters
	
	#region SalesOrderHeaderSalesReasonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesOrderHeaderSalesReasonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeaderSalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderSalesReasonQuery : SalesOrderHeaderSalesReasonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonQuery class.
		/// </summary>
		public SalesOrderHeaderSalesReasonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderHeaderSalesReasonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderHeaderSalesReasonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderHeaderSalesReasonQuery
		
	#region ProductModelFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelFilters : ProductModelFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelFilters class.
		/// </summary>
		public ProductModelFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelFilters
	
	#region ProductModelQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductModelParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductModel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelQuery : ProductModelParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelQuery class.
		/// </summary>
		public ProductModelQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelQuery
		
	#region SalesTaxRateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTaxRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTaxRateFilters : SalesTaxRateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateFilters class.
		/// </summary>
		public SalesTaxRateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTaxRateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTaxRateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTaxRateFilters
	
	#region SalesTaxRateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesTaxRateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesTaxRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTaxRateQuery : SalesTaxRateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateQuery class.
		/// </summary>
		public SalesTaxRateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTaxRateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTaxRateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTaxRateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTaxRateQuery
		
	#region SalesPersonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonFilters : SalesPersonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilters class.
		/// </summary>
		public SalesPersonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonFilters
	
	#region SalesPersonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesPersonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonQuery : SalesPersonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuery class.
		/// </summary>
		public SalesPersonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonQuery
		
	#region ProductCategoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCategoryFilters : ProductCategoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCategoryFilters class.
		/// </summary>
		public ProductCategoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCategoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCategoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCategoryFilters
	
	#region ProductCategoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductCategoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCategoryQuery : ProductCategoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCategoryQuery class.
		/// </summary>
		public ProductCategoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCategoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCategoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCategoryQuery
		
	#region ProductSubcategoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSubcategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSubcategoryFilters : ProductSubcategoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryFilters class.
		/// </summary>
		public ProductSubcategoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductSubcategoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductSubcategoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductSubcategoryFilters
	
	#region ProductSubcategoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductSubcategoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductSubcategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSubcategoryQuery : ProductSubcategoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryQuery class.
		/// </summary>
		public ProductSubcategoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductSubcategoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductSubcategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductSubcategoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductSubcategoryQuery
		
	#region ProductFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductFilters : ProductFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductFilters class.
		/// </summary>
		public ProductFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductFilters
	
	#region ProductQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductQuery : ProductParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductQuery class.
		/// </summary>
		public ProductQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductQuery
		
	#region SalesTerritoryHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTerritoryHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryHistoryFilters : SalesTerritoryHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryFilters class.
		/// </summary>
		public SalesTerritoryHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTerritoryHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTerritoryHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTerritoryHistoryFilters
	
	#region SalesTerritoryHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesTerritoryHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesTerritoryHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTerritoryHistoryQuery : SalesTerritoryHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryQuery class.
		/// </summary>
		public SalesTerritoryHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTerritoryHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTerritoryHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTerritoryHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTerritoryHistoryQuery
		
	#region PurchaseOrderDetailFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderDetailFilters : PurchaseOrderDetailFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailFilters class.
		/// </summary>
		public PurchaseOrderDetailFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PurchaseOrderDetailFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PurchaseOrderDetailFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PurchaseOrderDetailFilters
	
	#region PurchaseOrderDetailQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PurchaseOrderDetailParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderDetailQuery : PurchaseOrderDetailParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailQuery class.
		/// </summary>
		public PurchaseOrderDetailQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PurchaseOrderDetailQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PurchaseOrderDetailQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PurchaseOrderDetailQuery
		
	#region SalesOrderDetailFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderDetailFilters : SalesOrderDetailFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailFilters class.
		/// </summary>
		public SalesOrderDetailFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderDetailFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderDetailFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderDetailFilters
	
	#region SalesOrderDetailQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesOrderDetailParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesOrderDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderDetailQuery : SalesOrderDetailParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailQuery class.
		/// </summary>
		public SalesOrderDetailQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderDetailQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderDetailQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderDetailQuery
		
	#region ProductProductPhotoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductProductPhotoFilters : ProductProductPhotoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoFilters class.
		/// </summary>
		public ProductProductPhotoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductProductPhotoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductProductPhotoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductProductPhotoFilters
	
	#region ProductProductPhotoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductProductPhotoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductProductPhotoQuery : ProductProductPhotoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoQuery class.
		/// </summary>
		public ProductProductPhotoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductProductPhotoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductProductPhotoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductProductPhotoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductProductPhotoQuery
		
	#region ProductReviewFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductReview"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductReviewFilters : ProductReviewFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductReviewFilters class.
		/// </summary>
		public ProductReviewFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductReviewFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductReviewFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductReviewFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductReviewFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductReviewFilters
	
	#region ProductReviewQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductReviewParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductReview"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductReviewQuery : ProductReviewParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductReviewQuery class.
		/// </summary>
		public ProductReviewQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductReviewQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductReviewQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductReviewQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductReviewQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductReviewQuery
		
	#region PurchaseOrderHeaderFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderHeaderFilters : PurchaseOrderHeaderFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderFilters class.
		/// </summary>
		public PurchaseOrderHeaderFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PurchaseOrderHeaderFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PurchaseOrderHeaderFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PurchaseOrderHeaderFilters
	
	#region PurchaseOrderHeaderQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PurchaseOrderHeaderParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderHeaderQuery : PurchaseOrderHeaderParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderQuery class.
		/// </summary>
		public PurchaseOrderHeaderQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PurchaseOrderHeaderQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PurchaseOrderHeaderQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PurchaseOrderHeaderQuery
		
	#region ProductVendorFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductVendorFilters : ProductVendorFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductVendorFilters class.
		/// </summary>
		public ProductVendorFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductVendorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductVendorFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductVendorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductVendorFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductVendorFilters
	
	#region ProductVendorQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductVendorParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductVendorQuery : ProductVendorParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductVendorQuery class.
		/// </summary>
		public ProductVendorQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductVendorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductVendorQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductVendorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductVendorQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductVendorQuery
		
	#region ScrapReasonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScrapReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScrapReasonFilters : ScrapReasonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScrapReasonFilters class.
		/// </summary>
		public ScrapReasonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScrapReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScrapReasonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScrapReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScrapReasonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScrapReasonFilters
	
	#region ScrapReasonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ScrapReasonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ScrapReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScrapReasonQuery : ScrapReasonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScrapReasonQuery class.
		/// </summary>
		public ScrapReasonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScrapReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScrapReasonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScrapReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScrapReasonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScrapReasonQuery
		
	#region UnitMeasureFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UnitMeasure"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitMeasureFilters : UnitMeasureFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitMeasureFilters class.
		/// </summary>
		public UnitMeasureFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitMeasureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitMeasureFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitMeasureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitMeasureFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitMeasureFilters
	
	#region UnitMeasureQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UnitMeasureParameterBuilder"/> class
	/// that is used exclusively with a <see cref="UnitMeasure"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitMeasureQuery : UnitMeasureParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitMeasureQuery class.
		/// </summary>
		public UnitMeasureQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitMeasureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitMeasureQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitMeasureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitMeasureQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitMeasureQuery
		
	#region ShiftFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Shift"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShiftFilters : ShiftFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShiftFilters class.
		/// </summary>
		public ShiftFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShiftFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShiftFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShiftFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShiftFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShiftFilters
	
	#region ShiftQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ShiftParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Shift"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShiftQuery : ShiftParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShiftQuery class.
		/// </summary>
		public ShiftQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShiftQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShiftQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShiftQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShiftQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShiftQuery
		
	#region TransactionHistoryArchiveFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistoryArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryArchiveFilters : TransactionHistoryArchiveFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveFilters class.
		/// </summary>
		public TransactionHistoryArchiveFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TransactionHistoryArchiveFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TransactionHistoryArchiveFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TransactionHistoryArchiveFilters
	
	#region TransactionHistoryArchiveQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TransactionHistoryArchiveParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TransactionHistoryArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryArchiveQuery : TransactionHistoryArchiveParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveQuery class.
		/// </summary>
		public TransactionHistoryArchiveQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TransactionHistoryArchiveQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TransactionHistoryArchiveQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TransactionHistoryArchiveQuery
		
	#region VendorFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorFilters : VendorFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorFilters class.
		/// </summary>
		public VendorFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorFilters
	
	#region VendorQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VendorParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorQuery : VendorParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorQuery class.
		/// </summary>
		public VendorQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorQuery
		
	#region AddressFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressFilters : AddressFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressFilters class.
		/// </summary>
		public AddressFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressFilters
	
	#region AddressQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AddressParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressQuery : AddressParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressQuery class.
		/// </summary>
		public AddressQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressQuery
		
	#region WorkOrderFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderFilters : WorkOrderFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderFilters class.
		/// </summary>
		public WorkOrderFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkOrderFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkOrderFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkOrderFilters
	
	#region WorkOrderQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WorkOrderParameterBuilder"/> class
	/// that is used exclusively with a <see cref="WorkOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderQuery : WorkOrderParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderQuery class.
		/// </summary>
		public WorkOrderQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkOrderQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkOrderQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkOrderQuery
		
	#region VendorAddressFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorAddressFilters : VendorAddressFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorAddressFilters class.
		/// </summary>
		public VendorAddressFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorAddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorAddressFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorAddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorAddressFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorAddressFilters
	
	#region VendorAddressQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VendorAddressParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VendorAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorAddressQuery : VendorAddressParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorAddressQuery class.
		/// </summary>
		public VendorAddressQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorAddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorAddressQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorAddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorAddressQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorAddressQuery
		
	#region TransactionHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryFilters : TransactionHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryFilters class.
		/// </summary>
		public TransactionHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TransactionHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TransactionHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TransactionHistoryFilters
	
	#region TransactionHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TransactionHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TransactionHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryQuery : TransactionHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryQuery class.
		/// </summary>
		public TransactionHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TransactionHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TransactionHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TransactionHistoryQuery
		
	#region VendorContactFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorContactFilters : VendorContactFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorContactFilters class.
		/// </summary>
		public VendorContactFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorContactFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorContactFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorContactFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorContactFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorContactFilters
	
	#region VendorContactQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VendorContactParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VendorContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorContactQuery : VendorContactParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorContactQuery class.
		/// </summary>
		public VendorContactQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorContactQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorContactQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorContactQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorContactQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorContactQuery
		
	#region TimestampPkFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TimestampPk"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TimestampPkFilters : TimestampPkFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TimestampPkFilters class.
		/// </summary>
		public TimestampPkFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TimestampPkFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TimestampPkFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TimestampPkFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TimestampPkFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TimestampPkFilters
	
	#region TimestampPkQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TimestampPkParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TimestampPk"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TimestampPkQuery : TimestampPkParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TimestampPkQuery class.
		/// </summary>
		public TimestampPkQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TimestampPkQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TimestampPkQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TimestampPkQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TimestampPkQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TimestampPkQuery
		
	#region ShoppingCartItemFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShoppingCartItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShoppingCartItemFilters : ShoppingCartItemFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemFilters class.
		/// </summary>
		public ShoppingCartItemFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShoppingCartItemFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShoppingCartItemFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShoppingCartItemFilters
	
	#region ShoppingCartItemQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ShoppingCartItemParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ShoppingCartItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShoppingCartItemQuery : ShoppingCartItemParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemQuery class.
		/// </summary>
		public ShoppingCartItemQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShoppingCartItemQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShoppingCartItemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShoppingCartItemQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShoppingCartItemQuery
		
	#region TestVariantFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestVariant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestVariantFilters : TestVariantFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestVariantFilters class.
		/// </summary>
		public TestVariantFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestVariantFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestVariantFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestVariantFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestVariantFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestVariantFilters
	
	#region TestVariantQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TestVariantParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TestVariant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestVariantQuery : TestVariantParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestVariantQuery class.
		/// </summary>
		public TestVariantQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestVariantQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestVariantQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestVariantQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestVariantQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestVariantQuery
		
	#region SpecialOfferFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferFilters : SpecialOfferFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferFilters class.
		/// </summary>
		public SpecialOfferFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecialOfferFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecialOfferFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecialOfferFilters
	
	#region SpecialOfferQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SpecialOfferParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SpecialOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferQuery : SpecialOfferParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferQuery class.
		/// </summary>
		public SpecialOfferQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecialOfferQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecialOfferQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecialOfferQuery
		
	#region ShipMethodFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShipMethod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShipMethodFilters : ShipMethodFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShipMethodFilters class.
		/// </summary>
		public ShipMethodFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShipMethodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShipMethodFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShipMethodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShipMethodFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShipMethodFilters
	
	#region ShipMethodQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ShipMethodParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ShipMethod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShipMethodQuery : ShipMethodParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShipMethodQuery class.
		/// </summary>
		public ShipMethodQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShipMethodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShipMethodQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShipMethodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShipMethodQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShipMethodQuery
		
	#region SpecialOfferProductFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOfferProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferProductFilters : SpecialOfferProductFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductFilters class.
		/// </summary>
		public SpecialOfferProductFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecialOfferProductFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecialOfferProductFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecialOfferProductFilters
	
	#region SpecialOfferProductQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SpecialOfferProductParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SpecialOfferProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferProductQuery : SpecialOfferProductParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductQuery class.
		/// </summary>
		public SpecialOfferProductQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecialOfferProductQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecialOfferProductQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecialOfferProductQuery
		
	#region StateProvinceFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StateProvince"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateProvinceFilters : StateProvinceFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateProvinceFilters class.
		/// </summary>
		public StateProvinceFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the StateProvinceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StateProvinceFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StateProvinceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StateProvinceFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StateProvinceFilters
	
	#region StateProvinceQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="StateProvinceParameterBuilder"/> class
	/// that is used exclusively with a <see cref="StateProvince"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateProvinceQuery : StateProvinceParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateProvinceQuery class.
		/// </summary>
		public StateProvinceQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the StateProvinceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StateProvinceQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StateProvinceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StateProvinceQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StateProvinceQuery
		
	#region StoreFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreFilters : StoreFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreFilters class.
		/// </summary>
		public StoreFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the StoreFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StoreFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StoreFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StoreFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StoreFilters
	
	#region StoreQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="StoreParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreQuery : StoreParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreQuery class.
		/// </summary>
		public StoreQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the StoreQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StoreQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StoreQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StoreQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StoreQuery
		
	#region ProductPhotoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductPhotoFilters : ProductPhotoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductPhotoFilters class.
		/// </summary>
		public ProductPhotoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductPhotoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductPhotoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductPhotoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductPhotoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductPhotoFilters
	
	#region ProductPhotoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductPhotoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductPhoto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductPhotoQuery : ProductPhotoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductPhotoQuery class.
		/// </summary>
		public ProductPhotoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductPhotoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductPhotoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductPhotoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductPhotoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductPhotoQuery
		
	#region StoreContactFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StoreContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreContactFilters : StoreContactFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreContactFilters class.
		/// </summary>
		public StoreContactFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the StoreContactFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StoreContactFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StoreContactFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StoreContactFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StoreContactFilters
	
	#region StoreContactQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="StoreContactParameterBuilder"/> class
	/// that is used exclusively with a <see cref="StoreContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreContactQuery : StoreContactParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreContactQuery class.
		/// </summary>
		public StoreContactQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the StoreContactQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StoreContactQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StoreContactQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StoreContactQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StoreContactQuery
		
	#region ProductModelProductDescriptionCultureFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelProductDescriptionCulture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelProductDescriptionCultureFilters : ProductModelProductDescriptionCultureFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureFilters class.
		/// </summary>
		public ProductModelProductDescriptionCultureFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelProductDescriptionCultureFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelProductDescriptionCultureFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelProductDescriptionCultureFilters
	
	#region ProductModelProductDescriptionCultureQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductModelProductDescriptionCultureParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductModelProductDescriptionCulture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelProductDescriptionCultureQuery : ProductModelProductDescriptionCultureParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureQuery class.
		/// </summary>
		public ProductModelProductDescriptionCultureQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelProductDescriptionCultureQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelProductDescriptionCultureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelProductDescriptionCultureQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelProductDescriptionCultureQuery
		
	#region CurrencyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyFilters : CurrencyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyFilters class.
		/// </summary>
		public CurrencyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyFilters
	
	#region CurrencyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CurrencyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyQuery : CurrencyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyQuery class.
		/// </summary>
		public CurrencyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyQuery
		
	#region CustomerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerFilters : CustomerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerFilters class.
		/// </summary>
		public CustomerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerFilters
	
	#region CustomerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerQuery : CustomerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerQuery class.
		/// </summary>
		public CustomerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerQuery
		
	#region CurrencyRateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrencyRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyRateFilters : CurrencyRateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyRateFilters class.
		/// </summary>
		public CurrencyRateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyRateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyRateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyRateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyRateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyRateFilters
	
	#region CurrencyRateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CurrencyRateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CurrencyRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyRateQuery : CurrencyRateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyRateQuery class.
		/// </summary>
		public CurrencyRateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyRateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyRateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyRateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyRateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyRateQuery
		
	#region DepartmentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentFilters : DepartmentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentFilters class.
		/// </summary>
		public DepartmentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentFilters
	
	#region DepartmentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DepartmentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentQuery : DepartmentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentQuery class.
		/// </summary>
		public DepartmentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentQuery
		
	#region CustomerAddressFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAddressFilters : CustomerAddressFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAddressFilters class.
		/// </summary>
		public CustomerAddressFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerAddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerAddressFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerAddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerAddressFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerAddressFilters
	
	#region CustomerAddressQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerAddressParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAddressQuery : CustomerAddressParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAddressQuery class.
		/// </summary>
		public CustomerAddressQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerAddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerAddressQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerAddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerAddressQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerAddressQuery
		
	#region CultureFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Culture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CultureFilters : CultureFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CultureFilters class.
		/// </summary>
		public CultureFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CultureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CultureFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CultureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CultureFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CultureFilters
	
	#region CultureQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CultureParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Culture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CultureQuery : CultureParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CultureQuery class.
		/// </summary>
		public CultureQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CultureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CultureQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CultureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CultureQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CultureQuery
		
	#region DatabaseLogFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DatabaseLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DatabaseLogFilters : DatabaseLogFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DatabaseLogFilters class.
		/// </summary>
		public DatabaseLogFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DatabaseLogFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DatabaseLogFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DatabaseLogFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DatabaseLogFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DatabaseLogFilters
	
	#region DatabaseLogQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DatabaseLogParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DatabaseLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DatabaseLogQuery : DatabaseLogParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DatabaseLogQuery class.
		/// </summary>
		public DatabaseLogQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DatabaseLogQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DatabaseLogQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DatabaseLogQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DatabaseLogQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DatabaseLogQuery
		
	#region CreditCardFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CreditCardFilters : CreditCardFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CreditCardFilters class.
		/// </summary>
		public CreditCardFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CreditCardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CreditCardFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CreditCardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CreditCardFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CreditCardFilters
	
	#region CreditCardQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CreditCardParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CreditCardQuery : CreditCardParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CreditCardQuery class.
		/// </summary>
		public CreditCardQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CreditCardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CreditCardQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CreditCardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CreditCardQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CreditCardQuery
		
	#region BillOfMaterialsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillOfMaterials"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillOfMaterialsFilters : BillOfMaterialsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsFilters class.
		/// </summary>
		public BillOfMaterialsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BillOfMaterialsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BillOfMaterialsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BillOfMaterialsFilters
	
	#region BillOfMaterialsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BillOfMaterialsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BillOfMaterials"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillOfMaterialsQuery : BillOfMaterialsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsQuery class.
		/// </summary>
		public BillOfMaterialsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BillOfMaterialsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BillOfMaterialsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BillOfMaterialsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BillOfMaterialsQuery
		
	#region CountryRegionCurrencyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegionCurrency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionCurrencyFilters : CountryRegionCurrencyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyFilters class.
		/// </summary>
		public CountryRegionCurrencyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryRegionCurrencyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryRegionCurrencyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryRegionCurrencyFilters
	
	#region CountryRegionCurrencyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CountryRegionCurrencyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CountryRegionCurrency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionCurrencyQuery : CountryRegionCurrencyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyQuery class.
		/// </summary>
		public CountryRegionCurrencyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryRegionCurrencyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionCurrencyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryRegionCurrencyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryRegionCurrencyQuery
		
	#region ContactFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactFilters : ContactFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactFilters class.
		/// </summary>
		public ContactFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactFilters
	
	#region ContactQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ContactParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Contact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactQuery : ContactParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactQuery class.
		/// </summary>
		public ContactQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactQuery
		
	#region AwBuildVersionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AwBuildVersion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AwBuildVersionFilters : AwBuildVersionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionFilters class.
		/// </summary>
		public AwBuildVersionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AwBuildVersionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AwBuildVersionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AwBuildVersionFilters
	
	#region AwBuildVersionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AwBuildVersionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AwBuildVersion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AwBuildVersionQuery : AwBuildVersionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionQuery class.
		/// </summary>
		public AwBuildVersionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AwBuildVersionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AwBuildVersionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AwBuildVersionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AwBuildVersionQuery
		
	#region CountryRegionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionFilters : CountryRegionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionFilters class.
		/// </summary>
		public CountryRegionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryRegionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryRegionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryRegionFilters
	
	#region CountryRegionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CountryRegionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryRegionQuery : CountryRegionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryRegionQuery class.
		/// </summary>
		public CountryRegionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryRegionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryRegionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryRegionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryRegionQuery
		
	#region ContactCreditCardFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactCreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactCreditCardFilters : ContactCreditCardFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardFilters class.
		/// </summary>
		public ContactCreditCardFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactCreditCardFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactCreditCardFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactCreditCardFilters
	
	#region ContactCreditCardQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ContactCreditCardParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ContactCreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactCreditCardQuery : ContactCreditCardParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardQuery class.
		/// </summary>
		public ContactCreditCardQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactCreditCardQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactCreditCardQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactCreditCardQuery
		
	#region DocumentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Document"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DocumentFilters : DocumentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DocumentFilters class.
		/// </summary>
		public DocumentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DocumentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DocumentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DocumentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DocumentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DocumentFilters
	
	#region DocumentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DocumentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Document"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DocumentQuery : DocumentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DocumentQuery class.
		/// </summary>
		public DocumentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DocumentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DocumentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DocumentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DocumentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DocumentQuery
		
	#region ContactTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactTypeFilters : ContactTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactTypeFilters class.
		/// </summary>
		public ContactTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactTypeFilters
	
	#region ContactTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ContactTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ContactType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactTypeQuery : ContactTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactTypeQuery class.
		/// </summary>
		public ContactTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactTypeQuery
		
	#region EmployeeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeFilters : EmployeeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeFilters class.
		/// </summary>
		public EmployeeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeFilters
	
	#region EmployeeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeQuery : EmployeeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeQuery class.
		/// </summary>
		public EmployeeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeQuery
		
	#region ProductDocumentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDocumentFilters : ProductDocumentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDocumentFilters class.
		/// </summary>
		public ProductDocumentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductDocumentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductDocumentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductDocumentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductDocumentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductDocumentFilters
	
	#region ProductDocumentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductDocumentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDocumentQuery : ProductDocumentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDocumentQuery class.
		/// </summary>
		public ProductDocumentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductDocumentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductDocumentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductDocumentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductDocumentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductDocumentQuery
		
	#region EmployeeAddressFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeAddressFilters : EmployeeAddressFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressFilters class.
		/// </summary>
		public EmployeeAddressFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeAddressFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeAddressFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeAddressFilters
	
	#region EmployeeAddressQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeeAddressParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmployeeAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeAddressQuery : EmployeeAddressParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressQuery class.
		/// </summary>
		public EmployeeAddressQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeAddressQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeAddressQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeAddressQuery
		
	#region ProductInventoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductInventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductInventoryFilters : ProductInventoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductInventoryFilters class.
		/// </summary>
		public ProductInventoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductInventoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductInventoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductInventoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductInventoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductInventoryFilters
	
	#region ProductInventoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductInventoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductInventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductInventoryQuery : ProductInventoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductInventoryQuery class.
		/// </summary>
		public ProductInventoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductInventoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductInventoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductInventoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductInventoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductInventoryQuery
		
	#region ProductDescriptionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDescriptionFilters : ProductDescriptionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionFilters class.
		/// </summary>
		public ProductDescriptionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductDescriptionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductDescriptionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductDescriptionFilters
	
	#region ProductDescriptionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductDescriptionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductDescriptionQuery : ProductDescriptionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionQuery class.
		/// </summary>
		public ProductDescriptionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductDescriptionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductDescriptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductDescriptionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductDescriptionQuery
		
	#region ProductModelIllustrationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelIllustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelIllustrationFilters : ProductModelIllustrationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationFilters class.
		/// </summary>
		public ProductModelIllustrationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelIllustrationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelIllustrationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelIllustrationFilters
	
	#region ProductModelIllustrationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductModelIllustrationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductModelIllustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelIllustrationQuery : ProductModelIllustrationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationQuery class.
		/// </summary>
		public ProductModelIllustrationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelIllustrationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelIllustrationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelIllustrationQuery
		
	#region ProductListPriceHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductListPriceHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductListPriceHistoryFilters : ProductListPriceHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryFilters class.
		/// </summary>
		public ProductListPriceHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductListPriceHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductListPriceHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductListPriceHistoryFilters
	
	#region ProductListPriceHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductListPriceHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductListPriceHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductListPriceHistoryQuery : ProductListPriceHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryQuery class.
		/// </summary>
		public ProductListPriceHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductListPriceHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductListPriceHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductListPriceHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductListPriceHistoryQuery
		
	#region ProductCostHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCostHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCostHistoryFilters : ProductCostHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryFilters class.
		/// </summary>
		public ProductCostHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCostHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCostHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCostHistoryFilters
	
	#region ProductCostHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductCostHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductCostHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCostHistoryQuery : ProductCostHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryQuery class.
		/// </summary>
		public ProductCostHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCostHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCostHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCostHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCostHistoryQuery
		
	#region WorkOrderRoutingFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkOrderRouting"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderRoutingFilters : WorkOrderRoutingFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingFilters class.
		/// </summary>
		public WorkOrderRoutingFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkOrderRoutingFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkOrderRoutingFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkOrderRoutingFilters
	
	#region WorkOrderRoutingQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WorkOrderRoutingParameterBuilder"/> class
	/// that is used exclusively with a <see cref="WorkOrderRouting"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkOrderRoutingQuery : WorkOrderRoutingParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingQuery class.
		/// </summary>
		public WorkOrderRoutingQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkOrderRoutingQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkOrderRoutingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkOrderRoutingQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkOrderRoutingQuery
		
	#region NullFkeyParentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyParent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyParentFilters : NullFkeyParentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentFilters class.
		/// </summary>
		public NullFkeyParentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NullFkeyParentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NullFkeyParentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NullFkeyParentFilters
	
	#region NullFkeyParentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="NullFkeyParentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="NullFkeyParent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyParentQuery : NullFkeyParentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentQuery class.
		/// </summary>
		public NullFkeyParentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NullFkeyParentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyParentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NullFkeyParentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NullFkeyParentQuery
		
	#region EmployeePayHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeePayHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeePayHistoryFilters : EmployeePayHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryFilters class.
		/// </summary>
		public EmployeePayHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeePayHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeePayHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeePayHistoryFilters
	
	#region EmployeePayHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeePayHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmployeePayHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeePayHistoryQuery : EmployeePayHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryQuery class.
		/// </summary>
		public EmployeePayHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeePayHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeePayHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeePayHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeePayHistoryQuery
		
	#region NullFkeyChildFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NullFkeyChild"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyChildFilters : NullFkeyChildFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildFilters class.
		/// </summary>
		public NullFkeyChildFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NullFkeyChildFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NullFkeyChildFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NullFkeyChildFilters
	
	#region NullFkeyChildQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="NullFkeyChildParameterBuilder"/> class
	/// that is used exclusively with a <see cref="NullFkeyChild"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NullFkeyChildQuery : NullFkeyChildParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildQuery class.
		/// </summary>
		public NullFkeyChildQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NullFkeyChildQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NullFkeyChildQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NullFkeyChildQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NullFkeyChildQuery
		
	#region ErrorLogFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorLogFilters : ErrorLogFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorLogFilters class.
		/// </summary>
		public ErrorLogFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ErrorLogFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ErrorLogFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ErrorLogFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ErrorLogFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ErrorLogFilters
	
	#region ErrorLogQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ErrorLogParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ErrorLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorLogQuery : ErrorLogParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorLogQuery class.
		/// </summary>
		public ErrorLogQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ErrorLogQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ErrorLogQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ErrorLogQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ErrorLogQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ErrorLogQuery
		
	#region EmployeeDepartmentHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentHistoryFilters : EmployeeDepartmentHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryFilters class.
		/// </summary>
		public EmployeeDepartmentHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeDepartmentHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeDepartmentHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeDepartmentHistoryFilters
	
	#region EmployeeDepartmentHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeeDepartmentHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentHistoryQuery : EmployeeDepartmentHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryQuery class.
		/// </summary>
		public EmployeeDepartmentHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeDepartmentHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeDepartmentHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeDepartmentHistoryQuery
		
	#region JobCandidateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCandidateFilters : JobCandidateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCandidateFilters class.
		/// </summary>
		public JobCandidateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCandidateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCandidateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCandidateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCandidateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCandidateFilters
	
	#region JobCandidateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobCandidateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCandidateQuery : JobCandidateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCandidateQuery class.
		/// </summary>
		public JobCandidateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCandidateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCandidateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCandidateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCandidateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCandidateQuery
		
	#region IllustrationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Illustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IllustrationFilters : IllustrationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IllustrationFilters class.
		/// </summary>
		public IllustrationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the IllustrationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IllustrationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IllustrationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IllustrationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IllustrationFilters
	
	#region IllustrationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="IllustrationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Illustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IllustrationQuery : IllustrationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IllustrationQuery class.
		/// </summary>
		public IllustrationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the IllustrationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IllustrationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IllustrationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IllustrationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IllustrationQuery
		
	#region AddressTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddressType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressTypeFilters : AddressTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressTypeFilters class.
		/// </summary>
		public AddressTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressTypeFilters
	
	#region AddressTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AddressTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AddressType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressTypeQuery : AddressTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressTypeQuery class.
		/// </summary>
		public AddressTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressTypeQuery
		
	#region IndividualFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Individual"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndividualFilters : IndividualFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndividualFilters class.
		/// </summary>
		public IndividualFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the IndividualFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IndividualFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IndividualFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IndividualFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IndividualFilters
	
	#region IndividualQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="IndividualParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Individual"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndividualQuery : IndividualParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndividualQuery class.
		/// </summary>
		public IndividualQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the IndividualQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IndividualQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IndividualQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IndividualQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IndividualQuery
		
	#region VAdditionalContactInfoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VAdditionalContactInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VAdditionalContactInfoFilters : VAdditionalContactInfoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoFilters class.
		/// </summary>
		public VAdditionalContactInfoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VAdditionalContactInfoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VAdditionalContactInfoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VAdditionalContactInfoFilters
	
	#region VAdditionalContactInfoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VAdditionalContactInfoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VAdditionalContactInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VAdditionalContactInfoQuery : VAdditionalContactInfoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoQuery class.
		/// </summary>
		public VAdditionalContactInfoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VAdditionalContactInfoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VAdditionalContactInfoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VAdditionalContactInfoQuery
		
	#region VEmployeeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeFilters : VEmployeeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeFilters class.
		/// </summary>
		public VEmployeeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeFilters
	
	#region VEmployeeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VEmployeeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VEmployee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeQuery : VEmployeeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeQuery class.
		/// </summary>
		public VEmployeeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeQuery
		
	#region VEmployeeDepartmentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentFilters : VEmployeeDepartmentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentFilters class.
		/// </summary>
		public VEmployeeDepartmentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeDepartmentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeDepartmentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeDepartmentFilters
	
	#region VEmployeeDepartmentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VEmployeeDepartmentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentQuery : VEmployeeDepartmentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentQuery class.
		/// </summary>
		public VEmployeeDepartmentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeDepartmentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeDepartmentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeDepartmentQuery
		
	#region VEmployeeDepartmentHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentHistoryFilters : VEmployeeDepartmentHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryFilters class.
		/// </summary>
		public VEmployeeDepartmentHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeDepartmentHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeDepartmentHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeDepartmentHistoryFilters
	
	#region VEmployeeDepartmentHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VEmployeeDepartmentHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentHistoryQuery : VEmployeeDepartmentHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryQuery class.
		/// </summary>
		public VEmployeeDepartmentHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeDepartmentHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeDepartmentHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeDepartmentHistoryQuery
		
	#region VIndividualCustomerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualCustomerFilters : VIndividualCustomerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerFilters class.
		/// </summary>
		public VIndividualCustomerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VIndividualCustomerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VIndividualCustomerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VIndividualCustomerFilters
	
	#region VIndividualCustomerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VIndividualCustomerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VIndividualCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualCustomerQuery : VIndividualCustomerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerQuery class.
		/// </summary>
		public VIndividualCustomerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VIndividualCustomerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VIndividualCustomerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VIndividualCustomerQuery
		
	#region VIndividualDemographicsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualDemographicsFilters : VIndividualDemographicsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsFilters class.
		/// </summary>
		public VIndividualDemographicsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VIndividualDemographicsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VIndividualDemographicsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VIndividualDemographicsFilters
	
	#region VIndividualDemographicsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VIndividualDemographicsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VIndividualDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualDemographicsQuery : VIndividualDemographicsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsQuery class.
		/// </summary>
		public VIndividualDemographicsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VIndividualDemographicsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VIndividualDemographicsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VIndividualDemographicsQuery
		
	#region VJobCandidateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateFilters : VJobCandidateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateFilters class.
		/// </summary>
		public VJobCandidateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateFilters
	
	#region VJobCandidateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VJobCandidateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VJobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateQuery : VJobCandidateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateQuery class.
		/// </summary>
		public VJobCandidateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateQuery
		
	#region VJobCandidateEducationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEducationFilters : VJobCandidateEducationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationFilters class.
		/// </summary>
		public VJobCandidateEducationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateEducationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateEducationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateEducationFilters
	
	#region VJobCandidateEducationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VJobCandidateEducationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEducationQuery : VJobCandidateEducationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationQuery class.
		/// </summary>
		public VJobCandidateEducationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateEducationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateEducationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateEducationQuery
		
	#region VJobCandidateEmploymentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEmployment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEmploymentFilters : VJobCandidateEmploymentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentFilters class.
		/// </summary>
		public VJobCandidateEmploymentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateEmploymentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateEmploymentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateEmploymentFilters
	
	#region VJobCandidateEmploymentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VJobCandidateEmploymentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEmployment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEmploymentQuery : VJobCandidateEmploymentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentQuery class.
		/// </summary>
		public VJobCandidateEmploymentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateEmploymentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateEmploymentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateEmploymentQuery
		
	#region VProductAndDescriptionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductAndDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductAndDescriptionFilters : VProductAndDescriptionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionFilters class.
		/// </summary>
		public VProductAndDescriptionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductAndDescriptionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductAndDescriptionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductAndDescriptionFilters
	
	#region VProductAndDescriptionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VProductAndDescriptionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VProductAndDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductAndDescriptionQuery : VProductAndDescriptionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionQuery class.
		/// </summary>
		public VProductAndDescriptionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductAndDescriptionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductAndDescriptionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductAndDescriptionQuery
		
	#region VProductModelCatalogDescriptionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelCatalogDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelCatalogDescriptionFilters : VProductModelCatalogDescriptionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionFilters class.
		/// </summary>
		public VProductModelCatalogDescriptionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductModelCatalogDescriptionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductModelCatalogDescriptionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductModelCatalogDescriptionFilters
	
	#region VProductModelCatalogDescriptionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VProductModelCatalogDescriptionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VProductModelCatalogDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelCatalogDescriptionQuery : VProductModelCatalogDescriptionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionQuery class.
		/// </summary>
		public VProductModelCatalogDescriptionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductModelCatalogDescriptionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductModelCatalogDescriptionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductModelCatalogDescriptionQuery
		
	#region VProductModelInstructionsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelInstructions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelInstructionsFilters : VProductModelInstructionsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsFilters class.
		/// </summary>
		public VProductModelInstructionsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductModelInstructionsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductModelInstructionsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductModelInstructionsFilters
	
	#region VProductModelInstructionsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VProductModelInstructionsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VProductModelInstructions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelInstructionsQuery : VProductModelInstructionsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsQuery class.
		/// </summary>
		public VProductModelInstructionsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductModelInstructionsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductModelInstructionsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductModelInstructionsQuery
		
	#region VSalesPersonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonFilters : VSalesPersonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonFilters class.
		/// </summary>
		public VSalesPersonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VSalesPersonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VSalesPersonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VSalesPersonFilters
	
	#region VSalesPersonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VSalesPersonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VSalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonQuery : VSalesPersonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonQuery class.
		/// </summary>
		public VSalesPersonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VSalesPersonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VSalesPersonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VSalesPersonQuery
		
	#region VSalesPersonSalesByFiscalYearsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPersonSalesByFiscalYears"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonSalesByFiscalYearsFilters : VSalesPersonSalesByFiscalYearsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsFilters class.
		/// </summary>
		public VSalesPersonSalesByFiscalYearsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VSalesPersonSalesByFiscalYearsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VSalesPersonSalesByFiscalYearsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VSalesPersonSalesByFiscalYearsFilters
	
	#region VSalesPersonSalesByFiscalYearsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VSalesPersonSalesByFiscalYearsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VSalesPersonSalesByFiscalYears"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonSalesByFiscalYearsQuery : VSalesPersonSalesByFiscalYearsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsQuery class.
		/// </summary>
		public VSalesPersonSalesByFiscalYearsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VSalesPersonSalesByFiscalYearsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VSalesPersonSalesByFiscalYearsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VSalesPersonSalesByFiscalYearsQuery
		
	#region VStateProvinceCountryRegionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStateProvinceCountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStateProvinceCountryRegionFilters : VStateProvinceCountryRegionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionFilters class.
		/// </summary>
		public VStateProvinceCountryRegionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VStateProvinceCountryRegionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VStateProvinceCountryRegionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VStateProvinceCountryRegionFilters
	
	#region VStateProvinceCountryRegionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VStateProvinceCountryRegionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VStateProvinceCountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStateProvinceCountryRegionQuery : VStateProvinceCountryRegionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionQuery class.
		/// </summary>
		public VStateProvinceCountryRegionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VStateProvinceCountryRegionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VStateProvinceCountryRegionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VStateProvinceCountryRegionQuery
		
	#region VStoreWithDemographicsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStoreWithDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStoreWithDemographicsFilters : VStoreWithDemographicsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsFilters class.
		/// </summary>
		public VStoreWithDemographicsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VStoreWithDemographicsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VStoreWithDemographicsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VStoreWithDemographicsFilters
	
	#region VStoreWithDemographicsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VStoreWithDemographicsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VStoreWithDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStoreWithDemographicsQuery : VStoreWithDemographicsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsQuery class.
		/// </summary>
		public VStoreWithDemographicsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VStoreWithDemographicsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VStoreWithDemographicsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VStoreWithDemographicsQuery
		
	#region VVendorFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VVendorFilters : VVendorFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VVendorFilters class.
		/// </summary>
		public VVendorFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VVendorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VVendorFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VVendorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VVendorFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VVendorFilters
	
	#region VVendorQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VVendorParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VVendorQuery : VVendorParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VVendorQuery class.
		/// </summary>
		public VVendorQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VVendorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VVendorQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VVendorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VVendorQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VVendorQuery
	#endregion

	
}
