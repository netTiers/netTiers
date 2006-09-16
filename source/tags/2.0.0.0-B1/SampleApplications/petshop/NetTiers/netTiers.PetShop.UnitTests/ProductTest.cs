

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
    /// Provides tests for the and <see cref="Product"/> objects (entity, collection and repository).
    /// </summary>
    [TestFixture]
    public class ProductTest
    {
    	// the Product instance used to test the repository.
		private Product mock;
		
		// the TList<Product> instance used to test the repository.
		TList<Product> mockCollection;
		
		TransactionManager transactionManager = null;
		
		/// <summary>
		/// Creates a new <see cref="ProductTest"/> instance.
		/// </summary>	
		public ProductTest()
		{			
			this.mock = (Product)CreateMockInstance();						
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
			System.Console.WriteLine("-- Testing the Product Entity with the {0} --", netTiers.PetShop.DataAccessLayer.DataRepository.Provider.Name);
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
		/// Inserts a mock Product entity into the database.
		/// </summary>
		[Test]
		public void Step_01_Insert()
		{
			Assert.IsTrue(DataRepository.ProductProvider.Insert(transactionManager, this.mock), "Insert failed");
									
			System.Console.WriteLine("DataRepository.ProductProvider.Insert(this.mock):");			
			System.Console.WriteLine(this.mock);			
		}
		
		
		/// <summary>
		/// Selects all Product objects of the database.
		/// </summary>
		[Test]
		public void Step_02_SelectAll()
		{
			mockCollection = DataRepository.ProductProvider.GetAll(transactionManager);
			Assert.IsTrue(mockCollection.Count > 0, "No records returned.");
			System.Console.WriteLine("DataRepository.ProductProvider.GetAll():");			
			System.Console.WriteLine(mockCollection);
					
			
			// get paged
			int count = 0;
			DataRepository.ProductProvider.GetPaged(transactionManager, 0, 10, out count);
			System.Console.WriteLine("#get paged count: " + count.ToString());
		}
		
		
		
		
		/// <summary>
		/// Deep load all Product children.
		/// </summary>
		[Test]
		public void Step_03_DeepLoad()
		{
			if (mockCollection.Count > 0)
			{
				//mockCollection.Shuffle();			
				DataRepository.ProductProvider.DeepLoad(mockCollection[0]);
				System.Console.WriteLine("Product instance correctly deep loaded at 1 level.");
								
				//mockCollection.Shuffle();
				DataRepository.ProductProvider.DeepLoad(mockCollection[0], true);
				System.Console.WriteLine("Product instance correctly deep loaded at N level.");
				
				mockCollection.Add(this.mock);
				DataRepository.ProductProvider.DeepSave(transactionManager, mockCollection);
				
			}			
		}
		
		/// <summary>
		/// Updates a mock Product entity into the database.
		/// </summary>
		[Test]
		public void Step_04_Update()
		{
			this.mock = UpdateMockInstance(this.mock);
			Assert.IsTrue(DataRepository.ProductProvider.Update(transactionManager, this.mock), "Update failed.");			
		
			// TODO : select sur l'id
			// TODO : verif si l'object recup? est egal
			
			System.Console.WriteLine("DataRepository.ProductProvider.Update(this.mock):");			
			System.Console.WriteLine(this.mock);
		}
		
		
		/// <summary>
		/// Delete the mock Product entity into the database.
		/// </summary>
		[Test]
		public void Step_05_Delete()
		{
			Assert.IsTrue(DataRepository.ProductProvider.Delete(transactionManager, this.mock), "Delete failed.");
			System.Console.WriteLine("DataRepository.ProductProvider.Delete(this.mock):");			
			System.Console.WriteLine(this.mock);
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Product entity into a temporary file.
		/// </summary>
		[Test]
		public void Step_06_SerializeEntity()
		{
			string fileName = "temp_Product.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Product)); 
			//StreamWriter myWriter = new StreamWriter(fileName); 
			//mySerializer.Serialize(myWriter, this.mock); 
			//myWriter.Close();
			EntityHelper.SerializeXml(this.mock, fileName);
			System.Console.WriteLine("this.mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock Product entity from a temporary file.
		/// </summary>
		[Test]
		public void Step_07_DeserializeEntity()
		{
			string fileName = "temp_Product.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Product)); 
			//FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			//this.mock = (Product) mySerializer.Deserialize(myFileStream);
			//myFileStream.Close();
			StreamReader sr = File.OpenText(fileName);
			object item = EntityHelper.DeserializeEntityXml<Product>(sr.ReadToEnd());
			sr.Close();
			File.Delete(fileName);
			
			System.Console.WriteLine("this.mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Product collection into a temporary file.
		/// </summary>
		[Test]
		public void Step_08_SerializeCollection()
		{
			string fileName = "temp_ProductCollection.xml";
		
			TList<Product> mockCollection = new TList<Product>();
			mockCollection.Add(this.mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Product>)); 
			StreamWriter myWriter = new StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("TList<Product> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a Product collection from a temporary file.
		/// </summary>
		[Test]
		public void Step_09_DeserializeCollection()
		{
			string fileName = "temp_ProductCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Product>)); 
			FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			TList<Product> mockCollection = (TList<Product>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			File.Delete(fileName);
			System.Console.WriteLine("TList<Product> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		[Test]
		public void Step_10_FK()
		{
			Product entity = mockCollection[0].Clone() as Product;
			
			TList<Product> t0 = DataRepository.ProductProvider.GetByCategoryId(transactionManager, entity.CategoryId, 0, 10);
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		[Test]
		public void Step_11_IX()
		{
			Product entity = mockCollection[0].Clone() as Product;
			
			Product t0 = DataRepository.ProductProvider.GetById(transactionManager, entity.Id);
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		[Test]
		public void Step_20_TestEntityHelper()
		{
			Product entity = this.mock.Copy() as Product;
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Copy is working");

			entity = (Product)this.mock.Clone();
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Clone is working");
			
			Assert.IsTrue(entity.Equals(mock), "Clone is working");


			//Assert.IsTrue(EntityHelper.AreObjectsEqual(mockCollection[0], mockCollection[0]), "AreObjectEqual");
		}
		
		
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Product Entity with mock values.
		///</summary>
		public Product CreateMockInstance()
		{		
			Product mock = new Product();
						
			mock.Id = "QVRFXLOZCOVTIIXRA";
			mock.Name = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.Description = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			TList<Category> _collection0 = DataRepository.CategoryProvider.GetAll(transactionManager, 0, 10);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.CategoryId = _collection0[0].Id;
			}
		
			// create a temporary collection and add the item to it
			TList<Product> tempMockCollection = new TList<Product>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Product)mock;
		}
		
		
		///<summary>
		///  Update the Typed Product Entity with modified mock values.
		///</summary>
		public Product UpdateMockInstance(Product mock)
		{
			mock.Id = "QVRFXLOZCOVTIIXRA2";
			mock.Name = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.Description = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			TList<Category> _collection0 = DataRepository.CategoryProvider.GetAll(transactionManager, 0, 10);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.CategoryId = _collection0[0].Id;
			}
		   return (Product)mock;
		}

		#endregion
    }
}
