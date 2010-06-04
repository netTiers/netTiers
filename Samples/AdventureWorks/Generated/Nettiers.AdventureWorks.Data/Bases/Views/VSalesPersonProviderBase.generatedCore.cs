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
	/// This class is the base class for any <see cref="VSalesPersonProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VSalesPersonProviderBaseCore : EntityViewProviderBase<VSalesPerson>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VSalesPerson&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VSalesPerson&gt;"/></returns>
		protected static VList&lt;VSalesPerson&gt; Fill(DataSet dataSet, VList<VSalesPerson> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VSalesPerson>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VSalesPerson&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VSalesPerson>"/></returns>
		protected static VList&lt;VSalesPerson&gt; Fill(DataTable dataTable, VList<VSalesPerson> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VSalesPerson c = new VSalesPerson();
					c.SalesPersonId = (Convert.IsDBNull(row["SalesPersonID"]))?(int)0:(System.Int32)row["SalesPersonID"];
					c.Title = (Convert.IsDBNull(row["Title"]))?string.Empty:(System.String)row["Title"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.MiddleName = (Convert.IsDBNull(row["MiddleName"]))?string.Empty:(System.String)row["MiddleName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.Suffix = (Convert.IsDBNull(row["Suffix"]))?string.Empty:(System.String)row["Suffix"];
					c.JobTitle = (Convert.IsDBNull(row["JobTitle"]))?string.Empty:(System.String)row["JobTitle"];
					c.Phone = (Convert.IsDBNull(row["Phone"]))?string.Empty:(System.String)row["Phone"];
					c.EmailAddress = (Convert.IsDBNull(row["EmailAddress"]))?string.Empty:(System.String)row["EmailAddress"];
					c.EmailPromotion = (Convert.IsDBNull(row["EmailPromotion"]))?(int)0:(System.Int32)row["EmailPromotion"];
					c.AddressLine1 = (Convert.IsDBNull(row["AddressLine1"]))?string.Empty:(System.String)row["AddressLine1"];
					c.AddressLine2 = (Convert.IsDBNull(row["AddressLine2"]))?string.Empty:(System.String)row["AddressLine2"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.StateProvinceName = (Convert.IsDBNull(row["StateProvinceName"]))?string.Empty:(System.String)row["StateProvinceName"];
					c.PostalCode = (Convert.IsDBNull(row["PostalCode"]))?string.Empty:(System.String)row["PostalCode"];
					c.CountryRegionName = (Convert.IsDBNull(row["CountryRegionName"]))?string.Empty:(System.String)row["CountryRegionName"];
					c.TerritoryName = (Convert.IsDBNull(row["TerritoryName"]))?string.Empty:(System.String)row["TerritoryName"];
					c.TerritoryGroup = (Convert.IsDBNull(row["TerritoryGroup"]))?string.Empty:(System.String)row["TerritoryGroup"];
					c.SalesQuota = (Convert.IsDBNull(row["SalesQuota"]))?0:(System.Decimal?)row["SalesQuota"];
					c.SalesYtd = (Convert.IsDBNull(row["SalesYTD"]))?0:(System.Decimal)row["SalesYTD"];
					c.SalesLastYear = (Convert.IsDBNull(row["SalesLastYear"]))?0:(System.Decimal)row["SalesLastYear"];
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
		/// Fill an <see cref="VList&lt;VSalesPerson&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VSalesPerson&gt;"/></returns>
		protected VList<VSalesPerson> Fill(IDataReader reader, VList<VSalesPerson> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VSalesPerson entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VSalesPerson>("VSalesPerson",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VSalesPerson();
					}
					
					entity.SuppressEntityEvents = true;

					entity.SalesPersonId = (System.Int32)reader[((int)VSalesPersonColumn.SalesPersonId)];
					//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32)reader["SalesPersonID"];
					entity.Title = (reader.IsDBNull(((int)VSalesPersonColumn.Title)))?null:(System.String)reader[((int)VSalesPersonColumn.Title)];
					//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
					entity.FirstName = (System.String)reader[((int)VSalesPersonColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.MiddleName = (reader.IsDBNull(((int)VSalesPersonColumn.MiddleName)))?null:(System.String)reader[((int)VSalesPersonColumn.MiddleName)];
					//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
					entity.LastName = (System.String)reader[((int)VSalesPersonColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Suffix = (reader.IsDBNull(((int)VSalesPersonColumn.Suffix)))?null:(System.String)reader[((int)VSalesPersonColumn.Suffix)];
					//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
					entity.JobTitle = (System.String)reader[((int)VSalesPersonColumn.JobTitle)];
					//entity.JobTitle = (Convert.IsDBNull(reader["JobTitle"]))?string.Empty:(System.String)reader["JobTitle"];
					entity.Phone = (reader.IsDBNull(((int)VSalesPersonColumn.Phone)))?null:(System.String)reader[((int)VSalesPersonColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.EmailAddress = (reader.IsDBNull(((int)VSalesPersonColumn.EmailAddress)))?null:(System.String)reader[((int)VSalesPersonColumn.EmailAddress)];
					//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
					entity.EmailPromotion = (System.Int32)reader[((int)VSalesPersonColumn.EmailPromotion)];
					//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
					entity.AddressLine1 = (System.String)reader[((int)VSalesPersonColumn.AddressLine1)];
					//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
					entity.AddressLine2 = (reader.IsDBNull(((int)VSalesPersonColumn.AddressLine2)))?null:(System.String)reader[((int)VSalesPersonColumn.AddressLine2)];
					//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
					entity.City = (System.String)reader[((int)VSalesPersonColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.StateProvinceName = (System.String)reader[((int)VSalesPersonColumn.StateProvinceName)];
					//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
					entity.PostalCode = (System.String)reader[((int)VSalesPersonColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.CountryRegionName = (System.String)reader[((int)VSalesPersonColumn.CountryRegionName)];
					//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
					entity.TerritoryName = (reader.IsDBNull(((int)VSalesPersonColumn.TerritoryName)))?null:(System.String)reader[((int)VSalesPersonColumn.TerritoryName)];
					//entity.TerritoryName = (Convert.IsDBNull(reader["TerritoryName"]))?string.Empty:(System.String)reader["TerritoryName"];
					entity.TerritoryGroup = (reader.IsDBNull(((int)VSalesPersonColumn.TerritoryGroup)))?null:(System.String)reader[((int)VSalesPersonColumn.TerritoryGroup)];
					//entity.TerritoryGroup = (Convert.IsDBNull(reader["TerritoryGroup"]))?string.Empty:(System.String)reader["TerritoryGroup"];
					entity.SalesQuota = (reader.IsDBNull(((int)VSalesPersonColumn.SalesQuota)))?null:(System.Decimal?)reader[((int)VSalesPersonColumn.SalesQuota)];
					//entity.SalesQuota = (Convert.IsDBNull(reader["SalesQuota"]))?0:(System.Decimal?)reader["SalesQuota"];
					entity.SalesYtd = (System.Decimal)reader[((int)VSalesPersonColumn.SalesYtd)];
					//entity.SalesYtd = (Convert.IsDBNull(reader["SalesYTD"]))?0:(System.Decimal)reader["SalesYTD"];
					entity.SalesLastYear = (System.Decimal)reader[((int)VSalesPersonColumn.SalesLastYear)];
					//entity.SalesLastYear = (Convert.IsDBNull(reader["SalesLastYear"]))?0:(System.Decimal)reader["SalesLastYear"];
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
		/// Refreshes the <see cref="VSalesPerson"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VSalesPerson"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VSalesPerson entity)
		{
			reader.Read();
			entity.SalesPersonId = (System.Int32)reader[((int)VSalesPersonColumn.SalesPersonId)];
			//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32)reader["SalesPersonID"];
			entity.Title = (reader.IsDBNull(((int)VSalesPersonColumn.Title)))?null:(System.String)reader[((int)VSalesPersonColumn.Title)];
			//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
			entity.FirstName = (System.String)reader[((int)VSalesPersonColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.MiddleName = (reader.IsDBNull(((int)VSalesPersonColumn.MiddleName)))?null:(System.String)reader[((int)VSalesPersonColumn.MiddleName)];
			//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
			entity.LastName = (System.String)reader[((int)VSalesPersonColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Suffix = (reader.IsDBNull(((int)VSalesPersonColumn.Suffix)))?null:(System.String)reader[((int)VSalesPersonColumn.Suffix)];
			//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
			entity.JobTitle = (System.String)reader[((int)VSalesPersonColumn.JobTitle)];
			//entity.JobTitle = (Convert.IsDBNull(reader["JobTitle"]))?string.Empty:(System.String)reader["JobTitle"];
			entity.Phone = (reader.IsDBNull(((int)VSalesPersonColumn.Phone)))?null:(System.String)reader[((int)VSalesPersonColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.EmailAddress = (reader.IsDBNull(((int)VSalesPersonColumn.EmailAddress)))?null:(System.String)reader[((int)VSalesPersonColumn.EmailAddress)];
			//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
			entity.EmailPromotion = (System.Int32)reader[((int)VSalesPersonColumn.EmailPromotion)];
			//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
			entity.AddressLine1 = (System.String)reader[((int)VSalesPersonColumn.AddressLine1)];
			//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
			entity.AddressLine2 = (reader.IsDBNull(((int)VSalesPersonColumn.AddressLine2)))?null:(System.String)reader[((int)VSalesPersonColumn.AddressLine2)];
			//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
			entity.City = (System.String)reader[((int)VSalesPersonColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.StateProvinceName = (System.String)reader[((int)VSalesPersonColumn.StateProvinceName)];
			//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
			entity.PostalCode = (System.String)reader[((int)VSalesPersonColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.CountryRegionName = (System.String)reader[((int)VSalesPersonColumn.CountryRegionName)];
			//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
			entity.TerritoryName = (reader.IsDBNull(((int)VSalesPersonColumn.TerritoryName)))?null:(System.String)reader[((int)VSalesPersonColumn.TerritoryName)];
			//entity.TerritoryName = (Convert.IsDBNull(reader["TerritoryName"]))?string.Empty:(System.String)reader["TerritoryName"];
			entity.TerritoryGroup = (reader.IsDBNull(((int)VSalesPersonColumn.TerritoryGroup)))?null:(System.String)reader[((int)VSalesPersonColumn.TerritoryGroup)];
			//entity.TerritoryGroup = (Convert.IsDBNull(reader["TerritoryGroup"]))?string.Empty:(System.String)reader["TerritoryGroup"];
			entity.SalesQuota = (reader.IsDBNull(((int)VSalesPersonColumn.SalesQuota)))?null:(System.Decimal?)reader[((int)VSalesPersonColumn.SalesQuota)];
			//entity.SalesQuota = (Convert.IsDBNull(reader["SalesQuota"]))?0:(System.Decimal?)reader["SalesQuota"];
			entity.SalesYtd = (System.Decimal)reader[((int)VSalesPersonColumn.SalesYtd)];
			//entity.SalesYtd = (Convert.IsDBNull(reader["SalesYTD"]))?0:(System.Decimal)reader["SalesYTD"];
			entity.SalesLastYear = (System.Decimal)reader[((int)VSalesPersonColumn.SalesLastYear)];
			//entity.SalesLastYear = (Convert.IsDBNull(reader["SalesLastYear"]))?0:(System.Decimal)reader["SalesLastYear"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VSalesPerson"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VSalesPerson"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VSalesPerson entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesPersonId = (Convert.IsDBNull(dataRow["SalesPersonID"]))?(int)0:(System.Int32)dataRow["SalesPersonID"];
			entity.Title = (Convert.IsDBNull(dataRow["Title"]))?string.Empty:(System.String)dataRow["Title"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?string.Empty:(System.String)dataRow["FirstName"];
			entity.MiddleName = (Convert.IsDBNull(dataRow["MiddleName"]))?string.Empty:(System.String)dataRow["MiddleName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?string.Empty:(System.String)dataRow["LastName"];
			entity.Suffix = (Convert.IsDBNull(dataRow["Suffix"]))?string.Empty:(System.String)dataRow["Suffix"];
			entity.JobTitle = (Convert.IsDBNull(dataRow["JobTitle"]))?string.Empty:(System.String)dataRow["JobTitle"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?string.Empty:(System.String)dataRow["Phone"];
			entity.EmailAddress = (Convert.IsDBNull(dataRow["EmailAddress"]))?string.Empty:(System.String)dataRow["EmailAddress"];
			entity.EmailPromotion = (Convert.IsDBNull(dataRow["EmailPromotion"]))?(int)0:(System.Int32)dataRow["EmailPromotion"];
			entity.AddressLine1 = (Convert.IsDBNull(dataRow["AddressLine1"]))?string.Empty:(System.String)dataRow["AddressLine1"];
			entity.AddressLine2 = (Convert.IsDBNull(dataRow["AddressLine2"]))?string.Empty:(System.String)dataRow["AddressLine2"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.StateProvinceName = (Convert.IsDBNull(dataRow["StateProvinceName"]))?string.Empty:(System.String)dataRow["StateProvinceName"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?string.Empty:(System.String)dataRow["PostalCode"];
			entity.CountryRegionName = (Convert.IsDBNull(dataRow["CountryRegionName"]))?string.Empty:(System.String)dataRow["CountryRegionName"];
			entity.TerritoryName = (Convert.IsDBNull(dataRow["TerritoryName"]))?string.Empty:(System.String)dataRow["TerritoryName"];
			entity.TerritoryGroup = (Convert.IsDBNull(dataRow["TerritoryGroup"]))?string.Empty:(System.String)dataRow["TerritoryGroup"];
			entity.SalesQuota = (Convert.IsDBNull(dataRow["SalesQuota"]))?0:(System.Decimal?)dataRow["SalesQuota"];
			entity.SalesYtd = (Convert.IsDBNull(dataRow["SalesYTD"]))?0:(System.Decimal)dataRow["SalesYTD"];
			entity.SalesLastYear = (Convert.IsDBNull(dataRow["SalesLastYear"]))?0:(System.Decimal)dataRow["SalesLastYear"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VSalesPersonFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonFilterBuilder : SqlFilterBuilder<VSalesPersonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonFilterBuilder class.
		/// </summary>
		public VSalesPersonFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VSalesPersonFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VSalesPersonFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VSalesPersonFilterBuilder

	#region VSalesPersonParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VSalesPersonParameterBuilder : ParameterizedSqlFilterBuilder<VSalesPersonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonParameterBuilder class.
		/// </summary>
		public VSalesPersonParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VSalesPersonParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VSalesPersonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VSalesPersonParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VSalesPersonParameterBuilder
	
	#region VSalesPersonSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VSalesPerson"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VSalesPersonSortBuilder : SqlSortBuilder<VSalesPersonColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VSalesPersonSqlSortBuilder class.
		/// </summary>
		public VSalesPersonSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VSalesPersonSortBuilder

} // end namespace
