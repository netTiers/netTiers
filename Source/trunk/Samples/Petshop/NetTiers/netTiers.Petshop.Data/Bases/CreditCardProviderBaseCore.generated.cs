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
	/// This class is the base class for any <see cref="CreditCardProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CreditCardProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.CreditCard, netTiers.Petshop.Entities.CreditCardKey>
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
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.CreditCardKey key)
		{
			return Delete(transactionManager, key.Id, ((key.Entity != null) ? key.Entity.Timestamp : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="id">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid id, byte[] timestamp)
		{
			return Delete(null, id, timestamp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid id, byte[] timestamp);		
		
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
		public override netTiers.Petshop.Entities.CreditCard Get(TransactionManager transactionManager, netTiers.Petshop.Entities.CreditCardKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CreditCard index.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.CreditCard"/> class.</returns>
		public netTiers.Petshop.Entities.CreditCard GetById(System.Guid id)
		{
			int count = -1;
			return GetById(null,id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.CreditCard"/> class.</returns>
		public netTiers.Petshop.Entities.CreditCard GetById(System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.CreditCard"/> class.</returns>
		public netTiers.Petshop.Entities.CreditCard GetById(TransactionManager transactionManager, System.Guid id)
		{
			int count = -1;
			return GetById(transactionManager, id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.CreditCard"/> class.</returns>
		public netTiers.Petshop.Entities.CreditCard GetById(TransactionManager transactionManager, System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.CreditCard"/> class.</returns>
		public netTiers.Petshop.Entities.CreditCard GetById(System.Guid id, int start, int pageLength, out int count)
		{
			return GetById(null, id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.CreditCard"/> class.</returns>
		public abstract netTiers.Petshop.Entities.CreditCard GetById(TransactionManager transactionManager, System.Guid id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;CreditCard&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;CreditCard&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<CreditCard> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<CreditCard> rows, int start, int pageLength)
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
				
				netTiers.Petshop.Entities.CreditCard c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"CreditCard" 
							+ (reader.IsDBNull(reader.GetOrdinal("Id"))?Guid.Empty:(System.Guid)reader["Id"]).ToString();

					c = EntityManager.LocateOrCreate<CreditCard>(
						key.ToString(), // EntityTrackingKey 
						"CreditCard",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.CreditCard();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.Id = (System.Guid)reader["Id"];
					c.OriginalId = c.Id; //(reader.IsDBNull(reader.GetOrdinal("Id")))?Guid.Empty:(System.Guid)reader["Id"];
					c.Number = (System.String)reader["Number"];
					c.CardType = (System.String)reader["CardType"];
					c.ExpiryMonth = (System.String)reader["ExpiryMonth"];
					c.ExpiryYear = (System.String)reader["ExpiryYear"];
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
		/// Refreshes the <see cref="netTiers.Petshop.Entities.CreditCard"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.CreditCard"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.CreditCard entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Guid)reader["Id"];
			entity.OriginalId = (System.Guid)reader["Id"];
			entity.Number = (System.String)reader["Number"];
			entity.CardType = (System.String)reader["CardType"];
			entity.ExpiryMonth = (System.String)reader["ExpiryMonth"];
			entity.ExpiryYear = (System.String)reader["ExpiryYear"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.CreditCard"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.CreditCard"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.CreditCard entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Guid)dataRow["Id"];
			entity.OriginalId = (System.Guid)dataRow["Id"];
			entity.Number = (System.String)dataRow["Number"];
			entity.CardType = (System.String)dataRow["CardType"];
			entity.ExpiryMonth = (System.String)dataRow["ExpiryMonth"];
			entity.ExpiryYear = (System.String)dataRow["ExpiryYear"];
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
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.CreditCard"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.CreditCard Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.CreditCard entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetById methods when available
			
			#region OrdersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Orders>", "OrdersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrdersCollection' loaded.");
				#endif 

				entity.OrdersCollection = DataRepository.OrdersProvider.GetByCreditCardId(transactionManager, entity.Id);

				if (deep && entity.OrdersCollection.Count > 0)
				{
					DataRepository.OrdersProvider.DeepLoad(transactionManager, entity.OrdersCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region AccountCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Account>", "AccountCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'AccountCollection' loaded.");
				#endif 

				entity.AccountCollection = DataRepository.AccountProvider.GetByCreditCardId(transactionManager, entity.Id);

				if (deep && entity.AccountCollection.Count > 0)
				{
					DataRepository.AccountProvider.DeepLoad(transactionManager, entity.AccountCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.CreditCard object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.CreditCard instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.CreditCard Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.CreditCard entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
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
					child.CreditCardId = entity.Id;			}
			
			if (entity.OrdersCollection.Count > 0)
				DataRepository.OrdersProvider.DeepSave(transactionManager, entity.OrdersCollection, deepSaveType, childTypes);
			} 
			#endregion 

			#region List<Account>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<Account>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<Account>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(Account child in entity.AccountCollection)
			{
					child.CreditCardId = entity.Id;			}
			
			if (entity.AccountCollection.Count > 0)
				DataRepository.AccountProvider.DeepSave(transactionManager, entity.AccountCollection, deepSaveType, childTypes);
			} 
			#endregion 
		}
		#endregion
	} // end class
	
	#region CreditCardChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.CreditCard</c>
	///</summary>
	public enum CreditCardChildEntityTypes
	{

		///<summary>
		/// Collection of <c>CreditCard</c> as OneToMany for OrdersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Orders>))]
		OrdersCollection,

		///<summary>
		/// Collection of <c>CreditCard</c> as OneToMany for AccountCollection
		///</summary>
		[ChildEntityType(typeof(TList<Account>))]
		AccountCollection,
	}
	
	#endregion CreditCardChildEntityTypes
	
	#region CreditCardFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CreditCardFilterBuilder : SqlFilterBuilder<CreditCardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CreditCardFilterBuilder class.
		/// </summary>
		public CreditCardFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CreditCardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CreditCardFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CreditCardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CreditCardFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CreditCardFilterBuilder
} // end namespace
