﻿

/*
	File Generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file ProductListPriceHistoryTest.cs instead.
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
    /// Provides tests for the and <see cref="ProductListPriceHistory"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ProductListPriceHistoryTest
    {
    	// the ProductListPriceHistory instance used to test the repository.
		protected ProductListPriceHistory mock;

		// the TList<ProductListPriceHistory> instance used to test the repository.
		protected TList<ProductListPriceHistory> mockCollection;

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
			System.Console.WriteLine("-- Testing the ProductListPriceHistory Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock ProductListPriceHistory entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ProductListPriceHistoryProvider.Insert(tm, mock), "Insert failed");

				System.Console.WriteLine("DataRepository.ProductListPriceHistoryProvider.Insert(mock):");
				System.Console.WriteLine(mock);

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}


		/// <summary>
		/// Selects all ProductListPriceHistory objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;

				mockCollection = DataRepository.ProductListPriceHistoryProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");

				System.Console.WriteLine("DataRepository.ProductListPriceHistoryProvider.Find():");
				System.Console.WriteLine(mockCollection);

				// GetPaged
				count = -1;

				mockCollection = DataRepository.ProductListPriceHistoryProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}




		/// <summary>
		/// Deep load all ProductListPriceHistory children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ProductListPriceHistoryProvider.GetPaged(tm, 0, 10, out count);

				DataRepository.ProductListPriceHistoryProvider.DeepLoading += new EntityProviderBaseCore<ProductListPriceHistory, ProductListPriceHistoryKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{

					DataRepository.ProductListPriceHistoryProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ProductListPriceHistory instance correctly deep loaded at 1 level.");

					mockCollection.Add(mock);
					// DataRepository.ProductListPriceHistoryProvider.DeepSave(tm, mockCollection);
				}

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}

		/// <summary>
		/// Updates a mock ProductListPriceHistory entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ProductListPriceHistory mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ProductListPriceHistoryProvider.Insert(tm, mock), "Insert failed");

				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ProductListPriceHistoryProvider.Update(tm, mock), "Update failed.");

				System.Console.WriteLine("DataRepository.ProductListPriceHistoryProvider.Update(mock):");
				System.Console.WriteLine(mock);

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}


		/// <summary>
		/// Delete the mock ProductListPriceHistory entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (ProductListPriceHistory)CreateMockInstance(tm);
				DataRepository.ProductListPriceHistoryProvider.Insert(tm, mock);

				Assert.IsTrue(DataRepository.ProductListPriceHistoryProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ProductListPriceHistoryProvider.Delete(mock):");
				System.Console.WriteLine(mock);

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}

		#region Serialization tests

		/// <summary>
		/// Serialize the mock ProductListPriceHistory entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductListPriceHistory.xml");

				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");

				System.Console.WriteLine("mock correctly serialized to a temporary file.");
			}
		}

		/// <summary>
		/// Deserialize the mock ProductListPriceHistory entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductListPriceHistory.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ProductListPriceHistory>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);

			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}

		/// <summary>
		/// Serialize a ProductListPriceHistory collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductListPriceHistoryCollection.xml");

				mock = CreateMockInstance(tm);
				TList<ProductListPriceHistory> mockCollection = new TList<ProductListPriceHistory>();
				mockCollection.Add(mock);

				EntityHelper.SerializeXml(mockCollection, fileName);

				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ProductListPriceHistory> correctly serialized to a temporary file.");
			}
		}


		/// <summary>
		/// Deserialize a ProductListPriceHistory collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductListPriceHistoryCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ProductListPriceHistory>));
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ProductListPriceHistory> mockCollection = (TList<ProductListPriceHistory>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}

			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ProductListPriceHistory> correctly deserialized from a temporary file.");
		}
		#endregion



		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ProductListPriceHistory entity = CreateMockInstance(tm);
				bool result = DataRepository.ProductListPriceHistoryProvider.Insert(tm, entity);

				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");

				TList<ProductListPriceHistory> t0 = DataRepository.ProductListPriceHistoryProvider.GetByProductId(tm, entity.ProductId, 0, 10);
			}
		}


		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ProductListPriceHistory entity = CreateMockInstance(tm);
				bool result = DataRepository.ProductListPriceHistoryProvider.Insert(tm, entity);

				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");


				ProductListPriceHistory t0 = DataRepository.ProductListPriceHistoryProvider.GetByProductIdStartDate(tm, entity.ProductId, entity.StartDate);
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

				ProductListPriceHistory entity = mock.Copy() as ProductListPriceHistory;
				entity = (ProductListPriceHistory)mock.Clone();
				Assert.IsTrue(ProductListPriceHistory.ValueEquals(entity, mock), "Clone is not working");
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
				ProductListPriceHistory mock = CreateMockInstance(tm);
				bool result = DataRepository.ProductListPriceHistoryProvider.Insert(tm, mock);

				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ProductListPriceHistoryQuery query = new ProductListPriceHistoryQuery();

				query.AppendEquals(ProductListPriceHistoryColumn.ProductId, mock.ProductId.ToString());
				query.AppendEquals(ProductListPriceHistoryColumn.StartDate, mock.StartDate.ToString());
				if(mock.EndDate != null)
					query.AppendEquals(ProductListPriceHistoryColumn.EndDate, mock.EndDate.ToString());
				query.AppendEquals(ProductListPriceHistoryColumn.ListPrice, mock.ListPrice.ToString());
				query.AppendEquals(ProductListPriceHistoryColumn.ModifiedDate, mock.ModifiedDate.ToString());

				TList<ProductListPriceHistory> results = DataRepository.ProductListPriceHistoryProvider.Find(tm, query);

				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}

		#region Mock Instance
		///<summary>
		///  Returns a Typed ProductListPriceHistory Entity with mock values.
		///</summary>
		static public ProductListPriceHistory CreateMockInstance_Generated(TransactionManager tm)
		{
			ProductListPriceHistory mock = new ProductListPriceHistory();

			mock.StartDate = TestUtility.Instance.RandomDateTime();
			mock.EndDate = TestUtility.Instance.RandomDateTime();
			mock.ListPrice = TestUtility.Instance.RandomShort();
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();

			//OneToOneRelationship
			Product mockProductByProductId = ProductTest.CreateMockInstance(tm);
			DataRepository.ProductProvider.Insert(tm, mockProductByProductId);
			mock.ProductId = mockProductByProductId.ProductId;

			// create a temporary collection and add the item to it
			TList<ProductListPriceHistory> tempMockCollection = new TList<ProductListPriceHistory>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);


		   return (ProductListPriceHistory)mock;
		}


		///<summary>
		///  Update the Typed ProductListPriceHistory Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ProductListPriceHistory mock)
		{
			mock.EndDate = TestUtility.Instance.RandomDateTime();
			mock.ListPrice = TestUtility.Instance.RandomShort();
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();

			//OneToOneRelationship
			Product mockProductByProductId = ProductTest.CreateMockInstance(tm);
			DataRepository.ProductProvider.Insert(tm, mockProductByProductId);
			mock.ProductId = mockProductByProductId.ProductId;

		}
		#endregion
    }
}
