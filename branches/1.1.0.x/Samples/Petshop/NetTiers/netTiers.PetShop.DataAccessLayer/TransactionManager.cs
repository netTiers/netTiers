
using System;
using System.Data;
using System.Data.Common;

using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace netTiers.PetShop.DataAccessLayer
{
	/// <summary>
	/// TransactionManager is utility class that decorates a <see cref="IDbTransaction"/> instance.
	/// </summary>
	public class TransactionManager
	{
		private Database database;
		
		private DbConnection connection ;
		private DbTransaction transaction;

		private string connectionString;
		private bool _transactionOpen = false;	

		/// <summary>
		///		Initializes a new instance of the <see cref="TransactionManager"/> class.
		/// </summary>
		internal TransactionManager()
		{			
		}
		
		/// <summary>
		///		Initializes a new instance of the <see cref="TransactionManager"/> class.
		/// </summary>
		/// <param name="connectionString">The connection string to the database.</param>
		public TransactionManager(string connectionString)
		{
            this.connectionString = connectionString;
            this.database = new SqlDatabase(connectionString);
			//this.database = DatabaseFactory.CreateDatabase(this.instanceName);
			this.connection = this.database.CreateConnection();
		}
		
		/// <summary>
		///		Gets or sets the configuration key for database service.
		/// </summary>
		/// <remark>Do not change during a transaction.</remark>
		public string ConnectionString
		{
			get { return this.connectionString; }
			set
			{//make sure transaction is open
				if (IsOpen)
					throw new InvalidOperationException ("Database cannot be changed during a transaction");

                this.connectionString = value;
                this.database = new SqlDatabase(connectionString);
				this.connection = this.database.CreateConnection();
			}
		}
		
		/// <summary>
		/// Gets the <see cref="Database"/> instance.
		/// </summary>
		/// <value></value>
		public Database Database
		{
			get {return this.database;}
		}


		/// <summary>
		///	Allows for objects to access the underlying <see cref="DbTransaction"/> object.
		/// </summary>
		public DbTransaction TransactionObject
		{
			get { return this.transaction; }
		}

		/// <summary>
		///	Gets a value that indicates if a transaction is currently open and operating. 
		/// </summary>
		/// <value>Return true if a transaction session is currently open and operating; otherwise false.</value>
		public bool IsOpen 
		{
			get { return _transactionOpen; }
		}
		
		/// <summary>
		///		Begins a transaction.
		/// </summary>
		public void BeginTransaction()
		{
			BeginTransaction(IsolationLevel.ReadCommitted);
		}
		
		
		/// <summary>
		///		Begins a transaction.
		/// </summary>
		/// <param name="isolationLevel">The isolation level of the transaction</param>
		public void BeginTransaction(IsolationLevel isolationLevel)
		{
			if(IsOpen)
				throw new InvalidOperationException ("Transaction already open.");
			
			//Open connection
			try
			{
				this.connection.Open();
				this.transaction = this.connection.BeginTransaction(isolationLevel);
				this._transactionOpen = true;
			}
			// in the event of an error, close the connection and destroy the transobject.
			catch(DataException)
			{
				if (this.connection != null) this.connection.Close();
				if (this.transaction != null) this.transaction.Dispose();
				throw;
				//this.connection.Close();
				//this.transaction.Dispose();
				//throw new DataException("Error while creating connection for transaction.", e);
			}			
		}
	
		/// <summary>
		///		Commit the transaction to the datasource.
		/// </summary>
		public void Commit()
		{
			if(!this.IsOpen)
			{
				throw new InvalidOperationException("Transaction needs to begin first.");
			}
			
			this.transaction.Commit();
			//assuming the commit was sucessful.
			this.connection.Close();
			this.transaction.Dispose();
			this._transactionOpen = false;
		}

		/// <summary>
		///	Rollback the transaction.
		/// </summary>
		public void Rollback()
		{	
			if(!this.IsOpen)
			{
				throw new InvalidOperationException("Transaction needs to begin first.");			
			}
			
			this.transaction.Rollback();
			this.connection.Close();
			this.transaction.Dispose();
			this._transactionOpen = false;
		}
		
	}
}
