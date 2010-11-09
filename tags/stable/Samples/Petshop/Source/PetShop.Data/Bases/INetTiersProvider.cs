#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using PetShop.Business;

#endregion

namespace PetShop.Data.Bases
{	
	/// <summary>
	/// Interface for NetTiersProvider
	/// </summary>
	public interface INetTiersProvider
    {
        /// <summary>
        /// Creates the transaction.
        /// </summary>
        /// <returns></returns>
        TransactionManager CreateTransaction();

        /// <summary>
        /// Gets or sets the current load policy.
        /// </summary>
        /// <value>The current load policy.</value>
        LoadPolicy CurrentLoadPolicy { get; set; }

        /// <summary>
        /// Gets or sets the default command timeout.
        /// </summary>
        /// <value>The default command timeout.</value>
        int DefaultCommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable entity tracking].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enable entity tracking]; otherwise, <c>false</c>.
        /// </value>
        bool EnableEntityTracking { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable list tracking].
        /// </summary>
        /// <value><c>true</c> if [enable list tracking]; otherwise, <c>false</c>.</value>
        bool EnableListTracking { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable method authorization].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enable method authorization]; otherwise, <c>false</c>.
        /// </value>
        bool EnableMethodAuthorization { get; set; }

        /// <summary>
        /// Gets or sets the type of the entity creational factory.
        /// </summary>
        /// <value>The type of the entity creational factory.</value>
        Type EntityCreationalFactoryType { get; set; }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        DataSet ExecuteDataSet( string storedProcedureName, params object[] parameterValues );

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        DataSet ExecuteDataSet( TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues );

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        DataSet ExecuteDataSet( TransactionManager transactionManager, DbCommand commandWrapper );

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        DataSet ExecuteDataSet( DbCommand commandWrapper );

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        DataSet ExecuteDataSet( TransactionManager transactionManager, CommandType commandType, string commandText );

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        DataSet ExecuteDataSet( CommandType commandType, string commandText );

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        int ExecuteNonQuery( CommandType commandType, string commandText );

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        int ExecuteNonQuery( TransactionManager transactionManager, CommandType commandType, string commandText );

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        int ExecuteNonQuery( string storedProcedureName, params object[] parameterValues );

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        int ExecuteNonQuery( TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues );

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandWrapper">The command wrapper.</param>
        void ExecuteNonQuery( TransactionManager transactionManager, DbCommand commandWrapper );

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="commandWrapper">The command wrapper.</param>
        void ExecuteNonQuery( DbCommand commandWrapper );

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        IDataReader ExecuteReader( CommandType commandType, string commandText );

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        IDataReader ExecuteReader( TransactionManager transactionManager, CommandType commandType, string commandText );

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        IDataReader ExecuteReader( TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues );

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        IDataReader ExecuteReader( string storedProcedureName, params object[] parameterValues );

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        IDataReader ExecuteReader( TransactionManager transactionManager, DbCommand commandWrapper );

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        IDataReader ExecuteReader( DbCommand commandWrapper );

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        object ExecuteScalar( TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues );

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        object ExecuteScalar( CommandType commandType, string commandText );

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        object ExecuteScalar( TransactionManager transactionManager, CommandType commandType, string commandText );

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        object ExecuteScalar( DbCommand commandWrapper );

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        object ExecuteScalar( TransactionManager transactionManager, DbCommand commandWrapper );

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        object ExecuteScalar( string storedProcedureName, params object[] parameterValues );

        /// <summary>
        /// Initializes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="config">The config.</param>
        void Initialize( string name, NameValueCollection config );

        /// <summary>
        /// Gets a value indicating whether this instance is transaction supported.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is transaction supported; otherwise, <c>false</c>.
        /// </value>
        bool IsTransactionSupported { get; }

        /// <summary>
        /// Gets or sets a value indicating whether [use entity factory].
        /// </summary>
        /// <value><c>true</c> if [use entity factory]; otherwise, <c>false</c>.</value>
        bool UseEntityFactory { get; set; }
    }
}