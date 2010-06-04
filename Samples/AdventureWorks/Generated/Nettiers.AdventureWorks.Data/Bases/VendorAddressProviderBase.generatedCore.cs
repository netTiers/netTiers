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
	/// This class is the base class for any <see cref="VendorAddressProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class VendorAddressProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.VendorAddress, Nettiers.AdventureWorks.Entities.VendorAddressKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorAddressKey key)
		{
			return Delete(transactionManager, key.VendorId, key.AddressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.. Primary Key.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _vendorId, System.Int32 _addressId)
		{
			return Delete(null, _vendorId, _addressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.. Primary Key.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _vendorId, System.Int32 _addressId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_AddressType_AddressTypeID key.
		///		FK_VendorAddress_AddressType_AddressTypeID Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public TList<VendorAddress> GetByAddressTypeId(System.Int32 _addressTypeId)
		{
			int count = -1;
			return GetByAddressTypeId(_addressTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_AddressType_AddressTypeID key.
		///		FK_VendorAddress_AddressType_AddressTypeID Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		/// <remarks></remarks>
		public TList<VendorAddress> GetByAddressTypeId(TransactionManager transactionManager, System.Int32 _addressTypeId)
		{
			int count = -1;
			return GetByAddressTypeId(transactionManager, _addressTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_AddressType_AddressTypeID key.
		///		FK_VendorAddress_AddressType_AddressTypeID Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public TList<VendorAddress> GetByAddressTypeId(TransactionManager transactionManager, System.Int32 _addressTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressTypeId(transactionManager, _addressTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_AddressType_AddressTypeID key.
		///		fkVendorAddressAddressTypeAddressTypeId Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public TList<VendorAddress> GetByAddressTypeId(System.Int32 _addressTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAddressTypeId(null, _addressTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_AddressType_AddressTypeID key.
		///		fkVendorAddressAddressTypeAddressTypeId Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public TList<VendorAddress> GetByAddressTypeId(System.Int32 _addressTypeId, int start, int pageLength,out int count)
		{
			return GetByAddressTypeId(null, _addressTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_AddressType_AddressTypeID key.
		///		FK_VendorAddress_AddressType_AddressTypeID Description: Foreign key constraint referencing AddressType.AddressTypeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressTypeId">Address type. Foreign key to AddressType.AddressTypeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public abstract TList<VendorAddress> GetByAddressTypeId(TransactionManager transactionManager, System.Int32 _addressTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_Vendor_VendorID key.
		///		FK_VendorAddress_Vendor_VendorID Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public TList<VendorAddress> GetByVendorId(System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(_vendorId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_Vendor_VendorID key.
		///		FK_VendorAddress_Vendor_VendorID Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		/// <remarks></remarks>
		public TList<VendorAddress> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_Vendor_VendorID key.
		///		FK_VendorAddress_Vendor_VendorID Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public TList<VendorAddress> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_Vendor_VendorID key.
		///		fkVendorAddressVendorVendorId Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public TList<VendorAddress> GetByVendorId(System.Int32 _vendorId, int start, int pageLength)
		{
			int count =  -1;
			return GetByVendorId(null, _vendorId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_Vendor_VendorID key.
		///		fkVendorAddressVendorVendorId Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public TList<VendorAddress> GetByVendorId(System.Int32 _vendorId, int start, int pageLength,out int count)
		{
			return GetByVendorId(null, _vendorId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorAddress_Vendor_VendorID key.
		///		FK_VendorAddress_Vendor_VendorID Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorAddress objects.</returns>
		public abstract TList<VendorAddress> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.VendorAddress Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorAddressKey key, int start, int pageLength)
		{
			return GetByVendorIdAddressId(transactionManager, key.VendorId, key.AddressId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_VendorAddress_AddressID index.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorAddress&gt;"/> class.</returns>
		public TList<VendorAddress> GetByAddressId(System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(null,_addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorAddress_AddressID index.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorAddress&gt;"/> class.</returns>
		public TList<VendorAddress> GetByAddressId(System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(null, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorAddress_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorAddress&gt;"/> class.</returns>
		public TList<VendorAddress> GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorAddress_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorAddress&gt;"/> class.</returns>
		public TList<VendorAddress> GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorAddress_AddressID index.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorAddress&gt;"/> class.</returns>
		public TList<VendorAddress> GetByAddressId(System.Int32 _addressId, int start, int pageLength, out int count)
		{
			return GetByAddressId(null, _addressId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorAddress_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorAddress&gt;"/> class.</returns>
		public abstract TList<VendorAddress> GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_VendorAddress_VendorID_AddressID index.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorAddress GetByVendorIdAddressId(System.Int32 _vendorId, System.Int32 _addressId)
		{
			int count = -1;
			return GetByVendorIdAddressId(null,_vendorId, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorAddress_VendorID_AddressID index.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorAddress GetByVendorIdAddressId(System.Int32 _vendorId, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdAddressId(null, _vendorId, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorAddress_VendorID_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorAddress GetByVendorIdAddressId(TransactionManager transactionManager, System.Int32 _vendorId, System.Int32 _addressId)
		{
			int count = -1;
			return GetByVendorIdAddressId(transactionManager, _vendorId, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorAddress_VendorID_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorAddress GetByVendorIdAddressId(TransactionManager transactionManager, System.Int32 _vendorId, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdAddressId(transactionManager, _vendorId, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorAddress_VendorID_AddressID index.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorAddress GetByVendorIdAddressId(System.Int32 _vendorId, System.Int32 _addressId, int start, int pageLength, out int count)
		{
			return GetByVendorIdAddressId(null, _vendorId, _addressId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorAddress_VendorID_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.VendorAddress GetByVendorIdAddressId(TransactionManager transactionManager, System.Int32 _vendorId, System.Int32 _addressId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;VendorAddress&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;VendorAddress&gt;"/></returns>
		public static TList<VendorAddress> Fill(IDataReader reader, TList<VendorAddress> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.VendorAddress c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("VendorAddress")
					.Append("|").Append((System.Int32)reader[((int)VendorAddressColumn.VendorId - 1)])
					.Append("|").Append((System.Int32)reader[((int)VendorAddressColumn.AddressId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<VendorAddress>(
					key.ToString(), // EntityTrackingKey
					"VendorAddress",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.VendorAddress();
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
					c.VendorId = (System.Int32)reader[((int)VendorAddressColumn.VendorId - 1)];
					c.OriginalVendorId = c.VendorId;
					c.AddressId = (System.Int32)reader[((int)VendorAddressColumn.AddressId - 1)];
					c.OriginalAddressId = c.AddressId;
					c.AddressTypeId = (System.Int32)reader[((int)VendorAddressColumn.AddressTypeId - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)VendorAddressColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.VendorAddress entity)
		{
			if (!reader.Read()) return;
			
			entity.VendorId = (System.Int32)reader[((int)VendorAddressColumn.VendorId - 1)];
			entity.OriginalVendorId = (System.Int32)reader["VendorID"];
			entity.AddressId = (System.Int32)reader[((int)VendorAddressColumn.AddressId - 1)];
			entity.OriginalAddressId = (System.Int32)reader["AddressID"];
			entity.AddressTypeId = (System.Int32)reader[((int)VendorAddressColumn.AddressTypeId - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)VendorAddressColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.VendorAddress entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.VendorId = (System.Int32)dataRow["VendorID"];
			entity.OriginalVendorId = (System.Int32)dataRow["VendorID"];
			entity.AddressId = (System.Int32)dataRow["AddressID"];
			entity.OriginalAddressId = (System.Int32)dataRow["AddressID"];
			entity.AddressTypeId = (System.Int32)dataRow["AddressTypeID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.VendorAddress"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.VendorAddress Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorAddress entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region VendorIdSource	
			if (CanDeepLoad(entity, "Vendor|VendorIdSource", deepLoadType, innerList) 
				&& entity.VendorIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.VendorId;
				Vendor tmpEntity = EntityManager.LocateEntity<Vendor>(EntityLocator.ConstructKeyFromPkItems(typeof(Vendor), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.VendorIdSource = tmpEntity;
				else
					entity.VendorIdSource = DataRepository.VendorProvider.GetByVendorId(transactionManager, entity.VendorId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.VendorIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.VendorProvider.DeepLoad(transactionManager, entity.VendorIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion VendorIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.VendorAddress object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.VendorAddress instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.VendorAddress Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorAddress entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region VendorIdSource
			if (CanDeepSave(entity, "Vendor|VendorIdSource", deepSaveType, innerList) 
				&& entity.VendorIdSource != null)
			{
				DataRepository.VendorProvider.Save(transactionManager, entity.VendorIdSource);
				entity.VendorId = entity.VendorIdSource.VendorId;
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
	
	#region VendorAddressChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.VendorAddress</c>
	///</summary>
	public enum VendorAddressChildEntityTypes
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
		/// Composite Property for <c>Vendor</c> at VendorIdSource
		///</summary>
		[ChildEntityType(typeof(Vendor))]
		Vendor,
		}
	
	#endregion VendorAddressChildEntityTypes
	
	#region VendorAddressFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;VendorAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorAddressFilterBuilder : SqlFilterBuilder<VendorAddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorAddressFilterBuilder class.
		/// </summary>
		public VendorAddressFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorAddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorAddressFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorAddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorAddressFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorAddressFilterBuilder
	
	#region VendorAddressParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;VendorAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorAddressParameterBuilder : ParameterizedSqlFilterBuilder<VendorAddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorAddressParameterBuilder class.
		/// </summary>
		public VendorAddressParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorAddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorAddressParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorAddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorAddressParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorAddressParameterBuilder
	
	#region VendorAddressSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;VendorAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorAddress"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VendorAddressSortBuilder : SqlSortBuilder<VendorAddressColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorAddressSqlSortBuilder class.
		/// </summary>
		public VendorAddressSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VendorAddressSortBuilder
	
} // end namespace
