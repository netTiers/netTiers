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
	/// This class is the base class for any <see cref="EmployeeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmployeeProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Employee, Nettiers.AdventureWorks.Entities.EmployeeKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByAddressIdFromEmployeeAddress
		
		/// <summary>
		///		Gets Employee objects from the datasource by AddressID in the
		///		EmployeeAddress table. Table Employee is related to table Address
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Employee objects.</returns>
		public TList<Employee> GetByAddressIdFromEmployeeAddress(System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressIdFromEmployeeAddress(null,_addressId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Employee objects from the datasource by AddressID in the
		///		EmployeeAddress table. Table Employee is related to table Address
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Employee objects.</returns>
		public TList<Employee> GetByAddressIdFromEmployeeAddress(System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressIdFromEmployeeAddress(null, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Employee objects from the datasource by AddressID in the
		///		EmployeeAddress table. Table Employee is related to table Address
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Employee objects.</returns>
		public TList<Employee> GetByAddressIdFromEmployeeAddress(TransactionManager transactionManager, System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressIdFromEmployeeAddress(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Employee objects from the datasource by AddressID in the
		///		EmployeeAddress table. Table Employee is related to table Address
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Employee objects.</returns>
		public TList<Employee> GetByAddressIdFromEmployeeAddress(TransactionManager transactionManager, System.Int32 _addressId,int start, int pageLength)
		{
			int count = -1;
			return GetByAddressIdFromEmployeeAddress(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Employee objects from the datasource by AddressID in the
		///		EmployeeAddress table. Table Employee is related to table Address
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Employee objects.</returns>
		public TList<Employee> GetByAddressIdFromEmployeeAddress(System.Int32 _addressId,int start, int pageLength, out int count)
		{
			
			return GetByAddressIdFromEmployeeAddress(null, _addressId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Employee objects from the datasource by AddressID in the
		///		EmployeeAddress table. Table Employee is related to table Address
		///		through the (M:N) relationship defined in the EmployeeAddress table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_addressId">Primary key. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Employee objects.</returns>
		public abstract TList<Employee> GetByAddressIdFromEmployeeAddress(TransactionManager transactionManager,System.Int32 _addressId, int start, int pageLength, out int count);
		
		#endregion GetByAddressIdFromEmployeeAddress
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeKey key)
		{
			return Delete(transactionManager, key.EmployeeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_employeeId">Primary key for Employee records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _employeeId)
		{
			return Delete(null, _employeeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key for Employee records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _employeeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employee_Contact_ContactID key.
		///		FK_Employee_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="_contactId">Identifies the employee in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Employee objects.</returns>
		public TList<Employee> GetByContactId(System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(_contactId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employee_Contact_ContactID key.
		///		FK_Employee_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Identifies the employee in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Employee objects.</returns>
		/// <remarks></remarks>
		public TList<Employee> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employee_Contact_ContactID key.
		///		FK_Employee_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Identifies the employee in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Employee objects.</returns>
		public TList<Employee> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employee_Contact_ContactID key.
		///		fkEmployeeContactContactId Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Identifies the employee in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Employee objects.</returns>
		public TList<Employee> GetByContactId(System.Int32 _contactId, int start, int pageLength)
		{
			int count =  -1;
			return GetByContactId(null, _contactId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employee_Contact_ContactID key.
		///		fkEmployeeContactContactId Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Identifies the employee in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Employee objects.</returns>
		public TList<Employee> GetByContactId(System.Int32 _contactId, int start, int pageLength,out int count)
		{
			return GetByContactId(null, _contactId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employee_Contact_ContactID key.
		///		FK_Employee_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Identifies the employee in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Employee objects.</returns>
		public abstract TList<Employee> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.Employee Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeKey key, int start, int pageLength)
		{
			return GetByEmployeeId(transactionManager, key.EmployeeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Employee_LoginID index.
		/// </summary>
		/// <param name="_loginId">Network login.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByLoginId(System.String _loginId)
		{
			int count = -1;
			return GetByLoginId(null,_loginId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_LoginID index.
		/// </summary>
		/// <param name="_loginId">Network login.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByLoginId(System.String _loginId, int start, int pageLength)
		{
			int count = -1;
			return GetByLoginId(null, _loginId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_LoginID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_loginId">Network login.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByLoginId(TransactionManager transactionManager, System.String _loginId)
		{
			int count = -1;
			return GetByLoginId(transactionManager, _loginId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_LoginID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_loginId">Network login.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByLoginId(TransactionManager transactionManager, System.String _loginId, int start, int pageLength)
		{
			int count = -1;
			return GetByLoginId(transactionManager, _loginId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_LoginID index.
		/// </summary>
		/// <param name="_loginId">Network login.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByLoginId(System.String _loginId, int start, int pageLength, out int count)
		{
			return GetByLoginId(null, _loginId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_LoginID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_loginId">Network login.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Employee GetByLoginId(TransactionManager transactionManager, System.String _loginId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Employee_NationalIDNumber index.
		/// </summary>
		/// <param name="_nationalIdNumber">Unique national identification number such as a social security number.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByNationalIdNumber(System.String _nationalIdNumber)
		{
			int count = -1;
			return GetByNationalIdNumber(null,_nationalIdNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_NationalIDNumber index.
		/// </summary>
		/// <param name="_nationalIdNumber">Unique national identification number such as a social security number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByNationalIdNumber(System.String _nationalIdNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByNationalIdNumber(null, _nationalIdNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_NationalIDNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nationalIdNumber">Unique national identification number such as a social security number.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByNationalIdNumber(TransactionManager transactionManager, System.String _nationalIdNumber)
		{
			int count = -1;
			return GetByNationalIdNumber(transactionManager, _nationalIdNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_NationalIDNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nationalIdNumber">Unique national identification number such as a social security number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByNationalIdNumber(TransactionManager transactionManager, System.String _nationalIdNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByNationalIdNumber(transactionManager, _nationalIdNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_NationalIDNumber index.
		/// </summary>
		/// <param name="_nationalIdNumber">Unique national identification number such as a social security number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByNationalIdNumber(System.String _nationalIdNumber, int start, int pageLength, out int count)
		{
			return GetByNationalIdNumber(null, _nationalIdNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_NationalIDNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_nationalIdNumber">Unique national identification number such as a social security number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Employee GetByNationalIdNumber(TransactionManager transactionManager, System.String _nationalIdNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Employee_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Employee_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Employee GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Employee_ManagerID index.
		/// </summary>
		/// <param name="_managerId">Manager to whom the employee is assigned. Foreign Key to Employee.M</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employee&gt;"/> class.</returns>
		public TList<Employee> GetByManagerId(System.Int32? _managerId)
		{
			int count = -1;
			return GetByManagerId(null,_managerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee_ManagerID index.
		/// </summary>
		/// <param name="_managerId">Manager to whom the employee is assigned. Foreign Key to Employee.M</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employee&gt;"/> class.</returns>
		public TList<Employee> GetByManagerId(System.Int32? _managerId, int start, int pageLength)
		{
			int count = -1;
			return GetByManagerId(null, _managerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee_ManagerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_managerId">Manager to whom the employee is assigned. Foreign Key to Employee.M</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employee&gt;"/> class.</returns>
		public TList<Employee> GetByManagerId(TransactionManager transactionManager, System.Int32? _managerId)
		{
			int count = -1;
			return GetByManagerId(transactionManager, _managerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee_ManagerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_managerId">Manager to whom the employee is assigned. Foreign Key to Employee.M</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employee&gt;"/> class.</returns>
		public TList<Employee> GetByManagerId(TransactionManager transactionManager, System.Int32? _managerId, int start, int pageLength)
		{
			int count = -1;
			return GetByManagerId(transactionManager, _managerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee_ManagerID index.
		/// </summary>
		/// <param name="_managerId">Manager to whom the employee is assigned. Foreign Key to Employee.M</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employee&gt;"/> class.</returns>
		public TList<Employee> GetByManagerId(System.Int32? _managerId, int start, int pageLength, out int count)
		{
			return GetByManagerId(null, _managerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee_ManagerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_managerId">Manager to whom the employee is assigned. Foreign Key to Employee.M</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employee&gt;"/> class.</returns>
		public abstract TList<Employee> GetByManagerId(TransactionManager transactionManager, System.Int32? _managerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Employee_EmployeeID index.
		/// </summary>
		/// <param name="_employeeId">Primary key for Employee records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByEmployeeId(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(null,_employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_EmployeeID index.
		/// </summary>
		/// <param name="_employeeId">Primary key for Employee records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key for Employee records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key for Employee records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_EmployeeID index.
		/// </summary>
		/// <param name="_employeeId">Primary key for Employee records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Employee GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength, out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Primary key for Employee records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Employee GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Employee&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Employee&gt;"/></returns>
		public static TList<Employee> Fill(IDataReader reader, TList<Employee> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Employee c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Employee")
					.Append("|").Append((System.Int32)reader[((int)EmployeeColumn.EmployeeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Employee>(
					key.ToString(), // EntityTrackingKey
					"Employee",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Employee();
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
					c.EmployeeId = (System.Int32)reader[((int)EmployeeColumn.EmployeeId - 1)];
					c.NationalIdNumber = (System.String)reader[((int)EmployeeColumn.NationalIdNumber - 1)];
					c.ContactId = (System.Int32)reader[((int)EmployeeColumn.ContactId - 1)];
					c.LoginId = (System.String)reader[((int)EmployeeColumn.LoginId - 1)];
					c.ManagerId = (reader.IsDBNull(((int)EmployeeColumn.ManagerId - 1)))?null:(System.Int32?)reader[((int)EmployeeColumn.ManagerId - 1)];
					c.Title = (System.String)reader[((int)EmployeeColumn.Title - 1)];
					c.BirthDate = (System.DateTime)reader[((int)EmployeeColumn.BirthDate - 1)];
					c.MaritalStatus = (System.String)reader[((int)EmployeeColumn.MaritalStatus - 1)];
					c.Gender = (System.String)reader[((int)EmployeeColumn.Gender - 1)];
					c.HireDate = (System.DateTime)reader[((int)EmployeeColumn.HireDate - 1)];
					c.SalariedFlag = (System.Boolean)reader[((int)EmployeeColumn.SalariedFlag - 1)];
					c.VacationHours = (System.Int16)reader[((int)EmployeeColumn.VacationHours - 1)];
					c.SickLeaveHours = (System.Int16)reader[((int)EmployeeColumn.SickLeaveHours - 1)];
					c.CurrentFlag = (System.Boolean)reader[((int)EmployeeColumn.CurrentFlag - 1)];
					c.Rowguid = (System.Guid)reader[((int)EmployeeColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)EmployeeColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Employee"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Employee entity)
		{
			if (!reader.Read()) return;
			
			entity.EmployeeId = (System.Int32)reader[((int)EmployeeColumn.EmployeeId - 1)];
			entity.NationalIdNumber = (System.String)reader[((int)EmployeeColumn.NationalIdNumber - 1)];
			entity.ContactId = (System.Int32)reader[((int)EmployeeColumn.ContactId - 1)];
			entity.LoginId = (System.String)reader[((int)EmployeeColumn.LoginId - 1)];
			entity.ManagerId = (reader.IsDBNull(((int)EmployeeColumn.ManagerId - 1)))?null:(System.Int32?)reader[((int)EmployeeColumn.ManagerId - 1)];
			entity.Title = (System.String)reader[((int)EmployeeColumn.Title - 1)];
			entity.BirthDate = (System.DateTime)reader[((int)EmployeeColumn.BirthDate - 1)];
			entity.MaritalStatus = (System.String)reader[((int)EmployeeColumn.MaritalStatus - 1)];
			entity.Gender = (System.String)reader[((int)EmployeeColumn.Gender - 1)];
			entity.HireDate = (System.DateTime)reader[((int)EmployeeColumn.HireDate - 1)];
			entity.SalariedFlag = (System.Boolean)reader[((int)EmployeeColumn.SalariedFlag - 1)];
			entity.VacationHours = (System.Int16)reader[((int)EmployeeColumn.VacationHours - 1)];
			entity.SickLeaveHours = (System.Int16)reader[((int)EmployeeColumn.SickLeaveHours - 1)];
			entity.CurrentFlag = (System.Boolean)reader[((int)EmployeeColumn.CurrentFlag - 1)];
			entity.Rowguid = (System.Guid)reader[((int)EmployeeColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)EmployeeColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Employee"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Employee"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Employee entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeId = (System.Int32)dataRow["EmployeeID"];
			entity.NationalIdNumber = (System.String)dataRow["NationalIDNumber"];
			entity.ContactId = (System.Int32)dataRow["ContactID"];
			entity.LoginId = (System.String)dataRow["LoginID"];
			entity.ManagerId = Convert.IsDBNull(dataRow["ManagerID"]) ? null : (System.Int32?)dataRow["ManagerID"];
			entity.Title = (System.String)dataRow["Title"];
			entity.BirthDate = (System.DateTime)dataRow["BirthDate"];
			entity.MaritalStatus = (System.String)dataRow["MaritalStatus"];
			entity.Gender = (System.String)dataRow["Gender"];
			entity.HireDate = (System.DateTime)dataRow["HireDate"];
			entity.SalariedFlag = (System.Boolean)dataRow["SalariedFlag"];
			entity.VacationHours = (System.Int16)dataRow["VacationHours"];
			entity.SickLeaveHours = (System.Int16)dataRow["SickLeaveHours"];
			entity.CurrentFlag = (System.Boolean)dataRow["CurrentFlag"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Employee"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Employee Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Employee entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region ManagerIdSource	
			if (CanDeepLoad(entity, "Employee|ManagerIdSource", deepLoadType, innerList) 
				&& entity.ManagerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ManagerId ?? (int)0);
				Employee tmpEntity = EntityManager.LocateEntity<Employee>(EntityLocator.ConstructKeyFromPkItems(typeof(Employee), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ManagerIdSource = tmpEntity;
				else
					entity.ManagerIdSource = DataRepository.EmployeeProvider.GetByEmployeeId(transactionManager, (entity.ManagerId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ManagerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ManagerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmployeeProvider.DeepLoad(transactionManager, entity.ManagerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ManagerIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByEmployeeId methods when available
			
			#region EmployeeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Employee>|EmployeeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeCollection = DataRepository.EmployeeProvider.GetByManagerId(transactionManager, entity.EmployeeId);

				if (deep && entity.EmployeeCollection.Count > 0)
				{
					deepHandles.Add("EmployeeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Employee>) DataRepository.EmployeeProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobCandidateCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobCandidate>|JobCandidateCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobCandidateCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobCandidateCollection = DataRepository.JobCandidateProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.JobCandidateCollection.Count > 0)
				{
					deepHandles.Add("JobCandidateCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobCandidate>) DataRepository.JobCandidateProvider.DeepLoad,
						new object[] { transactionManager, entity.JobCandidateCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesPerson
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "SalesPerson|SalesPerson", deepLoadType, innerList))
			{
				entity.SalesPerson = DataRepository.SalesPersonProvider.GetBySalesPersonId(transactionManager, entity.EmployeeId);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPerson' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.SalesPerson != null)
				{
					deepHandles.Add("SalesPerson",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< SalesPerson >) DataRepository.SalesPersonProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesPerson, deep, deepLoadType, childTypes, innerList }
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

				entity.EmployeeAddressCollection = DataRepository.EmployeeAddressProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.EmployeeAddressCollection.Count > 0)
				{
					deepHandles.Add("EmployeeAddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeAddress>) DataRepository.EmployeeAddressProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeAddressCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmployeePayHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeePayHistory>|EmployeePayHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeePayHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeePayHistoryCollection = DataRepository.EmployeePayHistoryProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.EmployeePayHistoryCollection.Count > 0)
				{
					deepHandles.Add("EmployeePayHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeePayHistory>) DataRepository.EmployeePayHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeePayHistoryCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.PurchaseOrderHeaderCollection = DataRepository.PurchaseOrderHeaderProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.PurchaseOrderHeaderCollection.Count > 0)
				{
					deepHandles.Add("PurchaseOrderHeaderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PurchaseOrderHeader>) DataRepository.PurchaseOrderHeaderProvider.DeepLoad,
						new object[] { transactionManager, entity.PurchaseOrderHeaderCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AddressIdAddressCollection_From_EmployeeAddress
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Address>|AddressIdAddressCollection_From_EmployeeAddress", deepLoadType, innerList))
			{
				entity.AddressIdAddressCollection_From_EmployeeAddress = DataRepository.AddressProvider.GetByEmployeeIdFromEmployeeAddress(transactionManager, entity.EmployeeId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AddressIdAddressCollection_From_EmployeeAddress' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AddressIdAddressCollection_From_EmployeeAddress != null)
				{
					deepHandles.Add("AddressIdAddressCollection_From_EmployeeAddress",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Address >) DataRepository.AddressProvider.DeepLoad,
						new object[] { transactionManager, entity.AddressIdAddressCollection_From_EmployeeAddress, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region EmployeeDepartmentHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeDepartmentHistory>|EmployeeDepartmentHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeDepartmentHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeDepartmentHistoryCollection = DataRepository.EmployeeDepartmentHistoryProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.EmployeeDepartmentHistoryCollection.Count > 0)
				{
					deepHandles.Add("EmployeeDepartmentHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeDepartmentHistory>) DataRepository.EmployeeDepartmentHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeDepartmentHistoryCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Employee object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Employee instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Employee Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Employee entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region ManagerIdSource
			if (CanDeepSave(entity, "Employee|ManagerIdSource", deepSaveType, innerList) 
				&& entity.ManagerIdSource != null)
			{
				DataRepository.EmployeeProvider.Save(transactionManager, entity.ManagerIdSource);
				entity.ManagerId = entity.ManagerIdSource.EmployeeId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region SalesPerson
			if (CanDeepSave(entity.SalesPerson, "SalesPerson|SalesPerson", deepSaveType, innerList))
			{

				if (entity.SalesPerson != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.SalesPerson.SalesPersonId = entity.EmployeeId;
					//DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesPerson);
					deepHandles.Add("SalesPerson",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< SalesPerson >) DataRepository.SalesPersonProvider.DeepSave,
						new object[] { transactionManager, entity.SalesPerson, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 

			#region AddressIdAddressCollection_From_EmployeeAddress>
			if (CanDeepSave(entity.AddressIdAddressCollection_From_EmployeeAddress, "List<Address>|AddressIdAddressCollection_From_EmployeeAddress", deepSaveType, innerList))
			{
				if (entity.AddressIdAddressCollection_From_EmployeeAddress.Count > 0 || entity.AddressIdAddressCollection_From_EmployeeAddress.DeletedItems.Count > 0)
				{
					DataRepository.AddressProvider.Save(transactionManager, entity.AddressIdAddressCollection_From_EmployeeAddress); 
					deepHandles.Add("AddressIdAddressCollection_From_EmployeeAddress",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Address>) DataRepository.AddressProvider.DeepSave,
						new object[] { transactionManager, entity.AddressIdAddressCollection_From_EmployeeAddress, deepSaveType, childTypes, innerList }
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
						if(child.ManagerIdSource != null)
						{
							child.ManagerId = child.ManagerIdSource.EmployeeId;
						}
						else
						{
							child.ManagerId = entity.EmployeeId;
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
				
	
			#region List<JobCandidate>
				if (CanDeepSave(entity.JobCandidateCollection, "List<JobCandidate>|JobCandidateCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobCandidate child in entity.JobCandidateCollection)
					{
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
						}

					}

					if (entity.JobCandidateCollection.Count > 0 || entity.JobCandidateCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobCandidateProvider.Save(transactionManager, entity.JobCandidateCollection);
						
						deepHandles.Add("JobCandidateCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobCandidate >) DataRepository.JobCandidateProvider.DeepSave,
							new object[] { transactionManager, entity.JobCandidateCollection, deepSaveType, childTypes, innerList }
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
						if(child.EmployeeIdSource != null)
						{
								child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}

						if(child.AddressIdSource != null)
						{
								child.AddressId = child.AddressIdSource.AddressId;
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
				
	
			#region List<EmployeePayHistory>
				if (CanDeepSave(entity.EmployeePayHistoryCollection, "List<EmployeePayHistory>|EmployeePayHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmployeePayHistory child in entity.EmployeePayHistoryCollection)
					{
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
						}

					}

					if (entity.EmployeePayHistoryCollection.Count > 0 || entity.EmployeePayHistoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeePayHistoryProvider.Save(transactionManager, entity.EmployeePayHistoryCollection);
						
						deepHandles.Add("EmployeePayHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmployeePayHistory >) DataRepository.EmployeePayHistoryProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeePayHistoryCollection, deepSaveType, childTypes, innerList }
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
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
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
				
	
			#region List<EmployeeDepartmentHistory>
				if (CanDeepSave(entity.EmployeeDepartmentHistoryCollection, "List<EmployeeDepartmentHistory>|EmployeeDepartmentHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmployeeDepartmentHistory child in entity.EmployeeDepartmentHistoryCollection)
					{
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
						}

					}

					if (entity.EmployeeDepartmentHistoryCollection.Count > 0 || entity.EmployeeDepartmentHistoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeeDepartmentHistoryProvider.Save(transactionManager, entity.EmployeeDepartmentHistoryCollection);
						
						deepHandles.Add("EmployeeDepartmentHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmployeeDepartmentHistory >) DataRepository.EmployeeDepartmentHistoryProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeeDepartmentHistoryCollection, deepSaveType, childTypes, innerList }
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
	
	#region EmployeeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Employee</c>
	///</summary>
	public enum EmployeeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Contact</c> at ContactIdSource
		///</summary>
		[ChildEntityType(typeof(Contact))]
		Contact,
			
		///<summary>
		/// Composite Property for <c>Employee</c> at ManagerIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
	
		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for EmployeeCollection
		///</summary>
		[ChildEntityType(typeof(TList<Employee>))]
		EmployeeCollection,

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for JobCandidateCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobCandidate>))]
		JobCandidateCollection,
		///<summary>
		/// Entity <c>SalesPerson</c> as OneToOne for SalesPerson
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for EmployeeAddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeAddress>))]
		EmployeeAddressCollection,

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for EmployeePayHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeePayHistory>))]
		EmployeePayHistoryCollection,

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for PurchaseOrderHeaderCollection
		///</summary>
		[ChildEntityType(typeof(TList<PurchaseOrderHeader>))]
		PurchaseOrderHeaderCollection,

		///<summary>
		/// Collection of <c>Employee</c> as ManyToMany for AddressCollection_From_EmployeeAddress
		///</summary>
		[ChildEntityType(typeof(TList<Address>))]
		AddressIdAddressCollection_From_EmployeeAddress,

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for EmployeeDepartmentHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeDepartmentHistory>))]
		EmployeeDepartmentHistoryCollection,
	}
	
	#endregion EmployeeChildEntityTypes
	
	#region EmployeeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmployeeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeFilterBuilder : SqlFilterBuilder<EmployeeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeFilterBuilder class.
		/// </summary>
		public EmployeeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeFilterBuilder
	
	#region EmployeeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmployeeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeParameterBuilder : ParameterizedSqlFilterBuilder<EmployeeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeParameterBuilder class.
		/// </summary>
		public EmployeeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeParameterBuilder
	
	#region EmployeeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmployeeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmployeeSortBuilder : SqlSortBuilder<EmployeeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSqlSortBuilder class.
		/// </summary>
		public EmployeeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmployeeSortBuilder
	
} // end namespace
