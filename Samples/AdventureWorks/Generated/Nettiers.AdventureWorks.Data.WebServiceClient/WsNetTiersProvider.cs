

#region Using directives

using System;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.Data.WebServiceClient
{
	/// <summary>
	/// The WebService client data provider.
	/// </summary>
	public sealed class WsNetTiersProvider : Nettiers.AdventureWorks.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
		private string url;
        
		/// <summary>
		/// Initializes a new instance of the <see cref="WsNetTiersProvider"/> class.
		///</summary>
		public WsNetTiersProvider()
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


            #region Initialize Url
            string url  = config["url"];
           	if (string.IsNullOrEmpty(url))
            {
                throw new ProviderException("Empty or missing url");
            }
            this.url = url;
            config.Remove("url");
            #endregion

        }
        
		/// <summary>
		/// Current Url for WebService EndPoint
		/// </summary>
        public string Url
        {
        	get {return this.url;}
        	set {this.url = value;}
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			throw new NotSupportedException("Transactions are not supported by the webservice client.");
		}
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return false;
			}
		}

			
		private WsSalesTerritoryProvider innerSalesTerritoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesTerritory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesTerritoryProviderBase SalesTerritoryProvider
		{
			get
			{
				if (innerSalesTerritoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSalesTerritoryProvider == null)
						{
							this.innerSalesTerritoryProvider = new WsSalesTerritoryProvider(this.url);
						}
					}
				}
				return innerSalesTerritoryProvider;
			}
		}
		
			
		private WsLocationProvider innerLocationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Location"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LocationProviderBase LocationProvider
		{
			get
			{
				if (innerLocationProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerLocationProvider == null)
						{
							this.innerLocationProvider = new WsLocationProvider(this.url);
						}
					}
				}
				return innerLocationProvider;
			}
		}
		
			
		private WsSalesReasonProvider innerSalesReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesReasonProviderBase SalesReasonProvider
		{
			get
			{
				if (innerSalesReasonProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSalesReasonProvider == null)
						{
							this.innerSalesReasonProvider = new WsSalesReasonProvider(this.url);
						}
					}
				}
				return innerSalesReasonProvider;
			}
		}
		
			
		private WsSalesPersonQuotaHistoryProvider innerSalesPersonQuotaHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesPersonQuotaHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesPersonQuotaHistoryProviderBase SalesPersonQuotaHistoryProvider
		{
			get
			{
				if (innerSalesPersonQuotaHistoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSalesPersonQuotaHistoryProvider == null)
						{
							this.innerSalesPersonQuotaHistoryProvider = new WsSalesPersonQuotaHistoryProvider(this.url);
						}
					}
				}
				return innerSalesPersonQuotaHistoryProvider;
			}
		}
		
			
		private WsSalesOrderHeaderProvider innerSalesOrderHeaderProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesOrderHeader"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesOrderHeaderProviderBase SalesOrderHeaderProvider
		{
			get
			{
				if (innerSalesOrderHeaderProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSalesOrderHeaderProvider == null)
						{
							this.innerSalesOrderHeaderProvider = new WsSalesOrderHeaderProvider(this.url);
						}
					}
				}
				return innerSalesOrderHeaderProvider;
			}
		}
		
			
		private WsSalesOrderHeaderSalesReasonProvider innerSalesOrderHeaderSalesReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesOrderHeaderSalesReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesOrderHeaderSalesReasonProviderBase SalesOrderHeaderSalesReasonProvider
		{
			get
			{
				if (innerSalesOrderHeaderSalesReasonProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSalesOrderHeaderSalesReasonProvider == null)
						{
							this.innerSalesOrderHeaderSalesReasonProvider = new WsSalesOrderHeaderSalesReasonProvider(this.url);
						}
					}
				}
				return innerSalesOrderHeaderSalesReasonProvider;
			}
		}
		
			
		private WsProductModelProvider innerProductModelProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductModel"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductModelProviderBase ProductModelProvider
		{
			get
			{
				if (innerProductModelProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductModelProvider == null)
						{
							this.innerProductModelProvider = new WsProductModelProvider(this.url);
						}
					}
				}
				return innerProductModelProvider;
			}
		}
		
			
		private WsSalesTaxRateProvider innerSalesTaxRateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesTaxRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesTaxRateProviderBase SalesTaxRateProvider
		{
			get
			{
				if (innerSalesTaxRateProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSalesTaxRateProvider == null)
						{
							this.innerSalesTaxRateProvider = new WsSalesTaxRateProvider(this.url);
						}
					}
				}
				return innerSalesTaxRateProvider;
			}
		}
		
			
		private WsSalesPersonProvider innerSalesPersonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesPerson"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesPersonProviderBase SalesPersonProvider
		{
			get
			{
				if (innerSalesPersonProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSalesPersonProvider == null)
						{
							this.innerSalesPersonProvider = new WsSalesPersonProvider(this.url);
						}
					}
				}
				return innerSalesPersonProvider;
			}
		}
		
			
		private WsProductCategoryProvider innerProductCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductCategoryProviderBase ProductCategoryProvider
		{
			get
			{
				if (innerProductCategoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductCategoryProvider == null)
						{
							this.innerProductCategoryProvider = new WsProductCategoryProvider(this.url);
						}
					}
				}
				return innerProductCategoryProvider;
			}
		}
		
			
		private WsProductSubcategoryProvider innerProductSubcategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductSubcategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductSubcategoryProviderBase ProductSubcategoryProvider
		{
			get
			{
				if (innerProductSubcategoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductSubcategoryProvider == null)
						{
							this.innerProductSubcategoryProvider = new WsProductSubcategoryProvider(this.url);
						}
					}
				}
				return innerProductSubcategoryProvider;
			}
		}
		
			
		private WsProductProvider innerProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductProviderBase ProductProvider
		{
			get
			{
				if (innerProductProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductProvider == null)
						{
							this.innerProductProvider = new WsProductProvider(this.url);
						}
					}
				}
				return innerProductProvider;
			}
		}
		
			
		private WsSalesTerritoryHistoryProvider innerSalesTerritoryHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesTerritoryHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesTerritoryHistoryProviderBase SalesTerritoryHistoryProvider
		{
			get
			{
				if (innerSalesTerritoryHistoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSalesTerritoryHistoryProvider == null)
						{
							this.innerSalesTerritoryHistoryProvider = new WsSalesTerritoryHistoryProvider(this.url);
						}
					}
				}
				return innerSalesTerritoryHistoryProvider;
			}
		}
		
			
		private WsPurchaseOrderDetailProvider innerPurchaseOrderDetailProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PurchaseOrderDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PurchaseOrderDetailProviderBase PurchaseOrderDetailProvider
		{
			get
			{
				if (innerPurchaseOrderDetailProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerPurchaseOrderDetailProvider == null)
						{
							this.innerPurchaseOrderDetailProvider = new WsPurchaseOrderDetailProvider(this.url);
						}
					}
				}
				return innerPurchaseOrderDetailProvider;
			}
		}
		
			
		private WsSalesOrderDetailProvider innerSalesOrderDetailProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesOrderDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesOrderDetailProviderBase SalesOrderDetailProvider
		{
			get
			{
				if (innerSalesOrderDetailProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSalesOrderDetailProvider == null)
						{
							this.innerSalesOrderDetailProvider = new WsSalesOrderDetailProvider(this.url);
						}
					}
				}
				return innerSalesOrderDetailProvider;
			}
		}
		
			
		private WsProductProductPhotoProvider innerProductProductPhotoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductProductPhoto"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductProductPhotoProviderBase ProductProductPhotoProvider
		{
			get
			{
				if (innerProductProductPhotoProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductProductPhotoProvider == null)
						{
							this.innerProductProductPhotoProvider = new WsProductProductPhotoProvider(this.url);
						}
					}
				}
				return innerProductProductPhotoProvider;
			}
		}
		
			
		private WsProductReviewProvider innerProductReviewProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductReview"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductReviewProviderBase ProductReviewProvider
		{
			get
			{
				if (innerProductReviewProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductReviewProvider == null)
						{
							this.innerProductReviewProvider = new WsProductReviewProvider(this.url);
						}
					}
				}
				return innerProductReviewProvider;
			}
		}
		
			
		private WsPurchaseOrderHeaderProvider innerPurchaseOrderHeaderProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PurchaseOrderHeader"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PurchaseOrderHeaderProviderBase PurchaseOrderHeaderProvider
		{
			get
			{
				if (innerPurchaseOrderHeaderProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerPurchaseOrderHeaderProvider == null)
						{
							this.innerPurchaseOrderHeaderProvider = new WsPurchaseOrderHeaderProvider(this.url);
						}
					}
				}
				return innerPurchaseOrderHeaderProvider;
			}
		}
		
			
		private WsProductVendorProvider innerProductVendorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductVendor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductVendorProviderBase ProductVendorProvider
		{
			get
			{
				if (innerProductVendorProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductVendorProvider == null)
						{
							this.innerProductVendorProvider = new WsProductVendorProvider(this.url);
						}
					}
				}
				return innerProductVendorProvider;
			}
		}
		
			
		private WsScrapReasonProvider innerScrapReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ScrapReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ScrapReasonProviderBase ScrapReasonProvider
		{
			get
			{
				if (innerScrapReasonProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerScrapReasonProvider == null)
						{
							this.innerScrapReasonProvider = new WsScrapReasonProvider(this.url);
						}
					}
				}
				return innerScrapReasonProvider;
			}
		}
		
			
		private WsUnitMeasureProvider innerUnitMeasureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="UnitMeasure"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UnitMeasureProviderBase UnitMeasureProvider
		{
			get
			{
				if (innerUnitMeasureProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerUnitMeasureProvider == null)
						{
							this.innerUnitMeasureProvider = new WsUnitMeasureProvider(this.url);
						}
					}
				}
				return innerUnitMeasureProvider;
			}
		}
		
			
		private WsShiftProvider innerShiftProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Shift"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShiftProviderBase ShiftProvider
		{
			get
			{
				if (innerShiftProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerShiftProvider == null)
						{
							this.innerShiftProvider = new WsShiftProvider(this.url);
						}
					}
				}
				return innerShiftProvider;
			}
		}
		
			
		private WsTransactionHistoryArchiveProvider innerTransactionHistoryArchiveProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TransactionHistoryArchive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TransactionHistoryArchiveProviderBase TransactionHistoryArchiveProvider
		{
			get
			{
				if (innerTransactionHistoryArchiveProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerTransactionHistoryArchiveProvider == null)
						{
							this.innerTransactionHistoryArchiveProvider = new WsTransactionHistoryArchiveProvider(this.url);
						}
					}
				}
				return innerTransactionHistoryArchiveProvider;
			}
		}
		
			
		private WsVendorProvider innerVendorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vendor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VendorProviderBase VendorProvider
		{
			get
			{
				if (innerVendorProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerVendorProvider == null)
						{
							this.innerVendorProvider = new WsVendorProvider(this.url);
						}
					}
				}
				return innerVendorProvider;
			}
		}
		
			
		private WsAddressProvider innerAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Address"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AddressProviderBase AddressProvider
		{
			get
			{
				if (innerAddressProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAddressProvider == null)
						{
							this.innerAddressProvider = new WsAddressProvider(this.url);
						}
					}
				}
				return innerAddressProvider;
			}
		}
		
			
		private WsWorkOrderProvider innerWorkOrderProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="WorkOrder"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WorkOrderProviderBase WorkOrderProvider
		{
			get
			{
				if (innerWorkOrderProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerWorkOrderProvider == null)
						{
							this.innerWorkOrderProvider = new WsWorkOrderProvider(this.url);
						}
					}
				}
				return innerWorkOrderProvider;
			}
		}
		
			
		private WsVendorAddressProvider innerVendorAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VendorAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VendorAddressProviderBase VendorAddressProvider
		{
			get
			{
				if (innerVendorAddressProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerVendorAddressProvider == null)
						{
							this.innerVendorAddressProvider = new WsVendorAddressProvider(this.url);
						}
					}
				}
				return innerVendorAddressProvider;
			}
		}
		
			
		private WsTransactionHistoryProvider innerTransactionHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TransactionHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TransactionHistoryProviderBase TransactionHistoryProvider
		{
			get
			{
				if (innerTransactionHistoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerTransactionHistoryProvider == null)
						{
							this.innerTransactionHistoryProvider = new WsTransactionHistoryProvider(this.url);
						}
					}
				}
				return innerTransactionHistoryProvider;
			}
		}
		
			
		private WsVendorContactProvider innerVendorContactProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VendorContact"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VendorContactProviderBase VendorContactProvider
		{
			get
			{
				if (innerVendorContactProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerVendorContactProvider == null)
						{
							this.innerVendorContactProvider = new WsVendorContactProvider(this.url);
						}
					}
				}
				return innerVendorContactProvider;
			}
		}
		
			
		private WsTimestampPkProvider innerTimestampPkProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TimestampPk"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TimestampPkProviderBase TimestampPkProvider
		{
			get
			{
				if (innerTimestampPkProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerTimestampPkProvider == null)
						{
							this.innerTimestampPkProvider = new WsTimestampPkProvider(this.url);
						}
					}
				}
				return innerTimestampPkProvider;
			}
		}
		
			
		private WsShoppingCartItemProvider innerShoppingCartItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ShoppingCartItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShoppingCartItemProviderBase ShoppingCartItemProvider
		{
			get
			{
				if (innerShoppingCartItemProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerShoppingCartItemProvider == null)
						{
							this.innerShoppingCartItemProvider = new WsShoppingCartItemProvider(this.url);
						}
					}
				}
				return innerShoppingCartItemProvider;
			}
		}
		
			
		private WsTestVariantProvider innerTestVariantProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TestVariant"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TestVariantProviderBase TestVariantProvider
		{
			get
			{
				if (innerTestVariantProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerTestVariantProvider == null)
						{
							this.innerTestVariantProvider = new WsTestVariantProvider(this.url);
						}
					}
				}
				return innerTestVariantProvider;
			}
		}
		
			
		private WsSpecialOfferProvider innerSpecialOfferProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SpecialOffer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SpecialOfferProviderBase SpecialOfferProvider
		{
			get
			{
				if (innerSpecialOfferProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSpecialOfferProvider == null)
						{
							this.innerSpecialOfferProvider = new WsSpecialOfferProvider(this.url);
						}
					}
				}
				return innerSpecialOfferProvider;
			}
		}
		
			
		private WsShipMethodProvider innerShipMethodProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ShipMethod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShipMethodProviderBase ShipMethodProvider
		{
			get
			{
				if (innerShipMethodProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerShipMethodProvider == null)
						{
							this.innerShipMethodProvider = new WsShipMethodProvider(this.url);
						}
					}
				}
				return innerShipMethodProvider;
			}
		}
		
			
		private WsSpecialOfferProductProvider innerSpecialOfferProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SpecialOfferProduct"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SpecialOfferProductProviderBase SpecialOfferProductProvider
		{
			get
			{
				if (innerSpecialOfferProductProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSpecialOfferProductProvider == null)
						{
							this.innerSpecialOfferProductProvider = new WsSpecialOfferProductProvider(this.url);
						}
					}
				}
				return innerSpecialOfferProductProvider;
			}
		}
		
			
		private WsStateProvinceProvider innerStateProvinceProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="StateProvince"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StateProvinceProviderBase StateProvinceProvider
		{
			get
			{
				if (innerStateProvinceProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerStateProvinceProvider == null)
						{
							this.innerStateProvinceProvider = new WsStateProvinceProvider(this.url);
						}
					}
				}
				return innerStateProvinceProvider;
			}
		}
		
			
		private WsStoreProvider innerStoreProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Store"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StoreProviderBase StoreProvider
		{
			get
			{
				if (innerStoreProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerStoreProvider == null)
						{
							this.innerStoreProvider = new WsStoreProvider(this.url);
						}
					}
				}
				return innerStoreProvider;
			}
		}
		
			
		private WsProductPhotoProvider innerProductPhotoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductPhoto"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductPhotoProviderBase ProductPhotoProvider
		{
			get
			{
				if (innerProductPhotoProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductPhotoProvider == null)
						{
							this.innerProductPhotoProvider = new WsProductPhotoProvider(this.url);
						}
					}
				}
				return innerProductPhotoProvider;
			}
		}
		
			
		private WsStoreContactProvider innerStoreContactProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="StoreContact"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StoreContactProviderBase StoreContactProvider
		{
			get
			{
				if (innerStoreContactProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerStoreContactProvider == null)
						{
							this.innerStoreContactProvider = new WsStoreContactProvider(this.url);
						}
					}
				}
				return innerStoreContactProvider;
			}
		}
		
			
		private WsProductModelProductDescriptionCultureProvider innerProductModelProductDescriptionCultureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductModelProductDescriptionCulture"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductModelProductDescriptionCultureProviderBase ProductModelProductDescriptionCultureProvider
		{
			get
			{
				if (innerProductModelProductDescriptionCultureProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductModelProductDescriptionCultureProvider == null)
						{
							this.innerProductModelProductDescriptionCultureProvider = new WsProductModelProductDescriptionCultureProvider(this.url);
						}
					}
				}
				return innerProductModelProductDescriptionCultureProvider;
			}
		}
		
			
		private WsCurrencyProvider innerCurrencyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Currency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CurrencyProviderBase CurrencyProvider
		{
			get
			{
				if (innerCurrencyProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCurrencyProvider == null)
						{
							this.innerCurrencyProvider = new WsCurrencyProvider(this.url);
						}
					}
				}
				return innerCurrencyProvider;
			}
		}
		
			
		private WsCustomerProvider innerCustomerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Customer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerProviderBase CustomerProvider
		{
			get
			{
				if (innerCustomerProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCustomerProvider == null)
						{
							this.innerCustomerProvider = new WsCustomerProvider(this.url);
						}
					}
				}
				return innerCustomerProvider;
			}
		}
		
			
		private WsCurrencyRateProvider innerCurrencyRateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CurrencyRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CurrencyRateProviderBase CurrencyRateProvider
		{
			get
			{
				if (innerCurrencyRateProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCurrencyRateProvider == null)
						{
							this.innerCurrencyRateProvider = new WsCurrencyRateProvider(this.url);
						}
					}
				}
				return innerCurrencyRateProvider;
			}
		}
		
			
		private WsDepartmentProvider innerDepartmentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Department"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DepartmentProviderBase DepartmentProvider
		{
			get
			{
				if (innerDepartmentProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerDepartmentProvider == null)
						{
							this.innerDepartmentProvider = new WsDepartmentProvider(this.url);
						}
					}
				}
				return innerDepartmentProvider;
			}
		}
		
			
		private WsCustomerAddressProvider innerCustomerAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerAddressProviderBase CustomerAddressProvider
		{
			get
			{
				if (innerCustomerAddressProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCustomerAddressProvider == null)
						{
							this.innerCustomerAddressProvider = new WsCustomerAddressProvider(this.url);
						}
					}
				}
				return innerCustomerAddressProvider;
			}
		}
		
			
		private WsCultureProvider innerCultureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Culture"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CultureProviderBase CultureProvider
		{
			get
			{
				if (innerCultureProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCultureProvider == null)
						{
							this.innerCultureProvider = new WsCultureProvider(this.url);
						}
					}
				}
				return innerCultureProvider;
			}
		}
		
			
		private WsDatabaseLogProvider innerDatabaseLogProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DatabaseLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DatabaseLogProviderBase DatabaseLogProvider
		{
			get
			{
				if (innerDatabaseLogProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerDatabaseLogProvider == null)
						{
							this.innerDatabaseLogProvider = new WsDatabaseLogProvider(this.url);
						}
					}
				}
				return innerDatabaseLogProvider;
			}
		}
		
			
		private WsCreditCardProvider innerCreditCardProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CreditCard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CreditCardProviderBase CreditCardProvider
		{
			get
			{
				if (innerCreditCardProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCreditCardProvider == null)
						{
							this.innerCreditCardProvider = new WsCreditCardProvider(this.url);
						}
					}
				}
				return innerCreditCardProvider;
			}
		}
		
			
		private WsBillOfMaterialsProvider innerBillOfMaterialsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BillOfMaterials"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BillOfMaterialsProviderBase BillOfMaterialsProvider
		{
			get
			{
				if (innerBillOfMaterialsProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerBillOfMaterialsProvider == null)
						{
							this.innerBillOfMaterialsProvider = new WsBillOfMaterialsProvider(this.url);
						}
					}
				}
				return innerBillOfMaterialsProvider;
			}
		}
		
			
		private WsCountryRegionCurrencyProvider innerCountryRegionCurrencyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CountryRegionCurrency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CountryRegionCurrencyProviderBase CountryRegionCurrencyProvider
		{
			get
			{
				if (innerCountryRegionCurrencyProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCountryRegionCurrencyProvider == null)
						{
							this.innerCountryRegionCurrencyProvider = new WsCountryRegionCurrencyProvider(this.url);
						}
					}
				}
				return innerCountryRegionCurrencyProvider;
			}
		}
		
			
		private WsContactProvider innerContactProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Contact"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContactProviderBase ContactProvider
		{
			get
			{
				if (innerContactProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerContactProvider == null)
						{
							this.innerContactProvider = new WsContactProvider(this.url);
						}
					}
				}
				return innerContactProvider;
			}
		}
		
			
		private WsAwBuildVersionProvider innerAwBuildVersionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AwBuildVersion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AwBuildVersionProviderBase AwBuildVersionProvider
		{
			get
			{
				if (innerAwBuildVersionProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAwBuildVersionProvider == null)
						{
							this.innerAwBuildVersionProvider = new WsAwBuildVersionProvider(this.url);
						}
					}
				}
				return innerAwBuildVersionProvider;
			}
		}
		
			
		private WsCountryRegionProvider innerCountryRegionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CountryRegion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CountryRegionProviderBase CountryRegionProvider
		{
			get
			{
				if (innerCountryRegionProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCountryRegionProvider == null)
						{
							this.innerCountryRegionProvider = new WsCountryRegionProvider(this.url);
						}
					}
				}
				return innerCountryRegionProvider;
			}
		}
		
			
		private WsContactCreditCardProvider innerContactCreditCardProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ContactCreditCard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContactCreditCardProviderBase ContactCreditCardProvider
		{
			get
			{
				if (innerContactCreditCardProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerContactCreditCardProvider == null)
						{
							this.innerContactCreditCardProvider = new WsContactCreditCardProvider(this.url);
						}
					}
				}
				return innerContactCreditCardProvider;
			}
		}
		
			
		private WsDocumentProvider innerDocumentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Document"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DocumentProviderBase DocumentProvider
		{
			get
			{
				if (innerDocumentProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerDocumentProvider == null)
						{
							this.innerDocumentProvider = new WsDocumentProvider(this.url);
						}
					}
				}
				return innerDocumentProvider;
			}
		}
		
			
		private WsContactTypeProvider innerContactTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ContactType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContactTypeProviderBase ContactTypeProvider
		{
			get
			{
				if (innerContactTypeProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerContactTypeProvider == null)
						{
							this.innerContactTypeProvider = new WsContactTypeProvider(this.url);
						}
					}
				}
				return innerContactTypeProvider;
			}
		}
		
			
		private WsEmployeeProvider innerEmployeeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Employee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeProviderBase EmployeeProvider
		{
			get
			{
				if (innerEmployeeProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerEmployeeProvider == null)
						{
							this.innerEmployeeProvider = new WsEmployeeProvider(this.url);
						}
					}
				}
				return innerEmployeeProvider;
			}
		}
		
			
		private WsProductDocumentProvider innerProductDocumentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductDocument"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductDocumentProviderBase ProductDocumentProvider
		{
			get
			{
				if (innerProductDocumentProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductDocumentProvider == null)
						{
							this.innerProductDocumentProvider = new WsProductDocumentProvider(this.url);
						}
					}
				}
				return innerProductDocumentProvider;
			}
		}
		
			
		private WsEmployeeAddressProvider innerEmployeeAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeeAddress"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeAddressProviderBase EmployeeAddressProvider
		{
			get
			{
				if (innerEmployeeAddressProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerEmployeeAddressProvider == null)
						{
							this.innerEmployeeAddressProvider = new WsEmployeeAddressProvider(this.url);
						}
					}
				}
				return innerEmployeeAddressProvider;
			}
		}
		
			
		private WsProductInventoryProvider innerProductInventoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductInventory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductInventoryProviderBase ProductInventoryProvider
		{
			get
			{
				if (innerProductInventoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductInventoryProvider == null)
						{
							this.innerProductInventoryProvider = new WsProductInventoryProvider(this.url);
						}
					}
				}
				return innerProductInventoryProvider;
			}
		}
		
			
		private WsProductDescriptionProvider innerProductDescriptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductDescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductDescriptionProviderBase ProductDescriptionProvider
		{
			get
			{
				if (innerProductDescriptionProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductDescriptionProvider == null)
						{
							this.innerProductDescriptionProvider = new WsProductDescriptionProvider(this.url);
						}
					}
				}
				return innerProductDescriptionProvider;
			}
		}
		
			
		private WsProductModelIllustrationProvider innerProductModelIllustrationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductModelIllustration"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductModelIllustrationProviderBase ProductModelIllustrationProvider
		{
			get
			{
				if (innerProductModelIllustrationProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductModelIllustrationProvider == null)
						{
							this.innerProductModelIllustrationProvider = new WsProductModelIllustrationProvider(this.url);
						}
					}
				}
				return innerProductModelIllustrationProvider;
			}
		}
		
			
		private WsProductListPriceHistoryProvider innerProductListPriceHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductListPriceHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductListPriceHistoryProviderBase ProductListPriceHistoryProvider
		{
			get
			{
				if (innerProductListPriceHistoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductListPriceHistoryProvider == null)
						{
							this.innerProductListPriceHistoryProvider = new WsProductListPriceHistoryProvider(this.url);
						}
					}
				}
				return innerProductListPriceHistoryProvider;
			}
		}
		
			
		private WsProductCostHistoryProvider innerProductCostHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductCostHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductCostHistoryProviderBase ProductCostHistoryProvider
		{
			get
			{
				if (innerProductCostHistoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerProductCostHistoryProvider == null)
						{
							this.innerProductCostHistoryProvider = new WsProductCostHistoryProvider(this.url);
						}
					}
				}
				return innerProductCostHistoryProvider;
			}
		}
		
			
		private WsWorkOrderRoutingProvider innerWorkOrderRoutingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="WorkOrderRouting"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WorkOrderRoutingProviderBase WorkOrderRoutingProvider
		{
			get
			{
				if (innerWorkOrderRoutingProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerWorkOrderRoutingProvider == null)
						{
							this.innerWorkOrderRoutingProvider = new WsWorkOrderRoutingProvider(this.url);
						}
					}
				}
				return innerWorkOrderRoutingProvider;
			}
		}
		
			
		private WsNullFkeyParentProvider innerNullFkeyParentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="NullFkeyParent"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NullFkeyParentProviderBase NullFkeyParentProvider
		{
			get
			{
				if (innerNullFkeyParentProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerNullFkeyParentProvider == null)
						{
							this.innerNullFkeyParentProvider = new WsNullFkeyParentProvider(this.url);
						}
					}
				}
				return innerNullFkeyParentProvider;
			}
		}
		
			
		private WsEmployeePayHistoryProvider innerEmployeePayHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeePayHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeePayHistoryProviderBase EmployeePayHistoryProvider
		{
			get
			{
				if (innerEmployeePayHistoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerEmployeePayHistoryProvider == null)
						{
							this.innerEmployeePayHistoryProvider = new WsEmployeePayHistoryProvider(this.url);
						}
					}
				}
				return innerEmployeePayHistoryProvider;
			}
		}
		
			
		private WsNullFkeyChildProvider innerNullFkeyChildProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="NullFkeyChild"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NullFkeyChildProviderBase NullFkeyChildProvider
		{
			get
			{
				if (innerNullFkeyChildProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerNullFkeyChildProvider == null)
						{
							this.innerNullFkeyChildProvider = new WsNullFkeyChildProvider(this.url);
						}
					}
				}
				return innerNullFkeyChildProvider;
			}
		}
		
			
		private WsErrorLogProvider innerErrorLogProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ErrorLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ErrorLogProviderBase ErrorLogProvider
		{
			get
			{
				if (innerErrorLogProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerErrorLogProvider == null)
						{
							this.innerErrorLogProvider = new WsErrorLogProvider(this.url);
						}
					}
				}
				return innerErrorLogProvider;
			}
		}
		
			
		private WsEmployeeDepartmentHistoryProvider innerEmployeeDepartmentHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeeDepartmentHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeDepartmentHistoryProviderBase EmployeeDepartmentHistoryProvider
		{
			get
			{
				if (innerEmployeeDepartmentHistoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerEmployeeDepartmentHistoryProvider == null)
						{
							this.innerEmployeeDepartmentHistoryProvider = new WsEmployeeDepartmentHistoryProvider(this.url);
						}
					}
				}
				return innerEmployeeDepartmentHistoryProvider;
			}
		}
		
			
		private WsJobCandidateProvider innerJobCandidateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobCandidate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobCandidateProviderBase JobCandidateProvider
		{
			get
			{
				if (innerJobCandidateProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerJobCandidateProvider == null)
						{
							this.innerJobCandidateProvider = new WsJobCandidateProvider(this.url);
						}
					}
				}
				return innerJobCandidateProvider;
			}
		}
		
			
		private WsIllustrationProvider innerIllustrationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Illustration"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IllustrationProviderBase IllustrationProvider
		{
			get
			{
				if (innerIllustrationProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerIllustrationProvider == null)
						{
							this.innerIllustrationProvider = new WsIllustrationProvider(this.url);
						}
					}
				}
				return innerIllustrationProvider;
			}
		}
		
			
		private WsAddressTypeProvider innerAddressTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AddressType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AddressTypeProviderBase AddressTypeProvider
		{
			get
			{
				if (innerAddressTypeProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAddressTypeProvider == null)
						{
							this.innerAddressTypeProvider = new WsAddressTypeProvider(this.url);
						}
					}
				}
				return innerAddressTypeProvider;
			}
		}
		
			
		private WsIndividualProvider innerIndividualProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Individual"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IndividualProviderBase IndividualProvider
		{
			get
			{
				if (innerIndividualProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerIndividualProvider == null)
						{
							this.innerIndividualProvider = new WsIndividualProvider(this.url);
						}
					}
				}
				return innerIndividualProvider;
			}
		}
		
		
			
		private WsVAdditionalContactInfoProvider innerVAdditionalContactInfoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VAdditionalContactInfo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VAdditionalContactInfoProviderBase VAdditionalContactInfoProvider
		{
			get
			{
				if (innerVAdditionalContactInfoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVAdditionalContactInfoProvider == null)
						{
							this.innerVAdditionalContactInfoProvider = new WsVAdditionalContactInfoProvider(this.url);
						}
					}
				}
				return innerVAdditionalContactInfoProvider;
			}
		}
		
			
		private WsVEmployeeProvider innerVEmployeeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VEmployee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VEmployeeProviderBase VEmployeeProvider
		{
			get
			{
				if (innerVEmployeeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVEmployeeProvider == null)
						{
							this.innerVEmployeeProvider = new WsVEmployeeProvider(this.url);
						}
					}
				}
				return innerVEmployeeProvider;
			}
		}
		
			
		private WsVEmployeeDepartmentProvider innerVEmployeeDepartmentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VEmployeeDepartment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VEmployeeDepartmentProviderBase VEmployeeDepartmentProvider
		{
			get
			{
				if (innerVEmployeeDepartmentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVEmployeeDepartmentProvider == null)
						{
							this.innerVEmployeeDepartmentProvider = new WsVEmployeeDepartmentProvider(this.url);
						}
					}
				}
				return innerVEmployeeDepartmentProvider;
			}
		}
		
			
		private WsVEmployeeDepartmentHistoryProvider innerVEmployeeDepartmentHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VEmployeeDepartmentHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VEmployeeDepartmentHistoryProviderBase VEmployeeDepartmentHistoryProvider
		{
			get
			{
				if (innerVEmployeeDepartmentHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVEmployeeDepartmentHistoryProvider == null)
						{
							this.innerVEmployeeDepartmentHistoryProvider = new WsVEmployeeDepartmentHistoryProvider(this.url);
						}
					}
				}
				return innerVEmployeeDepartmentHistoryProvider;
			}
		}
		
			
		private WsVIndividualCustomerProvider innerVIndividualCustomerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VIndividualCustomer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VIndividualCustomerProviderBase VIndividualCustomerProvider
		{
			get
			{
				if (innerVIndividualCustomerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVIndividualCustomerProvider == null)
						{
							this.innerVIndividualCustomerProvider = new WsVIndividualCustomerProvider(this.url);
						}
					}
				}
				return innerVIndividualCustomerProvider;
			}
		}
		
			
		private WsVIndividualDemographicsProvider innerVIndividualDemographicsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VIndividualDemographics"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VIndividualDemographicsProviderBase VIndividualDemographicsProvider
		{
			get
			{
				if (innerVIndividualDemographicsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVIndividualDemographicsProvider == null)
						{
							this.innerVIndividualDemographicsProvider = new WsVIndividualDemographicsProvider(this.url);
						}
					}
				}
				return innerVIndividualDemographicsProvider;
			}
		}
		
			
		private WsVJobCandidateProvider innerVJobCandidateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VJobCandidate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VJobCandidateProviderBase VJobCandidateProvider
		{
			get
			{
				if (innerVJobCandidateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVJobCandidateProvider == null)
						{
							this.innerVJobCandidateProvider = new WsVJobCandidateProvider(this.url);
						}
					}
				}
				return innerVJobCandidateProvider;
			}
		}
		
			
		private WsVJobCandidateEducationProvider innerVJobCandidateEducationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VJobCandidateEducation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VJobCandidateEducationProviderBase VJobCandidateEducationProvider
		{
			get
			{
				if (innerVJobCandidateEducationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVJobCandidateEducationProvider == null)
						{
							this.innerVJobCandidateEducationProvider = new WsVJobCandidateEducationProvider(this.url);
						}
					}
				}
				return innerVJobCandidateEducationProvider;
			}
		}
		
			
		private WsVJobCandidateEmploymentProvider innerVJobCandidateEmploymentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VJobCandidateEmployment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VJobCandidateEmploymentProviderBase VJobCandidateEmploymentProvider
		{
			get
			{
				if (innerVJobCandidateEmploymentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVJobCandidateEmploymentProvider == null)
						{
							this.innerVJobCandidateEmploymentProvider = new WsVJobCandidateEmploymentProvider(this.url);
						}
					}
				}
				return innerVJobCandidateEmploymentProvider;
			}
		}
		
			
		private WsVProductAndDescriptionProvider innerVProductAndDescriptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VProductAndDescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VProductAndDescriptionProviderBase VProductAndDescriptionProvider
		{
			get
			{
				if (innerVProductAndDescriptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVProductAndDescriptionProvider == null)
						{
							this.innerVProductAndDescriptionProvider = new WsVProductAndDescriptionProvider(this.url);
						}
					}
				}
				return innerVProductAndDescriptionProvider;
			}
		}
		
			
		private WsVProductModelCatalogDescriptionProvider innerVProductModelCatalogDescriptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VProductModelCatalogDescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VProductModelCatalogDescriptionProviderBase VProductModelCatalogDescriptionProvider
		{
			get
			{
				if (innerVProductModelCatalogDescriptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVProductModelCatalogDescriptionProvider == null)
						{
							this.innerVProductModelCatalogDescriptionProvider = new WsVProductModelCatalogDescriptionProvider(this.url);
						}
					}
				}
				return innerVProductModelCatalogDescriptionProvider;
			}
		}
		
			
		private WsVProductModelInstructionsProvider innerVProductModelInstructionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VProductModelInstructions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VProductModelInstructionsProviderBase VProductModelInstructionsProvider
		{
			get
			{
				if (innerVProductModelInstructionsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVProductModelInstructionsProvider == null)
						{
							this.innerVProductModelInstructionsProvider = new WsVProductModelInstructionsProvider(this.url);
						}
					}
				}
				return innerVProductModelInstructionsProvider;
			}
		}
		
			
		private WsVSalesPersonProvider innerVSalesPersonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VSalesPerson"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VSalesPersonProviderBase VSalesPersonProvider
		{
			get
			{
				if (innerVSalesPersonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVSalesPersonProvider == null)
						{
							this.innerVSalesPersonProvider = new WsVSalesPersonProvider(this.url);
						}
					}
				}
				return innerVSalesPersonProvider;
			}
		}
		
			
		private WsVSalesPersonSalesByFiscalYearsProvider innerVSalesPersonSalesByFiscalYearsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VSalesPersonSalesByFiscalYears"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VSalesPersonSalesByFiscalYearsProviderBase VSalesPersonSalesByFiscalYearsProvider
		{
			get
			{
				if (innerVSalesPersonSalesByFiscalYearsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVSalesPersonSalesByFiscalYearsProvider == null)
						{
							this.innerVSalesPersonSalesByFiscalYearsProvider = new WsVSalesPersonSalesByFiscalYearsProvider(this.url);
						}
					}
				}
				return innerVSalesPersonSalesByFiscalYearsProvider;
			}
		}
		
			
		private WsVStateProvinceCountryRegionProvider innerVStateProvinceCountryRegionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VStateProvinceCountryRegion"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VStateProvinceCountryRegionProviderBase VStateProvinceCountryRegionProvider
		{
			get
			{
				if (innerVStateProvinceCountryRegionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVStateProvinceCountryRegionProvider == null)
						{
							this.innerVStateProvinceCountryRegionProvider = new WsVStateProvinceCountryRegionProvider(this.url);
						}
					}
				}
				return innerVStateProvinceCountryRegionProvider;
			}
		}
		
			
		private WsVStoreWithDemographicsProvider innerVStoreWithDemographicsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VStoreWithDemographics"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VStoreWithDemographicsProviderBase VStoreWithDemographicsProvider
		{
			get
			{
				if (innerVStoreWithDemographicsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVStoreWithDemographicsProvider == null)
						{
							this.innerVStoreWithDemographicsProvider = new WsVStoreWithDemographicsProvider(this.url);
						}
					}
				}
				return innerVStoreWithDemographicsProvider;
			}
		}
		
			
		private WsVVendorProvider innerVVendorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VVendor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VVendorProviderBase VVendorProvider
		{
			get
			{
				if (innerVVendorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerVVendorProvider == null)
						{
							this.innerVVendorProvider = new WsVVendorProvider(this.url);
						}
					}
				}
				return innerVVendorProvider;
			}
		}
		
		
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
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
			return proxy.ExecuteNonQuery(storedProcedureName, parameterValues);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
			return proxy.ExecuteNonQuery((WsProxy.CommandType)Enum.Parse(typeof(WsProxy.CommandType), commandType.ToString(), false), commandText);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");
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
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
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
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
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
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
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
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
			return proxy.ExecuteDataSet(storedProcedureName, parameterValues);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
			return proxy.ExecuteDataSet((WsProxy.CommandType)Enum.Parse(typeof(WsProxy.CommandType), commandType.ToString(), false), commandText);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");			
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
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
			return proxy.ExecuteScalar(storedProcedureName, parameterValues);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
			return proxy.ExecuteScalar((WsProxy.CommandType)Enum.Parse(typeof(WsProxy.CommandType), commandType.ToString(), false), commandText);	
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");		
		}
		#endregion

		#endregion
	}
}
