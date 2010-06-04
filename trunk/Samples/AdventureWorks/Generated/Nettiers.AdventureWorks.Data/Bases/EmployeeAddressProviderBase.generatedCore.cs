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
	/// This class is the base class for any <see cref="EmployeeAddressProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmployeeAddressProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.EmployeeAddress, Nettiers.AdventureWorks.Entities.EmployeeAddressKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeAddressKey key)
		{
			return Delete(transactionManager, key.EmployeeId, key.AddressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.. Primary Key.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _employeeId, System.Int32 _addressId)
		{
			return Delete(null, _employeeId, _addressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.. Primary Key.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _employeeId, System.Int32 _addressId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Address_AddressID key.
		///		FK_EmployeeAddress_Address_AddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public TList<EmployeeAddress> GetByAddressId(System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(_addressId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Address_AddressID key.
		///		FK_EmployeeAddress_Address_AddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeAddress> GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Address_AddressID key.
		///		FK_EmployeeAddress_Address_AddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public TList<EmployeeAddress> GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Address_AddressID key.
		///		fkEmployeeAddressAddressAddressId Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public TList<EmployeeAddress> GetByAddressId(System.Int32 _addressId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAddressId(null, _addressId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Address_AddressID key.
		///		fkEmployeeAddressAddressAddressId Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public TList<EmployeeAddress> GetByAddressId(System.Int32 _addressId, int start, int pageLength,out int count)
		{
			return GetByAddressId(null, _addressId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Address_AddressID key.
		///		FK_EmployeeAddress_Address_AddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public abstract TList<EmployeeAddress> GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Employee_EmployeeID key.
		///		FK_EmployeeAddress_Employee_EmployeeID Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public TList<EmployeeAddress> GetByEmployeeId(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(_employeeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Employee_EmployeeID key.
		///		FK_EmployeeAddress_Employee_EmployeeID Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeAddress> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Employee_EmployeeID key.
		///		FK_EmployeeAddress_Employee_EmployeeID Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public TList<EmployeeAddress> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Employee_EmployeeID key.
		///		fkEmployeeAddressEmployeeEmployeeId Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public TList<EmployeeAddress> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Employee_EmployeeID key.
		///		fkEmployeeAddressEmployeeEmployeeId Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public TList<EmployeeAddress> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength,out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeAddress_Employee_EmployeeID key.
		///		FK_EmployeeAddress_Employee_EmployeeID Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeAddress objects.</returns>
		public abstract TList<EmployeeAddress> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.EmployeeAddress Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeAddressKey key, int start, int pageLength)
		{
			return GetByEmployeeIdAddressId(transactionManager, key.EmployeeId, key.AddressId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_EmployeeAddress_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_EmployeeAddress_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_EmployeeAddress_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_EmployeeAddress_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_EmployeeAddress_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_EmployeeAddress_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.EmployeeAddress GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_EmployeeAddress_EmployeeID_AddressID index.
		/// </summary>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByEmployeeIdAddressId(System.Int32 _employeeId, System.Int32 _addressId)
		{
			int count = -1;
			return GetByEmployeeIdAddressId(null,_employeeId, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeAddress_EmployeeID_AddressID index.
		/// </summary>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByEmployeeIdAddressId(System.Int32 _employeeId, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdAddressId(null, _employeeId, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeAddress_EmployeeID_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByEmployeeIdAddressId(TransactionManager transactionManager, System.Int32 _employeeId, System.Int32 _addressId)
		{
			int count = -1;
			return GetByEmployeeIdAddressId(transactionManager, _employeeId, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeAddress_EmployeeID_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByEmployeeIdAddressId(TransactionManager transactionManager, System.Int32 _employeeId, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdAddressId(transactionManager, _employeeId, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeAddress_EmployeeID_AddressID index.
		/// </summary>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeAddress GetByEmployeeIdAddressId(System.Int32 _employeeId, System.Int32 _addressId, int start, int pageLength, out int count)
		{
			return GetByEmployeeIdAddressId(null, _employeeId, _addressId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeAddress_EmployeeID_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.EmployeeAddress GetByEmployeeIdAddressId(TransactionManager transactionManager, System.Int32 _employeeId, System.Int32 _addressId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;EmployeeAddress&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;EmployeeAddress&gt;"/></returns>
		public static TList<EmployeeAddress> Fill(IDataReader reader, TList<EmployeeAddress> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.EmployeeAddress c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EmployeeAddress")
					.Append("|").Append((System.Int32)reader[((int)EmployeeAddressColumn.EmployeeId - 1)])
					.Append("|").Append((System.Int32)reader[((int)EmployeeAddressColumn.AddressId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<EmployeeAddress>(
					key.ToString(), // EntityTrackingKey
					"EmployeeAddress",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.EmployeeAddress();
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
					c.EmployeeId = (System.Int32)reader[((int)EmployeeAddressColumn.EmployeeId - 1)];
					c.OriginalEmployeeId = c.EmployeeId;
					c.AddressId = (System.Int32)reader[((int)EmployeeAddressColumn.AddressId - 1)];
					c.OriginalAddressId = c.AddressId;
					c.Rowguid = (System.Guid)reader[((int)EmployeeAddressColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)EmployeeAddressColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.EmployeeAddress entity)
		{
			if (!reader.Read()) return;
			
			entity.EmployeeId = (System.Int32)reader[((int)EmployeeAddressColumn.EmployeeId - 1)];
			entity.OriginalEmployeeId = (System.Int32)reader["EmployeeID"];
			entity.AddressId = (System.Int32)reader[((int)EmployeeAddressColumn.AddressId - 1)];
			entity.OriginalAddressId = (System.Int32)reader["AddressID"];
			entity.Rowguid = (System.Guid)reader[((int)EmployeeAddressColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)EmployeeAddressColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.EmployeeAddress entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeId = (System.Int32)dataRow["EmployeeID"];
			entity.OriginalEmployeeId = (System.Int32)dataRow["EmployeeID"];
			entity.AddressId = (System.Int32)dataRow["AddressID"];
			entity.OriginalAddressId = (System.Int32)dataRow["AddressID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.EmployeeAddress"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.EmployeeAddress Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeAddress entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region EmployeeIdSource	
			if (CanDeepLoad(entity, "Employee|EmployeeIdSource", deepLoadType, innerList) 
				&& entity.EmployeeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.EmployeeId;
				Employee tmpEntity = EntityManager.LocateEntity<Employee>(EntityLocator.ConstructKeyFromPkItems(typeof(Employee), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmployeeIdSource = tmpEntity;
				else
					entity.EmployeeIdSource = DataRepository.EmployeeProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmployeeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmployeeProvider.DeepLoad(transactionManager, entity.EmployeeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion EmployeeIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.EmployeeAddress object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.EmployeeAddress instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.EmployeeAddress Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeAddress entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region EmployeeIdSource
			if (CanDeepSave(entity, "Employee|EmployeeIdSource", deepSaveType, innerList) 
				&& entity.EmployeeIdSource != null)
			{
				DataRepository.EmployeeProvider.Save(transactionManager, entity.EmployeeIdSource);
				entity.EmployeeId = entity.EmployeeIdSource.EmployeeId;
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
	
	#region EmployeeAddressChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.EmployeeAddress</c>
	///</summary>
	public enum EmployeeAddressChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Address</c> at AddressIdSource
		///</summary>
		[ChildEntityType(typeof(Address))]
		Address,
			
		///<summary>
		/// Composite Property for <c>Employee</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
		}
	
	#endregion EmployeeAddressChildEntityTypes
	
	#region EmployeeAddressFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmployeeAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeAddressFilterBuilder : SqlFilterBuilder<EmployeeAddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressFilterBuilder class.
		/// </summary>
		public EmployeeAddressFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeAddressFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeAddressFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeAddressFilterBuilder
	
	#region EmployeeAddressParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmployeeAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeAddress"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeAddressParameterBuilder : ParameterizedSqlFilterBuilder<EmployeeAddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressParameterBuilder class.
		/// </summary>
		public EmployeeAddressParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeAddressParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeAddressParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeAddressParameterBuilder
	
	#region EmployeeAddressSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmployeeAddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeAddress"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmployeeAddressSortBuilder : SqlSortBuilder<EmployeeAddressColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeAddressSqlSortBuilder class.
		/// </summary>
		public EmployeeAddressSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmployeeAddressSortBuilder
	
} // end namespace
