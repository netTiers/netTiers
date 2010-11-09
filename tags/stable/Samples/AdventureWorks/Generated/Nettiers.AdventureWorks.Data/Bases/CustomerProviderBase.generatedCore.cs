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
	/// This class is the base class for any <see cref="CustomerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Customer, Nettiers.AdventureWorks.Entities.CustomerKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByAddressIdFromCustomerAddress
		
		/// <summary>
		///		Gets Customer objects from the datasource by AddressID in the
		///		CustomerAddress table. Table Customer is related to table Address
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Customer objects.</returns>
		public TList<Customer> GetByAddressIdFromCustomerAddress(System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressIdFromCustomerAddress(null,_addressId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Customer objects from the datasource by AddressID in the
		///		CustomerAddress table. Table Customer is related to table Address
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Customer objects.</returns>
		public TList<Customer> GetByAddressIdFromCustomerAddress(System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressIdFromCustomerAddress(null, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Customer objects from the datasource by AddressID in the
		///		CustomerAddress table. Table Customer is related to table Address
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Customer objects.</returns>
		public TList<Customer> GetByAddressIdFromCustomerAddress(TransactionManager transactionManager, System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressIdFromCustomerAddress(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Customer objects from the datasource by AddressID in the
		///		CustomerAddress table. Table Customer is related to table Address
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Customer objects.</returns>
		public TList<Customer> GetByAddressIdFromCustomerAddress(TransactionManager transactionManager, System.Int32 _addressId,int start, int pageLength)
		{
			int count = -1;
			return GetByAddressIdFromCustomerAddress(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Customer objects from the datasource by AddressID in the
		///		CustomerAddress table. Table Customer is related to table Address
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Customer objects.</returns>
		public TList<Customer> GetByAddressIdFromCustomerAddress(System.Int32 _addressId,int start, int pageLength, out int count)
		{
			
			return GetByAddressIdFromCustomerAddress(null, _addressId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Customer objects from the datasource by AddressID in the
		///		CustomerAddress table. Table Customer is related to table Address
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Customer objects.</returns>
		public abstract TList<Customer> GetByAddressIdFromCustomerAddress(TransactionManager transactionManager,System.Int32 _addressId, int start, int pageLength, out int count);
		
		#endregion GetByAddressIdFromCustomerAddress
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CustomerKey key)
		{
			return Delete(transactionManager, key.CustomerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerId">Primary key for Customer records.. Primary Key.</param>
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
		/// <param name="_customerId">Primary key for Customer records.. Primary Key.</param>
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
		public override Nettiers.AdventureWorks.Entities.Customer Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CustomerKey key, int start, int pageLength)
		{
			return GetByCustomerId(transactionManager, key.CustomerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Customer_AccountNumber index.
		/// </summary>
		/// <param name="_accountNumber">Unique number identifying the customer assigned by the accounting system.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByAccountNumber(System.String _accountNumber)
		{
			int count = -1;
			return GetByAccountNumber(null,_accountNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_AccountNumber index.
		/// </summary>
		/// <param name="_accountNumber">Unique number identifying the customer assigned by the accounting system.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByAccountNumber(System.String _accountNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountNumber(null, _accountNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_AccountNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountNumber">Unique number identifying the customer assigned by the accounting system.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByAccountNumber(TransactionManager transactionManager, System.String _accountNumber)
		{
			int count = -1;
			return GetByAccountNumber(transactionManager, _accountNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_AccountNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountNumber">Unique number identifying the customer assigned by the accounting system.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByAccountNumber(TransactionManager transactionManager, System.String _accountNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountNumber(transactionManager, _accountNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_AccountNumber index.
		/// </summary>
		/// <param name="_accountNumber">Unique number identifying the customer assigned by the accounting system.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByAccountNumber(System.String _accountNumber, int start, int pageLength, out int count)
		{
			return GetByAccountNumber(null, _accountNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_AccountNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountNumber">Unique number identifying the customer assigned by the accounting system.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Customer GetByAccountNumber(TransactionManager transactionManager, System.String _accountNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Customer_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Customer_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Customer GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Customer_TerritoryID index.
		/// </summary>
		/// <param name="_territoryId">ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customer&gt;"/> class.</returns>
		public TList<Customer> GetByTerritoryId(System.Int32? _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(null,_territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_TerritoryID index.
		/// </summary>
		/// <param name="_territoryId">ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customer&gt;"/> class.</returns>
		public TList<Customer> GetByTerritoryId(System.Int32? _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_TerritoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customer&gt;"/> class.</returns>
		public TList<Customer> GetByTerritoryId(TransactionManager transactionManager, System.Int32? _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_TerritoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customer&gt;"/> class.</returns>
		public TList<Customer> GetByTerritoryId(TransactionManager transactionManager, System.Int32? _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_TerritoryID index.
		/// </summary>
		/// <param name="_territoryId">ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customer&gt;"/> class.</returns>
		public TList<Customer> GetByTerritoryId(System.Int32? _territoryId, int start, int pageLength, out int count)
		{
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_TerritoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customer&gt;"/> class.</returns>
		public abstract TList<Customer> GetByTerritoryId(TransactionManager transactionManager, System.Int32? _territoryId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Customer_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Primary key for Customer records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customer_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Primary key for Customer records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customer_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key for Customer records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customer_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key for Customer records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customer_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Primary key for Customer records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Customer GetByCustomerId(System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customer_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key for Customer records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Customer GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Customer&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Customer&gt;"/></returns>
		public static TList<Customer> Fill(IDataReader reader, TList<Customer> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Customer c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Customer")
					.Append("|").Append((System.Int32)reader[((int)CustomerColumn.CustomerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Customer>(
					key.ToString(), // EntityTrackingKey
					"Customer",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Customer();
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
					c.CustomerId = (System.Int32)reader[((int)CustomerColumn.CustomerId - 1)];
					c.TerritoryId = (reader.IsDBNull(((int)CustomerColumn.TerritoryId - 1)))?null:(System.Int32?)reader[((int)CustomerColumn.TerritoryId - 1)];
					c.AccountNumber = (System.String)reader[((int)CustomerColumn.AccountNumber - 1)];
					c.CustomerType = (System.String)reader[((int)CustomerColumn.CustomerType - 1)];
					c.Rowguid = (System.Guid)reader[((int)CustomerColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)CustomerColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Customer"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Customer entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomerId = (System.Int32)reader[((int)CustomerColumn.CustomerId - 1)];
			entity.TerritoryId = (reader.IsDBNull(((int)CustomerColumn.TerritoryId - 1)))?null:(System.Int32?)reader[((int)CustomerColumn.TerritoryId - 1)];
			entity.AccountNumber = (System.String)reader[((int)CustomerColumn.AccountNumber - 1)];
			entity.CustomerType = (System.String)reader[((int)CustomerColumn.CustomerType - 1)];
			entity.Rowguid = (System.Guid)reader[((int)CustomerColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)CustomerColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Customer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Customer"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Customer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.TerritoryId = Convert.IsDBNull(dataRow["TerritoryID"]) ? null : (System.Int32?)dataRow["TerritoryID"];
			entity.AccountNumber = (System.String)dataRow["AccountNumber"];
			entity.CustomerType = (System.String)dataRow["CustomerType"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Customer"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Customer Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Customer entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region TerritoryIdSource	
			if (CanDeepLoad(entity, "SalesTerritory|TerritoryIdSource", deepLoadType, innerList) 
				&& entity.TerritoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.TerritoryId ?? (int)0);
				SalesTerritory tmpEntity = EntityManager.LocateEntity<SalesTerritory>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesTerritory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TerritoryIdSource = tmpEntity;
				else
					entity.TerritoryIdSource = DataRepository.SalesTerritoryProvider.GetByTerritoryId(transactionManager, (entity.TerritoryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TerritoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TerritoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesTerritoryProvider.DeepLoad(transactionManager, entity.TerritoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TerritoryIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCustomerId methods when available
			
			#region Store
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "Store|Store", deepLoadType, innerList))
			{
				entity.Store = DataRepository.StoreProvider.GetByCustomerId(transactionManager, entity.CustomerId);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Store' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.Store != null)
				{
					deepHandles.Add("Store",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< Store >) DataRepository.StoreProvider.DeepLoad,
						new object[] { transactionManager, entity.Store, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			#region SalesOrderHeaderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderHeader>|SalesOrderHeaderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderHeaderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderHeaderCollection = DataRepository.SalesOrderHeaderProvider.GetByCustomerId(transactionManager, entity.CustomerId);

				if (deep && entity.SalesOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AddressIdAddressCollection_From_CustomerAddress
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Address>|AddressIdAddressCollection_From_CustomerAddress", deepLoadType, innerList))
			{
				entity.AddressIdAddressCollection_From_CustomerAddress = DataRepository.AddressProvider.GetByCustomerIdFromCustomerAddress(transactionManager, entity.CustomerId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AddressIdAddressCollection_From_CustomerAddress' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AddressIdAddressCollection_From_CustomerAddress != null)
				{
					deepHandles.Add("AddressIdAddressCollection_From_CustomerAddress",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Address >) DataRepository.AddressProvider.DeepLoad,
						new object[] { transactionManager, entity.AddressIdAddressCollection_From_CustomerAddress, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region Individual
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "Individual|Individual", deepLoadType, innerList))
			{
				entity.Individual = DataRepository.IndividualProvider.GetByCustomerId(transactionManager, entity.CustomerId);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Individual' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.Individual != null)
				{
					deepHandles.Add("Individual",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< Individual >) DataRepository.IndividualProvider.DeepLoad,
						new object[] { transactionManager, entity.Individual, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			#region CustomerAddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerAddress>|CustomerAddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerAddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerAddressCollection = DataRepository.CustomerAddressProvider.GetByCustomerId(transactionManager, entity.CustomerId);

				if (deep && entity.CustomerAddressCollection.Count > 0)
				{
					deepHandles.Add("CustomerAddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerAddress>) DataRepository.CustomerAddressProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerAddressCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Customer object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Customer instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Customer Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Customer entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region TerritoryIdSource
			if (CanDeepSave(entity, "SalesTerritory|TerritoryIdSource", deepSaveType, innerList) 
				&& entity.TerritoryIdSource != null)
			{
				DataRepository.SalesTerritoryProvider.Save(transactionManager, entity.TerritoryIdSource);
				entity.TerritoryId = entity.TerritoryIdSource.TerritoryId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region Store
			if (CanDeepSave(entity.Store, "Store|Store", deepSaveType, innerList))
			{

				if (entity.Store != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.Store.CustomerId = entity.CustomerId;
					//DataRepository.StoreProvider.Save(transactionManager, entity.Store);
					deepHandles.Add("Store",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< Store >) DataRepository.StoreProvider.DeepSave,
						new object[] { transactionManager, entity.Store, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 

			#region Individual
			if (CanDeepSave(entity.Individual, "Individual|Individual", deepSaveType, innerList))
			{

				if (entity.Individual != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.Individual.CustomerId = entity.CustomerId;
					//DataRepository.IndividualProvider.Save(transactionManager, entity.Individual);
					deepHandles.Add("Individual",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< Individual >) DataRepository.IndividualProvider.DeepSave,
						new object[] { transactionManager, entity.Individual, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 

			#region AddressIdAddressCollection_From_CustomerAddress>
			if (CanDeepSave(entity.AddressIdAddressCollection_From_CustomerAddress, "List<Address>|AddressIdAddressCollection_From_CustomerAddress", deepSaveType, innerList))
			{
				if (entity.AddressIdAddressCollection_From_CustomerAddress.Count > 0 || entity.AddressIdAddressCollection_From_CustomerAddress.DeletedItems.Count > 0)
				{
					DataRepository.AddressProvider.Save(transactionManager, entity.AddressIdAddressCollection_From_CustomerAddress); 
					deepHandles.Add("AddressIdAddressCollection_From_CustomerAddress",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Address>) DataRepository.AddressProvider.DeepSave,
						new object[] { transactionManager, entity.AddressIdAddressCollection_From_CustomerAddress, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<SalesOrderHeader>
				if (CanDeepSave(entity.SalesOrderHeaderCollection, "List<SalesOrderHeader>|SalesOrderHeaderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderHeader child in entity.SalesOrderHeaderCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.CustomerId;
						}
						else
						{
							child.CustomerId = entity.CustomerId;
						}

					}

					if (entity.SalesOrderHeaderCollection.Count > 0 || entity.SalesOrderHeaderCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesOrderHeaderProvider.Save(transactionManager, entity.SalesOrderHeaderCollection);
						
						deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesOrderHeader >) DataRepository.SalesOrderHeaderProvider.DeepSave,
							new object[] { transactionManager, entity.SalesOrderHeaderCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CustomerAddress>
				if (CanDeepSave(entity.CustomerAddressCollection, "List<CustomerAddress>|CustomerAddressCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerAddress child in entity.CustomerAddressCollection)
					{
						if(child.CustomerIdSource != null)
						{
								child.CustomerId = child.CustomerIdSource.CustomerId;
						}

						if(child.AddressIdSource != null)
						{
								child.AddressId = child.AddressIdSource.AddressId;
						}

					}

					if (entity.CustomerAddressCollection.Count > 0 || entity.CustomerAddressCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerAddressProvider.Save(transactionManager, entity.CustomerAddressCollection);
						
						deepHandles.Add("CustomerAddressCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerAddress >) DataRepository.CustomerAddressProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerAddressCollection, deepSaveType, childTypes, innerList }
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
	
	#region CustomerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Customer</c>
	///</summary>
	public enum CustomerChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>SalesTerritory</c> at TerritoryIdSource
		///</summary>
		[ChildEntityType(typeof(SalesTerritory))]
		SalesTerritory,
			///<summary>
		/// Entity <c>Store</c> as OneToOne for Store
		///</summary>
		[ChildEntityType(typeof(Store))]
		Store,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for SalesOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderHeaderCollection,

		///<summary>
		/// Collection of <c>Customer</c> as ManyToMany for AddressCollection_From_CustomerAddress
		///</summary>
		[ChildEntityType(typeof(TList<Address>))]
		AddressIdAddressCollection_From_CustomerAddress,
		///<summary>
		/// Entity <c>Individual</c> as OneToOne for Individual
		///</summary>
		[ChildEntityType(typeof(Individual))]
		Individual,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for CustomerAddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerAddress>))]
		CustomerAddressCollection,
	}
	
	#endregion CustomerChildEntityTypes
	
	#region CustomerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerFilterBuilder : SqlFilterBuilder<CustomerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerFilterBuilder class.
		/// </summary>
		public CustomerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerFilterBuilder
	
	#region CustomerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerParameterBuilder : ParameterizedSqlFilterBuilder<CustomerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerParameterBuilder class.
		/// </summary>
		public CustomerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerParameterBuilder
	
	#region CustomerSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomerSortBuilder : SqlSortBuilder<CustomerColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerSqlSortBuilder class.
		/// </summary>
		public CustomerSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomerSortBuilder
	
} // end namespace
