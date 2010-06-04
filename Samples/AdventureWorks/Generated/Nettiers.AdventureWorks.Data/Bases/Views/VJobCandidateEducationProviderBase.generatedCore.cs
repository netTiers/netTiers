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
	/// This class is the base class for any <see cref="VJobCandidateEducationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VJobCandidateEducationProviderBaseCore : EntityViewProviderBase<VJobCandidateEducation>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VJobCandidateEducation&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VJobCandidateEducation&gt;"/></returns>
		protected static VList&lt;VJobCandidateEducation&gt; Fill(DataSet dataSet, VList<VJobCandidateEducation> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VJobCandidateEducation>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VJobCandidateEducation&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VJobCandidateEducation>"/></returns>
		protected static VList&lt;VJobCandidateEducation&gt; Fill(DataTable dataTable, VList<VJobCandidateEducation> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VJobCandidateEducation c = new VJobCandidateEducation();
					c.JobCandidateId = (Convert.IsDBNull(row["JobCandidateID"]))?(int)0:(System.Int32)row["JobCandidateID"];
					c.SafeNameEduLevel = (Convert.IsDBNull(row["Edu.Level"]))?string.Empty:(System.String)row["Edu.Level"];
					c.SafeNameEduStartDate = (Convert.IsDBNull(row["Edu.StartDate"]))?DateTime.MinValue:(System.DateTime?)row["Edu.StartDate"];
					c.SafeNameEduEndDate = (Convert.IsDBNull(row["Edu.EndDate"]))?DateTime.MinValue:(System.DateTime?)row["Edu.EndDate"];
					c.SafeNameEduDegree = (Convert.IsDBNull(row["Edu.Degree"]))?string.Empty:(System.String)row["Edu.Degree"];
					c.SafeNameEduMajor = (Convert.IsDBNull(row["Edu.Major"]))?string.Empty:(System.String)row["Edu.Major"];
					c.SafeNameEduMinor = (Convert.IsDBNull(row["Edu.Minor"]))?string.Empty:(System.String)row["Edu.Minor"];
					c.SafeNameEduGpa = (Convert.IsDBNull(row["Edu.GPA"]))?string.Empty:(System.String)row["Edu.GPA"];
					c.SafeNameEduGpaScale = (Convert.IsDBNull(row["Edu.GPAScale"]))?string.Empty:(System.String)row["Edu.GPAScale"];
					c.SafeNameEduSchool = (Convert.IsDBNull(row["Edu.School"]))?string.Empty:(System.String)row["Edu.School"];
					c.SafeNameEduLocCountryRegion = (Convert.IsDBNull(row["Edu.Loc.CountryRegion"]))?string.Empty:(System.String)row["Edu.Loc.CountryRegion"];
					c.SafeNameEduLocState = (Convert.IsDBNull(row["Edu.Loc.State"]))?string.Empty:(System.String)row["Edu.Loc.State"];
					c.SafeNameEduLocCity = (Convert.IsDBNull(row["Edu.Loc.City"]))?string.Empty:(System.String)row["Edu.Loc.City"];
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
		/// Fill an <see cref="VList&lt;VJobCandidateEducation&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VJobCandidateEducation&gt;"/></returns>
		protected VList<VJobCandidateEducation> Fill(IDataReader reader, VList<VJobCandidateEducation> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VJobCandidateEducation entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VJobCandidateEducation>("VJobCandidateEducation",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VJobCandidateEducation();
					}
					
					entity.SuppressEntityEvents = true;

					entity.JobCandidateId = (System.Int32)reader[((int)VJobCandidateEducationColumn.JobCandidateId)];
					//entity.JobCandidateId = (Convert.IsDBNull(reader["JobCandidateID"]))?(int)0:(System.Int32)reader["JobCandidateID"];
					entity.SafeNameEduLevel = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduLevel)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduLevel)];
					//entity.SafeNameEduLevel = (Convert.IsDBNull(reader["Edu.Level"]))?string.Empty:(System.String)reader["Edu.Level"];
					entity.SafeNameEduStartDate = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduStartDate)))?null:(System.DateTime?)reader[((int)VJobCandidateEducationColumn.SafeNameEduStartDate)];
					//entity.SafeNameEduStartDate = (Convert.IsDBNull(reader["Edu.StartDate"]))?DateTime.MinValue:(System.DateTime?)reader["Edu.StartDate"];
					entity.SafeNameEduEndDate = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduEndDate)))?null:(System.DateTime?)reader[((int)VJobCandidateEducationColumn.SafeNameEduEndDate)];
					//entity.SafeNameEduEndDate = (Convert.IsDBNull(reader["Edu.EndDate"]))?DateTime.MinValue:(System.DateTime?)reader["Edu.EndDate"];
					entity.SafeNameEduDegree = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduDegree)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduDegree)];
					//entity.SafeNameEduDegree = (Convert.IsDBNull(reader["Edu.Degree"]))?string.Empty:(System.String)reader["Edu.Degree"];
					entity.SafeNameEduMajor = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduMajor)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduMajor)];
					//entity.SafeNameEduMajor = (Convert.IsDBNull(reader["Edu.Major"]))?string.Empty:(System.String)reader["Edu.Major"];
					entity.SafeNameEduMinor = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduMinor)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduMinor)];
					//entity.SafeNameEduMinor = (Convert.IsDBNull(reader["Edu.Minor"]))?string.Empty:(System.String)reader["Edu.Minor"];
					entity.SafeNameEduGpa = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduGpa)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduGpa)];
					//entity.SafeNameEduGpa = (Convert.IsDBNull(reader["Edu.GPA"]))?string.Empty:(System.String)reader["Edu.GPA"];
					entity.SafeNameEduGpaScale = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduGpaScale)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduGpaScale)];
					//entity.SafeNameEduGpaScale = (Convert.IsDBNull(reader["Edu.GPAScale"]))?string.Empty:(System.String)reader["Edu.GPAScale"];
					entity.SafeNameEduSchool = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduSchool)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduSchool)];
					//entity.SafeNameEduSchool = (Convert.IsDBNull(reader["Edu.School"]))?string.Empty:(System.String)reader["Edu.School"];
					entity.SafeNameEduLocCountryRegion = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduLocCountryRegion)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduLocCountryRegion)];
					//entity.SafeNameEduLocCountryRegion = (Convert.IsDBNull(reader["Edu.Loc.CountryRegion"]))?string.Empty:(System.String)reader["Edu.Loc.CountryRegion"];
					entity.SafeNameEduLocState = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduLocState)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduLocState)];
					//entity.SafeNameEduLocState = (Convert.IsDBNull(reader["Edu.Loc.State"]))?string.Empty:(System.String)reader["Edu.Loc.State"];
					entity.SafeNameEduLocCity = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduLocCity)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduLocCity)];
					//entity.SafeNameEduLocCity = (Convert.IsDBNull(reader["Edu.Loc.City"]))?string.Empty:(System.String)reader["Edu.Loc.City"];
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
		/// Refreshes the <see cref="VJobCandidateEducation"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VJobCandidateEducation"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VJobCandidateEducation entity)
		{
			reader.Read();
			entity.JobCandidateId = (System.Int32)reader[((int)VJobCandidateEducationColumn.JobCandidateId)];
			//entity.JobCandidateId = (Convert.IsDBNull(reader["JobCandidateID"]))?(int)0:(System.Int32)reader["JobCandidateID"];
			entity.SafeNameEduLevel = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduLevel)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduLevel)];
			//entity.SafeNameEduLevel = (Convert.IsDBNull(reader["Edu.Level"]))?string.Empty:(System.String)reader["Edu.Level"];
			entity.SafeNameEduStartDate = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduStartDate)))?null:(System.DateTime?)reader[((int)VJobCandidateEducationColumn.SafeNameEduStartDate)];
			//entity.SafeNameEduStartDate = (Convert.IsDBNull(reader["Edu.StartDate"]))?DateTime.MinValue:(System.DateTime?)reader["Edu.StartDate"];
			entity.SafeNameEduEndDate = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduEndDate)))?null:(System.DateTime?)reader[((int)VJobCandidateEducationColumn.SafeNameEduEndDate)];
			//entity.SafeNameEduEndDate = (Convert.IsDBNull(reader["Edu.EndDate"]))?DateTime.MinValue:(System.DateTime?)reader["Edu.EndDate"];
			entity.SafeNameEduDegree = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduDegree)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduDegree)];
			//entity.SafeNameEduDegree = (Convert.IsDBNull(reader["Edu.Degree"]))?string.Empty:(System.String)reader["Edu.Degree"];
			entity.SafeNameEduMajor = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduMajor)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduMajor)];
			//entity.SafeNameEduMajor = (Convert.IsDBNull(reader["Edu.Major"]))?string.Empty:(System.String)reader["Edu.Major"];
			entity.SafeNameEduMinor = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduMinor)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduMinor)];
			//entity.SafeNameEduMinor = (Convert.IsDBNull(reader["Edu.Minor"]))?string.Empty:(System.String)reader["Edu.Minor"];
			entity.SafeNameEduGpa = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduGpa)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduGpa)];
			//entity.SafeNameEduGpa = (Convert.IsDBNull(reader["Edu.GPA"]))?string.Empty:(System.String)reader["Edu.GPA"];
			entity.SafeNameEduGpaScale = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduGpaScale)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduGpaScale)];
			//entity.SafeNameEduGpaScale = (Convert.IsDBNull(reader["Edu.GPAScale"]))?string.Empty:(System.String)reader["Edu.GPAScale"];
			entity.SafeNameEduSchool = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduSchool)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduSchool)];
			//entity.SafeNameEduSchool = (Convert.IsDBNull(reader["Edu.School"]))?string.Empty:(System.String)reader["Edu.School"];
			entity.SafeNameEduLocCountryRegion = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduLocCountryRegion)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduLocCountryRegion)];
			//entity.SafeNameEduLocCountryRegion = (Convert.IsDBNull(reader["Edu.Loc.CountryRegion"]))?string.Empty:(System.String)reader["Edu.Loc.CountryRegion"];
			entity.SafeNameEduLocState = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduLocState)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduLocState)];
			//entity.SafeNameEduLocState = (Convert.IsDBNull(reader["Edu.Loc.State"]))?string.Empty:(System.String)reader["Edu.Loc.State"];
			entity.SafeNameEduLocCity = (reader.IsDBNull(((int)VJobCandidateEducationColumn.SafeNameEduLocCity)))?null:(System.String)reader[((int)VJobCandidateEducationColumn.SafeNameEduLocCity)];
			//entity.SafeNameEduLocCity = (Convert.IsDBNull(reader["Edu.Loc.City"]))?string.Empty:(System.String)reader["Edu.Loc.City"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VJobCandidateEducation"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VJobCandidateEducation"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VJobCandidateEducation entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobCandidateId = (Convert.IsDBNull(dataRow["JobCandidateID"]))?(int)0:(System.Int32)dataRow["JobCandidateID"];
			entity.SafeNameEduLevel = (Convert.IsDBNull(dataRow["Edu.Level"]))?string.Empty:(System.String)dataRow["Edu.Level"];
			entity.SafeNameEduStartDate = (Convert.IsDBNull(dataRow["Edu.StartDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["Edu.StartDate"];
			entity.SafeNameEduEndDate = (Convert.IsDBNull(dataRow["Edu.EndDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["Edu.EndDate"];
			entity.SafeNameEduDegree = (Convert.IsDBNull(dataRow["Edu.Degree"]))?string.Empty:(System.String)dataRow["Edu.Degree"];
			entity.SafeNameEduMajor = (Convert.IsDBNull(dataRow["Edu.Major"]))?string.Empty:(System.String)dataRow["Edu.Major"];
			entity.SafeNameEduMinor = (Convert.IsDBNull(dataRow["Edu.Minor"]))?string.Empty:(System.String)dataRow["Edu.Minor"];
			entity.SafeNameEduGpa = (Convert.IsDBNull(dataRow["Edu.GPA"]))?string.Empty:(System.String)dataRow["Edu.GPA"];
			entity.SafeNameEduGpaScale = (Convert.IsDBNull(dataRow["Edu.GPAScale"]))?string.Empty:(System.String)dataRow["Edu.GPAScale"];
			entity.SafeNameEduSchool = (Convert.IsDBNull(dataRow["Edu.School"]))?string.Empty:(System.String)dataRow["Edu.School"];
			entity.SafeNameEduLocCountryRegion = (Convert.IsDBNull(dataRow["Edu.Loc.CountryRegion"]))?string.Empty:(System.String)dataRow["Edu.Loc.CountryRegion"];
			entity.SafeNameEduLocState = (Convert.IsDBNull(dataRow["Edu.Loc.State"]))?string.Empty:(System.String)dataRow["Edu.Loc.State"];
			entity.SafeNameEduLocCity = (Convert.IsDBNull(dataRow["Edu.Loc.City"]))?string.Empty:(System.String)dataRow["Edu.Loc.City"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VJobCandidateEducationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEducationFilterBuilder : SqlFilterBuilder<VJobCandidateEducationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationFilterBuilder class.
		/// </summary>
		public VJobCandidateEducationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateEducationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateEducationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateEducationFilterBuilder

	#region VJobCandidateEducationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEducation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VJobCandidateEducationParameterBuilder : ParameterizedSqlFilterBuilder<VJobCandidateEducationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationParameterBuilder class.
		/// </summary>
		public VJobCandidateEducationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VJobCandidateEducationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VJobCandidateEducationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VJobCandidateEducationParameterBuilder
	
	#region VJobCandidateEducationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VJobCandidateEducation"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VJobCandidateEducationSortBuilder : SqlSortBuilder<VJobCandidateEducationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VJobCandidateEducationSqlSortBuilder class.
		/// </summary>
		public VJobCandidateEducationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VJobCandidateEducationSortBuilder

} // end namespace
