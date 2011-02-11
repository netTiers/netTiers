﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file VEmployeeTest.cs instead.
*/
#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="VEmployee"/> objects (entity, collection and repository).
    /// </summary>
    public partial class VEmployeeTest
    {
    	// the VEmployee instance used to test the repository.
		private VEmployee mock;
		
		// the VList<VEmployee> instance used to test the repository.
		private VList<VEmployee> mockCollection;		

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static private void Init_Generated()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the VEmployee Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
        static private void CleanUp_Generated()
        {       	
			System.Console.WriteLine();
			System.Console.WriteLine();
        }
		
		/// <summary>
		/// Selects a page of VEmployee objects from the database.
		/// </summary>
		private void Step_1_SelectAll_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.VEmployeeProvider.GetPaged(null, 0, 10, out count);
			Assert.IsTrue(count >= 0, "Select Query Failed with GetPaged");
			System.Console.WriteLine("DataRepository.VEmployeeProvider.GetPaged():");			
			System.Console.WriteLine(mockCollection);			
		}
		
		/// <summary>
		/// Searches some VEmployee objects from the database.
		/// </summary>
		private void Step_2_Search_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.VEmployeeProvider.Find(null, null, "", 0, 10, out count);
			Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
			
			System.Console.WriteLine("DataRepository.VEmployeeProvider.Find():");			
			System.Console.WriteLine(mockCollection);
					
		}
		 //Find
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock VEmployee entity into a temporary file.
		/// </summary>
		private void Step_6_SerializeEntity_Generated()
		{
			string fileName = "temp_VEmployee.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VEmployee)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mock); 
			myWriter.Close();
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock VEmployee entity from a temporary file.
		/// </summary>
		private void Step_7_DeserializeEntity_Generated()
		{
			string fileName = "temp_VEmployee.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VEmployee)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			mock = (VEmployee) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a VEmployee collection into a temporary file.
		/// </summary>
		private void Step_8_SerializeCollection_Generated()
		{
			string fileName = "temp_VEmployeeCollection.xml";
		
			VList<VEmployee> mockCollection = new VList<VEmployee>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<VEmployee>)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("VList<VEmployee> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a VEmployee collection from a temporary file.
		/// </summary>
		private void Step_9_DeserializeCollection_Generated()
		{
			string fileName = "temp_VEmployeeCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<VEmployee>)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			VList<VEmployee> mockCollection = (VList<VEmployee>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("VList<VEmployee> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		#region Mock Instance
		///<summary>
		///  Returns a Typed VEmployee Entity with mock values.
		///</summary>
		static public VEmployee CreateMockInstance()
		{		
			VEmployee mock = new VEmployee();
						
			mock.EmployeeId = TestUtility.Instance.RandomNumber();
			mock.Title = TestUtility.Instance.RandomString(8, false);;
			mock.FirstName = TestUtility.Instance.RandomString(24, false);;
			mock.MiddleName = TestUtility.Instance.RandomString(24, false);;
			mock.LastName = TestUtility.Instance.RandomString(24, false);;
			mock.Suffix = TestUtility.Instance.RandomString(10, false);;
			mock.JobTitle = TestUtility.Instance.RandomString(24, false);;
			mock.Phone = TestUtility.Instance.RandomString(11, false);;
			mock.EmailAddress = TestUtility.Instance.RandomString(24, false);;
			mock.EmailPromotion = TestUtility.Instance.RandomNumber();
			mock.AddressLine1 = TestUtility.Instance.RandomString(29, false);;
			mock.AddressLine2 = TestUtility.Instance.RandomString(29, false);;
			mock.City = TestUtility.Instance.RandomString(14, false);;
			mock.StateProvinceName = TestUtility.Instance.RandomString(24, false);;
			mock.PostalCode = TestUtility.Instance.RandomString(6, false);;
			mock.CountryRegionName = TestUtility.Instance.RandomString(24, false);;
			mock.AdditionalContactInfo = "<test></test>";
		   return (VEmployee)mock;
		}
		

		#endregion
    }
}