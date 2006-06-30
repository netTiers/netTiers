#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="AccountProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AccountProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.Account, netTiers.Petshop.Entities.AccountKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Functions

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.AccountKey key)
		{
			return Delete(transactionManager, key.Id, ((key.Entity != null) ? key.Entity.Timestamp : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="id">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String id, byte[] timestamp)
		{
			return Delete(null, id, timestamp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String id, byte[] timestamp);		
		
		#endregion
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_CreditCard key.
		///		FK_Account_CreditCard Description: 
		/// </summary>
		/// <param name="creditCardId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByCreditCardId(System.String creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(creditCardId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_CreditCard key.
		///		FK_Account_CreditCard Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="creditCardId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<Account> GetByCreditCardId(TransactionManager transactionManager, System.String creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, creditCardId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_CreditCard key.
		///		FK_Account_CreditCard Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="creditCardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByCreditCardId(TransactionManager transactionManager, System.String creditCardId, int start, int pageLength)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_CreditCard key.
		///		fK_Account_CreditCard Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="creditCardId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByCreditCardId(System.String creditCardId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCreditCardId(null, creditCardId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_CreditCard key.
		///		fK_Account_CreditCard Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="creditCardId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByCreditCardId(System.String creditCardId, int start, int pageLength,out int count)
		{
			return GetByCreditCardId(null, creditCardId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_CreditCard key.
		///		FK_Account_CreditCard Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="creditCardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<Account> GetByCreditCardId(TransactionManager transactionManager, System.String creditCardId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Category key.
		///		FK_Account_Category Description: 
		/// </summary>
		/// <param name="favoriteCategoryId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByFavoriteCategoryId(System.String favoriteCategoryId)
		{
			int count = -1;
			return GetByFavoriteCategoryId(favoriteCategoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Category key.
		///		FK_Account_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="favoriteCategoryId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<Account> GetByFavoriteCategoryId(TransactionManager transactionManager, System.String favoriteCategoryId)
		{
			int count = -1;
			return GetByFavoriteCategoryId(transactionManager, favoriteCategoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Category key.
		///		FK_Account_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="favoriteCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByFavoriteCategoryId(TransactionManager transactionManager, System.String favoriteCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByFavoriteCategoryId(transactionManager, favoriteCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Category key.
		///		fK_Account_Category Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="favoriteCategoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByFavoriteCategoryId(System.String favoriteCategoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFavoriteCategoryId(null, favoriteCategoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Category key.
		///		fK_Account_Category Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="favoriteCategoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByFavoriteCategoryId(System.String favoriteCategoryId, int start, int pageLength,out int count)
		{
			return GetByFavoriteCategoryId(null, favoriteCategoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Category key.
		///		FK_Account_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="favoriteCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Account objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<Account> GetByFavoriteCategoryId(TransactionManager transactionManager, System.String favoriteCategoryId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override netTiers.Petshop.Entities.Account Get(TransactionManager transactionManager, netTiers.Petshop.Entities.AccountKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Account index.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetById(System.String id)
		{
			int count = -1;
			return GetById(null,id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetById(System.String id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetById(TransactionManager transactionManager, System.String id)
		{
			int count = -1;
			return GetById(transactionManager, id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetById(TransactionManager transactionManager, System.String id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetById(System.String id, int start, int pageLength, out int count)
		{
			return GetById(null, id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public abstract netTiers.Petshop.Entities.Account GetById(TransactionManager transactionManager, System.String id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Account index.
		/// </summary>
		/// <param name="login"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetByLogin(System.String login)
		{
			int count = -1;
			return GetByLogin(null,login, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="login"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetByLogin(System.String login, int start, int pageLength)
		{
			int count = -1;
			return GetByLogin(null, login, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="login"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetByLogin(TransactionManager transactionManager, System.String login)
		{
			int count = -1;
			return GetByLogin(transactionManager, login, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="login"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetByLogin(TransactionManager transactionManager, System.String login, int start, int pageLength)
		{
			int count = -1;
			return GetByLogin(transactionManager, login, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="login"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public netTiers.Petshop.Entities.Account GetByLogin(System.String login, int start, int pageLength, out int count)
		{
			return GetByLogin(null, login, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="login"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Account"/> class.</returns>
		public abstract netTiers.Petshop.Entities.Account GetByLogin(TransactionManager transactionManager, System.String login, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Account_LastName index.
		/// </summary>
		/// <param name="lastName"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.TList&lt;Account&gt;"/> class.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByLastName(System.String lastName)
		{
			int count = -1;
			return GetByLastName(null,lastName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account_LastName index.
		/// </summary>
		/// <param name="lastName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.TList&lt;Account&gt;"/> class.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByLastName(System.String lastName, int start, int pageLength)
		{
			int count = -1;
			return GetByLastName(null, lastName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account_LastName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="lastName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.TList&lt;Account&gt;"/> class.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByLastName(TransactionManager transactionManager, System.String lastName)
		{
			int count = -1;
			return GetByLastName(transactionManager, lastName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account_LastName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="lastName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.TList&lt;Account&gt;"/> class.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByLastName(TransactionManager transactionManager, System.String lastName, int start, int pageLength)
		{
			int count = -1;
			return GetByLastName(transactionManager, lastName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account_LastName index.
		/// </summary>
		/// <param name="lastName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.TList&lt;Account&gt;"/> class.</returns>
		public netTiers.Petshop.Entities.TList<Account> GetByLastName(System.String lastName, int start, int pageLength, out int count)
		{
			return GetByLastName(null, lastName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account_LastName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="lastName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.TList&lt;Account&gt;"/> class.</returns>
		public abstract netTiers.Petshop.Entities.TList<Account> GetByLastName(TransactionManager transactionManager, System.String lastName, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;Account&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;Account&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<Account> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<Account> rows, int start, int pageLength)
		{
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
					return rows; // not enough rows, just return
			}

			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done

				string key = null;
				
				netTiers.Petshop.Entities.Account c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Account" 
							+ (reader.IsDBNull(reader.GetOrdinal("Id"))?string.Empty:(System.String)reader["Id"]).ToString();

					c = EntityManager.LocateOrCreate<Account>(
						key.ToString(), // EntityTrackingKey 
						"Account",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.Account();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.Id = (System.String)reader["Id"];
					c.OriginalId = c.Id; //(reader.IsDBNull(reader.GetOrdinal("Id")))?string.Empty:(System.String)reader["Id"];
					c.FirstName = (reader.IsDBNull(reader.GetOrdinal("FirstName")))?null:(System.String)reader["FirstName"];
					c.LastName = (reader.IsDBNull(reader.GetOrdinal("LastName")))?null:(System.String)reader["LastName"];
					c.StreetAddress = (reader.IsDBNull(reader.GetOrdinal("StreetAddress")))?null:(System.String)reader["StreetAddress"];
					c.PostalCode = (reader.IsDBNull(reader.GetOrdinal("PostalCode")))?null:(System.String)reader["PostalCode"];
					c.City = (reader.IsDBNull(reader.GetOrdinal("City")))?null:(System.String)reader["City"];
					c.StateOrProvince = (reader.IsDBNull(reader.GetOrdinal("StateOrProvince")))?null:(System.String)reader["StateOrProvince"];
					c.Country = (reader.IsDBNull(reader.GetOrdinal("Country")))?null:(System.String)reader["Country"];
					c.TelephoneNumber = (reader.IsDBNull(reader.GetOrdinal("TelephoneNumber")))?null:(System.String)reader["TelephoneNumber"];
					c.Email = (reader.IsDBNull(reader.GetOrdinal("Email")))?null:(System.String)reader["Email"];
					c.Login = (reader.IsDBNull(reader.GetOrdinal("Login")))?null:(System.String)reader["Login"];
					c.Password = (reader.IsDBNull(reader.GetOrdinal("Password")))?null:(System.String)reader["Password"];
					c.IWantMyList = (reader.IsDBNull(reader.GetOrdinal("IWantMyList")))?null:(System.Boolean?)reader["IWantMyList"];
					c.IWantPetTips = (reader.IsDBNull(reader.GetOrdinal("IWantPetTips")))?null:(System.Boolean?)reader["IWantPetTips"];
					c.FavoriteLanguage = (reader.IsDBNull(reader.GetOrdinal("FavoriteLanguage")))?null:(System.String)reader["FavoriteLanguage"];
					c.CreditCardId = (reader.IsDBNull(reader.GetOrdinal("CreditCardId")))?null:(System.String)reader["CreditCardId"];
					c.FavoriteCategoryId = (reader.IsDBNull(reader.GetOrdinal("FavoriteCategoryId")))?null:(System.String)reader["FavoriteCategoryId"];
					c.Timestamp = (System.Byte[])reader["Timestamp"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Account"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Account"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.Account entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader["Id"];
			entity.OriginalId = (System.String)reader["Id"];
			entity.FirstName = (reader.IsDBNull(reader.GetOrdinal("FirstName")))?null:(System.String)reader["FirstName"];
			entity.LastName = (reader.IsDBNull(reader.GetOrdinal("LastName")))?null:(System.String)reader["LastName"];
			entity.StreetAddress = (reader.IsDBNull(reader.GetOrdinal("StreetAddress")))?null:(System.String)reader["StreetAddress"];
			entity.PostalCode = (reader.IsDBNull(reader.GetOrdinal("PostalCode")))?null:(System.String)reader["PostalCode"];
			entity.City = (reader.IsDBNull(reader.GetOrdinal("City")))?null:(System.String)reader["City"];
			entity.StateOrProvince = (reader.IsDBNull(reader.GetOrdinal("StateOrProvince")))?null:(System.String)reader["StateOrProvince"];
			entity.Country = (reader.IsDBNull(reader.GetOrdinal("Country")))?null:(System.String)reader["Country"];
			entity.TelephoneNumber = (reader.IsDBNull(reader.GetOrdinal("TelephoneNumber")))?null:(System.String)reader["TelephoneNumber"];
			entity.Email = (reader.IsDBNull(reader.GetOrdinal("Email")))?null:(System.String)reader["Email"];
			entity.Login = (reader.IsDBNull(reader.GetOrdinal("Login")))?null:(System.String)reader["Login"];
			entity.Password = (reader.IsDBNull(reader.GetOrdinal("Password")))?null:(System.String)reader["Password"];
			entity.IWantMyList = (reader.IsDBNull(reader.GetOrdinal("IWantMyList")))?null:(System.Boolean?)reader["IWantMyList"];
			entity.IWantPetTips = (reader.IsDBNull(reader.GetOrdinal("IWantPetTips")))?null:(System.Boolean?)reader["IWantPetTips"];
			entity.FavoriteLanguage = (reader.IsDBNull(reader.GetOrdinal("FavoriteLanguage")))?null:(System.String)reader["FavoriteLanguage"];
			entity.CreditCardId = (reader.IsDBNull(reader.GetOrdinal("CreditCardId")))?null:(System.String)reader["CreditCardId"];
			entity.FavoriteCategoryId = (reader.IsDBNull(reader.GetOrdinal("FavoriteCategoryId")))?null:(System.String)reader["FavoriteCategoryId"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Account"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Account"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.Account entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["Id"];
			entity.OriginalId = (System.String)dataRow["Id"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?null:(System.String)dataRow["FirstName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?null:(System.String)dataRow["LastName"];
			entity.StreetAddress = (Convert.IsDBNull(dataRow["StreetAddress"]))?null:(System.String)dataRow["StreetAddress"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?null:(System.String)dataRow["PostalCode"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?null:(System.String)dataRow["City"];
			entity.StateOrProvince = (Convert.IsDBNull(dataRow["StateOrProvince"]))?null:(System.String)dataRow["StateOrProvince"];
			entity.Country = (Convert.IsDBNull(dataRow["Country"]))?null:(System.String)dataRow["Country"];
			entity.TelephoneNumber = (Convert.IsDBNull(dataRow["TelephoneNumber"]))?null:(System.String)dataRow["TelephoneNumber"];
			entity.Email = (Convert.IsDBNull(dataRow["Email"]))?null:(System.String)dataRow["Email"];
			entity.Login = (Convert.IsDBNull(dataRow["Login"]))?null:(System.String)dataRow["Login"];
			entity.Password = (Convert.IsDBNull(dataRow["Password"]))?null:(System.String)dataRow["Password"];
			entity.IWantMyList = (Convert.IsDBNull(dataRow["IWantMyList"]))?null:(System.Boolean?)dataRow["IWantMyList"];
			entity.IWantPetTips = (Convert.IsDBNull(dataRow["IWantPetTips"]))?null:(System.Boolean?)dataRow["IWantPetTips"];
			entity.FavoriteLanguage = (Convert.IsDBNull(dataRow["FavoriteLanguage"]))?null:(System.String)dataRow["FavoriteLanguage"];
			entity.CreditCardId = (Convert.IsDBNull(dataRow["CreditCardId"]))?null:(System.String)dataRow["CreditCardId"];
			entity.FavoriteCategoryId = (Convert.IsDBNull(dataRow["FavoriteCategoryId"]))?null:(System.String)dataRow["FavoriteCategoryId"];
			entity.Timestamp = (System.Byte[])dataRow["Timestamp"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad
		
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Account"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Account Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		protected override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.Account entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, Hashtable innerList)
		{
			
			#region Composite Source Children
			//Fill Source Composite Properties, however, don't call deep load on them.  
			//So they only get filled a single level deep.
			
			#region CreditCardIdSource
			if ((deepLoadType == DeepLoadType.IncludeChildren && innerList["CreditCard"] != null)
				|| (deepLoadType == DeepLoadType.ExcludeChildren && innerList["CreditCard"] == null))
			{
				if (entity.CreditCardIdSource == null)
				{
					object[] pkItems = new object[1];
					pkItems[0] = (entity.CreditCardId ?? string.Empty);
					CreditCard tmpEntity = EntityManager.LocateEntity<CreditCard>(EntityLocator.ConstructKeyFromPkItems(typeof(CreditCard), pkItems), DataRepository.Provider.EnableEntityTracking);
					if (tmpEntity != null)
						entity.CreditCardIdSource = tmpEntity;
					else
						entity.CreditCardIdSource = DataRepository.CreditCardProvider.GetById((entity.CreditCardId ?? string.Empty));
				}
				if (deepLoadType == DeepLoadType.IncludeChildren)
					innerList.Remove("CreditCard");
				else 
					innerList.Add("CreditCard", typeof(CreditCard));
			}
			#endregion CreditCardIdSource
			
			#region FavoriteCategoryIdSource
			if ((deepLoadType == DeepLoadType.IncludeChildren && innerList["Category"] != null)
				|| (deepLoadType == DeepLoadType.ExcludeChildren && innerList["Category"] == null))
			{
				if (entity.FavoriteCategoryIdSource == null)
				{
					object[] pkItems = new object[1];
					pkItems[0] = (entity.FavoriteCategoryId ?? string.Empty);
					Category tmpEntity = EntityManager.LocateEntity<Category>(EntityLocator.ConstructKeyFromPkItems(typeof(Category), pkItems), DataRepository.Provider.EnableEntityTracking);
					if (tmpEntity != null)
						entity.FavoriteCategoryIdSource = tmpEntity;
					else
						entity.FavoriteCategoryIdSource = DataRepository.CategoryProvider.GetById((entity.FavoriteCategoryId ?? string.Empty));
				}
				if (deepLoadType == DeepLoadType.IncludeChildren)
					innerList.Remove("Category");
				else 
					innerList.Add("Category", typeof(Category));
			}
			#endregion FavoriteCategoryIdSource
			#endregion
			
			ArrayList alreadySetCollections = new ArrayList();
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.Account object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.Account instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Account Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		protected override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.Account entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CreditCardIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["CreditCard"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" CreditCard"] == null))
			{
				if (entity.CreditCardIdSource != null )
				{
					//if (!entity.CreditCardIdSource.IsValid)
						//throw new netTiers.Petshop.Entities.EntityNotValidException(entity, "DeepSave");
					
					DataRepository.CreditCardProvider.Save(transactionManager, entity.CreditCardIdSource);
				}
			}
			#endregion 
			
			#region FavoriteCategoryIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["Category"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" Category"] == null))
			{
				if (entity.FavoriteCategoryIdSource != null )
				{
					//if (!entity.FavoriteCategoryIdSource.IsValid)
						//throw new netTiers.Petshop.Entities.EntityNotValidException(entity, "DeepSave");
					
					DataRepository.CategoryProvider.Save(transactionManager, entity.FavoriteCategoryIdSource);
				}
			}
			#endregion 
			#endregion Composite Source Properties

		}
		#endregion
	} // end class

	#region AccountFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Account"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountFilterBuilder : SqlFilterBuilder<AccountColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountFilterBuilder class.
		/// </summary>
		public AccountFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountFilterBuilder
} // end namespace
