#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="StoreProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class StoreProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Store, Nettiers.AdventureWorks.Entities.StoreKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByContactIdFromStoreContact
		
		/// <summary>
		///		Gets Store objects from the datasource by ContactID in the
		///		StoreContact table. Table Store is related to table Contact
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="_contactId">Contact (store employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Store objects.</returns>
		public TList<Store> GetByContactIdFromStoreContact(System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactIdFromStoreContact(null,_contactId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Store objects from the datasource by ContactID in the
		///		StoreContact table. Table Store is related to table Contact
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Contact (store employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Store objects.</returns>
		public TList<Store> GetByContactIdFromStoreContact(System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactIdFromStoreContact(null, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Store objects from the datasource by ContactID in the
		///		StoreContact table. Table Store is related to table Contact
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Contact (store employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Store objects.</returns>
		public TList<Store> GetByContactIdFromStoreContact(TransactionManager transactionManager, System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactIdFromStoreContact(transactionManager, _contactId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Store objects from the datasource by ContactID in the
		///		StoreContact table. Table Store is related to table Contact
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Contact (store employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Store objects.</returns>
		public TList<Store> GetByContactIdFromStoreContact(TransactionManager transactionManager, System.Int32 _contactId,int start, int pageLength)
		{
			int count = -1;
			return GetByContactIdFromStoreContact(transactionManager, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Store objects from the datasource by ContactID in the
		///		StoreContact table. Table Store is related to table Contact
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="_contactId">Contact (store employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Store objects.</returns>
		public TList<Store> GetByContactIdFromStoreContact(System.Int32 _contactId,int start, int pageLength, out int count)
		{
			
			return GetByContactIdFromStoreContact(null, _contactId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Store objects from the datasource by ContactID in the
		///		StoreContact table. Table Store is related to table Contact
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_contactId">Contact (store employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Store objects.</returns>
		public abstract TList<Store> GetByContactIdFromStoreContact(TransactionManager transactionManager,System.Int32 _contactId, int start, int pageLength, out int count);
		
		#endregion GetByContactIdFromStoreContact
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StoreKey key)
		{
			return Delete(transactionManager, key.CustomerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _customerId)
		{
			return Delete(null, _customerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _customerId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override Nettiers.AdventureWorks.Entities.Store Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StoreKey key, int start, int pageLength)
		{
			return GetByCustomerId(transactionManager, key.CustomerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Store_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Store_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Store_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Store_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Store_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Store_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Store GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Store_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId">ID of the sales person assigned to the customer. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetBySalesPersonId(System.Int32? _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(null,_salesPersonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Store_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId">ID of the sales person assigned to the customer. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetBySalesPersonId(System.Int32? _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Store_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">ID of the sales person assigned to the customer. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Store_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">ID of the sales person assigned to the customer. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Store_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId">ID of the sales person assigned to the customer. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetBySalesPersonId(System.Int32? _salesPersonId, int start, int pageLength, out int count)
		{
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Store_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">ID of the sales person assigned to the customer. Foreign key to SalesPerson.SalesPersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public abstract TList<Store> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Store_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Store_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Store_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Store_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Store_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Store GetByCustomerId(System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Store_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Store"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Store GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PXML_Store_Demographics index.
		/// </summary>
		/// <param name="_demographics">Demographic informationg about the store such as the number of employees, annual sales and store type.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetByDemographics(string _demographics)
		{
			int count = -1;
			return GetByDemographics(null,_demographics, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Store_Demographics index.
		/// </summary>
		/// <param name="_demographics">Demographic informationg about the store such as the number of employees, annual sales and store type.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetByDemographics(string _demographics, int start, int pageLength)
		{
			int count = -1;
			return GetByDemographics(null, _demographics, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Store_Demographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_demographics">Demographic informationg about the store such as the number of employees, annual sales and store type.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetByDemographics(TransactionManager transactionManager, string _demographics)
		{
			int count = -1;
			return GetByDemographics(transactionManager, _demographics, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Store_Demographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_demographics">Demographic informationg about the store such as the number of employees, annual sales and store type.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetByDemographics(TransactionManager transactionManager, string _demographics, int start, int pageLength)
		{
			int count = -1;
			return GetByDemographics(transactionManager, _demographics, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Store_Demographics index.
		/// </summary>
		/// <param name="_demographics">Demographic informationg about the store such as the number of employees, annual sales and store type.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public TList<Store> GetByDemographics(string _demographics, int start, int pageLength, out int count)
		{
			return GetByDemographics(null, _demographics, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Store_Demographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_demographics">Demographic informationg about the store such as the number of employees, annual sales and store type.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Store&gt;"/> class.</returns>
		public abstract TList<Store> GetByDemographics(TransactionManager transactionManager, string _demographics, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Store&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Store&gt;"/></returns>
		public static TList<Store> Fill(IDataReader reader, TList<Store> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
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
				
				Nettiers.AdventureWorks.Entities.Store c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Store")
					.Append("|").Append((System.Int32)reader[((int)StoreColumn.CustomerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Store>(
					key.ToString(), // EntityTrackingKey
					"Store",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Store();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.CustomerId = (System.Int32)reader[((int)StoreColumn.CustomerId - 1)];
					c.OriginalCustomerId = c.CustomerId;
					c.Name = (System.String)reader[((int)StoreColumn.Name - 1)];
					c.SalesPersonId = (reader.IsDBNull(((int)StoreColumn.SalesPersonId - 1)))?null:(System.Int32?)reader[((int)StoreColumn.SalesPersonId - 1)];
					c.Demographics = (reader.IsDBNull(((int)StoreColumn.Demographics - 1)))?null:(string)reader[((int)StoreColumn.Demographics - 1)];
					c.Rowguid = (System.Guid)reader[((int)StoreColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)StoreColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Store"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Store"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Store entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomerId = (System.Int32)reader[((int)StoreColumn.CustomerId - 1)];
			entity.OriginalCustomerId = (System.Int32)reader["CustomerID"];
			entity.Name = (System.String)reader[((int)StoreColumn.Name - 1)];
			entity.SalesPersonId = (reader.IsDBNull(((int)StoreColumn.SalesPersonId - 1)))?null:(System.Int32?)reader[((int)StoreColumn.SalesPersonId - 1)];
			entity.Demographics = (reader.IsDBNull(((int)StoreColumn.Demographics - 1)))?null:(string)reader[((int)StoreColumn.Demographics - 1)];
			entity.Rowguid = (System.Guid)reader[((int)StoreColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)StoreColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Store"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Store"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Store entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.OriginalCustomerId = (System.Int32)dataRow["CustomerID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.SalesPersonId = Convert.IsDBNull(dataRow["SalesPersonID"]) ? null : (System.Int32?)dataRow["SalesPersonID"];
			entity.Demographics = Convert.IsDBNull(dataRow["Demographics"]) ? null : (string)dataRow["Demographics"];
			entity.Rowguid = (System.Guid)dataRow["rowguid"];
			entity.ModifiedDate = (System.DateTime)dataRow["ModifiedDate"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Store"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Store Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Store entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "Customer|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomerId;
				Customer tmpEntity = EntityManager.LocateEntity<Customer>(EntityLocator.ConstructKeyFromPkItems(typeof(Customer), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomerProvider.GetByCustomerId(transactionManager, entity.CustomerId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomerProvider.DeepLoad(transactionManager, entity.CustomerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerIdSource

			#region SalesPersonIdSource	
			if (CanDeepLoad(entity, "SalesPerson|SalesPersonIdSource", deepLoadType, innerList) 
				&& entity.SalesPersonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SalesPersonId ?? (int)0);
				SalesPerson tmpEntity = EntityManager.LocateEntity<SalesPerson>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesPerson), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesPersonIdSource = tmpEntity;
				else
					entity.SalesPersonIdSource = DataRepository.SalesPersonProvider.GetBySalesPersonId(transactionManager, (entity.SalesPersonId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesPersonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesPersonProvider.DeepLoad(transactionManager, entity.SalesPersonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesPersonIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCustomerId methods when available
			
			#region StoreContactCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<StoreContact>|StoreContactCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StoreContactCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.StoreContactCollection = DataRepository.StoreContactProvider.GetByCustomerId(transactionManager, entity.CustomerId);

				if (deep && entity.StoreContactCollection.Count > 0)
				{
					deepHandles.Add("StoreContactCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<StoreContact>) DataRepository.StoreContactProvider.DeepLoad,
						new object[] { transactionManager, entity.StoreContactCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ContactIdContactCollection_From_StoreContact
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Contact>|ContactIdContactCollection_From_StoreContact", deepLoadType, innerList))
			{
				entity.ContactIdContactCollection_From_StoreContact = DataRepository.ContactProvider.GetByCustomerIdFromStoreContact(transactionManager, entity.CustomerId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ContactIdContactCollection_From_StoreContact' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ContactIdContactCollection_From_StoreContact != null)
				{
					deepHandles.Add("ContactIdContactCollection_From_StoreContact",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Contact >) DataRepository.ContactProvider.DeepLoad,
						new object[] { transactionManager, entity.ContactIdContactCollection_From_StoreContact, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Store object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Store instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Store Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Store entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customer|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.CustomerId;
			}
			#endregion 
			
			#region SalesPersonIdSource
			if (CanDeepSave(entity, "SalesPerson|SalesPersonIdSource", deepSaveType, innerList) 
				&& entity.SalesPersonIdSource != null)
			{
				DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesPersonIdSource);
				entity.SalesPersonId = entity.SalesPersonIdSource.SalesPersonId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region ContactIdContactCollection_From_StoreContact>
			if (CanDeepSave(entity.ContactIdContactCollection_From_StoreContact, "List<Contact>|ContactIdContactCollection_From_StoreContact", deepSaveType, innerList))
			{
				if (entity.ContactIdContactCollection_From_StoreContact.Count > 0 || entity.ContactIdContactCollection_From_StoreContact.DeletedItems.Count > 0)
				{
					DataRepository.ContactProvider.Save(transactionManager, entity.ContactIdContactCollection_From_StoreContact); 
					deepHandles.Add("ContactIdContactCollection_From_StoreContact",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Contact>) DataRepository.ContactProvider.DeepSave,
						new object[] { transactionManager, entity.ContactIdContactCollection_From_StoreContact, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<StoreContact>
				if (CanDeepSave(entity.StoreContactCollection, "List<StoreContact>|StoreContactCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(StoreContact child in entity.StoreContactCollection)
					{
						if(child.CustomerIdSource != null)
						{
								child.CustomerId = child.CustomerIdSource.CustomerId;
						}

						if(child.ContactIdSource != null)
						{
								child.ContactId = child.ContactIdSource.ContactId;
						}

					}

					if (entity.StoreContactCollection.Count > 0 || entity.StoreContactCollection.DeletedItems.Count > 0)
					{
						//DataRepository.StoreContactProvider.Save(transactionManager, entity.StoreContactCollection);
						
						deepHandles.Add("StoreContactCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< StoreContact >) DataRepository.StoreContactProvider.DeepSave,
							new object[] { transactionManager, entity.StoreContactCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region StoreChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Store</c>
	///</summary>
	public enum StoreChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
			
		///<summary>
		/// Composite Property for <c>SalesPerson</c> at SalesPersonIdSource
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,
	
		///<summary>
		/// Collection of <c>Store</c> as OneToMany for StoreContactCollection
		///</summary>
		[ChildEntityType(typeof(TList<StoreContact>))]
		StoreContactCollection,

		///<summary>
		/// Collection of <c>Store</c> as ManyToMany for ContactCollection_From_StoreContact
		///</summary>
		[ChildEntityType(typeof(TList<Contact>))]
		ContactIdContactCollection_From_StoreContact,
	}
	
	#endregion StoreChildEntityTypes
	
	#region StoreFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;StoreColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreFilterBuilder : SqlFilterBuilder<StoreColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreFilterBuilder class.
		/// </summary>
		public StoreFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StoreFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StoreFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StoreFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StoreFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StoreFilterBuilder
	
	#region StoreParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;StoreColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreParameterBuilder : ParameterizedSqlFilterBuilder<StoreColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreParameterBuilder class.
		/// </summary>
		public StoreParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StoreParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StoreParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StoreParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StoreParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StoreParameterBuilder
	
	#region StoreSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;StoreColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class StoreSortBuilder : SqlSortBuilder<StoreColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreSqlSortBuilder class.
		/// </summary>
		public StoreSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion StoreSortBuilder
	
} // end namespace
