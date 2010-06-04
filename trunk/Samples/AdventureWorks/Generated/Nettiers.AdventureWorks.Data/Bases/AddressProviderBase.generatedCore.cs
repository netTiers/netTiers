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
	/// This class is the base class for any <see cref="AddressProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AddressProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Address, Nettiers.AdventureWorks.Entities.AddressKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByCustomerIdFromCustomerAddress
		
		/// <summary>
		///		Gets Address objects from the datasource by CustomerID in the
		///		CustomerAddress table. Table Address is related to table Customer
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByCustomerIdFromCustomerAddress(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerIdFromCustomerAddress(null,_customerId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Address objects from the datasource by CustomerID in the
		///		CustomerAddress table. Table Address is related to table Customer
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Address objects.</returns>
		public TList<Address> GetByCustomerIdFromCustomerAddress(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdFromCustomerAddress(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Address objects from the datasource by CustomerID in the
		///		CustomerAddress table. Table Address is related to table Customer
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByCustomerIdFromCustomerAddress(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerIdFromCustomerAddress(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Address objects from the datasource by CustomerID in the
		///		CustomerAddress table. Table Address is related to table Customer
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByCustomerIdFromCustomerAddress(TransactionManager transactionManager, System.Int32 _customerId,int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdFromCustomerAddress(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Address objects from the datasource by CustomerID in the
		///		CustomerAddress table. Table Address is related to table Customer
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByCustomerIdFromCustomerAddress(System.Int32 _customerId,int start, int pageLength, out int count)
		{
			
			return GetByCustomerIdFromCustomerAddress(null, _customerId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Address objects from the datasource by CustomerID in the
		///		CustomerAddress table. Table Address is related to table Customer
		///		through the (M:N) relationship defined in the CustomerAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_customerId">Primary key. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Address objects.</returns>
		public abstract TList<Address> GetByCustomerIdFromCustomerAddress(TransactionManager transactionManager,System.Int32 _customerId, int start, int pageLength, out int count);
		
		#endregion GetByCustomerIdFromCustomerAddress
		
		#region GetByEmployeeIdFromEmployeeAddress
		
		/// <summary>
		///		Gets Address objects from the datasource by EmployeeID in the
		///		EmployeeAddress table. Table Address is related to table Employee
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByEmployeeIdFromEmployeeAddress(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeIdFromEmployeeAddress(null,_employeeId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Address objects from the datasource by EmployeeID in the
		///		EmployeeAddress table. Table Address is related to table Employee
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Address objects.</returns>
		public TList<Address> GetByEmployeeIdFromEmployeeAddress(System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdFromEmployeeAddress(null, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Address objects from the datasource by EmployeeID in the
		///		EmployeeAddress table. Table Address is related to table Employee
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByEmployeeIdFromEmployeeAddress(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeIdFromEmployeeAddress(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Address objects from the datasource by EmployeeID in the
		///		EmployeeAddress table. Table Address is related to table Employee
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByEmployeeIdFromEmployeeAddress(TransactionManager transactionManager, System.Int32 _employeeId,int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdFromEmployeeAddress(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Address objects from the datasource by EmployeeID in the
		///		EmployeeAddress table. Table Address is related to table Employee
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByEmployeeIdFromEmployeeAddress(System.Int32 _employeeId,int start, int pageLength, out int count)
		{
			
			return GetByEmployeeIdFromEmployeeAddress(null, _employeeId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Address objects from the datasource by EmployeeID in the
		///		EmployeeAddress table. Table Address is related to table Employee
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_employeeId">Primary key. Foreign key to Employee.EmployeeID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Address objects.</returns>
		public abstract TList<Address> GetByEmployeeIdFromEmployeeAddress(TransactionManager transactionManager,System.Int32 _employeeId, int start, int pageLength, out int count);
		
		#endregion GetByEmployeeIdFromEmployeeAddress
		
		#region GetByVendorIdFromVendorAddress
		
		/// <summary>
		///		Gets Address objects from the datasource by VendorID in the
		///		VendorAddress table. Table Address is related to table Vendor
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByVendorIdFromVendorAddress(System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorIdFromVendorAddress(null,_vendorId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Address objects from the datasource by VendorID in the
		///		VendorAddress table. Table Address is related to table Vendor
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Address objects.</returns>
		public TList<Address> GetByVendorIdFromVendorAddress(System.Int32 _vendorId, int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdFromVendorAddress(null, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Address objects from the datasource by VendorID in the
		///		VendorAddress table. Table Address is related to table Vendor
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByVendorIdFromVendorAddress(TransactionManager transactionManager, System.Int32 _vendorId)
		{
			int count = -1;
			return GetByVendorIdFromVendorAddress(transactionManager, _vendorId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Address objects from the datasource by VendorID in the
		///		VendorAddress table. Table Address is related to table Vendor
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByVendorIdFromVendorAddress(TransactionManager transactionManager, System.Int32 _vendorId,int start, int pageLength)
		{
			int count = -1;
			return GetByVendorIdFromVendorAddress(transactionManager, _vendorId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Address objects from the datasource by VendorID in the
		///		VendorAddress table. Table Address is related to table Vendor
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Address objects.</returns>
		public TList<Address> GetByVendorIdFromVendorAddress(System.Int32 _vendorId,int start, int pageLength, out int count)
		{
			
			return GetByVendorIdFromVendorAddress(null, _vendorId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Address objects from the datasource by VendorID in the
		///		VendorAddress table. Table Address is related to table Vendor
		///		through the (M:N) relationship defined in the VendorAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_vendorId">Primary key. Foreign key to Vendor.VendorID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Address objects.</returns>
		public abstract TList<Address> GetByVendorIdFromVendorAddress(TransactionManager transactionManager,System.Int32 _vendorId, int start, int pageLength, out int count);
		
		#endregion GetByVendorIdFromVendorAddress
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AddressKey key)
		{
			return Delete(transactionManager, key.AddressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_addressId">Primary key for Address records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _addressId)
		{
			return Delete(null, _addressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key for Address records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _addressId);		
		
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
		public override Nettiers.AdventureWorks.Entities.Address Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.AddressKey key, int start, int pageLength)
		{
			return GetByAddressId(transactionManager, key.AddressId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Address_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Address_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Address_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Address_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Address_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Address_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Address GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode index.
		/// </summary>
		/// <param name="_addressLine1">First street address line.</param>
		/// <param name="_addressLine2">Second street address line.</param>
		/// <param name="_city">Name of the city.</param>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="_postalCode">Postal code for the street address.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(System.String _addressLine1, System.String _addressLine2, System.String _city, System.Int32 _stateProvinceId, System.String _postalCode)
		{
			int count = -1;
			return GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(null,_addressLine1, _addressLine2, _city, _stateProvinceId, _postalCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode index.
		/// </summary>
		/// <param name="_addressLine1">First street address line.</param>
		/// <param name="_addressLine2">Second street address line.</param>
		/// <param name="_city">Name of the city.</param>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="_postalCode">Postal code for the street address.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(System.String _addressLine1, System.String _addressLine2, System.String _city, System.Int32 _stateProvinceId, System.String _postalCode, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(null, _addressLine1, _addressLine2, _city, _stateProvinceId, _postalCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressLine1">First street address line.</param>
		/// <param name="_addressLine2">Second street address line.</param>
		/// <param name="_city">Name of the city.</param>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="_postalCode">Postal code for the street address.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(TransactionManager transactionManager, System.String _addressLine1, System.String _addressLine2, System.String _city, System.Int32 _stateProvinceId, System.String _postalCode)
		{
			int count = -1;
			return GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(transactionManager, _addressLine1, _addressLine2, _city, _stateProvinceId, _postalCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressLine1">First street address line.</param>
		/// <param name="_addressLine2">Second street address line.</param>
		/// <param name="_city">Name of the city.</param>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="_postalCode">Postal code for the street address.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(TransactionManager transactionManager, System.String _addressLine1, System.String _addressLine2, System.String _city, System.Int32 _stateProvinceId, System.String _postalCode, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(transactionManager, _addressLine1, _addressLine2, _city, _stateProvinceId, _postalCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode index.
		/// </summary>
		/// <param name="_addressLine1">First street address line.</param>
		/// <param name="_addressLine2">Second street address line.</param>
		/// <param name="_city">Name of the city.</param>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="_postalCode">Postal code for the street address.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(System.String _addressLine1, System.String _addressLine2, System.String _city, System.Int32 _stateProvinceId, System.String _postalCode, int start, int pageLength, out int count)
		{
			return GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(null, _addressLine1, _addressLine2, _city, _stateProvinceId, _postalCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressLine1">First street address line.</param>
		/// <param name="_addressLine2">Second street address line.</param>
		/// <param name="_city">Name of the city.</param>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="_postalCode">Postal code for the street address.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Address GetByAddressLine1AddressLine2CityStateProvinceIdPostalCode(TransactionManager transactionManager, System.String _addressLine1, System.String _addressLine2, System.String _city, System.Int32 _stateProvinceId, System.String _postalCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Address_StateProvinceID index.
		/// </summary>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Address&gt;"/> class.</returns>
		public TList<Address> GetByStateProvinceId(System.Int32 _stateProvinceId)
		{
			int count = -1;
			return GetByStateProvinceId(null,_stateProvinceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_StateProvinceID index.
		/// </summary>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Address&gt;"/> class.</returns>
		public TList<Address> GetByStateProvinceId(System.Int32 _stateProvinceId, int start, int pageLength)
		{
			int count = -1;
			return GetByStateProvinceId(null, _stateProvinceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_StateProvinceID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Address&gt;"/> class.</returns>
		public TList<Address> GetByStateProvinceId(TransactionManager transactionManager, System.Int32 _stateProvinceId)
		{
			int count = -1;
			return GetByStateProvinceId(transactionManager, _stateProvinceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_StateProvinceID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Address&gt;"/> class.</returns>
		public TList<Address> GetByStateProvinceId(TransactionManager transactionManager, System.Int32 _stateProvinceId, int start, int pageLength)
		{
			int count = -1;
			return GetByStateProvinceId(transactionManager, _stateProvinceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_StateProvinceID index.
		/// </summary>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Address&gt;"/> class.</returns>
		public TList<Address> GetByStateProvinceId(System.Int32 _stateProvinceId, int start, int pageLength, out int count)
		{
			return GetByStateProvinceId(null, _stateProvinceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Address_StateProvinceID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateProvinceId">Unique identification number for the state or province. Foreign key to StateProvince table.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Address&gt;"/> class.</returns>
		public abstract TList<Address> GetByStateProvinceId(TransactionManager transactionManager, System.Int32 _stateProvinceId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Address_AddressID index.
		/// </summary>
		/// <param name="_addressId">Primary key for Address records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressId(System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(null,_addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address_AddressID index.
		/// </summary>
		/// <param name="_addressId">Primary key for Address records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressId(System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(null, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key for Address records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key for Address records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address_AddressID index.
		/// </summary>
		/// <param name="_addressId">Primary key for Address records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Address GetByAddressId(System.Int32 _addressId, int start, int pageLength, out int count)
		{
			return GetByAddressId(null, _addressId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address_AddressID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key for Address records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Address"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Address GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Address&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Address&gt;"/></returns>
		public static TList<Address> Fill(IDataReader reader, TList<Address> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Address c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Address")
					.Append("|").Append((System.Int32)reader[((int)AddressColumn.AddressId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Address>(
					key.ToString(), // EntityTrackingKey
					"Address",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Address();
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
					c.AddressId = (System.Int32)reader[((int)AddressColumn.AddressId - 1)];
					c.AddressLine1 = (System.String)reader[((int)AddressColumn.AddressLine1 - 1)];
					c.AddressLine2 = (reader.IsDBNull(((int)AddressColumn.AddressLine2 - 1)))?null:(System.String)reader[((int)AddressColumn.AddressLine2 - 1)];
					c.City = (System.String)reader[((int)AddressColumn.City - 1)];
					c.StateProvinceId = (System.Int32)reader[((int)AddressColumn.StateProvinceId - 1)];
					c.PostalCode = (System.String)reader[((int)AddressColumn.PostalCode - 1)];
					c.Rowguid = (System.Guid)reader[((int)AddressColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)AddressColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Address"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Address"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Address entity)
		{
			if (!reader.Read()) return;
			
			entity.AddressId = (System.Int32)reader[((int)AddressColumn.AddressId - 1)];
			entity.AddressLine1 = (System.String)reader[((int)AddressColumn.AddressLine1 - 1)];
			entity.AddressLine2 = (reader.IsDBNull(((int)AddressColumn.AddressLine2 - 1)))?null:(System.String)reader[((int)AddressColumn.AddressLine2 - 1)];
			entity.City = (System.String)reader[((int)AddressColumn.City - 1)];
			entity.StateProvinceId = (System.Int32)reader[((int)AddressColumn.StateProvinceId - 1)];
			entity.PostalCode = (System.String)reader[((int)AddressColumn.PostalCode - 1)];
			entity.Rowguid = (System.Guid)reader[((int)AddressColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)AddressColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Address"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Address"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Address entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AddressId = (System.Int32)dataRow["AddressID"];
			entity.AddressLine1 = (System.String)dataRow["AddressLine1"];
			entity.AddressLine2 = Convert.IsDBNull(dataRow["AddressLine2"]) ? null : (System.String)dataRow["AddressLine2"];
			entity.City = (System.String)dataRow["City"];
			entity.StateProvinceId = (System.Int32)dataRow["StateProvinceID"];
			entity.PostalCode = (System.String)dataRow["PostalCode"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Address"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Address Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Address entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region StateProvinceIdSource	
			if (CanDeepLoad(entity, "StateProvince|StateProvinceIdSource", deepLoadType, innerList) 
				&& entity.StateProvinceIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.StateProvinceId;
				StateProvince tmpEntity = EntityManager.LocateEntity<StateProvince>(EntityLocator.ConstructKeyFromPkItems(typeof(StateProvince), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.StateProvinceIdSource = tmpEntity;
				else
					entity.StateProvinceIdSource = DataRepository.StateProvinceProvider.GetByStateProvinceId(transactionManager, entity.StateProvinceId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StateProvinceIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.StateProvinceIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.StateProvinceProvider.DeepLoad(transactionManager, entity.StateProvinceIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion StateProvinceIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByAddressId methods when available
			
			#region CustomerAddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerAddress>|CustomerAddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerAddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerAddressCollection = DataRepository.CustomerAddressProvider.GetByAddressId(transactionManager, entity.AddressId);

				if (deep && entity.CustomerAddressCollection.Count > 0)
				{
					deepHandles.Add("CustomerAddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerAddress>) DataRepository.CustomerAddressProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerAddressCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerIdCustomerCollection_From_CustomerAddress
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Customer>|CustomerIdCustomerCollection_From_CustomerAddress", deepLoadType, innerList))
			{
				entity.CustomerIdCustomerCollection_From_CustomerAddress = DataRepository.CustomerProvider.GetByAddressIdFromCustomerAddress(transactionManager, entity.AddressId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdCustomerCollection_From_CustomerAddress' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdCustomerCollection_From_CustomerAddress != null)
				{
					deepHandles.Add("CustomerIdCustomerCollection_From_CustomerAddress",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Customer >) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerIdCustomerCollection_From_CustomerAddress, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region SalesOrderHeaderCollectionGetByBillToAddressId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderHeader>|SalesOrderHeaderCollectionGetByBillToAddressId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderHeaderCollectionGetByBillToAddressId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderHeaderCollectionGetByBillToAddressId = DataRepository.SalesOrderHeaderProvider.GetByBillToAddressId(transactionManager, entity.AddressId);

				if (deep && entity.SalesOrderHeaderCollectionGetByBillToAddressId.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderCollectionGetByBillToAddressId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderCollectionGetByBillToAddressId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmployeeAddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeAddress>|EmployeeAddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeAddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeAddressCollection = DataRepository.EmployeeAddressProvider.GetByAddressId(transactionManager, entity.AddressId);

				if (deep && entity.EmployeeAddressCollection.Count > 0)
				{
					deepHandles.Add("EmployeeAddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeAddress>) DataRepository.EmployeeAddressProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeAddressCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesOrderHeaderCollectionGetByShipToAddressId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderHeader>|SalesOrderHeaderCollectionGetByShipToAddressId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderHeaderCollectionGetByShipToAddressId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderHeaderCollectionGetByShipToAddressId = DataRepository.SalesOrderHeaderProvider.GetByShipToAddressId(transactionManager, entity.AddressId);

				if (deep && entity.SalesOrderHeaderCollectionGetByShipToAddressId.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderCollectionGetByShipToAddressId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeader>) DataRepository.SalesOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderCollectionGetByShipToAddressId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region VendorIdVendorCollection_From_VendorAddress
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Vendor>|VendorIdVendorCollection_From_VendorAddress", deepLoadType, innerList))
			{
				entity.VendorIdVendorCollection_From_VendorAddress = DataRepository.VendorProvider.GetByAddressIdFromVendorAddress(transactionManager, entity.AddressId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorIdVendorCollection_From_VendorAddress' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.VendorIdVendorCollection_From_VendorAddress != null)
				{
					deepHandles.Add("VendorIdVendorCollection_From_VendorAddress",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Vendor >) DataRepository.VendorProvider.DeepLoad,
						new object[] { transactionManager, entity.VendorIdVendorCollection_From_VendorAddress, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region VendorAddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<VendorAddress>|VendorAddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VendorAddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.VendorAddressCollection = DataRepository.VendorAddressProvider.GetByAddressId(transactionManager, entity.AddressId);

				if (deep && entity.VendorAddressCollection.Count > 0)
				{
					deepHandles.Add("VendorAddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<VendorAddress>) DataRepository.VendorAddressProvider.DeepLoad,
						new object[] { transactionManager, entity.VendorAddressCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmployeeIdEmployeeCollection_From_EmployeeAddress
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Employee>|EmployeeIdEmployeeCollection_From_EmployeeAddress", deepLoadType, innerList))
			{
				entity.EmployeeIdEmployeeCollection_From_EmployeeAddress = DataRepository.EmployeeProvider.GetByAddressIdFromEmployeeAddress(transactionManager, entity.AddressId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeIdEmployeeCollection_From_EmployeeAddress' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmployeeIdEmployeeCollection_From_EmployeeAddress != null)
				{
					deepHandles.Add("EmployeeIdEmployeeCollection_From_EmployeeAddress",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Employee >) DataRepository.EmployeeProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeIdEmployeeCollection_From_EmployeeAddress, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Address object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Address instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Address Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Address entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region StateProvinceIdSource
			if (CanDeepSave(entity, "StateProvince|StateProvinceIdSource", deepSaveType, innerList) 
				&& entity.StateProvinceIdSource != null)
			{
				DataRepository.StateProvinceProvider.Save(transactionManager, entity.StateProvinceIdSource);
				entity.StateProvinceId = entity.StateProvinceIdSource.StateProvinceId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region CustomerIdCustomerCollection_From_CustomerAddress>
			if (CanDeepSave(entity.CustomerIdCustomerCollection_From_CustomerAddress, "List<Customer>|CustomerIdCustomerCollection_From_CustomerAddress", deepSaveType, innerList))
			{
				if (entity.CustomerIdCustomerCollection_From_CustomerAddress.Count > 0 || entity.CustomerIdCustomerCollection_From_CustomerAddress.DeletedItems.Count > 0)
				{
					DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerIdCustomerCollection_From_CustomerAddress); 
					deepHandles.Add("CustomerIdCustomerCollection_From_CustomerAddress",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Customer>) DataRepository.CustomerProvider.DeepSave,
						new object[] { transactionManager, entity.CustomerIdCustomerCollection_From_CustomerAddress, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region VendorIdVendorCollection_From_VendorAddress>
			if (CanDeepSave(entity.VendorIdVendorCollection_From_VendorAddress, "List<Vendor>|VendorIdVendorCollection_From_VendorAddress", deepSaveType, innerList))
			{
				if (entity.VendorIdVendorCollection_From_VendorAddress.Count > 0 || entity.VendorIdVendorCollection_From_VendorAddress.DeletedItems.Count > 0)
				{
					DataRepository.VendorProvider.Save(transactionManager, entity.VendorIdVendorCollection_From_VendorAddress); 
					deepHandles.Add("VendorIdVendorCollection_From_VendorAddress",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Vendor>) DataRepository.VendorProvider.DeepSave,
						new object[] { transactionManager, entity.VendorIdVendorCollection_From_VendorAddress, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region EmployeeIdEmployeeCollection_From_EmployeeAddress>
			if (CanDeepSave(entity.EmployeeIdEmployeeCollection_From_EmployeeAddress, "List<Employee>|EmployeeIdEmployeeCollection_From_EmployeeAddress", deepSaveType, innerList))
			{
				if (entity.EmployeeIdEmployeeCollection_From_EmployeeAddress.Count > 0 || entity.EmployeeIdEmployeeCollection_From_EmployeeAddress.DeletedItems.Count > 0)
				{
					DataRepository.EmployeeProvider.Save(transactionManager, entity.EmployeeIdEmployeeCollection_From_EmployeeAddress); 
					deepHandles.Add("EmployeeIdEmployeeCollection_From_EmployeeAddress",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Employee>) DataRepository.EmployeeProvider.DeepSave,
						new object[] { transactionManager, entity.EmployeeIdEmployeeCollection_From_EmployeeAddress, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<CustomerAddress>
				if (CanDeepSave(entity.CustomerAddressCollection, "List<CustomerAddress>|CustomerAddressCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerAddress child in entity.CustomerAddressCollection)
					{
						if(child.AddressIdSource != null)
						{
								child.AddressId = child.AddressIdSource.AddressId;
						}

						if(child.CustomerIdSource != null)
						{
								child.CustomerId = child.CustomerIdSource.CustomerId;
						}

					}

					if (entity.CustomerAddressCollection.Count > 0 || entity.CustomerAddressCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerAddressProvider.Save(transactionManager, entity.CustomerAddressCollection);
						
						deepHandles.Add("CustomerAddressCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerAddress >) DataRepository.CustomerAddressProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerAddressCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SalesOrderHeader>
				if (CanDeepSave(entity.SalesOrderHeaderCollectionGetByBillToAddressId, "List<SalesOrderHeader>|SalesOrderHeaderCollectionGetByBillToAddressId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderHeader child in entity.SalesOrderHeaderCollectionGetByBillToAddressId)
					{
						if(child.BillToAddressIdSource != null)
						{
							child.BillToAddressId = child.BillToAddressIdSource.AddressId;
						}
						else
						{
							child.BillToAddressId = entity.AddressId;
						}

					}

					if (entity.SalesOrderHeaderCollectionGetByBillToAddressId.Count > 0 || entity.SalesOrderHeaderCollectionGetByBillToAddressId.DeletedItems.Count > 0)
					{
						//DataRepository.SalesOrderHeaderProvider.Save(transactionManager, entity.SalesOrderHeaderCollectionGetByBillToAddressId);
						
						deepHandles.Add("SalesOrderHeaderCollectionGetByBillToAddressId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesOrderHeader >) DataRepository.SalesOrderHeaderProvider.DeepSave,
							new object[] { transactionManager, entity.SalesOrderHeaderCollectionGetByBillToAddressId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<EmployeeAddress>
				if (CanDeepSave(entity.EmployeeAddressCollection, "List<EmployeeAddress>|EmployeeAddressCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmployeeAddress child in entity.EmployeeAddressCollection)
					{
						if(child.AddressIdSource != null)
						{
								child.AddressId = child.AddressIdSource.AddressId;
						}

						if(child.EmployeeIdSource != null)
						{
								child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}

					}

					if (entity.EmployeeAddressCollection.Count > 0 || entity.EmployeeAddressCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeeAddressProvider.Save(transactionManager, entity.EmployeeAddressCollection);
						
						deepHandles.Add("EmployeeAddressCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmployeeAddress >) DataRepository.EmployeeAddressProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeeAddressCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SalesOrderHeader>
				if (CanDeepSave(entity.SalesOrderHeaderCollectionGetByShipToAddressId, "List<SalesOrderHeader>|SalesOrderHeaderCollectionGetByShipToAddressId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderHeader child in entity.SalesOrderHeaderCollectionGetByShipToAddressId)
					{
						if(child.ShipToAddressIdSource != null)
						{
							child.ShipToAddressId = child.ShipToAddressIdSource.AddressId;
						}
						else
						{
							child.ShipToAddressId = entity.AddressId;
						}

					}

					if (entity.SalesOrderHeaderCollectionGetByShipToAddressId.Count > 0 || entity.SalesOrderHeaderCollectionGetByShipToAddressId.DeletedItems.Count > 0)
					{
						//DataRepository.SalesOrderHeaderProvider.Save(transactionManager, entity.SalesOrderHeaderCollectionGetByShipToAddressId);
						
						deepHandles.Add("SalesOrderHeaderCollectionGetByShipToAddressId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesOrderHeader >) DataRepository.SalesOrderHeaderProvider.DeepSave,
							new object[] { transactionManager, entity.SalesOrderHeaderCollectionGetByShipToAddressId, deepSaveType, childTypes, innerList }
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
						if(child.AddressIdSource != null)
						{
								child.AddressId = child.AddressIdSource.AddressId;
						}

						if(child.VendorIdSource != null)
						{
								child.VendorId = child.VendorIdSource.VendorId;
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
	
	#region AddressChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Address</c>
	///</summary>
	public enum AddressChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>StateProvince</c> at StateProvinceIdSource
		///</summary>
		[ChildEntityType(typeof(StateProvince))]
		StateProvince,
	
		///<summary>
		/// Collection of <c>Address</c> as OneToMany for CustomerAddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerAddress>))]
		CustomerAddressCollection,

		///<summary>
		/// Collection of <c>Address</c> as ManyToMany for CustomerCollection_From_CustomerAddress
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerIdCustomerCollection_From_CustomerAddress,

		///<summary>
		/// Collection of <c>Address</c> as OneToMany for SalesOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderHeaderCollectionGetByBillToAddressId,

		///<summary>
		/// Collection of <c>Address</c> as OneToMany for EmployeeAddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeAddress>))]
		EmployeeAddressCollection,

		///<summary>
		/// Collection of <c>Address</c> as OneToMany for SalesOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeader>))]
		SalesOrderHeaderCollectionGetByShipToAddressId,

		///<summary>
		/// Collection of <c>Address</c> as ManyToMany for VendorCollection_From_VendorAddress
		///</summary>
		[ChildEntityType(typeof(TList<Vendor>))]
		VendorIdVendorCollection_From_VendorAddress,

		///<summary>
		/// Collection of <c>Address</c> as OneToMany for VendorAddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<VendorAddress>))]
		VendorAddressCollection,

		///<summary>
		/// Collection of <c>Address</c> as ManyToMany for EmployeeCollection_From_EmployeeAddress
		///</summary>
		[ChildEntityType(typeof(TList<Employee>))]
		EmployeeIdEmployeeCollection_From_EmployeeAddress,
	}
	
	#endregion AddressChildEntityTypes
	
	#region AddressFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressFilterBuilder : SqlFilterBuilder<AddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressFilterBuilder class.
		/// </summary>
		public AddressFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressFilterBuilder
	
	#region AddressParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressParameterBuilder : ParameterizedSqlFilterBuilder<AddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressParameterBuilder class.
		/// </summary>
		public AddressParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressParameterBuilder
	
	#region AddressSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AddressSortBuilder : SqlSortBuilder<AddressColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressSqlSortBuilder class.
		/// </summary>
		public AddressSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AddressSortBuilder
	
} // end namespace
