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
	/// This class is the base class for any <see cref="VEmployeeDepartmentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VEmployeeDepartmentProviderBaseCore : EntityViewProviderBase<VEmployeeDepartment>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VEmployeeDepartment&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VEmployeeDepartment&gt;"/></returns>
		protected static VList&lt;VEmployeeDepartment&gt; Fill(DataSet dataSet, VList<VEmployeeDepartment> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VEmployeeDepartment>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VEmployeeDepartment&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VEmployeeDepartment>"/></returns>
		protected static VList&lt;VEmployeeDepartment&gt; Fill(DataTable dataTable, VList<VEmployeeDepartment> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VEmployeeDepartment c = new VEmployeeDepartment();
					c.EmployeeId = (Convert.IsDBNull(row["EmployeeID"]))?(int)0:(System.Int32)row["EmployeeID"];
					c.Title = (Convert.IsDBNull(row["Title"]))?string.Empty:(System.String)row["Title"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.MiddleName = (Convert.IsDBNull(row["MiddleName"]))?string.Empty:(System.String)row["MiddleName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.Suffix = (Convert.IsDBNull(row["Suffix"]))?string.Empty:(System.String)row["Suffix"];
					c.JobTitle = (Convert.IsDBNull(row["JobTitle"]))?string.Empty:(System.String)row["JobTitle"];
					c.Department = (Convert.IsDBNull(row["Department"]))?string.Empty:(System.String)row["Department"];
					c.GroupName = (Convert.IsDBNull(row["GroupName"]))?string.Empty:(System.String)row["GroupName"];
					c.StartDate = (Convert.IsDBNull(row["StartDate"]))?DateTime.MinValue:(System.DateTime)row["StartDate"];
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
		/// Fill an <see cref="VList&lt;VEmployeeDepartment&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VEmployeeDepartment&gt;"/></returns>
		protected VList<VEmployeeDepartment> Fill(IDataReader reader, VList<VEmployeeDepartment> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VEmployeeDepartment entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VEmployeeDepartment>("VEmployeeDepartment",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VEmployeeDepartment();
					}
					
					entity.SuppressEntityEvents = true;

					entity.EmployeeId = (System.Int32)reader[((int)VEmployeeDepartmentColumn.EmployeeId)];
					//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32)reader["EmployeeID"];
					entity.Title = (reader.IsDBNull(((int)VEmployeeDepartmentColumn.Title)))?null:(System.String)reader[((int)VEmployeeDepartmentColumn.Title)];
					//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
					entity.FirstName = (System.String)reader[((int)VEmployeeDepartmentColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.MiddleName = (reader.IsDBNull(((int)VEmployeeDepartmentColumn.MiddleName)))?null:(System.String)reader[((int)VEmployeeDepartmentColumn.MiddleName)];
					//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
					entity.LastName = (System.String)reader[((int)VEmployeeDepartmentColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Suffix = (reader.IsDBNull(((int)VEmployeeDepartmentColumn.Suffix)))?null:(System.String)reader[((int)VEmployeeDepartmentColumn.Suffix)];
					//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
					entity.JobTitle = (System.String)reader[((int)VEmployeeDepartmentColumn.JobTitle)];
					//entity.JobTitle = (Convert.IsDBNull(reader["JobTitle"]))?string.Empty:(System.String)reader["JobTitle"];
					entity.Department = (System.String)reader[((int)VEmployeeDepartmentColumn.Department)];
					//entity.Department = (Convert.IsDBNull(reader["Department"]))?string.Empty:(System.String)reader["Department"];
					entity.GroupName = (System.String)reader[((int)VEmployeeDepartmentColumn.GroupName)];
					//entity.GroupName = (Convert.IsDBNull(reader["GroupName"]))?string.Empty:(System.String)reader["GroupName"];
					entity.StartDate = (System.DateTime)reader[((int)VEmployeeDepartmentColumn.StartDate)];
					//entity.StartDate = (Convert.IsDBNull(reader["StartDate"]))?DateTime.MinValue:(System.DateTime)reader["StartDate"];
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
		/// Refreshes the <see cref="VEmployeeDepartment"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VEmployeeDepartment"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VEmployeeDepartment entity)
		{
			reader.Read();
			entity.EmployeeId = (System.Int32)reader[((int)VEmployeeDepartmentColumn.EmployeeId)];
			//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32)reader["EmployeeID"];
			entity.Title = (reader.IsDBNull(((int)VEmployeeDepartmentColumn.Title)))?null:(System.String)reader[((int)VEmployeeDepartmentColumn.Title)];
			//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
			entity.FirstName = (System.String)reader[((int)VEmployeeDepartmentColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.MiddleName = (reader.IsDBNull(((int)VEmployeeDepartmentColumn.MiddleName)))?null:(System.String)reader[((int)VEmployeeDepartmentColumn.MiddleName)];
			//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
			entity.LastName = (System.String)reader[((int)VEmployeeDepartmentColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Suffix = (reader.IsDBNull(((int)VEmployeeDepartmentColumn.Suffix)))?null:(System.String)reader[((int)VEmployeeDepartmentColumn.Suffix)];
			//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
			entity.JobTitle = (System.String)reader[((int)VEmployeeDepartmentColumn.JobTitle)];
			//entity.JobTitle = (Convert.IsDBNull(reader["JobTitle"]))?string.Empty:(System.String)reader["JobTitle"];
			entity.Department = (System.String)reader[((int)VEmployeeDepartmentColumn.Department)];
			//entity.Department = (Convert.IsDBNull(reader["Department"]))?string.Empty:(System.String)reader["Department"];
			entity.GroupName = (System.String)reader[((int)VEmployeeDepartmentColumn.GroupName)];
			//entity.GroupName = (Convert.IsDBNull(reader["GroupName"]))?string.Empty:(System.String)reader["GroupName"];
			entity.StartDate = (System.DateTime)reader[((int)VEmployeeDepartmentColumn.StartDate)];
			//entity.StartDate = (Convert.IsDBNull(reader["StartDate"]))?DateTime.MinValue:(System.DateTime)reader["StartDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VEmployeeDepartment"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VEmployeeDepartment"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VEmployeeDepartment entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeId = (Convert.IsDBNull(dataRow["EmployeeID"]))?(int)0:(System.Int32)dataRow["EmployeeID"];
			entity.Title = (Convert.IsDBNull(dataRow["Title"]))?string.Empty:(System.String)dataRow["Title"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?string.Empty:(System.String)dataRow["FirstName"];
			entity.MiddleName = (Convert.IsDBNull(dataRow["MiddleName"]))?string.Empty:(System.String)dataRow["MiddleName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?string.Empty:(System.String)dataRow["LastName"];
			entity.Suffix = (Convert.IsDBNull(dataRow["Suffix"]))?string.Empty:(System.String)dataRow["Suffix"];
			entity.JobTitle = (Convert.IsDBNull(dataRow["JobTitle"]))?string.Empty:(System.String)dataRow["JobTitle"];
			entity.Department = (Convert.IsDBNull(dataRow["Department"]))?string.Empty:(System.String)dataRow["Department"];
			entity.GroupName = (Convert.IsDBNull(dataRow["GroupName"]))?string.Empty:(System.String)dataRow["GroupName"];
			entity.StartDate = (Convert.IsDBNull(dataRow["StartDate"]))?DateTime.MinValue:(System.DateTime)dataRow["StartDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VEmployeeDepartmentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentFilterBuilder : SqlFilterBuilder<VEmployeeDepartmentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentFilterBuilder class.
		/// </summary>
		public VEmployeeDepartmentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeDepartmentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeDepartmentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeDepartmentFilterBuilder

	#region VEmployeeDepartmentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentParameterBuilder : ParameterizedSqlFilterBuilder<VEmployeeDepartmentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentParameterBuilder class.
		/// </summary>
		public VEmployeeDepartmentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeDepartmentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeDepartmentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeDepartmentParameterBuilder
	
	#region VEmployeeDepartmentSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartment"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VEmployeeDepartmentSortBuilder : SqlSortBuilder<VEmployeeDepartmentColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentSqlSortBuilder class.
		/// </summary>
		public VEmployeeDepartmentSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VEmployeeDepartmentSortBuilder

} // end namespace
