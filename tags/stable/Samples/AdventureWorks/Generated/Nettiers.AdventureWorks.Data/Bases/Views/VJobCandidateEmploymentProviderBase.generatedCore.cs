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
	/// This class is the base class for any <see cref="VJobCandidateEmploymentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VJobCandidateEmploymentProviderBaseCore : EntityViewProviderBase<VJobCandidateEmployment>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VJobCandidateEmployment&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VJobCandidateEmployment&gt;"/></returns>
		protected static VList&lt;VJobCandidateEmployment&gt; Fill(DataSet dataSet, VList<VJobCandidateEmployment> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VJobCandidateEmployment>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VJobCandidateEmployment&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VJobCandidateEmployment>"/></returns>
		protected static VList&lt;VJobCandidateEmployment&gt; Fill(DataTable dataTable, VList<VJobCandidateEmployment> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VJobCandidateEmployment c = new VJobCandidateEmployment();
					c.JobCandidateId = (Convert.IsDBNull(row["JobCandidateID"]))?(int)0:(System.Int32)row["JobCandidateID"];
					c.SafeNameEmpStartDate = (Convert.IsDBNull(row["Emp.StartDate"]))?DateTime.MinValue:(System.DateTime?)row["Emp.StartDate"];
					c.SafeNameEmpEndDate = (Convert.IsDBNull(row["Emp.EndDate"]))?DateTime.MinValue:(System.DateTime?)row["Emp.EndDate"];
					c.SafeNameEmpOrgName = (Convert.IsDBNull(row["Emp.OrgName"]))?string.Empty:(System.String)row["Emp.OrgName"];
					c.SafeNameEmpJobTitle = (Convert.IsDBNull(row["Emp.JobTitle"]))?string.Empty:(System.String)row["Emp.JobTitle"];
					c.SafeNameEmpResponsibility = (Convert.IsDBNull(row["Emp.Responsibility"]))?string.Empty:(System.String)row["Emp.Responsibility"];
					c.SafeNameEmpFunctionCategory = (Convert.IsDBNull(row["Emp.FunctionCategory"]))?string.Empty:(System.String)row["Emp.FunctionCategory"];
					c.SafeNameEmpIndustryCategory = (Convert.IsDBNull(row["Emp.IndustryCategory"]))?string.Empty:(System.String)row["Emp.IndustryCategory"];
					c.SafeNameEmpLocCountryRegion = (Convert.IsDBNull(row["Emp.Loc.CountryRegion"]))?string.Empty:(System.String)row["Emp.Loc.CountryRegion"];
					c.SafeNameEmpLocState = (Convert.IsDBNull(row["Emp.Loc.State"]))?string.Empty:(System.String)row["Emp.Loc.State"];
					c.SafeNameEmpLocCity = (Convert.IsDBNull(row["Emp.Loc.City"]))?string.Empty:(System.String)row["Emp.Loc.City"];
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
		/// Fill an <see cref="VList&lt;VJobCandidateEmployment&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VJobCandidateEmployment&gt;"/></returns>
		protected VList<VJobCandidateEmployment> Fill(IDataReader reader, VList<VJobCandidateEmployment> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VJobCandidateEmployment entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VJobCandidateEmployment>("VJobCandidateEmployment",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VJobCandidateEmployment();
					}
					
					entity.SuppressEntityEvents = true;

					entity.JobCandidateId = (System.Int32)reader[((int)VJobCandidateEmploymentColumn.JobCandidateId)];
					//entity.JobCandidateId = (Convert.IsDBNull(reader["JobCandidateID"]))?(int)0:(System.Int32)reader["JobCandidateID"];
					entity.SafeNameEmpStartDate = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpStartDate)))?null:(System.DateTime?)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpStartDate)];
					//entity.SafeNameEmpStartDate = (Convert.IsDBNull(reader["Emp.StartDate"]))?DateTime.MinValue:(System.DateTime?)reader["Emp.StartDate"];
					entity.SafeNameEmpEndDate = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpEndDate)))?null:(System.DateTime?)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpEndDate)];
					//entity.SafeNameEmpEndDate = (Convert.IsDBNull(reader["Emp.EndDate"]))?DateTime.MinValue:(System.DateTime?)reader["Emp.EndDate"];
					entity.SafeNameEmpOrgName = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpOrgName)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpOrgName)];
					//entity.SafeNameEmpOrgName = (Convert.IsDBNull(reader["Emp.OrgName"]))?string.Empty:(System.String)reader["Emp.OrgName"];
					entity.SafeNameEmpJobTitle = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpJobTitle)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpJobTitle)];
					//entity.SafeNameEmpJobTitle = (Convert.IsDBNull(reader["Emp.JobTitle"]))?string.Empty:(System.String)reader["Emp.JobTitle"];
					entity.SafeNameEmpResponsibility = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpResponsibility)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpResponsibility)];
					//entity.SafeNameEmpResponsibility = (Convert.IsDBNull(reader["Emp.Responsibility"]))?string.Empty:(System.String)reader["Emp.Responsibility"];
					entity.SafeNameEmpFunctionCategory = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpFunctionCategory)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpFunctionCategory)];
					//entity.SafeNameEmpFunctionCategory = (Convert.IsDBNull(reader["Emp.FunctionCategory"]))?string.Empty:(System.String)reader["Emp.FunctionCategory"];
					entity.SafeNameEmpIndustryCategory = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpIndustryCategory)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpIndustryCategory)];
					//entity.SafeNameEmpIndustryCategory = (Convert.IsDBNull(reader["Emp.IndustryCategory"]))?string.Empty:(System.String)reader["Emp.IndustryCategory"];
					entity.SafeNameEmpLocCountryRegion = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpLocCountryRegion)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpLocCountryRegion)];
					//entity.SafeNameEmpLocCountryRegion = (Convert.IsDBNull(reader["Emp.Loc.CountryRegion"]))?string.Empty:(System.String)reader["Emp.Loc.CountryRegion"];
					entity.SafeNameEmpLocState = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpLocState)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpLocState)];
					//entity.SafeNameEmpLocState = (Convert.IsDBNull(reader["Emp.Loc.State"]))?string.Empty:(System.String)reader["Emp.Loc.State"];
					entity.SafeNameEmpLocCity = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpLocCity)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpLocCity)];
					//entity.SafeNameEmpLocCity = (Convert.IsDBNull(reader["Emp.Loc.City"]))?string.Empty:(System.String)reader["Emp.Loc.City"];
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
		/// Refreshes the <see cref="VJobCandidateEmployment"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VJobCandidateEmployment"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VJobCandidateEmployment entity)
		{
			reader.Read();
			entity.JobCandidateId = (System.Int32)reader[((int)VJobCandidateEmploymentColumn.JobCandidateId)];
			//entity.JobCandidateId = (Convert.IsDBNull(reader["JobCandidateID"]))?(int)0:(System.Int32)reader["JobCandidateID"];
			entity.SafeNameEmpStartDate = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpStartDate)))?null:(System.DateTime?)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpStartDate)];
			//entity.SafeNameEmpStartDate = (Convert.IsDBNull(reader["Emp.StartDate"]))?DateTime.MinValue:(System.DateTime?)reader["Emp.StartDate"];
			entity.SafeNameEmpEndDate = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpEndDate)))?null:(System.DateTime?)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpEndDate)];
			//entity.SafeNameEmpEndDate = (Convert.IsDBNull(reader["Emp.EndDate"]))?DateTime.MinValue:(System.DateTime?)reader["Emp.EndDate"];
			entity.SafeNameEmpOrgName = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpOrgName)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpOrgName)];
			//entity.SafeNameEmpOrgName = (Convert.IsDBNull(reader["Emp.OrgName"]))?string.Empty:(System.String)reader["Emp.OrgName"];
			entity.SafeNameEmpJobTitle = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpJobTitle)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpJobTitle)];
			//entity.SafeNameEmpJobTitle = (Convert.IsDBNull(reader["Emp.JobTitle"]))?string.Empty:(System.String)reader["Emp.JobTitle"];
			entity.SafeNameEmpResponsibility = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpResponsibility)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpResponsibility)];
			//entity.SafeNameEmpResponsibility = (Convert.IsDBNull(reader["Emp.Responsibility"]))?string.Empty:(System.String)reader["Emp.Responsibility"];
			entity.SafeNameEmpFunctionCategory = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpFunctionCategory)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpFunctionCategory)];
			//entity.SafeNameEmpFunctionCategory = (Convert.IsDBNull(reader["Emp.FunctionCategory"]))?string.Empty:(System.String)reader["Emp.FunctionCategory"];
			entity.SafeNameEmpIndustryCategory = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpIndustryCategory)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpIndustryCategory)];
			//entity.SafeNameEmpIndustryCategory = (Convert.IsDBNull(reader["Emp.IndustryCategory"]))?string.Empty:(System.String)reader["Emp.IndustryCategory"];
			entity.SafeNameEmpLocCountryRegion = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpLocCountryRegion)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpLocCountryRegion)];
			//entity.SafeNameEmpLocCountryRegion = (Convert.IsDBNull(reader["Emp.Loc.CountryRegion"]))?string.Empty:(System.String)reader["Emp.Loc.CountryRegion"];
			entity.SafeNameEmpLocState = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpLocState)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpLocState)];
			//entity.SafeNameEmpLocState = (Convert.IsDBNull(reader["Emp.Loc.State"]))?string.Empty:(System.String)reader["Emp.Loc.State"];
			entity.SafeNameEmpLocCity = (reader.IsDBNull(((int)VJobCandidateEmploymentColumn.SafeNameEmpLocCity)))?null:(System.String)reader[((int)VJobCandidateEmploymentColumn.SafeNameEmpLocCity)];
			//entity.SafeNameEmpLocCity = (Convert.IsDBNull(reader["Emp.Loc.City"]))?string.Empty:(System.String)reader["Emp.Loc.City"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VJobCandidateEmployment"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VJobCandidateEmployment"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VJobCandidateEmployment entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobCandidateId = (Convert.IsDBNull(dataRow["JobCandidateID"]))?(int)0:(System.Int32)dataRow["JobCandidateID"];
			entity.SafeNameEmpStartDate = (Convert.IsDBNull(dataRow["Emp.StartDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["Emp.StartDate"];
			entity.SafeNameEmpEndDate = (Convert.IsDBNull(dataRow["Emp.EndDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["Emp.EndDate"];
			entity.SafeNameEmpOrgName = (Convert.IsDBNull(dataRow["Emp.OrgName"]))?string.Empty:(System.String)dataRow["Emp.OrgName"];
			entity.SafeNameEmpJobTitle = (Convert.IsDBNull(dataRow["Emp.JobTitle"]))?string.Empty:(System.String)dataRow["Emp.JobTitle"];
			entity.SafeNameEmpResponsibility = (Convert.IsDBNull(dataRow["Emp.Responsibility"]))?string.Empty:(System.String)dataRow["Emp.Responsibility"];
			entity.SafeNameEmpFunctionCategory = (Convert.IsDBNull(dataRow["Emp.FunctionCategory"]))?string.Empty:(System.String)dataRow["Emp.FunctionCategory"];
			entity.SafeNameEmpIndustryCategory = (Convert.IsDBNull(dataRow["Emp.IndustryCategory"]))?string.Empty:(System.String)dataRow["Emp.IndustryCategory"];
			entity.SafeNameEmpLocCountryRegion = (Convert.IsDBNull(dataRow["Emp.Loc.CountryRegion"]))?string.Empty:(System.String)dataRow["Emp.Loc.CountryRegion"];
			entity.SafeNameEmpLocState = (Convert.IsDBNull(dataRow["Emp.Loc.State"]))?string.Empty:(System.String)dataRow["Emp.Loc.State"];
			entity.SafeNameEmpLocCity = (Convert.IsDBNull(dataRow["Emp.Loc.City"]))?string.Empty:(System.String)dataRow["Emp.Loc.City"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VJobCandidateEmploymentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEmployment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEmploymentFilterBuilder : SqlFilterBuilder<VJobCandidateEmploymentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentFilterBuilder class.
		/// </summary>
		public VJobCandidateEmploymentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateEmploymentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateEmploymentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateEmploymentFilterBuilder

	#region VJobCandidateEmploymentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEmployment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEmploymentParameterBuilder : ParameterizedSqlFilterBuilder<VJobCandidateEmploymentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentParameterBuilder class.
		/// </summary>
		public VJobCandidateEmploymentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateEmploymentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateEmploymentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateEmploymentParameterBuilder
	
	#region VJobCandidateEmploymentSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEmployment"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VJobCandidateEmploymentSortBuilder : SqlSortBuilder<VJobCandidateEmploymentColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEmploymentSqlSortBuilder class.
		/// </summary>
		public VJobCandidateEmploymentSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VJobCandidateEmploymentSortBuilder

} // end namespace
