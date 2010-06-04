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
	/// This class is the base class for any <see cref="CultureProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CultureProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.Culture, Nettiers.AdventureWorks.Entities.CultureKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByProductDescriptionIdFromProductModelProductDescriptionCulture
		
		/// <summary>
		///		Gets Culture objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <returns>Returns a typed collection of Culture objects.</returns>
		public TList<Culture> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(System.Int32 _productDescriptionId)
		{
			int count = -1;
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(null,_productDescriptionId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Culture objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Culture objects.</returns>
		public TList<Culture> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(System.Int32 _productDescriptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(null, _productDescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Culture objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Culture objects.</returns>
		public TList<Culture> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.Int32 _productDescriptionId)
		{
			int count = -1;
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(transactionManager, _productDescriptionId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Culture objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Culture objects.</returns>
		public TList<Culture> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.Int32 _productDescriptionId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(transactionManager, _productDescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Culture objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Culture objects.</returns>
		public TList<Culture> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(System.Int32 _productDescriptionId,int start, int pageLength, out int count)
		{
			
			return GetByProductDescriptionIdFromProductModelProductDescriptionCulture(null, _productDescriptionId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Culture objects from the datasource by ProductDescriptionID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductDescription
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productDescriptionId">Primary key. Foreign key to ProductDescription.ProductDescriptionID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Culture objects.</returns>
		public abstract TList<Culture> GetByProductDescriptionIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager,System.Int32 _productDescriptionId, int start, int pageLength, out int count);
		
		#endregion GetByProductDescriptionIdFromProductModelProductDescriptionCulture
		
		#region GetByProductModelIdFromProductModelProductDescriptionCulture
		
		/// <summary>
		///		Gets Culture objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <returns>Returns a typed collection of Culture objects.</returns>
		public TList<Culture> GetByProductModelIdFromProductModelProductDescriptionCulture(System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelProductDescriptionCulture(null,_productModelId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.Culture objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Culture objects.</returns>
		public TList<Culture> GetByProductModelIdFromProductModelProductDescriptionCulture(System.Int32 _productModelId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelProductDescriptionCulture(null, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Culture objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Culture objects.</returns>
		public TList<Culture> GetByProductModelIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.Int32 _productModelId)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelProductDescriptionCulture(transactionManager, _productModelId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Culture objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Culture objects.</returns>
		public TList<Culture> GetByProductModelIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.Int32 _productModelId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductModelIdFromProductModelProductDescriptionCulture(transactionManager, _productModelId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Culture objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Culture objects.</returns>
		public TList<Culture> GetByProductModelIdFromProductModelProductDescriptionCulture(System.Int32 _productModelId,int start, int pageLength, out int count)
		{
			
			return GetByProductModelIdFromProductModelProductDescriptionCulture(null, _productModelId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Culture objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table Culture is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Culture objects.</returns>
		public abstract TList<Culture> GetByProductModelIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager,System.Int32 _productModelId, int start, int pageLength, out int count);
		
		#endregion GetByProductModelIdFromProductModelProductDescriptionCulture
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CultureKey key)
		{
			return Delete(transactionManager, key.CultureId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_cultureId">Primary key for Culture records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _cultureId)
		{
			return Delete(null, _cultureId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Primary key for Culture records.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _cultureId);		
		
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
		public override Nettiers.AdventureWorks.Entities.Culture Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.CultureKey key, int start, int pageLength)
		{
			return GetByCultureId(transactionManager, key.CultureId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_Culture_Name index.
		/// </summary>
		/// <param name="_name">Culture description.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Culture_Name index.
		/// </summary>
		/// <param name="_name">Culture description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Culture_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Culture description.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Culture_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Culture description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Culture_Name index.
		/// </summary>
		/// <param name="_name">Culture description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_Culture_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name">Culture description.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Culture GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Culture_CultureID index.
		/// </summary>
		/// <param name="_cultureId">Primary key for Culture records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByCultureId(System.String _cultureId)
		{
			int count = -1;
			return GetByCultureId(null,_cultureId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Culture_CultureID index.
		/// </summary>
		/// <param name="_cultureId">Primary key for Culture records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByCultureId(System.String _cultureId, int start, int pageLength)
		{
			int count = -1;
			return GetByCultureId(null, _cultureId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Culture_CultureID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Primary key for Culture records.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByCultureId(TransactionManager transactionManager, System.String _cultureId)
		{
			int count = -1;
			return GetByCultureId(transactionManager, _cultureId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Culture_CultureID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Primary key for Culture records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByCultureId(TransactionManager transactionManager, System.String _cultureId, int start, int pageLength)
		{
			int count = -1;
			return GetByCultureId(transactionManager, _cultureId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Culture_CultureID index.
		/// </summary>
		/// <param name="_cultureId">Primary key for Culture records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.Culture GetByCultureId(System.String _cultureId, int start, int pageLength, out int count)
		{
			return GetByCultureId(null, _cultureId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Culture_CultureID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cultureId">Primary key for Culture records.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.Culture GetByCultureId(TransactionManager transactionManager, System.String _cultureId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Culture&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Culture&gt;"/></returns>
		public static TList<Culture> Fill(IDataReader reader, TList<Culture> rows, int start, int pageLength)
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
				
				Nettiers.AdventureWorks.Entities.Culture c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Culture")
					.Append("|").Append((System.String)reader[((int)CultureColumn.CultureId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Culture>(
					key.ToString(), // EntityTrackingKey
					"Culture",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.Culture();
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
					c.CultureId = (System.String)reader[((int)CultureColumn.CultureId - 1)];
					c.OriginalCultureId = c.CultureId;
					c.Name = (System.String)reader[((int)CultureColumn.Name - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)CultureColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Culture"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.Culture entity)
		{
			if (!reader.Read()) return;
			
			entity.CultureId = (System.String)reader[((int)CultureColumn.CultureId - 1)];
			entity.OriginalCultureId = (System.String)reader["CultureID"];
			entity.Name = (System.String)reader[((int)CultureColumn.Name - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)CultureColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.Culture"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Culture"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.Culture entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CultureId = (System.String)dataRow["CultureID"];
			entity.OriginalCultureId = (System.String)dataRow["CultureID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.ModifiedDate = (System.DateTime)dataRow["ModifiedDate"];
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
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.Culture"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Culture Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Culture entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCultureId methods when available
			
			#region ProductModelProductDescriptionCultureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductModelProductDescriptionCulture>|ProductModelProductDescriptionCultureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelProductDescriptionCultureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductModelProductDescriptionCultureCollection = DataRepository.ProductModelProductDescriptionCultureProvider.GetByCultureId(transactionManager, entity.CultureId);

				if (deep && entity.ProductModelProductDescriptionCultureCollection.Count > 0)
				{
					deepHandles.Add("ProductModelProductDescriptionCultureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductModelProductDescriptionCulture>) DataRepository.ProductModelProductDescriptionCultureProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductModelProductDescriptionCultureCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<ProductModel>|ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture", deepLoadType, innerList))
			{
				entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture = DataRepository.ProductModelProvider.GetByCultureIdFromProductModelProductDescriptionCulture(transactionManager, entity.CultureId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture != null)
				{
					deepHandles.Add("ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< ProductModel >) DataRepository.ProductModelProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<ProductDescription>|ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture", deepLoadType, innerList))
			{
				entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture = DataRepository.ProductDescriptionProvider.GetByCultureIdFromProductModelProductDescriptionCulture(transactionManager, entity.CultureId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture != null)
				{
					deepHandles.Add("ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< ProductDescription >) DataRepository.ProductDescriptionProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.Culture object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Culture instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.Culture Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Culture entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture>
			if (CanDeepSave(entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture, "List<ProductModel>|ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture", deepSaveType, innerList))
			{
				if (entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture.Count > 0 || entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture.DeletedItems.Count > 0)
				{
					DataRepository.ProductModelProvider.Save(transactionManager, entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture); 
					deepHandles.Add("ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<ProductModel>) DataRepository.ProductModelProvider.DeepSave,
						new object[] { transactionManager, entity.ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture>
			if (CanDeepSave(entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture, "List<ProductDescription>|ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture", deepSaveType, innerList))
			{
				if (entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture.Count > 0 || entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture.DeletedItems.Count > 0)
				{
					DataRepository.ProductDescriptionProvider.Save(transactionManager, entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture); 
					deepHandles.Add("ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<ProductDescription>) DataRepository.ProductDescriptionProvider.DeepSave,
						new object[] { transactionManager, entity.ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<ProductModelProductDescriptionCulture>
				if (CanDeepSave(entity.ProductModelProductDescriptionCultureCollection, "List<ProductModelProductDescriptionCulture>|ProductModelProductDescriptionCultureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductModelProductDescriptionCulture child in entity.ProductModelProductDescriptionCultureCollection)
					{
						if(child.CultureIdSource != null)
						{
								child.CultureId = child.CultureIdSource.CultureId;
						}

						if(child.ProductModelIdSource != null)
						{
								child.ProductModelId = child.ProductModelIdSource.ProductModelId;
						}

						if(child.ProductDescriptionIdSource != null)
						{
								child.ProductDescriptionId = child.ProductDescriptionIdSource.ProductDescriptionId;
						}

					}

					if (entity.ProductModelProductDescriptionCultureCollection.Count > 0 || entity.ProductModelProductDescriptionCultureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductModelProductDescriptionCultureProvider.Save(transactionManager, entity.ProductModelProductDescriptionCultureCollection);
						
						deepHandles.Add("ProductModelProductDescriptionCultureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductModelProductDescriptionCulture >) DataRepository.ProductModelProductDescriptionCultureProvider.DeepSave,
							new object[] { transactionManager, entity.ProductModelProductDescriptionCultureCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region CultureChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.Culture</c>
	///</summary>
	public enum CultureChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Culture</c> as OneToMany for ProductModelProductDescriptionCultureCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductModelProductDescriptionCulture>))]
		ProductModelProductDescriptionCultureCollection,

		///<summary>
		/// Collection of <c>Culture</c> as ManyToMany for ProductModelCollection_From_ProductModelProductDescriptionCulture
		///</summary>
		[ChildEntityType(typeof(TList<ProductModel>))]
		ProductModelIdProductModelCollection_From_ProductModelProductDescriptionCulture,

		///<summary>
		/// Collection of <c>Culture</c> as ManyToMany for ProductDescriptionCollection_From_ProductModelProductDescriptionCulture
		///</summary>
		[ChildEntityType(typeof(TList<ProductDescription>))]
		ProductDescriptionIdProductDescriptionCollection_From_ProductModelProductDescriptionCulture,
	}
	
	#endregion CultureChildEntityTypes
	
	#region CultureFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CultureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Culture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CultureFilterBuilder : SqlFilterBuilder<CultureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CultureFilterBuilder class.
		/// </summary>
		public CultureFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CultureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CultureFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CultureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CultureFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CultureFilterBuilder
	
	#region CultureParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CultureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Culture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CultureParameterBuilder : ParameterizedSqlFilterBuilder<CultureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CultureParameterBuilder class.
		/// </summary>
		public CultureParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CultureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CultureParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CultureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CultureParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CultureParameterBuilder
	
	#region CultureSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CultureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Culture"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CultureSortBuilder : SqlSortBuilder<CultureColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CultureSqlSortBuilder class.
		/// </summary>
		public CultureSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CultureSortBuilder
	
} // end namespace
