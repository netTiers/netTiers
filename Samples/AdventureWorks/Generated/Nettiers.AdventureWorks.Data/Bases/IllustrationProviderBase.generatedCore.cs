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
	/// This class is the base class for any <see cref="IllustrationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class IllustrationProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Illustration, Nettiers.AdventureWorks.Entities.IllustrationKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByProductModelIdFromProductModelIllustration
		
		/// <summary>
		///		Gets Illustration objects from the datasource by ProductModelID in the
		///		ProductModelIllustration table. Table Illustration is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <returns>Returns a typed collection of Illustration objects.</returns>
		public TList<Illustration> GetByProductModelIdFromProductModelIllustration(System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelIllustration(null,_productModelId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Illustration objects from the datasource by ProductModelID in the
		///		ProductModelIllustration table. Table Illustration is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Illustration objects.</returns>
		public TList<Illustration> GetByProductModelIdFromProductModelIllustration(System.Int32 _productModelId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelIllustration(null, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Illustration objects from the datasource by ProductModelID in the
		///		ProductModelIllustration table. Table Illustration is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Illustration objects.</returns>
		public TList<Illustration> GetByProductModelIdFromProductModelIllustration(TransactionManager transactionManager, System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelIllustration(transactionManager, _productModelId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Illustration objects from the datasource by ProductModelID in the
		///		ProductModelIllustration table. Table Illustration is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Illustration objects.</returns>
		public TList<Illustration> GetByProductModelIdFromProductModelIllustration(TransactionManager transactionManager, System.Int32 _productModelId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelIllustration(transactionManager, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Illustration objects from the datasource by ProductModelID in the
		///		ProductModelIllustration table. Table Illustration is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Illustration objects.</returns>
		public TList<Illustration> GetByProductModelIdFromProductModelIllustration(System.Int32 _productModelId,int start, int pageLength, out int count)
		{
			
			return GetByProductModelIdFromProductModelIllustration(null, _productModelId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Illustration objects from the datasource by ProductModelID in the
		///		ProductModelIllustration table. Table Illustration is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelIllustration table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Illustration objects.</returns>
		public abstract TList<Illustration> GetByProductModelIdFromProductModelIllustration(TransactionManager transactionManager,System.Int32 _productModelId, int start, int pageLength, out int count);
		
		#endregion GetByProductModelIdFromProductModelIllustration
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.IllustrationKey key)
		{
			return Delete(transactionManager, key.IllustrationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_illustrationId">Primary key for Illustration records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _illustrationId)
		{
			return Delete(null, _illustrationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_illustrationId">Primary key for Illustration records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _illustrationId);		
		
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
		public override Nettiers.AdventureWorks.Entities.Illustration Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.IllustrationKey key, int start, int pageLength)
		{
			return GetByIllustrationId(transactionManager, key.IllustrationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Illustration_IllustrationID index.
		/// </summary>
		/// <param name="_illustrationId">Primary key for Illustration records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Illustration GetByIllustrationId(System.Int32 _illustrationId)
		{
			int count = -1;
			return GetByIllustrationId(null,_illustrationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Illustration_IllustrationID index.
		/// </summary>
		/// <param name="_illustrationId">Primary key for Illustration records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Illustration GetByIllustrationId(System.Int32 _illustrationId, int start, int pageLength)
		{
			int count = -1;
			return GetByIllustrationId(null, _illustrationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Illustration_IllustrationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_illustrationId">Primary key for Illustration records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Illustration GetByIllustrationId(TransactionManager transactionManager, System.Int32 _illustrationId)
		{
			int count = -1;
			return GetByIllustrationId(transactionManager, _illustrationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Illustration_IllustrationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_illustrationId">Primary key for Illustration records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Illustration GetByIllustrationId(TransactionManager transactionManager, System.Int32 _illustrationId, int start, int pageLength)
		{
			int count = -1;
			return GetByIllustrationId(transactionManager, _illustrationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Illustration_IllustrationID index.
		/// </summary>
		/// <param name="_illustrationId">Primary key for Illustration records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Illustration GetByIllustrationId(System.Int32 _illustrationId, int start, int pageLength, out int count)
		{
			return GetByIllustrationId(null, _illustrationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Illustration_IllustrationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_illustrationId">Primary key for Illustration records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Illustration GetByIllustrationId(TransactionManager transactionManager, System.Int32 _illustrationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Illustration&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Illustration&gt;"/></returns>
		public static TList<Illustration> Fill(IDataReader reader, TList<Illustration> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Illustration c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Illustration")
					.Append("|").Append((System.Int32)reader[((int)IllustrationColumn.IllustrationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Illustration>(
					key.ToString(), // EntityTrackingKey
					"Illustration",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Illustration();
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
					c.IllustrationId = (System.Int32)reader[((int)IllustrationColumn.IllustrationId - 1)];
					c.Diagram = (reader.IsDBNull(((int)IllustrationColumn.Diagram - 1)))?null:(string)reader[((int)IllustrationColumn.Diagram - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)IllustrationColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Illustration entity)
		{
			if (!reader.Read()) return;
			
			entity.IllustrationId = (System.Int32)reader[((int)IllustrationColumn.IllustrationId - 1)];
			entity.Diagram = (reader.IsDBNull(((int)IllustrationColumn.Diagram - 1)))?null:(string)reader[((int)IllustrationColumn.Diagram - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)IllustrationColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Illustration entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IllustrationId = (System.Int32)dataRow["IllustrationID"];
			entity.Diagram = Convert.IsDBNull(dataRow["Diagram"]) ? null : (string)dataRow["Diagram"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Illustration"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Illustration Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Illustration entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIllustrationId methods when available
			
			#region ProductModelIdProductModelCollection_From_ProductModelIllustration
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<ProductModel>|ProductModelIdProductModelCollection_From_ProductModelIllustration", deepLoadType, innerList))
			{
				entity.ProductModelIdProductModelCollection_From_ProductModelIllustration = DataRepository.ProductModelProvider.GetByIllustrationIdFromProductModelIllustration(transactionManager, entity.IllustrationId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelIdProductModelCollection_From_ProductModelIllustration' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductModelIdProductModelCollection_From_ProductModelIllustration != null)
				{
					deepHandles.Add("ProductModelIdProductModelCollection_From_ProductModelIllustration",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< ProductModel >) DataRepository.ProductModelProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductModelIdProductModelCollection_From_ProductModelIllustration, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ProductModelIllustrationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductModelIllustration>|ProductModelIllustrationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelIllustrationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductModelIllustrationCollection = DataRepository.ProductModelIllustrationProvider.GetByIllustrationId(transactionManager, entity.IllustrationId);

				if (deep && entity.ProductModelIllustrationCollection.Count > 0)
				{
					deepHandles.Add("ProductModelIllustrationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductModelIllustration>) DataRepository.ProductModelIllustrationProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductModelIllustrationCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Illustration object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Illustration instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Illustration Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Illustration entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region ProductModelIdProductModelCollection_From_ProductModelIllustration>
			if (CanDeepSave(entity.ProductModelIdProductModelCollection_From_ProductModelIllustration, "List<ProductModel>|ProductModelIdProductModelCollection_From_ProductModelIllustration", deepSaveType, innerList))
			{
				if (entity.ProductModelIdProductModelCollection_From_ProductModelIllustration.Count > 0 || entity.ProductModelIdProductModelCollection_From_ProductModelIllustration.DeletedItems.Count > 0)
				{
					DataRepository.ProductModelProvider.Save(transactionManager, entity.ProductModelIdProductModelCollection_From_ProductModelIllustration); 
					deepHandles.Add("ProductModelIdProductModelCollection_From_ProductModelIllustration",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<ProductModel>) DataRepository.ProductModelProvider.DeepSave,
						new object[] { transactionManager, entity.ProductModelIdProductModelCollection_From_ProductModelIllustration, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<ProductModelIllustration>
				if (CanDeepSave(entity.ProductModelIllustrationCollection, "List<ProductModelIllustration>|ProductModelIllustrationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductModelIllustration child in entity.ProductModelIllustrationCollection)
					{
						if(child.IllustrationIdSource != null)
						{
								child.IllustrationId = child.IllustrationIdSource.IllustrationId;
						}

						if(child.ProductModelIdSource != null)
						{
								child.ProductModelId = child.ProductModelIdSource.ProductModelId;
						}

					}

					if (entity.ProductModelIllustrationCollection.Count > 0 || entity.ProductModelIllustrationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductModelIllustrationProvider.Save(transactionManager, entity.ProductModelIllustrationCollection);
						
						deepHandles.Add("ProductModelIllustrationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductModelIllustration >) DataRepository.ProductModelIllustrationProvider.DeepSave,
							new object[] { transactionManager, entity.ProductModelIllustrationCollection, deepSaveType, childTypes, innerList }
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
	
	#region IllustrationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Illustration</c>
	///</summary>
	public enum IllustrationChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Illustration</c> as ManyToMany for ProductModelCollection_From_ProductModelIllustration
		///</summary>
		[ChildEntityType(typeof(TList<ProductModel>))]
		ProductModelIdProductModelCollection_From_ProductModelIllustration,

		///<summary>
		/// Collection of <c>Illustration</c> as OneToMany for ProductModelIllustrationCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductModelIllustration>))]
		ProductModelIllustrationCollection,
	}
	
	#endregion IllustrationChildEntityTypes
	
	#region IllustrationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;IllustrationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Illustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IllustrationFilterBuilder : SqlFilterBuilder<IllustrationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IllustrationFilterBuilder class.
		/// </summary>
		public IllustrationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IllustrationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IllustrationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IllustrationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IllustrationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IllustrationFilterBuilder
	
	#region IllustrationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;IllustrationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Illustration"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IllustrationParameterBuilder : ParameterizedSqlFilterBuilder<IllustrationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IllustrationParameterBuilder class.
		/// </summary>
		public IllustrationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IllustrationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IllustrationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IllustrationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IllustrationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IllustrationParameterBuilder
	
	#region IllustrationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;IllustrationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Illustration"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class IllustrationSortBuilder : SqlSortBuilder<IllustrationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IllustrationSqlSortBuilder class.
		/// </summary>
		public IllustrationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion IllustrationSortBuilder
	
} // end namespace
