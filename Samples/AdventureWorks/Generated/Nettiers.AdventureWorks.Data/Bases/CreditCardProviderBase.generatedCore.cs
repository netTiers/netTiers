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
	/// This class is the base class for any <see cref="CreditCardProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CreditCardProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.CreditCard, Nettiers.AdventureWorks.Entities.CreditCardKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByContactIdFromContactCreditCard
		
		/// <summary>
		///		Gets CreditCard objects from the datasource by ContactID in the
		///		ContactCreditCard table. Table CreditCard is related to table Contact
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of CreditCard objects.</returns>
		public TList<CreditCard> GetByContactIdFromContactCreditCard(System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactIdFromContactCreditCard(null,_contactId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.CreditCard objects from the datasource by ContactID in the
		///		ContactCreditCard table. Table CreditCard is related to table Contact
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of CreditCard objects.</returns>
		public TList<CreditCard> GetByContactIdFromContactCreditCard(System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactIdFromContactCreditCard(null, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets CreditCard objects from the datasource by ContactID in the
		///		ContactCreditCard table. Table CreditCard is related to table Contact
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CreditCard objects.</returns>
		public TList<CreditCard> GetByContactIdFromContactCreditCard(TransactionManager transactionManager, System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactIdFromContactCreditCard(transactionManager, _contactId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets CreditCard objects from the datasource by ContactID in the
		///		ContactCreditCard table. Table CreditCard is related to table Contact
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CreditCard objects.</returns>
		public TList<CreditCard> GetByContactIdFromContactCreditCard(TransactionManager transactionManager, System.Int32 _contactId,int start, int pageLength)
		{
			int count = -1;
			return GetByContactIdFromContactCreditCard(transactionManager, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets CreditCard objects from the datasource by ContactID in the
		///		ContactCreditCard table. Table CreditCard is related to table Contact
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CreditCard objects.</returns>
		public TList<CreditCard> GetByContactIdFromContactCreditCard(System.Int32 _contactId,int start, int pageLength, out int count)
		{
			
			return GetByContactIdFromContactCreditCard(null, _contactId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets CreditCard objects from the datasource by ContactID in the
		///		ContactCreditCard table. Table CreditCard is related to table Contact
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_contactId">Customer identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of CreditCard objects.</returns>
		public abstract TList<CreditCard> GetByContactIdFromContactCreditCard(TransactionManager transactionManager,System.Int32 _contactId, int start, int pageLength, out int count);
		
		#endregion GetByContactIdFromContactCreditCard
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CreditCardKey key)
		{
			return Delete(transactionManager, key.CreditCardId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_creditCardId">Primary key for CreditCard records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _creditCardId)
		{
			return Delete(null, _creditCardId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Primary key for CreditCard records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _creditCardId);		
		
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
		public override Nettiers.AdventureWorks.Entities.CreditCard Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CreditCardKey key, int start, int pageLength)
		{
			return GetByCreditCardId(transactionManager, key.CreditCardId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_CreditCard_CardNumber index.
		/// </summary>
		/// <param name="_cardNumber">Credit card number.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCardNumber(System.String _cardNumber)
		{
			int count = -1;
			return GetByCardNumber(null,_cardNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CreditCard_CardNumber index.
		/// </summary>
		/// <param name="_cardNumber">Credit card number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCardNumber(System.String _cardNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByCardNumber(null, _cardNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CreditCard_CardNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cardNumber">Credit card number.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCardNumber(TransactionManager transactionManager, System.String _cardNumber)
		{
			int count = -1;
			return GetByCardNumber(transactionManager, _cardNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CreditCard_CardNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cardNumber">Credit card number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCardNumber(TransactionManager transactionManager, System.String _cardNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByCardNumber(transactionManager, _cardNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CreditCard_CardNumber index.
		/// </summary>
		/// <param name="_cardNumber">Credit card number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCardNumber(System.String _cardNumber, int start, int pageLength, out int count)
		{
			return GetByCardNumber(null, _cardNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_CreditCard_CardNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cardNumber">Credit card number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.CreditCard GetByCardNumber(TransactionManager transactionManager, System.String _cardNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CreditCard_CreditCardID index.
		/// </summary>
		/// <param name="_creditCardId">Primary key for CreditCard records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCreditCardId(System.Int32 _creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(null,_creditCardId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard_CreditCardID index.
		/// </summary>
		/// <param name="_creditCardId">Primary key for CreditCard records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCreditCardId(System.Int32 _creditCardId, int start, int pageLength)
		{
			int count = -1;
			return GetByCreditCardId(null, _creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard_CreditCardID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Primary key for CreditCard records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCreditCardId(TransactionManager transactionManager, System.Int32 _creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, _creditCardId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard_CreditCardID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Primary key for CreditCard records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCreditCardId(TransactionManager transactionManager, System.Int32 _creditCardId, int start, int pageLength)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, _creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard_CreditCardID index.
		/// </summary>
		/// <param name="_creditCardId">Primary key for CreditCard records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.CreditCard GetByCreditCardId(System.Int32 _creditCardId, int start, int pageLength, out int count)
		{
			return GetByCreditCardId(null, _creditCardId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard_CreditCardID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Primary key for CreditCard records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.CreditCard GetByCreditCardId(TransactionManager transactionManager, System.Int32 _creditCardId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CreditCard&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CreditCard&gt;"/></returns>
		public static TList<CreditCard> Fill(IDataReader reader, TList<CreditCard> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.CreditCard c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CreditCard")
					.Append("|").Append((System.Int32)reader[((int)CreditCardColumn.CreditCardId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CreditCard>(
					key.ToString(), // EntityTrackingKey
					"CreditCard",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.CreditCard();
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
					c.CreditCardId = (System.Int32)reader[((int)CreditCardColumn.CreditCardId - 1)];
					c.CardType = (System.String)reader[((int)CreditCardColumn.CardType - 1)];
					c.CardNumber = (System.String)reader[((int)CreditCardColumn.CardNumber - 1)];
					c.ExpMonth = (System.Byte)reader[((int)CreditCardColumn.ExpMonth - 1)];
					c.ExpYear = (System.Int16)reader[((int)CreditCardColumn.ExpYear - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)CreditCardColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.CreditCard entity)
		{
			if (!reader.Read()) return;
			
			entity.CreditCardId = (System.Int32)reader[((int)CreditCardColumn.CreditCardId - 1)];
			entity.CardType = (System.String)reader[((int)CreditCardColumn.CardType - 1)];
			entity.CardNumber = (System.String)reader[((int)CreditCardColumn.CardNumber - 1)];
			entity.ExpMonth = (System.Byte)reader[((int)CreditCardColumn.ExpMonth - 1)];
			entity.ExpYear = (System.Int16)reader[((int)CreditCardColumn.ExpYear - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)CreditCardColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.CreditCard entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CreditCardId = (System.Int32)dataRow["CreditCardID"];
			entity.CardType = (System.String)dataRow["CardType"];
			entity.CardNumber = (System.String)dataRow["CardNumber"];
			entity.ExpMonth = (System.Byte)dataRow["ExpMonth"];
			entity.ExpYear = (System.Int16)dataRow["ExpYear"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.CreditCard"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CreditCard Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CreditCard entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCreditCardId methods when available
			
			#region ContactCreditCardCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ContactCreditCard>|ContactCreditCardCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ContactCreditCardCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ContactCreditCardCollection = DataRepository.ContactCreditCardProvider.GetByCreditCardId(transactionManager, entity.CreditCardId);

				if (deep && entity.ContactCreditCardCollection.Count > 0)
				{
					deepHandles.Add("ContactCreditCardCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ContactCreditCard>) DataRepository.ContactCreditCardProvider.DeepLoad,
						new object[] { transactionManager, entity.ContactCreditCardCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesOrderHeaderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderHeader>|SalesOrderHeaderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderHeaderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderHeaderCollection = DataRepository.SalesOrderHeaderProvider.GetByCreditCardId(transactionManager, entity.CreditCardId);

				if (deep && entity.SalesOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ContactIdContactCollection_From_ContactCreditCard
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Contact>|ContactIdContactCollection_From_ContactCreditCard", deepLoadType, innerList))
			{
				entity.ContactIdContactCollection_From_ContactCreditCard = DataRepository.ContactProvider.GetByCreditCardIdFromContactCreditCard(transactionManager, entity.CreditCardId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ContactIdContactCollection_From_ContactCreditCard' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ContactIdContactCollection_From_ContactCreditCard != null)
				{
					deepHandles.Add("ContactIdContactCollection_From_ContactCreditCard",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Contact >) DataRepository.ContactProvider.DeepLoad,
						new object[] { transactionManager, entity.ContactIdContactCollection_From_ContactCreditCard, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.CreditCard object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.CreditCard instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.CreditCard Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CreditCard entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region ContactIdContactCollection_From_ContactCreditCard>
			if (CanDeepSave(entity.ContactIdContactCollection_From_ContactCreditCard, "List<Contact>|ContactIdContactCollection_From_ContactCreditCard", deepSaveType, innerList))
			{
				if (entity.ContactIdContactCollection_From_ContactCreditCard.Count > 0 || entity.ContactIdContactCollection_From_ContactCreditCard.DeletedItems.Count > 0)
				{
					DataRepository.ContactProvider.Save(transactionManager, entity.ContactIdContactCollection_From_ContactCreditCard); 
					deepHandles.Add("ContactIdContactCollection_From_ContactCreditCard",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Contact>) DataRepository.ContactProvider.DeepSave,
						new object[] { transactionManager, entity.ContactIdContactCollection_From_ContactCreditCard, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<ContactCreditCard>
				if (CanDeepSave(entity.ContactCreditCardCollection, "List<ContactCreditCard>|ContactCreditCardCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ContactCreditCard child in entity.ContactCreditCardCollection)
					{
						if(child.CreditCardIdSource != null)
						{
								child.CreditCardId = child.CreditCardIdSource.CreditCardId;
						}

						if(child.ContactIdSource != null)
						{
								child.ContactId = child.ContactIdSource.ContactId;
						}

					}

					if (entity.ContactCreditCardCollection.Count > 0 || entity.ContactCreditCardCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ContactCreditCardProvider.Save(transactionManager, entity.ContactCreditCardCollection);
						
						deepHandles.Add("ContactCreditCardCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ContactCreditCard >) DataRepository.ContactCreditCardProvider.DeepSave,
							new object[] { transactionManager, entity.ContactCreditCardCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SalesOrderHeader>
				if (CanDeepSave(entity.SalesOrderHeaderCollection, "List<SalesOrderHeader>|SalesOrderHeaderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderHeader child in entity.SalesOrderHeaderCollection)
					{
						if(child.CreditCardIdSource != null)
						{
							child.CreditCardId = child.CreditCardIdSource.CreditCardId;
						}
						else
						{
							child.CreditCardId = entity.CreditCardId;
						}

					}

					if (entity.SalesOrderHeaderCollection.Count > 0 || entity.SalesOrderHeaderCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesOrderHeaderProvider.Save(transactionManager, entity.SalesOrderHeaderCollection);
						
						deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesOrderHeader >) DataRepository.SalesOrderHeaderProvider.DeepSave,
							new object[] { transactionManager, entity.SalesOrderHeaderCollection, deepSaveType, childTypes, innerList }
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
	
	#region CreditCardChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.CreditCard</c>
	///</summary>
	public enum CreditCardChildEntityTypes
	{

		///<summary>
		/// Collection of <c>CreditCard</c> as OneToMany for ContactCreditCardCollection
		///</summary>
		[ChildEntityType(typeof(TList<ContactCreditCard>))]
		ContactCreditCardCollection,

		///<summary>
		/// Collection of <c>CreditCard</c> as OneToMany for SalesOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderHeaderCollection,

		///<summary>
		/// Collection of <c>CreditCard</c> as ManyToMany for ContactCollection_From_ContactCreditCard
		///</summary>
		[ChildEntityType(typeof(TList<Contact>))]
		ContactIdContactCollection_From_ContactCreditCard,
	}
	
	#endregion CreditCardChildEntityTypes
	
	#region CreditCardFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CreditCardColumn&gt;"/> class
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
	
	#region CreditCardParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CreditCardColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CreditCard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CreditCardParameterBuilder : ParameterizedSqlFilterBuilder<CreditCardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CreditCardParameterBuilder class.
		/// </summary>
		public CreditCardParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CreditCardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CreditCardParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CreditCardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CreditCardParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CreditCardParameterBuilder
	
	#region CreditCardSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CreditCardColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CreditCard"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CreditCardSortBuilder : SqlSortBuilder<CreditCardColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CreditCardSqlSortBuilder class.
		/// </summary>
		public CreditCardSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CreditCardSortBuilder
	
} // end namespace
