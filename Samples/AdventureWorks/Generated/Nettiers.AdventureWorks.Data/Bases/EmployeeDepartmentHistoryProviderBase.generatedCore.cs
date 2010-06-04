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
	/// This class is the base class for any <see cref="EmployeeDepartmentHistoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmployeeDepartmentHistoryProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory, Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistoryKey>
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
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistoryKey key)
		{
			return Delete(transactionManager, key.EmployeeId, key.StartDate, key.DepartmentId, key.ShiftId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.. Primary Key.</param>
		/// <param name="_startDate">Date the employee started work in the department.. Primary Key.</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.. Primary Key.</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _employeeId, System.DateTime _startDate, System.Int16 _departmentId, System.Byte _shiftId)
		{
			return Delete(null, _employeeId, _startDate, _departmentId, _shiftId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.. Primary Key.</param>
		/// <param name="_startDate">Date the employee started work in the department.. Primary Key.</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.. Primary Key.</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _employeeId, System.DateTime _startDate, System.Int16 _departmentId, System.Byte _shiftId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartmentHistory_Employee_EmployeeID key.
		///		FK_EmployeeDepartmentHistory_Employee_EmployeeID Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory objects.</returns>
		public TList<EmployeeDepartmentHistory> GetByEmployeeId(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(_employeeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartmentHistory_Employee_EmployeeID key.
		///		FK_EmployeeDepartmentHistory_Employee_EmployeeID Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeDepartmentHistory> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartmentHistory_Employee_EmployeeID key.
		///		FK_EmployeeDepartmentHistory_Employee_EmployeeID Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory objects.</returns>
		public TList<EmployeeDepartmentHistory> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartmentHistory_Employee_EmployeeID key.
		///		fkEmployeeDepartmentHistoryEmployeeEmployeeId Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory objects.</returns>
		public TList<EmployeeDepartmentHistory> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartmentHistory_Employee_EmployeeID key.
		///		fkEmployeeDepartmentHistoryEmployeeEmployeeId Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory objects.</returns>
		public TList<EmployeeDepartmentHistory> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength,out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartmentHistory_Employee_EmployeeID key.
		///		FK_EmployeeDepartmentHistory_Employee_EmployeeID Description: Foreign key constraint referencing Employee.EmployeeID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory objects.</returns>
		public abstract TList<EmployeeDepartmentHistory> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistoryKey key, int start, int pageLength)
		{
			return GetByEmployeeIdStartDateDepartmentIdShiftId(transactionManager, key.EmployeeId, key.StartDate, key.DepartmentId, key.ShiftId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_EmployeeDepartmentHistory_DepartmentID index.
		/// </summary>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByDepartmentId(System.Int16 _departmentId)
		{
			int count = -1;
			return GetByDepartmentId(null,_departmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_DepartmentID index.
		/// </summary>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByDepartmentId(System.Int16 _departmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentId(null, _departmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByDepartmentId(TransactionManager transactionManager, System.Int16 _departmentId)
		{
			int count = -1;
			return GetByDepartmentId(transactionManager, _departmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByDepartmentId(TransactionManager transactionManager, System.Int16 _departmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentId(transactionManager, _departmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_DepartmentID index.
		/// </summary>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByDepartmentId(System.Int16 _departmentId, int start, int pageLength, out int count)
		{
			return GetByDepartmentId(null, _departmentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public abstract TList<EmployeeDepartmentHistory> GetByDepartmentId(TransactionManager transactionManager, System.Int16 _departmentId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_EmployeeDepartmentHistory_ShiftID index.
		/// </summary>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByShiftId(System.Byte _shiftId)
		{
			int count = -1;
			return GetByShiftId(null,_shiftId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_ShiftID index.
		/// </summary>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByShiftId(System.Byte _shiftId, int start, int pageLength)
		{
			int count = -1;
			return GetByShiftId(null, _shiftId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_ShiftID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByShiftId(TransactionManager transactionManager, System.Byte _shiftId)
		{
			int count = -1;
			return GetByShiftId(transactionManager, _shiftId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_ShiftID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByShiftId(TransactionManager transactionManager, System.Byte _shiftId, int start, int pageLength)
		{
			int count = -1;
			return GetByShiftId(transactionManager, _shiftId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_ShiftID index.
		/// </summary>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public TList<EmployeeDepartmentHistory> GetByShiftId(System.Byte _shiftId, int start, int pageLength, out int count)
		{
			return GetByShiftId(null, _shiftId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmployeeDepartmentHistory_ShiftID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/> class.</returns>
		public abstract TList<EmployeeDepartmentHistory> GetByShiftId(TransactionManager transactionManager, System.Byte _shiftId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_EmployeeDepartmentHistory_EmployeeID_StartDate_DepartmentID index.
		/// </summary>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_startDate">Date the employee started work in the department.</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory GetByEmployeeIdStartDateDepartmentIdShiftId(System.Int32 _employeeId, System.DateTime _startDate, System.Int16 _departmentId, System.Byte _shiftId)
		{
			int count = -1;
			return GetByEmployeeIdStartDateDepartmentIdShiftId(null,_employeeId, _startDate, _departmentId, _shiftId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartmentHistory_EmployeeID_StartDate_DepartmentID index.
		/// </summary>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_startDate">Date the employee started work in the department.</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory GetByEmployeeIdStartDateDepartmentIdShiftId(System.Int32 _employeeId, System.DateTime _startDate, System.Int16 _departmentId, System.Byte _shiftId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdStartDateDepartmentIdShiftId(null, _employeeId, _startDate, _departmentId, _shiftId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartmentHistory_EmployeeID_StartDate_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_startDate">Date the employee started work in the department.</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory GetByEmployeeIdStartDateDepartmentIdShiftId(TransactionManager transactionManager, System.Int32 _employeeId, System.DateTime _startDate, System.Int16 _departmentId, System.Byte _shiftId)
		{
			int count = -1;
			return GetByEmployeeIdStartDateDepartmentIdShiftId(transactionManager, _employeeId, _startDate, _departmentId, _shiftId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartmentHistory_EmployeeID_StartDate_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_startDate">Date the employee started work in the department.</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory GetByEmployeeIdStartDateDepartmentIdShiftId(TransactionManager transactionManager, System.Int32 _employeeId, System.DateTime _startDate, System.Int16 _departmentId, System.Byte _shiftId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdStartDateDepartmentIdShiftId(transactionManager, _employeeId, _startDate, _departmentId, _shiftId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartmentHistory_EmployeeID_StartDate_DepartmentID index.
		/// </summary>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_startDate">Date the employee started work in the department.</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory GetByEmployeeIdStartDateDepartmentIdShiftId(System.Int32 _employeeId, System.DateTime _startDate, System.Int16 _departmentId, System.Byte _shiftId, int start, int pageLength, out int count)
		{
			return GetByEmployeeIdStartDateDepartmentIdShiftId(null, _employeeId, _startDate, _departmentId, _shiftId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartmentHistory_EmployeeID_StartDate_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">Employee identification number. Foreign key to Employee.EmployeeID.</param>
		/// <param name="_startDate">Date the employee started work in the department.</param>
		/// <param name="_departmentId">Department in which the employee worked including currently. Foreign key to Department.DepartmentID.</param>
		/// <param name="_shiftId">Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory GetByEmployeeIdStartDateDepartmentIdShiftId(TransactionManager transactionManager, System.Int32 _employeeId, System.DateTime _startDate, System.Int16 _departmentId, System.Byte _shiftId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;EmployeeDepartmentHistory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;EmployeeDepartmentHistory&gt;"/></returns>
		public static TList<EmployeeDepartmentHistory> Fill(IDataReader reader, TList<EmployeeDepartmentHistory> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EmployeeDepartmentHistory")
					.Append("|").Append((System.Int32)reader[((int)EmployeeDepartmentHistoryColumn.EmployeeId - 1)])
					.Append("|").Append((System.Int16)reader[((int)EmployeeDepartmentHistoryColumn.DepartmentId - 1)])
					.Append("|").Append((System.Byte)reader[((int)EmployeeDepartmentHistoryColumn.ShiftId - 1)])
					.Append("|").Append((System.DateTime)reader[((int)EmployeeDepartmentHistoryColumn.StartDate - 1)]).ToString();
					c = EntityManager.LocateOrCreate<EmployeeDepartmentHistory>(
					key.ToString(), // EntityTrackingKey
					"EmployeeDepartmentHistory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory();
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
					c.EmployeeId = (System.Int32)reader[((int)EmployeeDepartmentHistoryColumn.EmployeeId - 1)];
					c.OriginalEmployeeId = c.EmployeeId;
					c.DepartmentId = (System.Int16)reader[((int)EmployeeDepartmentHistoryColumn.DepartmentId - 1)];
					c.OriginalDepartmentId = c.DepartmentId;
					c.ShiftId = (System.Byte)reader[((int)EmployeeDepartmentHistoryColumn.ShiftId - 1)];
					c.OriginalShiftId = c.ShiftId;
					c.StartDate = (System.DateTime)reader[((int)EmployeeDepartmentHistoryColumn.StartDate - 1)];
					c.OriginalStartDate = c.StartDate;
					c.EndDate = (reader.IsDBNull(((int)EmployeeDepartmentHistoryColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)EmployeeDepartmentHistoryColumn.EndDate - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)EmployeeDepartmentHistoryColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory entity)
		{
			if (!reader.Read()) return;
			
			entity.EmployeeId = (System.Int32)reader[((int)EmployeeDepartmentHistoryColumn.EmployeeId - 1)];
			entity.OriginalEmployeeId = (System.Int32)reader["EmployeeID"];
			entity.DepartmentId = (System.Int16)reader[((int)EmployeeDepartmentHistoryColumn.DepartmentId - 1)];
			entity.OriginalDepartmentId = (System.Int16)reader["DepartmentID"];
			entity.ShiftId = (System.Byte)reader[((int)EmployeeDepartmentHistoryColumn.ShiftId - 1)];
			entity.OriginalShiftId = (System.Byte)reader["ShiftID"];
			entity.StartDate = (System.DateTime)reader[((int)EmployeeDepartmentHistoryColumn.StartDate - 1)];
			entity.OriginalStartDate = (System.DateTime)reader["StartDate"];
			entity.EndDate = (reader.IsDBNull(((int)EmployeeDepartmentHistoryColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)EmployeeDepartmentHistoryColumn.EndDate - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)EmployeeDepartmentHistoryColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeId = (System.Int32)dataRow["EmployeeID"];
			entity.OriginalEmployeeId = (System.Int32)dataRow["EmployeeID"];
			entity.DepartmentId = (System.Int16)dataRow["DepartmentID"];
			entity.OriginalDepartmentId = (System.Int16)dataRow["DepartmentID"];
			entity.ShiftId = (System.Byte)dataRow["ShiftID"];
			entity.OriginalShiftId = (System.Byte)dataRow["ShiftID"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.OriginalStartDate = (System.DateTime)dataRow["StartDate"];
			entity.EndDate = Convert.IsDBNull(dataRow["EndDate"]) ? null : (System.DateTime?)dataRow["EndDate"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DepartmentIdSource	
			if (CanDeepLoad(entity, "Department|DepartmentIdSource", deepLoadType, innerList) 
				&& entity.DepartmentIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DepartmentId;
				Department tmpEntity = EntityManager.LocateEntity<Department>(EntityLocator.ConstructKeyFromPkItems(typeof(Department), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DepartmentIdSource = tmpEntity;
				else
					entity.DepartmentIdSource = DataRepository.DepartmentProvider.GetByDepartmentId(transactionManager, entity.DepartmentId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DepartmentIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DepartmentIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DepartmentProvider.DeepLoad(transactionManager, entity.DepartmentIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DepartmentIdSource

			#region EmployeeIdSource	
			if (CanDeepLoad(entity, "Employee|EmployeeIdSource", deepLoadType, innerList) 
				&& entity.EmployeeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.EmployeeId;
				Employee tmpEntity = EntityManager.LocateEntity<Employee>(EntityLocator.ConstructKeyFromPkItems(typeof(Employee), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmployeeIdSource = tmpEntity;
				else
					entity.EmployeeIdSource = DataRepository.EmployeeProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmployeeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmployeeProvider.DeepLoad(transactionManager, entity.EmployeeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion EmployeeIdSource

			#region ShiftIdSource	
			if (CanDeepLoad(entity, "Shift|ShiftIdSource", deepLoadType, innerList) 
				&& entity.ShiftIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ShiftId;
				Shift tmpEntity = EntityManager.LocateEntity<Shift>(EntityLocator.ConstructKeyFromPkItems(typeof(Shift), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShiftIdSource = tmpEntity;
				else
					entity.ShiftIdSource = DataRepository.ShiftProvider.GetByShiftId(transactionManager, entity.ShiftId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ShiftIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ShiftIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ShiftProvider.DeepLoad(transactionManager, entity.ShiftIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ShiftIdSource
			
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
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DepartmentIdSource
			if (CanDeepSave(entity, "Department|DepartmentIdSource", deepSaveType, innerList) 
				&& entity.DepartmentIdSource != null)
			{
				DataRepository.DepartmentProvider.Save(transactionManager, entity.DepartmentIdSource);
				entity.DepartmentId = entity.DepartmentIdSource.DepartmentId;
			}
			#endregion 
			
			#region EmployeeIdSource
			if (CanDeepSave(entity, "Employee|EmployeeIdSource", deepSaveType, innerList) 
				&& entity.EmployeeIdSource != null)
			{
				DataRepository.EmployeeProvider.Save(transactionManager, entity.EmployeeIdSource);
				entity.EmployeeId = entity.EmployeeIdSource.EmployeeId;
			}
			#endregion 
			
			#region ShiftIdSource
			if (CanDeepSave(entity, "Shift|ShiftIdSource", deepSaveType, innerList) 
				&& entity.ShiftIdSource != null)
			{
				DataRepository.ShiftProvider.Save(transactionManager, entity.ShiftIdSource);
				entity.ShiftId = entity.ShiftIdSource.ShiftId;
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
	
	#region EmployeeDepartmentHistoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.EmployeeDepartmentHistory</c>
	///</summary>
	public enum EmployeeDepartmentHistoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Department</c> at DepartmentIdSource
		///</summary>
		[ChildEntityType(typeof(Department))]
		Department,
			
		///<summary>
		/// Composite Property for <c>Employee</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
			
		///<summary>
		/// Composite Property for <c>Shift</c> at ShiftIdSource
		///</summary>
		[ChildEntityType(typeof(Shift))]
		Shift,
		}
	
	#endregion EmployeeDepartmentHistoryChildEntityTypes
	
	#region EmployeeDepartmentHistoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmployeeDepartmentHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentHistoryFilterBuilder : SqlFilterBuilder<EmployeeDepartmentHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryFilterBuilder class.
		/// </summary>
		public EmployeeDepartmentHistoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeDepartmentHistoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeDepartmentHistoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeDepartmentHistoryFilterBuilder
	
	#region EmployeeDepartmentHistoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmployeeDepartmentHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentHistoryParameterBuilder : ParameterizedSqlFilterBuilder<EmployeeDepartmentHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryParameterBuilder class.
		/// </summary>
		public EmployeeDepartmentHistoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeDepartmentHistoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeDepartmentHistoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeDepartmentHistoryParameterBuilder
	
	#region EmployeeDepartmentHistorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmployeeDepartmentHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartmentHistory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmployeeDepartmentHistorySortBuilder : SqlSortBuilder<EmployeeDepartmentHistoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentHistorySqlSortBuilder class.
		/// </summary>
		public EmployeeDepartmentHistorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmployeeDepartmentHistorySortBuilder
	
} // end namespace
