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
	/// This class is the base class for any <see cref="VendorProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class VendorProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Vendor, Nettiers.AdventureWorks.Entities.VendorKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByProductIdFromProductVendor
		
		/// <summary>
		///		Gets Vendor objects from the datasource by ProductID in the
		///		ProductVendor table. Table Vendor is related to table Product
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByProductIdFromProductVendor(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromProductVendor(null,_productId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Vendor objects from the datasource by ProductID in the
		///		ProductVendor table. Table Vendor is related to table Product
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Vendor objects.</returns>
		public TList<Vendor> GetByProductIdFromProductVendor(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromProductVendor(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Vendor objects from the datasource by ProductID in the
		///		ProductVendor table. Table Vendor is related to table Product
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByProductIdFromProductVendor(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromProductVendor(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Vendor objects from the datasource by ProductID in the
		///		ProductVendor table. Table Vendor is related to table Product
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByProductIdFromProductVendor(TransactionManager transactionManager, System.Int32 _productId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromProductVendor(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Vendor objects from the datasource by ProductID in the
		///		ProductVendor table. Table Vendor is related to table Product
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByProductIdFromProductVendor(System.Int32 _productId,int start, int pageLength, out int count)
		{
			
			return GetByProductIdFromProductVendor(null, _productId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Vendor objects from the datasource by ProductID in the
		///		ProductVendor table. Table Vendor is related to table Product
		///		through the (M:N) relationship defined in the ProductVendor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productId">Primary key. Foreign key to Product.ProductID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Vendor objects.</returns>
		public abstract TList<Vendor> GetByProductIdFromProductVendor(TransactionManager transactionManager,System.Int32 _productId, int start, int pageLength, out int count);
		
		#endregion GetByProductIdFromProductVendor
		
		#region GetByAddressIdFromVendorAddress
		
		/// <summary>
		///		Gets Vendor objects from the datasource by AddressID in the
		///		VendorAddress table. Table Vendor is related to table Address
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByAddressIdFromVendorAddress(System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressIdFromVendorAddress(null,_addressId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Vendor objects from the datasource by AddressID in the
		///		VendorAddress table. Table Vendor is related to table Address
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Vendor objects.</returns>
		public TList<Vendor> GetByAddressIdFromVendorAddress(System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressIdFromVendorAddress(null, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Vendor objects from the datasource by AddressID in the
		///		VendorAddress table. Table Vendor is related to table Address
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByAddressIdFromVendorAddress(TransactionManager transactionManager, System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressIdFromVendorAddress(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Vendor objects from the datasource by AddressID in the
		///		VendorAddress table. Table Vendor is related to table Address
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByAddressIdFromVendorAddress(TransactionManager transactionManager, System.Int32 _addressId,int start, int pageLength)
		{
			int count = -1;
			return GetByAddressIdFromVendorAddress(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Vendor objects from the datasource by AddressID in the
		///		VendorAddress table. Table Vendor is related to table Address
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByAddressIdFromVendorAddress(System.Int32 _addressId,int start, int pageLength, out int count)
		{
			
			return GetByAddressIdFromVendorAddress(null, _addressId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Vendor objects from the datasource by AddressID in the
		///		VendorAddress table. Table Vendor is related to table Address
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Vendor objects.</returns>
		public abstract TList<Vendor> GetByAddressIdFromVendorAddress(TransactionManager transactionManager,System.Int32 _addressId, int start, int pageLength, out int count);
		
		#endregion GetByAddressIdFromVendorAddress
		
		#region GetByContactIdFromVendorContact
		
		/// <summary>
		///		Gets Vendor objects from the datasource by ContactID in the
		///		VendorContact table. Table Vendor is related to table Contact
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByContactIdFromVendorContact(System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactIdFromVendorContact(null,_contactId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Vendor objects from the datasource by ContactID in the
		///		VendorContact table. Table Vendor is related to table Contact
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Vendor objects.</returns>
		public TList<Vendor> GetByContactIdFromVendorContact(System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactIdFromVendorContact(null, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Vendor objects from the datasource by ContactID in the
		///		VendorContact table. Table Vendor is related to table Contact
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByContactIdFromVendorContact(TransactionManager transactionManager, System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactIdFromVendorContact(transactionManager, _contactId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Vendor objects from the datasource by ContactID in the
		///		VendorContact table. Table Vendor is related to table Contact
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByContactIdFromVendorContact(TransactionManager transactionManager, System.Int32 _contactId,int start, int pageLength)
		{
			int count = -1;
			return GetByContactIdFromVendorContact(transactionManager, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Vendor objects from the datasource by ContactID in the
		///		VendorContact table. Table Vendor is related to table Contact
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Vendor objects.</returns>
		public TList<Vendor> GetByContactIdFromVendorContact(System.Int32 _contactId,int start, int pageLength, out int count)
		{
			
			return GetByContactIdFromVendorContact(null, _contactId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Vendor objects from the datasource by ContactID in the
		///		VendorContact table. Table Vendor is related to table Contact
		///		through the (M:N) relationship defined in the VendorContact table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_contactId">Contact (Vendor employee) identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Vendor objects.</returns>
		public abstract TList<Vendor> GetByContactIdFromVendorContact(TransactionManager transactionManager,System.Int32 _contactId, int start, int pageLength, out int count);
		
		#endregion GetByContactIdFromVendorContact
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorKey key)
		{
			return Delete(transactionManager, key.VendorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_vendorId">Primary key for Vendor records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _vendorId)
		{
			return Delete(null, _vendorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key for Vendor records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _vendorId);		
		
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
		public override Nettiers.AdventureWorks.Entities.Vendor Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.VendorKey key, int start, int pageLength)
		{
			return GetByVendorId(transactionManager, key.VendorId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Vendor_AccountNumber index.
		/// </summary>
		/// <param name="_accountNumber">Vendor account (identification) number.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByAccountNumber(System.String _accountNumber)
		{
			int count = -1;
			return GetByAccountNumber(null,_accountNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Vendor_AccountNumber index.
		/// </summary>
		/// <param name="_accountNumber">Vendor account (identification) number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByAccountNumber(System.String _accountNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountNumber(null, _accountNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Vendor_AccountNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountNumber">Vendor account (identification) number.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByAccountNumber(TransactionManager transactionManager, System.String _accountNumber)
		{
			int count = -1;
			return GetByAccountNumber(transactionManager, _accountNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Vendor_AccountNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountNumber">Vendor account (identification) number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByAccountNumber(TransactionManager transactionManager, System.String _accountNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountNumber(transactionManager, _accountNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Vendor_AccountNumber index.
		/// </summary>
		/// <param name="_accountNumber">Vendor account (identification) number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByAccountNumber(System.String _accountNumber, int start, int pageLength, out int count)
		{
			return GetByAccountNumber(null, _accountNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Vendor_AccountNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountNumber">Vendor account (identification) number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Vendor GetByAccountNumber(TransactionManager transactionManager, System.String _accountNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Vendor_VendorID index.
		/// </summary>
		/// <param name="_vendorId">Primary key for Vendor records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByVendorId(System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(null,_vendorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vendor_VendorID index.
		/// </summary>
		/// <param name="_vendorId">Primary key for Vendor records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByVendorId(System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorId(null, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vendor_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key for Vendor records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vendor_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key for Vendor records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorId(transactionManager, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vendor_VendorID index.
		/// </summary>
		/// <param name="_vendorId">Primary key for Vendor records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Vendor GetByVendorId(System.Int32 _vendorId, int start, int pageLength, out int count)
		{
			return GetByVendorId(null, _vendorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vendor_VendorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key for Vendor records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Vendor GetByVendorId(TransactionManager transactionManager, System.Int32 _vendorId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Vendor&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Vendor&gt;"/></returns>
		public static TList<Vendor> Fill(IDataReader reader, TList<Vendor> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Vendor c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Vendor")
					.Append("|").Append((System.Int32)reader[((int)VendorColumn.VendorId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Vendor>(
					key.ToString(), // EntityTrackingKey
					"Vendor",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Vendor();
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
					c.VendorId = (System.Int32)reader[((int)VendorColumn.VendorId - 1)];
					c.AccountNumber = (System.String)reader[((int)VendorColumn.AccountNumber - 1)];
					c.Name = (System.String)reader[((int)VendorColumn.Name - 1)];
					c.CreditRating = (System.Byte)reader[((int)VendorColumn.CreditRating - 1)];
					c.PreferredVendorStatus = (System.Boolean)reader[((int)VendorColumn.PreferredVendorStatus - 1)];
					c.ActiveFlag = (System.Boolean)reader[((int)VendorColumn.ActiveFlag - 1)];
					c.PurchasingWebServiceUrl = (reader.IsDBNull(((int)VendorColumn.PurchasingWebServiceUrl - 1)))?null:(System.String)reader[((int)VendorColumn.PurchasingWebServiceUrl - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)VendorColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Vendor entity)
		{
			if (!reader.Read()) return;
			
			entity.VendorId = (System.Int32)reader[((int)VendorColumn.VendorId - 1)];
			entity.AccountNumber = (System.String)reader[((int)VendorColumn.AccountNumber - 1)];
			entity.Name = (System.String)reader[((int)VendorColumn.Name - 1)];
			entity.CreditRating = (System.Byte)reader[((int)VendorColumn.CreditRating - 1)];
			entity.PreferredVendorStatus = (System.Boolean)reader[((int)VendorColumn.PreferredVendorStatus - 1)];
			entity.ActiveFlag = (System.Boolean)reader[((int)VendorColumn.ActiveFlag - 1)];
			entity.PurchasingWebServiceUrl = (reader.IsDBNull(((int)VendorColumn.PurchasingWebServiceUrl - 1)))?null:(System.String)reader[((int)VendorColumn.PurchasingWebServiceUrl - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)VendorColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Vendor entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.VendorId = (System.Int32)dataRow["VendorID"];
			entity.AccountNumber = (System.String)dataRow["AccountNumber"];
			entity.Name = (System.String)dataRow["Name"];
			entity.CreditRating = (System.Byte)dataRow["CreditRating"];
			entity.PreferredVendorStatus = (System.Boolean)dataRow["PreferredVendorStatus"];
			entity.ActiveFlag = (System.Boolean)dataRow["ActiveFlag"];
			entity.PurchasingWebServiceUrl = Convert.IsDBNull(dataRow["PurchasingWebServiceURL"]) ? null : (System.String)dataRow["PurchasingWebServiceURL"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Vendor"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Vendor Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Vendor entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByVendorId methods when available
			
			#region VendorAddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<VendorAddress>|VendorAddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorAddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.VendorAddressCollection = DataRepository.VendorAddressProvider.GetByVendorId(transactionManager, entity.VendorId);

				if (deep && entity.VendorAddressCollection.Count > 0)
				{
					deepHandles.Add("VendorAddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<VendorAddress>) DataRepository.VendorAddressProvider.DeepLoad,
						new object[] { transactionManager, entity.VendorAddressCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductIdProductCollection_From_ProductVendor
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Product>|ProductIdProductCollection_From_ProductVendor", deepLoadType, innerList))
			{
				entity.ProductIdProductCollection_From_ProductVendor = DataRepository.ProductProvider.GetByVendorIdFromProductVendor(transactionManager, entity.VendorId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdProductCollection_From_ProductVendor' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdProductCollection_From_ProductVendor != null)
				{
					deepHandles.Add("ProductIdProductCollection_From_ProductVendor",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Product >) DataRepository.ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_ProductVendor, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region AddressIdAddressCollection_From_VendorAddress
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Address>|AddressIdAddressCollection_From_VendorAddress", deepLoadType, innerList))
			{
				entity.AddressIdAddressCollection_From_VendorAddress = DataRepository.AddressProvider.GetByVendorIdFromVendorAddress(transactionManager, entity.VendorId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AddressIdAddressCollection_From_VendorAddress' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AddressIdAddressCollection_From_VendorAddress != null)
				{
					deepHandles.Add("AddressIdAddressCollection_From_VendorAddress",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Address >) DataRepository.AddressProvider.DeepLoad,
						new object[] { transactionManager, entity.AddressIdAddressCollection_From_VendorAddress, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ContactIdContactCollection_From_VendorContact
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Contact>|ContactIdContactCollection_From_VendorContact", deepLoadType, innerList))
			{
				entity.ContactIdContactCollection_From_VendorContact = DataRepository.ContactProvider.GetByVendorIdFromVendorContact(transactionManager, entity.VendorId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ContactIdContactCollection_From_VendorContact' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ContactIdContactCollection_From_VendorContact != null)
				{
					deepHandles.Add("ContactIdContactCollection_From_VendorContact",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Contact >) DataRepository.ContactProvider.DeepLoad,
						new object[] { transactionManager, entity.ContactIdContactCollection_From_VendorContact, deep, deepLoadType, childTypes, innerList }
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

				entity.VendorContactCollection = DataRepository.VendorContactProvider.GetByVendorId(transactionManager, entity.VendorId);

				if (deep && entity.VendorContactCollection.Count > 0)
				{
					deepHandles.Add("VendorContactCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<VendorContact>) DataRepository.VendorContactProvider.DeepLoad,
						new object[] { transactionManager, entity.VendorContactCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region PurchaseOrderHeaderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PurchaseOrderHeader>|PurchaseOrderHeaderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PurchaseOrderHeaderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PurchaseOrderHeaderCollection = DataRepository.PurchaseOrderHeaderProvider.GetByVendorId(transactionManager, entity.VendorId);

				if (deep && entity.PurchaseOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("PurchaseOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PurchaseOrderHeader>) DataRepository.PurchaseOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.PurchaseOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.ProductVendorCollection = DataRepository.ProductVendorProvider.GetByVendorId(transactionManager, entity.VendorId);

				if (deep && entity.ProductVendorCollection.Count > 0)
				{
					deepHandles.Add("ProductVendorCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductVendor>) DataRepository.ProductVendorProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductVendorCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Vendor object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Vendor instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Vendor Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Vendor entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region ProductIdProductCollection_From_ProductVendor>
			if (CanDeepSave(entity.ProductIdProductCollection_From_ProductVendor, "List<Product>|ProductIdProductCollection_From_ProductVendor", deepSaveType, innerList))
			{
				if (entity.ProductIdProductCollection_From_ProductVendor.Count > 0 || entity.ProductIdProductCollection_From_ProductVendor.DeletedItems.Count > 0)
				{
					DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdProductCollection_From_ProductVendor); 
					deepHandles.Add("ProductIdProductCollection_From_ProductVendor",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Product>) DataRepository.ProductProvider.DeepSave,
						new object[] { transactionManager, entity.ProductIdProductCollection_From_ProductVendor, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region AddressIdAddressCollection_From_VendorAddress>
			if (CanDeepSave(entity.AddressIdAddressCollection_From_VendorAddress, "List<Address>|AddressIdAddressCollection_From_VendorAddress", deepSaveType, innerList))
			{
				if (entity.AddressIdAddressCollection_From_VendorAddress.Count > 0 || entity.AddressIdAddressCollection_From_VendorAddress.DeletedItems.Count > 0)
				{
					DataRepository.AddressProvider.Save(transactionManager, entity.AddressIdAddressCollection_From_VendorAddress); 
					deepHandles.Add("AddressIdAddressCollection_From_VendorAddress",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Address>) DataRepository.AddressProvider.DeepSave,
						new object[] { transactionManager, entity.AddressIdAddressCollection_From_VendorAddress, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region ContactIdContactCollection_From_VendorContact>
			if (CanDeepSave(entity.ContactIdContactCollection_From_VendorContact, "List<Contact>|ContactIdContactCollection_From_VendorContact", deepSaveType, innerList))
			{
				if (entity.ContactIdContactCollection_From_VendorContact.Count > 0 || entity.ContactIdContactCollection_From_VendorContact.DeletedItems.Count > 0)
				{
					DataRepository.ContactProvider.Save(transactionManager, entity.ContactIdContactCollection_From_VendorContact); 
					deepHandles.Add("ContactIdContactCollection_From_VendorContact",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Contact>) DataRepository.ContactProvider.DeepSave,
						new object[] { transactionManager, entity.ContactIdContactCollection_From_VendorContact, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<VendorAddress>
				if (CanDeepSave(entity.VendorAddressCollection, "List<VendorAddress>|VendorAddressCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(VendorAddress child in entity.VendorAddressCollection)
					{
						if(child.VendorIdSource != null)
						{
								child.VendorId = child.VendorIdSource.VendorId;
						}

						if(child.AddressIdSource != null)
						{
								child.AddressId = child.AddressIdSource.AddressId;
						}

					}

					if (entity.VendorAddressCollection.Count > 0 || entity.VendorAddressCollection.DeletedItems.Count > 0)
					{
						//DataRepository.VendorAddressProvider.Save(transactionManager, entity.VendorAddressCollection);
						
						deepHandles.Add("VendorAddressCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< VendorAddress >) DataRepository.VendorAddressProvider.DeepSave,
							new object[] { transactionManager, entity.VendorAddressCollection, deepSaveType, childTypes, innerList }
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
						if(child.VendorIdSource != null)
						{
								child.VendorId = child.VendorIdSource.VendorId;
						}

						if(child.ContactIdSource != null)
						{
								child.ContactId = child.ContactIdSource.ContactId;
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
				
	
			#region List<PurchaseOrderHeader>
				if (CanDeepSave(entity.PurchaseOrderHeaderCollection, "List<PurchaseOrderHeader>|PurchaseOrderHeaderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PurchaseOrderHeader child in entity.PurchaseOrderHeaderCollection)
					{
						if(child.VendorIdSource != null)
						{
							child.VendorId = child.VendorIdSource.VendorId;
						}
						else
						{
							child.VendorId = entity.VendorId;
						}

					}

					if (entity.PurchaseOrderHeaderCollection.Count > 0 || entity.PurchaseOrderHeaderCollection.DeletedItems.Count > 0)
					{
						//DataRepository.PurchaseOrderHeaderProvider.Save(transactionManager, entity.PurchaseOrderHeaderCollection);
						
						deepHandles.Add("PurchaseOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< PurchaseOrderHeader >) DataRepository.PurchaseOrderHeaderProvider.DeepSave,
							new object[] { transactionManager, entity.PurchaseOrderHeaderCollection, deepSaveType, childTypes, innerList }
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
						if(child.VendorIdSource != null)
						{
								child.VendorId = child.VendorIdSource.VendorId;
						}

						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

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
	
	#region VendorChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Vendor</c>
	///</summary>
	public enum VendorChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Vendor</c> as OneToMany for VendorAddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<VendorAddress>))]
		VendorAddressCollection,

		///<summary>
		/// Collection of <c>Vendor</c> as ManyToMany for ProductCollection_From_ProductVendor
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductIdProductCollection_From_ProductVendor,

		///<summary>
		/// Collection of <c>Vendor</c> as ManyToMany for AddressCollection_From_VendorAddress
		///</summary>
		[ChildEntityType(typeof(TList<Address>))]
		AddressIdAddressCollection_From_VendorAddress,

		///<summary>
		/// Collection of <c>Vendor</c> as ManyToMany for ContactCollection_From_VendorContact
		///</summary>
		[ChildEntityType(typeof(TList<Contact>))]
		ContactIdContactCollection_From_VendorContact,

		///<summary>
		/// Collection of <c>Vendor</c> as OneToMany for VendorContactCollection
		///</summary>
		[ChildEntityType(typeof(TList<VendorContact>))]
		VendorContactCollection,

		///<summary>
		/// Collection of <c>Vendor</c> as OneToMany for PurchaseOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<PurchaseOrderHeader>))]
		PurchaseOrderHeaderCollection,

		///<summary>
		/// Collection of <c>Vendor</c> as OneToMany for ProductVendorCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductVendor>))]
		ProductVendorCollection,
	}
	
	#endregion VendorChildEntityTypes
	
	#region VendorFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;VendorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorFilterBuilder : SqlFilterBuilder<VendorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorFilterBuilder class.
		/// </summary>
		public VendorFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorFilterBuilder
	
	#region VendorParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;VendorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VendorParameterBuilder : ParameterizedSqlFilterBuilder<VendorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorParameterBuilder class.
		/// </summary>
		public VendorParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VendorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VendorParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VendorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VendorParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VendorParameterBuilder
	
	#region VendorSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;VendorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vendor"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VendorSortBuilder : SqlSortBuilder<VendorColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VendorSqlSortBuilder class.
		/// </summary>
		public VendorSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VendorSortBuilder
	
} // end namespace
