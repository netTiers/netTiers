﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Monday, July 24, 2006
	Important: Do not modify this file. Edit the file OrdersTest.cs instead.
*/

#region Using directives

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="Orders"/> objects (entity, collection and repository).
    /// </summary>
   public partial class OrdersTest
    {
    	// the Orders instance used to test the repository.
		static private Orders mock;
		
		// the TList<Orders> instance used to test the repository.
		static TList<Orders> mockCollection;
		
		static TransactionManager transactionManager = null;
        
        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>        
        static public void Init_Generated()
        {
			mock = (Orders)CreateMockInstance();						
			
        	if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction();
			}
			
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the Orders Entity with the {0} --", netTiers.Petshop.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		static public void CleanUp_Generated()
        {   
        	if (DataRepository.Provider.IsTransactionSupported && transactionManager!=null && transactionManager.IsOpen)
			{
				transactionManager.Rollback();
			}
			
			System.Console.WriteLine();
			System.Console.WriteLine();
        }
    
    
		/// <summary>
		/// Inserts a mock Orders entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			Assert.IsTrue(DataRepository.OrdersProvider.Insert(transactionManager, mock), "Insert failed");
									
			System.Console.WriteLine("DataRepository.OrdersProvider.Insert(mock):");			
			System.Console.WriteLine(mock);			
		}
		
		
		/// <summary>
		/// Selects all Orders objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			mockCollection = DataRepository.OrdersProvider.GetAll(transactionManager);
			Assert.IsTrue(mockCollection.Count > 0, "No records returned.");
			System.Console.WriteLine("DataRepository.OrdersProvider.GetAll():");			
			System.Console.WriteLine(mockCollection);
					
			
			// get paged
			int count = 0;
			DataRepository.OrdersProvider.GetPaged(transactionManager, 0, 10, out count);
			System.Console.WriteLine("#get paged count: " + count.ToString());
		}
		
		
		
		
		/// <summary>
		/// Deep load all Orders children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			if (mockCollection.Count > 0)
			{
				//mockCollection.Shuffle();			
				DataRepository.OrdersProvider.DeepLoad(mockCollection[0]);
				System.Console.WriteLine("Orders instance correctly deep loaded at 1 level.");
								
				mockCollection.Add(mock);
				DataRepository.OrdersProvider.DeepSave(transactionManager, mockCollection);
			}			
		}
		
		/// <summary>
		/// Updates a mock Orders entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			UpdateMockInstance(mock);
			Assert.IsTrue(DataRepository.OrdersProvider.Update(transactionManager, mock), "Update failed.");			
		
			// TODO : select sur l'id
			// TODO : verif si l'object recup? est egal
			
			System.Console.WriteLine("DataRepository.OrdersProvider.Update(mock):");			
			System.Console.WriteLine(mock);
		}
		
		
		/// <summary>
		/// Delete the mock Orders entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			Assert.IsTrue(DataRepository.OrdersProvider.Delete(transactionManager, mock), "Delete failed.");
			System.Console.WriteLine("DataRepository.OrdersProvider.Delete(mock):");			
			System.Console.WriteLine(mock);
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Orders entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{
			string fileName = "temp_Orders.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Orders)); 
			//StreamWriter myWriter = new StreamWriter(fileName); 
			//mySerializer.Serialize(myWriter, this.mock); 
			//myWriter.Close();
			EntityHelper.SerializeXml(mock, fileName);
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock Orders entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = "temp_Orders.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Orders)); 
			//FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			//this.mock = (Orders) mySerializer.Deserialize(myFileStream);
			//myFileStream.Close();
			StreamReader sr = File.OpenText(fileName);
			object item = EntityHelper.DeserializeEntityXml<Orders>(sr.ReadToEnd());
			sr.Close();
			File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Orders collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			string fileName = "temp_OrdersCollection.xml";
		
			TList<Orders> mockCollection = new TList<Orders>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Orders>)); 
			StreamWriter myWriter = new StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("TList<Orders> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a Orders collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = "temp_OrdersCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Orders>)); 
			FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			TList<Orders> mockCollection = (TList<Orders>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			File.Delete(fileName);
			System.Console.WriteLine("TList<Orders> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			Orders entity = mockCollection[0].Clone() as Orders;
			
			TList<Orders> t0 = DataRepository.OrdersProvider.GetByAccountId(transactionManager, entity.AccountId, 0, 10);
			TList<Orders> t1 = DataRepository.OrdersProvider.GetByCourierId(transactionManager, entity.CourierId, 0, 10);
			TList<Orders> t2 = DataRepository.OrdersProvider.GetByCreditCardId(transactionManager, entity.CreditCardId, 0, 10);
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			Orders entity = mockCollection[0].Clone() as Orders;
			
			Orders t0 = DataRepository.OrdersProvider.GetByOrderId(transactionManager, entity.OrderId);
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			Orders entity = mock.Copy() as Orders;
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Copy is working");

			entity = (Orders)mock.Clone();
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Clone is working");
			
			Assert.IsTrue(entity.Equals(mock), "Clone is working");


			//Assert.IsTrue(EntityHelper.AreObjectsEqual(mockCollection[0], mockCollection[0]), "AreObjectEqual");
		}
		
		
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Orders Entity with mock values.
		///</summary>
		static public Orders CreateMockInstance()
		{		
			Orders mock = new Orders();
						
			mock.OrderDate = new DateTime(2006, 7, 24, 2, 39, 34, 296);
			mock.ShipAddr1 = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.ShipAddr2 = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.ShipCity = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.ShipState = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.ShipZip = "LMCMHLYZC";
			mock.ShipCountry = "LMCMHLYZC";
			mock.BillAddr1 = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.BillAddr2 = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.BillCity = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.BillState = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.BillZip = "LMCMHLYZC";
			mock.BillCountry = "LMCMHLYZC";
			mock.TotalPrice = 172m;
			mock.BillToFirstName = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.BillToLastName = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.ShipToFirstName = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.ShipToLastName = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB";
			mock.Locale = "LMCMHLYZC";
			
			TList<Account> _collection0 = DataRepository.AccountProvider.GetAll(transactionManager, 0, 10);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.AccountId = _collection0[0].Id;
			}
			TList<Courier> _collection1 = DataRepository.CourierProvider.GetAll(transactionManager, 0, 10);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.CourierId = _collection1[0].CourierId;
			}
			TList<CreditCard> _collection2 = DataRepository.CreditCardProvider.GetAll(transactionManager, 0, 10);
			//_collection2.Shuffle();
			if (_collection2.Count > 0)
			{
				mock.CreditCardId = _collection2[0].Id;
			}
		
			// create a temporary collection and add the item to it
			TList<Orders> tempMockCollection = new TList<Orders>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Orders)mock;
		}
		
		
		///<summary>
		///  Update the Typed Orders Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance(Orders mock)
		{
			mock.OrderDate = new DateTime(2006, 7, 24, 2, 39, 34, 296);
			mock.ShipAddr1 = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.ShipAddr2 = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.ShipCity = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.ShipState = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.ShipZip = "LMCMHLYZC2";
			mock.ShipCountry = "LMCMHLYZC2";
			mock.BillAddr1 = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.BillAddr2 = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.BillCity = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.BillState = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.BillZip = "LMCMHLYZC2";
			mock.BillCountry = "LMCMHLYZC2";
			mock.TotalPrice = 172m;
			mock.BillToFirstName = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.BillToLastName = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.ShipToFirstName = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.ShipToLastName = "DHBXVRKAVRBYMUHKHFTL[LPROQMWINPTZZHMJZB2";
			mock.Locale = "LMCMHLYZC2";
			
			TList<Account> _collection0 = DataRepository.AccountProvider.GetAll(transactionManager, 0, 10);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.AccountId = _collection0[0].Id;
			}
			TList<Courier> _collection1 = DataRepository.CourierProvider.GetAll(transactionManager, 0, 10);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.CourierId = _collection1[0].CourierId;
			}
			TList<CreditCard> _collection2 = DataRepository.CreditCardProvider.GetAll(transactionManager, 0, 10);
			//_collection2.Shuffle();
			if (_collection2.Count > 0)
			{
				mock.CreditCardId = _collection2[0].Id;
			}
		}

		#endregion
    }
}
