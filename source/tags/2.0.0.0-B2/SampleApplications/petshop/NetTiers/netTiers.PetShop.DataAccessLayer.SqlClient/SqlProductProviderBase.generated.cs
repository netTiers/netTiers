﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : mercredi 15 mars 2006
	Important: Do not modify this file. Edit the file SqlProductProvider.cs instead.
*/

#region using directives

using System;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Specialized;

using System.Diagnostics;
using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;
using netTiers.PetShop.DataAccessLayer.Bases;

#endregion

namespace netTiers.PetShop.DataAccessLayer.SqlClient
{
	public partial class SqlProductProviderBase : ProductProviderBase
	{
		#region "Declarations"	
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region "Constructors"
		
		/// <summary>
		/// Creates a new <see cref="SqlProductProviderBase"/> instance.
		/// </summary>
		public SqlProductProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlProductProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlProductProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
		
	#endregion "Constructors"
	
		#region "Public properties"
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
	
		#region "Get from  Many To Many Relationship Functions"
	#endregion
	
	
		#region "Delete Functions"
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="id">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, System.String id, byte[] timestamp)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Product_Delete", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, id);
			database.AddInParameter(commandWrapper, "@Timestamp", DbType.Binary, timestamp);
			
			int results = 0;
			
			if (transactionManager != null)
			{	
				if (!transactionManager.IsOpen) throw new DataException("Transaction must be open before executing a query.");
				results = database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);
			}
			else
			{
				results = database.ExecuteNonQuery(commandWrapper);
			}
			
			
			if (results == 0)
			{
				throw new DBConcurrencyException ("The record has been modified by an other user. Please reload the instance before deleting.");
			}
			
			return Convert.ToBoolean(results);
		}//end Delete
		#endregion

		#region "Find Functions"	
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public override netTiers.PetShop.TList<Product> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength)
		{
			if (whereClause.IndexOf(";") > -1)
				return new netTiers.PetShop.TList<Product>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Product_Find", _useStoredProcedure);
			
			whereClause = whereClause.Replace("AND", "|");
			Hashtable hparams = new Hashtable();
			if (whereClause.ToUpper().IndexOf("|") > -1)
			{
				string[] clauses = whereClause.Split('|');
				foreach (string clause in clauses)
				{
					string[] sparams = new string[2];
					if (clause.Trim().IndexOf('=') > 1)
						sparams = clause.Split('=');
	
					if (sparams[0] != null	&&
						sparams[1] != null && 
						!hparams.ContainsKey("@" + sparams[0].Trim()))
						hparams.Add("@" + sparams[0].Trim(), sparams[1].Trim().Replace("'", ""));
				}
			}
			else
			{
				string[] sparams = new string[2];	
				if (whereClause.Trim().IndexOf('=') > 1)
					sparams = whereClause.Split('=');
	
				if (sparams[0] != null	&&
					sparams[1] != null && 
					!hparams.ContainsKey("@" + sparams[0].Trim()))
					hparams.Add("@" + sparams[0].Trim(), sparams[1].Trim().Replace("'", ""));
			}
			
			if (hparams.Count == 0)
				return new netTiers.PetShop.TList<Product>();
					
			
			database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, DBNull.Value);
			database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, DBNull.Value);
			database.AddInParameter(commandWrapper, "@Description", DbType.AnsiString, DBNull.Value);
			database.AddInParameter(commandWrapper, "@CategoryId", DbType.AnsiStringFixedLength, DBNull.Value);
			database.AddInParameter(commandWrapper, "@Timestamp", DbType.Binary, DBNull.Value);
			
			foreach (string key in hparams.Keys)
			{
			database.SetParameterValue(commandWrapper, key.ToString(), hparams[key]);
			}
					
			IDataReader reader = null;
			//Create Collection
			netTiers.PetShop.TList<Product> rows = new netTiers.PetShop.TList<Product>();
	
				
			try
			{
				if (transactionManager != null)
				{
					if (!transactionManager.IsOpen) throw new DataException("Transaction must be open before executing a query.");
					reader = database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);
				}
				else
				{
					reader = database.ExecuteReader(commandWrapper);
				}		
				
				Fill(reader, rows, start, pageLength);
			}
			finally
			{
				if (reader != null) 
					reader.Close();				
			}
			return rows;
		}
		
		#endregion "Find Functions"
	
		#region "GetList Functions"
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public override netTiers.PetShop.TList<Product> GetAll(TransactionManager transactionManager, int start, int pageLength)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Product_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			netTiers.PetShop.TList<Product> rows = new netTiers.PetShop.TList<Product>();
			
			try
			{
				if (transactionManager != null)
				{
					if (!transactionManager.IsOpen) throw new DataException("Transaction must be open before executing a query.");
					reader = database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);
				}
				else
				{
					reader = database.ExecuteReader(commandWrapper);
				}		
		
				Fill(reader, rows, start, pageLength);
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			return rows;
		}//end getall
		
		#endregion
		
		#region Paged Recordset
				
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
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public override netTiers.PetShop.TList<Product> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Product_GetPaged", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
		
			IDataReader reader = null;
			
			if (transactionManager != null)
			{
				if (!transactionManager.IsOpen) throw new DataException("Transaction must be open before executing a query.");
				reader = database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);
			}
			else
			{
				reader = database.ExecuteReader(commandWrapper);
			}
			
			
			//Create Collection
			netTiers.PetShop.TList<Product> rows = new netTiers.PetShop.TList<Product>();
			
			try
			{
				if (reader.Read())
				{
					count = reader.GetInt32(0);
					if (reader.NextResult())
					{	
						Fill(reader, rows, 0, int.MaxValue);
					}
				}
				else
				{
					count = 0;
				}
			}
			catch(Exception)
			{			
				throw;
			}
			finally
			{
				if (reader != null) 
					reader.Close();
			}
			
			return rows;
		}
		
		#endregion	
		
		#region "Get By Foreign Key Functions"

		#region "GetByCategoryId"
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Product_Category key.
		///		FK_Product_Category Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.PetShop.Product objects.</returns>
		public override netTiers.PetShop.TList<Product> GetByCategoryId(TransactionManager transactionManager, System.String categoryId, int start, int pageLength)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Product_GetByCategoryId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@CategoryId", DbType.AnsiStringFixedLength, categoryId);
			
			IDataReader reader = null;
			netTiers.PetShop.TList<Product> rows = new netTiers.PetShop.TList<Product>();
			try
			{
				if (transactionManager != null)
				{
					if (!transactionManager.IsOpen) throw new DataException("Transaction must be open before executing a query.");
					reader = database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);
				}
				else
				{
					reader = database.ExecuteReader(commandWrapper);
				}
				
			
				//Create Collection
				Fill(reader, rows, start, pageLength);
			}
			finally
			{
				if (reader != null) 
					reader.Close();
			}
			return rows;
		}	
		#endregion
	
	#endregion
	

		#region "Get By Index Functions"

		#region "GetById"
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Product index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="id"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.PetShop.Product"/> class.</returns>
		public override netTiers.PetShop.Product GetById(TransactionManager transactionManager, System.String id, int start, int pageLength)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Product_GetById", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, id);
			
			IDataReader reader = null;
			netTiers.PetShop.TList<Product> tmp = new netTiers.PetShop.TList<Product>();
			try
			{
				if (transactionManager != null)
				{
					if (!transactionManager.IsOpen) throw new DataException("Transaction must be open before executing a query.");
					reader = database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);
				}
				else
				{
					reader = database.ExecuteReader(commandWrapper);
				}		
		
				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
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

	#endregion "Get By Index Functions"

		#region "Insert Functions"
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the netTiers.PetShop.Product object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<netTiers.PetShop.Product> entities)
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
			bulkCopy.DestinationTableName = "Product";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("Id", typeof(System.String));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("Name", typeof(System.String));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("Description", typeof(System.String));
			col2.AllowDBNull = true;		
			DataColumn col3 = dataTable.Columns.Add("CategoryId", typeof(System.String));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("Timestamp", typeof(System.Byte[]));
			col4.AllowDBNull = false;		
			
			bulkCopy.ColumnMappings.Add("Id", "Id");
			bulkCopy.ColumnMappings.Add("Name", "Name");
			bulkCopy.ColumnMappings.Add("Description", "Description");
			bulkCopy.ColumnMappings.Add("CategoryId", "CategoryId");
			bulkCopy.ColumnMappings.Add("Timestamp", "Timestamp");
			
			foreach(netTiers.PetShop.Product entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["Id"] = entity.Id;
							
				
					row["Name"] = entity.Name;
							
				
					row["Description"] = entity.Description;
							
				
					row["CategoryId"] = entity.CategoryId;
							
				
					row["Timestamp"] = entity.Timestamp;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(netTiers.PetShop.Product entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a netTiers.PetShop.Product object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">netTiers.PetShop.Product object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the netTiers.PetShop.Product object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Insert(TransactionManager transactionManager, netTiers.PetShop.Product entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Product_Insert", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, entity.Id );
			database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, entity.Name );
			database.AddInParameter(commandWrapper, "@Description", DbType.AnsiString, entity.Description );
			database.AddInParameter(commandWrapper, "@CategoryId", DbType.AnsiStringFixedLength, entity.CategoryId );
			database.AddOutParameter(commandWrapper, "@Timestamp", DbType.Binary, 8);
			
			int results = 0;
			
				
			if (transactionManager != null)
			{
				if (!transactionManager.IsOpen) throw new DataException("Transaction must be open before executing a query.");
				results = database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);
			}
			else
			{
				results = database.ExecuteNonQuery(commandWrapper);
			}
					
			entity.Timestamp = (System.Byte[])database.GetParameterValue(commandWrapper, "@Timestamp");
			entity.OriginalId = entity.Id;
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}	
		#endregion

		#region "Update Functions"
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">netTiers.PetShop.Product object to update.</param>
		/// <remarks>
		///		After updating the datasource, the netTiers.PetShop.Product object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Update(TransactionManager transactionManager, netTiers.PetShop.Product entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Product_Update", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, entity.Id );
			database.AddInParameter(commandWrapper, "@OriginalId", DbType.AnsiStringFixedLength, entity.OriginalId);
			database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, entity.Name );
			database.AddInParameter(commandWrapper, "@Description", DbType.AnsiString, entity.Description );
			database.AddInParameter(commandWrapper, "@CategoryId", DbType.AnsiStringFixedLength, entity.CategoryId );
			database.AddInParameter(commandWrapper, "@Timestamp", DbType.Binary, entity.Timestamp );
			database.AddOutParameter(commandWrapper, "@ReturnedTimestamp", DbType.Binary, 8);
			
			int results = 0;
			
			
			if (transactionManager != null)
			{
				if (!transactionManager.IsOpen) throw new DataException("Transaction must be open before executing a query.");
				results = database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);
			}
			else
			{
				results = database.ExecuteNonQuery(commandWrapper);
			}
			
			if (results == 0)
			{
				throw new DBConcurrencyException("Concurrency exception");
			}
		
			entity.Timestamp = (System.Byte[])database.GetParameterValue(commandWrapper, "@ReturnedTimestamp");
			entity.OriginalId = entity.Id;
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}
			
		#endregion
		
		#region "Custom Methods"
	

		#endregion
	
	}//end class
} // end namespace
