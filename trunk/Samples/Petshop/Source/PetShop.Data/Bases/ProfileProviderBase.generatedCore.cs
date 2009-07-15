#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using PetShop.Business;
using PetShop.Data;

#endregion

namespace PetShop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ProfileProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProfileProviderBaseCore : EntityProviderBase<PetShop.Business.Profile, PetShop.Business.ProfileKey>
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
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.ProfileKey key)
		{
			return Delete(transactionManager, key.UniqueId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_uniqueId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(int _uniqueId)
		{
			return Delete(null, _uniqueId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, int _uniqueId);		
		
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
		public override PetShop.Business.Profile Get(TransactionManager transactionManager, PetShop.Business.ProfileKey key, int start, int pageLength)
		{
			return GetByUniqueId(transactionManager, key.UniqueId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Profiles index.
		/// </summary>
		/// <param name="_username"></param>
		/// <param name="_applicationName"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUsernameApplicationName(string _username, string _applicationName)
		{
			int count = -1;
			return GetByUsernameApplicationName(null,_username, _applicationName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles index.
		/// </summary>
		/// <param name="_username"></param>
		/// <param name="_applicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUsernameApplicationName(string _username, string _applicationName, int start, int pageLength)
		{
			int count = -1;
			return GetByUsernameApplicationName(null, _username, _applicationName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_username"></param>
		/// <param name="_applicationName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUsernameApplicationName(TransactionManager transactionManager, string _username, string _applicationName)
		{
			int count = -1;
			return GetByUsernameApplicationName(transactionManager, _username, _applicationName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_username"></param>
		/// <param name="_applicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUsernameApplicationName(TransactionManager transactionManager, string _username, string _applicationName, int start, int pageLength)
		{
			int count = -1;
			return GetByUsernameApplicationName(transactionManager, _username, _applicationName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles index.
		/// </summary>
		/// <param name="_username"></param>
		/// <param name="_applicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUsernameApplicationName(string _username, string _applicationName, int start, int pageLength, out int count)
		{
			return GetByUsernameApplicationName(null, _username, _applicationName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_username"></param>
		/// <param name="_applicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public abstract PetShop.Business.Profile GetByUsernameApplicationName(TransactionManager transactionManager, string _username, string _applicationName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Profiles_1 index.
		/// </summary>
		/// <param name="_uniqueId"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUniqueId(int _uniqueId)
		{
			int count = -1;
			return GetByUniqueId(null,_uniqueId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles_1 index.
		/// </summary>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUniqueId(int _uniqueId, int start, int pageLength)
		{
			int count = -1;
			return GetByUniqueId(null, _uniqueId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUniqueId(TransactionManager transactionManager, int _uniqueId)
		{
			int count = -1;
			return GetByUniqueId(transactionManager, _uniqueId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUniqueId(TransactionManager transactionManager, int _uniqueId, int start, int pageLength)
		{
			int count = -1;
			return GetByUniqueId(transactionManager, _uniqueId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles_1 index.
		/// </summary>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public PetShop.Business.Profile GetByUniqueId(int _uniqueId, int start, int pageLength, out int count)
		{
			return GetByUniqueId(null, _uniqueId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Profiles_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Profile"/> class.</returns>
		public abstract PetShop.Business.Profile GetByUniqueId(TransactionManager transactionManager, int _uniqueId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Profile&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Profile&gt;"/></returns>
		public static TList<Profile> Fill(IDataReader reader, TList<Profile> rows, int start, int pageLength)
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
				
				PetShop.Business.Profile c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Profile")
					.Append("|").Append((int)reader[((int)ProfileColumn.UniqueId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Profile>(
					key.ToString(), // EntityTrackingKey
					"Profile",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.Profile();
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
					c.UniqueId = (int)reader[((int)ProfileColumn.UniqueId - 1)];
					c.Username = (string)reader[((int)ProfileColumn.Username - 1)];
					c.ApplicationName = (string)reader[((int)ProfileColumn.ApplicationName - 1)];
					c.IsAnonymous = (reader.IsDBNull(((int)ProfileColumn.IsAnonymous - 1)))?null:(System.Boolean?)reader[((int)ProfileColumn.IsAnonymous - 1)];
					c.LastActivityDate = (reader.IsDBNull(((int)ProfileColumn.LastActivityDate - 1)))?null:(System.DateTime?)reader[((int)ProfileColumn.LastActivityDate - 1)];
					c.LastUpdatedDate = (reader.IsDBNull(((int)ProfileColumn.LastUpdatedDate - 1)))?null:(System.DateTime?)reader[((int)ProfileColumn.LastUpdatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Profile"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Profile"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.Profile entity)
		{
			if (!reader.Read()) return;
			
			entity.UniqueId = (int)reader[((int)ProfileColumn.UniqueId - 1)];
			entity.Username = (string)reader[((int)ProfileColumn.Username - 1)];
			entity.ApplicationName = (string)reader[((int)ProfileColumn.ApplicationName - 1)];
			entity.IsAnonymous = (reader.IsDBNull(((int)ProfileColumn.IsAnonymous - 1)))?null:(System.Boolean?)reader[((int)ProfileColumn.IsAnonymous - 1)];
			entity.LastActivityDate = (reader.IsDBNull(((int)ProfileColumn.LastActivityDate - 1)))?null:(System.DateTime?)reader[((int)ProfileColumn.LastActivityDate - 1)];
			entity.LastUpdatedDate = (reader.IsDBNull(((int)ProfileColumn.LastUpdatedDate - 1)))?null:(System.DateTime?)reader[((int)ProfileColumn.LastUpdatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Profile"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Profile"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.Profile entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UniqueId = (int)dataRow["UniqueID"];
			entity.Username = (string)dataRow["Username"];
			entity.ApplicationName = (string)dataRow["ApplicationName"];
			entity.IsAnonymous = Convert.IsDBNull(dataRow["IsAnonymous"]) ? null : (System.Boolean?)dataRow["IsAnonymous"];
			entity.LastActivityDate = Convert.IsDBNull(dataRow["LastActivityDate"]) ? null : (System.DateTime?)dataRow["LastActivityDate"];
			entity.LastUpdatedDate = Convert.IsDBNull(dataRow["LastUpdatedDate"]) ? null : (System.DateTime?)dataRow["LastUpdatedDate"];
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
		/// <param name="entity">The <see cref="PetShop.Business.Profile"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.Profile Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.Profile entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByUniqueId methods when available
			
			#region CartCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Cart>|CartCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CartCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CartCollection = DataRepository.CartProvider.GetByUniqueId(transactionManager, entity.UniqueId);

				if (deep && entity.CartCollection.Count > 0)
				{
					deepHandles.Add("CartCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Cart>) DataRepository.CartProvider.DeepLoad,
						new object[] { transactionManager, entity.CartCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AccountCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Account>|AccountCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AccountCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AccountCollection = DataRepository.AccountProvider.GetByUniqueId(transactionManager, entity.UniqueId);

				if (deep && entity.AccountCollection.Count > 0)
				{
					deepHandles.Add("AccountCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Account>) DataRepository.AccountProvider.DeepLoad,
						new object[] { transactionManager, entity.AccountCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the PetShop.Business.Profile object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.Profile instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.Profile Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.Profile entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Cart>
				if (CanDeepSave(entity.CartCollection, "List<Cart>|CartCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Cart child in entity.CartCollection)
					{
						if(child.UniqueIdSource != null)
						{
							child.UniqueId = child.UniqueIdSource.UniqueId;
						}
						else
						{
							child.UniqueId = entity.UniqueId;
						}

					}

					if (entity.CartCollection.Count > 0 || entity.CartCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CartProvider.Save(transactionManager, entity.CartCollection);
						
						deepHandles.Add("CartCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Cart >) DataRepository.CartProvider.DeepSave,
							new object[] { transactionManager, entity.CartCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Account>
				if (CanDeepSave(entity.AccountCollection, "List<Account>|AccountCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Account child in entity.AccountCollection)
					{
						if(child.UniqueIdSource != null)
						{
							child.UniqueId = child.UniqueIdSource.UniqueId;
						}
						else
						{
							child.UniqueId = entity.UniqueId;
						}

					}

					if (entity.AccountCollection.Count > 0 || entity.AccountCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AccountProvider.Save(transactionManager, entity.AccountCollection);
						
						deepHandles.Add("AccountCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Account >) DataRepository.AccountProvider.DeepSave,
							new object[] { transactionManager, entity.AccountCollection, deepSaveType, childTypes, innerList }
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
	
	#region ProfileChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.Profile</c>
	///</summary>
	public enum ProfileChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Profile</c> as OneToMany for CartCollection
		///</summary>
		[ChildEntityType(typeof(TList<Cart>))]
		CartCollection,

		///<summary>
		/// Collection of <c>Profile</c> as OneToMany for AccountCollection
		///</summary>
		[ChildEntityType(typeof(TList<Account>))]
		AccountCollection,
	}
	
	#endregion ProfileChildEntityTypes
	
	#region ProfileFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProfileColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfileFilterBuilder : SqlFilterBuilder<ProfileColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfileFilterBuilder class.
		/// </summary>
		public ProfileFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfileFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfileFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfileFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfileFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfileFilterBuilder
	
	#region ProfileParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProfileColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfileParameterBuilder : ParameterizedSqlFilterBuilder<ProfileColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfileParameterBuilder class.
		/// </summary>
		public ProfileParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfileParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfileParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfileParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfileParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfileParameterBuilder
	
	#region ProfileSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProfileColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profile"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProfileSortBuilder : SqlSortBuilder<ProfileColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfileSqlSortBuilder class.
		/// </summary>
		public ProfileSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProfileSortBuilder
	
} // end namespace
