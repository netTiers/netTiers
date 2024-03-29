﻿

/*
	File Generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file VendorAddressTest.cs instead.
*/

#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="VendorAddress"/> objects (entity, collection and repository).
    /// </summary>
   public partial class VendorAddressTest
    {
    	// the VendorAddress instance used to test the repository.
		protected VendorAddress mock;

		// the TList<VendorAddress> instance used to test the repository.
		protected TList<VendorAddress> mockCollection;

		protected static TransactionManager CreateTransaction()
		{
			TransactionManager transactionManager = null;
			if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
			}
			return transactionManager;
		}

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static public void Init_Generated()
        {
        	System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the VendorAddress Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }

    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		static public void CleanUp_Generated()
        {
			System.Console.WriteLine("All Tests Completed");
			System.Console.WriteLine();
        }




		/// <summary>
		/// Selects all VendorAddress objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;

				mockCollection = DataRepository.VendorAddressProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");

				System.Console.WriteLine("DataRepository.VendorAddressProvider.Find():");
				System.Console.WriteLine(mockCollection);

				// GetPaged
				count = -1;

				mockCollection = DataRepository.VendorAddressProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}




		/// <summary>
		/// Deep load all VendorAddress children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.VendorAddressProvider.GetPaged(tm, 0, 10, out count);

				DataRepository.VendorAddressProvider.DeepLoading += new EntityProviderBaseCore<VendorAddress, VendorAddressKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{

					DataRepository.VendorAddressProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("VendorAddress instance correctly deep loaded at 1 level.");

					mockCollection.Add(mock);
					// DataRepository.VendorAddressProvider.DeepSave(tm, mockCollection);
				}

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}




		#region Serialization tests

		/// <summary>
		/// Serialize the mock VendorAddress entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_VendorAddress.xml");

				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");

				System.Console.WriteLine("mock correctly serialized to a temporary file.");
			}
		}

		/// <summary>
		/// Deserialize the mock VendorAddress entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_VendorAddress.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<VendorAddress>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);

			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}

		/// <summary>
		/// Serialize a VendorAddress collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_VendorAddressCollection.xml");

				mock = CreateMockInstance(tm);
				TList<VendorAddress> mockCollection = new TList<VendorAddress>();
				mockCollection.Add(mock);

				EntityHelper.SerializeXml(mockCollection, fileName);

				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<VendorAddress> correctly serialized to a temporary file.");
			}
		}


		/// <summary>
		/// Deserialize a VendorAddress collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_VendorAddressCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<VendorAddress>));
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<VendorAddress> mockCollection = (TList<VendorAddress>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}

			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<VendorAddress> correctly deserialized from a temporary file.");
		}
		#endregion




		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);

				VendorAddress entity = mock.Copy() as VendorAddress;
				entity = (VendorAddress)mock.Clone();
				Assert.IsTrue(VendorAddress.ValueEquals(entity, mock), "Clone is not working");
			}
		}

		/// <summary>
		/// Test Find using the Query class
		/// </summary>
		private void Step_30_TestFindByQuery_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Insert Mock Instance
				VendorAddress mock = CreateMockInstance(tm);
				bool result = DataRepository.VendorAddressProvider.Insert(tm, mock);

				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				VendorAddressQuery query = new VendorAddressQuery();

				query.AppendEquals(VendorAddressColumn.VendorId, mock.VendorId.ToString());
				query.AppendEquals(VendorAddressColumn.AddressId, mock.AddressId.ToString());
				query.AppendEquals(VendorAddressColumn.AddressTypeId, mock.AddressTypeId.ToString());
				query.AppendEquals(VendorAddressColumn.ModifiedDate, mock.ModifiedDate.ToString());

				TList<VendorAddress> results = DataRepository.VendorAddressProvider.Find(tm, query);

				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}

		#region Mock Instance
		///<summary>
		///  Returns a Typed VendorAddress Entity with mock values.
		///</summary>
		static public VendorAddress CreateMockInstance_Generated(TransactionManager tm)
		{
			VendorAddress mock = new VendorAddress();

			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();

			//OneToOneRelationship
			Address mockAddressByAddressId = AddressTest.CreateMockInstance(tm);
			DataRepository.AddressProvider.Insert(tm, mockAddressByAddressId);
			mock.AddressId = mockAddressByAddressId.AddressId;
			//OneToOneRelationship
			AddressType mockAddressTypeByAddressTypeId = AddressTypeTest.CreateMockInstance(tm);
			DataRepository.AddressTypeProvider.Insert(tm, mockAddressTypeByAddressTypeId);
			mock.AddressTypeId = mockAddressTypeByAddressTypeId.AddressTypeId;
			//OneToOneRelationship
			Vendor mockVendorByVendorId = VendorTest.CreateMockInstance(tm);
			DataRepository.VendorProvider.Insert(tm, mockVendorByVendorId);
			mock.VendorId = mockVendorByVendorId.VendorId;

			// create a temporary collection and add the item to it
			TList<VendorAddress> tempMockCollection = new TList<VendorAddress>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);


		   return (VendorAddress)mock;
		}


		///<summary>
		///  Update the Typed VendorAddress Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, VendorAddress mock)
		{
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();

			//OneToOneRelationship
			Address mockAddressByAddressId = AddressTest.CreateMockInstance(tm);
			DataRepository.AddressProvider.Insert(tm, mockAddressByAddressId);
			mock.AddressId = mockAddressByAddressId.AddressId;

			//OneToOneRelationship
			AddressType mockAddressTypeByAddressTypeId = AddressTypeTest.CreateMockInstance(tm);
			DataRepository.AddressTypeProvider.Insert(tm, mockAddressTypeByAddressTypeId);
			mock.AddressTypeId = mockAddressTypeByAddressTypeId.AddressTypeId;

			//OneToOneRelationship
			Vendor mockVendorByVendorId = VendorTest.CreateMockInstance(tm);
			DataRepository.VendorProvider.Insert(tm, mockVendorByVendorId);
			mock.VendorId = mockVendorByVendorId.VendorId;

		}
		#endregion
    }
}
