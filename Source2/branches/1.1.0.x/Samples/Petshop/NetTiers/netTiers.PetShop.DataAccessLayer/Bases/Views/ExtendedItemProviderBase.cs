	
	 
#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;

#endregion

namespace netTiers.PetShop.DataAccessLayer.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ExtendedItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ExtendedItemProviderBase
	{
		
			
		#region "GetList Functions"
		
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> GetAll()
		{
			return GetAll(0, int.MaxValue);
		}
		
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks>Uses connection string object was created with.</remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> GetAll(int start, int pageLength)
		{	
			return GetAll(null, start, pageLength);		
		}
		
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> GetAll(TransactionManager transactionManager)
		{
			return GetAll(transactionManager, 0, int.MaxValue);		
		}
		
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public abstract VList<ExtendedItem> GetAll(TransactionManager transactionManager, int start, int pageLength);
		
		#endregion
		
		#region Get filtered and sorted
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> Get()
		{
			return Get(null, null, null, 0, int.MaxValue);
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> Get(TransactionManager transactionManager)
		{
			return Get(transactionManager, null, null, 0, int.MaxValue);
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> Get(int start, int pageLength)
		{
			return Get(null, null, null, start, pageLength);
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> Get(TransactionManager transactionManager, int start, int pageLength)
		{
			return Get(transactionManager, null, null, start, pageLength);		
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> Get(string whereClause, string orderBy)
		{
			return Get(whereClause, orderBy, 0, int.MaxValue);
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="whereClause">.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> Get(TransactionManager transactionManager, string whereClause, string orderBy)
		{
			return Get(transactionManager, whereClause, orderBy, 0, int.MaxValue);
		}
						
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public VList<ExtendedItem> Get(string whereClause, string orderBy, int start, int pageLength)
		{
			return Get(null, whereClause, orderBy, start, pageLength);
		}
		
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ExtendedItem objects.</returns>
		public abstract VList<ExtendedItem> Get(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength);
		
		#endregion
			
			
	
		#region Custom Methods
		
		
		#endregion
	
		#region "Helper Functions"	
		
		/*
		///<summary>
		/// Fill an VList&lt;ExtendedItem&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ExtendedItem&gt;"/></returns>
		protected static VList&lt;ExtendedItem&gt; Fill(DataSet dataSet, VList<ExtendedItem> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ExtendedItem>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ExtendedItem&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ExtendedItem>"/></returns>
		protected static VList&lt;ExtendedItem&gt; Fill(DataTable dataTable, VList<ExtendedItem> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ExtendedItem c = new ExtendedItem();
					c.ItemId = (Convert.IsDBNull(row["ItemId"]))?string.Empty:(System.String)row["ItemId"];
					c.ItemName = (Convert.IsDBNull(row["ItemName"]))?string.Empty:(System.String)row["ItemName"];
					c.ItemDescription = (Convert.IsDBNull(row["ItemDescription"]))?string.Empty:(System.String)row["ItemDescription"];
					c.ItemPrice = (Convert.IsDBNull(row["ItemPrice"]))?0.0f:(System.Double?)row["ItemPrice"];
					c.ItemPhoto = (Convert.IsDBNull(row["ItemPhoto"]))?string.Empty:(System.String)row["ItemPhoto"];
					c.ProductId = (Convert.IsDBNull(row["ProductId"]))?string.Empty:(System.String)row["ProductId"];
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
					c.ProductDescription = (Convert.IsDBNull(row["ProductDescription"]))?string.Empty:(System.String)row["ProductDescription"];
					c.CategoryId = (Convert.IsDBNull(row["CategoryId"]))?string.Empty:(System.String)row["CategoryId"];
					c.CategoryName = (Convert.IsDBNull(row["CategoryName"]))?string.Empty:(System.String)row["CategoryName"];
					c.AcceptChanges();
					rows.Add(c);
					pagelen -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		*/	
						
		///<summary>
		/// Fill an <see cref="VList&lt;ExtendedItem&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ExtendedItem&gt;"/></returns>
		protected VList<ExtendedItem> Fill(IDataReader reader, VList<ExtendedItem> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ExtendedItem entity = new ExtendedItem();
					entity.ItemId = (Convert.IsDBNull(reader["ItemId"]))?string.Empty:(System.String)reader["ItemId"];
					//entity.ItemId = (Convert.IsDBNull(reader["ItemId"]))?string.Empty:(System.String)reader["ItemId"];
					entity.ItemName = (Convert.IsDBNull(reader["ItemName"]))?string.Empty:(System.String)reader["ItemName"];
					//entity.ItemName = (Convert.IsDBNull(reader["ItemName"]))?string.Empty:(System.String)reader["ItemName"];
					entity.ItemDescription = (Convert.IsDBNull(reader["ItemDescription"]))?null:(System.String)reader["ItemDescription"];
					//entity.ItemDescription = (Convert.IsDBNull(reader["ItemDescription"]))?string.Empty:(System.String)reader["ItemDescription"];
					entity.ItemPrice = (Convert.IsDBNull(reader["ItemPrice"]))?null:(System.Double?)reader["ItemPrice"];
					//entity.ItemPrice = (Convert.IsDBNull(reader["ItemPrice"]))?0.0f:(System.Double?)reader["ItemPrice"];
					entity.ItemPhoto = (Convert.IsDBNull(reader["ItemPhoto"]))?null:(System.String)reader["ItemPhoto"];
					//entity.ItemPhoto = (Convert.IsDBNull(reader["ItemPhoto"]))?string.Empty:(System.String)reader["ItemPhoto"];
					entity.ProductId = (Convert.IsDBNull(reader["ProductId"]))?string.Empty:(System.String)reader["ProductId"];
					//entity.ProductId = (Convert.IsDBNull(reader["ProductId"]))?string.Empty:(System.String)reader["ProductId"];
					entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.ProductDescription = (Convert.IsDBNull(reader["ProductDescription"]))?null:(System.String)reader["ProductDescription"];
					//entity.ProductDescription = (Convert.IsDBNull(reader["ProductDescription"]))?string.Empty:(System.String)reader["ProductDescription"];
					entity.CategoryId = (Convert.IsDBNull(reader["CategoryId"]))?string.Empty:(System.String)reader["CategoryId"];
					//entity.CategoryId = (Convert.IsDBNull(reader["CategoryId"]))?string.Empty:(System.String)reader["CategoryId"];
					entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
					//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
					entity.AcceptChanges();
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="ExtendedItem"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ExtendedItem"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ExtendedItem entity)
		{
			reader.Read();
			entity.ItemId = (Convert.IsDBNull(reader["ItemId"]))?string.Empty:(System.String)reader["ItemId"];
			//entity.ItemId = (Convert.IsDBNull(reader["ItemId"]))?string.Empty:(System.String)reader["ItemId"];
			entity.ItemName = (Convert.IsDBNull(reader["ItemName"]))?string.Empty:(System.String)reader["ItemName"];
			//entity.ItemName = (Convert.IsDBNull(reader["ItemName"]))?string.Empty:(System.String)reader["ItemName"];
			entity.ItemDescription = (Convert.IsDBNull(reader["ItemDescription"]))?null:(System.String)reader["ItemDescription"];
			//entity.ItemDescription = (Convert.IsDBNull(reader["ItemDescription"]))?string.Empty:(System.String)reader["ItemDescription"];
			entity.ItemPrice = (Convert.IsDBNull(reader["ItemPrice"]))?null:(System.Double?)reader["ItemPrice"];
			//entity.ItemPrice = (Convert.IsDBNull(reader["ItemPrice"]))?0.0f:(System.Double?)reader["ItemPrice"];
			entity.ItemPhoto = (Convert.IsDBNull(reader["ItemPhoto"]))?null:(System.String)reader["ItemPhoto"];
			//entity.ItemPhoto = (Convert.IsDBNull(reader["ItemPhoto"]))?string.Empty:(System.String)reader["ItemPhoto"];
			entity.ProductId = (Convert.IsDBNull(reader["ProductId"]))?string.Empty:(System.String)reader["ProductId"];
			//entity.ProductId = (Convert.IsDBNull(reader["ProductId"]))?string.Empty:(System.String)reader["ProductId"];
			entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.ProductDescription = (Convert.IsDBNull(reader["ProductDescription"]))?null:(System.String)reader["ProductDescription"];
			//entity.ProductDescription = (Convert.IsDBNull(reader["ProductDescription"]))?string.Empty:(System.String)reader["ProductDescription"];
			entity.CategoryId = (Convert.IsDBNull(reader["CategoryId"]))?string.Empty:(System.String)reader["CategoryId"];
			//entity.CategoryId = (Convert.IsDBNull(reader["CategoryId"]))?string.Empty:(System.String)reader["CategoryId"];
			entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
			//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ExtendedItem"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ExtendedItem"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ExtendedItem entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ItemId = (Convert.IsDBNull(dataRow["ItemId"]))?string.Empty:(System.String)dataRow["ItemId"];
			entity.ItemName = (Convert.IsDBNull(dataRow["ItemName"]))?string.Empty:(System.String)dataRow["ItemName"];
			entity.ItemDescription = (Convert.IsDBNull(dataRow["ItemDescription"]))?string.Empty:(System.String)dataRow["ItemDescription"];
			entity.ItemPrice = (Convert.IsDBNull(dataRow["ItemPrice"]))?0.0f:(System.Double?)dataRow["ItemPrice"];
			entity.ItemPhoto = (Convert.IsDBNull(dataRow["ItemPhoto"]))?string.Empty:(System.String)dataRow["ItemPhoto"];
			entity.ProductId = (Convert.IsDBNull(dataRow["ProductId"]))?string.Empty:(System.String)dataRow["ProductId"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.ProductDescription = (Convert.IsDBNull(dataRow["ProductDescription"]))?string.Empty:(System.String)dataRow["ProductDescription"];
			entity.CategoryId = (Convert.IsDBNull(dataRow["CategoryId"]))?string.Empty:(System.String)dataRow["CategoryId"];
			entity.CategoryName = (Convert.IsDBNull(dataRow["CategoryName"]))?string.Empty:(System.String)dataRow["CategoryName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion "Helper Functions"
		
	}//end class
} // end namespace
