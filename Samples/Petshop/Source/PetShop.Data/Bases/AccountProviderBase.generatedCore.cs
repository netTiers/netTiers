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
	/// This class is the base class for any <see cref="AccountProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AccountProviderBaseCore : EntityProviderBase<PetShop.Business.Account, PetShop.Business.AccountKey>
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
		public override bool Delete(TransactionManager transactionManager, PetShop.Business.AccountKey key)
		{
			return Delete(transactionManager, key.AccountId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_accountId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(int _accountId)
		{
			return Delete(null, _accountId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, int _accountId);		
		
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
		public override PetShop.Business.Account Get(TransactionManager transactionManager, PetShop.Business.AccountKey key, int start, int pageLength)
		{
			return GetByAccountId(transactionManager, key.AccountId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key FK_Account_UniqueID index.
		/// </summary>
		/// <param name="_uniqueId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Account&gt;"/> class.</returns>
		public TList<Account> GetByUniqueId(int _uniqueId)
		{
			int count = -1;
			return GetByUniqueId(null,_uniqueId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_UniqueID index.
		/// </summary>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Account&gt;"/> class.</returns>
		public TList<Account> GetByUniqueId(int _uniqueId, int start, int pageLength)
		{
			int count = -1;
			return GetByUniqueId(null, _uniqueId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_UniqueID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Account&gt;"/> class.</returns>
		public TList<Account> GetByUniqueId(TransactionManager transactionManager, int _uniqueId)
		{
			int count = -1;
			return GetByUniqueId(transactionManager, _uniqueId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_UniqueID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Account&gt;"/> class.</returns>
		public TList<Account> GetByUniqueId(TransactionManager transactionManager, int _uniqueId, int start, int pageLength)
		{
			int count = -1;
			return GetByUniqueId(transactionManager, _uniqueId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_UniqueID index.
		/// </summary>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Account&gt;"/> class.</returns>
		public TList<Account> GetByUniqueId(int _uniqueId, int start, int pageLength, out int count)
		{
			return GetByUniqueId(null, _uniqueId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_UniqueID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Account&gt;"/> class.</returns>
		public abstract TList<Account> GetByUniqueId(TransactionManager transactionManager, int _uniqueId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Account index.
		/// </summary>
		/// <param name="_accountId"></param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Account"/> class.</returns>
		public PetShop.Business.Account GetByAccountId(int _accountId)
		{
			int count = -1;
			return GetByAccountId(null,_accountId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="_accountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Account"/> class.</returns>
		public PetShop.Business.Account GetByAccountId(int _accountId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountId(null, _accountId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Account"/> class.</returns>
		public PetShop.Business.Account GetByAccountId(TransactionManager transactionManager, int _accountId)
		{
			int count = -1;
			return GetByAccountId(transactionManager, _accountId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Account"/> class.</returns>
		public PetShop.Business.Account GetByAccountId(TransactionManager transactionManager, int _accountId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountId(transactionManager, _accountId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="_accountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Account"/> class.</returns>
		public PetShop.Business.Account GetByAccountId(int _accountId, int start, int pageLength, out int count)
		{
			return GetByAccountId(null, _accountId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="PetShop.Business.Account"/> class.</returns>
		public abstract PetShop.Business.Account GetByAccountId(TransactionManager transactionManager, int _accountId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Account&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Account&gt;"/></returns>
		public static TList<Account> Fill(IDataReader reader, TList<Account> rows, int start, int pageLength)
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
				
				PetShop.Business.Account c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Account")
					.Append("|").Append((int)reader[((int)AccountColumn.AccountId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Account>(
					key.ToString(), // EntityTrackingKey
					"Account",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new PetShop.Business.Account();
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
					c.AccountId = (int)reader[((int)AccountColumn.AccountId - 1)];
					c.UniqueId = (int)reader[((int)AccountColumn.UniqueId - 1)];
					c.Email = (string)reader[((int)AccountColumn.Email - 1)];
					c.FirstName = (string)reader[((int)AccountColumn.FirstName - 1)];
					c.LastName = (string)reader[((int)AccountColumn.LastName - 1)];
					c.Address1 = (string)reader[((int)AccountColumn.Address1 - 1)];
					c.Address2 = (reader.IsDBNull(((int)AccountColumn.Address2 - 1)))?null:(string)reader[((int)AccountColumn.Address2 - 1)];
					c.City = (string)reader[((int)AccountColumn.City - 1)];
					c.State = (string)reader[((int)AccountColumn.State - 1)];
					c.Zip = (string)reader[((int)AccountColumn.Zip - 1)];
					c.Country = (string)reader[((int)AccountColumn.Country - 1)];
					c.Phone = (reader.IsDBNull(((int)AccountColumn.Phone - 1)))?null:(string)reader[((int)AccountColumn.Phone - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Account"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Account"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, PetShop.Business.Account entity)
		{
			if (!reader.Read()) return;
			
			entity.AccountId = (int)reader[((int)AccountColumn.AccountId - 1)];
			entity.UniqueId = (int)reader[((int)AccountColumn.UniqueId - 1)];
			entity.Email = (string)reader[((int)AccountColumn.Email - 1)];
			entity.FirstName = (string)reader[((int)AccountColumn.FirstName - 1)];
			entity.LastName = (string)reader[((int)AccountColumn.LastName - 1)];
			entity.Address1 = (string)reader[((int)AccountColumn.Address1 - 1)];
			entity.Address2 = (reader.IsDBNull(((int)AccountColumn.Address2 - 1)))?null:(string)reader[((int)AccountColumn.Address2 - 1)];
			entity.City = (string)reader[((int)AccountColumn.City - 1)];
			entity.State = (string)reader[((int)AccountColumn.State - 1)];
			entity.Zip = (string)reader[((int)AccountColumn.Zip - 1)];
			entity.Country = (string)reader[((int)AccountColumn.Country - 1)];
			entity.Phone = (reader.IsDBNull(((int)AccountColumn.Phone - 1)))?null:(string)reader[((int)AccountColumn.Phone - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="PetShop.Business.Account"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="PetShop.Business.Account"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, PetShop.Business.Account entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AccountId = (int)dataRow["AccountId"];
			entity.UniqueId = (int)dataRow["UniqueID"];
			entity.Email = (string)dataRow["Email"];
			entity.FirstName = (string)dataRow["FirstName"];
			entity.LastName = (string)dataRow["LastName"];
			entity.Address1 = (string)dataRow["Address1"];
			entity.Address2 = Convert.IsDBNull(dataRow["Address2"]) ? null : (string)dataRow["Address2"];
			entity.City = (string)dataRow["City"];
			entity.State = (string)dataRow["State"];
			entity.Zip = (string)dataRow["Zip"];
			entity.Country = (string)dataRow["Country"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (string)dataRow["Phone"];
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
		/// <param name="entity">The <see cref="PetShop.Business.Account"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">PetShop.Business.Account Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, PetShop.Business.Account entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region UniqueIdSource	
			if (CanDeepLoad(entity, "Profile|UniqueIdSource", deepLoadType, innerList) 
				&& entity.UniqueIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.UniqueId;
				Profile tmpEntity = EntityManager.LocateEntity<Profile>(EntityLocator.ConstructKeyFromPkItems(typeof(Profile), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UniqueIdSource = tmpEntity;
				else
					entity.UniqueIdSource = DataRepository.ProfileProvider.GetByUniqueId(transactionManager, entity.UniqueId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UniqueIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UniqueIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProfileProvider.DeepLoad(transactionManager, entity.UniqueIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UniqueIdSource
			
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
		/// Deep Save the entire object graph of the PetShop.Business.Account object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">PetShop.Business.Account instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">PetShop.Business.Account Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, PetShop.Business.Account entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region UniqueIdSource
			if (CanDeepSave(entity, "Profile|UniqueIdSource", deepSaveType, innerList) 
				&& entity.UniqueIdSource != null)
			{
				DataRepository.ProfileProvider.Save(transactionManager, entity.UniqueIdSource);
				entity.UniqueId = entity.UniqueIdSource.UniqueId;
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
	
	#region AccountChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>PetShop.Business.Account</c>
	///</summary>
	public enum AccountChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Profile</c> at UniqueIdSource
		///</summary>
		[ChildEntityType(typeof(Profile))]
		Profile,
		}
	
	#endregion AccountChildEntityTypes
	
	#region AccountFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AccountColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Account"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountFilterBuilder : SqlFilterBuilder<AccountColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountFilterBuilder class.
		/// </summary>
		public AccountFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountFilterBuilder
	
	#region AccountParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AccountColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Account"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountParameterBuilder : ParameterizedSqlFilterBuilder<AccountColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountParameterBuilder class.
		/// </summary>
		public AccountParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountParameterBuilder
	
	#region AccountSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AccountColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Account"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AccountSortBuilder : SqlSortBuilder<AccountColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountSqlSortBuilder class.
		/// </summary>
		public AccountSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AccountSortBuilder
	
} // end namespace
