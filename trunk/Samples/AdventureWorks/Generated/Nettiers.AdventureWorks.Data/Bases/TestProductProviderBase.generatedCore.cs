#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="TestProductProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TestProductProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.TestProduct, Nettiers.AdventureWorks.Entities.TestProductKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestProductKey key)
		{
			return Delete(transactionManager, key.ProductId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productId)
		{
			return Delete(null, _productId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override Nettiers.AdventureWorks.Entities.TestProduct Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestProductKey key, int start, int pageLength)
		{
			return GetByProductId(transactionManager, key.ProductId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblTestProduct index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestProduct GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTestProduct index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestProduct GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTestProduct index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestProduct GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTestProduct index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestProduct GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTestProduct index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.TestProduct GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTestProduct index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.TestProduct GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TestProduct&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TestProduct&gt;"/></returns>
		public static TList<TestProduct> Fill(IDataReader reader, TList<TestProduct> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				Nettiers.AdventureWorks.Entities.TestProduct c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TestProduct")
					.Append("|").Append((System.Int32)reader[((int)TestProductColumn.ProductId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TestProduct>(
					key.ToString(), // EntityTrackingKey
					"TestProduct",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.TestProduct();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.ProductId = (System.Int32)reader[((int)TestProductColumn.ProductId - 1)];
					c.ProductTypeId = (reader.IsDBNull(((int)TestProductColumn.ProductTypeId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.ProductTypeId - 1)];
					c.DownloadId = (reader.IsDBNull(((int)TestProductColumn.DownloadId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.DownloadId - 1)];
					c.ManufacturerId = (reader.IsDBNull(((int)TestProductColumn.ManufacturerId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.ManufacturerId - 1)];
					c.BrandName = (reader.IsDBNull(((int)TestProductColumn.BrandName - 1)))?null:(System.String)reader[((int)TestProductColumn.BrandName - 1)];
					c.ProductName = (reader.IsDBNull(((int)TestProductColumn.ProductName - 1)))?null:(System.String)reader[((int)TestProductColumn.ProductName - 1)];
					c.ProductCode = (reader.IsDBNull(((int)TestProductColumn.ProductCode - 1)))?null:(System.String)reader[((int)TestProductColumn.ProductCode - 1)];
					c.UniqueIdentifier = (reader.IsDBNull(((int)TestProductColumn.UniqueIdentifier - 1)))?null:(System.String)reader[((int)TestProductColumn.UniqueIdentifier - 1)];
					c.TypeName = (reader.IsDBNull(((int)TestProductColumn.TypeName - 1)))?null:(System.String)reader[((int)TestProductColumn.TypeName - 1)];
					c.ModelName = (reader.IsDBNull(((int)TestProductColumn.ModelName - 1)))?null:(System.String)reader[((int)TestProductColumn.ModelName - 1)];
					c.DisplayName = (reader.IsDBNull(((int)TestProductColumn.DisplayName - 1)))?null:(System.String)reader[((int)TestProductColumn.DisplayName - 1)];
					c.ProductLink = (reader.IsDBNull(((int)TestProductColumn.ProductLink - 1)))?null:(System.String)reader[((int)TestProductColumn.ProductLink - 1)];
					c.ConnectorCode = (reader.IsDBNull(((int)TestProductColumn.ConnectorCode - 1)))?null:(System.String)reader[((int)TestProductColumn.ConnectorCode - 1)];
					c.BaseId = (reader.IsDBNull(((int)TestProductColumn.BaseId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.BaseId - 1)];
					c.OrgProductId = (reader.IsDBNull(((int)TestProductColumn.OrgProductId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.OrgProductId - 1)];
					c.ImageFileType = (reader.IsDBNull(((int)TestProductColumn.ImageFileType - 1)))?null:(System.String)reader[((int)TestProductColumn.ImageFileType - 1)];
					c.FullImageFileType = (reader.IsDBNull(((int)TestProductColumn.FullImageFileType - 1)))?null:(System.String)reader[((int)TestProductColumn.FullImageFileType - 1)];
					c.Status = (reader.IsDBNull(((int)TestProductColumn.Status - 1)))?null:(System.String)reader[((int)TestProductColumn.Status - 1)];
					c.AddedBy = (reader.IsDBNull(((int)TestProductColumn.AddedBy - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.AddedBy - 1)];
					c.AddedDate = (reader.IsDBNull(((int)TestProductColumn.AddedDate - 1)))?null:(System.DateTime?)reader[((int)TestProductColumn.AddedDate - 1)];
					c.UpdatedBy = (reader.IsDBNull(((int)TestProductColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.UpdatedBy - 1)];
					c.UpdatedDate = (reader.IsDBNull(((int)TestProductColumn.UpdatedDate - 1)))?null:(System.DateTime?)reader[((int)TestProductColumn.UpdatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.TestProduct entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductId = (System.Int32)reader[((int)TestProductColumn.ProductId - 1)];
			entity.ProductTypeId = (reader.IsDBNull(((int)TestProductColumn.ProductTypeId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.ProductTypeId - 1)];
			entity.DownloadId = (reader.IsDBNull(((int)TestProductColumn.DownloadId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.DownloadId - 1)];
			entity.ManufacturerId = (reader.IsDBNull(((int)TestProductColumn.ManufacturerId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.ManufacturerId - 1)];
			entity.BrandName = (reader.IsDBNull(((int)TestProductColumn.BrandName - 1)))?null:(System.String)reader[((int)TestProductColumn.BrandName - 1)];
			entity.ProductName = (reader.IsDBNull(((int)TestProductColumn.ProductName - 1)))?null:(System.String)reader[((int)TestProductColumn.ProductName - 1)];
			entity.ProductCode = (reader.IsDBNull(((int)TestProductColumn.ProductCode - 1)))?null:(System.String)reader[((int)TestProductColumn.ProductCode - 1)];
			entity.UniqueIdentifier = (reader.IsDBNull(((int)TestProductColumn.UniqueIdentifier - 1)))?null:(System.String)reader[((int)TestProductColumn.UniqueIdentifier - 1)];
			entity.TypeName = (reader.IsDBNull(((int)TestProductColumn.TypeName - 1)))?null:(System.String)reader[((int)TestProductColumn.TypeName - 1)];
			entity.ModelName = (reader.IsDBNull(((int)TestProductColumn.ModelName - 1)))?null:(System.String)reader[((int)TestProductColumn.ModelName - 1)];
			entity.DisplayName = (reader.IsDBNull(((int)TestProductColumn.DisplayName - 1)))?null:(System.String)reader[((int)TestProductColumn.DisplayName - 1)];
			entity.ProductLink = (reader.IsDBNull(((int)TestProductColumn.ProductLink - 1)))?null:(System.String)reader[((int)TestProductColumn.ProductLink - 1)];
			entity.ConnectorCode = (reader.IsDBNull(((int)TestProductColumn.ConnectorCode - 1)))?null:(System.String)reader[((int)TestProductColumn.ConnectorCode - 1)];
			entity.BaseId = (reader.IsDBNull(((int)TestProductColumn.BaseId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.BaseId - 1)];
			entity.OrgProductId = (reader.IsDBNull(((int)TestProductColumn.OrgProductId - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.OrgProductId - 1)];
			entity.ImageFileType = (reader.IsDBNull(((int)TestProductColumn.ImageFileType - 1)))?null:(System.String)reader[((int)TestProductColumn.ImageFileType - 1)];
			entity.FullImageFileType = (reader.IsDBNull(((int)TestProductColumn.FullImageFileType - 1)))?null:(System.String)reader[((int)TestProductColumn.FullImageFileType - 1)];
			entity.Status = (reader.IsDBNull(((int)TestProductColumn.Status - 1)))?null:(System.String)reader[((int)TestProductColumn.Status - 1)];
			entity.AddedBy = (reader.IsDBNull(((int)TestProductColumn.AddedBy - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.AddedBy - 1)];
			entity.AddedDate = (reader.IsDBNull(((int)TestProductColumn.AddedDate - 1)))?null:(System.DateTime?)reader[((int)TestProductColumn.AddedDate - 1)];
			entity.UpdatedBy = (reader.IsDBNull(((int)TestProductColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)TestProductColumn.UpdatedBy - 1)];
			entity.UpdatedDate = (reader.IsDBNull(((int)TestProductColumn.UpdatedDate - 1)))?null:(System.DateTime?)reader[((int)TestProductColumn.UpdatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.TestProduct entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.ProductTypeId = Convert.IsDBNull(dataRow["ProductTypeID"]) ? null : (System.Int32?)dataRow["ProductTypeID"];
			entity.DownloadId = Convert.IsDBNull(dataRow["DownloadID"]) ? null : (System.Int32?)dataRow["DownloadID"];
			entity.ManufacturerId = Convert.IsDBNull(dataRow["ManufacturerID"]) ? null : (System.Int32?)dataRow["ManufacturerID"];
			entity.BrandName = Convert.IsDBNull(dataRow["BrandName"]) ? null : (System.String)dataRow["BrandName"];
			entity.ProductName = Convert.IsDBNull(dataRow["ProductName"]) ? null : (System.String)dataRow["ProductName"];
			entity.ProductCode = Convert.IsDBNull(dataRow["ProductCode"]) ? null : (System.String)dataRow["ProductCode"];
			entity.UniqueIdentifier = Convert.IsDBNull(dataRow["UniqueIdentifier"]) ? null : (System.String)dataRow["UniqueIdentifier"];
			entity.TypeName = Convert.IsDBNull(dataRow["TypeName"]) ? null : (System.String)dataRow["TypeName"];
			entity.ModelName = Convert.IsDBNull(dataRow["ModelName"]) ? null : (System.String)dataRow["ModelName"];
			entity.DisplayName = Convert.IsDBNull(dataRow["DisplayName"]) ? null : (System.String)dataRow["DisplayName"];
			entity.ProductLink = Convert.IsDBNull(dataRow["ProductLink"]) ? null : (System.String)dataRow["ProductLink"];
			entity.ConnectorCode = Convert.IsDBNull(dataRow["ConnectorCode"]) ? null : (System.String)dataRow["ConnectorCode"];
			entity.BaseId = Convert.IsDBNull(dataRow["BaseID"]) ? null : (System.Int32?)dataRow["BaseID"];
			entity.OrgProductId = Convert.IsDBNull(dataRow["OrgProductID"]) ? null : (System.Int32?)dataRow["OrgProductID"];
			entity.ImageFileType = Convert.IsDBNull(dataRow["ImageFileType"]) ? null : (System.String)dataRow["ImageFileType"];
			entity.FullImageFileType = Convert.IsDBNull(dataRow["FullImageFileType"]) ? null : (System.String)dataRow["FullImageFileType"];
			entity.Status = Convert.IsDBNull(dataRow["Status"]) ? null : (System.String)dataRow["Status"];
			entity.AddedBy = Convert.IsDBNull(dataRow["AddedBy"]) ? null : (System.Int32?)dataRow["AddedBy"];
			entity.AddedDate = Convert.IsDBNull(dataRow["AddedDate"]) ? null : (System.DateTime?)dataRow["AddedDate"];
			entity.UpdatedBy = Convert.IsDBNull(dataRow["UpdatedBy"]) ? null : (System.Int32?)dataRow["UpdatedBy"];
			entity.UpdatedDate = Convert.IsDBNull(dataRow["UpdatedDate"]) ? null : (System.DateTime?)dataRow["UpdatedDate"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.TestProduct"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TestProduct Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestProduct entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			DeepHandles deepHandles = new DeepHandles();
			
			//Fire all DeepLoad Items
			deepHandles.InvokeAll();
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.TestProduct object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.TestProduct instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.TestProduct Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TestProduct entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			DeepHandles deepHandles = new DeepHandles();
			//Fire all DeepSave Items
			if (deepHandles.ContainsDuplicates())
				innerList.CancelSession = true;
			else
				deepHandles.InvokeAll();
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region TestProductChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.TestProduct</c>
	///</summary>
	public enum TestProductChildEntityTypes
	{
	}
	
	#endregion TestProductChildEntityTypes
	
	#region TestProductFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TestProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestProductFilterBuilder : SqlFilterBuilder<TestProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestProductFilterBuilder class.
		/// </summary>
		public TestProductFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestProductFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestProductFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestProductFilterBuilder
	
	#region TestProductParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TestProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestProductParameterBuilder : ParameterizedSqlFilterBuilder<TestProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestProductParameterBuilder class.
		/// </summary>
		public TestProductParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TestProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TestProductParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TestProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TestProductParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TestProductParameterBuilder
	
	#region TestProductSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TestProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestProduct"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TestProductSortBuilder : SqlSortBuilder<TestProductColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestProductSqlSortBuilder class.
		/// </summary>
		public TestProductSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TestProductSortBuilder
	
} // end namespace
