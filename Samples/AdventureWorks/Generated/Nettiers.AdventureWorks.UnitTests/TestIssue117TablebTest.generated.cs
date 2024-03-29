﻿

/*
	File Generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file TestIssue117TablebTest.cs instead.
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
    /// Provides tests for the and <see cref="TestIssue117Tableb"/> objects (entity, collection and repository).
    /// </summary>
   public partial class TestIssue117TablebTest
    {
    	// the TestIssue117Tableb instance used to test the repository.
		private TestIssue117Tableb mock;

		// the TList<TestIssue117Tableb> instance used to test the repository.
		private TList<TestIssue117Tableb> mockCollection;

		private static TransactionManager CreateTransaction()
		{
			TransactionManager transactionManager = null;
			if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
			}
			return transactionManager;
		}

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static public void Init_Generated()
        {
        	System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the TestIssue117Tableb Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock TestIssue117Tableb entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.TestIssue117TablebProvider.Insert(tm, mock), "Insert failed");

				System.Console.WriteLine("DataRepository.TestIssue117TablebProvider.Insert(mock):");
				System.Console.WriteLine(mock);

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}


		/// <summary>
		/// Selects all TestIssue117Tableb objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;

				mockCollection = DataRepository.TestIssue117TablebProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");

				System.Console.WriteLine("DataRepository.TestIssue117TablebProvider.Find():");
				System.Console.WriteLine(mockCollection);

				// GetPaged
				count = -1;

				mockCollection = DataRepository.TestIssue117TablebProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}




		/// <summary>
		/// Deep load all TestIssue117Tableb children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.TestIssue117TablebProvider.GetPaged(tm, 0, 10, out count);

				DataRepository.TestIssue117TablebProvider.DeepLoading += new EntityProviderBaseCore<TestIssue117Tableb, TestIssue117TablebKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{

					DataRepository.TestIssue117TablebProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("TestIssue117Tableb instance correctly deep loaded at 1 level.");

					mockCollection.Add(mock);
					// DataRepository.TestIssue117TablebProvider.DeepSave(tm, mockCollection);
				}

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}

		/// <summary>
		/// Updates a mock TestIssue117Tableb entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				TestIssue117Tableb mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.TestIssue117TablebProvider.Insert(tm, mock), "Insert failed");

				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.TestIssue117TablebProvider.Update(tm, mock), "Update failed.");

				System.Console.WriteLine("DataRepository.TestIssue117TablebProvider.Update(mock):");
				System.Console.WriteLine(mock);

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}


		/// <summary>
		/// Delete the mock TestIssue117Tableb entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (TestIssue117Tableb)CreateMockInstance(tm);
				DataRepository.TestIssue117TablebProvider.Insert(tm, mock);

				Assert.IsTrue(DataRepository.TestIssue117TablebProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.TestIssue117TablebProvider.Delete(mock):");
				System.Console.WriteLine(mock);

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}

		#region Serialization tests

		/// <summary>
		/// Serialize the mock TestIssue117Tableb entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_TestIssue117Tableb.xml");

				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");

				System.Console.WriteLine("mock correctly serialized to a temporary file.");
			}
		}

		/// <summary>
		/// Deserialize the mock TestIssue117Tableb entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_TestIssue117Tableb.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<TestIssue117Tableb>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);

			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}

		/// <summary>
		/// Serialize a TestIssue117Tableb collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_TestIssue117TablebCollection.xml");

				mock = CreateMockInstance(tm);
				TList<TestIssue117Tableb> mockCollection = new TList<TestIssue117Tableb>();
				mockCollection.Add(mock);

				EntityHelper.SerializeXml(mockCollection, fileName);

				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<TestIssue117Tableb> correctly serialized to a temporary file.");
			}
		}


		/// <summary>
		/// Deserialize a TestIssue117Tableb collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_TestIssue117TablebCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<TestIssue117Tableb>));
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<TestIssue117Tableb> mockCollection = (TList<TestIssue117Tableb>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}

			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<TestIssue117Tableb> correctly deserialized from a temporary file.");
		}
		#endregion



		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				TestIssue117Tableb entity = CreateMockInstance(tm);
				bool result = DataRepository.TestIssue117TablebProvider.Insert(tm, entity);

				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");

			}
		}


		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				TestIssue117Tableb entity = CreateMockInstance(tm);
				bool result = DataRepository.TestIssue117TablebProvider.Insert(tm, entity);

				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");


				TestIssue117Tableb t0 = DataRepository.TestIssue117TablebProvider.GetByTestIssue117TableBid(tm, entity.TestIssue117TableBid);
			}
		}

		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);

				TestIssue117Tableb entity = mock.Copy() as TestIssue117Tableb;
				entity = (TestIssue117Tableb)mock.Clone();
				Assert.IsTrue(TestIssue117Tableb.ValueEquals(entity, mock), "Clone is not working");
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
				TestIssue117Tableb mock = CreateMockInstance(tm);
				bool result = DataRepository.TestIssue117TablebProvider.Insert(tm, mock);

				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				TestIssue117TablebQuery query = new TestIssue117TablebQuery();

				if(mock.DumbField != null)
					query.AppendEquals(TestIssue117TablebColumn.DumbField, mock.DumbField.ToString());

				TList<TestIssue117Tableb> results = DataRepository.TestIssue117TablebProvider.Find(tm, query);

				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}

		#region Mock Instance
		///<summary>
		///  Returns a Typed TestIssue117Tableb Entity with mock values.
		///</summary>
		static public TestIssue117Tableb CreateMockInstance_Generated(TransactionManager tm)
		{
			TestIssue117Tableb mock = new TestIssue117Tableb();

			mock.DumbField = TestUtility.Instance.RandomBoolean();


			// create a temporary collection and add the item to it
			TList<TestIssue117Tableb> tempMockCollection = new TList<TestIssue117Tableb>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);


		   return (TestIssue117Tableb)mock;
		}


		///<summary>
		///  Update the Typed TestIssue117Tableb Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, TestIssue117Tableb mock)
		{
			mock.DumbField = TestUtility.Instance.RandomBoolean();

		}
		#endregion
    }
}
