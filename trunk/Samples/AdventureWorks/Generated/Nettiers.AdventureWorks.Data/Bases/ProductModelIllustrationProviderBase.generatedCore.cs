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
	/// This class is the base class for any <see cref="ProductModelIllustrationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductModelIllustrationProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ProductModelIllustration, Nettiers.AdventureWorks.Entities.ProductModelIllustrationKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelIllustrationKey key)
		{
			return Delete(transactionManager, key.ProductModelId, key.IllustrationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.. Primary Key.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productModelId, System.Int32 _illustrationId)
		{
			return Delete(null, _productModelId, _illustrationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.. Primary Key.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productModelId, System.Int32 _illustrationId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_Illustration_IllustrationID key.
		///		FK_ProductModelIllustration_Illustration_IllustrationID Description: Foreign key constraint referencing Illustration.IllustrationID.
		/// </summary>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public TList<ProductModelIllustration> GetByIllustrationId(System.Int32 _illustrationId)
		{
			int count = -1;
			return GetByIllustrationId(_illustrationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_Illustration_IllustrationID key.
		///		FK_ProductModelIllustration_Illustration_IllustrationID Description: Foreign key constraint referencing Illustration.IllustrationID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		/// <remarks></remarks>
		public TList<ProductModelIllustration> GetByIllustrationId(TransactionManager transactionManager, System.Int32 _illustrationId)
		{
			int count = -1;
			return GetByIllustrationId(transactionManager, _illustrationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_Illustration_IllustrationID key.
		///		FK_ProductModelIllustration_Illustration_IllustrationID Description: Foreign key constraint referencing Illustration.IllustrationID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public TList<ProductModelIllustration> GetByIllustrationId(TransactionManager transactionManager, System.Int32 _illustrationId, int start, int pageLength)
		{
			int count = -1;
			return GetByIllustrationId(transactionManager, _illustrationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_Illustration_IllustrationID key.
		///		fkProductModelIllustrationIllustrationIllustrationId Description: Foreign key constraint referencing Illustration.IllustrationID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public TList<ProductModelIllustration> GetByIllustrationId(System.Int32 _illustrationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByIllustrationId(null, _illustrationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_Illustration_IllustrationID key.
		///		fkProductModelIllustrationIllustrationIllustrationId Description: Foreign key constraint referencing Illustration.IllustrationID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public TList<ProductModelIllustration> GetByIllustrationId(System.Int32 _illustrationId, int start, int pageLength,out int count)
		{
			return GetByIllustrationId(null, _illustrationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_Illustration_IllustrationID key.
		///		FK_ProductModelIllustration_Illustration_IllustrationID Description: Foreign key constraint referencing Illustration.IllustrationID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public abstract TList<ProductModelIllustration> GetByIllustrationId(TransactionManager transactionManager, System.Int32 _illustrationId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_ProductModel_ProductModelID key.
		///		FK_ProductModelIllustration_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public TList<ProductModelIllustration> GetByProductModelId(System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelId(_productModelId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_ProductModel_ProductModelID key.
		///		FK_ProductModelIllustration_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		/// <remarks></remarks>
		public TList<ProductModelIllustration> GetByProductModelId(TransactionManager transactionManager, System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelId(transactionManager, _productModelId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_ProductModel_ProductModelID key.
		///		FK_ProductModelIllustration_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public TList<ProductModelIllustration> GetByProductModelId(TransactionManager transactionManager, System.Int32 _productModelId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelId(transactionManager, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_ProductModel_ProductModelID key.
		///		fkProductModelIllustrationProductModelProductModelId Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public TList<ProductModelIllustration> GetByProductModelId(System.Int32 _productModelId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductModelId(null, _productModelId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_ProductModel_ProductModelID key.
		///		fkProductModelIllustrationProductModelProductModelId Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public TList<ProductModelIllustration> GetByProductModelId(System.Int32 _productModelId, int start, int pageLength,out int count)
		{
			return GetByProductModelId(null, _productModelId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductModelIllustration_ProductModel_ProductModelID key.
		///		FK_ProductModelIllustration_ProductModel_ProductModelID Description: Foreign key constraint referencing ProductModel.ProductModelID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductModelIllustration objects.</returns>
		public abstract TList<ProductModelIllustration> GetByProductModelId(TransactionManager transactionManager, System.Int32 _productModelId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.ProductModelIllustration Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelIllustrationKey key, int start, int pageLength)
		{
			return GetByProductModelIdIllustrationId(transactionManager, key.ProductModelId, key.IllustrationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductModelIllustration_ProductModelID_IllustrationID index.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelIllustration GetByProductModelIdIllustrationId(System.Int32 _productModelId, System.Int32 _illustrationId)
		{
			int count = -1;
			return GetByProductModelIdIllustrationId(null,_productModelId, _illustrationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelIllustration_ProductModelID_IllustrationID index.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelIllustration GetByProductModelIdIllustrationId(System.Int32 _productModelId, System.Int32 _illustrationId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdIllustrationId(null, _productModelId, _illustrationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelIllustration_ProductModelID_IllustrationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelIllustration GetByProductModelIdIllustrationId(TransactionManager transactionManager, System.Int32 _productModelId, System.Int32 _illustrationId)
		{
			int count = -1;
			return GetByProductModelIdIllustrationId(transactionManager, _productModelId, _illustrationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelIllustration_ProductModelID_IllustrationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelIllustration GetByProductModelIdIllustrationId(TransactionManager transactionManager, System.Int32 _productModelId, System.Int32 _illustrationId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdIllustrationId(transactionManager, _productModelId, _illustrationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelIllustration_ProductModelID_IllustrationID index.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ProductModelIllustration GetByProductModelIdIllustrationId(System.Int32 _productModelId, System.Int32 _illustrationId, int start, int pageLength, out int count)
		{
			return GetByProductModelIdIllustrationId(null, _productModelId, _illustrationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductModelIllustration_ProductModelID_IllustrationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="_illustrationId">Primary key. Foreign key to Illustration.IllustrationID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ProductModelIllustration GetByProductModelIdIllustrationId(TransactionManager transactionManager, System.Int32 _productModelId, System.Int32 _illustrationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProductModelIllustration&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProductModelIllustration&gt;"/></returns>
		public static TList<ProductModelIllustration> Fill(IDataReader reader, TList<ProductModelIllustration> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ProductModelIllustration c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductModelIllustration")
					.Append("|").Append((System.Int32)reader[((int)ProductModelIllustrationColumn.ProductModelId - 1)])
					.Append("|").Append((System.Int32)reader[((int)ProductModelIllustrationColumn.IllustrationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProductModelIllustration>(
					key.ToString(), // EntityTrackingKey
					"ProductModelIllustration",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ProductModelIllustration();
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
					c.ProductModelId = (System.Int32)reader[((int)ProductModelIllustrationColumn.ProductModelId - 1)];
					c.OriginalProductModelId = c.ProductModelId;
					c.IllustrationId = (System.Int32)reader[((int)ProductModelIllustrationColumn.IllustrationId - 1)];
					c.OriginalIllustrationId = c.IllustrationId;
					c.ModifiedDate = (System.DateTime)reader[((int)ProductModelIllustrationColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ProductModelIllustration entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductModelId = (System.Int32)reader[((int)ProductModelIllustrationColumn.ProductModelId - 1)];
			entity.OriginalProductModelId = (System.Int32)reader["ProductModelID"];
			entity.IllustrationId = (System.Int32)reader[((int)ProductModelIllustrationColumn.IllustrationId - 1)];
			entity.OriginalIllustrationId = (System.Int32)reader["IllustrationID"];
			entity.ModifiedDate = (System.DateTime)reader[((int)ProductModelIllustrationColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ProductModelIllustration entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductModelId = (System.Int32)dataRow["ProductModelID"];
			entity.OriginalProductModelId = (System.Int32)dataRow["ProductModelID"];
			entity.IllustrationId = (System.Int32)dataRow["IllustrationID"];
			entity.OriginalIllustrationId = (System.Int32)dataRow["IllustrationID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ProductModelIllustration"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductModelIllustration Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelIllustration entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IllustrationIdSource	
			if (CanDeepLoad(entity, "Illustration|IllustrationIdSource", deepLoadType, innerList) 
				&& entity.IllustrationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IllustrationId;
				Illustration tmpEntity = EntityManager.LocateEntity<Illustration>(EntityLocator.ConstructKeyFromPkItems(typeof(Illustration), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IllustrationIdSource = tmpEntity;
				else
					entity.IllustrationIdSource = DataRepository.IllustrationProvider.GetByIllustrationId(transactionManager, entity.IllustrationId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IllustrationIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IllustrationIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.IllustrationProvider.DeepLoad(transactionManager, entity.IllustrationIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IllustrationIdSource

			#region ProductModelIdSource	
			if (CanDeepLoad(entity, "ProductModel|ProductModelIdSource", deepLoadType, innerList) 
				&& entity.ProductModelIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductModelId;
				ProductModel tmpEntity = EntityManager.LocateEntity<ProductModel>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductModel), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductModelIdSource = tmpEntity;
				else
					entity.ProductModelIdSource = DataRepository.ProductModelProvider.GetByProductModelId(transactionManager, entity.ProductModelId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductModelIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductModelProvider.DeepLoad(transactionManager, entity.ProductModelIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductModelIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ProductModelIllustration object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductModelIllustration instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ProductModelIllustration Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductModelIllustration entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IllustrationIdSource
			if (CanDeepSave(entity, "Illustration|IllustrationIdSource", deepSaveType, innerList) 
				&& entity.IllustrationIdSource != null)
			{
				DataRepository.IllustrationProvider.Save(transactionManager, entity.IllustrationIdSource);
				entity.IllustrationId = entity.IllustrationIdSource.IllustrationId;
			}
			#endregion 
			
			#region ProductModelIdSource
			if (CanDeepSave(entity, "ProductModel|ProductModelIdSource", deepSaveType, innerList) 
				&& entity.ProductModelIdSource != null)
			{
				DataRepository.ProductModelProvider.Save(transactionManager, entity.ProductModelIdSource);
				entity.ProductModelId = entity.ProductModelIdSource.ProductModelId;
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
	
	#region ProductModelIllustrationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ProductModelIllustration</c>
	///</summary>
	public enum ProductModelIllustrationChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Illustration</c> at IllustrationIdSource
		///</summary>
		[ChildEntityType(typeof(Illustration))]
		Illustration,
			
		///<summary>
		/// Composite Property for <c>ProductModel</c> at ProductModelIdSource
		///</summary>
		[ChildEntityType(typeof(ProductModel))]
		ProductModel,
		}
	
	#endregion ProductModelIllustrationChildEntityTypes
	
	#region ProductModelIllustrationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductModelIllustrationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelIllustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelIllustrationFilterBuilder : SqlFilterBuilder<ProductModelIllustrationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationFilterBuilder class.
		/// </summary>
		public ProductModelIllustrationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelIllustrationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelIllustrationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelIllustrationFilterBuilder
	
	#region ProductModelIllustrationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductModelIllustrationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelIllustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductModelIllustrationParameterBuilder : ParameterizedSqlFilterBuilder<ProductModelIllustrationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationParameterBuilder class.
		/// </summary>
		public ProductModelIllustrationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductModelIllustrationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductModelIllustrationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductModelIllustrationParameterBuilder
	
	#region ProductModelIllustrationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductModelIllustrationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductModelIllustration"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductModelIllustrationSortBuilder : SqlSortBuilder<ProductModelIllustrationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductModelIllustrationSqlSortBuilder class.
		/// </summary>
		public ProductModelIllustrationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductModelIllustrationSortBuilder
	
} // end namespace
