
#region Using directives
using System;
using System.Data;
using System.Data.Common;

using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
#endregion Using directives

namespace PetShop.Data
{
	/// <summary>
	/// TransactionManager interface
	/// </summary>
    public interface ITransactionManager
    {
        /// <summary>
        /// Begins the transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="isolationLevel">The isolation level.</param>
        void BeginTransaction( IsolationLevel isolationLevel );

        /// <summary>
        /// Commits this instance.
        /// </summary>
        void Commit();

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>The database.</value>
        Database Database { get; }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        void Dispose();

        /// <summary>
        /// Gets or sets the name of the invariant provider.
        /// </summary>
        /// <value>The name of the invariant provider.</value>
        string InvariantProviderName { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is open.
        /// </summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        bool IsOpen { get; }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Gets the transaction object.
        /// </summary>
        /// <value>The transaction object.</value>
        DbTransaction TransactionObject { get; }
    }
}
