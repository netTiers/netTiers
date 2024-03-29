﻿

/*
	File Generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file SalesReasonTest.cs instead.
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
    /// Provides tests for the and <see cref="SalesReason"/> objects (entity, collection and repository).
    /// </summary>
   public partial class SalesReasonTest
    {
    	// the SalesReason instance used to test the repository.
		protected SalesReason mock;

		// the TList<SalesReason> instance used to test the repository.
		protected TList<SalesReason> mockCollection;

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
			System.Console.WriteLine("-- Testing the SalesReason Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock SalesReason entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SalesReasonProvider.Insert(tm, mock), "Insert failed");

				System.Console.WriteLine("DataRepository.SalesReasonProvider.Insert(mock):");
				System.Console.WriteLine(mock);

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}


		/// <summary>
		/// Selects all SalesReason objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;

				mockCollection = DataRepository.SalesReasonProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");

				System.Console.WriteLine("DataRepository.SalesReasonProvider.Find():");
				System.Console.WriteLine(mockCollection);

				// GetPaged
				count = -1;

				mockCollection = DataRepository.SalesReasonProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}




		/// <summary>
		/// Deep load all SalesReason children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.SalesReasonProvider.GetPaged(tm, 0, 10, out count);

				DataRepository.SalesReasonProvider.DeepLoading += new EntityProviderBaseCore<SalesReason, SalesReasonKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{

					DataRepository.SalesReasonProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("SalesReason instance correctly deep loaded at 1 level.");

					mockCollection.Add(mock);
					// DataRepository.SalesReasonProvider.DeepSave(tm, mockCollection);
				}

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}

		/// <summary>
		/// Updates a mock SalesReason entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SalesReason mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SalesReasonProvider.Insert(tm, mock), "Insert failed");

				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.SalesReasonProvider.Update(tm, mock), "Update failed.");

				System.Console.WriteLine("DataRepository.SalesReasonProvider.Update(mock):");
				System.Console.WriteLine(mock);

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}


		/// <summary>
		/// Delete the mock SalesReason entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (SalesReason)CreateMockInstance(tm);
				DataRepository.SalesReasonProvider.Insert(tm, mock);

				Assert.IsTrue(DataRepository.SalesReasonProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.SalesReasonProvider.Delete(mock):");
				System.Console.WriteLine(mock);

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}

		#region Serialization tests

		/// <summary>
		/// Serialize the mock SalesReason entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SalesReason.xml");

				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");

				System.Console.WriteLine("mock correctly serialized to a temporary file.");
			}
		}

		/// <summary>
		/// Deserialize the mock SalesReason entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SalesReason.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<SalesReason>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);

			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}

		/// <summary>
		/// Serialize a SalesReason collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SalesReasonCollection.xml");

				mock = CreateMockInstance(tm);
				TList<SalesReason> mockCollection = new TList<SalesReason>();
				mockCollection.Add(mock);

				EntityHelper.SerializeXml(mockCollection, fileName);

				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<SalesReason> correctly serialized to a temporary file.");
			}
		}


		/// <summary>
		/// Deserialize a SalesReason collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SalesReasonCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<SalesReason>));
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<SalesReason> mockCollection = (TList<SalesReason>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}

			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<SalesReason> correctly deserialized from a temporary file.");
		}
		#endregion



		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SalesReason entity = CreateMockInstance(tm);
				bool result = DataRepository.SalesReasonProvider.Insert(tm, entity);

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
				SalesReason entity = CreateMockInstance(tm);
				bool result = DataRepository.SalesReasonProvider.Insert(tm, entity);

				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");


				SalesReason t0 = DataRepository.SalesReasonProvider.GetBySalesReasonId(tm, entity.SalesReasonId);
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

				SalesReason entity = mock.Copy() as SalesReason;
				entity = (SalesReason)mock.Clone();
				Assert.IsTrue(SalesReason.ValueEquals(entity, mock), "Clone is not working");
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
				SalesReason mock = CreateMockInstance(tm);
				bool result = DataRepository.SalesReasonProvider.Insert(tm, mock);

				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				SalesReasonQuery query = new SalesReasonQuery();

				query.AppendEquals(SalesReasonColumn.SalesReasonId, mock.SalesReasonId.ToString());
				query.AppendEquals(SalesReasonColumn.Name, mock.Name.ToString());
				query.AppendEquals(SalesReasonColumn.ReasonType, mock.ReasonType.ToString());
				query.AppendEquals(SalesReasonColumn.ModifiedDate, mock.ModifiedDate.ToString());

				TList<SalesReason> results = DataRepository.SalesReasonProvider.Find(tm, query);

				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}

		#region Mock Instance
		///<summary>
		///  Returns a Typed SalesReason Entity with mock values.
		///</summary>
		static public SalesReason CreateMockInstance_Generated(TransactionManager tm)
		{
			SalesReason mock = new SalesReason();

			mock.Name = TestUtility.Instance.RandomString(24, false);;
			mock.ReasonType = TestUtility.Instance.RandomString(24, false);;
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();


			// create a temporary collection and add the item to it
			TList<SalesReason> tempMockCollection = new TList<SalesReason>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);


		   return (SalesReason)mock;
		}


		///<summary>
		///  Update the Typed SalesReason Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, SalesReason mock)
		{
			mock.Name = TestUtility.Instance.RandomString(24, false);;
			mock.ReasonType = TestUtility.Instance.RandomString(24, false);;
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();

		}
		#endregion
    }
}
