

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
    /// Provides tests for the and <see cref="Account"/> objects (entity, collection and repository).
    /// </summary>
    [TestFixture]
    public class AccountTest
    {
    	// the Account instance used to test the repository.
		private Account mock;
		
		// the TList<Account> instance used to test the repository.
		TList<Account> mockCollection;
		
		TransactionManager transactionManager = null;
		
		/// <summary>
		/// Creates a new <see cref="AccountTest"/> instance.
		/// </summary>	
		public AccountTest()
		{			
			this.mock = (Account)CreateMockInstance();						
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
			System.Console.WriteLine("-- Testing the Account Entity with the {0} --", netTiers.PetShop.DataAccessLayer.DataRepository.Provider.Name);
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
		/// Inserts a mock Account entity into the database.
		/// </summary>
		[Test]
		public void Step_01_Insert()
		{
			Assert.IsTrue(DataRepository.AccountProvider.Insert(transactionManager, this.mock), "Insert failed");
									
			System.Console.WriteLine("DataRepository.AccountProvider.Insert(this.mock):");			
			System.Console.WriteLine(this.mock);			
		}
		
		
		/// <summary>
		/// Selects all Account objects of the database.
		/// </summary>
		[Test]
		public void Step_02_SelectAll()
		{
			mockCollection = DataRepository.AccountProvider.GetAll(transactionManager);
			Assert.IsTrue(mockCollection.Count > 0, "No records returned.");
			System.Console.WriteLine("DataRepository.AccountProvider.GetAll():");			
			System.Console.WriteLine(mockCollection);
					
			
			// get paged
			int count = 0;
			DataRepository.AccountProvider.GetPaged(transactionManager, 0, 10, out count);
			System.Console.WriteLine("#get paged count: " + count.ToString());
		}
		
		
		
		
		/// <summary>
		/// Deep load all Account children.
		/// </summary>
		[Test]
		public void Step_03_DeepLoad()
		{
			if (mockCollection.Count > 0)
			{
				//mockCollection.Shuffle();			
				DataRepository.AccountProvider.DeepLoad(mockCollection[0]);
				System.Console.WriteLine("Account instance correctly deep loaded at 1 level.");
								
				//mockCollection.Shuffle();
				DataRepository.AccountProvider.DeepLoad(mockCollection[0], true);
				System.Console.WriteLine("Account instance correctly deep loaded at N level.");
				
				mockCollection.Add(this.mock);
				DataRepository.AccountProvider.DeepSave(transactionManager, mockCollection);
				
			}			
		}
		
		/// <summary>
		/// Updates a mock Account entity into the database.
		/// </summary>
		[Test]
		public void Step_04_Update()
		{
			this.mock = UpdateMockInstance(this.mock);
			Assert.IsTrue(DataRepository.AccountProvider.Update(transactionManager, this.mock), "Update failed.");			
		
			// TODO : select sur l'id
			// TODO : verif si l'object recup? est egal
			
			System.Console.WriteLine("DataRepository.AccountProvider.Update(this.mock):");			
			System.Console.WriteLine(this.mock);
		}
		
		
		/// <summary>
		/// Delete the mock Account entity into the database.
		/// </summary>
		[Test]
		public void Step_05_Delete()
		{
			Assert.IsTrue(DataRepository.AccountProvider.Delete(transactionManager, this.mock), "Delete failed.");
			System.Console.WriteLine("DataRepository.AccountProvider.Delete(this.mock):");			
			System.Console.WriteLine(this.mock);
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Account entity into a temporary file.
		/// </summary>
		[Test]
		public void Step_06_SerializeEntity()
		{
			string fileName = "temp_Account.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Account)); 
			//StreamWriter myWriter = new StreamWriter(fileName); 
			//mySerializer.Serialize(myWriter, this.mock); 
			//myWriter.Close();
			EntityHelper.SerializeXml(this.mock, fileName);
			System.Console.WriteLine("this.mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock Account entity from a temporary file.
		/// </summary>
		[Test]
		public void Step_07_DeserializeEntity()
		{
			string fileName = "temp_Account.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Account)); 
			//FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			//this.mock = (Account) mySerializer.Deserialize(myFileStream);
			//myFileStream.Close();
			StreamReader sr = File.OpenText(fileName);
			object item = EntityHelper.DeserializeEntityXml<Account>(sr.ReadToEnd());
			sr.Close();
			File.Delete(fileName);
			
			System.Console.WriteLine("this.mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Account collection into a temporary file.
		/// </summary>
		[Test]
		public void Step_08_SerializeCollection()
		{
			string fileName = "temp_AccountCollection.xml";
		
			TList<Account> mockCollection = new TList<Account>();
			mockCollection.Add(this.mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Account>)); 
			StreamWriter myWriter = new StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("TList<Account> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a Account collection from a temporary file.
		/// </summary>
		[Test]
		public void Step_09_DeserializeCollection()
		{
			string fileName = "temp_AccountCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Account>)); 
			FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			TList<Account> mockCollection = (TList<Account>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			File.Delete(fileName);
			System.Console.WriteLine("TList<Account> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		[Test]
		public void Step_10_FK()
		{
			Account entity = mockCollection[0].Clone() as Account;
			
			TList<Account> t0 = DataRepository.AccountProvider.GetByFavoriteCategoryId(transactionManager, entity.FavoriteCategoryId, 0, 10);
			TList<Account> t1 = DataRepository.AccountProvider.GetByCreditCardId(transactionManager, entity.CreditCardId, 0, 10);
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		[Test]
		public void Step_11_IX()
		{
			Account entity = mockCollection[0].Clone() as Account;
			
			Account t0 = DataRepository.AccountProvider.GetById(transactionManager, entity.Id);
			Account t1 = DataRepository.AccountProvider.GetByLogin(transactionManager, entity.Login);
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		[Test]
		public void Step_20_TestEntityHelper()
		{
			Account entity = this.mock.Copy() as Account;
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Copy is working");

			entity = (Account)this.mock.Clone();
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Clone is working");
			
			Assert.IsTrue(entity.Equals(mock), "Clone is working");


			//Assert.IsTrue(EntityHelper.AreObjectsEqual(mockCollection[0], mockCollection[0]), "AreObjectEqual");
		}
		
		
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Account Entity with mock values.
		///</summary>
		public Account CreateMockInstance()
		{		
			Account mock = new Account();
						
			mock.Id = "QVRFXLOZCOVTIIXRA";
			mock.FirstName = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.LastName = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.StreetAddress = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.PostalCode = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.City = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.StateOrProvince = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.Country = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.TelephoneNumber = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.Email = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.Login = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.Password = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.IWantMyList = false;
			mock.IWantPetTips = false;
			mock.FavoriteLanguage = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			TList<Category> _collection0 = DataRepository.CategoryProvider.GetAll(transactionManager, 0, 10);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.FavoriteCategoryId = _collection0[0].Id;
			}
			TList<CreditCard> _collection1 = DataRepository.CreditCardProvider.GetAll(transactionManager, 0, 10);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.CreditCardId = _collection1[0].Id;
			}
		
			// create a temporary collection and add the item to it
			TList<Account> tempMockCollection = new TList<Account>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Account)mock;
		}
		
		
		///<summary>
		///  Update the Typed Account Entity with modified mock values.
		///</summary>
		public Account UpdateMockInstance(Account mock)
		{
			mock.Id = "QVRFXLOZCOVTIIXRA2";
			mock.FirstName = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.LastName = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.StreetAddress = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.PostalCode = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.City = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.StateOrProvince = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.Country = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.TelephoneNumber = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.Email = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.Login = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.Password = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.IWantMyList = true;
			mock.IWantPetTips = true;
			mock.FavoriteLanguage = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			TList<Category> _collection0 = DataRepository.CategoryProvider.GetAll(transactionManager, 0, 10);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.FavoriteCategoryId = _collection0[0].Id;
			}
			TList<CreditCard> _collection1 = DataRepository.CreditCardProvider.GetAll(transactionManager, 0, 10);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.CreditCardId = _collection1[0].Id;
			}
		   return (Account)mock;
		}

		#endregion
    }
}
