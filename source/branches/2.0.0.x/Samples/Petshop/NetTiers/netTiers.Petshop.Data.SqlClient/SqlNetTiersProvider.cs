
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

using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Data.Bases;

#endregion

namespace netTiers.Petshop.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : netTiers.Petshop.Data.Bases.NetTiersProvider
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
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
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
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "AccountProvider"
			
		private SqlAccountProvider innerSqlAccountProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Account"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AccountProviderBase AccountProvider
		{
			get
			{
				if (innerSqlAccountProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAccountProvider == null)
						{
							this.innerSqlAccountProvider = new SqlAccountProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAccountProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAccountProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAccountProvider SqlAccountProvider
		{
			get {return AccountProvider as SqlAccountProvider;}
		}
		
		#endregion
		
		
		#region "CategoryProvider"
			
		private SqlCategoryProvider innerSqlCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Category"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CategoryProviderBase CategoryProvider
		{
			get
			{
				if (innerSqlCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCategoryProvider == null)
						{
							this.innerSqlCategoryProvider = new SqlCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCategoryProvider SqlCategoryProvider
		{
			get {return CategoryProvider as SqlCategoryProvider;}
		}
		
		#endregion
		
		
		#region "CourierProvider"
			
		private SqlCourierProvider innerSqlCourierProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Courier"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CourierProviderBase CourierProvider
		{
			get
			{
				if (innerSqlCourierProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCourierProvider == null)
						{
							this.innerSqlCourierProvider = new SqlCourierProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCourierProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCourierProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCourierProvider SqlCourierProvider
		{
			get {return CourierProvider as SqlCourierProvider;}
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
		/// Gets the current <c cref="SqlCreditCardProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCreditCardProvider SqlCreditCardProvider
		{
			get {return CreditCardProvider as SqlCreditCardProvider;}
		}
		
		#endregion
		
		
		#region "InventoryProvider"
			
		private SqlInventoryProvider innerSqlInventoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Inventory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override InventoryProviderBase InventoryProvider
		{
			get
			{
				if (innerSqlInventoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlInventoryProvider == null)
						{
							this.innerSqlInventoryProvider = new SqlInventoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlInventoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlInventoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlInventoryProvider SqlInventoryProvider
		{
			get {return InventoryProvider as SqlInventoryProvider;}
		}
		
		#endregion
		
		
		#region "ItemProvider"
			
		private SqlItemProvider innerSqlItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Item"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemProviderBase ItemProvider
		{
			get
			{
				if (innerSqlItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemProvider == null)
						{
							this.innerSqlItemProvider = new SqlItemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlItemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemProvider SqlItemProvider
		{
			get {return ItemProvider as SqlItemProvider;}
		}
		
		#endregion
		
		
		#region "LineItemProvider"
			
		private SqlLineItemProvider innerSqlLineItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LineItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LineItemProviderBase LineItemProvider
		{
			get
			{
				if (innerSqlLineItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLineItemProvider == null)
						{
							this.innerSqlLineItemProvider = new SqlLineItemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLineItemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLineItemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLineItemProvider SqlLineItemProvider
		{
			get {return LineItemProvider as SqlLineItemProvider;}
		}
		
		#endregion
		
		
		#region "OrdersProvider"
			
		private SqlOrdersProvider innerSqlOrdersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Orders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrdersProviderBase OrdersProvider
		{
			get
			{
				if (innerSqlOrdersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrdersProvider == null)
						{
							this.innerSqlOrdersProvider = new SqlOrdersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrdersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOrdersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrdersProvider SqlOrdersProvider
		{
			get {return OrdersProvider as SqlOrdersProvider;}
		}
		
		#endregion
		
		
		#region "OrderStatusProvider"
			
		private SqlOrderStatusProvider innerSqlOrderStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderStatusProviderBase OrderStatusProvider
		{
			get
			{
				if (innerSqlOrderStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderStatusProvider == null)
						{
							this.innerSqlOrderStatusProvider = new SqlOrderStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOrderStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderStatusProvider SqlOrderStatusProvider
		{
			get {return OrderStatusProvider as SqlOrderStatusProvider;}
		}
		
		#endregion
		
		
		#region "OrderStatusTypeProvider"
			
		private SqlOrderStatusTypeProvider innerSqlOrderStatusTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderStatusType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderStatusTypeProviderBase OrderStatusTypeProvider
		{
			get
			{
				if (innerSqlOrderStatusTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderStatusTypeProvider == null)
						{
							this.innerSqlOrderStatusTypeProvider = new SqlOrderStatusTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderStatusTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOrderStatusTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderStatusTypeProvider SqlOrderStatusTypeProvider
		{
			get {return OrderStatusTypeProvider as SqlOrderStatusTypeProvider;}
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
		/// Gets the current <c cref="SqlProductProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductProvider SqlProductProvider
		{
			get {return ProductProvider as SqlProductProvider;}
		}
		
		#endregion
		
		
		#region "SupplierProvider"
			
		private SqlSupplierProvider innerSqlSupplierProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Supplier"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SupplierProviderBase SupplierProvider
		{
			get
			{
				if (innerSqlSupplierProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSupplierProvider == null)
						{
							this.innerSqlSupplierProvider = new SqlSupplierProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSupplierProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSupplierProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSupplierProvider SqlSupplierProvider
		{
			get {return SupplierProvider as SqlSupplierProvider;}
		}
		
		#endregion
		
		
		
		#region "ExtendedItemProvider"
		
		private SqlExtendedItemProvider innerSqlExtendedItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ExtendedItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ExtendedItemProviderBase ExtendedItemProvider
		{
			get
			{
				if (innerSqlExtendedItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlExtendedItemProvider == null)
						{
							this.innerSqlExtendedItemProvider = new SqlExtendedItemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlExtendedItemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlExtendedItemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlExtendedItemProvider SqlExtendedItemProvider
		{
			get {return ExtendedItemProvider as SqlExtendedItemProvider;}
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
