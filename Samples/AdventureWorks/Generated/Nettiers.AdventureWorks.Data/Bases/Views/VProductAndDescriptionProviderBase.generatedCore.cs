#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="VProductAndDescriptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VProductAndDescriptionProviderBaseCore : EntityViewProviderBase<VProductAndDescription>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VProductAndDescription&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VProductAndDescription&gt;"/></returns>
		protected static VList&lt;VProductAndDescription&gt; Fill(DataSet dataSet, VList<VProductAndDescription> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VProductAndDescription>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VProductAndDescription&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VProductAndDescription>"/></returns>
		protected static VList&lt;VProductAndDescription&gt; Fill(DataTable dataTable, VList<VProductAndDescription> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VProductAndDescription c = new VProductAndDescription();
					c.ProductId = (Convert.IsDBNull(row["ProductID"]))?(int)0:(System.Int32)row["ProductID"];
					c.Name = (Convert.IsDBNull(row["Name"]))?string.Empty:(System.String)row["Name"];
					c.ProductModel = (Convert.IsDBNull(row["ProductModel"]))?string.Empty:(System.String)row["ProductModel"];
					c.CultureId = (Convert.IsDBNull(row["CultureID"]))?string.Empty:(System.String)row["CultureID"];
					c.Description = (Convert.IsDBNull(row["Description"]))?string.Empty:(System.String)row["Description"];
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
		/// Fill an <see cref="VList&lt;VProductAndDescription&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VProductAndDescription&gt;"/></returns>
		protected VList<VProductAndDescription> Fill(IDataReader reader, VList<VProductAndDescription> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VProductAndDescription entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VProductAndDescription>("VProductAndDescription",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VProductAndDescription();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProductId = (System.Int32)reader[((int)VProductAndDescriptionColumn.ProductId)];
					//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
					entity.Name = (System.String)reader[((int)VProductAndDescriptionColumn.Name)];
					//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
					entity.ProductModel = (System.String)reader[((int)VProductAndDescriptionColumn.ProductModel)];
					//entity.ProductModel = (Convert.IsDBNull(reader["ProductModel"]))?string.Empty:(System.String)reader["ProductModel"];
					entity.CultureId = (System.String)reader[((int)VProductAndDescriptionColumn.CultureId)];
					//entity.CultureId = (Convert.IsDBNull(reader["CultureID"]))?string.Empty:(System.String)reader["CultureID"];
					entity.Description = (System.String)reader[((int)VProductAndDescriptionColumn.Description)];
					//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
					entity.AcceptChanges();
					entity.SuppressEntityEvents = false;
					
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="VProductAndDescription"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VProductAndDescription"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VProductAndDescription entity)
		{
			reader.Read();
			entity.ProductId = (System.Int32)reader[((int)VProductAndDescriptionColumn.ProductId)];
			//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
			entity.Name = (System.String)reader[((int)VProductAndDescriptionColumn.Name)];
			//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
			entity.ProductModel = (System.String)reader[((int)VProductAndDescriptionColumn.ProductModel)];
			//entity.ProductModel = (Convert.IsDBNull(reader["ProductModel"]))?string.Empty:(System.String)reader["ProductModel"];
			entity.CultureId = (System.String)reader[((int)VProductAndDescriptionColumn.CultureId)];
			//entity.CultureId = (Convert.IsDBNull(reader["CultureID"]))?string.Empty:(System.String)reader["CultureID"];
			entity.Description = (System.String)reader[((int)VProductAndDescriptionColumn.Description)];
			//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VProductAndDescription"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VProductAndDescription"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VProductAndDescription entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (Convert.IsDBNull(dataRow["ProductID"]))?(int)0:(System.Int32)dataRow["ProductID"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?string.Empty:(System.String)dataRow["Name"];
			entity.ProductModel = (Convert.IsDBNull(dataRow["ProductModel"]))?string.Empty:(System.String)dataRow["ProductModel"];
			entity.CultureId = (Convert.IsDBNull(dataRow["CultureID"]))?string.Empty:(System.String)dataRow["CultureID"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?string.Empty:(System.String)dataRow["Description"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VProductAndDescriptionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductAndDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductAndDescriptionFilterBuilder : SqlFilterBuilder<VProductAndDescriptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionFilterBuilder class.
		/// </summary>
		public VProductAndDescriptionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductAndDescriptionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductAndDescriptionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductAndDescriptionFilterBuilder

	#region VProductAndDescriptionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductAndDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductAndDescriptionParameterBuilder : ParameterizedSqlFilterBuilder<VProductAndDescriptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionParameterBuilder class.
		/// </summary>
		public VProductAndDescriptionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductAndDescriptionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductAndDescriptionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductAndDescriptionParameterBuilder
	
	#region VProductAndDescriptionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductAndDescription"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VProductAndDescriptionSortBuilder : SqlSortBuilder<VProductAndDescriptionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductAndDescriptionSqlSortBuilder class.
		/// </summary>
		public VProductAndDescriptionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VProductAndDescriptionSortBuilder

} // end namespace
