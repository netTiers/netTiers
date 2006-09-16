using System;
using System.ComponentModel;

using NTiers.Sample.NorthWind.DataAccessLayer;
using NTiers.Sample.NorthWind.DataAccessLayer.SqlClient;

namespace NTiers.Sample.NorthWind.ConsoleUI
{
	class Program
	{
		/// <summary>
		[STAThread]
		static void Main(string[] args)
		{
			string connectionString = "Server=w1841;Database=NorthWind;User ID=sa;Password=celine;Trusted_Connection=False";

			/* Sample 1 */
			EmployeeCollection employees = EmployeeRepository.GetAll("Server=w1841;Database=NorthWind;User ID=sa;Password=celine;Trusted_Connection=False");
			employees.Sort(EmployeeColumns.LastName, ListSortDirection.Ascending);
			foreach(Employee employee in employees)
			{
				Console.WriteLine("{1} {0}", employee.FirstName, employee.LastName);
			}
			

			/* Sample 2 
			// Create a new record and save
			Employee employee = new Employee();
			employee.FirstName = "John";
			employee.LastName = "Doe";
			employee.BirthDate = DateTime.Now;
			employee.Address = "10 , fake street";
			employee.City = "Metroplolis";
			employee.Country = "USA";
			employee.HireDate = DateTime.Now;
			employee.HomePhone = "0123456789";
			employee.Notes = "This is a fake employee";
			employee.Title = "M";
			employee.TitleOfCourtesy = "Dear";
			employee.PostalCode = "5556";
			employee.Region = "New-York";
			
			EmployeeRepository.Save(connectionString, employee);
			*/

			/* Sample 3
			// Select by Index and Update
			EmployeeCollection employees = EmployeeRepository.GetByLastName(connectionString, "Doe");
			if (employees.Count == 1)
			{
				employees[0].Notes = "This is a modified fake employee";
				EmployeeRepository.Save(connectionString, employees[0]);
				Console.Write(employees[0]);
			}
			*/

			/* Sample 4
			// Select by primary key and Delete (Demonstrate that insert, update, delete methods can also take collection as parameter)
			EmployeeCollection employees = EmployeeRepository.GetByEmployeeID(connectionString, 13);
			EmployeeRepository.Delete(connectionString, employees);
			*/

			/* Sample
			// The SqlClient can work with transactions.
			// Also show the Save method, wich encapsulate the use of Insert, Update and Delete methods.
			TransactionManager transaction = new TransactionManager(connectionString); 
			transaction.BeginTransaction(); 
			try
			{ 
				// Insert
				Employee employee = new Employee();
				employee.FirstName = "John";
				employee.LastName = "Doe";
				employee.BirthDate = DateTime.Now;
				employee.Address = "10 , fake street";
				employee.City = "Metroplolis";
				employee.Country = "USA";
				employee.HireDate = DateTime.Now;
				employee.HomePhone = "0123456789";
				employee.Notes = "This is a fake employee";
				employee.Title = "M";
				employee.TitleOfCourtesy = "Dear";
				employee.PostalCode = "5556";
				employee.Region = "New-York";

				EmployeeRepository.Save(transaction, employee); 

				// Update
				employee.Notes = "This is a modified fake employee";
				EmployeeRepository.Save(transaction, employee); 

				transaction.Commit();
				Console.WriteLine("ok");
			} 
			catch(Exception)
			{
				transaction.Rollback();
				Console.WriteLine("nok");
			}
			*/
		}
	}
}
