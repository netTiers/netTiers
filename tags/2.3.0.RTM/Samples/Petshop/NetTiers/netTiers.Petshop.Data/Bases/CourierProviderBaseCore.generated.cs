#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="CourierProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CourierProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.Courier, netTiers.Petshop.Entities.CourierKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Functions

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.CourierKey key)
		{
			return Delete(transactionManager, key.CourierId, ((key.Entity != null) ? key.Entity.Timestamp : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="courierId">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid courierId, byte[] timestamp)
		{
			return Delete(null, courierId, timestamp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="courierId">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid courierId, byte[] timestamp);		
		
		#endregion
		
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
		public override netTiers.Petshop.Entities.Courier Get(TransactionManager transactionManager, netTiers.Petshop.Entities.CourierKey key, int start, int pageLength)
		{
			return GetByCourierId(transactionManager, key.CourierId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Courier index.
		/// </summary>
		/// <param name="courierId"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Courier"/> class.</returns>
		public netTiers.Petshop.Entities.Courier GetByCourierId(System.Guid courierId)
		{
			int count = -1;
			return GetByCourierId(null,courierId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Courier index.
		/// </summary>
		/// <param name="courierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Courier"/> class.</returns>
		public netTiers.Petshop.Entities.Courier GetByCourierId(System.Guid courierId, int start, int pageLength)
		{
			int count = -1;
			return GetByCourierId(null, courierId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Courier index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="courierId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Courier"/> class.</returns>
		public netTiers.Petshop.Entities.Courier GetByCourierId(TransactionManager transactionManager, System.Guid courierId)
		{
			int count = -1;
			return GetByCourierId(transactionManager, courierId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Courier index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="courierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Courier"/> class.</returns>
		public netTiers.Petshop.Entities.Courier GetByCourierId(TransactionManager transactionManager, System.Guid courierId, int start, int pageLength)
		{
			int count = -1;
			return GetByCourierId(transactionManager, courierId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Courier index.
		/// </summary>
		/// <param name="courierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Courier"/> class.</returns>
		public netTiers.Petshop.Entities.Courier GetByCourierId(System.Guid courierId, int start, int pageLength, out int count)
		{
			return GetByCourierId(null, courierId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Courier index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="courierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Courier"/> class.</returns>
		public abstract netTiers.Petshop.Entities.Courier GetByCourierId(TransactionManager transactionManager, System.Guid courierId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;Courier&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;Courier&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<Courier> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<Courier> rows, int start, int pageLength)
		{
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
				
				netTiers.Petshop.Entities.Courier c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Courier" 
							+ (reader.IsDBNull(reader.GetOrdinal("CourierId"))?Guid.Empty:(System.Guid)reader["CourierId"]).ToString();

					c = EntityManager.LocateOrCreate<Courier>(
						key.ToString(), // EntityTrackingKey 
						"Courier",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.Courier();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.CourierId = (System.Guid)reader["CourierId"];
					c.OriginalCourierId = c.CourierId; //(reader.IsDBNull(reader.GetOrdinal("CourierId")))?Guid.Empty:(System.Guid)reader["CourierId"];
					c.CourierName = (System.String)reader["CourierName"];
					c.CourierDescription = (reader.IsDBNull(reader.GetOrdinal("CourierDescription")))?null:(System.String)reader["CourierDescription"];
					c.MinItems = (System.Int32)reader["MinItems"];
					c.MaxItems = (System.Int32)reader["MaxItems"];
					c.Timestamp = (System.Byte[])reader["Timestamp"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Courier"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Courier"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.Courier entity)
		{
			if (!reader.Read()) return;
			
			entity.CourierId = (System.Guid)reader["CourierId"];
			entity.OriginalCourierId = (System.Guid)reader["CourierId"];
			entity.CourierName = (System.String)reader["CourierName"];
			entity.CourierDescription = (reader.IsDBNull(reader.GetOrdinal("CourierDescription")))?null:(System.String)reader["CourierDescription"];
			entity.MinItems = (System.Int32)reader["MinItems"];
			entity.MaxItems = (System.Int32)reader["MaxItems"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Courier"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Courier"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.Courier entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CourierId = (System.Guid)dataRow["CourierId"];
			entity.OriginalCourierId = (System.Guid)dataRow["CourierId"];
			entity.CourierName = (System.String)dataRow["CourierName"];
			entity.CourierDescription = (Convert.IsDBNull(dataRow["CourierDescription"]))?null:(System.String)dataRow["CourierDescription"];
			entity.MinItems = (System.Int32)dataRow["MinItems"];
			entity.MaxItems = (System.Int32)dataRow["MaxItems"];
			entity.Timestamp = (System.Byte[])dataRow["Timestamp"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Courier"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Courier Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.Courier entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByCourierId methods when available
			
			#region OrdersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Orders>", "OrdersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrdersCollection' loaded.");
				#endif 

				entity.OrdersCollection = DataRepository.OrdersProvider.GetByCourierId(transactionManager, entity.CourierId);

				if (deep && entity.OrdersCollection.Count > 0)
				{
					DataRepository.OrdersProvider.DeepLoad(transactionManager, entity.OrdersCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.Courier object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.Courier instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Courier Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.Courier entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Source Properties


			#region List<Orders>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<Orders>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<Orders>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(Orders child in entity.OrdersCollection)
			{
					child.CourierId = entity.CourierId;			}
			
			if (entity.OrdersCollection.Count > 0)
				DataRepository.OrdersProvider.DeepSave(transactionManager, entity.OrdersCollection, deepSaveType, childTypes);
			} 
			#endregion 
		}
		#endregion
	} // end class
	
	#region CourierChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.Courier</c>
	///</summary>
	public enum CourierChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Courier</c> as OneToMany for OrdersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Orders>))]
		OrdersCollection,
	}
	
	#endregion CourierChildEntityTypes
	
	#region CourierFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Courier"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourierFilterBuilder : SqlFilterBuilder<CourierColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourierFilterBuilder class.
		/// </summary>
		public CourierFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourierFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourierFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourierFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourierFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourierFilterBuilder
} // end namespace
