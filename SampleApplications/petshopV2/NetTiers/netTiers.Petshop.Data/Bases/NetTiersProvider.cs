
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using netTiers.Petshop.Entities;

#endregion

namespace netTiers.Petshop.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : ProviderBase
	{
		private Type entityCreationalFactoryType = null;
        private static object syncObject = new object();
        private bool enableEntityTracking = true;
        private bool enableListTracking = false;
        private bool useEntityFactory = true;
		private bool enableMethodAuthorization = false;

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
	        base.Initialize(name, config);
	        
            string entityCreationalFactoryTypeString = config["entityFactoryType"];

	        lock(syncObject)
            {
                if (string.IsNullOrEmpty(entityCreationalFactoryTypeString))
				{
                    entityCreationalFactoryType = typeof(netTiers.Petshop.Entities.EntityFactory);
				}
				else
				{
					foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
					{
						if (assembly.FullName.Split(',')[0] == entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')))
						{
							entityCreationalFactoryType = assembly.GetType(entityCreationalFactoryTypeString, false, true);
							break;
						}
					}
				}
				
                if (entityCreationalFactoryType == null)
                {
                    System.Reflection.Assembly entityLibrary = null;
                    //assembly still not found, try loading the assembly.  It's possible it's not referenced.
                    try
                    {
                        //entityLibrary = AppDomain.CurrentDomain.Load(string.Format("{0}.dll", entityCreationalFactoryType.Substring(0, entityCreationalFactoryType.LastIndexOf('.'))));
                        entityLibrary = System.Reflection.Assembly.Load(
                            entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')));
                    }
                    catch
                    {
                        //throws file not found exception
                    }

                    if (entityLibrary != null)
                    {
                        entityCreationalFactoryType = entityLibrary.GetType(entityCreationalFactoryTypeString, false, true);
                    }
                }
                if (entityCreationalFactoryType == null)
                    throw new ArgumentNullException("Could not find a valid entity factory configured in assemblies.  .netTiers can not continue.");
                
                bool t;
                enableEntityTracking = bool.TryParse(config["enableEntityTracking"], out t);

                bool l;
                enableListTracking = bool.TryParse(config["enableListTracking"], out l);

                bool c;
                useEntityFactory = bool.TryParse(config["useEntityFactory"], out c);
				
				bool m;
                enableMethodAuthorization = bool.TryParse(config["enableMethodAuthorization"], out m);
				
			}   
         }
	    
        /// <summary>
        /// Gets or sets the Creational Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual Type EntityCreationalFactoryType
        {
            get
            {
                return entityCreationalFactoryType;
            }
            set
            {
                entityCreationalFactoryType = value;
            }
        }

        /// <summary>
        /// Gets or sets the ability to track entities.
        /// </summary>
        /// <value>true/false.</value>
        public virtual bool EnableEntityTracking
        {
            get
            {
                return enableEntityTracking;
            }
            set { enableEntityTracking = value; }
        }

        /// <summary>
        /// Gets or sets the Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual bool EnableListTracking
        {
            get
            {
                return enableListTracking;
            }
            set 
            {
                enableListTracking = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use entity factory property to enable the usage of the EntityFactory and it's type cache.
        /// </summary>
        /// <value>bool value</value>
        public virtual bool UseEntityFactory
        {
            get
            {
                return useEntityFactory;
            }
            set 
            {
                useEntityFactory = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use Enable Method Authorization to enable the usage of the Microsoft Patterns and Practices 
		/// IAuthorizationRuleProvider for code level authorization.
		/// </summary>
        /// <value>A bool value.</value>
        public virtual bool EnableMethodAuthorization
        {
            get
            {
                return enableMethodAuthorization;
            }
            set 
            {
                enableMethodAuthorization = value; 
            }
        }

		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation is supporting Transactions.
		///</summary>
		public abstract bool IsTransactionSupported{get;}
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public virtual TransactionManager CreateTransaction() {throw new NotSupportedException();}
		
		
		///<summary>
		/// Current AccountProviderBase instance.
		///</summary>
		public virtual AccountProviderBase AccountProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CategoryProviderBase instance.
		///</summary>
		public virtual CategoryProviderBase CategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CourierProviderBase instance.
		///</summary>
		public virtual CourierProviderBase CourierProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CreditCardProviderBase instance.
		///</summary>
		public virtual CreditCardProviderBase CreditCardProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current InventoryProviderBase instance.
		///</summary>
		public virtual InventoryProviderBase InventoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemProviderBase instance.
		///</summary>
		public virtual ItemProviderBase ItemProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LineItemProviderBase instance.
		///</summary>
		public virtual LineItemProviderBase LineItemProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrdersProviderBase instance.
		///</summary>
		public virtual OrdersProviderBase OrdersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderStatusProviderBase instance.
		///</summary>
		public virtual OrderStatusProviderBase OrderStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderStatusTypeProviderBase instance.
		///</summary>
		public virtual OrderStatusTypeProviderBase OrderStatusTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductProviderBase instance.
		///</summary>
		public virtual ProductProviderBase ProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SupplierProviderBase instance.
		///</summary>
		public virtual SupplierProviderBase SupplierProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current ExtendedItemProviderBase instance.
		///</summary>
		public virtual ExtendedItemProviderBase ExtendedItemProvider{get {throw new NotImplementedException();}}
		
					
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(DbCommand commandWrapper);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(DbCommand commandWrapper);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(DbCommand commandWrapper);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(DbCommand commandWrapper);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion
		
		#endregion
	}
}
