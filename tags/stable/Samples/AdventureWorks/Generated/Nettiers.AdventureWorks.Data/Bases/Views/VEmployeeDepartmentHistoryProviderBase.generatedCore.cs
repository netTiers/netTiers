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
	/// This class is the base class for any <see cref="VEmployeeDepartmentHistoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VEmployeeDepartmentHistoryProviderBaseCore : EntityViewProviderBase<VEmployeeDepartmentHistory>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VEmployeeDepartmentHistory&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VEmployeeDepartmentHistory&gt;"/></returns>
		protected static VList&lt;VEmployeeDepartmentHistory&gt; Fill(DataSet dataSet, VList<VEmployeeDepartmentHistory> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VEmployeeDepartmentHistory>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VEmployeeDepartmentHistory&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VEmployeeDepartmentHistory>"/></returns>
		protected static VList&lt;VEmployeeDepartmentHistory&gt; Fill(DataTable dataTable, VList<VEmployeeDepartmentHistory> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VEmployeeDepartmentHistory c = new VEmployeeDepartmentHistory();
					c.EmployeeId = (Convert.IsDBNull(row["EmployeeID"]))?(int)0:(System.Int32)row["EmployeeID"];
					c.Title = (Convert.IsDBNull(row["Title"]))?string.Empty:(System.String)row["Title"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.MiddleName = (Convert.IsDBNull(row["MiddleName"]))?string.Empty:(System.String)row["MiddleName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.Suffix = (Convert.IsDBNull(row["Suffix"]))?string.Empty:(System.String)row["Suffix"];
					c.Shift = (Convert.IsDBNull(row["Shift"]))?string.Empty:(System.String)row["Shift"];
					c.Department = (Convert.IsDBNull(row["Department"]))?string.Empty:(System.String)row["Department"];
					c.GroupName = (Convert.IsDBNull(row["GroupName"]))?string.Empty:(System.String)row["GroupName"];
					c.StartDate = (Convert.IsDBNull(row["StartDate"]))?DateTime.MinValue:(System.DateTime)row["StartDate"];
					c.EndDate = (Convert.IsDBNull(row["EndDate"]))?DateTime.MinValue:(System.DateTime?)row["EndDate"];
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
		/// Fill an <see cref="VList&lt;VEmployeeDepartmentHistory&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VEmployeeDepartmentHistory&gt;"/></returns>
		protected VList<VEmployeeDepartmentHistory> Fill(IDataReader reader, VList<VEmployeeDepartmentHistory> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VEmployeeDepartmentHistory entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VEmployeeDepartmentHistory>("VEmployeeDepartmentHistory",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VEmployeeDepartmentHistory();
					}
					
					entity.SuppressEntityEvents = true;

					entity.EmployeeId = (System.Int32)reader[((int)VEmployeeDepartmentHistoryColumn.EmployeeId)];
					//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32)reader["EmployeeID"];
					entity.Title = (reader.IsDBNull(((int)VEmployeeDepartmentHistoryColumn.Title)))?null:(System.String)reader[((int)VEmployeeDepartmentHistoryColumn.Title)];
					//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
					entity.FirstName = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.MiddleName = (reader.IsDBNull(((int)VEmployeeDepartmentHistoryColumn.MiddleName)))?null:(System.String)reader[((int)VEmployeeDepartmentHistoryColumn.MiddleName)];
					//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
					entity.LastName = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Suffix = (reader.IsDBNull(((int)VEmployeeDepartmentHistoryColumn.Suffix)))?null:(System.String)reader[((int)VEmployeeDepartmentHistoryColumn.Suffix)];
					//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
					entity.Shift = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.Shift)];
					//entity.Shift = (Convert.IsDBNull(reader["Shift"]))?string.Empty:(System.String)reader["Shift"];
					entity.Department = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.Department)];
					//entity.Department = (Convert.IsDBNull(reader["Department"]))?string.Empty:(System.String)reader["Department"];
					entity.GroupName = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.GroupName)];
					//entity.GroupName = (Convert.IsDBNull(reader["GroupName"]))?string.Empty:(System.String)reader["GroupName"];
					entity.StartDate = (System.DateTime)reader[((int)VEmployeeDepartmentHistoryColumn.StartDate)];
					//entity.StartDate = (Convert.IsDBNull(reader["StartDate"]))?DateTime.MinValue:(System.DateTime)reader["StartDate"];
					entity.EndDate = (reader.IsDBNull(((int)VEmployeeDepartmentHistoryColumn.EndDate)))?null:(System.DateTime?)reader[((int)VEmployeeDepartmentHistoryColumn.EndDate)];
					//entity.EndDate = (Convert.IsDBNull(reader["EndDate"]))?DateTime.MinValue:(System.DateTime?)reader["EndDate"];
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
		/// Refreshes the <see cref="VEmployeeDepartmentHistory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VEmployeeDepartmentHistory"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VEmployeeDepartmentHistory entity)
		{
			reader.Read();
			entity.EmployeeId = (System.Int32)reader[((int)VEmployeeDepartmentHistoryColumn.EmployeeId)];
			//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32)reader["EmployeeID"];
			entity.Title = (reader.IsDBNull(((int)VEmployeeDepartmentHistoryColumn.Title)))?null:(System.String)reader[((int)VEmployeeDepartmentHistoryColumn.Title)];
			//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
			entity.FirstName = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.MiddleName = (reader.IsDBNull(((int)VEmployeeDepartmentHistoryColumn.MiddleName)))?null:(System.String)reader[((int)VEmployeeDepartmentHistoryColumn.MiddleName)];
			//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
			entity.LastName = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Suffix = (reader.IsDBNull(((int)VEmployeeDepartmentHistoryColumn.Suffix)))?null:(System.String)reader[((int)VEmployeeDepartmentHistoryColumn.Suffix)];
			//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
			entity.Shift = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.Shift)];
			//entity.Shift = (Convert.IsDBNull(reader["Shift"]))?string.Empty:(System.String)reader["Shift"];
			entity.Department = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.Department)];
			//entity.Department = (Convert.IsDBNull(reader["Department"]))?string.Empty:(System.String)reader["Department"];
			entity.GroupName = (System.String)reader[((int)VEmployeeDepartmentHistoryColumn.GroupName)];
			//entity.GroupName = (Convert.IsDBNull(reader["GroupName"]))?string.Empty:(System.String)reader["GroupName"];
			entity.StartDate = (System.DateTime)reader[((int)VEmployeeDepartmentHistoryColumn.StartDate)];
			//entity.StartDate = (Convert.IsDBNull(reader["StartDate"]))?DateTime.MinValue:(System.DateTime)reader["StartDate"];
			entity.EndDate = (reader.IsDBNull(((int)VEmployeeDepartmentHistoryColumn.EndDate)))?null:(System.DateTime?)reader[((int)VEmployeeDepartmentHistoryColumn.EndDate)];
			//entity.EndDate = (Convert.IsDBNull(reader["EndDate"]))?DateTime.MinValue:(System.DateTime?)reader["EndDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VEmployeeDepartmentHistory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VEmployeeDepartmentHistory"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VEmployeeDepartmentHistory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeId = (Convert.IsDBNull(dataRow["EmployeeID"]))?(int)0:(System.Int32)dataRow["EmployeeID"];
			entity.Title = (Convert.IsDBNull(dataRow["Title"]))?string.Empty:(System.String)dataRow["Title"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?string.Empty:(System.String)dataRow["FirstName"];
			entity.MiddleName = (Convert.IsDBNull(dataRow["MiddleName"]))?string.Empty:(System.String)dataRow["MiddleName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?string.Empty:(System.String)dataRow["LastName"];
			entity.Suffix = (Convert.IsDBNull(dataRow["Suffix"]))?string.Empty:(System.String)dataRow["Suffix"];
			entity.Shift = (Convert.IsDBNull(dataRow["Shift"]))?string.Empty:(System.String)dataRow["Shift"];
			entity.Department = (Convert.IsDBNull(dataRow["Department"]))?string.Empty:(System.String)dataRow["Department"];
			entity.GroupName = (Convert.IsDBNull(dataRow["GroupName"]))?string.Empty:(System.String)dataRow["GroupName"];
			entity.StartDate = (Convert.IsDBNull(dataRow["StartDate"]))?DateTime.MinValue:(System.DateTime)dataRow["StartDate"];
			entity.EndDate = (Convert.IsDBNull(dataRow["EndDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["EndDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VEmployeeDepartmentHistoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentHistoryFilterBuilder : SqlFilterBuilder<VEmployeeDepartmentHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryFilterBuilder class.
		/// </summary>
		public VEmployeeDepartmentHistoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeDepartmentHistoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeDepartmentHistoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeDepartmentHistoryFilterBuilder

	#region VEmployeeDepartmentHistoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartmentHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeDepartmentHistoryParameterBuilder : ParameterizedSqlFilterBuilder<VEmployeeDepartmentHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryParameterBuilder class.
		/// </summary>
		public VEmployeeDepartmentHistoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeDepartmentHistoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeDepartmentHistoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeDepartmentHistoryParameterBuilder
	
	#region VEmployeeDepartmentHistorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployeeDepartmentHistory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VEmployeeDepartmentHistorySortBuilder : SqlSortBuilder<VEmployeeDepartmentHistoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeDepartmentHistorySqlSortBuilder class.
		/// </summary>
		public VEmployeeDepartmentHistorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VEmployeeDepartmentHistorySortBuilder

} // end namespace
