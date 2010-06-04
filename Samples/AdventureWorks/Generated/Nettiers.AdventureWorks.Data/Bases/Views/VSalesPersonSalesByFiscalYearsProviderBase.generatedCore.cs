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
	/// This class is the base class for any <see cref="VSalesPersonSalesByFiscalYearsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VSalesPersonSalesByFiscalYearsProviderBaseCore : EntityViewProviderBase<VSalesPersonSalesByFiscalYears>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VSalesPersonSalesByFiscalYears&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VSalesPersonSalesByFiscalYears&gt;"/></returns>
		protected static VList&lt;VSalesPersonSalesByFiscalYears&gt; Fill(DataSet dataSet, VList<VSalesPersonSalesByFiscalYears> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VSalesPersonSalesByFiscalYears>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VSalesPersonSalesByFiscalYears&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VSalesPersonSalesByFiscalYears>"/></returns>
		protected static VList&lt;VSalesPersonSalesByFiscalYears&gt; Fill(DataTable dataTable, VList<VSalesPersonSalesByFiscalYears> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VSalesPersonSalesByFiscalYears c = new VSalesPersonSalesByFiscalYears();
					c.SalesPersonId = (Convert.IsDBNull(row["SalesPersonID"]))?(int)0:(System.Int32?)row["SalesPersonID"];
					c.FullName = (Convert.IsDBNull(row["FullName"]))?string.Empty:(System.String)row["FullName"];
					c.Title = (Convert.IsDBNull(row["Title"]))?string.Empty:(System.String)row["Title"];
					c.SalesTerritory = (Convert.IsDBNull(row["SalesTerritory"]))?string.Empty:(System.String)row["SalesTerritory"];
					c.SafeName2002 = (Convert.IsDBNull(row["2002"]))?0:(System.Decimal?)row["2002"];
					c.SafeName2003 = (Convert.IsDBNull(row["2003"]))?0:(System.Decimal?)row["2003"];
					c.SafeName2004 = (Convert.IsDBNull(row["2004"]))?0:(System.Decimal?)row["2004"];
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
		/// Fill an <see cref="VList&lt;VSalesPersonSalesByFiscalYears&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VSalesPersonSalesByFiscalYears&gt;"/></returns>
		protected VList<VSalesPersonSalesByFiscalYears> Fill(IDataReader reader, VList<VSalesPersonSalesByFiscalYears> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VSalesPersonSalesByFiscalYears entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VSalesPersonSalesByFiscalYears>("VSalesPersonSalesByFiscalYears",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VSalesPersonSalesByFiscalYears();
					}
					
					entity.SuppressEntityEvents = true;

					entity.SalesPersonId = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.SalesPersonId)))?null:(System.Int32?)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SalesPersonId)];
					//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32?)reader["SalesPersonID"];
					entity.FullName = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.FullName)))?null:(System.String)reader[((int)VSalesPersonSalesByFiscalYearsColumn.FullName)];
					//entity.FullName = (Convert.IsDBNull(reader["FullName"]))?string.Empty:(System.String)reader["FullName"];
					entity.Title = (System.String)reader[((int)VSalesPersonSalesByFiscalYearsColumn.Title)];
					//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
					entity.SalesTerritory = (System.String)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SalesTerritory)];
					//entity.SalesTerritory = (Convert.IsDBNull(reader["SalesTerritory"]))?string.Empty:(System.String)reader["SalesTerritory"];
					entity.SafeName2002 = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2002)))?null:(System.Decimal?)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2002)];
					//entity.SafeName2002 = (Convert.IsDBNull(reader["2002"]))?0:(System.Decimal?)reader["2002"];
					entity.SafeName2003 = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2003)))?null:(System.Decimal?)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2003)];
					//entity.SafeName2003 = (Convert.IsDBNull(reader["2003"]))?0:(System.Decimal?)reader["2003"];
					entity.SafeName2004 = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2004)))?null:(System.Decimal?)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2004)];
					//entity.SafeName2004 = (Convert.IsDBNull(reader["2004"]))?0:(System.Decimal?)reader["2004"];
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
		/// Refreshes the <see cref="VSalesPersonSalesByFiscalYears"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VSalesPersonSalesByFiscalYears"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VSalesPersonSalesByFiscalYears entity)
		{
			reader.Read();
			entity.SalesPersonId = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.SalesPersonId)))?null:(System.Int32?)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SalesPersonId)];
			//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32?)reader["SalesPersonID"];
			entity.FullName = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.FullName)))?null:(System.String)reader[((int)VSalesPersonSalesByFiscalYearsColumn.FullName)];
			//entity.FullName = (Convert.IsDBNull(reader["FullName"]))?string.Empty:(System.String)reader["FullName"];
			entity.Title = (System.String)reader[((int)VSalesPersonSalesByFiscalYearsColumn.Title)];
			//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
			entity.SalesTerritory = (System.String)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SalesTerritory)];
			//entity.SalesTerritory = (Convert.IsDBNull(reader["SalesTerritory"]))?string.Empty:(System.String)reader["SalesTerritory"];
			entity.SafeName2002 = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2002)))?null:(System.Decimal?)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2002)];
			//entity.SafeName2002 = (Convert.IsDBNull(reader["2002"]))?0:(System.Decimal?)reader["2002"];
			entity.SafeName2003 = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2003)))?null:(System.Decimal?)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2003)];
			//entity.SafeName2003 = (Convert.IsDBNull(reader["2003"]))?0:(System.Decimal?)reader["2003"];
			entity.SafeName2004 = (reader.IsDBNull(((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2004)))?null:(System.Decimal?)reader[((int)VSalesPersonSalesByFiscalYearsColumn.SafeName2004)];
			//entity.SafeName2004 = (Convert.IsDBNull(reader["2004"]))?0:(System.Decimal?)reader["2004"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VSalesPersonSalesByFiscalYears"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VSalesPersonSalesByFiscalYears"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VSalesPersonSalesByFiscalYears entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesPersonId = (Convert.IsDBNull(dataRow["SalesPersonID"]))?(int)0:(System.Int32?)dataRow["SalesPersonID"];
			entity.FullName = (Convert.IsDBNull(dataRow["FullName"]))?string.Empty:(System.String)dataRow["FullName"];
			entity.Title = (Convert.IsDBNull(dataRow["Title"]))?string.Empty:(System.String)dataRow["Title"];
			entity.SalesTerritory = (Convert.IsDBNull(dataRow["SalesTerritory"]))?string.Empty:(System.String)dataRow["SalesTerritory"];
			entity.SafeName2002 = (Convert.IsDBNull(dataRow["2002"]))?0:(System.Decimal?)dataRow["2002"];
			entity.SafeName2003 = (Convert.IsDBNull(dataRow["2003"]))?0:(System.Decimal?)dataRow["2003"];
			entity.SafeName2004 = (Convert.IsDBNull(dataRow["2004"]))?0:(System.Decimal?)dataRow["2004"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VSalesPersonSalesByFiscalYearsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPersonSalesByFiscalYears"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonSalesByFiscalYearsFilterBuilder : SqlFilterBuilder<VSalesPersonSalesByFiscalYearsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsFilterBuilder class.
		/// </summary>
		public VSalesPersonSalesByFiscalYearsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VSalesPersonSalesByFiscalYearsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VSalesPersonSalesByFiscalYearsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VSalesPersonSalesByFiscalYearsFilterBuilder

	#region VSalesPersonSalesByFiscalYearsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPersonSalesByFiscalYears"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonSalesByFiscalYearsParameterBuilder : ParameterizedSqlFilterBuilder<VSalesPersonSalesByFiscalYearsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsParameterBuilder class.
		/// </summary>
		public VSalesPersonSalesByFiscalYearsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VSalesPersonSalesByFiscalYearsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VSalesPersonSalesByFiscalYearsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VSalesPersonSalesByFiscalYearsParameterBuilder
	
	#region VSalesPersonSalesByFiscalYearsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPersonSalesByFiscalYears"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VSalesPersonSalesByFiscalYearsSortBuilder : SqlSortBuilder<VSalesPersonSalesByFiscalYearsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSalesByFiscalYearsSqlSortBuilder class.
		/// </summary>
		public VSalesPersonSalesByFiscalYearsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VSalesPersonSalesByFiscalYearsSortBuilder

} // end namespace
