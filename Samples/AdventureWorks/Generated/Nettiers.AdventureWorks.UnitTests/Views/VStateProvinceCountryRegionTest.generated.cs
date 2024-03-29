﻿
/*
	File Generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file VStateProvinceCountryRegionTest.cs instead.
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
    /// Provides tests for the and <see cref="VStateProvinceCountryRegion"/> objects (entity, collection and repository).
    /// </summary>
    public partial class VStateProvinceCountryRegionTest
    {
    	// the VStateProvinceCountryRegion instance used to test the repository.
		private VStateProvinceCountryRegion mock;

		// the VList<VStateProvinceCountryRegion> instance used to test the repository.
		private VList<VStateProvinceCountryRegion> mockCollection;

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static private void Init_Generated()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the VStateProvinceCountryRegion Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
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
		/// Selects a page of VStateProvinceCountryRegion objects from the database.
		/// </summary>
		private void Step_1_SelectAll_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.VStateProvinceCountryRegionProvider.GetPaged(null, 0, 10, out count);
			Assert.IsTrue(count >= 0, "Select Query Failed with GetPaged");
			System.Console.WriteLine("DataRepository.VStateProvinceCountryRegionProvider.GetPaged():");
			System.Console.WriteLine(mockCollection);
		}

		/// <summary>
		/// Searches some VStateProvinceCountryRegion objects from the database.
		/// </summary>
		private void Step_2_Search_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.VStateProvinceCountryRegionProvider.Find(null, null, "", 0, 10, out count);
			Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");

			System.Console.WriteLine("DataRepository.VStateProvinceCountryRegionProvider.Find():");
			System.Console.WriteLine(mockCollection);

		}
		 //Find


		#region Serialization tests

		/// <summary>
		/// Serialize the mock VStateProvinceCountryRegion entity into a temporary file.
		/// </summary>
		private void Step_6_SerializeEntity_Generated()
		{
			string fileName = "temp_VStateProvinceCountryRegion.xml";

			XmlSerializer mySerializer = new XmlSerializer(typeof(VStateProvinceCountryRegion));
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName);
			mySerializer.Serialize(myWriter, mock);
			myWriter.Close();
			System.Console.WriteLine("mock correctly serialized to a temporary file.");
		}

		/// <summary>
		/// Deserialize the mock VStateProvinceCountryRegion entity from a temporary file.
		/// </summary>
		private void Step_7_DeserializeEntity_Generated()
		{
			string fileName = "temp_VStateProvinceCountryRegion.xml";

			XmlSerializer mySerializer = new XmlSerializer(typeof(VStateProvinceCountryRegion));
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open);
			mock = (VStateProvinceCountryRegion) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);

			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}

		/// <summary>
		/// Serialize a VStateProvinceCountryRegion collection into a temporary file.
		/// </summary>
		private void Step_8_SerializeCollection_Generated()
		{
			string fileName = "temp_VStateProvinceCountryRegionCollection.xml";

			VList<VStateProvinceCountryRegion> mockCollection = new VList<VStateProvinceCountryRegion>();
			mockCollection.Add(mock);

			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<VStateProvinceCountryRegion>));
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName);
			mySerializer.Serialize(myWriter, mockCollection);
			myWriter.Close();

			System.Console.WriteLine("VList<VStateProvinceCountryRegion> correctly serialized to a temporary file.");
		}


		/// <summary>
		/// Deserialize a VStateProvinceCountryRegion collection from a temporary file.
		/// </summary>
		private void Step_9_DeserializeCollection_Generated()
		{
			string fileName = "temp_VStateProvinceCountryRegionCollection.xml";

			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<VStateProvinceCountryRegion>));
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open);
			VList<VStateProvinceCountryRegion> mockCollection = (VList<VStateProvinceCountryRegion>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("VList<VStateProvinceCountryRegion> correctly deserialized from a temporary file.");
		}
		#endregion

		#region Mock Instance
		///<summary>
		///  Returns a Typed VStateProvinceCountryRegion Entity with mock values.
		///</summary>
		static public VStateProvinceCountryRegion CreateMockInstance()
		{
			VStateProvinceCountryRegion mock = new VStateProvinceCountryRegion();

			mock.StateProvinceId = TestUtility.Instance.RandomNumber();
			mock.StateProvinceCode = TestUtility.Instance.RandomString(3, false);;
			mock.IsOnlyStateProvinceFlag = TestUtility.Instance.RandomBoolean();
			mock.StateProvinceName = TestUtility.Instance.RandomString(24, false);;
			mock.TerritoryId = TestUtility.Instance.RandomNumber();
			mock.CountryRegionCode = TestUtility.Instance.RandomString(3, false);;
			mock.CountryRegionName = TestUtility.Instance.RandomString(24, false);;
		   return (VStateProvinceCountryRegion)mock;
		}


		#endregion
    }
}
