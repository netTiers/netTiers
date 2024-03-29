﻿
/*
	File Generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file SqlStoreProvider.cs instead.
*/

#region using directives

using System;
using System.Data;
using System.Data.Common;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Specialized;

using System.Diagnostics;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="Store"/> entity.
	///</summary>
	public abstract partial class SqlStoreProviderBase : StoreProviderBase
	{
		#region Declarations

		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;

		#endregion "Declarations"

		#region Constructors

		/// <summary>
		/// Creates a new <see cref="SqlStoreProviderBase"/> instance.
		/// </summary>
		public SqlStoreProviderBase()
		{
		}

	/// <summary>
	/// Creates a new <see cref="SqlStoreProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we should use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlStoreProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}

	#endregion "Constructors"

		#region Public properties
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
    /// Gets or sets a value indicating whether to use stored procedures.
    /// </summary>
    /// <value><c>true</c> if we choose to use use stored procedures; otherwise, <c>false</c>.</value>
	public bool UseStoredProcedure
	{
		get {return this._useStoredProcedure;}
		set {this._useStoredProcedure = value;}
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
	#endregion

		#region Get Many To Many Relationship Functions

		#region GetByContactIdFromStoreContact
		/// <summary>
		///		Gets Store objects from the datasource by ContactID in the
		///		StoreContact table. Table Store is related to table Contact
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Contact (store employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns a <c>TList</c> of Store objects.</returns>
		public override TList<Store> GetByContactIdFromStoreContact(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_GetByContactIdFromStoreContact", _useStoredProcedure);

			database.AddInParameter(commandWrapper, "@ContactId", DbType.Int32, _contactId);

			IDataReader reader = null;
			// Create collection and fill
			TList<Store> rows = new TList<Store>();

			try
			{
				// Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByContactIdFromStoreContact", rows));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}

				// Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByContactIdFromStoreContact", rows));

			}
			finally
			{
				if (reader != null)
					reader.Close();

				commandWrapper = null;
			}
			return rows;
		}

		#endregion GetByContactIdFromStoreContact

		#endregion

		#region Delete Functions
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.. Primary Key.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 _customerId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@CustomerId", DbType.Int32, _customerId);

			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Delete"));

			int results = 0;

			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}

			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
			{
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(Store)
					,_customerId);
				EntityManager.StopTracking(entityKey);
			}

			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Delete"));

			commandWrapper = null;

			return Convert.ToBoolean(results);
		}//end Delete
		#endregion

		#region Find Functions

		#region Parsed Find Methods
		/// <summary>
		/// 	Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks>Operators must be capitalized (OR, AND).</remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Store objects.</returns>
		public override TList<Store> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new TList<Store>();

			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;

		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);

		database.AddInParameter(commandWrapper, "@CustomerId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Name", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@SalesPersonId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Demographics", DbType.Xml, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Rowguid", DbType.Guid, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ModifiedDate", DbType.DateTime, DBNull.Value);

			// replace all instances of 'AND' and 'OR' because we already set searchUsingOR
			whereClause = whereClause.Replace(" AND ", "|").Replace(" OR ", "|") ;
			string[] clauses = whereClause.ToLower().Split('|');

			// Here's what's going on below: Find a field, then to get the value we
			// drop the field name from the front, trim spaces, drop the '=' sign,
			// trim more spaces, and drop any outer single quotes.
			// Now handles the case when two fields start off the same way - like "Friendly='Yes' AND Friend='john'"

			char[] equalSign = {'='};
			char[] singleQuote = {'\''};
	   		foreach (string clause in clauses)
			{
				if (clause.Trim().StartsWith("customerid ") || clause.Trim().StartsWith("customerid="))
				{
					database.SetParameterValue(commandWrapper, "@CustomerId",
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("name ") || clause.Trim().StartsWith("name="))
				{
					database.SetParameterValue(commandWrapper, "@Name",
						clause.Trim().Remove(0,4).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("salespersonid ") || clause.Trim().StartsWith("salespersonid="))
				{
					database.SetParameterValue(commandWrapper, "@SalesPersonId",
						clause.Trim().Remove(0,13).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("demographics ") || clause.Trim().StartsWith("demographics="))
				{
					database.SetParameterValue(commandWrapper, "@Demographics",
						clause.Trim().Remove(0,12).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("rowguid ") || clause.Trim().StartsWith("rowguid="))
				{
					database.SetParameterValue(commandWrapper, "@Rowguid", new Guid(
						clause.Trim().Remove(0,7).Trim().TrimStart(equalSign).Trim().Trim(singleQuote)));
					continue;
				}
				if (clause.Trim().StartsWith("modifieddate ") || clause.Trim().StartsWith("modifieddate="))
				{
					database.SetParameterValue(commandWrapper, "@ModifiedDate",
						clause.Trim().Remove(0,12).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}

				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}

			IDataReader reader = null;
			//Create Collection
			TList<Store> rows = new TList<Store>();


			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "Find", rows));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				Fill(reader, rows, start, pageLength);

				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}

				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "Find", rows));
			}
			finally
			{
				if (reader != null)
					reader.Close();

				commandWrapper = null;
			}
			return rows;
		}

		#endregion Parsed Find Methods

		#region Parameterized Find Methods

		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Store objects.</returns>
		public override TList<Store> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlFilterParameterCollection filter = null;

			if (parameters == null)
				filter = new SqlFilterParameterCollection();
			else
				filter = parameters.GetParameters();

			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_Find_Dynamic", typeof(StoreColumn), filter, orderBy, start, pageLength);

			SqlFilterParameter param;

			for ( int i = 0; i < filter.Count; i++ )
			{
				param = filter[i];
				database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
			}

			TList<Store> rows = new TList<Store>();
			IDataReader reader = null;

			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "Find", rows));

				if ( transactionManager != null )
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;

				if ( reader.NextResult() )
				{
					if ( reader.Read() )
					{
						count = reader.GetInt32(0);
					}
				}

				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "Find", rows));
			}
			finally
			{
				if ( reader != null )
					reader.Close();

				commandWrapper = null;
			}

			return rows;
		}

		#endregion Parameterized Find Methods

		#endregion Find Functions

		#region GetAll Methods

		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Store objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<Store> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_Get_List", _useStoredProcedure);

			IDataReader reader = null;

			//Create Collection
			TList<Store> rows = new TList<Store>();

			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetAll", rows));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}

				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetAll", rows));
			}
			finally
			{
				if (reader != null)
					reader.Close();

				commandWrapper = null;
			}
			return rows;
		}//end getall

		#endregion

		#region GetPaged Methods

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Store objects.</returns>
		public override TList<Store> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_GetPaged", _useStoredProcedure);


            if (commandWrapper.CommandType == CommandType.Text
                && commandWrapper.CommandText != null)
            {
                commandWrapper.CommandText = commandWrapper.CommandText.Replace(SqlUtil.PAGE_INDEX, string.Concat(SqlUtil.PAGE_INDEX, Guid.NewGuid().ToString("N").Substring(0, 8)));
            }

			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);

			IDataReader reader = null;
			//Create Collection
			TList<Store> rows = new TList<Store>();

			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetPaged", rows));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;

				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}

				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetPaged", rows));

			}
			catch(Exception)
			{
				throw;
			}
			finally
			{
				if (reader != null)
					reader.Close();

				commandWrapper = null;
			}

			return rows;
		}

		#endregion

		#region Get By Foreign Key Functions
	#endregion

		#region Get By Index Functions

		#region GetByRowguid

		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Store_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override Nettiers.AdventureWorks.Entities.Store GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_GetByRowguid", _useStoredProcedure);

				database.AddInParameter(commandWrapper, "@Rowguid", DbType.Guid, _rowguid);

			IDataReader reader = null;
			TList<Store> tmp = new TList<Store>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByRowguid", tmp));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}

				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByRowguid", tmp));
			}
			finally
			{
				if (reader != null)
					reader.Close();

				commandWrapper = null;
			}

			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}

			//return rows;
		}

		#endregion


		#region GetBySalesPersonId

		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Store_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">ID of the sales person assigned to the customer. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<Store> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_GetBySalesPersonId", _useStoredProcedure);

				database.AddInParameter(commandWrapper, "@SalesPersonId", DbType.Int32, _salesPersonId);

			IDataReader reader = null;
			TList<Store> tmp = new TList<Store>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetBySalesPersonId", tmp));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}

				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetBySalesPersonId", tmp));
			}
			finally
			{
				if (reader != null)
					reader.Close();

				commandWrapper = null;
			}

			return tmp;

			//return rows;
		}

		#endregion


		#region GetByCustomerId

		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Store_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override Nettiers.AdventureWorks.Entities.Store GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_GetByCustomerId", _useStoredProcedure);

				database.AddInParameter(commandWrapper, "@CustomerId", DbType.Int32, _customerId);

			IDataReader reader = null;
			TList<Store> tmp = new TList<Store>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByCustomerId", tmp));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}

				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByCustomerId", tmp));
			}
			finally
			{
				if (reader != null)
					reader.Close();

				commandWrapper = null;
			}

			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}

			//return rows;
		}

		#endregion


		#region GetByDemographics

		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Store_Demographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_demographics">Demographic informationg about the store such as the number of employees, annual sales and store type.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<Store> GetByDemographics(TransactionManager transactionManager, string _demographics, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_GetByDemographics", _useStoredProcedure);

				database.AddInParameter(commandWrapper, "@Demographics", DbType.Xml, _demographics);

			IDataReader reader = null;
			TList<Store> tmp = new TList<Store>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByDemographics", tmp));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}

				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByDemographics", tmp));
			}
			finally
			{
				if (reader != null)
					reader.Close();

				commandWrapper = null;
			}

			return tmp;

			//return rows;
		}

		#endregion

	#endregion Get By Index Functions

		#region Insert Methods
		/// <summary>
		/// Lets you efficiently bulk insert many entities to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the Nettiers.AdventureWorks.Entities.Store object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, TList<Nettiers.AdventureWorks.Entities.Store> entities)
		{
			//System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);

			System.Data.SqlClient.SqlBulkCopy bulkCopy = null;

			if (transactionManager != null && transactionManager.IsOpen)
			{
				System.Data.SqlClient.SqlConnection cnx = transactionManager.TransactionObject.Connection as System.Data.SqlClient.SqlConnection;
				System.Data.SqlClient.SqlTransaction transaction = transactionManager.TransactionObject as System.Data.SqlClient.SqlTransaction;
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(cnx, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints, transaction); //, null);
			}
			else
			{
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			}

			bulkCopy.BulkCopyTimeout = 360;
			bulkCopy.DestinationTableName = "Store";

			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("CustomerID", typeof(System.Int32));
			col0.AllowDBNull = false;
			DataColumn col1 = dataTable.Columns.Add("Name", typeof(System.String));
			col1.AllowDBNull = false;
			DataColumn col2 = dataTable.Columns.Add("SalesPersonID", typeof(System.Int32));
			col2.AllowDBNull = true;
			DataColumn col3 = dataTable.Columns.Add("Demographics", typeof(string));
			col3.AllowDBNull = true;
			DataColumn col4 = dataTable.Columns.Add("rowguid", typeof(System.Guid));
			col4.AllowDBNull = false;
			DataColumn col5 = dataTable.Columns.Add("ModifiedDate", typeof(System.DateTime));
			col5.AllowDBNull = false;

			bulkCopy.ColumnMappings.Add("CustomerID", "CustomerID");
			bulkCopy.ColumnMappings.Add("Name", "Name");
			bulkCopy.ColumnMappings.Add("SalesPersonID", "SalesPersonID");
			bulkCopy.ColumnMappings.Add("Demographics", "Demographics");
			bulkCopy.ColumnMappings.Add("rowguid", "rowguid");
			bulkCopy.ColumnMappings.Add("ModifiedDate", "ModifiedDate");

			foreach(Nettiers.AdventureWorks.Entities.Store entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;

				DataRow row = dataTable.NewRow();

					row["CustomerID"] = entity.CustomerId;


					row["Name"] = entity.Name;


					row["SalesPersonID"] = entity.SalesPersonId.HasValue ? (object) entity.SalesPersonId  : System.DBNull.Value;


					row["Demographics"] = entity.Demographics;


					row["rowguid"] = entity.Rowguid;


					row["ModifiedDate"] = entity.ModifiedDate;


				dataTable.Rows.Add(row);
			}

			// send the data to the server
			bulkCopy.WriteToServer(dataTable);

			// update back the state
			foreach(Nettiers.AdventureWorks.Entities.Store entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;

				entity.AcceptChanges();
			}
		}

		/// <summary>
		/// 	Inserts a Nettiers.AdventureWorks.Entities.Store object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Store object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the Nettiers.AdventureWorks.Entities.Store object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Store entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_Insert", _useStoredProcedure);

			database.AddInParameter(commandWrapper, "@CustomerId", DbType.Int32, entity.CustomerId );
			database.AddInParameter(commandWrapper, "@Name", DbType.String, entity.Name );
			database.AddInParameter(commandWrapper, "@SalesPersonId", DbType.Int32, (entity.SalesPersonId.HasValue ? (object) entity.SalesPersonId  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@Demographics", DbType.Xml, entity.Demographics );
			database.AddOutParameter(commandWrapper, "@Rowguid", DbType.Guid, 16);
			database.AddInParameter(commandWrapper, "@ModifiedDate", DbType.DateTime, entity.ModifiedDate );

			int results = 0;

			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Insert", entity));

			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}

			object _rowguid = database.GetParameterValue(commandWrapper, "@Rowguid");
			entity.Rowguid = (System.Guid)_rowguid;

			entity.OriginalCustomerId = entity.CustomerId;

			entity.AcceptChanges();

			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Insert", entity));

			return Convert.ToBoolean(results);
		}
		#endregion

		#region Update Methods

		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Store object to update.</param>
		/// <remarks>
		///		After updating the datasource, the Nettiers.AdventureWorks.Entities.Store object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Store entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "Sales.usp_adwTiers_Store_Update", _useStoredProcedure);

			database.AddInParameter(commandWrapper, "@CustomerId", DbType.Int32, entity.CustomerId );
			database.AddInParameter(commandWrapper, "@OriginalCustomerId", DbType.Int32, entity.OriginalCustomerId);
			database.AddInParameter(commandWrapper, "@Name", DbType.String, entity.Name );
			database.AddInParameter(commandWrapper, "@SalesPersonId", DbType.Int32, (entity.SalesPersonId.HasValue ? (object) entity.SalesPersonId : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@Demographics", DbType.Xml, entity.Demographics );
			database.AddInParameter(commandWrapper, "@Rowguid", DbType.Guid, entity.Rowguid );
			database.AddInParameter(commandWrapper, "@ModifiedDate", DbType.DateTime, entity.ModifiedDate );

			int results = 0;

			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Update", entity));

			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}

			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
				EntityManager.StopTracking(entity.EntityTrackingKey);

			entity.OriginalCustomerId = entity.CustomerId;

			entity.AcceptChanges();

			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Update", entity));

			return Convert.ToBoolean(results);
		}

		#endregion

		#region Custom Methods

		#endregion
	}//end class
} // end namespace
