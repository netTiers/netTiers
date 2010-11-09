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
	/// This class is the base class for any <see cref="UnitMeasureProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UnitMeasureProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.UnitMeasure, Nettiers.AdventureWorks.Entities.UnitMeasureKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.UnitMeasureKey key)
		{
			return Delete(transactionManager, key.UnitMeasureCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_unitMeasureCode">Primary key.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _unitMeasureCode)
		{
			return Delete(null, _unitMeasureCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">Primary key.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _unitMeasureCode);		
		
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
		public override Nettiers.AdventureWorks.Entities.UnitMeasure Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.UnitMeasureKey key, int start, int pageLength)
		{
			return GetByUnitMeasureCode(transactionManager, key.UnitMeasureCode, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_UnitMeasure_Name index.
		/// </summary>
		/// <param name="_name">Unit of measure description.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_UnitMeasure_Name index.
		/// </summary>
		/// <param name="_name">Unit of measure description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_UnitMeasure_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Unit of measure description.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_UnitMeasure_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Unit of measure description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_UnitMeasure_Name index.
		/// </summary>
		/// <param name="_name">Unit of measure description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_UnitMeasure_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Unit of measure description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.UnitMeasure GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_UnitMeasure_UnitMeasureCode index.
		/// </summary>
		/// <param name="_unitMeasureCode">Primary key.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByUnitMeasureCode(System.String _unitMeasureCode)
		{
			int count = -1;
			return GetByUnitMeasureCode(null,_unitMeasureCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitMeasure_UnitMeasureCode index.
		/// </summary>
		/// <param name="_unitMeasureCode">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByUnitMeasureCode(System.String _unitMeasureCode, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitMeasureCode(null, _unitMeasureCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitMeasure_UnitMeasureCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">Primary key.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByUnitMeasureCode(TransactionManager transactionManager, System.String _unitMeasureCode)
		{
			int count = -1;
			return GetByUnitMeasureCode(transactionManager, _unitMeasureCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitMeasure_UnitMeasureCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByUnitMeasureCode(TransactionManager transactionManager, System.String _unitMeasureCode, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitMeasureCode(transactionManager, _unitMeasureCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitMeasure_UnitMeasureCode index.
		/// </summary>
		/// <param name="_unitMeasureCode">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.UnitMeasure GetByUnitMeasureCode(System.String _unitMeasureCode, int start, int pageLength, out int count)
		{
			return GetByUnitMeasureCode(null, _unitMeasureCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitMeasure_UnitMeasureCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_unitMeasureCode">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.UnitMeasure GetByUnitMeasureCode(TransactionManager transactionManager, System.String _unitMeasureCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;UnitMeasure&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;UnitMeasure&gt;"/></returns>
		public static TList<UnitMeasure> Fill(IDataReader reader, TList<UnitMeasure> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.UnitMeasure c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("UnitMeasure")
					.Append("|").Append((System.String)reader[((int)UnitMeasureColumn.UnitMeasureCode - 1)]).ToString();
					c = EntityManager.LocateOrCreate<UnitMeasure>(
					key.ToString(), // EntityTrackingKey
					"UnitMeasure",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.UnitMeasure();
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
					c.UnitMeasureCode = (System.String)reader[((int)UnitMeasureColumn.UnitMeasureCode - 1)];
					c.OriginalUnitMeasureCode = c.UnitMeasureCode;
					c.Name = (System.String)reader[((int)UnitMeasureColumn.Name - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)UnitMeasureColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.UnitMeasure entity)
		{
			if (!reader.Read()) return;
			
			entity.UnitMeasureCode = (System.String)reader[((int)UnitMeasureColumn.UnitMeasureCode - 1)];
			entity.OriginalUnitMeasureCode = (System.String)reader["UnitMeasureCode"];
			entity.Name = (System.String)reader[((int)UnitMeasureColumn.Name - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)UnitMeasureColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.UnitMeasure entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UnitMeasureCode = (System.String)dataRow["UnitMeasureCode"];
			entity.OriginalUnitMeasureCode = (System.String)dataRow["UnitMeasureCode"];
			entity.Name = (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.UnitMeasure"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.UnitMeasure Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.UnitMeasure entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByUnitMeasureCode methods when available
			
			#region BillOfMaterialsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<BillOfMaterials>|BillOfMaterialsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BillOfMaterialsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.BillOfMaterialsCollection = DataRepository.BillOfMaterialsProvider.GetByUnitMeasureCode(transactionManager, entity.UnitMeasureCode);

				if (deep && entity.BillOfMaterialsCollection.Count > 0)
				{
					deepHandles.Add("BillOfMaterialsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<BillOfMaterials>) DataRepository.BillOfMaterialsProvider.DeepLoad,
						new object[] { transactionManager, entity.BillOfMaterialsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductCollectionGetByWeightUnitMeasureCode
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Product>|ProductCollectionGetByWeightUnitMeasureCode", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductCollectionGetByWeightUnitMeasureCode' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductCollectionGetByWeightUnitMeasureCode = DataRepository.ProductProvider.GetByWeightUnitMeasureCode(transactionManager, entity.UnitMeasureCode);

				if (deep && entity.ProductCollectionGetByWeightUnitMeasureCode.Count > 0)
				{
					deepHandles.Add("ProductCollectionGetByWeightUnitMeasureCode",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Product>) DataRepository.ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductCollectionGetByWeightUnitMeasureCode, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductVendorCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductVendor>|ProductVendorCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductVendorCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductVendorCollection = DataRepository.ProductVendorProvider.GetByUnitMeasureCode(transactionManager, entity.UnitMeasureCode);

				if (deep && entity.ProductVendorCollection.Count > 0)
				{
					deepHandles.Add("ProductVendorCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductVendor>) DataRepository.ProductVendorProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductVendorCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductCollectionGetBySizeUnitMeasureCode
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Product>|ProductCollectionGetBySizeUnitMeasureCode", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductCollectionGetBySizeUnitMeasureCode' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductCollectionGetBySizeUnitMeasureCode = DataRepository.ProductProvider.GetBySizeUnitMeasureCode(transactionManager, entity.UnitMeasureCode);

				if (deep && entity.ProductCollectionGetBySizeUnitMeasureCode.Count > 0)
				{
					deepHandles.Add("ProductCollectionGetBySizeUnitMeasureCode",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Product>) DataRepository.ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductCollectionGetBySizeUnitMeasureCode, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.UnitMeasure object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.UnitMeasure instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.UnitMeasure Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.UnitMeasure entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<BillOfMaterials>
				if (CanDeepSave(entity.BillOfMaterialsCollection, "List<BillOfMaterials>|BillOfMaterialsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(BillOfMaterials child in entity.BillOfMaterialsCollection)
					{
						if(child.UnitMeasureCodeSource != null)
						{
							child.UnitMeasureCode = child.UnitMeasureCodeSource.UnitMeasureCode;
						}
						else
						{
							child.UnitMeasureCode = entity.UnitMeasureCode;
						}

					}

					if (entity.BillOfMaterialsCollection.Count > 0 || entity.BillOfMaterialsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.BillOfMaterialsProvider.Save(transactionManager, entity.BillOfMaterialsCollection);
						
						deepHandles.Add("BillOfMaterialsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< BillOfMaterials >) DataRepository.BillOfMaterialsProvider.DeepSave,
							new object[] { transactionManager, entity.BillOfMaterialsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Product>
				if (CanDeepSave(entity.ProductCollectionGetByWeightUnitMeasureCode, "List<Product>|ProductCollectionGetByWeightUnitMeasureCode", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Product child in entity.ProductCollectionGetByWeightUnitMeasureCode)
					{
						if(child.WeightUnitMeasureCodeSource != null)
						{
							child.WeightUnitMeasureCode = child.WeightUnitMeasureCodeSource.UnitMeasureCode;
						}
						else
						{
							child.WeightUnitMeasureCode = entity.UnitMeasureCode;
						}

					}

					if (entity.ProductCollectionGetByWeightUnitMeasureCode.Count > 0 || entity.ProductCollectionGetByWeightUnitMeasureCode.DeletedItems.Count > 0)
					{
						//DataRepository.ProductProvider.Save(transactionManager, entity.ProductCollectionGetByWeightUnitMeasureCode);
						
						deepHandles.Add("ProductCollectionGetByWeightUnitMeasureCode",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Product >) DataRepository.ProductProvider.DeepSave,
							new object[] { transactionManager, entity.ProductCollectionGetByWeightUnitMeasureCode, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ProductVendor>
				if (CanDeepSave(entity.ProductVendorCollection, "List<ProductVendor>|ProductVendorCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductVendor child in entity.ProductVendorCollection)
					{
					}

					if (entity.ProductVendorCollection.Count > 0 || entity.ProductVendorCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductVendorProvider.Save(transactionManager, entity.ProductVendorCollection);
						
						deepHandles.Add("ProductVendorCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductVendor >) DataRepository.ProductVendorProvider.DeepSave,
							new object[] { transactionManager, entity.ProductVendorCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Product>
				if (CanDeepSave(entity.ProductCollectionGetBySizeUnitMeasureCode, "List<Product>|ProductCollectionGetBySizeUnitMeasureCode", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Product child in entity.ProductCollectionGetBySizeUnitMeasureCode)
					{
						if(child.SizeUnitMeasureCodeSource != null)
						{
							child.SizeUnitMeasureCode = child.SizeUnitMeasureCodeSource.UnitMeasureCode;
						}
						else
						{
							child.SizeUnitMeasureCode = entity.UnitMeasureCode;
						}

					}

					if (entity.ProductCollectionGetBySizeUnitMeasureCode.Count > 0 || entity.ProductCollectionGetBySizeUnitMeasureCode.DeletedItems.Count > 0)
					{
						//DataRepository.ProductProvider.Save(transactionManager, entity.ProductCollectionGetBySizeUnitMeasureCode);
						
						deepHandles.Add("ProductCollectionGetBySizeUnitMeasureCode",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Product >) DataRepository.ProductProvider.DeepSave,
							new object[] { transactionManager, entity.ProductCollectionGetBySizeUnitMeasureCode, deepSaveType, childTypes, innerList }
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
	
	#region UnitMeasureChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.UnitMeasure</c>
	///</summary>
	public enum UnitMeasureChildEntityTypes
	{

		///<summary>
		/// Collection of <c>UnitMeasure</c> as OneToMany for BillOfMaterialsCollection
		///</summary>
		[ChildEntityType(typeof(TList<BillOfMaterials>))]
		BillOfMaterialsCollection,

		///<summary>
		/// Collection of <c>UnitMeasure</c> as OneToMany for ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductCollectionGetByWeightUnitMeasureCode,

		///<summary>
		/// Collection of <c>UnitMeasure</c> as OneToMany for ProductVendorCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductVendor>))]
		ProductVendorCollection,

		///<summary>
		/// Collection of <c>UnitMeasure</c> as OneToMany for ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductCollectionGetBySizeUnitMeasureCode,
	}
	
	#endregion UnitMeasureChildEntityTypes
	
	#region UnitMeasureFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;UnitMeasureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UnitMeasure"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitMeasureFilterBuilder : SqlFilterBuilder<UnitMeasureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitMeasureFilterBuilder class.
		/// </summary>
		public UnitMeasureFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitMeasureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitMeasureFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitMeasureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitMeasureFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitMeasureFilterBuilder
	
	#region UnitMeasureParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;UnitMeasureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UnitMeasure"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitMeasureParameterBuilder : ParameterizedSqlFilterBuilder<UnitMeasureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitMeasureParameterBuilder class.
		/// </summary>
		public UnitMeasureParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitMeasureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitMeasureParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitMeasureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitMeasureParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitMeasureParameterBuilder
	
	#region UnitMeasureSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;UnitMeasureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UnitMeasure"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class UnitMeasureSortBuilder : SqlSortBuilder<UnitMeasureColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitMeasureSqlSortBuilder class.
		/// </summary>
		public UnitMeasureSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion UnitMeasureSortBuilder
	
} // end namespace
