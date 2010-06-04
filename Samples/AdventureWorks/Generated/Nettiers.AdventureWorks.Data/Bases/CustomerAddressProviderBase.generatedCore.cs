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
	/// This class is the base class for any <see cref="CustomerAddressProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerAddressProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.CustomerAddress, Nettiers.AdventureWorks.Entities.CustomerAddressKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CustomerAddressKey key)
		{
			return Delete(transactionManager, key.CustomerId, key.AddressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.. Primary Key.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _customerId, System.Int32 _addressId)
		{
			return Delete(null, _customerId, _addressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.. Primary Key.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _customerId, System.Int32 _addressId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Address_AddressID key.
		///		FK_CustomerAddress_Address_AddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByAddressId(System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(_addressId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Address_AddressID key.
		///		FK_CustomerAddress_Address_AddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerAddress> GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Address_AddressID key.
		///		FK_CustomerAddress_Address_AddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Address_AddressID key.
		///		fkCustomerAddressAddressAddressId Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByAddressId(System.Int32 _addressId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAddressId(null, _addressId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Address_AddressID key.
		///		fkCustomerAddressAddressAddressId Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByAddressId(System.Int32 _addressId, int start, int pageLength,out int count)
		{
			return GetByAddressId(null, _addressId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Address_AddressID key.
		///		FK_CustomerAddress_Address_AddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public abstract TList<CustomerAddress> GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_AddressType_AddressTypeID key.
		///		FK_CustomerAddress_AddressType_AddressTypeID Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByAddressTypeId(System.Int32 _addressTypeId)
		{
			int count = -1;
			return GetByAddressTypeId(_addressTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_AddressType_AddressTypeID key.
		///		FK_CustomerAddress_AddressType_AddressTypeID Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerAddress> GetByAddressTypeId(TransactionManager transactionManager, System.Int32 _addressTypeId)
		{
			int count = -1;
			return GetByAddressTypeId(transactionManager, _addressTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_AddressType_AddressTypeID key.
		///		FK_CustomerAddress_AddressType_AddressTypeID Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByAddressTypeId(TransactionManager transactionManager, System.Int32 _addressTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressTypeId(transactionManager, _addressTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_AddressType_AddressTypeID key.
		///		fkCustomerAddressAddressTypeAddressTypeId Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByAddressTypeId(System.Int32 _addressTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAddressTypeId(null, _addressTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_AddressType_AddressTypeID key.
		///		fkCustomerAddressAddressTypeAddressTypeId Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByAddressTypeId(System.Int32 _addressTypeId, int start, int pageLength,out int count)
		{
			return GetByAddressTypeId(null, _addressTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_AddressType_AddressTypeID key.
		///		FK_CustomerAddress_AddressType_AddressTypeID Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public abstract TList<CustomerAddress> GetByAddressTypeId(TransactionManager transactionManager, System.Int32 _addressTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Customer_CustomerID key.
		///		FK_CustomerAddress_Customer_CustomerID Description: Foreign key constraint referencing Customer.CustomerID.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Customer_CustomerID key.
		///		FK_CustomerAddress_Customer_CustomerID Description: Foreign key constraint referencing Customer.CustomerID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerAddress> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Customer_CustomerID key.
		///		FK_CustomerAddress_Customer_CustomerID Description: Foreign key constraint referencing Customer.CustomerID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Customer_CustomerID key.
		///		fkCustomerAddressCustomerCustomerId Description: Foreign key constraint referencing Customer.CustomerID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Customer_CustomerID key.
		///		fkCustomerAddressCustomerCustomerId Description: Foreign key constraint referencing Customer.CustomerID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public TList<CustomerAddress> GetByCustomerId(System.Int32 _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerAddress_Customer_CustomerID key.
		///		FK_CustomerAddress_Customer_CustomerID Description: Foreign key constraint referencing Customer.CustomerID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.CustomerAddress objects.</returns>
		public abstract TList<CustomerAddress> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.CustomerAddress Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CustomerAddressKey key, int start, int pageLength)
		{
			return GetByCustomerIdAddressId(transactionManager, key.CustomerId, key.AddressId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_CustomerAddress_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CustomerAddress_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CustomerAddress_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CustomerAddress_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CustomerAddress_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CustomerAddress_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.CustomerAddress GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CustomerAddress_CustomerID_AddressID index.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByCustomerIdAddressId(System.Int32 _customerId, System.Int32 _addressId)
		{
			int count = -1;
			return GetByCustomerIdAddressId(null,_customerId, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerAddress_CustomerID_AddressID index.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByCustomerIdAddressId(System.Int32 _customerId, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdAddressId(null, _customerId, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerAddress_CustomerID_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByCustomerIdAddressId(TransactionManager transactionManager, System.Int32 _customerId, System.Int32 _addressId)
		{
			int count = -1;
			return GetByCustomerIdAddressId(transactionManager, _customerId, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerAddress_CustomerID_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByCustomerIdAddressId(TransactionManager transactionManager, System.Int32 _customerId, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdAddressId(transactionManager, _customerId, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerAddress_CustomerID_AddressID index.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CustomerAddress GetByCustomerIdAddressId(System.Int32 _customerId, System.Int32 _addressId, int start, int pageLength, out int count)
		{
			return GetByCustomerIdAddressId(null, _customerId, _addressId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerAddress_CustomerID_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.CustomerAddress GetByCustomerIdAddressId(TransactionManager transactionManager, System.Int32 _customerId, System.Int32 _addressId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CustomerAddress&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CustomerAddress&gt;"/></returns>
		public static TList<CustomerAddress> Fill(IDataReader reader, TList<CustomerAddress> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.CustomerAddress c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerAddress")
					.Append("|").Append((System.Int32)reader[((int)CustomerAddressColumn.CustomerId - 1)])
					.Append("|").Append((System.Int32)reader[((int)CustomerAddressColumn.AddressId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CustomerAddress>(
					key.ToString(), // EntityTrackingKey
					"CustomerAddress",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.CustomerAddress();
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
					c.CustomerId = (System.Int32)reader[((int)CustomerAddressColumn.CustomerId - 1)];
					c.OriginalCustomerId = c.CustomerId;
					c.AddressId = (System.Int32)reader[((int)CustomerAddressColumn.AddressId - 1)];
					c.OriginalAddressId = c.AddressId;
					c.AddressTypeId = (System.Int32)reader[((int)CustomerAddressColumn.AddressTypeId - 1)];
					c.Rowguid = (System.Guid)reader[((int)CustomerAddressColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)CustomerAddressColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.CustomerAddress entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomerId = (System.Int32)reader[((int)CustomerAddressColumn.CustomerId - 1)];
			entity.OriginalCustomerId = (System.Int32)reader["CustomerID"];
			entity.AddressId = (System.Int32)reader[((int)CustomerAddressColumn.AddressId - 1)];
			entity.OriginalAddressId = (System.Int32)reader["AddressID"];
			entity.AddressTypeId = (System.Int32)reader[((int)CustomerAddressColumn.AddressTypeId - 1)];
			entity.Rowguid = (System.Guid)reader[((int)CustomerAddressColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)CustomerAddressColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.CustomerAddress entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.OriginalCustomerId = (System.Int32)dataRow["CustomerID"];
			entity.AddressId = (System.Int32)dataRow["AddressID"];
			entity.OriginalAddressId = (System.Int32)dataRow["AddressID"];
			entity.AddressTypeId = (System.Int32)dataRow["AddressTypeID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CustomerAddress"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CustomerAddress Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CustomerAddress entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AddressIdSource	
			if (CanDeepLoad(entity, "Address|AddressIdSource", deepLoadType, innerList) 
				&& entity.AddressIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AddressId;
				Address tmpEntity = EntityManager.LocateEntity<Address>(EntityLocator.ConstructKeyFromPkItems(typeof(Address), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AddressIdSource = tmpEntity;
				else
					entity.AddressIdSource = DataRepository.AddressProvider.GetByAddressId(transactionManager, entity.AddressId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AddressIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AddressIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AddressProvider.DeepLoad(transactionManager, entity.AddressIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AddressIdSource

			#region AddressTypeIdSource	
			if (CanDeepLoad(entity, "AddressType|AddressTypeIdSource", deepLoadType, innerList) 
				&& entity.AddressTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AddressTypeId;
				AddressType tmpEntity = EntityManager.LocateEntity<AddressType>(EntityLocator.ConstructKeyFromPkItems(typeof(AddressType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AddressTypeIdSource = tmpEntity;
				else
					entity.AddressTypeIdSource = DataRepository.AddressTypeProvider.GetByAddressTypeId(transactionManager, entity.AddressTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AddressTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AddressTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AddressTypeProvider.DeepLoad(transactionManager, entity.AddressTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AddressTypeIdSource

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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.CustomerAddress object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.CustomerAddress instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CustomerAddress Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CustomerAddress entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AddressIdSource
			if (CanDeepSave(entity, "Address|AddressIdSource", deepSaveType, innerList) 
				&& entity.AddressIdSource != null)
			{
				DataRepository.AddressProvider.Save(transactionManager, entity.AddressIdSource);
				entity.AddressId = entity.AddressIdSource.AddressId;
			}
			#endregion 
			
			#region AddressTypeIdSource
			if (CanDeepSave(entity, "AddressType|AddressTypeIdSource", deepSaveType, innerList) 
				&& entity.AddressTypeIdSource != null)
			{
				DataRepository.AddressTypeProvider.Save(transactionManager, entity.AddressTypeIdSource);
				entity.AddressTypeId = entity.AddressTypeIdSource.AddressTypeId;
			}
			#endregion 
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customer|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.CustomerId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region CustomerAddressChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.CustomerAddress</c>
	///</summary>
	public enum CustomerAddressChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Address</c> at AddressIdSource
		///</summary>
		[ChildEntityType(typeof(Address))]
		Address,
			
		///<summary>
		/// Composite Property for <c>AddressType</c> at AddressTypeIdSource
		///</summary>
		[ChildEntityType(typeof(AddressType))]
		AddressType,
			
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
		}
	
	#endregion CustomerAddressChildEntityTypes
	
	#region CustomerAddressFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAddressFilterBuilder : SqlFilterBuilder<CustomerAddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAddressFilterBuilder class.
		/// </summary>
		public CustomerAddressFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerAddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerAddressFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerAddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerAddressFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerAddressFilterBuilder
	
	#region CustomerAddressParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAddressParameterBuilder : ParameterizedSqlFilterBuilder<CustomerAddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAddressParameterBuilder class.
		/// </summary>
		public CustomerAddressParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerAddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerAddressParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerAddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerAddressParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerAddressParameterBuilder
	
	#region CustomerAddressSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomerAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAddress"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomerAddressSortBuilder : SqlSortBuilder<CustomerAddressColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAddressSqlSortBuilder class.
		/// </summary>
		public CustomerAddressSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomerAddressSortBuilder
	
} // end namespace
