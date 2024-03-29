﻿
/*
	File Generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file SqlItemProvider.cs instead.
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
using PetShop.Business;
using PetShop.Data;
using PetShop.Data.Bases;

#endregion

namespace PetShop.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="Item"/> entity.
	///</summary>
	public abstract partial class SqlItemProviderBase : ItemProviderBase
	{
		#region Declarations

		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;

		#endregion "Declarations"

		#region Constructors

		/// <summary>
		/// Creates a new <see cref="SqlItemProviderBase"/> instance.
		/// </summary>
		public SqlItemProviderBase()
		{
		}

	/// <summary>
	/// Creates a new <see cref="SqlItemProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we should use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlItemProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
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
		/// <param name="_itemId">. Primary Key.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, string _itemId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@ItemId", DbType.AnsiString, _itemId);

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
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(Item)
					,_itemId);
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
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public override TList<Item> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new TList<Item>();

			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;

		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);

		database.AddInParameter(commandWrapper, "@ItemId", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ProductId", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ListPrice", DbType.Decimal, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UnitCost", DbType.Decimal, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Supplier", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Status", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Image", DbType.AnsiString, DBNull.Value);

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
				if (clause.Trim().StartsWith("itemid ") || clause.Trim().StartsWith("itemid="))
				{
					database.SetParameterValue(commandWrapper, "@ItemId",
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("productid ") || clause.Trim().StartsWith("productid="))
				{
					database.SetParameterValue(commandWrapper, "@ProductId",
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("listprice ") || clause.Trim().StartsWith("listprice="))
				{
					database.SetParameterValue(commandWrapper, "@ListPrice",
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("unitcost ") || clause.Trim().StartsWith("unitcost="))
				{
					database.SetParameterValue(commandWrapper, "@UnitCost",
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("supplier ") || clause.Trim().StartsWith("supplier="))
				{
					database.SetParameterValue(commandWrapper, "@Supplier",
						clause.Trim().Remove(0,8).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("status ") || clause.Trim().StartsWith("status="))
				{
					database.SetParameterValue(commandWrapper, "@Status",
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("name ") || clause.Trim().StartsWith("name="))
				{
					database.SetParameterValue(commandWrapper, "@Name",
						clause.Trim().Remove(0,4).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("image ") || clause.Trim().StartsWith("image="))
				{
					database.SetParameterValue(commandWrapper, "@Image",
						clause.Trim().Remove(0,5).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}

				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}

			IDataReader reader = null;
			//Create Collection
			TList<Item> rows = new TList<Item>();


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
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public override TList<Item> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlFilterParameterCollection filter = null;

			if (parameters == null)
				filter = new SqlFilterParameterCollection();
			else
				filter = parameters.GetParameters();

			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_Find_Dynamic", typeof(ItemColumn), filter, orderBy, start, pageLength);

			SqlFilterParameter param;

			for ( int i = 0; i < filter.Count; i++ )
			{
				param = filter[i];
				database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
			}

			TList<Item> rows = new TList<Item>();
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
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<Item> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_Get_List", _useStoredProcedure);

			IDataReader reader = null;

			//Create Collection
			TList<Item> rows = new TList<Item>();

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
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
		public override TList<Item> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_GetPaged", _useStoredProcedure);


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
			TList<Item> rows = new TList<Item>();

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

		#region GetByProductId
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__ProductId__117F9D94 key.
		///		FK__Item__ProductId__117F9D94 Description:
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<Item> GetByProductId(TransactionManager transactionManager, string _productId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_GetByProductId", _useStoredProcedure);

				database.AddInParameter(commandWrapper, "@ProductId", DbType.AnsiString, _productId);

			IDataReader reader = null;
			TList<Item> rows = new TList<Item>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByProductId", rows));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				//Create Collection
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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByProductId", rows));
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


		#region GetBySupplier
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Item__Supplier__1273C1CD key.
		///		FK__Item__Supplier__1273C1CD Description:
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplier"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of PetShop.Business.Item objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<Item> GetBySupplier(TransactionManager transactionManager, System.Int32? _supplier, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_GetBySupplier", _useStoredProcedure);

				database.AddInParameter(commandWrapper, "@Supplier", DbType.Int32, _supplier);

			IDataReader reader = null;
			TList<Item> rows = new TList<Item>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetBySupplier", rows));

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}

				//Create Collection
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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetBySupplier", rows));
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

	#endregion

		#region Get By Index Functions

		#region GetByProductIdItemIdListPriceName

		/// <summary>
		/// 	Gets rows from the datasource based on the IxItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="_itemId"></param>
		/// <param name="_listPrice"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Item&gt;"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<Item> GetByProductIdItemIdListPriceName(TransactionManager transactionManager, string _productId, string _itemId, System.Decimal? _listPrice, string _name, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_GetByProductIdItemIdListPriceName", _useStoredProcedure);

				database.AddInParameter(commandWrapper, "@ProductId", DbType.AnsiString, _productId);
				database.AddInParameter(commandWrapper, "@ItemId", DbType.AnsiString, _itemId);
				database.AddInParameter(commandWrapper, "@ListPrice", DbType.Decimal, _listPrice);
				database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, _name);

			IDataReader reader = null;
			TList<Item> tmp = new TList<Item>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByProductIdItemIdListPriceName", tmp));

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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByProductIdItemIdListPriceName", tmp));
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


		#region GetByItemId

		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Item__727E838B0F975522 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Item"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override PetShop.Business.Item GetByItemId(TransactionManager transactionManager, string _itemId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_GetByItemId", _useStoredProcedure);

				database.AddInParameter(commandWrapper, "@ItemId", DbType.AnsiString, _itemId);

			IDataReader reader = null;
			TList<Item> tmp = new TList<Item>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByItemId", tmp));

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
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByItemId", tmp));
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
		///		After inserting into the datasource, the PetShop.Business.Item object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, TList<PetShop.Business.Item> entities)
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
			bulkCopy.DestinationTableName = "Item";

			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("ItemId", typeof(string));
			col0.AllowDBNull = false;
			DataColumn col1 = dataTable.Columns.Add("ProductId", typeof(string));
			col1.AllowDBNull = false;
			DataColumn col2 = dataTable.Columns.Add("ListPrice", typeof(System.Decimal?));
			col2.AllowDBNull = true;
			DataColumn col3 = dataTable.Columns.Add("UnitCost", typeof(System.Decimal?));
			col3.AllowDBNull = true;
			DataColumn col4 = dataTable.Columns.Add("Supplier", typeof(System.Int32?));
			col4.AllowDBNull = true;
			DataColumn col5 = dataTable.Columns.Add("Status", typeof(string));
			col5.AllowDBNull = true;
			DataColumn col6 = dataTable.Columns.Add("Name", typeof(string));
			col6.AllowDBNull = true;
			DataColumn col7 = dataTable.Columns.Add("Image", typeof(string));
			col7.AllowDBNull = true;

			bulkCopy.ColumnMappings.Add("ItemId", "ItemId");
			bulkCopy.ColumnMappings.Add("ProductId", "ProductId");
			bulkCopy.ColumnMappings.Add("ListPrice", "ListPrice");
			bulkCopy.ColumnMappings.Add("UnitCost", "UnitCost");
			bulkCopy.ColumnMappings.Add("Supplier", "Supplier");
			bulkCopy.ColumnMappings.Add("Status", "Status");
			bulkCopy.ColumnMappings.Add("Name", "Name");
			bulkCopy.ColumnMappings.Add("Image", "Image");

			foreach(PetShop.Business.Item entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;

				DataRow row = dataTable.NewRow();

					row["ItemId"] = entity.ItemId;


					row["ProductId"] = entity.ProductId;


					row["ListPrice"] = entity.ListPrice.HasValue ? (object) entity.ListPrice  : System.DBNull.Value;


					row["UnitCost"] = entity.UnitCost.HasValue ? (object) entity.UnitCost  : System.DBNull.Value;


					row["Supplier"] = entity.Supplier.HasValue ? (object) entity.Supplier  : System.DBNull.Value;


					row["Status"] = entity.Status;


					row["Name"] = entity.Name;


					row["Image"] = entity.Image;


				dataTable.Rows.Add(row);
			}

			// send the data to the server
			bulkCopy.WriteToServer(dataTable);

			// update back the state
			foreach(PetShop.Business.Item entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;

				entity.AcceptChanges();
			}
		}

		/// <summary>
		/// 	Inserts a PetShop.Business.Item object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">PetShop.Business.Item object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the PetShop.Business.Item object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, PetShop.Business.Item entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_Insert", _useStoredProcedure);

			database.AddInParameter(commandWrapper, "@ItemId", DbType.AnsiString, entity.ItemId );
			database.AddInParameter(commandWrapper, "@ProductId", DbType.AnsiString, entity.ProductId );
			database.AddInParameter(commandWrapper, "@ListPrice", DbType.Decimal, (entity.ListPrice.HasValue ? (object) entity.ListPrice  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@UnitCost", DbType.Decimal, (entity.UnitCost.HasValue ? (object) entity.UnitCost  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@Supplier", DbType.Int32, (entity.Supplier.HasValue ? (object) entity.Supplier  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@Status", DbType.AnsiString, entity.Status );
			database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, entity.Name );
			database.AddInParameter(commandWrapper, "@Image", DbType.AnsiString, entity.Image );

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


			entity.OriginalItemId = entity.ItemId;

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
		/// <param name="entity">PetShop.Business.Item object to update.</param>
		/// <remarks>
		///		After updating the datasource, the PetShop.Business.Item object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, PetShop.Business.Item entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Item_Update", _useStoredProcedure);

			database.AddInParameter(commandWrapper, "@ItemId", DbType.AnsiString, entity.ItemId );
			database.AddInParameter(commandWrapper, "@OriginalItemId", DbType.AnsiString, entity.OriginalItemId);
			database.AddInParameter(commandWrapper, "@ProductId", DbType.AnsiString, entity.ProductId );
			database.AddInParameter(commandWrapper, "@ListPrice", DbType.Decimal, (entity.ListPrice.HasValue ? (object) entity.ListPrice : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@UnitCost", DbType.Decimal, (entity.UnitCost.HasValue ? (object) entity.UnitCost : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@Supplier", DbType.Int32, (entity.Supplier.HasValue ? (object) entity.Supplier : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@Status", DbType.AnsiString, entity.Status );
			database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, entity.Name );
			database.AddInParameter(commandWrapper, "@Image", DbType.AnsiString, entity.Image );

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

			entity.OriginalItemId = entity.ItemId;

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
