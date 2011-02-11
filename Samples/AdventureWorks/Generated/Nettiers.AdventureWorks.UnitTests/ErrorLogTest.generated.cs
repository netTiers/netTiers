﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file ErrorLogTest.cs instead.
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
    /// Provides tests for the and <see cref="ErrorLog"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ErrorLogTest
    {
    	// the ErrorLog instance used to test the repository.
		protected ErrorLog mock;
		
		// the TList<ErrorLog> instance used to test the repository.
		protected TList<ErrorLog> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the ErrorLog Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock ErrorLog entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ErrorLogProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ErrorLogProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all ErrorLog objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ErrorLogProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ErrorLogProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ErrorLogProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all ErrorLog children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ErrorLogProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ErrorLogProvider.DeepLoading += new EntityProviderBaseCore<ErrorLog, ErrorLogKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ErrorLogProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ErrorLog instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ErrorLogProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock ErrorLog entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ErrorLog mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ErrorLogProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ErrorLogProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ErrorLogProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock ErrorLog entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (ErrorLog)CreateMockInstance(tm);
				DataRepository.ErrorLogProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ErrorLogProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ErrorLogProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ErrorLog entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ErrorLog.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock ErrorLog entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ErrorLog.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ErrorLog>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ErrorLog collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ErrorLogCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<ErrorLog> mockCollection = new TList<ErrorLog>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ErrorLog> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a ErrorLog collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ErrorLogCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ErrorLog>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ErrorLog> mockCollection = (TList<ErrorLog>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ErrorLog> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ErrorLog entity = CreateMockInstance(tm);
				bool result = DataRepository.ErrorLogProvider.Insert(tm, entity);
				
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
				ErrorLog entity = CreateMockInstance(tm);
				bool result = DataRepository.ErrorLogProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				ErrorLog t0 = DataRepository.ErrorLogProvider.GetByErrorLogId(tm, entity.ErrorLogId);
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
				
				ErrorLog entity = mock.Copy() as ErrorLog;
				entity = (ErrorLog)mock.Clone();
				Assert.IsTrue(ErrorLog.ValueEquals(entity, mock), "Clone is not working");
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
				ErrorLog mock = CreateMockInstance(tm);
				bool result = DataRepository.ErrorLogProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ErrorLogQuery query = new ErrorLogQuery();
			
				query.AppendEquals(ErrorLogColumn.ErrorLogId, mock.ErrorLogId.ToString());
				query.AppendEquals(ErrorLogColumn.ErrorTime, mock.ErrorTime.ToString());
				query.AppendEquals(ErrorLogColumn.UserName, mock.UserName.ToString());
				query.AppendEquals(ErrorLogColumn.ErrorNumber, mock.ErrorNumber.ToString());
				if(mock.ErrorSeverity != null)
					query.AppendEquals(ErrorLogColumn.ErrorSeverity, mock.ErrorSeverity.ToString());
				if(mock.ErrorState != null)
					query.AppendEquals(ErrorLogColumn.ErrorState, mock.ErrorState.ToString());
				if(mock.ErrorProcedure != null)
					query.AppendEquals(ErrorLogColumn.ErrorProcedure, mock.ErrorProcedure.ToString());
				if(mock.ErrorLine != null)
					query.AppendEquals(ErrorLogColumn.ErrorLine, mock.ErrorLine.ToString());
				query.AppendEquals(ErrorLogColumn.ErrorMessage, mock.ErrorMessage.ToString());
				
				TList<ErrorLog> results = DataRepository.ErrorLogProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed ErrorLog Entity with mock values.
		///</summary>
		static public ErrorLog CreateMockInstance_Generated(TransactionManager tm)
		{		
			ErrorLog mock = new ErrorLog();
						
			mock.ErrorTime = TestUtility.Instance.RandomDateTime();
			mock.UserName = TestUtility.Instance.RandomString(63, false);;
			mock.ErrorNumber = TestUtility.Instance.RandomNumber();
			mock.ErrorSeverity = TestUtility.Instance.RandomNumber();
			mock.ErrorState = TestUtility.Instance.RandomNumber();
			mock.ErrorProcedure = TestUtility.Instance.RandomString(62, false);;
			mock.ErrorLine = TestUtility.Instance.RandomNumber();
			mock.ErrorMessage = TestUtility.Instance.RandomString(499, false);;
			
		
			// create a temporary collection and add the item to it
			TList<ErrorLog> tempMockCollection = new TList<ErrorLog>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (ErrorLog)mock;
		}
		
		
		///<summary>
		///  Update the Typed ErrorLog Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ErrorLog mock)
		{
			mock.ErrorTime = TestUtility.Instance.RandomDateTime();
			mock.UserName = TestUtility.Instance.RandomString(63, false);;
			mock.ErrorNumber = TestUtility.Instance.RandomNumber();
			mock.ErrorSeverity = TestUtility.Instance.RandomNumber();
			mock.ErrorState = TestUtility.Instance.RandomNumber();
			mock.ErrorProcedure = TestUtility.Instance.RandomString(62, false);;
			mock.ErrorLine = TestUtility.Instance.RandomNumber();
			mock.ErrorMessage = TestUtility.Instance.RandomString(499, false);;
			
		}
		#endregion
    }
}