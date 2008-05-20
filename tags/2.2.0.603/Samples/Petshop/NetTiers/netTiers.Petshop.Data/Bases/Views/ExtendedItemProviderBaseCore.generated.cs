#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ExtendedItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ExtendedItemProviderBaseCore : EntityViewProviderBase<ExtendedItem>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
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
					c.ItemId = (Convert.IsDBNull(row["ItemId"]))?Guid.Empty:(System.Guid)row["ItemId"];
					c.ItemName = (Convert.IsDBNull(row["ItemName"]))?string.Empty:(System.String)row["ItemName"];
					c.ItemDescription = (Convert.IsDBNull(row["ItemDescription"]))?string.Empty:(System.String)row["ItemDescription"];
					c.ItemPrice = (Convert.IsDBNull(row["ItemPrice"]))?0.0f:(System.Double?)row["ItemPrice"];
					c.ItemPhoto = (Convert.IsDBNull(row["ItemPhoto"]))?string.Empty:(System.String)row["ItemPhoto"];
					c.ProductId = (Convert.IsDBNull(row["ProductId"]))?Guid.Empty:(System.Guid)row["ProductId"];
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
					c.ProductDescription = (Convert.IsDBNull(row["ProductDescription"]))?string.Empty:(System.String)row["ProductDescription"];
					c.CategoryId = (Convert.IsDBNull(row["CategoryId"]))?Guid.Empty:(System.Guid)row["CategoryId"];
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
					entity.ItemId = (System.Guid)reader["ItemId"];
					//entity.ItemId = (Convert.IsDBNull(reader["ItemId"]))?Guid.Empty:(System.Guid)reader["ItemId"];
					entity.ItemName = (System.String)reader["ItemName"];
					//entity.ItemName = (Convert.IsDBNull(reader["ItemName"]))?string.Empty:(System.String)reader["ItemName"];
					entity.ItemDescription = (reader.IsDBNull(reader.GetOrdinal("ItemDescription")))?null:(System.String)reader["ItemDescription"];
					//entity.ItemDescription = (Convert.IsDBNull(reader["ItemDescription"]))?string.Empty:(System.String)reader["ItemDescription"];
					entity.ItemPrice = (reader.IsDBNull(reader.GetOrdinal("ItemPrice")))?null:(System.Double?)reader["ItemPrice"];
					//entity.ItemPrice = (Convert.IsDBNull(reader["ItemPrice"]))?0.0f:(System.Double?)reader["ItemPrice"];
					entity.ItemPhoto = (reader.IsDBNull(reader.GetOrdinal("ItemPhoto")))?null:(System.String)reader["ItemPhoto"];
					//entity.ItemPhoto = (Convert.IsDBNull(reader["ItemPhoto"]))?string.Empty:(System.String)reader["ItemPhoto"];
					entity.ProductId = (System.Guid)reader["ProductId"];
					//entity.ProductId = (Convert.IsDBNull(reader["ProductId"]))?Guid.Empty:(System.Guid)reader["ProductId"];
					entity.ProductName = (System.String)reader["ProductName"];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.ProductDescription = (reader.IsDBNull(reader.GetOrdinal("ProductDescription")))?null:(System.String)reader["ProductDescription"];
					//entity.ProductDescription = (Convert.IsDBNull(reader["ProductDescription"]))?string.Empty:(System.String)reader["ProductDescription"];
					entity.CategoryId = (System.Guid)reader["CategoryId"];
					//entity.CategoryId = (Convert.IsDBNull(reader["CategoryId"]))?Guid.Empty:(System.Guid)reader["CategoryId"];
					entity.CategoryName = (System.String)reader["CategoryName"];
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
			entity.ItemId = (System.Guid)reader["ItemId"];
			//entity.ItemId = (Convert.IsDBNull(reader["ItemId"]))?Guid.Empty:(System.Guid)reader["ItemId"];
			entity.ItemName = (System.String)reader["ItemName"];
			//entity.ItemName = (Convert.IsDBNull(reader["ItemName"]))?string.Empty:(System.String)reader["ItemName"];
			entity.ItemDescription = (reader.IsDBNull(reader.GetOrdinal("ItemDescription")))?null:(System.String)reader["ItemDescription"];
			//entity.ItemDescription = (Convert.IsDBNull(reader["ItemDescription"]))?string.Empty:(System.String)reader["ItemDescription"];
			entity.ItemPrice = (reader.IsDBNull(reader.GetOrdinal("ItemPrice")))?null:(System.Double?)reader["ItemPrice"];
			//entity.ItemPrice = (Convert.IsDBNull(reader["ItemPrice"]))?0.0f:(System.Double?)reader["ItemPrice"];
			entity.ItemPhoto = (reader.IsDBNull(reader.GetOrdinal("ItemPhoto")))?null:(System.String)reader["ItemPhoto"];
			//entity.ItemPhoto = (Convert.IsDBNull(reader["ItemPhoto"]))?string.Empty:(System.String)reader["ItemPhoto"];
			entity.ProductId = (System.Guid)reader["ProductId"];
			//entity.ProductId = (Convert.IsDBNull(reader["ProductId"]))?Guid.Empty:(System.Guid)reader["ProductId"];
			entity.ProductName = (System.String)reader["ProductName"];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.ProductDescription = (reader.IsDBNull(reader.GetOrdinal("ProductDescription")))?null:(System.String)reader["ProductDescription"];
			//entity.ProductDescription = (Convert.IsDBNull(reader["ProductDescription"]))?string.Empty:(System.String)reader["ProductDescription"];
			entity.CategoryId = (System.Guid)reader["CategoryId"];
			//entity.CategoryId = (Convert.IsDBNull(reader["CategoryId"]))?Guid.Empty:(System.Guid)reader["CategoryId"];
			entity.CategoryName = (System.String)reader["CategoryName"];
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
			
			entity.ItemId = (Convert.IsDBNull(dataRow["ItemId"]))?Guid.Empty:(System.Guid)dataRow["ItemId"];
			entity.ItemName = (Convert.IsDBNull(dataRow["ItemName"]))?string.Empty:(System.String)dataRow["ItemName"];
			entity.ItemDescription = (Convert.IsDBNull(dataRow["ItemDescription"]))?string.Empty:(System.String)dataRow["ItemDescription"];
			entity.ItemPrice = (Convert.IsDBNull(dataRow["ItemPrice"]))?0.0f:(System.Double?)dataRow["ItemPrice"];
			entity.ItemPhoto = (Convert.IsDBNull(dataRow["ItemPhoto"]))?string.Empty:(System.String)dataRow["ItemPhoto"];
			entity.ProductId = (Convert.IsDBNull(dataRow["ProductId"]))?Guid.Empty:(System.Guid)dataRow["ProductId"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.ProductDescription = (Convert.IsDBNull(dataRow["ProductDescription"]))?string.Empty:(System.String)dataRow["ProductDescription"];
			entity.CategoryId = (Convert.IsDBNull(dataRow["CategoryId"]))?Guid.Empty:(System.Guid)dataRow["CategoryId"];
			entity.CategoryName = (Convert.IsDBNull(dataRow["CategoryName"]))?string.Empty:(System.String)dataRow["CategoryName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ExtendedItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtendedItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtendedItemFilterBuilder : SqlFilterBuilder<ExtendedItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtendedItemFilterBuilder class.
		/// </summary>
		public ExtendedItemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExtendedItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExtendedItemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExtendedItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExtendedItemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExtendedItemFilterBuilder
} // end namespace
