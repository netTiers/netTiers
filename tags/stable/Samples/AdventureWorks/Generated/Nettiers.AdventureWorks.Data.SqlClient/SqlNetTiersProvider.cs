
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : Nettiers.AdventureWorks.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "SalesTerritoryProvider"
			
		private SqlSalesTerritoryProvider innerSqlSalesTerritoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesTerritory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesTerritoryProviderBase SalesTerritoryProvider
		{
			get
			{
				if (innerSqlSalesTerritoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesTerritoryProvider == null)
						{
							this.innerSqlSalesTerritoryProvider = new SqlSalesTerritoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesTerritoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesTerritoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesTerritoryProvider SqlSalesTerritoryProvider
		{
			get {return SalesTerritoryProvider as SqlSalesTerritoryProvider;}
		}
		
		#endregion
		
		
		#region "LocationProvider"
			
		private SqlLocationProvider innerSqlLocationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Location"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LocationProviderBase LocationProvider
		{
			get
			{
				if (innerSqlLocationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLocationProvider == null)
						{
							this.innerSqlLocationProvider = new SqlLocationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLocationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlLocationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLocationProvider SqlLocationProvider
		{
			get {return LocationProvider as SqlLocationProvider;}
		}
		
		#endregion
		
		
		#region "SalesReasonProvider"
			
		private SqlSalesReasonProvider innerSqlSalesReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesReasonProviderBase SalesReasonProvider
		{
			get
			{
				if (innerSqlSalesReasonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesReasonProvider == null)
						{
							this.innerSqlSalesReasonProvider = new SqlSalesReasonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesReasonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesReasonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesReasonProvider SqlSalesReasonProvider
		{
			get {return SalesReasonProvider as SqlSalesReasonProvider;}
		}
		
		#endregion
		
		
		#region "SalesPersonQuotaHistoryProvider"
			
		private SqlSalesPersonQuotaHistoryProvider innerSqlSalesPersonQuotaHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesPersonQuotaHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesPersonQuotaHistoryProviderBase SalesPersonQuotaHistoryProvider
		{
			get
			{
				if (innerSqlSalesPersonQuotaHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesPersonQuotaHistoryProvider == null)
						{
							this.innerSqlSalesPersonQuotaHistoryProvider = new SqlSalesPersonQuotaHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesPersonQuotaHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesPersonQuotaHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesPersonQuotaHistoryProvider SqlSalesPersonQuotaHistoryProvider
		{
			get {return SalesPersonQuotaHistoryProvider as SqlSalesPersonQuotaHistoryProvider;}
		}
		
		#endregion
		
		
		#region "SalesOrderHeaderProvider"
			
		private SqlSalesOrderHeaderProvider innerSqlSalesOrderHeaderProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesOrderHeader"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesOrderHeaderProviderBase SalesOrderHeaderProvider
		{
			get
			{
				if (innerSqlSalesOrderHeaderProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesOrderHeaderProvider == null)
						{
							this.innerSqlSalesOrderHeaderProvider = new SqlSalesOrderHeaderProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesOrderHeaderProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesOrderHeaderProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesOrderHeaderProvider SqlSalesOrderHeaderProvider
		{
			get {return SalesOrderHeaderProvider as SqlSalesOrderHeaderProvider;}
		}
		
		#endregion
		
		
		#region "SalesOrderHeaderSalesReasonProvider"
			
		private SqlSalesOrderHeaderSalesReasonProvider innerSqlSalesOrderHeaderSalesReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesOrderHeaderSalesReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesOrderHeaderSalesReasonProviderBase SalesOrderHeaderSalesReasonProvider
		{
			get
			{
				if (innerSqlSalesOrderHeaderSalesReasonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesOrderHeaderSalesReasonProvider == null)
						{
							this.innerSqlSalesOrderHeaderSalesReasonProvider = new SqlSalesOrderHeaderSalesReasonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesOrderHeaderSalesReasonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesOrderHeaderSalesReasonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesOrderHeaderSalesReasonProvider SqlSalesOrderHeaderSalesReasonProvider
		{
			get {return SalesOrderHeaderSalesReasonProvider as SqlSalesOrderHeaderSalesReasonProvider;}
		}
		
		#endregion
		
		
		#region "ProductModelProvider"
			
		private SqlProductModelProvider innerSqlProductModelProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductModel"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductModelProviderBase ProductModelProvider
		{
			get
			{
				if (innerSqlProductModelProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductModelProvider == null)
						{
							this.innerSqlProductModelProvider = new SqlProductModelProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductModelProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductModelProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductModelProvider SqlProductModelProvider
		{
			get {return ProductModelProvider as SqlProductModelProvider;}
		}
		
		#endregion
		
		
		#region "SalesTaxRateProvider"
			
		private SqlSalesTaxRateProvider innerSqlSalesTaxRateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesTaxRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesTaxRateProviderBase SalesTaxRateProvider
		{
			get
			{
				if (innerSqlSalesTaxRateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesTaxRateProvider == null)
						{
							this.innerSqlSalesTaxRateProvider = new SqlSalesTaxRateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesTaxRateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesTaxRateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesTaxRateProvider SqlSalesTaxRateProvider
		{
			get {return SalesTaxRateProvider as SqlSalesTaxRateProvider;}
		}
		
		#endregion
		
		
		#region "SalesPersonProvider"
			
		private SqlSalesPersonProvider innerSqlSalesPersonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesPerson"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesPersonProviderBase SalesPersonProvider
		{
			get
			{
				if (innerSqlSalesPersonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesPersonProvider == null)
						{
							this.innerSqlSalesPersonProvider = new SqlSalesPersonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesPersonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesPersonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesPersonProvider SqlSalesPersonProvider
		{
			get {return SalesPersonProvider as SqlSalesPersonProvider;}
		}
		
		#endregion
		
		
		#region "ProductCategoryProvider"
			
		private SqlProductCategoryProvider innerSqlProductCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductCategoryProviderBase ProductCategoryProvider
		{
			get
			{
				if (innerSqlProductCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductCategoryProvider == null)
						{
							this.innerSqlProductCategoryProvider = new SqlProductCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductCategoryProvider SqlProductCategoryProvider
		{
			get {return ProductCategoryProvider as SqlProductCategoryProvider;}
		}
		
		#endregion
		
		
		#region "ProductSubcategoryProvider"
			
		private SqlProductSubcategoryProvider innerSqlProductSubcategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductSubcategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductSubcategoryProviderBase ProductSubcategoryProvider
		{
			get
			{
				if (innerSqlProductSubcategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductSubcategoryProvider == null)
						{
							this.innerSqlProductSubcategoryProvider = new SqlProductSubcategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductSubcategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductSubcategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductSubcategoryProvider SqlProductSubcategoryProvider
		{
			get {return ProductSubcategoryProvider as SqlProductSubcategoryProvider;}
		}
		
		#endregion
		
		
		#region "ProductProvider"
			
		private SqlProductProvider innerSqlProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductProviderBase ProductProvider
		{
			get
			{
				if (innerSqlProductProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductProvider == null)
						{
							this.innerSqlProductProvider = new SqlProductProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductProvider SqlProductProvider
		{
			get {return ProductProvider as SqlProductProvider;}
		}
		
		#endregion
		
		
		#region "SalesTerritoryHistoryProvider"
			
		private SqlSalesTerritoryHistoryProvider innerSqlSalesTerritoryHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesTerritoryHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesTerritoryHistoryProviderBase SalesTerritoryHistoryProvider
		{
			get
			{
				if (innerSqlSalesTerritoryHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesTerritoryHistoryProvider == null)
						{
							this.innerSqlSalesTerritoryHistoryProvider = new SqlSalesTerritoryHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesTerritoryHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesTerritoryHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesTerritoryHistoryProvider SqlSalesTerritoryHistoryProvider
		{
			get {return SalesTerritoryHistoryProvider as SqlSalesTerritoryHistoryProvider;}
		}
		
		#endregion
		
		
		#region "PurchaseOrderDetailProvider"
			
		private SqlPurchaseOrderDetailProvider innerSqlPurchaseOrderDetailProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PurchaseOrderDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PurchaseOrderDetailProviderBase PurchaseOrderDetailProvider
		{
			get
			{
				if (innerSqlPurchaseOrderDetailProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPurchaseOrderDetailProvider == null)
						{
							this.innerSqlPurchaseOrderDetailProvider = new SqlPurchaseOrderDetailProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPurchaseOrderDetailProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlPurchaseOrderDetailProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPurchaseOrderDetailProvider SqlPurchaseOrderDetailProvider
		{
			get {return PurchaseOrderDetailProvider as SqlPurchaseOrderDetailProvider;}
		}
		
		#endregion
		
		
		#region "SalesOrderDetailProvider"
			
		private SqlSalesOrderDetailProvider innerSqlSalesOrderDetailProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesOrderDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesOrderDetailProviderBase SalesOrderDetailProvider
		{
			get
			{
				if (innerSqlSalesOrderDetailProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesOrderDetailProvider == null)
						{
							this.innerSqlSalesOrderDetailProvider = new SqlSalesOrderDetailProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesOrderDetailProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesOrderDetailProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesOrderDetailProvider SqlSalesOrderDetailProvider
		{
			get {return SalesOrderDetailProvider as SqlSalesOrderDetailProvider;}
		}
		
		#endregion
		
		
		#region "ProductProductPhotoProvider"
			
		private SqlProductProductPhotoProvider innerSqlProductProductPhotoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductProductPhoto"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductProductPhotoProviderBase ProductProductPhotoProvider
		{
			get
			{
				if (innerSqlProductProductPhotoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductProductPhotoProvider == null)
						{
							this.innerSqlProductProductPhotoProvider = new SqlProductProductPhotoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductProductPhotoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductProductPhotoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductProductPhotoProvider SqlProductProductPhotoProvider
		{
			get {return ProductProductPhotoProvider as SqlProductProductPhotoProvider;}
		}
		
		#endregion
		
		
		#region "ProductReviewProvider"
			
		private SqlProductReviewProvider innerSqlProductReviewProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductReview"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductReviewProviderBase ProductReviewProvider
		{
			get
			{
				if (innerSqlProductReviewProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductReviewProvider == null)
						{
							this.innerSqlProductReviewProvider = new SqlProductReviewProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductReviewProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductReviewProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductReviewProvider SqlProductReviewProvider
		{
			get {return ProductReviewProvider as SqlProductReviewProvider;}
		}
		
		#endregion
		
		
		#region "PurchaseOrderHeaderProvider"
			
		private SqlPurchaseOrderHeaderProvider innerSqlPurchaseOrderHeaderProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PurchaseOrderHeader"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PurchaseOrderHeaderProviderBase PurchaseOrderHeaderProvider
		{
			get
			{
				if (innerSqlPurchaseOrderHeaderProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPurchaseOrderHeaderProvider == null)
						{
							this.innerSqlPurchaseOrderHeaderProvider = new SqlPurchaseOrderHeaderProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPurchaseOrderHeaderProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlPurchaseOrderHeaderProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPurchaseOrderHeaderProvider SqlPurchaseOrderHeaderProvider
		{
			get {return PurchaseOrderHeaderProvider as SqlPurchaseOrderHeaderProvider;}
		}
		
		#endregion
		
		
		#region "ProductVendorProvider"
			
		private SqlProductVendorProvider innerSqlProductVendorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductVendor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductVendorProviderBase ProductVendorProvider
		{
			get
			{
				if (innerSqlProductVendorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductVendorProvider == null)
						{
							this.innerSqlProductVendorProvider = new SqlProductVendorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductVendorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductVendorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductVendorProvider SqlProductVendorProvider
		{
			get {return ProductVendorProvider as SqlProductVendorProvider;}
		}
		
		#endregion
		
		
		#region "ScrapReasonProvider"
			
		private SqlScrapReasonProvider innerSqlScrapReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ScrapReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ScrapReasonProviderBase ScrapReasonProvider
		{
			get
			{
				if (innerSqlScrapReasonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlScrapReasonProvider == null)
						{
							this.innerSqlScrapReasonProvider = new SqlScrapReasonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlScrapReasonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlScrapReasonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlScrapReasonProvider SqlScrapReasonProvider
		{
			get {return ScrapReasonProvider as SqlScrapReasonProvider;}
		}
		
		#endregion
		
		
		#region "UnitMeasureProvider"
			
		private SqlUnitMeasureProvider innerSqlUnitMeasureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="UnitMeasure"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UnitMeasureProviderBase UnitMeasureProvider
		{
			get
			{
				if (innerSqlUnitMeasureProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUnitMeasureProvider == null)
						{
							this.innerSqlUnitMeasureProvider = new SqlUnitMeasureProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUnitMeasureProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlUnitMeasureProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUnitMeasureProvider SqlUnitMeasureProvider
		{
			get {return UnitMeasureProvider as SqlUnitMeasureProvider;}
		}
		
		#endregion
		
		
		#region "ShiftProvider"
			
		private SqlShiftProvider innerSqlShiftProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Shift"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShiftProviderBase ShiftProvider
		{
			get
			{
				if (innerSqlShiftProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlShiftProvider == null)
						{
							this.innerSqlShiftProvider = new SqlShiftProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlShiftProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlShiftProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlShiftProvider SqlShiftProvider
		{
			get {return ShiftProvider as SqlShiftProvider;}
		}
		
		#endregion
		
		
		#region "TransactionHistoryArchiveProvider"
			
		private SqlTransactionHistoryArchiveProvider innerSqlTransactionHistoryArchiveProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TransactionHistoryArchive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TransactionHistoryArchiveProviderBase TransactionHistoryArchiveProvider
		{
			get
			{
				if (innerSqlTransactionHistoryArchiveProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTransactionHistoryArchiveProvider == null)
						{
							this.innerSqlTransactionHistoryArchiveProvider = new SqlTransactionHistoryArchiveProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTransactionHistoryArchiveProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTransactionHistoryArchiveProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTransactionHistoryArchiveProvider SqlTransactionHistoryArchiveProvider
		{
			get {return TransactionHistoryArchiveProvider as SqlTransactionHistoryArchiveProvider;}
		}
		
		#endregion
		
		
		#region "VendorProvider"
			
		private SqlVendorProvider innerSqlVendorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vendor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VendorProviderBase VendorProvider
		{
			get
			{
				if (innerSqlVendorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVendorProvider == null)
						{
							this.innerSqlVendorProvider = new SqlVendorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVendorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVendorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVendorProvider SqlVendorProvider
		{
			get {return VendorProvider as SqlVendorProvider;}
		}
		
		#endregion
		
		
		#region "AddressProvider"
			
		private SqlAddressProvider innerSqlAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Address"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AddressProviderBase AddressProvider
		{
			get
			{
				if (innerSqlAddressProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAddressProvider == null)
						{
							this.innerSqlAddressProvider = new SqlAddressProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAddressProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAddressProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAddressProvider SqlAddressProvider
		{
			get {return AddressProvider as SqlAddressProvider;}
		}
		
		#endregion
		
		
		#region "WorkOrderProvider"
			
		private SqlWorkOrderProvider innerSqlWorkOrderProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="WorkOrder"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WorkOrderProviderBase WorkOrderProvider
		{
			get
			{
				if (innerSqlWorkOrderProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWorkOrderProvider == null)
						{
							this.innerSqlWorkOrderProvider = new SqlWorkOrderProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWorkOrderProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlWorkOrderProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWorkOrderProvider SqlWorkOrderProvider
		{
			get {return WorkOrderProvider as SqlWorkOrderProvider;}
		}
		
		#endregion
		
		
		#region "VendorAddressProvider"
			
		private SqlVendorAddressProvider innerSqlVendorAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VendorAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VendorAddressProviderBase VendorAddressProvider
		{
			get
			{
				if (innerSqlVendorAddressProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVendorAddressProvider == null)
						{
							this.innerSqlVendorAddressProvider = new SqlVendorAddressProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVendorAddressProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVendorAddressProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVendorAddressProvider SqlVendorAddressProvider
		{
			get {return VendorAddressProvider as SqlVendorAddressProvider;}
		}
		
		#endregion
		
		
		#region "TransactionHistoryProvider"
			
		private SqlTransactionHistoryProvider innerSqlTransactionHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TransactionHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TransactionHistoryProviderBase TransactionHistoryProvider
		{
			get
			{
				if (innerSqlTransactionHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTransactionHistoryProvider == null)
						{
							this.innerSqlTransactionHistoryProvider = new SqlTransactionHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTransactionHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTransactionHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTransactionHistoryProvider SqlTransactionHistoryProvider
		{
			get {return TransactionHistoryProvider as SqlTransactionHistoryProvider;}
		}
		
		#endregion
		
		
		#region "VendorContactProvider"
			
		private SqlVendorContactProvider innerSqlVendorContactProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VendorContact"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VendorContactProviderBase VendorContactProvider
		{
			get
			{
				if (innerSqlVendorContactProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVendorContactProvider == null)
						{
							this.innerSqlVendorContactProvider = new SqlVendorContactProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVendorContactProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVendorContactProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVendorContactProvider SqlVendorContactProvider
		{
			get {return VendorContactProvider as SqlVendorContactProvider;}
		}
		
		#endregion
		
		
		#region "TimestampPkProvider"
			
		private SqlTimestampPkProvider innerSqlTimestampPkProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TimestampPk"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TimestampPkProviderBase TimestampPkProvider
		{
			get
			{
				if (innerSqlTimestampPkProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTimestampPkProvider == null)
						{
							this.innerSqlTimestampPkProvider = new SqlTimestampPkProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTimestampPkProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTimestampPkProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTimestampPkProvider SqlTimestampPkProvider
		{
			get {return TimestampPkProvider as SqlTimestampPkProvider;}
		}
		
		#endregion
		
		
		#region "ShoppingCartItemProvider"
			
		private SqlShoppingCartItemProvider innerSqlShoppingCartItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ShoppingCartItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShoppingCartItemProviderBase ShoppingCartItemProvider
		{
			get
			{
				if (innerSqlShoppingCartItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlShoppingCartItemProvider == null)
						{
							this.innerSqlShoppingCartItemProvider = new SqlShoppingCartItemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlShoppingCartItemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlShoppingCartItemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlShoppingCartItemProvider SqlShoppingCartItemProvider
		{
			get {return ShoppingCartItemProvider as SqlShoppingCartItemProvider;}
		}
		
		#endregion
		
		
		#region "TestVariantProvider"
			
		private SqlTestVariantProvider innerSqlTestVariantProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TestVariant"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TestVariantProviderBase TestVariantProvider
		{
			get
			{
				if (innerSqlTestVariantProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTestVariantProvider == null)
						{
							this.innerSqlTestVariantProvider = new SqlTestVariantProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTestVariantProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTestVariantProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTestVariantProvider SqlTestVariantProvider
		{
			get {return TestVariantProvider as SqlTestVariantProvider;}
		}
		
		#endregion
		
		
		#region "SpecialOfferProvider"
			
		private SqlSpecialOfferProvider innerSqlSpecialOfferProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SpecialOffer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SpecialOfferProviderBase SpecialOfferProvider
		{
			get
			{
				if (innerSqlSpecialOfferProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSpecialOfferProvider == null)
						{
							this.innerSqlSpecialOfferProvider = new SqlSpecialOfferProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSpecialOfferProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSpecialOfferProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSpecialOfferProvider SqlSpecialOfferProvider
		{
			get {return SpecialOfferProvider as SqlSpecialOfferProvider;}
		}
		
		#endregion
		
		
		#region "ShipMethodProvider"
			
		private SqlShipMethodProvider innerSqlShipMethodProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ShipMethod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShipMethodProviderBase ShipMethodProvider
		{
			get
			{
				if (innerSqlShipMethodProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlShipMethodProvider == null)
						{
							this.innerSqlShipMethodProvider = new SqlShipMethodProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlShipMethodProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlShipMethodProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlShipMethodProvider SqlShipMethodProvider
		{
			get {return ShipMethodProvider as SqlShipMethodProvider;}
		}
		
		#endregion
		
		
		#region "SpecialOfferProductProvider"
			
		private SqlSpecialOfferProductProvider innerSqlSpecialOfferProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SpecialOfferProduct"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SpecialOfferProductProviderBase SpecialOfferProductProvider
		{
			get
			{
				if (innerSqlSpecialOfferProductProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSpecialOfferProductProvider == null)
						{
							this.innerSqlSpecialOfferProductProvider = new SqlSpecialOfferProductProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSpecialOfferProductProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSpecialOfferProductProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSpecialOfferProductProvider SqlSpecialOfferProductProvider
		{
			get {return SpecialOfferProductProvider as SqlSpecialOfferProductProvider;}
		}
		
		#endregion
		
		
		#region "StateProvinceProvider"
			
		private SqlStateProvinceProvider innerSqlStateProvinceProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="StateProvince"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StateProvinceProviderBase StateProvinceProvider
		{
			get
			{
				if (innerSqlStateProvinceProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStateProvinceProvider == null)
						{
							this.innerSqlStateProvinceProvider = new SqlStateProvinceProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStateProvinceProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlStateProvinceProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStateProvinceProvider SqlStateProvinceProvider
		{
			get {return StateProvinceProvider as SqlStateProvinceProvider;}
		}
		
		#endregion
		
		
		#region "StoreProvider"
			
		private SqlStoreProvider innerSqlStoreProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Store"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StoreProviderBase StoreProvider
		{
			get
			{
				if (innerSqlStoreProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStoreProvider == null)
						{
							this.innerSqlStoreProvider = new SqlStoreProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStoreProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlStoreProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStoreProvider SqlStoreProvider
		{
			get {return StoreProvider as SqlStoreProvider;}
		}
		
		#endregion
		
		
		#region "ProductPhotoProvider"
			
		private SqlProductPhotoProvider innerSqlProductPhotoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductPhoto"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductPhotoProviderBase ProductPhotoProvider
		{
			get
			{
				if (innerSqlProductPhotoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductPhotoProvider == null)
						{
							this.innerSqlProductPhotoProvider = new SqlProductPhotoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductPhotoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductPhotoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductPhotoProvider SqlProductPhotoProvider
		{
			get {return ProductPhotoProvider as SqlProductPhotoProvider;}
		}
		
		#endregion
		
		
		#region "StoreContactProvider"
			
		private SqlStoreContactProvider innerSqlStoreContactProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="StoreContact"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StoreContactProviderBase StoreContactProvider
		{
			get
			{
				if (innerSqlStoreContactProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStoreContactProvider == null)
						{
							this.innerSqlStoreContactProvider = new SqlStoreContactProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStoreContactProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlStoreContactProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStoreContactProvider SqlStoreContactProvider
		{
			get {return StoreContactProvider as SqlStoreContactProvider;}
		}
		
		#endregion
		
		
		#region "ProductModelProductDescriptionCultureProvider"
			
		private SqlProductModelProductDescriptionCultureProvider innerSqlProductModelProductDescriptionCultureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductModelProductDescriptionCulture"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductModelProductDescriptionCultureProviderBase ProductModelProductDescriptionCultureProvider
		{
			get
			{
				if (innerSqlProductModelProductDescriptionCultureProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductModelProductDescriptionCultureProvider == null)
						{
							this.innerSqlProductModelProductDescriptionCultureProvider = new SqlProductModelProductDescriptionCultureProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductModelProductDescriptionCultureProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductModelProductDescriptionCultureProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductModelProductDescriptionCultureProvider SqlProductModelProductDescriptionCultureProvider
		{
			get {return ProductModelProductDescriptionCultureProvider as SqlProductModelProductDescriptionCultureProvider;}
		}
		
		#endregion
		
		
		#region "CurrencyProvider"
			
		private SqlCurrencyProvider innerSqlCurrencyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Currency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CurrencyProviderBase CurrencyProvider
		{
			get
			{
				if (innerSqlCurrencyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCurrencyProvider == null)
						{
							this.innerSqlCurrencyProvider = new SqlCurrencyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCurrencyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCurrencyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCurrencyProvider SqlCurrencyProvider
		{
			get {return CurrencyProvider as SqlCurrencyProvider;}
		}
		
		#endregion
		
		
		#region "CustomerProvider"
			
		private SqlCustomerProvider innerSqlCustomerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Customer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerProviderBase CustomerProvider
		{
			get
			{
				if (innerSqlCustomerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerProvider == null)
						{
							this.innerSqlCustomerProvider = new SqlCustomerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCustomerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerProvider SqlCustomerProvider
		{
			get {return CustomerProvider as SqlCustomerProvider;}
		}
		
		#endregion
		
		
		#region "CurrencyRateProvider"
			
		private SqlCurrencyRateProvider innerSqlCurrencyRateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CurrencyRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CurrencyRateProviderBase CurrencyRateProvider
		{
			get
			{
				if (innerSqlCurrencyRateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCurrencyRateProvider == null)
						{
							this.innerSqlCurrencyRateProvider = new SqlCurrencyRateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCurrencyRateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCurrencyRateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCurrencyRateProvider SqlCurrencyRateProvider
		{
			get {return CurrencyRateProvider as SqlCurrencyRateProvider;}
		}
		
		#endregion
		
		
		#region "DepartmentProvider"
			
		private SqlDepartmentProvider innerSqlDepartmentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Department"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DepartmentProviderBase DepartmentProvider
		{
			get
			{
				if (innerSqlDepartmentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDepartmentProvider == null)
						{
							this.innerSqlDepartmentProvider = new SqlDepartmentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDepartmentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDepartmentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDepartmentProvider SqlDepartmentProvider
		{
			get {return DepartmentProvider as SqlDepartmentProvider;}
		}
		
		#endregion
		
		
		#region "CustomerAddressProvider"
			
		private SqlCustomerAddressProvider innerSqlCustomerAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerAddressProviderBase CustomerAddressProvider
		{
			get
			{
				if (innerSqlCustomerAddressProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerAddressProvider == null)
						{
							this.innerSqlCustomerAddressProvider = new SqlCustomerAddressProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerAddressProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCustomerAddressProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerAddressProvider SqlCustomerAddressProvider
		{
			get {return CustomerAddressProvider as SqlCustomerAddressProvider;}
		}
		
		#endregion
		
		
		#region "CultureProvider"
			
		private SqlCultureProvider innerSqlCultureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Culture"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CultureProviderBase CultureProvider
		{
			get
			{
				if (innerSqlCultureProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCultureProvider == null)
						{
							this.innerSqlCultureProvider = new SqlCultureProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCultureProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCultureProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCultureProvider SqlCultureProvider
		{
			get {return CultureProvider as SqlCultureProvider;}
		}
		
		#endregion
		
		
		#region "DatabaseLogProvider"
			
		private SqlDatabaseLogProvider innerSqlDatabaseLogProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DatabaseLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DatabaseLogProviderBase DatabaseLogProvider
		{
			get
			{
				if (innerSqlDatabaseLogProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDatabaseLogProvider == null)
						{
							this.innerSqlDatabaseLogProvider = new SqlDatabaseLogProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDatabaseLogProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDatabaseLogProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDatabaseLogProvider SqlDatabaseLogProvider
		{
			get {return DatabaseLogProvider as SqlDatabaseLogProvider;}
		}
		
		#endregion
		
		
		#region "CreditCardProvider"
			
		private SqlCreditCardProvider innerSqlCreditCardProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CreditCard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CreditCardProviderBase CreditCardProvider
		{
			get
			{
				if (innerSqlCreditCardProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCreditCardProvider == null)
						{
							this.innerSqlCreditCardProvider = new SqlCreditCardProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCreditCardProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCreditCardProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCreditCardProvider SqlCreditCardProvider
		{
			get {return CreditCardProvider as SqlCreditCardProvider;}
		}
		
		#endregion
		
		
		#region "BillOfMaterialsProvider"
			
		private SqlBillOfMaterialsProvider innerSqlBillOfMaterialsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BillOfMaterials"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BillOfMaterialsProviderBase BillOfMaterialsProvider
		{
			get
			{
				if (innerSqlBillOfMaterialsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBillOfMaterialsProvider == null)
						{
							this.innerSqlBillOfMaterialsProvider = new SqlBillOfMaterialsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBillOfMaterialsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlBillOfMaterialsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBillOfMaterialsProvider SqlBillOfMaterialsProvider
		{
			get {return BillOfMaterialsProvider as SqlBillOfMaterialsProvider;}
		}
		
		#endregion
		
		
		#region "CountryRegionCurrencyProvider"
			
		private SqlCountryRegionCurrencyProvider innerSqlCountryRegionCurrencyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CountryRegionCurrency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CountryRegionCurrencyProviderBase CountryRegionCurrencyProvider
		{
			get
			{
				if (innerSqlCountryRegionCurrencyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCountryRegionCurrencyProvider == null)
						{
							this.innerSqlCountryRegionCurrencyProvider = new SqlCountryRegionCurrencyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCountryRegionCurrencyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCountryRegionCurrencyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCountryRegionCurrencyProvider SqlCountryRegionCurrencyProvider
		{
			get {return CountryRegionCurrencyProvider as SqlCountryRegionCurrencyProvider;}
		}
		
		#endregion
		
		
		#region "ContactProvider"
			
		private SqlContactProvider innerSqlContactProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Contact"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContactProviderBase ContactProvider
		{
			get
			{
				if (innerSqlContactProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlContactProvider == null)
						{
							this.innerSqlContactProvider = new SqlContactProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlContactProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlContactProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlContactProvider SqlContactProvider
		{
			get {return ContactProvider as SqlContactProvider;}
		}
		
		#endregion
		
		
		#region "AwBuildVersionProvider"
			
		private SqlAwBuildVersionProvider innerSqlAwBuildVersionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AwBuildVersion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AwBuildVersionProviderBase AwBuildVersionProvider
		{
			get
			{
				if (innerSqlAwBuildVersionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAwBuildVersionProvider == null)
						{
							this.innerSqlAwBuildVersionProvider = new SqlAwBuildVersionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAwBuildVersionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAwBuildVersionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAwBuildVersionProvider SqlAwBuildVersionProvider
		{
			get {return AwBuildVersionProvider as SqlAwBuildVersionProvider;}
		}
		
		#endregion
		
		
		#region "CountryRegionProvider"
			
		private SqlCountryRegionProvider innerSqlCountryRegionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CountryRegion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CountryRegionProviderBase CountryRegionProvider
		{
			get
			{
				if (innerSqlCountryRegionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCountryRegionProvider == null)
						{
							this.innerSqlCountryRegionProvider = new SqlCountryRegionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCountryRegionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCountryRegionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCountryRegionProvider SqlCountryRegionProvider
		{
			get {return CountryRegionProvider as SqlCountryRegionProvider;}
		}
		
		#endregion
		
		
		#region "ContactCreditCardProvider"
			
		private SqlContactCreditCardProvider innerSqlContactCreditCardProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ContactCreditCard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContactCreditCardProviderBase ContactCreditCardProvider
		{
			get
			{
				if (innerSqlContactCreditCardProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlContactCreditCardProvider == null)
						{
							this.innerSqlContactCreditCardProvider = new SqlContactCreditCardProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlContactCreditCardProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlContactCreditCardProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlContactCreditCardProvider SqlContactCreditCardProvider
		{
			get {return ContactCreditCardProvider as SqlContactCreditCardProvider;}
		}
		
		#endregion
		
		
		#region "DocumentProvider"
			
		private SqlDocumentProvider innerSqlDocumentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Document"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DocumentProviderBase DocumentProvider
		{
			get
			{
				if (innerSqlDocumentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDocumentProvider == null)
						{
							this.innerSqlDocumentProvider = new SqlDocumentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDocumentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDocumentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDocumentProvider SqlDocumentProvider
		{
			get {return DocumentProvider as SqlDocumentProvider;}
		}
		
		#endregion
		
		
		#region "ContactTypeProvider"
			
		private SqlContactTypeProvider innerSqlContactTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ContactType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContactTypeProviderBase ContactTypeProvider
		{
			get
			{
				if (innerSqlContactTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlContactTypeProvider == null)
						{
							this.innerSqlContactTypeProvider = new SqlContactTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlContactTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlContactTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlContactTypeProvider SqlContactTypeProvider
		{
			get {return ContactTypeProvider as SqlContactTypeProvider;}
		}
		
		#endregion
		
		
		#region "EmployeeProvider"
			
		private SqlEmployeeProvider innerSqlEmployeeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Employee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeProviderBase EmployeeProvider
		{
			get
			{
				if (innerSqlEmployeeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeeProvider == null)
						{
							this.innerSqlEmployeeProvider = new SqlEmployeeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeeProvider SqlEmployeeProvider
		{
			get {return EmployeeProvider as SqlEmployeeProvider;}
		}
		
		#endregion
		
		
		#region "ProductDocumentProvider"
			
		private SqlProductDocumentProvider innerSqlProductDocumentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductDocument"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductDocumentProviderBase ProductDocumentProvider
		{
			get
			{
				if (innerSqlProductDocumentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductDocumentProvider == null)
						{
							this.innerSqlProductDocumentProvider = new SqlProductDocumentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductDocumentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductDocumentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductDocumentProvider SqlProductDocumentProvider
		{
			get {return ProductDocumentProvider as SqlProductDocumentProvider;}
		}
		
		#endregion
		
		
		#region "EmployeeAddressProvider"
			
		private SqlEmployeeAddressProvider innerSqlEmployeeAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeeAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeAddressProviderBase EmployeeAddressProvider
		{
			get
			{
				if (innerSqlEmployeeAddressProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeeAddressProvider == null)
						{
							this.innerSqlEmployeeAddressProvider = new SqlEmployeeAddressProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeeAddressProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeeAddressProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeeAddressProvider SqlEmployeeAddressProvider
		{
			get {return EmployeeAddressProvider as SqlEmployeeAddressProvider;}
		}
		
		#endregion
		
		
		#region "ProductInventoryProvider"
			
		private SqlProductInventoryProvider innerSqlProductInventoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductInventory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductInventoryProviderBase ProductInventoryProvider
		{
			get
			{
				if (innerSqlProductInventoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductInventoryProvider == null)
						{
							this.innerSqlProductInventoryProvider = new SqlProductInventoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductInventoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductInventoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductInventoryProvider SqlProductInventoryProvider
		{
			get {return ProductInventoryProvider as SqlProductInventoryProvider;}
		}
		
		#endregion
		
		
		#region "ProductDescriptionProvider"
			
		private SqlProductDescriptionProvider innerSqlProductDescriptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductDescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductDescriptionProviderBase ProductDescriptionProvider
		{
			get
			{
				if (innerSqlProductDescriptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductDescriptionProvider == null)
						{
							this.innerSqlProductDescriptionProvider = new SqlProductDescriptionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductDescriptionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductDescriptionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductDescriptionProvider SqlProductDescriptionProvider
		{
			get {return ProductDescriptionProvider as SqlProductDescriptionProvider;}
		}
		
		#endregion
		
		
		#region "ProductModelIllustrationProvider"
			
		private SqlProductModelIllustrationProvider innerSqlProductModelIllustrationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductModelIllustration"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductModelIllustrationProviderBase ProductModelIllustrationProvider
		{
			get
			{
				if (innerSqlProductModelIllustrationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductModelIllustrationProvider == null)
						{
							this.innerSqlProductModelIllustrationProvider = new SqlProductModelIllustrationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductModelIllustrationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductModelIllustrationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductModelIllustrationProvider SqlProductModelIllustrationProvider
		{
			get {return ProductModelIllustrationProvider as SqlProductModelIllustrationProvider;}
		}
		
		#endregion
		
		
		#region "ProductListPriceHistoryProvider"
			
		private SqlProductListPriceHistoryProvider innerSqlProductListPriceHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductListPriceHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductListPriceHistoryProviderBase ProductListPriceHistoryProvider
		{
			get
			{
				if (innerSqlProductListPriceHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductListPriceHistoryProvider == null)
						{
							this.innerSqlProductListPriceHistoryProvider = new SqlProductListPriceHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductListPriceHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductListPriceHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductListPriceHistoryProvider SqlProductListPriceHistoryProvider
		{
			get {return ProductListPriceHistoryProvider as SqlProductListPriceHistoryProvider;}
		}
		
		#endregion
		
		
		#region "ProductCostHistoryProvider"
			
		private SqlProductCostHistoryProvider innerSqlProductCostHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductCostHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductCostHistoryProviderBase ProductCostHistoryProvider
		{
			get
			{
				if (innerSqlProductCostHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductCostHistoryProvider == null)
						{
							this.innerSqlProductCostHistoryProvider = new SqlProductCostHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductCostHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductCostHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductCostHistoryProvider SqlProductCostHistoryProvider
		{
			get {return ProductCostHistoryProvider as SqlProductCostHistoryProvider;}
		}
		
		#endregion
		
		
		#region "WorkOrderRoutingProvider"
			
		private SqlWorkOrderRoutingProvider innerSqlWorkOrderRoutingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="WorkOrderRouting"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WorkOrderRoutingProviderBase WorkOrderRoutingProvider
		{
			get
			{
				if (innerSqlWorkOrderRoutingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWorkOrderRoutingProvider == null)
						{
							this.innerSqlWorkOrderRoutingProvider = new SqlWorkOrderRoutingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWorkOrderRoutingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlWorkOrderRoutingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWorkOrderRoutingProvider SqlWorkOrderRoutingProvider
		{
			get {return WorkOrderRoutingProvider as SqlWorkOrderRoutingProvider;}
		}
		
		#endregion
		
		
		#region "NullFkeyParentProvider"
			
		private SqlNullFkeyParentProvider innerSqlNullFkeyParentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="NullFkeyParent"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NullFkeyParentProviderBase NullFkeyParentProvider
		{
			get
			{
				if (innerSqlNullFkeyParentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNullFkeyParentProvider == null)
						{
							this.innerSqlNullFkeyParentProvider = new SqlNullFkeyParentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNullFkeyParentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlNullFkeyParentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNullFkeyParentProvider SqlNullFkeyParentProvider
		{
			get {return NullFkeyParentProvider as SqlNullFkeyParentProvider;}
		}
		
		#endregion
		
		
		#region "EmployeePayHistoryProvider"
			
		private SqlEmployeePayHistoryProvider innerSqlEmployeePayHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeePayHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeePayHistoryProviderBase EmployeePayHistoryProvider
		{
			get
			{
				if (innerSqlEmployeePayHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeePayHistoryProvider == null)
						{
							this.innerSqlEmployeePayHistoryProvider = new SqlEmployeePayHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeePayHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeePayHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeePayHistoryProvider SqlEmployeePayHistoryProvider
		{
			get {return EmployeePayHistoryProvider as SqlEmployeePayHistoryProvider;}
		}
		
		#endregion
		
		
		#region "NullFkeyChildProvider"
			
		private SqlNullFkeyChildProvider innerSqlNullFkeyChildProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="NullFkeyChild"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NullFkeyChildProviderBase NullFkeyChildProvider
		{
			get
			{
				if (innerSqlNullFkeyChildProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNullFkeyChildProvider == null)
						{
							this.innerSqlNullFkeyChildProvider = new SqlNullFkeyChildProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNullFkeyChildProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlNullFkeyChildProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNullFkeyChildProvider SqlNullFkeyChildProvider
		{
			get {return NullFkeyChildProvider as SqlNullFkeyChildProvider;}
		}
		
		#endregion
		
		
		#region "ErrorLogProvider"
			
		private SqlErrorLogProvider innerSqlErrorLogProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ErrorLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ErrorLogProviderBase ErrorLogProvider
		{
			get
			{
				if (innerSqlErrorLogProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlErrorLogProvider == null)
						{
							this.innerSqlErrorLogProvider = new SqlErrorLogProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlErrorLogProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlErrorLogProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlErrorLogProvider SqlErrorLogProvider
		{
			get {return ErrorLogProvider as SqlErrorLogProvider;}
		}
		
		#endregion
		
		
		#region "EmployeeDepartmentHistoryProvider"
			
		private SqlEmployeeDepartmentHistoryProvider innerSqlEmployeeDepartmentHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeeDepartmentHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeDepartmentHistoryProviderBase EmployeeDepartmentHistoryProvider
		{
			get
			{
				if (innerSqlEmployeeDepartmentHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeeDepartmentHistoryProvider == null)
						{
							this.innerSqlEmployeeDepartmentHistoryProvider = new SqlEmployeeDepartmentHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeeDepartmentHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeeDepartmentHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeeDepartmentHistoryProvider SqlEmployeeDepartmentHistoryProvider
		{
			get {return EmployeeDepartmentHistoryProvider as SqlEmployeeDepartmentHistoryProvider;}
		}
		
		#endregion
		
		
		#region "JobCandidateProvider"
			
		private SqlJobCandidateProvider innerSqlJobCandidateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobCandidate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobCandidateProviderBase JobCandidateProvider
		{
			get
			{
				if (innerSqlJobCandidateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobCandidateProvider == null)
						{
							this.innerSqlJobCandidateProvider = new SqlJobCandidateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobCandidateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlJobCandidateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobCandidateProvider SqlJobCandidateProvider
		{
			get {return JobCandidateProvider as SqlJobCandidateProvider;}
		}
		
		#endregion
		
		
		#region "IllustrationProvider"
			
		private SqlIllustrationProvider innerSqlIllustrationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Illustration"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IllustrationProviderBase IllustrationProvider
		{
			get
			{
				if (innerSqlIllustrationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlIllustrationProvider == null)
						{
							this.innerSqlIllustrationProvider = new SqlIllustrationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlIllustrationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlIllustrationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlIllustrationProvider SqlIllustrationProvider
		{
			get {return IllustrationProvider as SqlIllustrationProvider;}
		}
		
		#endregion
		
		
		#region "AddressTypeProvider"
			
		private SqlAddressTypeProvider innerSqlAddressTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AddressType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AddressTypeProviderBase AddressTypeProvider
		{
			get
			{
				if (innerSqlAddressTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAddressTypeProvider == null)
						{
							this.innerSqlAddressTypeProvider = new SqlAddressTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAddressTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAddressTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAddressTypeProvider SqlAddressTypeProvider
		{
			get {return AddressTypeProvider as SqlAddressTypeProvider;}
		}
		
		#endregion
		
		
		#region "IndividualProvider"
			
		private SqlIndividualProvider innerSqlIndividualProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Individual"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IndividualProviderBase IndividualProvider
		{
			get
			{
				if (innerSqlIndividualProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlIndividualProvider == null)
						{
							this.innerSqlIndividualProvider = new SqlIndividualProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlIndividualProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlIndividualProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlIndividualProvider SqlIndividualProvider
		{
			get {return IndividualProvider as SqlIndividualProvider;}
		}
		
		#endregion
		
		
		
		#region "VAdditionalContactInfoProvider"
		
		private SqlVAdditionalContactInfoProvider innerSqlVAdditionalContactInfoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VAdditionalContactInfo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VAdditionalContactInfoProviderBase VAdditionalContactInfoProvider
		{
			get
			{
				if (innerSqlVAdditionalContactInfoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVAdditionalContactInfoProvider == null)
						{
							this.innerSqlVAdditionalContactInfoProvider = new SqlVAdditionalContactInfoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVAdditionalContactInfoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVAdditionalContactInfoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVAdditionalContactInfoProvider SqlVAdditionalContactInfoProvider
		{
			get {return VAdditionalContactInfoProvider as SqlVAdditionalContactInfoProvider;}
		}
		
		#endregion
		
		
		#region "VEmployeeProvider"
		
		private SqlVEmployeeProvider innerSqlVEmployeeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VEmployee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VEmployeeProviderBase VEmployeeProvider
		{
			get
			{
				if (innerSqlVEmployeeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVEmployeeProvider == null)
						{
							this.innerSqlVEmployeeProvider = new SqlVEmployeeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVEmployeeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVEmployeeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVEmployeeProvider SqlVEmployeeProvider
		{
			get {return VEmployeeProvider as SqlVEmployeeProvider;}
		}
		
		#endregion
		
		
		#region "VEmployeeDepartmentProvider"
		
		private SqlVEmployeeDepartmentProvider innerSqlVEmployeeDepartmentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VEmployeeDepartment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VEmployeeDepartmentProviderBase VEmployeeDepartmentProvider
		{
			get
			{
				if (innerSqlVEmployeeDepartmentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVEmployeeDepartmentProvider == null)
						{
							this.innerSqlVEmployeeDepartmentProvider = new SqlVEmployeeDepartmentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVEmployeeDepartmentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVEmployeeDepartmentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVEmployeeDepartmentProvider SqlVEmployeeDepartmentProvider
		{
			get {return VEmployeeDepartmentProvider as SqlVEmployeeDepartmentProvider;}
		}
		
		#endregion
		
		
		#region "VEmployeeDepartmentHistoryProvider"
		
		private SqlVEmployeeDepartmentHistoryProvider innerSqlVEmployeeDepartmentHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VEmployeeDepartmentHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VEmployeeDepartmentHistoryProviderBase VEmployeeDepartmentHistoryProvider
		{
			get
			{
				if (innerSqlVEmployeeDepartmentHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVEmployeeDepartmentHistoryProvider == null)
						{
							this.innerSqlVEmployeeDepartmentHistoryProvider = new SqlVEmployeeDepartmentHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVEmployeeDepartmentHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVEmployeeDepartmentHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVEmployeeDepartmentHistoryProvider SqlVEmployeeDepartmentHistoryProvider
		{
			get {return VEmployeeDepartmentHistoryProvider as SqlVEmployeeDepartmentHistoryProvider;}
		}
		
		#endregion
		
		
		#region "VIndividualCustomerProvider"
		
		private SqlVIndividualCustomerProvider innerSqlVIndividualCustomerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VIndividualCustomer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VIndividualCustomerProviderBase VIndividualCustomerProvider
		{
			get
			{
				if (innerSqlVIndividualCustomerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVIndividualCustomerProvider == null)
						{
							this.innerSqlVIndividualCustomerProvider = new SqlVIndividualCustomerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVIndividualCustomerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVIndividualCustomerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVIndividualCustomerProvider SqlVIndividualCustomerProvider
		{
			get {return VIndividualCustomerProvider as SqlVIndividualCustomerProvider;}
		}
		
		#endregion
		
		
		#region "VIndividualDemographicsProvider"
		
		private SqlVIndividualDemographicsProvider innerSqlVIndividualDemographicsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VIndividualDemographics"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VIndividualDemographicsProviderBase VIndividualDemographicsProvider
		{
			get
			{
				if (innerSqlVIndividualDemographicsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVIndividualDemographicsProvider == null)
						{
							this.innerSqlVIndividualDemographicsProvider = new SqlVIndividualDemographicsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVIndividualDemographicsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVIndividualDemographicsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVIndividualDemographicsProvider SqlVIndividualDemographicsProvider
		{
			get {return VIndividualDemographicsProvider as SqlVIndividualDemographicsProvider;}
		}
		
		#endregion
		
		
		#region "VJobCandidateProvider"
		
		private SqlVJobCandidateProvider innerSqlVJobCandidateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VJobCandidate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VJobCandidateProviderBase VJobCandidateProvider
		{
			get
			{
				if (innerSqlVJobCandidateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVJobCandidateProvider == null)
						{
							this.innerSqlVJobCandidateProvider = new SqlVJobCandidateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVJobCandidateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVJobCandidateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVJobCandidateProvider SqlVJobCandidateProvider
		{
			get {return VJobCandidateProvider as SqlVJobCandidateProvider;}
		}
		
		#endregion
		
		
		#region "VJobCandidateEducationProvider"
		
		private SqlVJobCandidateEducationProvider innerSqlVJobCandidateEducationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VJobCandidateEducation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VJobCandidateEducationProviderBase VJobCandidateEducationProvider
		{
			get
			{
				if (innerSqlVJobCandidateEducationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVJobCandidateEducationProvider == null)
						{
							this.innerSqlVJobCandidateEducationProvider = new SqlVJobCandidateEducationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVJobCandidateEducationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVJobCandidateEducationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVJobCandidateEducationProvider SqlVJobCandidateEducationProvider
		{
			get {return VJobCandidateEducationProvider as SqlVJobCandidateEducationProvider;}
		}
		
		#endregion
		
		
		#region "VJobCandidateEmploymentProvider"
		
		private SqlVJobCandidateEmploymentProvider innerSqlVJobCandidateEmploymentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VJobCandidateEmployment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VJobCandidateEmploymentProviderBase VJobCandidateEmploymentProvider
		{
			get
			{
				if (innerSqlVJobCandidateEmploymentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVJobCandidateEmploymentProvider == null)
						{
							this.innerSqlVJobCandidateEmploymentProvider = new SqlVJobCandidateEmploymentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVJobCandidateEmploymentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVJobCandidateEmploymentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVJobCandidateEmploymentProvider SqlVJobCandidateEmploymentProvider
		{
			get {return VJobCandidateEmploymentProvider as SqlVJobCandidateEmploymentProvider;}
		}
		
		#endregion
		
		
		#region "VProductAndDescriptionProvider"
		
		private SqlVProductAndDescriptionProvider innerSqlVProductAndDescriptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VProductAndDescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VProductAndDescriptionProviderBase VProductAndDescriptionProvider
		{
			get
			{
				if (innerSqlVProductAndDescriptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVProductAndDescriptionProvider == null)
						{
							this.innerSqlVProductAndDescriptionProvider = new SqlVProductAndDescriptionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVProductAndDescriptionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVProductAndDescriptionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVProductAndDescriptionProvider SqlVProductAndDescriptionProvider
		{
			get {return VProductAndDescriptionProvider as SqlVProductAndDescriptionProvider;}
		}
		
		#endregion
		
		
		#region "VProductModelCatalogDescriptionProvider"
		
		private SqlVProductModelCatalogDescriptionProvider innerSqlVProductModelCatalogDescriptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VProductModelCatalogDescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VProductModelCatalogDescriptionProviderBase VProductModelCatalogDescriptionProvider
		{
			get
			{
				if (innerSqlVProductModelCatalogDescriptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVProductModelCatalogDescriptionProvider == null)
						{
							this.innerSqlVProductModelCatalogDescriptionProvider = new SqlVProductModelCatalogDescriptionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVProductModelCatalogDescriptionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVProductModelCatalogDescriptionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVProductModelCatalogDescriptionProvider SqlVProductModelCatalogDescriptionProvider
		{
			get {return VProductModelCatalogDescriptionProvider as SqlVProductModelCatalogDescriptionProvider;}
		}
		
		#endregion
		
		
		#region "VProductModelInstructionsProvider"
		
		private SqlVProductModelInstructionsProvider innerSqlVProductModelInstructionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VProductModelInstructions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VProductModelInstructionsProviderBase VProductModelInstructionsProvider
		{
			get
			{
				if (innerSqlVProductModelInstructionsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVProductModelInstructionsProvider == null)
						{
							this.innerSqlVProductModelInstructionsProvider = new SqlVProductModelInstructionsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVProductModelInstructionsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVProductModelInstructionsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVProductModelInstructionsProvider SqlVProductModelInstructionsProvider
		{
			get {return VProductModelInstructionsProvider as SqlVProductModelInstructionsProvider;}
		}
		
		#endregion
		
		
		#region "VSalesPersonProvider"
		
		private SqlVSalesPersonProvider innerSqlVSalesPersonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VSalesPerson"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VSalesPersonProviderBase VSalesPersonProvider
		{
			get
			{
				if (innerSqlVSalesPersonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVSalesPersonProvider == null)
						{
							this.innerSqlVSalesPersonProvider = new SqlVSalesPersonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVSalesPersonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVSalesPersonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVSalesPersonProvider SqlVSalesPersonProvider
		{
			get {return VSalesPersonProvider as SqlVSalesPersonProvider;}
		}
		
		#endregion
		
		
		#region "VSalesPersonSalesByFiscalYearsProvider"
		
		private SqlVSalesPersonSalesByFiscalYearsProvider innerSqlVSalesPersonSalesByFiscalYearsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VSalesPersonSalesByFiscalYears"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VSalesPersonSalesByFiscalYearsProviderBase VSalesPersonSalesByFiscalYearsProvider
		{
			get
			{
				if (innerSqlVSalesPersonSalesByFiscalYearsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVSalesPersonSalesByFiscalYearsProvider == null)
						{
							this.innerSqlVSalesPersonSalesByFiscalYearsProvider = new SqlVSalesPersonSalesByFiscalYearsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVSalesPersonSalesByFiscalYearsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVSalesPersonSalesByFiscalYearsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVSalesPersonSalesByFiscalYearsProvider SqlVSalesPersonSalesByFiscalYearsProvider
		{
			get {return VSalesPersonSalesByFiscalYearsProvider as SqlVSalesPersonSalesByFiscalYearsProvider;}
		}
		
		#endregion
		
		
		#region "VStateProvinceCountryRegionProvider"
		
		private SqlVStateProvinceCountryRegionProvider innerSqlVStateProvinceCountryRegionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VStateProvinceCountryRegion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VStateProvinceCountryRegionProviderBase VStateProvinceCountryRegionProvider
		{
			get
			{
				if (innerSqlVStateProvinceCountryRegionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVStateProvinceCountryRegionProvider == null)
						{
							this.innerSqlVStateProvinceCountryRegionProvider = new SqlVStateProvinceCountryRegionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVStateProvinceCountryRegionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVStateProvinceCountryRegionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVStateProvinceCountryRegionProvider SqlVStateProvinceCountryRegionProvider
		{
			get {return VStateProvinceCountryRegionProvider as SqlVStateProvinceCountryRegionProvider;}
		}
		
		#endregion
		
		
		#region "VStoreWithDemographicsProvider"
		
		private SqlVStoreWithDemographicsProvider innerSqlVStoreWithDemographicsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VStoreWithDemographics"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VStoreWithDemographicsProviderBase VStoreWithDemographicsProvider
		{
			get
			{
				if (innerSqlVStoreWithDemographicsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVStoreWithDemographicsProvider == null)
						{
							this.innerSqlVStoreWithDemographicsProvider = new SqlVStoreWithDemographicsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVStoreWithDemographicsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVStoreWithDemographicsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVStoreWithDemographicsProvider SqlVStoreWithDemographicsProvider
		{
			get {return VStoreWithDemographicsProvider as SqlVStoreWithDemographicsProvider;}
		}
		
		#endregion
		
		
		#region "VVendorProvider"
		
		private SqlVVendorProvider innerSqlVVendorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VVendor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VVendorProviderBase VVendorProvider
		{
			get
			{
				if (innerSqlVVendorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVVendorProvider == null)
						{
							this.innerSqlVVendorProvider = new SqlVVendorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVVendorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVVendorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVVendorProvider SqlVVendorProvider
		{
			get {return VVendorProvider as SqlVVendorProvider;}
		}
		
		#endregion
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
