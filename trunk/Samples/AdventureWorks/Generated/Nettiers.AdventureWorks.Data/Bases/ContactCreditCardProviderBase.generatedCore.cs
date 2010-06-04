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
	/// This class is the base class for any <see cref="ContactCreditCardProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ContactCreditCardProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.ContactCreditCard, Nettiers.AdventureWorks.Entities.ContactCreditCardKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactCreditCardKey key)
		{
			return Delete(transactionManager, key.ContactId, key.CreditCardId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.. Primary Key.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _contactId, System.Int32 _creditCardId)
		{
			return Delete(null, _contactId, _creditCardId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.. Primary Key.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _contactId, System.Int32 _creditCardId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_Contact_ContactID key.
		///		FK_ContactCreditCard_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public TList<ContactCreditCard> GetByContactId(System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(_contactId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_Contact_ContactID key.
		///		FK_ContactCreditCard_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		/// <remarks></remarks>
		public TList<ContactCreditCard> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_Contact_ContactID key.
		///		FK_ContactCreditCard_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public TList<ContactCreditCard> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_Contact_ContactID key.
		///		fkContactCreditCardContactContactId Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public TList<ContactCreditCard> GetByContactId(System.Int32 _contactId, int start, int pageLength)
		{
			int count =  -1;
			return GetByContactId(null, _contactId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_Contact_ContactID key.
		///		fkContactCreditCardContactContactId Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public TList<ContactCreditCard> GetByContactId(System.Int32 _contactId, int start, int pageLength,out int count)
		{
			return GetByContactId(null, _contactId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_Contact_ContactID key.
		///		FK_ContactCreditCard_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public abstract TList<ContactCreditCard> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_CreditCard_CreditCardID key.
		///		FK_ContactCreditCard_CreditCard_CreditCardID Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public TList<ContactCreditCard> GetByCreditCardId(System.Int32 _creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(_creditCardId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_CreditCard_CreditCardID key.
		///		FK_ContactCreditCard_CreditCard_CreditCardID Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		/// <remarks></remarks>
		public TList<ContactCreditCard> GetByCreditCardId(TransactionManager transactionManager, System.Int32 _creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, _creditCardId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_CreditCard_CreditCardID key.
		///		FK_ContactCreditCard_CreditCard_CreditCardID Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public TList<ContactCreditCard> GetByCreditCardId(TransactionManager transactionManager, System.Int32 _creditCardId, int start, int pageLength)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, _creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_CreditCard_CreditCardID key.
		///		fkContactCreditCardCreditCardCreditCardId Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public TList<ContactCreditCard> GetByCreditCardId(System.Int32 _creditCardId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCreditCardId(null, _creditCardId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_CreditCard_CreditCardID key.
		///		fkContactCreditCardCreditCardCreditCardId Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public TList<ContactCreditCard> GetByCreditCardId(System.Int32 _creditCardId, int start, int pageLength,out int count)
		{
			return GetByCreditCardId(null, _creditCardId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ContactCreditCard_CreditCard_CreditCardID key.
		///		FK_ContactCreditCard_CreditCard_CreditCardID Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ContactCreditCard objects.</returns>
		public abstract TList<ContactCreditCard> GetByCreditCardId(TransactionManager transactionManager, System.Int32 _creditCardId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.ContactCreditCard Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactCreditCardKey key, int start, int pageLength)
		{
			return GetByContactIdCreditCardId(transactionManager, key.ContactId, key.CreditCardId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ContactCreditCard_ContactID_CreditCardID index.
		/// </summary>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactCreditCard GetByContactIdCreditCardId(System.Int32 _contactId, System.Int32 _creditCardId)
		{
			int count = -1;
			return GetByContactIdCreditCardId(null,_contactId, _creditCardId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactCreditCard_ContactID_CreditCardID index.
		/// </summary>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactCreditCard GetByContactIdCreditCardId(System.Int32 _contactId, System.Int32 _creditCardId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactIdCreditCardId(null, _contactId, _creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactCreditCard_ContactID_CreditCardID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactCreditCard GetByContactIdCreditCardId(TransactionManager transactionManager, System.Int32 _contactId, System.Int32 _creditCardId)
		{
			int count = -1;
			return GetByContactIdCreditCardId(transactionManager, _contactId, _creditCardId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactCreditCard_ContactID_CreditCardID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactCreditCard GetByContactIdCreditCardId(TransactionManager transactionManager, System.Int32 _contactId, System.Int32 _creditCardId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactIdCreditCardId(transactionManager, _contactId, _creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactCreditCard_ContactID_CreditCardID index.
		/// </summary>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.ContactCreditCard GetByContactIdCreditCardId(System.Int32 _contactId, System.Int32 _creditCardId, int start, int pageLength, out int count)
		{
			return GetByContactIdCreditCardId(null, _contactId, _creditCardId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ContactCreditCard_ContactID_CreditCardID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.ContactCreditCard GetByContactIdCreditCardId(TransactionManager transactionManager, System.Int32 _contactId, System.Int32 _creditCardId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ContactCreditCard&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ContactCreditCard&gt;"/></returns>
		public static TList<ContactCreditCard> Fill(IDataReader reader, TList<ContactCreditCard> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.ContactCreditCard c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ContactCreditCard")
					.Append("|").Append((System.Int32)reader[((int)ContactCreditCardColumn.ContactId - 1)])
					.Append("|").Append((System.Int32)reader[((int)ContactCreditCardColumn.CreditCardId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ContactCreditCard>(
					key.ToString(), // EntityTrackingKey
					"ContactCreditCard",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.ContactCreditCard();
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
					c.ContactId = (System.Int32)reader[((int)ContactCreditCardColumn.ContactId - 1)];
					c.OriginalContactId = c.ContactId;
					c.CreditCardId = (System.Int32)reader[((int)ContactCreditCardColumn.CreditCardId - 1)];
					c.OriginalCreditCardId = c.CreditCardId;
					c.ModifiedDate = (System.DateTime)reader[((int)ContactCreditCardColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.ContactCreditCard entity)
		{
			if (!reader.Read()) return;
			
			entity.ContactId = (System.Int32)reader[((int)ContactCreditCardColumn.ContactId - 1)];
			entity.OriginalContactId = (System.Int32)reader["ContactID"];
			entity.CreditCardId = (System.Int32)reader[((int)ContactCreditCardColumn.CreditCardId - 1)];
			entity.OriginalCreditCardId = (System.Int32)reader["CreditCardID"];
			entity.ModifiedDate = (System.DateTime)reader[((int)ContactCreditCardColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.ContactCreditCard entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ContactId = (System.Int32)dataRow["ContactID"];
			entity.OriginalContactId = (System.Int32)dataRow["ContactID"];
			entity.CreditCardId = (System.Int32)dataRow["CreditCardID"];
			entity.OriginalCreditCardId = (System.Int32)dataRow["CreditCardID"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.ContactCreditCard"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ContactCreditCard Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactCreditCard entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region CreditCardIdSource	
			if (CanDeepLoad(entity, "CreditCard|CreditCardIdSource", deepLoadType, innerList) 
				&& entity.CreditCardIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CreditCardId;
				CreditCard tmpEntity = EntityManager.LocateEntity<CreditCard>(EntityLocator.ConstructKeyFromPkItems(typeof(CreditCard), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CreditCardIdSource = tmpEntity;
				else
					entity.CreditCardIdSource = DataRepository.CreditCardProvider.GetByCreditCardId(transactionManager, entity.CreditCardId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CreditCardIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CreditCardIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CreditCardProvider.DeepLoad(transactionManager, entity.CreditCardIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CreditCardIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.ContactCreditCard object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ContactCreditCard instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.ContactCreditCard Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactCreditCard entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region CreditCardIdSource
			if (CanDeepSave(entity, "CreditCard|CreditCardIdSource", deepSaveType, innerList) 
				&& entity.CreditCardIdSource != null)
			{
				DataRepository.CreditCardProvider.Save(transactionManager, entity.CreditCardIdSource);
				entity.CreditCardId = entity.CreditCardIdSource.CreditCardId;
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
	
	#region ContactCreditCardChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.ContactCreditCard</c>
	///</summary>
	public enum ContactCreditCardChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Contact</c> at ContactIdSource
		///</summary>
		[ChildEntityType(typeof(Contact))]
		Contact,
			
		///<summary>
		/// Composite Property for <c>CreditCard</c> at CreditCardIdSource
		///</summary>
		[ChildEntityType(typeof(CreditCard))]
		CreditCard,
		}
	
	#endregion ContactCreditCardChildEntityTypes
	
	#region ContactCreditCardFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ContactCreditCardColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactCreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactCreditCardFilterBuilder : SqlFilterBuilder<ContactCreditCardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardFilterBuilder class.
		/// </summary>
		public ContactCreditCardFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactCreditCardFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactCreditCardFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactCreditCardFilterBuilder
	
	#region ContactCreditCardParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ContactCreditCardColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactCreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactCreditCardParameterBuilder : ParameterizedSqlFilterBuilder<ContactCreditCardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardParameterBuilder class.
		/// </summary>
		public ContactCreditCardParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactCreditCardParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactCreditCardParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactCreditCardParameterBuilder
	
	#region ContactCreditCardSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ContactCreditCardColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactCreditCard"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ContactCreditCardSortBuilder : SqlSortBuilder<ContactCreditCardColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactCreditCardSqlSortBuilder class.
		/// </summary>
		public ContactCreditCardSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ContactCreditCardSortBuilder
	
} // end namespace
