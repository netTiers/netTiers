#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using PetShop.Business;
using PetShop.Data;
using PetShop.Data.Bases;

#endregion

namespace PetShop.Data
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
					_section = WebConfigurationManager.GetSection("PetShop.Data") as NetTiersServiceSection;
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
		
		#region OrderStatusProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrderStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrderStatusProviderBase OrderStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderStatusProvider;
			}
		}
		
		#endregion
		
		#region CartProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Cart"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CartProviderBase CartProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CartProvider;
			}
		}
		
		#endregion
		
		#region OrderProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Order"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrderProviderBase OrderProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderProvider;
			}
		}
		
		#endregion
		
		#region InventoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Inventory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static InventoryProviderBase InventoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.InventoryProvider;
			}
		}
		
		#endregion
		
		#region SupplierProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Supplier"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SupplierProviderBase SupplierProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SupplierProvider;
			}
		}
		
		#endregion
		
		#region CategoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Category"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CategoryProviderBase CategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CategoryProvider;
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
		
		#region LineItemProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LineItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LineItemProviderBase LineItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LineItemProvider;
			}
		}
		
		#endregion
		
		#region AccountProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Account"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AccountProviderBase AccountProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AccountProvider;
			}
		}
		
		#endregion
		
		#region ProfileProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Profile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProfileProviderBase ProfileProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProfileProvider;
			}
		}
		
		#endregion
		
		#region ItemProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Item"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ItemProviderBase ItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region OrderStatusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusFilters : OrderStatusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilters class.
		/// </summary>
		public OrderStatusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStatusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStatusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStatusFilters
	
	#region OrderStatusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrderStatusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusQuery : OrderStatusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusQuery class.
		/// </summary>
		public OrderStatusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStatusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStatusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStatusQuery
		
	#region CartFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CartFilters : CartFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CartFilters class.
		/// </summary>
		public CartFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CartFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CartFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CartFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CartFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CartFilters
	
	#region CartQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CartParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Cart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CartQuery : CartParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CartQuery class.
		/// </summary>
		public CartQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CartQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CartQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CartQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CartQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CartQuery
		
	#region OrderFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Order"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderFilters : OrderFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderFilters class.
		/// </summary>
		public OrderFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderFilters
	
	#region OrderQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrderParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Order"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderQuery : OrderParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderQuery class.
		/// </summary>
		public OrderQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderQuery
		
	#region InventoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Inventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InventoryFilters : InventoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InventoryFilters class.
		/// </summary>
		public InventoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the InventoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InventoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InventoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InventoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InventoryFilters
	
	#region InventoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="InventoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Inventory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InventoryQuery : InventoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InventoryQuery class.
		/// </summary>
		public InventoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the InventoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InventoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InventoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InventoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InventoryQuery
		
	#region SupplierFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Supplier"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SupplierFilters : SupplierFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SupplierFilters class.
		/// </summary>
		public SupplierFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SupplierFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SupplierFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SupplierFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SupplierFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SupplierFilters
	
	#region SupplierQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SupplierParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Supplier"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SupplierQuery : SupplierParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SupplierQuery class.
		/// </summary>
		public SupplierQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SupplierQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SupplierQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SupplierQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SupplierQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SupplierQuery
		
	#region CategoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Category"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoryFilters : CategoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoryFilters class.
		/// </summary>
		public CategoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoryFilters
	
	#region CategoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CategoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Category"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoryQuery : CategoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoryQuery class.
		/// </summary>
		public CategoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoryQuery
		
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
		
	#region LineItemFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LineItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LineItemFilters : LineItemFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LineItemFilters class.
		/// </summary>
		public LineItemFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LineItemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LineItemFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LineItemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LineItemFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LineItemFilters
	
	#region LineItemQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LineItemParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LineItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LineItemQuery : LineItemParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LineItemQuery class.
		/// </summary>
		public LineItemQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LineItemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LineItemQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LineItemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LineItemQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LineItemQuery
		
	#region AccountFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Account"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountFilters : AccountFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountFilters class.
		/// </summary>
		public AccountFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountFilters
	
	#region AccountQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AccountParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Account"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountQuery : AccountParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountQuery class.
		/// </summary>
		public AccountQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountQuery
		
	#region ProfileFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfileFilters : ProfileFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfileFilters class.
		/// </summary>
		public ProfileFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfileFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfileFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfileFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfileFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfileFilters
	
	#region ProfileQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProfileParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Profile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfileQuery : ProfileParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfileQuery class.
		/// </summary>
		public ProfileQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfileQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfileQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfileQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfileQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfileQuery
		
	#region ItemFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Item"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemFilters : ItemFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemFilters class.
		/// </summary>
		public ItemFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemFilters
	
	#region ItemQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ItemParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Item"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemQuery : ItemParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemQuery class.
		/// </summary>
		public ItemQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemQuery
	#endregion

	
}
