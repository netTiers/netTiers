#region Using Directives
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Threading;
using System.Web;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
#endregion 

namespace Nettiers.AdventureWorks.Services
{
	/// <summary>
	/// Provides storage of global database connection information.
	/// </summary>
	[CLSCompliant(true)]
	public class ConnectionScopeBase : IConnectionScope
    {
        #region Constructors
        /// <summary>
		/// Initializes a new instance of the ConnectionScope class.
		/// </summary>
		public ConnectionScopeBase()
		{
        }
        #endregion Constructors

		#region Properties
		/// <summary>
		/// The ConnectionStringKey member variable.
		/// </summary>
		private string connectionStringKey;

		/// <summary>
		/// Gets or sets the ConnectionStringKey property.
		/// </summary>
		public string ConnectionStringKey
		{
			get { return connectionStringKey; }
			set { connectionStringKey = value; }
		}

		/// <summary>
		/// The DynamicConnectionString member variable.
		/// </summary>
		private string dynamicConnectionString;

		/// <summary>
		/// Gets or sets the DynamicConnectionString property.
		/// </summary>
		public string DynamicConnectionString
		{
			get { return dynamicConnectionString; }
			set { dynamicConnectionString = value; }
		}

		/// <summary>
		/// The TransactionManager member variable.
		/// </summary>
		private TransactionManager transactionManager;

		/// <summary>
		/// Gets or sets the TransactionManager property.
		/// </summary>
		public TransactionManager TransactionManager
		{
			get { return transactionManager; }
			set { transactionManager = value; }
		}
		
		/// <summary>
		/// The NetTiersProvider member variable.
		/// </summary>
		private NetTiersProvider dataProvider;
		
		/// <summary>
		/// Gets or Sets the Current DataProvider property of the <c>ConnectionScope</c> Object.
		/// </summary>
		/// <remarks>
		/// To use a dynamic connection, you must set both the 
		/// DynamicConnectionString and a unique ConnectionStringKey properties;
		///</remarks>
		public NetTiersProvider DataProvider
		{
			get
			{
				if (dataProvider == null)
				{
					if (string.IsNullOrEmpty(connectionStringKey))
					{
						dataProvider = DataRepository.Provider;
					}
					else if (!DataRepository.Connections.ContainsKey(connectionStringKey) && dynamicConnectionString != null)
					{
						DataRepository.AddConnection(connectionStringKey, dynamicConnectionString);
						dataProvider = DataRepository.Connections[connectionStringKey].Provider;
					}
					else if (DataRepository.Connections.ContainsKey(connectionStringKey)) 
					{
						dataProvider =  DataRepository.Connections[connectionStringKey].Provider;
					}
				}
					
				return dataProvider;
			}
			set
			{
				if (value != null)
				{
					dataProvider = value;	
				}
			}
		}

		/// <summary>
		/// Determines if Current Connections is in a Transaction.
		/// </summary>
		public virtual bool HasTransaction 
		{
            get { throw new NotImplementedException( "Property is not implemented" ); }
		}
		#endregion Properties
	}

}