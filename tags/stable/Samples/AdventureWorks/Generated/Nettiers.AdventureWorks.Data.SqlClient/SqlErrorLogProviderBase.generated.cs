﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file SqlErrorLogProvider.cs instead.
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
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="ErrorLog"/> entity.
	///</summary>
	public abstract partial class SqlErrorLogProviderBase : ErrorLogProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlErrorLogProviderBase"/> instance.
		/// </summary>
		public SqlErrorLogProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlErrorLogProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we should use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlErrorLogProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
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
		#endregion
	
		#region Delete Functions
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_errorLogId">Primary key for ErrorLog records.. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 _errorLogId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.usp_adwTiers_ErrorLog_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@ErrorLogId", DbType.Int32, _errorLogId);
			
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
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(ErrorLog)
					,_errorLogId);
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
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ErrorLog objects.</returns>
		public override TList<ErrorLog> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new TList<ErrorLog>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.usp_adwTiers_ErrorLog_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@ErrorLogId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ErrorTime", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UserName", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ErrorNumber", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ErrorSeverity", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ErrorState", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ErrorProcedure", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ErrorLine", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ErrorMessage", DbType.String, DBNull.Value);
	
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
				if (clause.Trim().StartsWith("errorlogid ") || clause.Trim().StartsWith("errorlogid="))
				{
					database.SetParameterValue(commandWrapper, "@ErrorLogId", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("errortime ") || clause.Trim().StartsWith("errortime="))
				{
					database.SetParameterValue(commandWrapper, "@ErrorTime", 
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("username ") || clause.Trim().StartsWith("username="))
				{
					database.SetParameterValue(commandWrapper, "@UserName", 
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("errornumber ") || clause.Trim().StartsWith("errornumber="))
				{
					database.SetParameterValue(commandWrapper, "@ErrorNumber", 
						clause.Trim().Remove(0,11).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("errorseverity ") || clause.Trim().StartsWith("errorseverity="))
				{
					database.SetParameterValue(commandWrapper, "@ErrorSeverity", 
						clause.Trim().Remove(0,13).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("errorstate ") || clause.Trim().StartsWith("errorstate="))
				{
					database.SetParameterValue(commandWrapper, "@ErrorState", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("errorprocedure ") || clause.Trim().StartsWith("errorprocedure="))
				{
					database.SetParameterValue(commandWrapper, "@ErrorProcedure", 
						clause.Trim().Remove(0,14).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("errorline ") || clause.Trim().StartsWith("errorline="))
				{
					database.SetParameterValue(commandWrapper, "@ErrorLine", 
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("errormessage ") || clause.Trim().StartsWith("errormessage="))
				{
					database.SetParameterValue(commandWrapper, "@ErrorMessage", 
						clause.Trim().Remove(0,12).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			TList<ErrorLog> rows = new TList<ErrorLog>();
	
				
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
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ErrorLog objects.</returns>
		public override TList<ErrorLog> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlFilterParameterCollection filter = null;
			
			if (parameters == null)
				filter = new SqlFilterParameterCollection();
			else 
				filter = parameters.GetParameters();
				
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.usp_adwTiers_ErrorLog_Find_Dynamic", typeof(ErrorLogColumn), filter, orderBy, start, pageLength);
		
			SqlFilterParameter param;

			for ( int i = 0; i < filter.Count; i++ )
			{
				param = filter[i];
				database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
			}

			TList<ErrorLog> rows = new TList<ErrorLog>();
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
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ErrorLog objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<ErrorLog> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.usp_adwTiers_ErrorLog_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			TList<ErrorLog> rows = new TList<ErrorLog>();
			
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
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ErrorLog objects.</returns>
		public override TList<ErrorLog> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.usp_adwTiers_ErrorLog_GetPaged", _useStoredProcedure);
		
			
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
			TList<ErrorLog> rows = new TList<ErrorLog>();
			
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

		#region GetByErrorLogId
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ErrorLog_ErrorLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_errorLogId">Primary key for ErrorLog records.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ErrorLog"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override Nettiers.AdventureWorks.Entities.ErrorLog GetByErrorLogId(TransactionManager transactionManager, System.Int32 _errorLogId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.usp_adwTiers_ErrorLog_GetByErrorLogId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@ErrorLogId", DbType.Int32, _errorLogId);
			
			IDataReader reader = null;
			TList<ErrorLog> tmp = new TList<ErrorLog>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByErrorLogId", tmp)); 

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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByErrorLogId", tmp));
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

	#endregion Get By Index Functions

		#region Insert Methods
		/// <summary>
		/// Lets you efficiently bulk insert many entities to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the Nettiers.AdventureWorks.Entities.ErrorLog object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<Nettiers.AdventureWorks.Entities.ErrorLog> entities)
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
			bulkCopy.DestinationTableName = "ErrorLog";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("ErrorLogID", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("ErrorTime", typeof(System.DateTime));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("UserName", typeof(System.String));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("ErrorNumber", typeof(System.Int32));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("ErrorSeverity", typeof(System.Int32));
			col4.AllowDBNull = true;		
			DataColumn col5 = dataTable.Columns.Add("ErrorState", typeof(System.Int32));
			col5.AllowDBNull = true;		
			DataColumn col6 = dataTable.Columns.Add("ErrorProcedure", typeof(System.String));
			col6.AllowDBNull = true;		
			DataColumn col7 = dataTable.Columns.Add("ErrorLine", typeof(System.Int32));
			col7.AllowDBNull = true;		
			DataColumn col8 = dataTable.Columns.Add("ErrorMessage", typeof(System.String));
			col8.AllowDBNull = false;		
			
			bulkCopy.ColumnMappings.Add("ErrorLogID", "ErrorLogID");
			bulkCopy.ColumnMappings.Add("ErrorTime", "ErrorTime");
			bulkCopy.ColumnMappings.Add("UserName", "UserName");
			bulkCopy.ColumnMappings.Add("ErrorNumber", "ErrorNumber");
			bulkCopy.ColumnMappings.Add("ErrorSeverity", "ErrorSeverity");
			bulkCopy.ColumnMappings.Add("ErrorState", "ErrorState");
			bulkCopy.ColumnMappings.Add("ErrorProcedure", "ErrorProcedure");
			bulkCopy.ColumnMappings.Add("ErrorLine", "ErrorLine");
			bulkCopy.ColumnMappings.Add("ErrorMessage", "ErrorMessage");
			
			foreach(Nettiers.AdventureWorks.Entities.ErrorLog entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["ErrorLogID"] = entity.ErrorLogId;
							
				
					row["ErrorTime"] = entity.ErrorTime;
							
				
					row["UserName"] = entity.UserName;
							
				
					row["ErrorNumber"] = entity.ErrorNumber;
							
				
					row["ErrorSeverity"] = entity.ErrorSeverity.HasValue ? (object) entity.ErrorSeverity  : System.DBNull.Value;
							
				
					row["ErrorState"] = entity.ErrorState.HasValue ? (object) entity.ErrorState  : System.DBNull.Value;
							
				
					row["ErrorProcedure"] = entity.ErrorProcedure;
							
				
					row["ErrorLine"] = entity.ErrorLine.HasValue ? (object) entity.ErrorLine  : System.DBNull.Value;
							
				
					row["ErrorMessage"] = entity.ErrorMessage;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(Nettiers.AdventureWorks.Entities.ErrorLog entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a Nettiers.AdventureWorks.Entities.ErrorLog object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ErrorLog object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the Nettiers.AdventureWorks.Entities.ErrorLog object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ErrorLog entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.usp_adwTiers_ErrorLog_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@ErrorLogId", DbType.Int32, 4);
			database.AddInParameter(commandWrapper, "@ErrorTime", DbType.DateTime, entity.ErrorTime );
			database.AddInParameter(commandWrapper, "@UserName", DbType.String, entity.UserName );
			database.AddInParameter(commandWrapper, "@ErrorNumber", DbType.Int32, entity.ErrorNumber );
			database.AddInParameter(commandWrapper, "@ErrorSeverity", DbType.Int32, (entity.ErrorSeverity.HasValue ? (object) entity.ErrorSeverity  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@ErrorState", DbType.Int32, (entity.ErrorState.HasValue ? (object) entity.ErrorState  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@ErrorProcedure", DbType.String, entity.ErrorProcedure );
			database.AddInParameter(commandWrapper, "@ErrorLine", DbType.Int32, (entity.ErrorLine.HasValue ? (object) entity.ErrorLine  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@ErrorMessage", DbType.String, entity.ErrorMessage );
			
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
					
			object _errorLogId = database.GetParameterValue(commandWrapper, "@ErrorLogId");
			entity.ErrorLogId = (System.Int32)_errorLogId;
			
			
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
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ErrorLog object to update.</param>
		/// <remarks>
		///		After updating the datasource, the Nettiers.AdventureWorks.Entities.ErrorLog object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ErrorLog entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.usp_adwTiers_ErrorLog_Update", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@ErrorLogId", DbType.Int32, entity.ErrorLogId );
			database.AddInParameter(commandWrapper, "@ErrorTime", DbType.DateTime, entity.ErrorTime );
			database.AddInParameter(commandWrapper, "@UserName", DbType.String, entity.UserName );
			database.AddInParameter(commandWrapper, "@ErrorNumber", DbType.Int32, entity.ErrorNumber );
			database.AddInParameter(commandWrapper, "@ErrorSeverity", DbType.Int32, (entity.ErrorSeverity.HasValue ? (object) entity.ErrorSeverity : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@ErrorState", DbType.Int32, (entity.ErrorState.HasValue ? (object) entity.ErrorState : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@ErrorProcedure", DbType.String, entity.ErrorProcedure );
			database.AddInParameter(commandWrapper, "@ErrorLine", DbType.Int32, (entity.ErrorLine.HasValue ? (object) entity.ErrorLine : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@ErrorMessage", DbType.String, entity.ErrorMessage );
			
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