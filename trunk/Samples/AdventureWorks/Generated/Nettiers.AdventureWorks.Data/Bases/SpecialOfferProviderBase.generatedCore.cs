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
	/// This class is the base class for any <see cref="SpecialOfferProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SpecialOfferProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SpecialOffer, Nettiers.AdventureWorks.Entities.SpecialOfferKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByProductIdFromSpecialOfferProduct
		
		/// <summary>
		///		Gets SpecialOffer objects from the datasource by ProductID in the
		///		SpecialOfferProduct table. Table SpecialOffer is related to table Product
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of SpecialOffer objects.</returns>
		public TList<SpecialOffer> GetByProductIdFromSpecialOfferProduct(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromSpecialOfferProduct(null,_productId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.SpecialOffer objects from the datasource by ProductID in the
		///		SpecialOfferProduct table. Table SpecialOffer is related to table Product
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of SpecialOffer objects.</returns>
		public TList<SpecialOffer> GetByProductIdFromSpecialOfferProduct(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromSpecialOfferProduct(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets SpecialOffer objects from the datasource by ProductID in the
		///		SpecialOfferProduct table. Table SpecialOffer is related to table Product
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SpecialOffer objects.</returns>
		public TList<SpecialOffer> GetByProductIdFromSpecialOfferProduct(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromSpecialOfferProduct(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets SpecialOffer objects from the datasource by ProductID in the
		///		SpecialOfferProduct table. Table SpecialOffer is related to table Product
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SpecialOffer objects.</returns>
		public TList<SpecialOffer> GetByProductIdFromSpecialOfferProduct(TransactionManager transactionManager, System.Int32 _productId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromSpecialOfferProduct(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets SpecialOffer objects from the datasource by ProductID in the
		///		SpecialOfferProduct table. Table SpecialOffer is related to table Product
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SpecialOffer objects.</returns>
		public TList<SpecialOffer> GetByProductIdFromSpecialOfferProduct(System.Int32 _productId,int start, int pageLength, out int count)
		{
			
			return GetByProductIdFromSpecialOfferProduct(null, _productId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets SpecialOffer objects from the datasource by ProductID in the
		///		SpecialOfferProduct table. Table SpecialOffer is related to table Product
		///		through the (M:N) relationship defined in the SpecialOfferProduct table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of SpecialOffer objects.</returns>
		public abstract TList<SpecialOffer> GetByProductIdFromSpecialOfferProduct(TransactionManager transactionManager,System.Int32 _productId, int start, int pageLength, out int count);
		
		#endregion GetByProductIdFromSpecialOfferProduct
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SpecialOfferKey key)
		{
			return Delete(transactionManager, key.SpecialOfferId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOffer records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _specialOfferId)
		{
			return Delete(null, _specialOfferId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOffer records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _specialOfferId);		
		
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
		public override Nettiers.AdventureWorks.Entities.SpecialOffer Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SpecialOfferKey key, int start, int pageLength)
		{
			return GetBySpecialOfferId(transactionManager, key.SpecialOfferId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SpecialOffer_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOffer_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOffer_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOffer_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOffer_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SpecialOffer_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SpecialOffer GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SpecialOffer_SpecialOfferID index.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOffer records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetBySpecialOfferId(System.Int32 _specialOfferId)
		{
			int count = -1;
			return GetBySpecialOfferId(null,_specialOfferId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOffer_SpecialOfferID index.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOffer records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetBySpecialOfferId(System.Int32 _specialOfferId, int start, int pageLength)
		{
			int count = -1;
			return GetBySpecialOfferId(null, _specialOfferId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOffer_SpecialOfferID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOffer records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetBySpecialOfferId(TransactionManager transactionManager, System.Int32 _specialOfferId)
		{
			int count = -1;
			return GetBySpecialOfferId(transactionManager, _specialOfferId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOffer_SpecialOfferID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOffer records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetBySpecialOfferId(TransactionManager transactionManager, System.Int32 _specialOfferId, int start, int pageLength)
		{
			int count = -1;
			return GetBySpecialOfferId(transactionManager, _specialOfferId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOffer_SpecialOfferID index.
		/// </summary>
		/// <param name="_specialOfferId">Primary key for SpecialOffer records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SpecialOffer GetBySpecialOfferId(System.Int32 _specialOfferId, int start, int pageLength, out int count)
		{
			return GetBySpecialOfferId(null, _specialOfferId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SpecialOffer_SpecialOfferID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_specialOfferId">Primary key for SpecialOffer records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SpecialOffer GetBySpecialOfferId(TransactionManager transactionManager, System.Int32 _specialOfferId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SpecialOffer&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SpecialOffer&gt;"/></returns>
		public static TList<SpecialOffer> Fill(IDataReader reader, TList<SpecialOffer> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.SpecialOffer c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SpecialOffer")
					.Append("|").Append((System.Int32)reader[((int)SpecialOfferColumn.SpecialOfferId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SpecialOffer>(
					key.ToString(), // EntityTrackingKey
					"SpecialOffer",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SpecialOffer();
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
					c.SpecialOfferId = (System.Int32)reader[((int)SpecialOfferColumn.SpecialOfferId - 1)];
					c.Description = (System.String)reader[((int)SpecialOfferColumn.Description - 1)];
					c.DiscountPct = (System.Decimal)reader[((int)SpecialOfferColumn.DiscountPct - 1)];
					c.Type = (System.String)reader[((int)SpecialOfferColumn.Type - 1)];
					c.Category = (System.String)reader[((int)SpecialOfferColumn.Category - 1)];
					c.StartDate = (System.DateTime)reader[((int)SpecialOfferColumn.StartDate - 1)];
					c.EndDate = (System.DateTime)reader[((int)SpecialOfferColumn.EndDate - 1)];
					c.MinQty = (System.Int32)reader[((int)SpecialOfferColumn.MinQty - 1)];
					c.MaxQty = (reader.IsDBNull(((int)SpecialOfferColumn.MaxQty - 1)))?null:(System.Int32?)reader[((int)SpecialOfferColumn.MaxQty - 1)];
					c.Rowguid = (System.Guid)reader[((int)SpecialOfferColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SpecialOfferColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SpecialOffer entity)
		{
			if (!reader.Read()) return;
			
			entity.SpecialOfferId = (System.Int32)reader[((int)SpecialOfferColumn.SpecialOfferId - 1)];
			entity.Description = (System.String)reader[((int)SpecialOfferColumn.Description - 1)];
			entity.DiscountPct = (System.Decimal)reader[((int)SpecialOfferColumn.DiscountPct - 1)];
			entity.Type = (System.String)reader[((int)SpecialOfferColumn.Type - 1)];
			entity.Category = (System.String)reader[((int)SpecialOfferColumn.Category - 1)];
			entity.StartDate = (System.DateTime)reader[((int)SpecialOfferColumn.StartDate - 1)];
			entity.EndDate = (System.DateTime)reader[((int)SpecialOfferColumn.EndDate - 1)];
			entity.MinQty = (System.Int32)reader[((int)SpecialOfferColumn.MinQty - 1)];
			entity.MaxQty = (reader.IsDBNull(((int)SpecialOfferColumn.MaxQty - 1)))?null:(System.Int32?)reader[((int)SpecialOfferColumn.MaxQty - 1)];
			entity.Rowguid = (System.Guid)reader[((int)SpecialOfferColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SpecialOfferColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SpecialOffer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SpecialOfferId = (System.Int32)dataRow["SpecialOfferID"];
			entity.Description = (System.String)dataRow["Description"];
			entity.DiscountPct = (System.Decimal)dataRow["DiscountPct"];
			entity.Type = (System.String)dataRow["Type"];
			entity.Category = (System.String)dataRow["Category"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.EndDate = (System.DateTime)dataRow["EndDate"];
			entity.MinQty = (System.Int32)dataRow["MinQty"];
			entity.MaxQty = Convert.IsDBNull(dataRow["MaxQty"]) ? null : (System.Int32?)dataRow["MaxQty"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SpecialOffer"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SpecialOffer Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SpecialOffer entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySpecialOfferId methods when available
			
			#region SpecialOfferProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SpecialOfferProduct>|SpecialOfferProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SpecialOfferProductCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SpecialOfferProductCollection = DataRepository.SpecialOfferProductProvider.GetBySpecialOfferId(transactionManager, entity.SpecialOfferId);

				if (deep && entity.SpecialOfferProductCollection.Count > 0)
				{
					deepHandles.Add("SpecialOfferProductCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SpecialOfferProduct>) DataRepository.SpecialOfferProductProvider.DeepLoad,
						new object[] { transactionManager, entity.SpecialOfferProductCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductIdProductCollection_From_SpecialOfferProduct
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Product>|ProductIdProductCollection_From_SpecialOfferProduct", deepLoadType, innerList))
			{
				entity.ProductIdProductCollection_From_SpecialOfferProduct = DataRepository.ProductProvider.GetBySpecialOfferIdFromSpecialOfferProduct(transactionManager, entity.SpecialOfferId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdProductCollection_From_SpecialOfferProduct' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdProductCollection_From_SpecialOfferProduct != null)
				{
					deepHandles.Add("ProductIdProductCollection_From_SpecialOfferProduct",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Product >) DataRepository.ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_SpecialOfferProduct, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SpecialOffer object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SpecialOffer instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SpecialOffer Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SpecialOffer entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region ProductIdProductCollection_From_SpecialOfferProduct>
			if (CanDeepSave(entity.ProductIdProductCollection_From_SpecialOfferProduct, "List<Product>|ProductIdProductCollection_From_SpecialOfferProduct", deepSaveType, innerList))
			{
				if (entity.ProductIdProductCollection_From_SpecialOfferProduct.Count > 0 || entity.ProductIdProductCollection_From_SpecialOfferProduct.DeletedItems.Count > 0)
				{
					DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdProductCollection_From_SpecialOfferProduct); 
					deepHandles.Add("ProductIdProductCollection_From_SpecialOfferProduct",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Product>) DataRepository.ProductProvider.DeepSave,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_SpecialOfferProduct, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<SpecialOfferProduct>
				if (CanDeepSave(entity.SpecialOfferProductCollection, "List<SpecialOfferProduct>|SpecialOfferProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SpecialOfferProduct child in entity.SpecialOfferProductCollection)
					{
						if(child.SpecialOfferIdSource != null)
						{
								child.SpecialOfferId = child.SpecialOfferIdSource.SpecialOfferId;
						}

						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

					}

					if (entity.SpecialOfferProductCollection.Count > 0 || entity.SpecialOfferProductCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SpecialOfferProductProvider.Save(transactionManager, entity.SpecialOfferProductCollection);
						
						deepHandles.Add("SpecialOfferProductCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SpecialOfferProduct >) DataRepository.SpecialOfferProductProvider.DeepSave,
							new object[] { transactionManager, entity.SpecialOfferProductCollection, deepSaveType, childTypes, innerList }
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
	
	#region SpecialOfferChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SpecialOffer</c>
	///</summary>
	public enum SpecialOfferChildEntityTypes
	{

		///<summary>
		/// Collection of <c>SpecialOffer</c> as OneToMany for SpecialOfferProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<SpecialOfferProduct>))]
		SpecialOfferProductCollection,

		///<summary>
		/// Collection of <c>SpecialOffer</c> as ManyToMany for ProductCollection_From_SpecialOfferProduct
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductIdProductCollection_From_SpecialOfferProduct,
	}
	
	#endregion SpecialOfferChildEntityTypes
	
	#region SpecialOfferFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SpecialOfferColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferFilterBuilder : SqlFilterBuilder<SpecialOfferColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferFilterBuilder class.
		/// </summary>
		public SpecialOfferFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecialOfferFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecialOfferFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecialOfferFilterBuilder
	
	#region SpecialOfferParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SpecialOfferColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecialOfferParameterBuilder : ParameterizedSqlFilterBuilder<SpecialOfferColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferParameterBuilder class.
		/// </summary>
		public SpecialOfferParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecialOfferParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecialOfferParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecialOfferParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecialOfferParameterBuilder
	
	#region SpecialOfferSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SpecialOfferColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SpecialOffer"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SpecialOfferSortBuilder : SqlSortBuilder<SpecialOfferColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecialOfferSqlSortBuilder class.
		/// </summary>
		public SpecialOfferSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SpecialOfferSortBuilder
	
} // end namespace
