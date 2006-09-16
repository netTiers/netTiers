﻿

#region Using directives

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;

#endregion

namespace netTiers.PetShop.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="Item"/> objects (entity, collection and repository).
    /// </summary>
    [TestFixture]
    public class ItemTest
    {
    	// the Item instance used to test the repository.
		private Item mock;
		
		// the TList<Item> instance used to test the repository.
		TList<Item> mockCollection;
		
		TransactionManager transactionManager = null;
		
		/// <summary>
		/// Creates a new <see cref="ItemTest"/> instance.
		/// </summary>	
		public ItemTest()
		{			
			this.mock = (Item)CreateMockInstance();						
		}
        
        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        [TestFixtureSetUp]
        public void Init()
        {
        	if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction();
			}
			
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the Item Entity with the {0} --", netTiers.PetShop.DataAccessLayer.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
        [TestFixtureTearDown]
        public void Dispose()
        {   
        	if (DataRepository.Provider.IsTransactionSupported && transactionManager!=null && transactionManager.IsOpen)
			{
				transactionManager.Rollback();
			}
			
			System.Console.WriteLine();
			System.Console.WriteLine();
        }
    
    
		/// <summary>
		/// Inserts a mock Item entity into the database.
		/// </summary>
		[Test]
		public void Step_01_Insert()
		{
			Assert.IsTrue(DataRepository.ItemProvider.Insert(transactionManager, this.mock), "Insert failed");
									
			System.Console.WriteLine("DataRepository.ItemProvider.Insert(this.mock):");			
			System.Console.WriteLine(this.mock);			
		}
		
		
		/// <summary>
		/// Selects all Item objects of the database.
		/// </summary>
		[Test]
		public void Step_02_SelectAll()
		{
			mockCollection = DataRepository.ItemProvider.GetAll(transactionManager);
			Assert.IsTrue(mockCollection.Count > 0, "No records returned.");
			System.Console.WriteLine("DataRepository.ItemProvider.GetAll():");			
			System.Console.WriteLine(mockCollection);
					
			
			// get paged
			int count = 0;
			DataRepository.ItemProvider.GetPaged(transactionManager, 0, 10, out count);
			System.Console.WriteLine("#get paged count: " + count.ToString());
		}
		
		
		
		
		/// <summary>
		/// Deep load all Item children.
		/// </summary>
		[Test]
		public void Step_03_DeepLoad()
		{
			if (mockCollection.Count > 0)
			{
				//mockCollection.Shuffle();			
				DataRepository.ItemProvider.DeepLoad(mockCollection[0]);
				System.Console.WriteLine("Item instance correctly deep loaded at 1 level.");
								
				//mockCollection.Shuffle();
				DataRepository.ItemProvider.DeepLoad(mockCollection[0], true);
				System.Console.WriteLine("Item instance correctly deep loaded at N level.");
				
				mockCollection.Add(this.mock);
				DataRepository.ItemProvider.DeepSave(transactionManager, mockCollection);
				
			}			
		}
		
		/// <summary>
		/// Updates a mock Item entity into the database.
		/// </summary>
		[Test]
		public void Step_04_Update()
		{
			this.mock = UpdateMockInstance(this.mock);
			Assert.IsTrue(DataRepository.ItemProvider.Update(transactionManager, this.mock), "Update failed.");			
		
			// TODO : select sur l'id
			// TODO : verif si l'object recup? est egal
			
			System.Console.WriteLine("DataRepository.ItemProvider.Update(this.mock):");			
			System.Console.WriteLine(this.mock);
		}
		
		
		/// <summary>
		/// Delete the mock Item entity into the database.
		/// </summary>
		[Test]
		public void Step_05_Delete()
		{
			Assert.IsTrue(DataRepository.ItemProvider.Delete(transactionManager, this.mock), "Delete failed.");
			System.Console.WriteLine("DataRepository.ItemProvider.Delete(this.mock):");			
			System.Console.WriteLine(this.mock);
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Item entity into a temporary file.
		/// </summary>
		[Test]
		public void Step_06_SerializeEntity()
		{
			string fileName = "temp_Item.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Item)); 
			//StreamWriter myWriter = new StreamWriter(fileName); 
			//mySerializer.Serialize(myWriter, this.mock); 
			//myWriter.Close();
			EntityHelper.SerializeXml(this.mock, fileName);
			System.Console.WriteLine("this.mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock Item entity from a temporary file.
		/// </summary>
		[Test]
		public void Step_07_DeserializeEntity()
		{
			string fileName = "temp_Item.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Item)); 
			//FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			//this.mock = (Item) mySerializer.Deserialize(myFileStream);
			//myFileStream.Close();
			StreamReader sr = File.OpenText(fileName);
			object item = EntityHelper.DeserializeEntityXml<Item>(sr.ReadToEnd());
			sr.Close();
			File.Delete(fileName);
			
			System.Console.WriteLine("this.mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Item collection into a temporary file.
		/// </summary>
		[Test]
		public void Step_08_SerializeCollection()
		{
			string fileName = "temp_ItemCollection.xml";
		
			TList<Item> mockCollection = new TList<Item>();
			mockCollection.Add(this.mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Item>)); 
			StreamWriter myWriter = new StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("TList<Item> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a Item collection from a temporary file.
		/// </summary>
		[Test]
		public void Step_09_DeserializeCollection()
		{
			string fileName = "temp_ItemCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Item>)); 
			FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			TList<Item> mockCollection = (TList<Item>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			File.Delete(fileName);
			System.Console.WriteLine("TList<Item> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		[Test]
		public void Step_10_FK()
		{
			Item entity = mockCollection[0].Clone() as Item;
			
			TList<Item> t0 = DataRepository.ItemProvider.GetByProductId(transactionManager, entity.ProductId, 0, 10);
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		[Test]
		public void Step_11_IX()
		{
			Item entity = mockCollection[0].Clone() as Item;
			
			Item t0 = DataRepository.ItemProvider.GetById(transactionManager, entity.Id);
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		[Test]
		public void Step_20_TestEntityHelper()
		{
			Item entity = this.mock.Copy() as Item;
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Copy is working");

			entity = (Item)this.mock.Clone();
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Clone is working");
			
			Assert.IsTrue(entity.Equals(mock), "Clone is working");


			//Assert.IsTrue(EntityHelper.AreObjectsEqual(mockCollection[0], mockCollection[0]), "AreObjectEqual");
		}
		
		
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Item Entity with mock values.
		///</summary>
		public Item CreateMockInstance()
		{		
			Item mock = new Item();
						
			mock.Id = "QVRFXLOZCOVTIIXRA";
			mock.Name = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.Description = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.Price = 66.0f;
			mock.Currency = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.Photo = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			TList<Product> _collection0 = DataRepository.ProductProvider.GetAll(transactionManager, 0, 10);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.ProductId = _collection0[0].Id;
			}
		
			// create a temporary collection and add the item to it
			TList<Item> tempMockCollection = new TList<Item>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Item)mock;
		}
		
		
		///<summary>
		///  Update the Typed Item Entity with modified mock values.
		///</summary>
		public Item UpdateMockInstance(Item mock)
		{
			mock.Id = "QVRFXLOZCOVTIIXRA2";
			mock.Name = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.Description = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.Price = 66.0f;
			mock.Currency = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.Photo = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			TList<Product> _collection0 = DataRepository.ProductProvider.GetAll(transactionManager, 0, 10);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.ProductId = _collection0[0].Id;
			}
		   return (Item)mock;
		}

		#endregion
    }
}
