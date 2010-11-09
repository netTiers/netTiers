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
	/// This class is the base class for any <see cref="ContactProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ContactProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Contact, Nettiers.AdventureWorks.Entities.ContactKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByCreditCardIdFromContactCreditCard
		
		/// <summary>
		///		Gets Contact objects from the datasource by CreditCardID in the
		///		ContactCreditCard table. Table Contact is related to table CreditCard
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByCreditCardIdFromContactCreditCard(System.Int32 _creditCardId)
		{
			int count = -1;
			return GetByCreditCardIdFromContactCreditCard(null,_creditCardId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Contact objects from the datasource by CreditCardID in the
		///		ContactCreditCard table. Table Contact is related to table CreditCard
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Contact objects.</returns>
		public TList<Contact> GetByCreditCardIdFromContactCreditCard(System.Int32 _creditCardId, int start, int pageLength)
		{
			int count = -1;
			return GetByCreditCardIdFromContactCreditCard(null, _creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Contact objects from the datasource by CreditCardID in the
		///		ContactCreditCard table. Table Contact is related to table CreditCard
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByCreditCardIdFromContactCreditCard(TransactionManager transactionManager, System.Int32 _creditCardId)
		{
			int count = -1;
			return GetByCreditCardIdFromContactCreditCard(transactionManager, _creditCardId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Contact objects from the datasource by CreditCardID in the
		///		ContactCreditCard table. Table Contact is related to table CreditCard
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByCreditCardIdFromContactCreditCard(TransactionManager transactionManager, System.Int32 _creditCardId,int start, int pageLength)
		{
			int count = -1;
			return GetByCreditCardIdFromContactCreditCard(transactionManager, _creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Contact objects from the datasource by CreditCardID in the
		///		ContactCreditCard table. Table Contact is related to table CreditCard
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByCreditCardIdFromContactCreditCard(System.Int32 _creditCardId,int start, int pageLength, out int count)
		{
			
			return GetByCreditCardIdFromContactCreditCard(null, _creditCardId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Contact objects from the datasource by CreditCardID in the
		///		ContactCreditCard table. Table Contact is related to table CreditCard
		///		through the (M:N) relationship defined in the ContactCreditCard table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Contact objects.</returns>
		public abstract TList<Contact> GetByCreditCardIdFromContactCreditCard(TransactionManager transactionManager,System.Int32 _creditCardId, int start, int pageLength, out int count);
		
		#endregion GetByCreditCardIdFromContactCreditCard
		
		#region GetByCustomerIdFromStoreContact
		
		/// <summary>
		///		Gets Contact objects from the datasource by CustomerID in the
		///		StoreContact table. Table Contact is related to table Store
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="_customerId">Store identification number. Foreign key to Customer.CustomerID.</param>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByCustomerIdFromStoreContact(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerIdFromStoreContact(null,_customerId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Contact objects from the datasource by CustomerID in the
		///		StoreContact table. Table Contact is related to table Store
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId">Store identification number. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Contact objects.</returns>
		public TList<Contact> GetByCustomerIdFromStoreContact(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdFromStoreContact(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Contact objects from the datasource by CustomerID in the
		///		StoreContact table. Table Contact is related to table Store
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Store identification number. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByCustomerIdFromStoreContact(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerIdFromStoreContact(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Contact objects from the datasource by CustomerID in the
		///		StoreContact table. Table Contact is related to table Store
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Store identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByCustomerIdFromStoreContact(TransactionManager transactionManager, System.Int32 _customerId,int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdFromStoreContact(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Contact objects from the datasource by CustomerID in the
		///		StoreContact table. Table Contact is related to table Store
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="_customerId">Store identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByCustomerIdFromStoreContact(System.Int32 _customerId,int start, int pageLength, out int count)
		{
			
			return GetByCustomerIdFromStoreContact(null, _customerId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Contact objects from the datasource by CustomerID in the
		///		StoreContact table. Table Contact is related to table Store
		///		through the (M:N) relationship defined in the StoreContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_customerId">Store identification number. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Contact objects.</returns>
		public abstract TList<Contact> GetByCustomerIdFromStoreContact(TransactionManager transactionManager,System.Int32 _customerId, int start, int pageLength, out int count);
		
		#endregion GetByCustomerIdFromStoreContact
		
		#region GetByVendorIdFromVendorContact
		
		/// <summary>
		///		Gets Contact objects from the datasource by VendorID in the
		///		VendorContact table. Table Contact is related to table Vendor
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="_vendorId">Primary key.</param>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByVendorIdFromVendorContact(System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorIdFromVendorContact(null,_vendorId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Contact objects from the datasource by VendorID in the
		///		VendorContact table. Table Contact is related to table Vendor
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Contact objects.</returns>
		public TList<Contact> GetByVendorIdFromVendorContact(System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdFromVendorContact(null, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Contact objects from the datasource by VendorID in the
		///		VendorContact table. Table Contact is related to table Vendor
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByVendorIdFromVendorContact(TransactionManager transactionManager, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorIdFromVendorContact(transactionManager, _vendorId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Contact objects from the datasource by VendorID in the
		///		VendorContact table. Table Contact is related to table Vendor
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByVendorIdFromVendorContact(TransactionManager transactionManager, System.Int32 _vendorId,int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdFromVendorContact(transactionManager, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Contact objects from the datasource by VendorID in the
		///		VendorContact table. Table Contact is related to table Vendor
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="_vendorId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Contact objects.</returns>
		public TList<Contact> GetByVendorIdFromVendorContact(System.Int32 _vendorId,int start, int pageLength, out int count)
		{
			
			return GetByVendorIdFromVendorContact(null, _vendorId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Contact objects from the datasource by VendorID in the
		///		VendorContact table. Table Contact is related to table Vendor
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_vendorId">Primary key.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Contact objects.</returns>
		public abstract TList<Contact> GetByVendorIdFromVendorContact(TransactionManager transactionManager,System.Int32 _vendorId, int start, int pageLength, out int count);
		
		#endregion GetByVendorIdFromVendorContact
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactKey key)
		{
			return Delete(transactionManager, key.ContactId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_contactId">Primary key for Contact records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _contactId)
		{
			return Delete(null, _contactId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Primary key for Contact records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _contactId);		
		
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
		public override Nettiers.AdventureWorks.Entities.Contact Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ContactKey key, int start, int pageLength)
		{
			return GetByContactId(transactionManager, key.ContactId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Contact_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Contact_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Contact_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Contact_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Contact_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Contact_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Contact GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Contact_EmailAddress index.
		/// </summary>
		/// <param name="_emailAddress">E-mail address for the person.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByEmailAddress(System.String _emailAddress)
		{
			int count = -1;
			return GetByEmailAddress(null,_emailAddress, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Contact_EmailAddress index.
		/// </summary>
		/// <param name="_emailAddress">E-mail address for the person.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByEmailAddress(System.String _emailAddress, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailAddress(null, _emailAddress, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Contact_EmailAddress index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailAddress">E-mail address for the person.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByEmailAddress(TransactionManager transactionManager, System.String _emailAddress)
		{
			int count = -1;
			return GetByEmailAddress(transactionManager, _emailAddress, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Contact_EmailAddress index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailAddress">E-mail address for the person.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByEmailAddress(TransactionManager transactionManager, System.String _emailAddress, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailAddress(transactionManager, _emailAddress, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Contact_EmailAddress index.
		/// </summary>
		/// <param name="_emailAddress">E-mail address for the person.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByEmailAddress(System.String _emailAddress, int start, int pageLength, out int count)
		{
			return GetByEmailAddress(null, _emailAddress, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Contact_EmailAddress index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailAddress">E-mail address for the person.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public abstract TList<Contact> GetByEmailAddress(TransactionManager transactionManager, System.String _emailAddress, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Contact_ContactID index.
		/// </summary>
		/// <param name="_contactId">Primary key for Contact records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByContactId(System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(null,_contactId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contact_ContactID index.
		/// </summary>
		/// <param name="_contactId">Primary key for Contact records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByContactId(System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactId(null, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contact_ContactID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Primary key for Contact records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByContactId(TransactionManager transactionManager, System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contact_ContactID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Primary key for Contact records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contact_ContactID index.
		/// </summary>
		/// <param name="_contactId">Primary key for Contact records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Contact GetByContactId(System.Int32 _contactId, int start, int pageLength, out int count)
		{
			return GetByContactId(null, _contactId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contact_ContactID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Primary key for Contact records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Contact GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PXML_Contact_AddContact index.
		/// </summary>
		/// <param name="_additionalContactInfo">Additional contact information about the person stored in xml format. </param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByAdditionalContactInfo(string _additionalContactInfo)
		{
			int count = -1;
			return GetByAdditionalContactInfo(null,_additionalContactInfo, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Contact_AddContact index.
		/// </summary>
		/// <param name="_additionalContactInfo">Additional contact information about the person stored in xml format. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByAdditionalContactInfo(string _additionalContactInfo, int start, int pageLength)
		{
			int count = -1;
			return GetByAdditionalContactInfo(null, _additionalContactInfo, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Contact_AddContact index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_additionalContactInfo">Additional contact information about the person stored in xml format. </param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByAdditionalContactInfo(TransactionManager transactionManager, string _additionalContactInfo)
		{
			int count = -1;
			return GetByAdditionalContactInfo(transactionManager, _additionalContactInfo, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Contact_AddContact index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_additionalContactInfo">Additional contact information about the person stored in xml format. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByAdditionalContactInfo(TransactionManager transactionManager, string _additionalContactInfo, int start, int pageLength)
		{
			int count = -1;
			return GetByAdditionalContactInfo(transactionManager, _additionalContactInfo, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Contact_AddContact index.
		/// </summary>
		/// <param name="_additionalContactInfo">Additional contact information about the person stored in xml format. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public TList<Contact> GetByAdditionalContactInfo(string _additionalContactInfo, int start, int pageLength, out int count)
		{
			return GetByAdditionalContactInfo(null, _additionalContactInfo, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PXML_Contact_AddContact index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_additionalContactInfo">Additional contact information about the person stored in xml format. </param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Contact&gt;"/> class.</returns>
		public abstract TList<Contact> GetByAdditionalContactInfo(TransactionManager transactionManager, string _additionalContactInfo, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Contact&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Contact&gt;"/></returns>
		public static TList<Contact> Fill(IDataReader reader, TList<Contact> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Contact c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Contact")
					.Append("|").Append((System.Int32)reader[((int)ContactColumn.ContactId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Contact>(
					key.ToString(), // EntityTrackingKey
					"Contact",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Contact();
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
					c.ContactId = (System.Int32)reader[((int)ContactColumn.ContactId - 1)];
					c.NameStyle = (System.Boolean)reader[((int)ContactColumn.NameStyle - 1)];
					c.Title = (reader.IsDBNull(((int)ContactColumn.Title - 1)))?null:(System.String)reader[((int)ContactColumn.Title - 1)];
					c.FirstName = (System.String)reader[((int)ContactColumn.FirstName - 1)];
					c.MiddleName = (reader.IsDBNull(((int)ContactColumn.MiddleName - 1)))?null:(System.String)reader[((int)ContactColumn.MiddleName - 1)];
					c.LastName = (System.String)reader[((int)ContactColumn.LastName - 1)];
					c.Suffix = (reader.IsDBNull(((int)ContactColumn.Suffix - 1)))?null:(System.String)reader[((int)ContactColumn.Suffix - 1)];
					c.EmailAddress = (reader.IsDBNull(((int)ContactColumn.EmailAddress - 1)))?null:(System.String)reader[((int)ContactColumn.EmailAddress - 1)];
					c.EmailPromotion = (System.Int32)reader[((int)ContactColumn.EmailPromotion - 1)];
					c.Phone = (reader.IsDBNull(((int)ContactColumn.Phone - 1)))?null:(System.String)reader[((int)ContactColumn.Phone - 1)];
					c.PasswordHash = (System.String)reader[((int)ContactColumn.PasswordHash - 1)];
					c.PasswordSalt = (System.String)reader[((int)ContactColumn.PasswordSalt - 1)];
					c.AdditionalContactInfo = (reader.IsDBNull(((int)ContactColumn.AdditionalContactInfo - 1)))?null:(string)reader[((int)ContactColumn.AdditionalContactInfo - 1)];
					c.Rowguid = (System.Guid)reader[((int)ContactColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)ContactColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Contact"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Contact entity)
		{
			if (!reader.Read()) return;
			
			entity.ContactId = (System.Int32)reader[((int)ContactColumn.ContactId - 1)];
			entity.NameStyle = (System.Boolean)reader[((int)ContactColumn.NameStyle - 1)];
			entity.Title = (reader.IsDBNull(((int)ContactColumn.Title - 1)))?null:(System.String)reader[((int)ContactColumn.Title - 1)];
			entity.FirstName = (System.String)reader[((int)ContactColumn.FirstName - 1)];
			entity.MiddleName = (reader.IsDBNull(((int)ContactColumn.MiddleName - 1)))?null:(System.String)reader[((int)ContactColumn.MiddleName - 1)];
			entity.LastName = (System.String)reader[((int)ContactColumn.LastName - 1)];
			entity.Suffix = (reader.IsDBNull(((int)ContactColumn.Suffix - 1)))?null:(System.String)reader[((int)ContactColumn.Suffix - 1)];
			entity.EmailAddress = (reader.IsDBNull(((int)ContactColumn.EmailAddress - 1)))?null:(System.String)reader[((int)ContactColumn.EmailAddress - 1)];
			entity.EmailPromotion = (System.Int32)reader[((int)ContactColumn.EmailPromotion - 1)];
			entity.Phone = (reader.IsDBNull(((int)ContactColumn.Phone - 1)))?null:(System.String)reader[((int)ContactColumn.Phone - 1)];
			entity.PasswordHash = (System.String)reader[((int)ContactColumn.PasswordHash - 1)];
			entity.PasswordSalt = (System.String)reader[((int)ContactColumn.PasswordSalt - 1)];
			entity.AdditionalContactInfo = (reader.IsDBNull(((int)ContactColumn.AdditionalContactInfo - 1)))?null:(string)reader[((int)ContactColumn.AdditionalContactInfo - 1)];
			entity.Rowguid = (System.Guid)reader[((int)ContactColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)ContactColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Contact"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Contact"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Contact entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ContactId = (System.Int32)dataRow["ContactID"];
			entity.NameStyle = (System.Boolean)dataRow["NameStyle"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.FirstName = (System.String)dataRow["FirstName"];
			entity.MiddleName = Convert.IsDBNull(dataRow["MiddleName"]) ? null : (System.String)dataRow["MiddleName"];
			entity.LastName = (System.String)dataRow["LastName"];
			entity.Suffix = Convert.IsDBNull(dataRow["Suffix"]) ? null : (System.String)dataRow["Suffix"];
			entity.EmailAddress = Convert.IsDBNull(dataRow["EmailAddress"]) ? null : (System.String)dataRow["EmailAddress"];
			entity.EmailPromotion = (System.Int32)dataRow["EmailPromotion"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.PasswordHash = (System.String)dataRow["PasswordHash"];
			entity.PasswordSalt = (System.String)dataRow["PasswordSalt"];
			entity.AdditionalContactInfo = Convert.IsDBNull(dataRow["AdditionalContactInfo"]) ? null : (string)dataRow["AdditionalContactInfo"];
			entity.Rowguid = (System.Guid)dataRow["rowguid"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Contact"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Contact Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Contact entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByContactId methods when available
			
			#region EmployeeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Employee>|EmployeeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeCollection = DataRepository.EmployeeProvider.GetByContactId(transactionManager, entity.ContactId);

				if (deep && entity.EmployeeCollection.Count > 0)
				{
					deepHandles.Add("EmployeeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Employee>) DataRepository.EmployeeProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.SalesOrderHeaderCollection = DataRepository.SalesOrderHeaderProvider.GetByContactId(transactionManager, entity.ContactId);

				if (deep && entity.SalesOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region IndividualCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Individual>|IndividualCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IndividualCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.IndividualCollection = DataRepository.IndividualProvider.GetByContactId(transactionManager, entity.ContactId);

				if (deep && entity.IndividualCollection.Count > 0)
				{
					deepHandles.Add("IndividualCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Individual>) DataRepository.IndividualProvider.DeepLoad,
						new object[] { transactionManager, entity.IndividualCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region StoreContactCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<StoreContact>|StoreContactCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StoreContactCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.StoreContactCollection = DataRepository.StoreContactProvider.GetByContactId(transactionManager, entity.ContactId);

				if (deep && entity.StoreContactCollection.Count > 0)
				{
					deepHandles.Add("StoreContactCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<StoreContact>) DataRepository.StoreContactProvider.DeepLoad,
						new object[] { transactionManager, entity.StoreContactCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ContactCreditCardCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ContactCreditCard>|ContactCreditCardCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ContactCreditCardCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ContactCreditCardCollection = DataRepository.ContactCreditCardProvider.GetByContactId(transactionManager, entity.ContactId);

				if (deep && entity.ContactCreditCardCollection.Count > 0)
				{
					deepHandles.Add("ContactCreditCardCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ContactCreditCard>) DataRepository.ContactCreditCardProvider.DeepLoad,
						new object[] { transactionManager, entity.ContactCreditCardCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region VendorContactCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<VendorContact>|VendorContactCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorContactCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.VendorContactCollection = DataRepository.VendorContactProvider.GetByContactId(transactionManager, entity.ContactId);

				if (deep && entity.VendorContactCollection.Count > 0)
				{
					deepHandles.Add("VendorContactCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<VendorContact>) DataRepository.VendorContactProvider.DeepLoad,
						new object[] { transactionManager, entity.VendorContactCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CreditCardIdCreditCardCollection_From_ContactCreditCard
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<CreditCard>|CreditCardIdCreditCardCollection_From_ContactCreditCard", deepLoadType, innerList))
			{
				entity.CreditCardIdCreditCardCollection_From_ContactCreditCard = DataRepository.CreditCardProvider.GetByContactIdFromContactCreditCard(transactionManager, entity.ContactId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CreditCardIdCreditCardCollection_From_ContactCreditCard' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CreditCardIdCreditCardCollection_From_ContactCreditCard != null)
				{
					deepHandles.Add("CreditCardIdCreditCardCollection_From_ContactCreditCard",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< CreditCard >) DataRepository.CreditCardProvider.DeepLoad,
						new object[] { transactionManager, entity.CreditCardIdCreditCardCollection_From_ContactCreditCard, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region CustomerIdStoreCollection_From_StoreContact
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Store>|CustomerIdStoreCollection_From_StoreContact", deepLoadType, innerList))
			{
				entity.CustomerIdStoreCollection_From_StoreContact = DataRepository.StoreProvider.GetByContactIdFromStoreContact(transactionManager, entity.ContactId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdStoreCollection_From_StoreContact' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdStoreCollection_From_StoreContact != null)
				{
					deepHandles.Add("CustomerIdStoreCollection_From_StoreContact",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Store >) DataRepository.StoreProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerIdStoreCollection_From_StoreContact, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region VendorIdVendorCollection_From_VendorContact
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Vendor>|VendorIdVendorCollection_From_VendorContact", deepLoadType, innerList))
			{
				entity.VendorIdVendorCollection_From_VendorContact = DataRepository.VendorProvider.GetByContactIdFromVendorContact(transactionManager, entity.ContactId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorIdVendorCollection_From_VendorContact' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.VendorIdVendorCollection_From_VendorContact != null)
				{
					deepHandles.Add("VendorIdVendorCollection_From_VendorContact",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Vendor >) DataRepository.VendorProvider.DeepLoad,
						new object[] { transactionManager, entity.VendorIdVendorCollection_From_VendorContact, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Contact object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Contact instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Contact Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Contact entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region CreditCardIdCreditCardCollection_From_ContactCreditCard>
			if (CanDeepSave(entity.CreditCardIdCreditCardCollection_From_ContactCreditCard, "List<CreditCard>|CreditCardIdCreditCardCollection_From_ContactCreditCard", deepSaveType, innerList))
			{
				if (entity.CreditCardIdCreditCardCollection_From_ContactCreditCard.Count > 0 || entity.CreditCardIdCreditCardCollection_From_ContactCreditCard.DeletedItems.Count > 0)
				{
					DataRepository.CreditCardProvider.Save(transactionManager, entity.CreditCardIdCreditCardCollection_From_ContactCreditCard); 
					deepHandles.Add("CreditCardIdCreditCardCollection_From_ContactCreditCard",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<CreditCard>) DataRepository.CreditCardProvider.DeepSave,
						new object[] { transactionManager, entity.CreditCardIdCreditCardCollection_From_ContactCreditCard, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region CustomerIdStoreCollection_From_StoreContact>
			if (CanDeepSave(entity.CustomerIdStoreCollection_From_StoreContact, "List<Store>|CustomerIdStoreCollection_From_StoreContact", deepSaveType, innerList))
			{
				if (entity.CustomerIdStoreCollection_From_StoreContact.Count > 0 || entity.CustomerIdStoreCollection_From_StoreContact.DeletedItems.Count > 0)
				{
					DataRepository.StoreProvider.Save(transactionManager, entity.CustomerIdStoreCollection_From_StoreContact); 
					deepHandles.Add("CustomerIdStoreCollection_From_StoreContact",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Store>) DataRepository.StoreProvider.DeepSave,
						new object[] { transactionManager, entity.CustomerIdStoreCollection_From_StoreContact, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region VendorIdVendorCollection_From_VendorContact>
			if (CanDeepSave(entity.VendorIdVendorCollection_From_VendorContact, "List<Vendor>|VendorIdVendorCollection_From_VendorContact", deepSaveType, innerList))
			{
				if (entity.VendorIdVendorCollection_From_VendorContact.Count > 0 || entity.VendorIdVendorCollection_From_VendorContact.DeletedItems.Count > 0)
				{
					DataRepository.VendorProvider.Save(transactionManager, entity.VendorIdVendorCollection_From_VendorContact); 
					deepHandles.Add("VendorIdVendorCollection_From_VendorContact",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Vendor>) DataRepository.VendorProvider.DeepSave,
						new object[] { transactionManager, entity.VendorIdVendorCollection_From_VendorContact, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<Employee>
				if (CanDeepSave(entity.EmployeeCollection, "List<Employee>|EmployeeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Employee child in entity.EmployeeCollection)
					{
						if(child.ContactIdSource != null)
						{
							child.ContactId = child.ContactIdSource.ContactId;
						}
						else
						{
							child.ContactId = entity.ContactId;
						}

					}

					if (entity.EmployeeCollection.Count > 0 || entity.EmployeeCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeeProvider.Save(transactionManager, entity.EmployeeCollection);
						
						deepHandles.Add("EmployeeCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Employee >) DataRepository.EmployeeProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeeCollection, deepSaveType, childTypes, innerList }
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
						if(child.ContactIdSource != null)
						{
							child.ContactId = child.ContactIdSource.ContactId;
						}
						else
						{
							child.ContactId = entity.ContactId;
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
				
	
			#region List<Individual>
				if (CanDeepSave(entity.IndividualCollection, "List<Individual>|IndividualCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Individual child in entity.IndividualCollection)
					{
						if(child.ContactIdSource != null)
						{
							child.ContactId = child.ContactIdSource.ContactId;
						}
						else
						{
							child.ContactId = entity.ContactId;
						}

					}

					if (entity.IndividualCollection.Count > 0 || entity.IndividualCollection.DeletedItems.Count > 0)
					{
						//DataRepository.IndividualProvider.Save(transactionManager, entity.IndividualCollection);
						
						deepHandles.Add("IndividualCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Individual >) DataRepository.IndividualProvider.DeepSave,
							new object[] { transactionManager, entity.IndividualCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<StoreContact>
				if (CanDeepSave(entity.StoreContactCollection, "List<StoreContact>|StoreContactCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(StoreContact child in entity.StoreContactCollection)
					{
						if(child.ContactIdSource != null)
						{
								child.ContactId = child.ContactIdSource.ContactId;
						}

						if(child.CustomerIdSource != null)
						{
								child.CustomerId = child.CustomerIdSource.CustomerId;
						}

					}

					if (entity.StoreContactCollection.Count > 0 || entity.StoreContactCollection.DeletedItems.Count > 0)
					{
						//DataRepository.StoreContactProvider.Save(transactionManager, entity.StoreContactCollection);
						
						deepHandles.Add("StoreContactCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< StoreContact >) DataRepository.StoreContactProvider.DeepSave,
							new object[] { transactionManager, entity.StoreContactCollection, deepSaveType, childTypes, innerList }
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
						if(child.ContactIdSource != null)
						{
								child.ContactId = child.ContactIdSource.ContactId;
						}

						if(child.CreditCardIdSource != null)
						{
								child.CreditCardId = child.CreditCardIdSource.CreditCardId;
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
				
	
			#region List<VendorContact>
				if (CanDeepSave(entity.VendorContactCollection, "List<VendorContact>|VendorContactCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(VendorContact child in entity.VendorContactCollection)
					{
						if(child.ContactIdSource != null)
						{
								child.ContactId = child.ContactIdSource.ContactId;
						}

						if(child.VendorIdSource != null)
						{
								child.VendorId = child.VendorIdSource.VendorId;
						}

					}

					if (entity.VendorContactCollection.Count > 0 || entity.VendorContactCollection.DeletedItems.Count > 0)
					{
						//DataRepository.VendorContactProvider.Save(transactionManager, entity.VendorContactCollection);
						
						deepHandles.Add("VendorContactCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< VendorContact >) DataRepository.VendorContactProvider.DeepSave,
							new object[] { transactionManager, entity.VendorContactCollection, deepSaveType, childTypes, innerList }
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
	
	#region ContactChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Contact</c>
	///</summary>
	public enum ContactChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Contact</c> as OneToMany for EmployeeCollection
		///</summary>
		[ChildEntityType(typeof(TList<Employee>))]
		EmployeeCollection,

		///<summary>
		/// Collection of <c>Contact</c> as OneToMany for SalesOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderHeaderCollection,

		///<summary>
		/// Collection of <c>Contact</c> as OneToMany for IndividualCollection
		///</summary>
		[ChildEntityType(typeof(TList<Individual>))]
		IndividualCollection,

		///<summary>
		/// Collection of <c>Contact</c> as OneToMany for StoreContactCollection
		///</summary>
		[ChildEntityType(typeof(TList<StoreContact>))]
		StoreContactCollection,

		///<summary>
		/// Collection of <c>Contact</c> as OneToMany for ContactCreditCardCollection
		///</summary>
		[ChildEntityType(typeof(TList<ContactCreditCard>))]
		ContactCreditCardCollection,

		///<summary>
		/// Collection of <c>Contact</c> as OneToMany for VendorContactCollection
		///</summary>
		[ChildEntityType(typeof(TList<VendorContact>))]
		VendorContactCollection,

		///<summary>
		/// Collection of <c>Contact</c> as ManyToMany for CreditCardCollection_From_ContactCreditCard
		///</summary>
		[ChildEntityType(typeof(TList<CreditCard>))]
		CreditCardIdCreditCardCollection_From_ContactCreditCard,

		///<summary>
		/// Collection of <c>Contact</c> as ManyToMany for StoreCollection_From_StoreContact
		///</summary>
		[ChildEntityType(typeof(TList<Store>))]
		CustomerIdStoreCollection_From_StoreContact,

		///<summary>
		/// Collection of <c>Contact</c> as ManyToMany for VendorCollection_From_VendorContact
		///</summary>
		[ChildEntityType(typeof(TList<Vendor>))]
		VendorIdVendorCollection_From_VendorContact,
	}
	
	#endregion ContactChildEntityTypes
	
	#region ContactFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ContactColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactFilterBuilder : SqlFilterBuilder<ContactColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactFilterBuilder class.
		/// </summary>
		public ContactFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactFilterBuilder
	
	#region ContactParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ContactColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contact"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactParameterBuilder : ParameterizedSqlFilterBuilder<ContactColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactParameterBuilder class.
		/// </summary>
		public ContactParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactParameterBuilder
	
	#region ContactSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ContactColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contact"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ContactSortBuilder : SqlSortBuilder<ContactColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactSqlSortBuilder class.
		/// </summary>
		public ContactSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ContactSortBuilder
	
} // end namespace
