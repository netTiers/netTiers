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
	/// This class is the base class for any <see cref="VStateProvinceCountryRegionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VStateProvinceCountryRegionProviderBaseCore : EntityViewProviderBase<VStateProvinceCountryRegion>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VStateProvinceCountryRegion&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VStateProvinceCountryRegion&gt;"/></returns>
		protected static VList&lt;VStateProvinceCountryRegion&gt; Fill(DataSet dataSet, VList<VStateProvinceCountryRegion> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VStateProvinceCountryRegion>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VStateProvinceCountryRegion&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VStateProvinceCountryRegion>"/></returns>
		protected static VList&lt;VStateProvinceCountryRegion&gt; Fill(DataTable dataTable, VList<VStateProvinceCountryRegion> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VStateProvinceCountryRegion c = new VStateProvinceCountryRegion();
					c.StateProvinceId = (Convert.IsDBNull(row["StateProvinceID"]))?(int)0:(System.Int32)row["StateProvinceID"];
					c.StateProvinceCode = (Convert.IsDBNull(row["StateProvinceCode"]))?string.Empty:(System.String)row["StateProvinceCode"];
					c.IsOnlyStateProvinceFlag = (Convert.IsDBNull(row["IsOnlyStateProvinceFlag"]))?false:(System.Boolean)row["IsOnlyStateProvinceFlag"];
					c.StateProvinceName = (Convert.IsDBNull(row["StateProvinceName"]))?string.Empty:(System.String)row["StateProvinceName"];
					c.TerritoryId = (Convert.IsDBNull(row["TerritoryID"]))?(int)0:(System.Int32)row["TerritoryID"];
					c.CountryRegionCode = (Convert.IsDBNull(row["CountryRegionCode"]))?string.Empty:(System.String)row["CountryRegionCode"];
					c.CountryRegionName = (Convert.IsDBNull(row["CountryRegionName"]))?string.Empty:(System.String)row["CountryRegionName"];
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
		/// Fill an <see cref="VList&lt;VStateProvinceCountryRegion&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VStateProvinceCountryRegion&gt;"/></returns>
		protected VList<VStateProvinceCountryRegion> Fill(IDataReader reader, VList<VStateProvinceCountryRegion> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VStateProvinceCountryRegion entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VStateProvinceCountryRegion>("VStateProvinceCountryRegion",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VStateProvinceCountryRegion();
					}
					
					entity.SuppressEntityEvents = true;

					entity.StateProvinceId = (System.Int32)reader[((int)VStateProvinceCountryRegionColumn.StateProvinceId)];
					//entity.StateProvinceId = (Convert.IsDBNull(reader["StateProvinceID"]))?(int)0:(System.Int32)reader["StateProvinceID"];
					entity.StateProvinceCode = (System.String)reader[((int)VStateProvinceCountryRegionColumn.StateProvinceCode)];
					//entity.StateProvinceCode = (Convert.IsDBNull(reader["StateProvinceCode"]))?string.Empty:(System.String)reader["StateProvinceCode"];
					entity.IsOnlyStateProvinceFlag = (System.Boolean)reader[((int)VStateProvinceCountryRegionColumn.IsOnlyStateProvinceFlag)];
					//entity.IsOnlyStateProvinceFlag = (Convert.IsDBNull(reader["IsOnlyStateProvinceFlag"]))?false:(System.Boolean)reader["IsOnlyStateProvinceFlag"];
					entity.StateProvinceName = (System.String)reader[((int)VStateProvinceCountryRegionColumn.StateProvinceName)];
					//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
					entity.TerritoryId = (System.Int32)reader[((int)VStateProvinceCountryRegionColumn.TerritoryId)];
					//entity.TerritoryId = (Convert.IsDBNull(reader["TerritoryID"]))?(int)0:(System.Int32)reader["TerritoryID"];
					entity.CountryRegionCode = (System.String)reader[((int)VStateProvinceCountryRegionColumn.CountryRegionCode)];
					//entity.CountryRegionCode = (Convert.IsDBNull(reader["CountryRegionCode"]))?string.Empty:(System.String)reader["CountryRegionCode"];
					entity.CountryRegionName = (System.String)reader[((int)VStateProvinceCountryRegionColumn.CountryRegionName)];
					//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
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
		/// Refreshes the <see cref="VStateProvinceCountryRegion"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VStateProvinceCountryRegion"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VStateProvinceCountryRegion entity)
		{
			reader.Read();
			entity.StateProvinceId = (System.Int32)reader[((int)VStateProvinceCountryRegionColumn.StateProvinceId)];
			//entity.StateProvinceId = (Convert.IsDBNull(reader["StateProvinceID"]))?(int)0:(System.Int32)reader["StateProvinceID"];
			entity.StateProvinceCode = (System.String)reader[((int)VStateProvinceCountryRegionColumn.StateProvinceCode)];
			//entity.StateProvinceCode = (Convert.IsDBNull(reader["StateProvinceCode"]))?string.Empty:(System.String)reader["StateProvinceCode"];
			entity.IsOnlyStateProvinceFlag = (System.Boolean)reader[((int)VStateProvinceCountryRegionColumn.IsOnlyStateProvinceFlag)];
			//entity.IsOnlyStateProvinceFlag = (Convert.IsDBNull(reader["IsOnlyStateProvinceFlag"]))?false:(System.Boolean)reader["IsOnlyStateProvinceFlag"];
			entity.StateProvinceName = (System.String)reader[((int)VStateProvinceCountryRegionColumn.StateProvinceName)];
			//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
			entity.TerritoryId = (System.Int32)reader[((int)VStateProvinceCountryRegionColumn.TerritoryId)];
			//entity.TerritoryId = (Convert.IsDBNull(reader["TerritoryID"]))?(int)0:(System.Int32)reader["TerritoryID"];
			entity.CountryRegionCode = (System.String)reader[((int)VStateProvinceCountryRegionColumn.CountryRegionCode)];
			//entity.CountryRegionCode = (Convert.IsDBNull(reader["CountryRegionCode"]))?string.Empty:(System.String)reader["CountryRegionCode"];
			entity.CountryRegionName = (System.String)reader[((int)VStateProvinceCountryRegionColumn.CountryRegionName)];
			//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VStateProvinceCountryRegion"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VStateProvinceCountryRegion"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VStateProvinceCountryRegion entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.StateProvinceId = (Convert.IsDBNull(dataRow["StateProvinceID"]))?(int)0:(System.Int32)dataRow["StateProvinceID"];
			entity.StateProvinceCode = (Convert.IsDBNull(dataRow["StateProvinceCode"]))?string.Empty:(System.String)dataRow["StateProvinceCode"];
			entity.IsOnlyStateProvinceFlag = (Convert.IsDBNull(dataRow["IsOnlyStateProvinceFlag"]))?false:(System.Boolean)dataRow["IsOnlyStateProvinceFlag"];
			entity.StateProvinceName = (Convert.IsDBNull(dataRow["StateProvinceName"]))?string.Empty:(System.String)dataRow["StateProvinceName"];
			entity.TerritoryId = (Convert.IsDBNull(dataRow["TerritoryID"]))?(int)0:(System.Int32)dataRow["TerritoryID"];
			entity.CountryRegionCode = (Convert.IsDBNull(dataRow["CountryRegionCode"]))?string.Empty:(System.String)dataRow["CountryRegionCode"];
			entity.CountryRegionName = (Convert.IsDBNull(dataRow["CountryRegionName"]))?string.Empty:(System.String)dataRow["CountryRegionName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VStateProvinceCountryRegionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStateProvinceCountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStateProvinceCountryRegionFilterBuilder : SqlFilterBuilder<VStateProvinceCountryRegionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionFilterBuilder class.
		/// </summary>
		public VStateProvinceCountryRegionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VStateProvinceCountryRegionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VStateProvinceCountryRegionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VStateProvinceCountryRegionFilterBuilder

	#region VStateProvinceCountryRegionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStateProvinceCountryRegion"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStateProvinceCountryRegionParameterBuilder : ParameterizedSqlFilterBuilder<VStateProvinceCountryRegionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionParameterBuilder class.
		/// </summary>
		public VStateProvinceCountryRegionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VStateProvinceCountryRegionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VStateProvinceCountryRegionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VStateProvinceCountryRegionParameterBuilder
	
	#region VStateProvinceCountryRegionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStateProvinceCountryRegion"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VStateProvinceCountryRegionSortBuilder : SqlSortBuilder<VStateProvinceCountryRegionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStateProvinceCountryRegionSqlSortBuilder class.
		/// </summary>
		public VStateProvinceCountryRegionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VStateProvinceCountryRegionSortBuilder

} // end namespace
