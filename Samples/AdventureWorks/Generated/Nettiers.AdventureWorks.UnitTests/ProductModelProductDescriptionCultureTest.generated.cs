﻿

/*
	File Generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file ProductModelProductDescriptionCultureTest.cs instead.
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
    /// Provides tests for the and <see cref="ProductModelProductDescriptionCulture"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ProductModelProductDescriptionCultureTest
    {
    	// the ProductModelProductDescriptionCulture instance used to test the repository.
		protected ProductModelProductDescriptionCulture mock;

		// the TList<ProductModelProductDescriptionCulture> instance used to test the repository.
		protected TList<ProductModelProductDescriptionCulture> mockCollection;

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
			System.Console.WriteLine("-- Testing the ProductModelProductDescriptionCulture Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
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
		/// Selects all ProductModelProductDescriptionCulture objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;

				mockCollection = DataRepository.ProductModelProductDescriptionCultureProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");

				System.Console.WriteLine("DataRepository.ProductModelProductDescriptionCultureProvider.Find():");
				System.Console.WriteLine(mockCollection);

				// GetPaged
				count = -1;

				mockCollection = DataRepository.ProductModelProductDescriptionCultureProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}




		/// <summary>
		/// Deep load all ProductModelProductDescriptionCulture children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ProductModelProductDescriptionCultureProvider.GetPaged(tm, 0, 10, out count);

				DataRepository.ProductModelProductDescriptionCultureProvider.DeepLoading += new EntityProviderBaseCore<ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{

					DataRepository.ProductModelProductDescriptionCultureProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ProductModelProductDescriptionCulture instance correctly deep loaded at 1 level.");

					mockCollection.Add(mock);
					// DataRepository.ProductModelProductDescriptionCultureProvider.DeepSave(tm, mockCollection);
				}

				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}




		#region Serialization tests

		/// <summary>
		/// Serialize the mock ProductModelProductDescriptionCulture entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductModelProductDescriptionCulture.xml");

				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");

				System.Console.WriteLine("mock correctly serialized to a temporary file.");
			}
		}

		/// <summary>
		/// Deserialize the mock ProductModelProductDescriptionCulture entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductModelProductDescriptionCulture.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ProductModelProductDescriptionCulture>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);

			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}

		/// <summary>
		/// Serialize a ProductModelProductDescriptionCulture collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductModelProductDescriptionCultureCollection.xml");

				mock = CreateMockInstance(tm);
				TList<ProductModelProductDescriptionCulture> mockCollection = new TList<ProductModelProductDescriptionCulture>();
				mockCollection.Add(mock);

				EntityHelper.SerializeXml(mockCollection, fileName);

				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ProductModelProductDescriptionCulture> correctly serialized to a temporary file.");
			}
		}


		/// <summary>
		/// Deserialize a ProductModelProductDescriptionCulture collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductModelProductDescriptionCultureCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");

			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ProductModelProductDescriptionCulture>));
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ProductModelProductDescriptionCulture> mockCollection = (TList<ProductModelProductDescriptionCulture>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}

			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ProductModelProductDescriptionCulture> correctly deserialized from a temporary file.");
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

				ProductModelProductDescriptionCulture entity = mock.Copy() as ProductModelProductDescriptionCulture;
				entity = (ProductModelProductDescriptionCulture)mock.Clone();
				Assert.IsTrue(ProductModelProductDescriptionCulture.ValueEquals(entity, mock), "Clone is not working");
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
				ProductModelProductDescriptionCulture mock = CreateMockInstance(tm);
				bool result = DataRepository.ProductModelProductDescriptionCultureProvider.Insert(tm, mock);

				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ProductModelProductDescriptionCultureQuery query = new ProductModelProductDescriptionCultureQuery();

				query.AppendEquals(ProductModelProductDescriptionCultureColumn.ProductModelId, mock.ProductModelId.ToString());
				query.AppendEquals(ProductModelProductDescriptionCultureColumn.ProductDescriptionId, mock.ProductDescriptionId.ToString());
				query.AppendEquals(ProductModelProductDescriptionCultureColumn.CultureId, mock.CultureId.ToString());
				query.AppendEquals(ProductModelProductDescriptionCultureColumn.ModifiedDate, mock.ModifiedDate.ToString());

				TList<ProductModelProductDescriptionCulture> results = DataRepository.ProductModelProductDescriptionCultureProvider.Find(tm, query);

				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}

		#region Mock Instance
		///<summary>
		///  Returns a Typed ProductModelProductDescriptionCulture Entity with mock values.
		///</summary>
		static public ProductModelProductDescriptionCulture CreateMockInstance_Generated(TransactionManager tm)
		{
			ProductModelProductDescriptionCulture mock = new ProductModelProductDescriptionCulture();

			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();

			//OneToOneRelationship
			Culture mockCultureByCultureId = CultureTest.CreateMockInstance(tm);
			DataRepository.CultureProvider.Insert(tm, mockCultureByCultureId);
			mock.CultureId = mockCultureByCultureId.CultureId;
			//OneToOneRelationship
			ProductDescription mockProductDescriptionByProductDescriptionId = ProductDescriptionTest.CreateMockInstance(tm);
			DataRepository.ProductDescriptionProvider.Insert(tm, mockProductDescriptionByProductDescriptionId);
			mock.ProductDescriptionId = mockProductDescriptionByProductDescriptionId.ProductDescriptionId;
			//OneToOneRelationship
			ProductModel mockProductModelByProductModelId = ProductModelTest.CreateMockInstance(tm);
			DataRepository.ProductModelProvider.Insert(tm, mockProductModelByProductModelId);
			mock.ProductModelId = mockProductModelByProductModelId.ProductModelId;

			// create a temporary collection and add the item to it
			TList<ProductModelProductDescriptionCulture> tempMockCollection = new TList<ProductModelProductDescriptionCulture>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);


		   return (ProductModelProductDescriptionCulture)mock;
		}


		///<summary>
		///  Update the Typed ProductModelProductDescriptionCulture Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ProductModelProductDescriptionCulture mock)
		{
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();

			//OneToOneRelationship
			Culture mockCultureByCultureId = CultureTest.CreateMockInstance(tm);
			DataRepository.CultureProvider.Insert(tm, mockCultureByCultureId);
			mock.CultureId = mockCultureByCultureId.CultureId;

			//OneToOneRelationship
			ProductDescription mockProductDescriptionByProductDescriptionId = ProductDescriptionTest.CreateMockInstance(tm);
			DataRepository.ProductDescriptionProvider.Insert(tm, mockProductDescriptionByProductDescriptionId);
			mock.ProductDescriptionId = mockProductDescriptionByProductDescriptionId.ProductDescriptionId;

			//OneToOneRelationship
			ProductModel mockProductModelByProductModelId = ProductModelTest.CreateMockInstance(tm);
			DataRepository.ProductModelProvider.Insert(tm, mockProductModelByProductModelId);
			mock.ProductModelId = mockProductModelByProductModelId.ProductModelId;

		}
		#endregion
    }
}
