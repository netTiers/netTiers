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
	/// This class is the base class for any <see cref="VJobCandidateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VJobCandidateProviderBaseCore : EntityViewProviderBase<VJobCandidate>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VJobCandidate&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VJobCandidate&gt;"/></returns>
		protected static VList&lt;VJobCandidate&gt; Fill(DataSet dataSet, VList<VJobCandidate> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VJobCandidate>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VJobCandidate&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VJobCandidate>"/></returns>
		protected static VList&lt;VJobCandidate&gt; Fill(DataTable dataTable, VList<VJobCandidate> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VJobCandidate c = new VJobCandidate();
					c.JobCandidateId = (Convert.IsDBNull(row["JobCandidateID"]))?(int)0:(System.Int32)row["JobCandidateID"];
					c.EmployeeId = (Convert.IsDBNull(row["EmployeeID"]))?(int)0:(System.Int32?)row["EmployeeID"];
					c.SafeNameNamePrefix = (Convert.IsDBNull(row["Name.Prefix"]))?string.Empty:(System.String)row["Name.Prefix"];
					c.SafeNameNameFirst = (Convert.IsDBNull(row["Name.First"]))?string.Empty:(System.String)row["Name.First"];
					c.SafeNameNameMiddle = (Convert.IsDBNull(row["Name.Middle"]))?string.Empty:(System.String)row["Name.Middle"];
					c.SafeNameNameLast = (Convert.IsDBNull(row["Name.Last"]))?string.Empty:(System.String)row["Name.Last"];
					c.SafeNameNameSuffix = (Convert.IsDBNull(row["Name.Suffix"]))?string.Empty:(System.String)row["Name.Suffix"];
					c.Skills = (Convert.IsDBNull(row["Skills"]))?string.Empty:(System.String)row["Skills"];
					c.SafeNameAddrType = (Convert.IsDBNull(row["Addr.Type"]))?string.Empty:(System.String)row["Addr.Type"];
					c.SafeNameAddrLocCountryRegion = (Convert.IsDBNull(row["Addr.Loc.CountryRegion"]))?string.Empty:(System.String)row["Addr.Loc.CountryRegion"];
					c.SafeNameAddrLocState = (Convert.IsDBNull(row["Addr.Loc.State"]))?string.Empty:(System.String)row["Addr.Loc.State"];
					c.SafeNameAddrLocCity = (Convert.IsDBNull(row["Addr.Loc.City"]))?string.Empty:(System.String)row["Addr.Loc.City"];
					c.SafeNameAddrPostalCode = (Convert.IsDBNull(row["Addr.PostalCode"]))?string.Empty:(System.String)row["Addr.PostalCode"];
					c.Email = (Convert.IsDBNull(row["EMail"]))?string.Empty:(System.String)row["EMail"];
					c.WebSite = (Convert.IsDBNull(row["WebSite"]))?string.Empty:(System.String)row["WebSite"];
					c.ModifiedDate = (Convert.IsDBNull(row["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)row["ModifiedDate"];
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
		/// Fill an <see cref="VList&lt;VJobCandidate&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VJobCandidate&gt;"/></returns>
		protected VList<VJobCandidate> Fill(IDataReader reader, VList<VJobCandidate> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VJobCandidate entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VJobCandidate>("VJobCandidate",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VJobCandidate();
					}
					
					entity.SuppressEntityEvents = true;

					entity.JobCandidateId = (System.Int32)reader[((int)VJobCandidateColumn.JobCandidateId)];
					//entity.JobCandidateId = (Convert.IsDBNull(reader["JobCandidateID"]))?(int)0:(System.Int32)reader["JobCandidateID"];
					entity.EmployeeId = (reader.IsDBNull(((int)VJobCandidateColumn.EmployeeId)))?null:(System.Int32?)reader[((int)VJobCandidateColumn.EmployeeId)];
					//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32?)reader["EmployeeID"];
					entity.SafeNameNamePrefix = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNamePrefix)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNamePrefix)];
					//entity.SafeNameNamePrefix = (Convert.IsDBNull(reader["Name.Prefix"]))?string.Empty:(System.String)reader["Name.Prefix"];
					entity.SafeNameNameFirst = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNameFirst)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNameFirst)];
					//entity.SafeNameNameFirst = (Convert.IsDBNull(reader["Name.First"]))?string.Empty:(System.String)reader["Name.First"];
					entity.SafeNameNameMiddle = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNameMiddle)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNameMiddle)];
					//entity.SafeNameNameMiddle = (Convert.IsDBNull(reader["Name.Middle"]))?string.Empty:(System.String)reader["Name.Middle"];
					entity.SafeNameNameLast = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNameLast)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNameLast)];
					//entity.SafeNameNameLast = (Convert.IsDBNull(reader["Name.Last"]))?string.Empty:(System.String)reader["Name.Last"];
					entity.SafeNameNameSuffix = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNameSuffix)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNameSuffix)];
					//entity.SafeNameNameSuffix = (Convert.IsDBNull(reader["Name.Suffix"]))?string.Empty:(System.String)reader["Name.Suffix"];
					entity.Skills = (reader.IsDBNull(((int)VJobCandidateColumn.Skills)))?null:(System.String)reader[((int)VJobCandidateColumn.Skills)];
					//entity.Skills = (Convert.IsDBNull(reader["Skills"]))?string.Empty:(System.String)reader["Skills"];
					entity.SafeNameAddrType = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrType)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrType)];
					//entity.SafeNameAddrType = (Convert.IsDBNull(reader["Addr.Type"]))?string.Empty:(System.String)reader["Addr.Type"];
					entity.SafeNameAddrLocCountryRegion = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrLocCountryRegion)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrLocCountryRegion)];
					//entity.SafeNameAddrLocCountryRegion = (Convert.IsDBNull(reader["Addr.Loc.CountryRegion"]))?string.Empty:(System.String)reader["Addr.Loc.CountryRegion"];
					entity.SafeNameAddrLocState = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrLocState)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrLocState)];
					//entity.SafeNameAddrLocState = (Convert.IsDBNull(reader["Addr.Loc.State"]))?string.Empty:(System.String)reader["Addr.Loc.State"];
					entity.SafeNameAddrLocCity = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrLocCity)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrLocCity)];
					//entity.SafeNameAddrLocCity = (Convert.IsDBNull(reader["Addr.Loc.City"]))?string.Empty:(System.String)reader["Addr.Loc.City"];
					entity.SafeNameAddrPostalCode = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrPostalCode)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrPostalCode)];
					//entity.SafeNameAddrPostalCode = (Convert.IsDBNull(reader["Addr.PostalCode"]))?string.Empty:(System.String)reader["Addr.PostalCode"];
					entity.Email = (reader.IsDBNull(((int)VJobCandidateColumn.Email)))?null:(System.String)reader[((int)VJobCandidateColumn.Email)];
					//entity.Email = (Convert.IsDBNull(reader["EMail"]))?string.Empty:(System.String)reader["EMail"];
					entity.WebSite = (reader.IsDBNull(((int)VJobCandidateColumn.WebSite)))?null:(System.String)reader[((int)VJobCandidateColumn.WebSite)];
					//entity.WebSite = (Convert.IsDBNull(reader["WebSite"]))?string.Empty:(System.String)reader["WebSite"];
					entity.ModifiedDate = (System.DateTime)reader[((int)VJobCandidateColumn.ModifiedDate)];
					//entity.ModifiedDate = (Convert.IsDBNull(reader["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)reader["ModifiedDate"];
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
		/// Refreshes the <see cref="VJobCandidate"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VJobCandidate"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VJobCandidate entity)
		{
			reader.Read();
			entity.JobCandidateId = (System.Int32)reader[((int)VJobCandidateColumn.JobCandidateId)];
			//entity.JobCandidateId = (Convert.IsDBNull(reader["JobCandidateID"]))?(int)0:(System.Int32)reader["JobCandidateID"];
			entity.EmployeeId = (reader.IsDBNull(((int)VJobCandidateColumn.EmployeeId)))?null:(System.Int32?)reader[((int)VJobCandidateColumn.EmployeeId)];
			//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32?)reader["EmployeeID"];
			entity.SafeNameNamePrefix = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNamePrefix)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNamePrefix)];
			//entity.SafeNameNamePrefix = (Convert.IsDBNull(reader["Name.Prefix"]))?string.Empty:(System.String)reader["Name.Prefix"];
			entity.SafeNameNameFirst = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNameFirst)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNameFirst)];
			//entity.SafeNameNameFirst = (Convert.IsDBNull(reader["Name.First"]))?string.Empty:(System.String)reader["Name.First"];
			entity.SafeNameNameMiddle = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNameMiddle)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNameMiddle)];
			//entity.SafeNameNameMiddle = (Convert.IsDBNull(reader["Name.Middle"]))?string.Empty:(System.String)reader["Name.Middle"];
			entity.SafeNameNameLast = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNameLast)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNameLast)];
			//entity.SafeNameNameLast = (Convert.IsDBNull(reader["Name.Last"]))?string.Empty:(System.String)reader["Name.Last"];
			entity.SafeNameNameSuffix = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameNameSuffix)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameNameSuffix)];
			//entity.SafeNameNameSuffix = (Convert.IsDBNull(reader["Name.Suffix"]))?string.Empty:(System.String)reader["Name.Suffix"];
			entity.Skills = (reader.IsDBNull(((int)VJobCandidateColumn.Skills)))?null:(System.String)reader[((int)VJobCandidateColumn.Skills)];
			//entity.Skills = (Convert.IsDBNull(reader["Skills"]))?string.Empty:(System.String)reader["Skills"];
			entity.SafeNameAddrType = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrType)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrType)];
			//entity.SafeNameAddrType = (Convert.IsDBNull(reader["Addr.Type"]))?string.Empty:(System.String)reader["Addr.Type"];
			entity.SafeNameAddrLocCountryRegion = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrLocCountryRegion)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrLocCountryRegion)];
			//entity.SafeNameAddrLocCountryRegion = (Convert.IsDBNull(reader["Addr.Loc.CountryRegion"]))?string.Empty:(System.String)reader["Addr.Loc.CountryRegion"];
			entity.SafeNameAddrLocState = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrLocState)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrLocState)];
			//entity.SafeNameAddrLocState = (Convert.IsDBNull(reader["Addr.Loc.State"]))?string.Empty:(System.String)reader["Addr.Loc.State"];
			entity.SafeNameAddrLocCity = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrLocCity)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrLocCity)];
			//entity.SafeNameAddrLocCity = (Convert.IsDBNull(reader["Addr.Loc.City"]))?string.Empty:(System.String)reader["Addr.Loc.City"];
			entity.SafeNameAddrPostalCode = (reader.IsDBNull(((int)VJobCandidateColumn.SafeNameAddrPostalCode)))?null:(System.String)reader[((int)VJobCandidateColumn.SafeNameAddrPostalCode)];
			//entity.SafeNameAddrPostalCode = (Convert.IsDBNull(reader["Addr.PostalCode"]))?string.Empty:(System.String)reader["Addr.PostalCode"];
			entity.Email = (reader.IsDBNull(((int)VJobCandidateColumn.Email)))?null:(System.String)reader[((int)VJobCandidateColumn.Email)];
			//entity.Email = (Convert.IsDBNull(reader["EMail"]))?string.Empty:(System.String)reader["EMail"];
			entity.WebSite = (reader.IsDBNull(((int)VJobCandidateColumn.WebSite)))?null:(System.String)reader[((int)VJobCandidateColumn.WebSite)];
			//entity.WebSite = (Convert.IsDBNull(reader["WebSite"]))?string.Empty:(System.String)reader["WebSite"];
			entity.ModifiedDate = (System.DateTime)reader[((int)VJobCandidateColumn.ModifiedDate)];
			//entity.ModifiedDate = (Convert.IsDBNull(reader["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)reader["ModifiedDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VJobCandidate"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VJobCandidate"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VJobCandidate entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobCandidateId = (Convert.IsDBNull(dataRow["JobCandidateID"]))?(int)0:(System.Int32)dataRow["JobCandidateID"];
			entity.EmployeeId = (Convert.IsDBNull(dataRow["EmployeeID"]))?(int)0:(System.Int32?)dataRow["EmployeeID"];
			entity.SafeNameNamePrefix = (Convert.IsDBNull(dataRow["Name.Prefix"]))?string.Empty:(System.String)dataRow["Name.Prefix"];
			entity.SafeNameNameFirst = (Convert.IsDBNull(dataRow["Name.First"]))?string.Empty:(System.String)dataRow["Name.First"];
			entity.SafeNameNameMiddle = (Convert.IsDBNull(dataRow["Name.Middle"]))?string.Empty:(System.String)dataRow["Name.Middle"];
			entity.SafeNameNameLast = (Convert.IsDBNull(dataRow["Name.Last"]))?string.Empty:(System.String)dataRow["Name.Last"];
			entity.SafeNameNameSuffix = (Convert.IsDBNull(dataRow["Name.Suffix"]))?string.Empty:(System.String)dataRow["Name.Suffix"];
			entity.Skills = (Convert.IsDBNull(dataRow["Skills"]))?string.Empty:(System.String)dataRow["Skills"];
			entity.SafeNameAddrType = (Convert.IsDBNull(dataRow["Addr.Type"]))?string.Empty:(System.String)dataRow["Addr.Type"];
			entity.SafeNameAddrLocCountryRegion = (Convert.IsDBNull(dataRow["Addr.Loc.CountryRegion"]))?string.Empty:(System.String)dataRow["Addr.Loc.CountryRegion"];
			entity.SafeNameAddrLocState = (Convert.IsDBNull(dataRow["Addr.Loc.State"]))?string.Empty:(System.String)dataRow["Addr.Loc.State"];
			entity.SafeNameAddrLocCity = (Convert.IsDBNull(dataRow["Addr.Loc.City"]))?string.Empty:(System.String)dataRow["Addr.Loc.City"];
			entity.SafeNameAddrPostalCode = (Convert.IsDBNull(dataRow["Addr.PostalCode"]))?string.Empty:(System.String)dataRow["Addr.PostalCode"];
			entity.Email = (Convert.IsDBNull(dataRow["EMail"]))?string.Empty:(System.String)dataRow["EMail"];
			entity.WebSite = (Convert.IsDBNull(dataRow["WebSite"]))?string.Empty:(System.String)dataRow["WebSite"];
			entity.ModifiedDate = (Convert.IsDBNull(dataRow["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)dataRow["ModifiedDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VJobCandidateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateFilterBuilder : SqlFilterBuilder<VJobCandidateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateFilterBuilder class.
		/// </summary>
		public VJobCandidateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateFilterBuilder

	#region VJobCandidateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateParameterBuilder : ParameterizedSqlFilterBuilder<VJobCandidateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateParameterBuilder class.
		/// </summary>
		public VJobCandidateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateParameterBuilder
	
	#region VJobCandidateSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidate"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VJobCandidateSortBuilder : SqlSortBuilder<VJobCandidateColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateSqlSortBuilder class.
		/// </summary>
		public VJobCandidateSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VJobCandidateSortBuilder

} // end namespace
