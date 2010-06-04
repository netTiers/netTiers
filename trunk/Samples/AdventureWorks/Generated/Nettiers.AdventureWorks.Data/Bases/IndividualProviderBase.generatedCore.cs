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
	/// This class is the base class for any <see cref="IndividualProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class IndividualProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Individual, Nettiers.AdventureWorks.Entities.IndividualKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.IndividualKey key)
		{
			return Delete(transactionManager, key.CustomerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _customerId)
		{
			return Delete(null, _customerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _customerId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Individual_Contact_ContactID key.
		///		FK_Individual_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="_contactId">Identifies the customer in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		public TList<Individual> GetByContactId(System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(_contactId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Individual_Contact_ContactID key.
		///		FK_Individual_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Identifies the customer in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		/// <remarks></remarks>
		public TList<Individual> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Individual_Contact_ContactID key.
		///		FK_Individual_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Identifies the customer in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		public TList<Individual> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Individual_Contact_ContactID key.
		///		fkIndividualContactContactId Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Identifies the customer in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		public TList<Individual> GetByContactId(System.Int32 _contactId, int start, int pageLength)
		{
			int count =  -1;
			return GetByContactId(null, _contactId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Individual_Contact_ContactID key.
		///		fkIndividualContactContactId Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Identifies the customer in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		public TList<Individual> GetByContactId(System.Int32 _contactId, int start, int pageLength,out int count)
		{
			return GetByContactId(null, _contactId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Individual_Contact_ContactID key.
		///		FK_Individual_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Identifies the customer in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		public abstract TList<Individual> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.Individual Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.IndividualKey key, int start, int pageLength)
		{
			return GetByCustomerId(transactionManager, key.CustomerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Individual_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Individual"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Individual GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Individual_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Individual"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Individual GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Individual_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Individual"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Individual GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Individual_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Individual"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Individual GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Individual_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Individual"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Individual GetByCustomerId(System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Individual_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Individual"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Individual GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PXML_Individual_Demographics index.
		/// </summary>
		/// <param name="_demographics">Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Individual&gt;"/> class.</returns>
		public TList<Individual> GetByDemographics(string _demographics)
		{
			int count = -1;
			return GetByDemographics(null,_demographics, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Individual_Demographics index.
		/// </summary>
		/// <param name="_demographics">Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Individual&gt;"/> class.</returns>
		public TList<Individual> GetByDemographics(string _demographics, int start, int pageLength)
		{
			int count = -1;
			return GetByDemographics(null, _demographics, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Individual_Demographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_demographics">Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Individual&gt;"/> class.</returns>
		public TList<Individual> GetByDemographics(TransactionManager transactionManager, string _demographics)
		{
			int count = -1;
			return GetByDemographics(transactionManager, _demographics, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Individual_Demographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_demographics">Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Individual&gt;"/> class.</returns>
		public TList<Individual> GetByDemographics(TransactionManager transactionManager, string _demographics, int start, int pageLength)
		{
			int count = -1;
			return GetByDemographics(transactionManager, _demographics, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Individual_Demographics index.
		/// </summary>
		/// <param name="_demographics">Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Individual&gt;"/> class.</returns>
		public TList<Individual> GetByDemographics(string _demographics, int start, int pageLength, out int count)
		{
			return GetByDemographics(null, _demographics, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Individual_Demographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_demographics">Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Individual&gt;"/> class.</returns>
		public abstract TList<Individual> GetByDemographics(TransactionManager transactionManager, string _demographics, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Individual&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Individual&gt;"/></returns>
		public static TList<Individual> Fill(IDataReader reader, TList<Individual> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Individual c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Individual")
					.Append("|").Append((System.Int32)reader[((int)IndividualColumn.CustomerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Individual>(
					key.ToString(), // EntityTrackingKey
					"Individual",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Individual();
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
					c.CustomerId = (System.Int32)reader[((int)IndividualColumn.CustomerId - 1)];
					c.OriginalCustomerId = c.CustomerId;
					c.ContactId = (System.Int32)reader[((int)IndividualColumn.ContactId - 1)];
					c.Demographics = (reader.IsDBNull(((int)IndividualColumn.Demographics - 1)))?null:(string)reader[((int)IndividualColumn.Demographics - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)IndividualColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Individual"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Individual"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Individual entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomerId = (System.Int32)reader[((int)IndividualColumn.CustomerId - 1)];
			entity.OriginalCustomerId = (System.Int32)reader["CustomerID"];
			entity.ContactId = (System.Int32)reader[((int)IndividualColumn.ContactId - 1)];
			entity.Demographics = (reader.IsDBNull(((int)IndividualColumn.Demographics - 1)))?null:(string)reader[((int)IndividualColumn.Demographics - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)IndividualColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Individual"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Individual"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Individual entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.OriginalCustomerId = (System.Int32)dataRow["CustomerID"];
			entity.ContactId = (System.Int32)dataRow["ContactID"];
			entity.Demographics = Convert.IsDBNull(dataRow["Demographics"]) ? null : (string)dataRow["Demographics"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Individual"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Individual Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Individual entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ContactIdSource	
			if (CanDeepLoad(entity, "Contact|ContactIdSource", deepLoadType, innerList) 
				&& entity.ContactIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ContactId;
				Contact tmpEntity = EntityManager.LocateEntity<Contact>(EntityLocator.ConstructKeyFromPkItems(typeof(Contact), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ContactIdSource = tmpEntity;
				else
					entity.ContactIdSource = DataRepository.ContactProvider.GetByContactId(transactionManager, entity.ContactId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ContactIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ContactIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ContactProvider.DeepLoad(transactionManager, entity.ContactIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ContactIdSource

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "Customer|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomerId;
				Customer tmpEntity = EntityManager.LocateEntity<Customer>(EntityLocator.ConstructKeyFromPkItems(typeof(Customer), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomerProvider.GetByCustomerId(transactionManager, entity.CustomerId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomerProvider.DeepLoad(transactionManager, entity.CustomerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Individual object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Individual instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Individual Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Individual entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ContactIdSource
			if (CanDeepSave(entity, "Contact|ContactIdSource", deepSaveType, innerList) 
				&& entity.ContactIdSource != null)
			{
				DataRepository.ContactProvider.Save(transactionManager, entity.ContactIdSource);
				entity.ContactId = entity.ContactIdSource.ContactId;
			}
			#endregion 
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customer|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.CustomerId;
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
	
	#region IndividualChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Individual</c>
	///</summary>
	public enum IndividualChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Contact</c> at ContactIdSource
		///</summary>
		[ChildEntityType(typeof(Contact))]
		Contact,
			
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
		}
	
	#endregion IndividualChildEntityTypes
	
	#region IndividualFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;IndividualColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Individual"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndividualFilterBuilder : SqlFilterBuilder<IndividualColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndividualFilterBuilder class.
		/// </summary>
		public IndividualFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IndividualFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IndividualFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IndividualFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IndividualFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IndividualFilterBuilder
	
	#region IndividualParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;IndividualColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Individual"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndividualParameterBuilder : ParameterizedSqlFilterBuilder<IndividualColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndividualParameterBuilder class.
		/// </summary>
		public IndividualParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IndividualParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IndividualParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IndividualParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IndividualParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IndividualParameterBuilder
	
	#region IndividualSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;IndividualColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Individual"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class IndividualSortBuilder : SqlSortBuilder<IndividualColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndividualSqlSortBuilder class.
		/// </summary>
		public IndividualSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion IndividualSortBuilder
	
} // end namespace
