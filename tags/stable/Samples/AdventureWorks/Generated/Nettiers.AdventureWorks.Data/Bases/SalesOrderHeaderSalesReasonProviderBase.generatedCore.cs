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
	/// This class is the base class for any <see cref="SalesOrderHeaderSalesReasonProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesOrderHeaderSalesReasonProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason, Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReasonKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReasonKey key)
		{
			return Delete(transactionManager, key.SalesOrderId, key.SalesReasonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.. Primary Key.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salesOrderId, System.Int32 _salesReasonId)
		{
			return Delete(null, _salesOrderId, _salesReasonId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.. Primary Key.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salesOrderId, System.Int32 _salesReasonId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID key.
		///		FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID Description: Foreign key constraint referencing SalesOrderHeader.SalesOrderID.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public TList<SalesOrderHeaderSalesReason> GetBySalesOrderId(System.Int32 _salesOrderId)
		{
			int count = -1;
			return GetBySalesOrderId(_salesOrderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID key.
		///		FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID Description: Foreign key constraint referencing SalesOrderHeader.SalesOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderHeaderSalesReason> GetBySalesOrderId(TransactionManager transactionManager, System.Int32 _salesOrderId)
		{
			int count = -1;
			return GetBySalesOrderId(transactionManager, _salesOrderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID key.
		///		FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID Description: Foreign key constraint referencing SalesOrderHeader.SalesOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public TList<SalesOrderHeaderSalesReason> GetBySalesOrderId(TransactionManager transactionManager, System.Int32 _salesOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderId(transactionManager, _salesOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID key.
		///		fkSalesOrderHeaderSalesReasonSalesOrderHeaderSalesOrderId Description: Foreign key constraint referencing SalesOrderHeader.SalesOrderID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public TList<SalesOrderHeaderSalesReason> GetBySalesOrderId(System.Int32 _salesOrderId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalesOrderId(null, _salesOrderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID key.
		///		fkSalesOrderHeaderSalesReasonSalesOrderHeaderSalesOrderId Description: Foreign key constraint referencing SalesOrderHeader.SalesOrderID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public TList<SalesOrderHeaderSalesReason> GetBySalesOrderId(System.Int32 _salesOrderId, int start, int pageLength,out int count)
		{
			return GetBySalesOrderId(null, _salesOrderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID key.
		///		FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID Description: Foreign key constraint referencing SalesOrderHeader.SalesOrderID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public abstract TList<SalesOrderHeaderSalesReason> GetBySalesOrderId(TransactionManager transactionManager, System.Int32 _salesOrderId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID key.
		///		FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID Description: Foreign key constraint referencing SalesReason.SalesReasonID.
		/// </summary>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public TList<SalesOrderHeaderSalesReason> GetBySalesReasonId(System.Int32 _salesReasonId)
		{
			int count = -1;
			return GetBySalesReasonId(_salesReasonId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID key.
		///		FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID Description: Foreign key constraint referencing SalesReason.SalesReasonID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderHeaderSalesReason> GetBySalesReasonId(TransactionManager transactionManager, System.Int32 _salesReasonId)
		{
			int count = -1;
			return GetBySalesReasonId(transactionManager, _salesReasonId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID key.
		///		FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID Description: Foreign key constraint referencing SalesReason.SalesReasonID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public TList<SalesOrderHeaderSalesReason> GetBySalesReasonId(TransactionManager transactionManager, System.Int32 _salesReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesReasonId(transactionManager, _salesReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID key.
		///		fkSalesOrderHeaderSalesReasonSalesReasonSalesReasonId Description: Foreign key constraint referencing SalesReason.SalesReasonID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public TList<SalesOrderHeaderSalesReason> GetBySalesReasonId(System.Int32 _salesReasonId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalesReasonId(null, _salesReasonId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID key.
		///		fkSalesOrderHeaderSalesReasonSalesReasonSalesReasonId Description: Foreign key constraint referencing SalesReason.SalesReasonID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public TList<SalesOrderHeaderSalesReason> GetBySalesReasonId(System.Int32 _salesReasonId, int start, int pageLength,out int count)
		{
			return GetBySalesReasonId(null, _salesReasonId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID key.
		///		FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID Description: Foreign key constraint referencing SalesReason.SalesReasonID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason objects.</returns>
		public abstract TList<SalesOrderHeaderSalesReason> GetBySalesReasonId(TransactionManager transactionManager, System.Int32 _salesReasonId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReasonKey key, int start, int pageLength)
		{
			return GetBySalesOrderIdSalesReasonId(transactionManager, key.SalesOrderId, key.SalesReasonId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID index.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason GetBySalesOrderIdSalesReasonId(System.Int32 _salesOrderId, System.Int32 _salesReasonId)
		{
			int count = -1;
			return GetBySalesOrderIdSalesReasonId(null,_salesOrderId, _salesReasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID index.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason GetBySalesOrderIdSalesReasonId(System.Int32 _salesOrderId, System.Int32 _salesReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderIdSalesReasonId(null, _salesOrderId, _salesReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason GetBySalesOrderIdSalesReasonId(TransactionManager transactionManager, System.Int32 _salesOrderId, System.Int32 _salesReasonId)
		{
			int count = -1;
			return GetBySalesOrderIdSalesReasonId(transactionManager, _salesOrderId, _salesReasonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason GetBySalesOrderIdSalesReasonId(TransactionManager transactionManager, System.Int32 _salesOrderId, System.Int32 _salesReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderIdSalesReasonId(transactionManager, _salesOrderId, _salesReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID index.
		/// </summary>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason GetBySalesOrderIdSalesReasonId(System.Int32 _salesOrderId, System.Int32 _salesReasonId, int start, int pageLength, out int count)
		{
			return GetBySalesOrderIdSalesReasonId(null, _salesOrderId, _salesReasonId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key. Foreign key to SalesOrderHeader.SalesOrderID.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason GetBySalesOrderIdSalesReasonId(TransactionManager transactionManager, System.Int32 _salesOrderId, System.Int32 _salesReasonId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalesOrderHeaderSalesReason&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalesOrderHeaderSalesReason&gt;"/></returns>
		public static TList<SalesOrderHeaderSalesReason> Fill(IDataReader reader, TList<SalesOrderHeaderSalesReason> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesOrderHeaderSalesReason")
					.Append("|").Append((System.Int32)reader[((int)SalesOrderHeaderSalesReasonColumn.SalesOrderId - 1)])
					.Append("|").Append((System.Int32)reader[((int)SalesOrderHeaderSalesReasonColumn.SalesReasonId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalesOrderHeaderSalesReason>(
					key.ToString(), // EntityTrackingKey
					"SalesOrderHeaderSalesReason",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason();
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
					c.SalesOrderId = (System.Int32)reader[((int)SalesOrderHeaderSalesReasonColumn.SalesOrderId - 1)];
					c.OriginalSalesOrderId = c.SalesOrderId;
					c.SalesReasonId = (System.Int32)reader[((int)SalesOrderHeaderSalesReasonColumn.SalesReasonId - 1)];
					c.OriginalSalesReasonId = c.SalesReasonId;
					c.ModifiedDate = (System.DateTime)reader[((int)SalesOrderHeaderSalesReasonColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason entity)
		{
			if (!reader.Read()) return;
			
			entity.SalesOrderId = (System.Int32)reader[((int)SalesOrderHeaderSalesReasonColumn.SalesOrderId - 1)];
			entity.OriginalSalesOrderId = (System.Int32)reader["SalesOrderID"];
			entity.SalesReasonId = (System.Int32)reader[((int)SalesOrderHeaderSalesReasonColumn.SalesReasonId - 1)];
			entity.OriginalSalesReasonId = (System.Int32)reader["SalesReasonID"];
			entity.ModifiedDate = (System.DateTime)reader[((int)SalesOrderHeaderSalesReasonColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesOrderId = (System.Int32)dataRow["SalesOrderID"];
			entity.OriginalSalesOrderId = (System.Int32)dataRow["SalesOrderID"];
			entity.SalesReasonId = (System.Int32)dataRow["SalesReasonID"];
			entity.OriginalSalesReasonId = (System.Int32)dataRow["SalesReasonID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SalesOrderIdSource	
			if (CanDeepLoad(entity, "SalesOrderHeader|SalesOrderIdSource", deepLoadType, innerList) 
				&& entity.SalesOrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SalesOrderId;
				SalesOrderHeader tmpEntity = EntityManager.LocateEntity<SalesOrderHeader>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesOrderHeader), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesOrderIdSource = tmpEntity;
				else
					entity.SalesOrderIdSource = DataRepository.SalesOrderHeaderProvider.GetBySalesOrderId(transactionManager, entity.SalesOrderId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesOrderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesOrderHeaderProvider.DeepLoad(transactionManager, entity.SalesOrderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesOrderIdSource

			#region SalesReasonIdSource	
			if (CanDeepLoad(entity, "SalesReason|SalesReasonIdSource", deepLoadType, innerList) 
				&& entity.SalesReasonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SalesReasonId;
				SalesReason tmpEntity = EntityManager.LocateEntity<SalesReason>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesReason), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesReasonIdSource = tmpEntity;
				else
					entity.SalesReasonIdSource = DataRepository.SalesReasonProvider.GetBySalesReasonId(transactionManager, entity.SalesReasonId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesReasonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesReasonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesReasonProvider.DeepLoad(transactionManager, entity.SalesReasonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesReasonIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region SalesOrderIdSource
			if (CanDeepSave(entity, "SalesOrderHeader|SalesOrderIdSource", deepSaveType, innerList) 
				&& entity.SalesOrderIdSource != null)
			{
				DataRepository.SalesOrderHeaderProvider.Save(transactionManager, entity.SalesOrderIdSource);
				entity.SalesOrderId = entity.SalesOrderIdSource.SalesOrderId;
			}
			#endregion 
			
			#region SalesReasonIdSource
			if (CanDeepSave(entity, "SalesReason|SalesReasonIdSource", deepSaveType, innerList) 
				&& entity.SalesReasonIdSource != null)
			{
				DataRepository.SalesReasonProvider.Save(transactionManager, entity.SalesReasonIdSource);
				entity.SalesReasonId = entity.SalesReasonIdSource.SalesReasonId;
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
	
	#region SalesOrderHeaderSalesReasonChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SalesOrderHeaderSalesReason</c>
	///</summary>
	public enum SalesOrderHeaderSalesReasonChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>SalesOrderHeader</c> at SalesOrderIdSource
		///</summary>
		[ChildEntityType(typeof(SalesOrderHeader))]
		SalesOrderHeader,
			
		///<summary>
		/// Composite Property for <c>SalesReason</c> at SalesReasonIdSource
		///</summary>
		[ChildEntityType(typeof(SalesReason))]
		SalesReason,
		}
	
	#endregion SalesOrderHeaderSalesReasonChildEntityTypes
	
	#region SalesOrderHeaderSalesReasonFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesOrderHeaderSalesReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeaderSalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderSalesReasonFilterBuilder : SqlFilterBuilder<SalesOrderHeaderSalesReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonFilterBuilder class.
		/// </summary>
		public SalesOrderHeaderSalesReasonFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderHeaderSalesReasonFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderHeaderSalesReasonFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderHeaderSalesReasonFilterBuilder
	
	#region SalesOrderHeaderSalesReasonParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesOrderHeaderSalesReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeaderSalesReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderSalesReasonParameterBuilder : ParameterizedSqlFilterBuilder<SalesOrderHeaderSalesReasonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonParameterBuilder class.
		/// </summary>
		public SalesOrderHeaderSalesReasonParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderHeaderSalesReasonParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderHeaderSalesReasonParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderHeaderSalesReasonParameterBuilder
	
	#region SalesOrderHeaderSalesReasonSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalesOrderHeaderSalesReasonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeaderSalesReason"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesOrderHeaderSalesReasonSortBuilder : SqlSortBuilder<SalesOrderHeaderSalesReasonColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSalesReasonSqlSortBuilder class.
		/// </summary>
		public SalesOrderHeaderSalesReasonSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesOrderHeaderSalesReasonSortBuilder
	
} // end namespace
