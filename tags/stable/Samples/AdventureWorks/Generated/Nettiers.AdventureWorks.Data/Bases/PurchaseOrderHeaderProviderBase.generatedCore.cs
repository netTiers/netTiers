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
	/// This class is the base class for any <see cref="PurchaseOrderHeaderProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PurchaseOrderHeaderProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.PurchaseOrderHeader, Nettiers.AdventureWorks.Entities.PurchaseOrderHeaderKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.PurchaseOrderHeaderKey key)
		{
			return Delete(transactionManager, key.PurchaseOrderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_purchaseOrderId">Primary key.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _purchaseOrderId)
		{
			return Delete(null, _purchaseOrderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _purchaseOrderId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderHeader_ShipMethod_ShipMethodID key.
		///		FK_PurchaseOrderHeader_ShipMethod_ShipMethodID Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderHeader objects.</returns>
		public TList<PurchaseOrderHeader> GetByShipMethodId(System.Int32 _shipMethodId)
		{
			int count = -1;
			return GetByShipMethodId(_shipMethodId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderHeader_ShipMethod_ShipMethodID key.
		///		FK_PurchaseOrderHeader_ShipMethod_ShipMethodID Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderHeader objects.</returns>
		/// <remarks></remarks>
		public TList<PurchaseOrderHeader> GetByShipMethodId(TransactionManager transactionManager, System.Int32 _shipMethodId)
		{
			int count = -1;
			return GetByShipMethodId(transactionManager, _shipMethodId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderHeader_ShipMethod_ShipMethodID key.
		///		FK_PurchaseOrderHeader_ShipMethod_ShipMethodID Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderHeader objects.</returns>
		public TList<PurchaseOrderHeader> GetByShipMethodId(TransactionManager transactionManager, System.Int32 _shipMethodId, int start, int pageLength)
		{
			int count = -1;
			return GetByShipMethodId(transactionManager, _shipMethodId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderHeader_ShipMethod_ShipMethodID key.
		///		fkPurchaseOrderHeaderShipMethodShipMethodId Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderHeader objects.</returns>
		public TList<PurchaseOrderHeader> GetByShipMethodId(System.Int32 _shipMethodId, int start, int pageLength)
		{
			int count =  -1;
			return GetByShipMethodId(null, _shipMethodId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderHeader_ShipMethod_ShipMethodID key.
		///		fkPurchaseOrderHeaderShipMethodShipMethodId Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderHeader objects.</returns>
		public TList<PurchaseOrderHeader> GetByShipMethodId(System.Int32 _shipMethodId, int start, int pageLength,out int count)
		{
			return GetByShipMethodId(null, _shipMethodId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_PurchaseOrderHeader_ShipMethod_ShipMethodID key.
		///		FK_PurchaseOrderHeader_ShipMethod_ShipMethodID Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.PurchaseOrderHeader objects.</returns>
		public abstract TList<PurchaseOrderHeader> GetByShipMethodId(TransactionManager transactionManager, System.Int32 _shipMethodId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.PurchaseOrderHeader Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.PurchaseOrderHeaderKey key, int start, int pageLength)
		{
			return GetByPurchaseOrderId(transactionManager, key.PurchaseOrderId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_PurchaseOrderHeader_EmployeeID index.
		/// </summary>
		/// <param name="_employeeId">Employee who created the purchase order. Foreign key to Employee.EmployeeID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByEmployeeId(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(null,_employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_EmployeeID index.
		/// </summary>
		/// <param name="_employeeId">Employee who created the purchase order. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee who created the purchase order. Foreign key to Employee.EmployeeID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee who created the purchase order. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_EmployeeID index.
		/// </summary>
		/// <param name="_employeeId">Employee who created the purchase order. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength, out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee who created the purchase order. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public abstract TList<PurchaseOrderHeader> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_PurchaseOrderHeader_VendorID index.
		/// </summary>
		/// <param name="_vendorId">Vendor with whom the purchase order is placed. Foreign key to Vendor.VendorID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByVendorId(System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(null,_vendorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_VendorID index.
		/// </summary>
		/// <param name="_vendorId">Vendor with whom the purchase order is placed. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByVendorId(System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorId(null, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Vendor with whom the purchase order is placed. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Vendor with whom the purchase order is placed. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_VendorID index.
		/// </summary>
		/// <param name="_vendorId">Vendor with whom the purchase order is placed. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public TList<PurchaseOrderHeader> GetByVendorId(System.Int32 _vendorId, int start, int pageLength, out int count)
		{
			return GetByVendorId(null, _vendorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_PurchaseOrderHeader_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Vendor with whom the purchase order is placed. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;PurchaseOrderHeader&gt;"/> class.</returns>
		public abstract TList<PurchaseOrderHeader> GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_PurchaseOrderHeader_PurchaseOrderID index.
		/// </summary>
		/// <param name="_purchaseOrderId">Primary key.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderHeader GetByPurchaseOrderId(System.Int32 _purchaseOrderId)
		{
			int count = -1;
			return GetByPurchaseOrderId(null,_purchaseOrderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderHeader_PurchaseOrderID index.
		/// </summary>
		/// <param name="_purchaseOrderId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderHeader GetByPurchaseOrderId(System.Int32 _purchaseOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetByPurchaseOrderId(null, _purchaseOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderHeader_PurchaseOrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderHeader GetByPurchaseOrderId(TransactionManager transactionManager, System.Int32 _purchaseOrderId)
		{
			int count = -1;
			return GetByPurchaseOrderId(transactionManager, _purchaseOrderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderHeader_PurchaseOrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderHeader GetByPurchaseOrderId(TransactionManager transactionManager, System.Int32 _purchaseOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetByPurchaseOrderId(transactionManager, _purchaseOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderHeader_PurchaseOrderID index.
		/// </summary>
		/// <param name="_purchaseOrderId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.PurchaseOrderHeader GetByPurchaseOrderId(System.Int32 _purchaseOrderId, int start, int pageLength, out int count)
		{
			return GetByPurchaseOrderId(null, _purchaseOrderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PurchaseOrderHeader_PurchaseOrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseOrderId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.PurchaseOrderHeader GetByPurchaseOrderId(TransactionManager transactionManager, System.Int32 _purchaseOrderId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;PurchaseOrderHeader&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;PurchaseOrderHeader&gt;"/></returns>
		public static TList<PurchaseOrderHeader> Fill(IDataReader reader, TList<PurchaseOrderHeader> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.PurchaseOrderHeader c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("PurchaseOrderHeader")
					.Append("|").Append((System.Int32)reader[((int)PurchaseOrderHeaderColumn.PurchaseOrderId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<PurchaseOrderHeader>(
					key.ToString(), // EntityTrackingKey
					"PurchaseOrderHeader",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.PurchaseOrderHeader();
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
					c.PurchaseOrderId = (System.Int32)reader[((int)PurchaseOrderHeaderColumn.PurchaseOrderId - 1)];
					c.RevisionNumber = (System.Byte)reader[((int)PurchaseOrderHeaderColumn.RevisionNumber - 1)];
					c.Status = (System.Byte)reader[((int)PurchaseOrderHeaderColumn.Status - 1)];
					c.EmployeeId = (System.Int32)reader[((int)PurchaseOrderHeaderColumn.EmployeeId - 1)];
					c.VendorId = (System.Int32)reader[((int)PurchaseOrderHeaderColumn.VendorId - 1)];
					c.ShipMethodId = (System.Int32)reader[((int)PurchaseOrderHeaderColumn.ShipMethodId - 1)];
					c.OrderDate = (System.DateTime)reader[((int)PurchaseOrderHeaderColumn.OrderDate - 1)];
					c.ShipDate = (reader.IsDBNull(((int)PurchaseOrderHeaderColumn.ShipDate - 1)))?null:(System.DateTime?)reader[((int)PurchaseOrderHeaderColumn.ShipDate - 1)];
					c.SubTotal = (System.Decimal)reader[((int)PurchaseOrderHeaderColumn.SubTotal - 1)];
					c.TaxAmt = (System.Decimal)reader[((int)PurchaseOrderHeaderColumn.TaxAmt - 1)];
					c.Freight = (System.Decimal)reader[((int)PurchaseOrderHeaderColumn.Freight - 1)];
					c.TotalDue = (System.Decimal)reader[((int)PurchaseOrderHeaderColumn.TotalDue - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)PurchaseOrderHeaderColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.PurchaseOrderHeader entity)
		{
			if (!reader.Read()) return;
			
			entity.PurchaseOrderId = (System.Int32)reader[((int)PurchaseOrderHeaderColumn.PurchaseOrderId - 1)];
			entity.RevisionNumber = (System.Byte)reader[((int)PurchaseOrderHeaderColumn.RevisionNumber - 1)];
			entity.Status = (System.Byte)reader[((int)PurchaseOrderHeaderColumn.Status - 1)];
			entity.EmployeeId = (System.Int32)reader[((int)PurchaseOrderHeaderColumn.EmployeeId - 1)];
			entity.VendorId = (System.Int32)reader[((int)PurchaseOrderHeaderColumn.VendorId - 1)];
			entity.ShipMethodId = (System.Int32)reader[((int)PurchaseOrderHeaderColumn.ShipMethodId - 1)];
			entity.OrderDate = (System.DateTime)reader[((int)PurchaseOrderHeaderColumn.OrderDate - 1)];
			entity.ShipDate = (reader.IsDBNull(((int)PurchaseOrderHeaderColumn.ShipDate - 1)))?null:(System.DateTime?)reader[((int)PurchaseOrderHeaderColumn.ShipDate - 1)];
			entity.SubTotal = (System.Decimal)reader[((int)PurchaseOrderHeaderColumn.SubTotal - 1)];
			entity.TaxAmt = (System.Decimal)reader[((int)PurchaseOrderHeaderColumn.TaxAmt - 1)];
			entity.Freight = (System.Decimal)reader[((int)PurchaseOrderHeaderColumn.Freight - 1)];
			entity.TotalDue = (System.Decimal)reader[((int)PurchaseOrderHeaderColumn.TotalDue - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)PurchaseOrderHeaderColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.PurchaseOrderHeader entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PurchaseOrderId = (System.Int32)dataRow["PurchaseOrderID"];
			entity.RevisionNumber = (System.Byte)dataRow["RevisionNumber"];
			entity.Status = (System.Byte)dataRow["Status"];
			entity.EmployeeId = (System.Int32)dataRow["EmployeeID"];
			entity.VendorId = (System.Int32)dataRow["VendorID"];
			entity.ShipMethodId = (System.Int32)dataRow["ShipMethodID"];
			entity.OrderDate = (System.DateTime)dataRow["OrderDate"];
			entity.ShipDate = Convert.IsDBNull(dataRow["ShipDate"]) ? null : (System.DateTime?)dataRow["ShipDate"];
			entity.SubTotal = (System.Decimal)dataRow["SubTotal"];
			entity.TaxAmt = (System.Decimal)dataRow["TaxAmt"];
			entity.Freight = (System.Decimal)dataRow["Freight"];
			entity.TotalDue = (System.Decimal)dataRow["TotalDue"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.PurchaseOrderHeader"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.PurchaseOrderHeader Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.PurchaseOrderHeader entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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

			#region ShipMethodIdSource	
			if (CanDeepLoad(entity, "ShipMethod|ShipMethodIdSource", deepLoadType, innerList) 
				&& entity.ShipMethodIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ShipMethodId;
				ShipMethod tmpEntity = EntityManager.LocateEntity<ShipMethod>(EntityLocator.ConstructKeyFromPkItems(typeof(ShipMethod), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShipMethodIdSource = tmpEntity;
				else
					entity.ShipMethodIdSource = DataRepository.ShipMethodProvider.GetByShipMethodId(transactionManager, entity.ShipMethodId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ShipMethodIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ShipMethodIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ShipMethodProvider.DeepLoad(transactionManager, entity.ShipMethodIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ShipMethodIdSource

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
			// Deep load child collections  - Call GetByPurchaseOrderId methods when available
			
			#region PurchaseOrderDetailCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PurchaseOrderDetail>|PurchaseOrderDetailCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PurchaseOrderDetailCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PurchaseOrderDetailCollection = DataRepository.PurchaseOrderDetailProvider.GetByPurchaseOrderId(transactionManager, entity.PurchaseOrderId);

				if (deep && entity.PurchaseOrderDetailCollection.Count > 0)
				{
					deepHandles.Add("PurchaseOrderDetailCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PurchaseOrderDetail>) DataRepository.PurchaseOrderDetailProvider.DeepLoad,
						new object[] { transactionManager, entity.PurchaseOrderDetailCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.PurchaseOrderHeader object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.PurchaseOrderHeader instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.PurchaseOrderHeader Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.PurchaseOrderHeader entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region EmployeeIdSource
			if (CanDeepSave(entity, "Employee|EmployeeIdSource", deepSaveType, innerList) 
				&& entity.EmployeeIdSource != null)
			{
				DataRepository.EmployeeProvider.Save(transactionManager, entity.EmployeeIdSource);
				entity.EmployeeId = entity.EmployeeIdSource.EmployeeId;
			}
			#endregion 
			
			#region ShipMethodIdSource
			if (CanDeepSave(entity, "ShipMethod|ShipMethodIdSource", deepSaveType, innerList) 
				&& entity.ShipMethodIdSource != null)
			{
				DataRepository.ShipMethodProvider.Save(transactionManager, entity.ShipMethodIdSource);
				entity.ShipMethodId = entity.ShipMethodIdSource.ShipMethodId;
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
	
			#region List<PurchaseOrderDetail>
				if (CanDeepSave(entity.PurchaseOrderDetailCollection, "List<PurchaseOrderDetail>|PurchaseOrderDetailCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PurchaseOrderDetail child in entity.PurchaseOrderDetailCollection)
					{
						if(child.PurchaseOrderIdSource != null)
						{
							child.PurchaseOrderId = child.PurchaseOrderIdSource.PurchaseOrderId;
						}
						else
						{
							child.PurchaseOrderId = entity.PurchaseOrderId;
						}

					}

					if (entity.PurchaseOrderDetailCollection.Count > 0 || entity.PurchaseOrderDetailCollection.DeletedItems.Count > 0)
					{
						//DataRepository.PurchaseOrderDetailProvider.Save(transactionManager, entity.PurchaseOrderDetailCollection);
						
						deepHandles.Add("PurchaseOrderDetailCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< PurchaseOrderDetail >) DataRepository.PurchaseOrderDetailProvider.DeepSave,
							new object[] { transactionManager, entity.PurchaseOrderDetailCollection, deepSaveType, childTypes, innerList }
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
	
	#region PurchaseOrderHeaderChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.PurchaseOrderHeader</c>
	///</summary>
	public enum PurchaseOrderHeaderChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Employee</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
			
		///<summary>
		/// Composite Property for <c>ShipMethod</c> at ShipMethodIdSource
		///</summary>
		[ChildEntityType(typeof(ShipMethod))]
		ShipMethod,
			
		///<summary>
		/// Composite Property for <c>Vendor</c> at VendorIdSource
		///</summary>
		[ChildEntityType(typeof(Vendor))]
		Vendor,
	
		///<summary>
		/// Collection of <c>PurchaseOrderHeader</c> as OneToMany for PurchaseOrderDetailCollection
		///</summary>
		[ChildEntityType(typeof(TList<PurchaseOrderDetail>))]
		PurchaseOrderDetailCollection,
	}
	
	#endregion PurchaseOrderHeaderChildEntityTypes
	
	#region PurchaseOrderHeaderFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PurchaseOrderHeaderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderHeaderFilterBuilder : SqlFilterBuilder<PurchaseOrderHeaderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderFilterBuilder class.
		/// </summary>
		public PurchaseOrderHeaderFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PurchaseOrderHeaderFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PurchaseOrderHeaderFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PurchaseOrderHeaderFilterBuilder
	
	#region PurchaseOrderHeaderParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PurchaseOrderHeaderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PurchaseOrderHeaderParameterBuilder : ParameterizedSqlFilterBuilder<PurchaseOrderHeaderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderParameterBuilder class.
		/// </summary>
		public PurchaseOrderHeaderParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PurchaseOrderHeaderParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PurchaseOrderHeaderParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PurchaseOrderHeaderParameterBuilder
	
	#region PurchaseOrderHeaderSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;PurchaseOrderHeaderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PurchaseOrderHeader"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class PurchaseOrderHeaderSortBuilder : SqlSortBuilder<PurchaseOrderHeaderColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PurchaseOrderHeaderSqlSortBuilder class.
		/// </summary>
		public PurchaseOrderHeaderSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion PurchaseOrderHeaderSortBuilder
	
} // end namespace
