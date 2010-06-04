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
	/// This class is the base class for any <see cref="VendorContactProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class VendorContactProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.VendorContact, Nettiers.AdventureWorks.Entities.VendorContactKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorContactKey key)
		{
			return Delete(transactionManager, key.VendorId, key.ContactId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_vendorId">Primary key.. Primary Key.</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _vendorId, System.Int32 _contactId)
		{
			return Delete(null, _vendorId, _contactId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key.. Primary Key.</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _vendorId, System.Int32 _contactId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorContact_Vendor_VendorID key.
		///		FK_VendorContact_Vendor_VendorID Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="_vendorId">Primary key.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorContact objects.</returns>
		public TList<VendorContact> GetByVendorId(System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(_vendorId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorContact_Vendor_VendorID key.
		///		FK_VendorContact_Vendor_VendorID Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorContact objects.</returns>
		/// <remarks></remarks>
		public TList<VendorContact> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorContact_Vendor_VendorID key.
		///		FK_VendorContact_Vendor_VendorID Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorContact objects.</returns>
		public TList<VendorContact> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorContact_Vendor_VendorID key.
		///		fkVendorContactVendorVendorId Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorContact objects.</returns>
		public TList<VendorContact> GetByVendorId(System.Int32 _vendorId, int start, int pageLength)
		{
			int count =  -1;
			return GetByVendorId(null, _vendorId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorContact_Vendor_VendorID key.
		///		fkVendorContactVendorVendorId Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorContact objects.</returns>
		public TList<VendorContact> GetByVendorId(System.Int32 _vendorId, int start, int pageLength,out int count)
		{
			return GetByVendorId(null, _vendorId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_VendorContact_Vendor_VendorID key.
		///		FK_VendorContact_Vendor_VendorID Description: Foreign key constraint referencing Vendor.VendorID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.VendorContact objects.</returns>
		public abstract TList<VendorContact> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.VendorContact Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorContactKey key, int start, int pageLength)
		{
			return GetByVendorIdContactId(transactionManager, key.VendorId, key.ContactId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_VendorContact_ContactID index.
		/// </summary>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactId(System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(null,_contactId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactID index.
		/// </summary>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactId(System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactId(null, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactID index.
		/// </summary>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactId(System.Int32 _contactId, int start, int pageLength, out int count)
		{
			return GetByContactId(null, _contactId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public abstract TList<VendorContact> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_VendorContact_ContactTypeID index.
		/// </summary>
		/// <param name="_contactTypeId">Contact type such as sales manager, or sales agent.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactTypeId(System.Int32 _contactTypeId)
		{
			int count = -1;
			return GetByContactTypeId(null,_contactTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactTypeID index.
		/// </summary>
		/// <param name="_contactTypeId">Contact type such as sales manager, or sales agent.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactTypeId(System.Int32 _contactTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactTypeId(null, _contactTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactTypeId">Contact type such as sales manager, or sales agent.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactTypeId(TransactionManager transactionManager, System.Int32 _contactTypeId)
		{
			int count = -1;
			return GetByContactTypeId(transactionManager, _contactTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactTypeId">Contact type such as sales manager, or sales agent.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactTypeId(TransactionManager transactionManager, System.Int32 _contactTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactTypeId(transactionManager, _contactTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactTypeID index.
		/// </summary>
		/// <param name="_contactTypeId">Contact type such as sales manager, or sales agent.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public TList<VendorContact> GetByContactTypeId(System.Int32 _contactTypeId, int start, int pageLength, out int count)
		{
			return GetByContactTypeId(null, _contactTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_VendorContact_ContactTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactTypeId">Contact type such as sales manager, or sales agent.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;VendorContact&gt;"/> class.</returns>
		public abstract TList<VendorContact> GetByContactTypeId(TransactionManager transactionManager, System.Int32 _contactTypeId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_VendorContact_VendorID_ContactID index.
		/// </summary>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorContact GetByVendorIdContactId(System.Int32 _vendorId, System.Int32 _contactId)
		{
			int count = -1;
			return GetByVendorIdContactId(null,_vendorId, _contactId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorContact_VendorID_ContactID index.
		/// </summary>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorContact GetByVendorIdContactId(System.Int32 _vendorId, System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdContactId(null, _vendorId, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorContact_VendorID_ContactID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorContact GetByVendorIdContactId(TransactionManager transactionManager, System.Int32 _vendorId, System.Int32 _contactId)
		{
			int count = -1;
			return GetByVendorIdContactId(transactionManager, _vendorId, _contactId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorContact_VendorID_ContactID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorContact GetByVendorIdContactId(TransactionManager transactionManager, System.Int32 _vendorId, System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdContactId(transactionManager, _vendorId, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorContact_VendorID_ContactID index.
		/// </summary>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.VendorContact GetByVendorIdContactId(System.Int32 _vendorId, System.Int32 _contactId, int start, int pageLength, out int count)
		{
			return GetByVendorIdContactId(null, _vendorId, _contactId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_VendorContact_VendorID_ContactID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.VendorContact GetByVendorIdContactId(TransactionManager transactionManager, System.Int32 _vendorId, System.Int32 _contactId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;VendorContact&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;VendorContact&gt;"/></returns>
		public static TList<VendorContact> Fill(IDataReader reader, TList<VendorContact> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.VendorContact c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("VendorContact")
					.Append("|").Append((System.Int32)reader[((int)VendorContactColumn.VendorId - 1)])
					.Append("|").Append((System.Int32)reader[((int)VendorContactColumn.ContactId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<VendorContact>(
					key.ToString(), // EntityTrackingKey
					"VendorContact",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.VendorContact();
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
					c.VendorId = (System.Int32)reader[((int)VendorContactColumn.VendorId - 1)];
					c.OriginalVendorId = c.VendorId;
					c.ContactId = (System.Int32)reader[((int)VendorContactColumn.ContactId - 1)];
					c.OriginalContactId = c.ContactId;
					c.ContactTypeId = (System.Int32)reader[((int)VendorContactColumn.ContactTypeId - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)VendorContactColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.VendorContact entity)
		{
			if (!reader.Read()) return;
			
			entity.VendorId = (System.Int32)reader[((int)VendorContactColumn.VendorId - 1)];
			entity.OriginalVendorId = (System.Int32)reader["VendorID"];
			entity.ContactId = (System.Int32)reader[((int)VendorContactColumn.ContactId - 1)];
			entity.OriginalContactId = (System.Int32)reader["ContactID"];
			entity.ContactTypeId = (System.Int32)reader[((int)VendorContactColumn.ContactTypeId - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)VendorContactColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.VendorContact entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.VendorId = (System.Int32)dataRow["VendorID"];
			entity.OriginalVendorId = (System.Int32)dataRow["VendorID"];
			entity.ContactId = (System.Int32)dataRow["ContactID"];
			entity.OriginalContactId = (System.Int32)dataRow["ContactID"];
			entity.ContactTypeId = (System.Int32)dataRow["ContactTypeID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.VendorContact"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.VendorContact Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorContact entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ContactIdSource	
			if (CanDeepLoad(entity, "Contact|ContactIdSource", deepLoadType, innerList) 
				&& entity.ContactIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ContactId;
				Contact tmpEntity = EntityManager.LocateEntity<Contact>(EntityLocator.ConstructKeyFromPkItems(typeof(Contact), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ContactIdSource = tmpEntity;
				else
					entity.ContactIdSource = DataRepository.ContactProvider.GetByContactId(transactionManager, entity.ContactId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ContactIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ContactIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ContactProvider.DeepLoad(transactionManager, entity.ContactIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ContactIdSource

			#region ContactTypeIdSource	
			if (CanDeepLoad(entity, "ContactType|ContactTypeIdSource", deepLoadType, innerList) 
				&& entity.ContactTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ContactTypeId;
				ContactType tmpEntity = EntityManager.LocateEntity<ContactType>(EntityLocator.ConstructKeyFromPkItems(typeof(ContactType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ContactTypeIdSource = tmpEntity;
				else
					entity.ContactTypeIdSource = DataRepository.ContactTypeProvider.GetByContactTypeId(transactionManager, entity.ContactTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ContactTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ContactTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ContactTypeProvider.DeepLoad(transactionManager, entity.ContactTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ContactTypeIdSource

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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.VendorContact object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.VendorContact instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.VendorContact Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorContact entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ContactIdSource
			if (CanDeepSave(entity, "Contact|ContactIdSource", deepSaveType, innerList) 
				&& entity.ContactIdSource != null)
			{
				DataRepository.ContactProvider.Save(transactionManager, entity.ContactIdSource);
				entity.ContactId = entity.ContactIdSource.ContactId;
			}
			#endregion 
			
			#region ContactTypeIdSource
			if (CanDeepSave(entity, "ContactType|ContactTypeIdSource", deepSaveType, innerList) 
				&& entity.ContactTypeIdSource != null)
			{
				DataRepository.ContactTypeProvider.Save(transactionManager, entity.ContactTypeIdSource);
				entity.ContactTypeId = entity.ContactTypeIdSource.ContactTypeId;
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
	
	#region VendorContactChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.VendorContact</c>
	///</summary>
	public enum VendorContactChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Contact</c> at ContactIdSource
		///</summary>
		[ChildEntityType(typeof(Contact))]
		Contact,
			
		///<summary>
		/// Composite Property for <c>ContactType</c> at ContactTypeIdSource
		///</summary>
		[ChildEntityType(typeof(ContactType))]
		ContactType,
			
		///<summary>
		/// Composite Property for <c>Vendor</c> at VendorIdSource
		///</summary>
		[ChildEntityType(typeof(Vendor))]
		Vendor,
		}
	
	#endregion VendorContactChildEntityTypes
	
	#region VendorContactFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;VendorContactColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorContactFilterBuilder : SqlFilterBuilder<VendorContactColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorContactFilterBuilder class.
		/// </summary>
		public VendorContactFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorContactFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorContactFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorContactFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorContactFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorContactFilterBuilder
	
	#region VendorContactParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;VendorContactColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorContact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorContactParameterBuilder : ParameterizedSqlFilterBuilder<VendorContactColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorContactParameterBuilder class.
		/// </summary>
		public VendorContactParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorContactParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorContactParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorContactParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorContactParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorContactParameterBuilder
	
	#region VendorContactSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;VendorContactColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VendorContact"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VendorContactSortBuilder : SqlSortBuilder<VendorContactColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorContactSqlSortBuilder class.
		/// </summary>
		public VendorContactSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VendorContactSortBuilder
	
} // end namespace
