
#region Using directives

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using System.Collections.Generic;
using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;

#endregion

namespace netTiers.PetShop.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="ExtendedItem"/> objects (entity, collection and repository).
    /// </summary>
    [TestFixture]
    public class ExtendedItemTest
    {
    	// the ExtendedItem instance used to test the repository.
		private ExtendedItem mock;
		
		// the VList<ExtendedItem> instance used to test the repository.
		VList<ExtendedItem> mockCollection;
		
		/// <summary>
		/// Creates a new <see cref="ExtendedItemTest"/> instance.
		/// </summary>	
		public ExtendedItemTest()
		{			
			this.mock = (ExtendedItem)CreateMockInstance();	
		}
        
        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        [TestFixtureSetUp]
        public void Init()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the ExtendedItem Entity with the {0} --", netTiers.PetShop.DataAccessLayer.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
        [TestFixtureTearDown]
        public void Dispose()
        {       	
			System.Console.WriteLine();
			System.Console.WriteLine();
        }
        
		
		/// <summary>
		/// Selects all ExtendedItem objects of the database.
		/// </summary>
		[Test]
		public void Step_1_SelectAll()
		{
			mockCollection = DataRepository.ExtendedItemProvider.GetAll(0, 10);
			Assert.IsTrue(mockCollection.Count > 0, "No records returned.");
			System.Console.WriteLine("DataRepository.ExtendedItemProvider.GetAll():");			
			System.Console.WriteLine(mockCollection);			
		}
		
		/// <summary>
		/// Selects all ExtendedItem objects of the database.
		/// </summary>
		[Test]
		public void Step_2_Search()
		{
			mockCollection = DataRepository.ExtendedItemProvider.Get(0, 10);
			Assert.IsTrue(mockCollection.Count > 0, "No records returned.");
			System.Console.WriteLine("DataRepository.ExtendedItemProvider.Get():");			
			System.Console.WriteLine(mockCollection);
					
		}
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ExtendedItem entity into a temporary file.
		/// </summary>
		[Test]
		public void Step_6_SerializeEntity()
		{
			string fileName = "temp_ExtendedItem.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(ExtendedItem)); 
			StreamWriter myWriter = new StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, this.mock); 
			myWriter.Close();
			System.Console.WriteLine("this.mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock ExtendedItem entity from a temporary file.
		/// </summary>
		[Test]
		public void Step_7_DeserializeEntity()
		{
			string fileName = "temp_ExtendedItem.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(ExtendedItem)); 
			FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			this.mock = (ExtendedItem) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			File.Delete(fileName);
			
			System.Console.WriteLine("this.mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ExtendedItem collection into a temporary file.
		/// </summary>
		[Test]
		public void Step_8_SerializeCollection()
		{
			string fileName = "temp_ExtendedItemCollection.xml";
		
			VList<ExtendedItem> mockCollection = new VList<ExtendedItem>();
			mockCollection.Add(this.mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<ExtendedItem>)); 
			StreamWriter myWriter = new StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("VList<ExtendedItem> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a ExtendedItem collection from a temporary file.
		/// </summary>
		[Test]
		public void Step_9_DeserializeCollection()
		{
			string fileName = "temp_ExtendedItemCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<ExtendedItem>)); 
			FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			VList<ExtendedItem> mockCollection = (VList<ExtendedItem>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			File.Delete(fileName);
			System.Console.WriteLine("VList<ExtendedItem> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		#region Mock Instance
		///<summary>
		///  Returns a Typed ExtendedItem Entity with mock values.
		///</summary>
		public ExtendedItem CreateMockInstance()
		{		
			ExtendedItem mock = new ExtendedItem();
						
			mock.ItemId = "QVRFXLOZCOVTIIXRA";
			mock.ItemName = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.ItemDescription = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.ItemPrice = 94.0f;
			mock.ItemPhoto = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.ProductId = "QVRFXLOZCOVTIIXRA";
			mock.ProductName = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.ProductDescription = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.CategoryId = "QVRFXLOZCOVTIIXRA";
			mock.CategoryName = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
		   return (ExtendedItem)mock;
		}
		

		#endregion
    }
}
