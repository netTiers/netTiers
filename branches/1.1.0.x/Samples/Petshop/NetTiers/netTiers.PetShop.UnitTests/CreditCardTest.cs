

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
    /// Provides tests for the and <see cref="CreditCard"/> objects (entity, collection and repository).
    /// </summary>
    [TestFixture]
    public class CreditCardTest
    {
    	// the CreditCard instance used to test the repository.
		private CreditCard mock;
		
		// the TList<CreditCard> instance used to test the repository.
		TList<CreditCard> mockCollection;
		
		TransactionManager transactionManager = null;
		
		/// <summary>
		/// Creates a new <see cref="CreditCardTest"/> instance.
		/// </summary>	
		public CreditCardTest()
		{			
			this.mock = (CreditCard)CreateMockInstance();						
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
			System.Console.WriteLine("-- Testing the CreditCard Entity with the {0} --", netTiers.PetShop.DataAccessLayer.DataRepository.Provider.Name);
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
		/// Inserts a mock CreditCard entity into the database.
		/// </summary>
		[Test]
		public void Step_01_Insert()
		{
			Assert.IsTrue(DataRepository.CreditCardProvider.Insert(transactionManager, this.mock), "Insert failed");
									
			System.Console.WriteLine("DataRepository.CreditCardProvider.Insert(this.mock):");			
			System.Console.WriteLine(this.mock);			
		}
		
		
		/// <summary>
		/// Selects all CreditCard objects of the database.
		/// </summary>
		[Test]
		public void Step_02_SelectAll()
		{
			mockCollection = DataRepository.CreditCardProvider.GetAll(transactionManager);
			Assert.IsTrue(mockCollection.Count > 0, "No records returned.");
			System.Console.WriteLine("DataRepository.CreditCardProvider.GetAll():");			
			System.Console.WriteLine(mockCollection);
					
			
			// get paged
			int count = 0;
			DataRepository.CreditCardProvider.GetPaged(transactionManager, 0, 10, out count);
			System.Console.WriteLine("#get paged count: " + count.ToString());
		}
		
		
		
		
		/// <summary>
		/// Deep load all CreditCard children.
		/// </summary>
		[Test]
		public void Step_03_DeepLoad()
		{
			if (mockCollection.Count > 0)
			{
				//mockCollection.Shuffle();			
				DataRepository.CreditCardProvider.DeepLoad(mockCollection[0]);
				System.Console.WriteLine("CreditCard instance correctly deep loaded at 1 level.");
								
				//mockCollection.Shuffle();
				DataRepository.CreditCardProvider.DeepLoad(mockCollection[0], true);
				System.Console.WriteLine("CreditCard instance correctly deep loaded at N level.");
				
				mockCollection.Add(this.mock);
				DataRepository.CreditCardProvider.DeepSave(transactionManager, mockCollection);
				
			}			
		}
		
		/// <summary>
		/// Updates a mock CreditCard entity into the database.
		/// </summary>
		[Test]
		public void Step_04_Update()
		{
			this.mock = UpdateMockInstance(this.mock);
			Assert.IsTrue(DataRepository.CreditCardProvider.Update(transactionManager, this.mock), "Update failed.");			
		
			// TODO : select sur l'id
			// TODO : verif si l'object recup? est egal
			
			System.Console.WriteLine("DataRepository.CreditCardProvider.Update(this.mock):");			
			System.Console.WriteLine(this.mock);
		}
		
		
		/// <summary>
		/// Delete the mock CreditCard entity into the database.
		/// </summary>
		[Test]
		public void Step_05_Delete()
		{
			Assert.IsTrue(DataRepository.CreditCardProvider.Delete(transactionManager, this.mock), "Delete failed.");
			System.Console.WriteLine("DataRepository.CreditCardProvider.Delete(this.mock):");			
			System.Console.WriteLine(this.mock);
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock CreditCard entity into a temporary file.
		/// </summary>
		[Test]
		public void Step_06_SerializeEntity()
		{
			string fileName = "temp_CreditCard.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(CreditCard)); 
			//StreamWriter myWriter = new StreamWriter(fileName); 
			//mySerializer.Serialize(myWriter, this.mock); 
			//myWriter.Close();
			EntityHelper.SerializeXml(this.mock, fileName);
			System.Console.WriteLine("this.mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock CreditCard entity from a temporary file.
		/// </summary>
		[Test]
		public void Step_07_DeserializeEntity()
		{
			string fileName = "temp_CreditCard.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(CreditCard)); 
			//FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			//this.mock = (CreditCard) mySerializer.Deserialize(myFileStream);
			//myFileStream.Close();
			StreamReader sr = File.OpenText(fileName);
			object item = EntityHelper.DeserializeEntityXml<CreditCard>(sr.ReadToEnd());
			sr.Close();
			File.Delete(fileName);
			
			System.Console.WriteLine("this.mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a CreditCard collection into a temporary file.
		/// </summary>
		[Test]
		public void Step_08_SerializeCollection()
		{
			string fileName = "temp_CreditCardCollection.xml";
		
			TList<CreditCard> mockCollection = new TList<CreditCard>();
			mockCollection.Add(this.mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<CreditCard>)); 
			StreamWriter myWriter = new StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("TList<CreditCard> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a CreditCard collection from a temporary file.
		/// </summary>
		[Test]
		public void Step_09_DeserializeCollection()
		{
			string fileName = "temp_CreditCardCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<CreditCard>)); 
			FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			TList<CreditCard> mockCollection = (TList<CreditCard>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			File.Delete(fileName);
			System.Console.WriteLine("TList<CreditCard> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		[Test]
		public void Step_10_FK()
		{
			CreditCard entity = mockCollection[0].Clone() as CreditCard;
			
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		[Test]
		public void Step_11_IX()
		{
			CreditCard entity = mockCollection[0].Clone() as CreditCard;
			
			CreditCard t0 = DataRepository.CreditCardProvider.GetById(transactionManager, entity.Id);
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		[Test]
		public void Step_20_TestEntityHelper()
		{
			CreditCard entity = this.mock.Copy() as CreditCard;
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Copy is working");

			entity = (CreditCard)this.mock.Clone();
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Clone is working");
			
			Assert.IsTrue(entity.Equals(mock), "Clone is working");


			//Assert.IsTrue(EntityHelper.AreObjectsEqual(mockCollection[0], mockCollection[0]), "AreObjectEqual");
		}
		
		
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed CreditCard Entity with mock values.
		///</summary>
		public CreditCard CreateMockInstance()
		{		
			CreditCard mock = new CreditCard();
						
			mock.Id = "QVRFXLOZCOVTIIXRA";
			mock.Number = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.CardType = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.ExpiryMonth = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.ExpiryYear = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
		
			// create a temporary collection and add the item to it
			TList<CreditCard> tempMockCollection = new TList<CreditCard>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (CreditCard)mock;
		}
		
		
		///<summary>
		///  Update the Typed CreditCard Entity with modified mock values.
		///</summary>
		public CreditCard UpdateMockInstance(CreditCard mock)
		{
			mock.Id = "QVRFXLOZCOVTIIXRA2";
			mock.Number = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.CardType = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.ExpiryMonth = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.ExpiryYear = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
		   return (CreditCard)mock;
		}

		#endregion
    }
}
