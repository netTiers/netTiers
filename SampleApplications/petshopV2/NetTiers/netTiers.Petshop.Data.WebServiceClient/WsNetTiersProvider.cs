

#region Using directives

using System;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using netTiers.Petshop.Data.Bases;

#endregion

namespace netTiers.Petshop.Data.WebServiceClient
{
	/// <summary>
	/// The WebService client data provider.
	/// </summary>
	public sealed class WsNetTiersProvider : netTiers.Petshop.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
		private string _url;
        
		/// <summary>
		/// Initializes a new instance of the <see cref="WsDataProvider"/> class.
		///</summary>
		public WsNetTiersProvider()
		{			
		}
		
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


            #region "Initialize Url"
            string url  = config["url"];
           	if (string.IsNullOrEmpty(url))
            {
                throw new ProviderException("Empty or missing url");
            }
            this._url = url;
            config.Remove("url");
            #endregion

        }
        
        public string Url
        {
        	get {return this._url;}
        	set {this._url = value;}
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			throw new NotSupportedException("Transactions are not supported by the webservice client.");
		}
		
		///<summary>
		/// Indicates if the current <c cref="DataProviderBase"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return false;
			}
		}

			
		private WsAccountProvider innerAccountProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Account"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AccountProviderBase AccountProvider
		{
			get
			{
				if (innerAccountProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAccountProvider == null)
						{
							this.innerAccountProvider = new WsAccountProvider(this._url);
						}
					}
				}
				return innerAccountProvider;
			}
		}
		
			
		private WsCategoryProvider innerCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Category"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CategoryProviderBase CategoryProvider
		{
			get
			{
				if (innerCategoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCategoryProvider == null)
						{
							this.innerCategoryProvider = new WsCategoryProvider(this._url);
						}
					}
				}
				return innerCategoryProvider;
			}
		}
		
			
		private WsCourierProvider innerCourierProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Courier"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CourierProviderBase CourierProvider
		{
			get
			{
				if (innerCourierProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerCourierProvider == null)
						{
							this.innerCourierProvider = new WsCourierProvider(this._url);
						}
					}
				}
				return innerCourierProvider;
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
							this.innerCreditCardProvider = new WsCreditCardProvider(this._url);
						}
					}
				}
				return innerCreditCardProvider;
			}
		}
		
			
		private WsInventoryProvider innerInventoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Inventory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override InventoryProviderBase InventoryProvider
		{
			get
			{
				if (innerInventoryProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerInventoryProvider == null)
						{
							this.innerInventoryProvider = new WsInventoryProvider(this._url);
						}
					}
				}
				return innerInventoryProvider;
			}
		}
		
			
		private WsItemProvider innerItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Item"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemProviderBase ItemProvider
		{
			get
			{
				if (innerItemProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerItemProvider == null)
						{
							this.innerItemProvider = new WsItemProvider(this._url);
						}
					}
				}
				return innerItemProvider;
			}
		}
		
			
		private WsLineItemProvider innerLineItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LineItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LineItemProviderBase LineItemProvider
		{
			get
			{
				if (innerLineItemProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerLineItemProvider == null)
						{
							this.innerLineItemProvider = new WsLineItemProvider(this._url);
						}
					}
				}
				return innerLineItemProvider;
			}
		}
		
			
		private WsOrdersProvider innerOrdersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Orders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrdersProviderBase OrdersProvider
		{
			get
			{
				if (innerOrdersProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerOrdersProvider == null)
						{
							this.innerOrdersProvider = new WsOrdersProvider(this._url);
						}
					}
				}
				return innerOrdersProvider;
			}
		}
		
			
		private WsOrderStatusProvider innerOrderStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderStatusProviderBase OrderStatusProvider
		{
			get
			{
				if (innerOrderStatusProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerOrderStatusProvider == null)
						{
							this.innerOrderStatusProvider = new WsOrderStatusProvider(this._url);
						}
					}
				}
				return innerOrderStatusProvider;
			}
		}
		
			
		private WsOrderStatusTypeProvider innerOrderStatusTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderStatusType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderStatusTypeProviderBase OrderStatusTypeProvider
		{
			get
			{
				if (innerOrderStatusTypeProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerOrderStatusTypeProvider == null)
						{
							this.innerOrderStatusTypeProvider = new WsOrderStatusTypeProvider(this._url);
						}
					}
				}
				return innerOrderStatusTypeProvider;
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
							this.innerProductProvider = new WsProductProvider(this._url);
						}
					}
				}
				return innerProductProvider;
			}
		}
		
			
		private WsSupplierProvider innerSupplierProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Supplier"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SupplierProviderBase SupplierProvider
		{
			get
			{
				if (innerSupplierProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerSupplierProvider == null)
						{
							this.innerSupplierProvider = new WsSupplierProvider(this._url);
						}
					}
				}
				return innerSupplierProvider;
			}
		}
		
		
			
		private WsExtendedItemProvider innerExtendedItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ExtendedItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ExtendedItemProviderBase ExtendedItemProvider
		{
			get
			{
				if (innerExtendedItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerExtendedItemProvider == null)
						{
							this.innerExtendedItemProvider = new WsExtendedItemProvider(this._url);
						}
					}
				}
				return innerExtendedItemProvider;
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
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
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
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
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
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
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
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
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
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
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
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
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
