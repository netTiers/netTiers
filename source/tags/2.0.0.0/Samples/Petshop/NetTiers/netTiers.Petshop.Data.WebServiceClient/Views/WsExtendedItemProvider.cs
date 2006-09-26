
#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;
using netTiers.Petshop.Data;
using netTiers.Petshop.Entities;

#endregion

namespace netTiers.Petshop.Data.WebServiceClient
{
	///<summary>
	/// This class is the WebServiceClient Data Access Logic Component implementation for the <see cref="ExtendedItem"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class WsExtendedItemProvider
	{
	    /// <summary>
	    /// Gets All rows from the DataSource.
	    /// </summary>
	    /// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	    /// <param name="start">Row number at which to start reading.</param>
	    /// <param name="pageLength">Number of rows to return.</param>
	    /// <param name="count">The total number of rows in the data source.</param>
	    /// <remarks></remarks>
	    /// <returns>Returns a typed collection of Entity objects.</returns>
	    public override VList<ExtendedItem> GetAll(TransactionManager transactionManager, int start, int pageLength,
	                                               out int count)
	    {
	        throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Gets a page of rows from the DataSource.
	    /// </summary>
	    /// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	    /// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
	    /// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
	    /// <param name="start">Row number at which to start reading.</param>
	    /// <param name="pageLength">Number of rows to return.</param>
	    /// <param name="count">The total number of rows in the data source.</param>
	    /// <remarks></remarks>
	    /// <returns>Returns a typed collection of Entity objects.</returns>
	    public override VList<ExtendedItem> Get(TransactionManager transactionManager, string whereClause, string orderBy,
	                                            int start, int pageLength, out int count)
	    {
	        throw new NotImplementedException();
	    }
	}
}