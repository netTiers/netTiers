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
	/// This class is the base class for any <see cref="LocationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LocationProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Location, Nettiers.AdventureWorks.Entities.LocationKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByProductIdFromProductInventory
		
		/// <summary>
		///		Gets Location objects from the datasource by ProductID in the
		///		ProductInventory table. Table Location is related to table Product
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Location objects.</returns>
		public TList<Location> GetByProductIdFromProductInventory(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromProductInventory(null,_productId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Location objects from the datasource by ProductID in the
		///		ProductInventory table. Table Location is related to table Product
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Location objects.</returns>
		public TList<Location> GetByProductIdFromProductInventory(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromProductInventory(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Location objects from the datasource by ProductID in the
		///		ProductInventory table. Table Location is related to table Product
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Location objects.</returns>
		public TList<Location> GetByProductIdFromProductInventory(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromProductInventory(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Location objects from the datasource by ProductID in the
		///		ProductInventory table. Table Location is related to table Product
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Location objects.</returns>
		public TList<Location> GetByProductIdFromProductInventory(TransactionManager transactionManager, System.Int32 _productId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromProductInventory(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Location objects from the datasource by ProductID in the
		///		ProductInventory table. Table Location is related to table Product
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Location objects.</returns>
		public TList<Location> GetByProductIdFromProductInventory(System.Int32 _productId,int start, int pageLength, out int count)
		{
			
			return GetByProductIdFromProductInventory(null, _productId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Location objects from the datasource by ProductID in the
		///		ProductInventory table. Table Location is related to table Product
		///		through the (M:N) relationship defined in the ProductInventory table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productId">Product identification number. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Location objects.</returns>
		public abstract TList<Location> GetByProductIdFromProductInventory(TransactionManager transactionManager,System.Int32 _productId, int start, int pageLength, out int count);
		
		#endregion GetByProductIdFromProductInventory
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.LocationKey key)
		{
			return Delete(transactionManager, key.LocationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_locationId">Primary key for Location records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int16 _locationId)
		{
			return Delete(null, _locationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">Primary key for Location records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int16 _locationId);		
		
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
		public override Nettiers.AdventureWorks.Entities.Location Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.LocationKey key, int start, int pageLength)
		{
			return GetByLocationId(transactionManager, key.LocationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Location_Name index.
		/// </summary>
		/// <param name="_name">Location description.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Location_Name index.
		/// </summary>
		/// <param name="_name">Location description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Location_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Location description.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Location_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Location description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Location_Name index.
		/// </summary>
		/// <param name="_name">Location description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Location_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Location description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Location GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Location_LocationID index.
		/// </summary>
		/// <param name="_locationId">Primary key for Location records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByLocationId(System.Int16 _locationId)
		{
			int count = -1;
			return GetByLocationId(null,_locationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Location_LocationID index.
		/// </summary>
		/// <param name="_locationId">Primary key for Location records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByLocationId(System.Int16 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetByLocationId(null, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Location_LocationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">Primary key for Location records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByLocationId(TransactionManager transactionManager, System.Int16 _locationId)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Location_LocationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">Primary key for Location records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByLocationId(TransactionManager transactionManager, System.Int16 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Location_LocationID index.
		/// </summary>
		/// <param name="_locationId">Primary key for Location records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Location GetByLocationId(System.Int16 _locationId, int start, int pageLength, out int count)
		{
			return GetByLocationId(null, _locationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Location_LocationID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">Primary key for Location records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Location"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Location GetByLocationId(TransactionManager transactionManager, System.Int16 _locationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Location&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Location&gt;"/></returns>
		public static TList<Location> Fill(IDataReader reader, TList<Location> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Location c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Location")
					.Append("|").Append((System.Int16)reader[((int)LocationColumn.LocationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Location>(
					key.ToString(), // EntityTrackingKey
					"Location",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Location();
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
					c.LocationId = (System.Int16)reader[((int)LocationColumn.LocationId - 1)];
					c.Name = (System.String)reader[((int)LocationColumn.Name - 1)];
					c.CostRate = (System.Decimal)reader[((int)LocationColumn.CostRate - 1)];
					c.Availability = (System.Decimal)reader[((int)LocationColumn.Availability - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)LocationColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Location"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Location"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Location entity)
		{
			if (!reader.Read()) return;
			
			entity.LocationId = (System.Int16)reader[((int)LocationColumn.LocationId - 1)];
			entity.Name = (System.String)reader[((int)LocationColumn.Name - 1)];
			entity.CostRate = (System.Decimal)reader[((int)LocationColumn.CostRate - 1)];
			entity.Availability = (System.Decimal)reader[((int)LocationColumn.Availability - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)LocationColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Location"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Location"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Location entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.LocationId = (System.Int16)dataRow["LocationID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.CostRate = (System.Decimal)dataRow["CostRate"];
			entity.Availability = (System.Decimal)dataRow["Availability"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Location"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Location Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Location entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByLocationId methods when available
			
			#region WorkOrderRoutingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<WorkOrderRouting>|WorkOrderRoutingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WorkOrderRoutingCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WorkOrderRoutingCollection = DataRepository.WorkOrderRoutingProvider.GetByLocationId(transactionManager, entity.LocationId);

				if (deep && entity.WorkOrderRoutingCollection.Count > 0)
				{
					deepHandles.Add("WorkOrderRoutingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WorkOrderRouting>) DataRepository.WorkOrderRoutingProvider.DeepLoad,
						new object[] { transactionManager, entity.WorkOrderRoutingCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductIdProductCollection_From_ProductInventory
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Product>|ProductIdProductCollection_From_ProductInventory", deepLoadType, innerList))
			{
				entity.ProductIdProductCollection_From_ProductInventory = DataRepository.ProductProvider.GetByLocationIdFromProductInventory(transactionManager, entity.LocationId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdProductCollection_From_ProductInventory' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdProductCollection_From_ProductInventory != null)
				{
					deepHandles.Add("ProductIdProductCollection_From_ProductInventory",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Product >) DataRepository.ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_ProductInventory, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ProductInventoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductInventory>|ProductInventoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductInventoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductInventoryCollection = DataRepository.ProductInventoryProvider.GetByLocationId(transactionManager, entity.LocationId);

				if (deep && entity.ProductInventoryCollection.Count > 0)
				{
					deepHandles.Add("ProductInventoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductInventory>) DataRepository.ProductInventoryProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductInventoryCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Location object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Location instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Location Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Location entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region ProductIdProductCollection_From_ProductInventory>
			if (CanDeepSave(entity.ProductIdProductCollection_From_ProductInventory, "List<Product>|ProductIdProductCollection_From_ProductInventory", deepSaveType, innerList))
			{
				if (entity.ProductIdProductCollection_From_ProductInventory.Count > 0 || entity.ProductIdProductCollection_From_ProductInventory.DeletedItems.Count > 0)
				{
					DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdProductCollection_From_ProductInventory); 
					deepHandles.Add("ProductIdProductCollection_From_ProductInventory",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Product>) DataRepository.ProductProvider.DeepSave,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_ProductInventory, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<WorkOrderRouting>
				if (CanDeepSave(entity.WorkOrderRoutingCollection, "List<WorkOrderRouting>|WorkOrderRoutingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WorkOrderRouting child in entity.WorkOrderRoutingCollection)
					{
						if(child.LocationIdSource != null)
						{
							child.LocationId = child.LocationIdSource.LocationId;
						}
						else
						{
							child.LocationId = entity.LocationId;
						}

					}

					if (entity.WorkOrderRoutingCollection.Count > 0 || entity.WorkOrderRoutingCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WorkOrderRoutingProvider.Save(transactionManager, entity.WorkOrderRoutingCollection);
						
						deepHandles.Add("WorkOrderRoutingCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< WorkOrderRouting >) DataRepository.WorkOrderRoutingProvider.DeepSave,
							new object[] { transactionManager, entity.WorkOrderRoutingCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ProductInventory>
				if (CanDeepSave(entity.ProductInventoryCollection, "List<ProductInventory>|ProductInventoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductInventory child in entity.ProductInventoryCollection)
					{
						if(child.LocationIdSource != null)
						{
								child.LocationId = child.LocationIdSource.LocationId;
						}

						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

					}

					if (entity.ProductInventoryCollection.Count > 0 || entity.ProductInventoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductInventoryProvider.Save(transactionManager, entity.ProductInventoryCollection);
						
						deepHandles.Add("ProductInventoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductInventory >) DataRepository.ProductInventoryProvider.DeepSave,
							new object[] { transactionManager, entity.ProductInventoryCollection, deepSaveType, childTypes, innerList }
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
	
	#region LocationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Location</c>
	///</summary>
	public enum LocationChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Location</c> as OneToMany for WorkOrderRoutingCollection
		///</summary>
		[ChildEntityType(typeof(TList<WorkOrderRouting>))]
		WorkOrderRoutingCollection,

		///<summary>
		/// Collection of <c>Location</c> as ManyToMany for ProductCollection_From_ProductInventory
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductIdProductCollection_From_ProductInventory,

		///<summary>
		/// Collection of <c>Location</c> as OneToMany for ProductInventoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductInventory>))]
		ProductInventoryCollection,
	}
	
	#endregion LocationChildEntityTypes
	
	#region LocationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LocationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LocationFilterBuilder : SqlFilterBuilder<LocationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationFilterBuilder class.
		/// </summary>
		public LocationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LocationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LocationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LocationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LocationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LocationFilterBuilder
	
	#region LocationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LocationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LocationParameterBuilder : ParameterizedSqlFilterBuilder<LocationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationParameterBuilder class.
		/// </summary>
		public LocationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LocationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LocationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LocationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LocationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LocationParameterBuilder
	
	#region LocationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;LocationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class LocationSortBuilder : SqlSortBuilder<LocationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationSqlSortBuilder class.
		/// </summary>
		public LocationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion LocationSortBuilder
	
} // end namespace
