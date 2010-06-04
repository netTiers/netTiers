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
	/// This class is the base class for any <see cref="TransactionHistoryArchiveProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TransactionHistoryArchiveProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.TransactionHistoryArchive, Nettiers.AdventureWorks.Entities.TransactionHistoryArchiveKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TransactionHistoryArchiveKey key)
		{
			return Delete(transactionManager, key.TransactionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_transactionId">Primary key for TransactionHistoryArchive records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _transactionId)
		{
			return Delete(null, _transactionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_transactionId">Primary key for TransactionHistoryArchive records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _transactionId);		
		
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
		public override Nettiers.AdventureWorks.Entities.TransactionHistoryArchive Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TransactionHistoryArchiveKey key, int start, int pageLength)
		{
			return GetByTransactionId(transactionManager, key.TransactionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_TransactionHistoryArchive_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ProductID index.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public abstract TList<TransactionHistoryArchive> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID index.
		/// </summary>
		/// <param name="_referenceOrderId">Purchase order, sales order, or work order identification number.</param>
		/// <param name="_referenceOrderLineId">Line number associated with the purchase order, sales order, or work order.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByReferenceOrderIdReferenceOrderLineId(System.Int32 _referenceOrderId, System.Int32 _referenceOrderLineId)
		{
			int count = -1;
			return GetByReferenceOrderIdReferenceOrderLineId(null,_referenceOrderId, _referenceOrderLineId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID index.
		/// </summary>
		/// <param name="_referenceOrderId">Purchase order, sales order, or work order identification number.</param>
		/// <param name="_referenceOrderLineId">Line number associated with the purchase order, sales order, or work order.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByReferenceOrderIdReferenceOrderLineId(System.Int32 _referenceOrderId, System.Int32 _referenceOrderLineId, int start, int pageLength)
		{
			int count = -1;
			return GetByReferenceOrderIdReferenceOrderLineId(null, _referenceOrderId, _referenceOrderLineId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referenceOrderId">Purchase order, sales order, or work order identification number.</param>
		/// <param name="_referenceOrderLineId">Line number associated with the purchase order, sales order, or work order.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByReferenceOrderIdReferenceOrderLineId(TransactionManager transactionManager, System.Int32 _referenceOrderId, System.Int32 _referenceOrderLineId)
		{
			int count = -1;
			return GetByReferenceOrderIdReferenceOrderLineId(transactionManager, _referenceOrderId, _referenceOrderLineId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referenceOrderId">Purchase order, sales order, or work order identification number.</param>
		/// <param name="_referenceOrderLineId">Line number associated with the purchase order, sales order, or work order.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByReferenceOrderIdReferenceOrderLineId(TransactionManager transactionManager, System.Int32 _referenceOrderId, System.Int32 _referenceOrderLineId, int start, int pageLength)
		{
			int count = -1;
			return GetByReferenceOrderIdReferenceOrderLineId(transactionManager, _referenceOrderId, _referenceOrderLineId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID index.
		/// </summary>
		/// <param name="_referenceOrderId">Purchase order, sales order, or work order identification number.</param>
		/// <param name="_referenceOrderLineId">Line number associated with the purchase order, sales order, or work order.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public TList<TransactionHistoryArchive> GetByReferenceOrderIdReferenceOrderLineId(System.Int32 _referenceOrderId, System.Int32 _referenceOrderLineId, int start, int pageLength, out int count)
		{
			return GetByReferenceOrderIdReferenceOrderLineId(null, _referenceOrderId, _referenceOrderLineId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referenceOrderId">Purchase order, sales order, or work order identification number.</param>
		/// <param name="_referenceOrderLineId">Line number associated with the purchase order, sales order, or work order.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;TransactionHistoryArchive&gt;"/> class.</returns>
		public abstract TList<TransactionHistoryArchive> GetByReferenceOrderIdReferenceOrderLineId(TransactionManager transactionManager, System.Int32 _referenceOrderId, System.Int32 _referenceOrderLineId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_TransactionHistoryArchive_TransactionID index.
		/// </summary>
		/// <param name="_transactionId">Primary key for TransactionHistoryArchive records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TransactionHistoryArchive GetByTransactionId(System.Int32 _transactionId)
		{
			int count = -1;
			return GetByTransactionId(null,_transactionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TransactionHistoryArchive_TransactionID index.
		/// </summary>
		/// <param name="_transactionId">Primary key for TransactionHistoryArchive records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TransactionHistoryArchive GetByTransactionId(System.Int32 _transactionId, int start, int pageLength)
		{
			int count = -1;
			return GetByTransactionId(null, _transactionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TransactionHistoryArchive_TransactionID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_transactionId">Primary key for TransactionHistoryArchive records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TransactionHistoryArchive GetByTransactionId(TransactionManager transactionManager, System.Int32 _transactionId)
		{
			int count = -1;
			return GetByTransactionId(transactionManager, _transactionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TransactionHistoryArchive_TransactionID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_transactionId">Primary key for TransactionHistoryArchive records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TransactionHistoryArchive GetByTransactionId(TransactionManager transactionManager, System.Int32 _transactionId, int start, int pageLength)
		{
			int count = -1;
			return GetByTransactionId(transactionManager, _transactionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TransactionHistoryArchive_TransactionID index.
		/// </summary>
		/// <param name="_transactionId">Primary key for TransactionHistoryArchive records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TransactionHistoryArchive GetByTransactionId(System.Int32 _transactionId, int start, int pageLength, out int count)
		{
			return GetByTransactionId(null, _transactionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TransactionHistoryArchive_TransactionID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_transactionId">Primary key for TransactionHistoryArchive records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.TransactionHistoryArchive GetByTransactionId(TransactionManager transactionManager, System.Int32 _transactionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TransactionHistoryArchive&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TransactionHistoryArchive&gt;"/></returns>
		public static TList<TransactionHistoryArchive> Fill(IDataReader reader, TList<TransactionHistoryArchive> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.TransactionHistoryArchive c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TransactionHistoryArchive")
					.Append("|").Append((System.Int32)reader[((int)TransactionHistoryArchiveColumn.TransactionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TransactionHistoryArchive>(
					key.ToString(), // EntityTrackingKey
					"TransactionHistoryArchive",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.TransactionHistoryArchive();
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
					c.TransactionId = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.TransactionId - 1)];
					c.OriginalTransactionId = c.TransactionId;
					c.ProductId = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.ProductId - 1)];
					c.ReferenceOrderId = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.ReferenceOrderId - 1)];
					c.ReferenceOrderLineId = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.ReferenceOrderLineId - 1)];
					c.TransactionDate = (System.DateTime)reader[((int)TransactionHistoryArchiveColumn.TransactionDate - 1)];
					c.TransactionType = (System.String)reader[((int)TransactionHistoryArchiveColumn.TransactionType - 1)];
					c.Quantity = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.Quantity - 1)];
					c.ActualCost = (System.Decimal)reader[((int)TransactionHistoryArchiveColumn.ActualCost - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)TransactionHistoryArchiveColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.TransactionHistoryArchive entity)
		{
			if (!reader.Read()) return;
			
			entity.TransactionId = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.TransactionId - 1)];
			entity.OriginalTransactionId = (System.Int32)reader["TransactionID"];
			entity.ProductId = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.ProductId - 1)];
			entity.ReferenceOrderId = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.ReferenceOrderId - 1)];
			entity.ReferenceOrderLineId = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.ReferenceOrderLineId - 1)];
			entity.TransactionDate = (System.DateTime)reader[((int)TransactionHistoryArchiveColumn.TransactionDate - 1)];
			entity.TransactionType = (System.String)reader[((int)TransactionHistoryArchiveColumn.TransactionType - 1)];
			entity.Quantity = (System.Int32)reader[((int)TransactionHistoryArchiveColumn.Quantity - 1)];
			entity.ActualCost = (System.Decimal)reader[((int)TransactionHistoryArchiveColumn.ActualCost - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)TransactionHistoryArchiveColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.TransactionHistoryArchive entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TransactionId = (System.Int32)dataRow["TransactionID"];
			entity.OriginalTransactionId = (System.Int32)dataRow["TransactionID"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.ReferenceOrderId = (System.Int32)dataRow["ReferenceOrderID"];
			entity.ReferenceOrderLineId = (System.Int32)dataRow["ReferenceOrderLineID"];
			entity.TransactionDate = (System.DateTime)dataRow["TransactionDate"];
			entity.TransactionType = (System.String)dataRow["TransactionType"];
			entity.Quantity = (System.Int32)dataRow["Quantity"];
			entity.ActualCost = (System.Decimal)dataRow["ActualCost"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TransactionHistoryArchive"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TransactionHistoryArchive Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TransactionHistoryArchive entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.TransactionHistoryArchive object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.TransactionHistoryArchive instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TransactionHistoryArchive Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TransactionHistoryArchive entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
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
	
	#region TransactionHistoryArchiveChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.TransactionHistoryArchive</c>
	///</summary>
	public enum TransactionHistoryArchiveChildEntityTypes
	{
	}
	
	#endregion TransactionHistoryArchiveChildEntityTypes
	
	#region TransactionHistoryArchiveFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TransactionHistoryArchiveColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistoryArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryArchiveFilterBuilder : SqlFilterBuilder<TransactionHistoryArchiveColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveFilterBuilder class.
		/// </summary>
		public TransactionHistoryArchiveFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TransactionHistoryArchiveFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TransactionHistoryArchiveFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TransactionHistoryArchiveFilterBuilder
	
	#region TransactionHistoryArchiveParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TransactionHistoryArchiveColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistoryArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TransactionHistoryArchiveParameterBuilder : ParameterizedSqlFilterBuilder<TransactionHistoryArchiveColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveParameterBuilder class.
		/// </summary>
		public TransactionHistoryArchiveParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TransactionHistoryArchiveParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TransactionHistoryArchiveParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TransactionHistoryArchiveParameterBuilder
	
	#region TransactionHistoryArchiveSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TransactionHistoryArchiveColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TransactionHistoryArchive"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TransactionHistoryArchiveSortBuilder : SqlSortBuilder<TransactionHistoryArchiveColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransactionHistoryArchiveSqlSortBuilder class.
		/// </summary>
		public TransactionHistoryArchiveSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TransactionHistoryArchiveSortBuilder
	
} // end namespace
