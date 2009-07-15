#region Using Directives
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Threading;
using System.Web;

using PetShop.Business;
using PetShop.Data;
using PetShop.Data.Bases;

#endregion 

namespace PetShop.Services
{
	/// <summary>
	/// Connection Scope Interface
	/// </summary>
	public interface IConnectionScope
    {
        /// <summary>
        /// Gets or sets the connection string key.
        /// </summary>
        /// <value>The connection string key.</value>
        string ConnectionStringKey { get; set; }
        
        /// <summary>
        /// Gets or sets the data provider.
        /// </summary>
        /// <value>The data provider.</value>
        NetTiersProvider DataProvider { get; set; }
        
        /// <summary>
        /// Gets or sets the dynamic connection string.
        /// </summary>
        /// <value>The dynamic connection string.</value>
        string DynamicConnectionString { get; set; }
        
        /// <summary>
        /// Gets a value indicating whether this instance has transaction.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has transaction; otherwise, <c>false</c>.
        /// </value>
        bool HasTransaction { get; }
        
        /// <summary>
        /// Gets or sets the transaction manager.
        /// </summary>
        /// <value>The transaction manager.</value>
        TransactionManager TransactionManager { get; set; }
    }
}