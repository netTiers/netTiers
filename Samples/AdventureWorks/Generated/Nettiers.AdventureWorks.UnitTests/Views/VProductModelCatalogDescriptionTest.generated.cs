﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file VProductModelCatalogDescriptionTest.cs instead.
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
    /// Provides tests for the and <see cref="VProductModelCatalogDescription"/> objects (entity, collection and repository).
    /// </summary>
    public partial class VProductModelCatalogDescriptionTest
    {
    	// the VProductModelCatalogDescription instance used to test the repository.
		private VProductModelCatalogDescription mock;
		
		// the VList<VProductModelCatalogDescription> instance used to test the repository.
		private VList<VProductModelCatalogDescription> mockCollection;		

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static private void Init_Generated()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the VProductModelCatalogDescription Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
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
		/// Selects a page of VProductModelCatalogDescription objects from the database.
		/// </summary>
		private void Step_1_SelectAll_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.VProductModelCatalogDescriptionProvider.GetPaged(null, 0, 10, out count);
			Assert.IsTrue(count >= 0, "Select Query Failed with GetPaged");
			System.Console.WriteLine("DataRepository.VProductModelCatalogDescriptionProvider.GetPaged():");			
			System.Console.WriteLine(mockCollection);			
		}
		
		/// <summary>
		/// Searches some VProductModelCatalogDescription objects from the database.
		/// </summary>
		private void Step_2_Search_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.VProductModelCatalogDescriptionProvider.Find(null, null, "", 0, 10, out count);
			Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
			
			System.Console.WriteLine("DataRepository.VProductModelCatalogDescriptionProvider.Find():");			
			System.Console.WriteLine(mockCollection);
					
		}
		 //Find
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock VProductModelCatalogDescription entity into a temporary file.
		/// </summary>
		private void Step_6_SerializeEntity_Generated()
		{
			string fileName = "temp_VProductModelCatalogDescription.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VProductModelCatalogDescription)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mock); 
			myWriter.Close();
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock VProductModelCatalogDescription entity from a temporary file.
		/// </summary>
		private void Step_7_DeserializeEntity_Generated()
		{
			string fileName = "temp_VProductModelCatalogDescription.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VProductModelCatalogDescription)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			mock = (VProductModelCatalogDescription) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a VProductModelCatalogDescription collection into a temporary file.
		/// </summary>
		private void Step_8_SerializeCollection_Generated()
		{
			string fileName = "temp_VProductModelCatalogDescriptionCollection.xml";
		
			VList<VProductModelCatalogDescription> mockCollection = new VList<VProductModelCatalogDescription>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<VProductModelCatalogDescription>)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("VList<VProductModelCatalogDescription> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a VProductModelCatalogDescription collection from a temporary file.
		/// </summary>
		private void Step_9_DeserializeCollection_Generated()
		{
			string fileName = "temp_VProductModelCatalogDescriptionCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<VProductModelCatalogDescription>)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			VList<VProductModelCatalogDescription> mockCollection = (VList<VProductModelCatalogDescription>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("VList<VProductModelCatalogDescription> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		#region Mock Instance
		///<summary>
		///  Returns a Typed VProductModelCatalogDescription Entity with mock values.
		///</summary>
		static public VProductModelCatalogDescription CreateMockInstance()
		{		
			VProductModelCatalogDescription mock = new VProductModelCatalogDescription();
						
			mock.ProductModelId = TestUtility.Instance.RandomNumber();
			mock.Name = TestUtility.Instance.RandomString(24, false);;
			mock.Summary = TestUtility.Instance.RandomString(2, false);;
			mock.Manufacturer = TestUtility.Instance.RandomString(2, false);;
			mock.Copyright = TestUtility.Instance.RandomString(14, false);;
			mock.ProductUrl = TestUtility.Instance.RandomString(127, false);;
			mock.WarrantyPeriod = TestUtility.Instance.RandomString(127, false);;
			mock.WarrantyDescription = TestUtility.Instance.RandomString(127, false);;
			mock.NoOfYears = TestUtility.Instance.RandomString(127, false);;
			mock.MaintenanceDescription = TestUtility.Instance.RandomString(127, false);;
			mock.Wheel = TestUtility.Instance.RandomString(127, false);;
			mock.Saddle = TestUtility.Instance.RandomString(127, false);;
			mock.Pedal = TestUtility.Instance.RandomString(127, false);;
			mock.BikeFrame = TestUtility.Instance.RandomString(2, false);;
			mock.Crankset = TestUtility.Instance.RandomString(127, false);;
			mock.PictureAngle = TestUtility.Instance.RandomString(127, false);;
			mock.PictureSize = TestUtility.Instance.RandomString(127, false);;
			mock.ProductPhotoId = TestUtility.Instance.RandomString(127, false);;
			mock.Material = TestUtility.Instance.RandomString(127, false);;
			mock.Color = TestUtility.Instance.RandomString(127, false);;
			mock.ProductLine = TestUtility.Instance.RandomString(127, false);;
			mock.Style = TestUtility.Instance.RandomString(127, false);;
			mock.RiderExperience = TestUtility.Instance.RandomString(499, false);;
			mock.Rowguid = Guid.NewGuid();
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();
		   return (VProductModelCatalogDescription)mock;
		}
		

		#endregion
    }
}