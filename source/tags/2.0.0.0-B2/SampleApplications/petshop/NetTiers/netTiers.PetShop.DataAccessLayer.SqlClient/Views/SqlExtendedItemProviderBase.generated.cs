
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : mercredi 15 mars 2006
	Important: Do not modify this file. Edit the file ExtendedItem.cs instead.
*/

#region "Using directives"

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer.Bases;

#endregion

namespace netTiers.PetShop.DataAccessLayer.SqlClient
{

/// <summary>
///	This class is the base repository for the CRUD operations on the ExtendedItem objects.
/// </summary>
public partial class SqlExtendedItemProviderBase : ExtendedItemProviderBase
{
	#region "Declarations"	
	
	string _connectionString;
    bool _useStoredProcedure;
    string _providerInvariantName;
    		
	#endregion "Declarations"
		
	#region "Constructors"
	
	/// <summary>
	/// Creates a new <see cref="SqlExtendedItemProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	protected SqlExtendedItemProviderBase()
	{		
	}
	
	/// <summary>
	/// Creates a new <see cref="SqlExtendedItemProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlExtendedItemProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
			
	#endregion "Constructors"
	
	#region Public properties
	
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
		
	#endregion
	
	#region "GetList Functions"
	
	/// <summary>
	/// 	Gets All rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
	public override VList<ExtendedItem> GetAll(TransactionManager transactionManager, int start, int pageLength)
	{
		SqlDatabase database = new SqlDatabase(this._connectionString);
		DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "ExtendedItem_Get_List", _useStoredProcedure);
		
		IDataReader reader = null;
		//Create Collection
		VList<ExtendedItem> rows = new VList<ExtendedItem>();
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
		finally {	if (reader != null) reader.Close();	}
		
		return rows;
	}//end getall
	
	#endregion
	
	#region "Get filterd and sorted"
			
	/// <summary>
	/// Gets a page of rows from the DataSource.
	/// </summary>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
	/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
	public override VList<ExtendedItem> Get(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength)
	{
		SqlDatabase database = new SqlDatabase(this._connectionString);
		DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "ExtendedItem_Get", _useStoredProcedure);

		//commandWrapper.AddInParameter("@PageIndex", DbType.Int32, start);
		//commandWrapper.AddInParameter("@PageSize", DbType.Int32, pageLength);
		database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
		database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
	
		IDataReader reader = null;
		//Create Collection
		VList<ExtendedItem> rows = new VList<ExtendedItem>();	
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


			//reader.Read();
			//count = reader.GetInt32(0);
			//reader.NextResult();
	
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
	

	#region "Custom Methods"
	

	#endregion
	
	}//end class
} // end namespace
