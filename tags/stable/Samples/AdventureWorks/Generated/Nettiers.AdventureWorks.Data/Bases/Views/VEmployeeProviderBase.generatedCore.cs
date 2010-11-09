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
	/// This class is the base class for any <see cref="VEmployeeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VEmployeeProviderBaseCore : EntityViewProviderBase<VEmployee>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VEmployee&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VEmployee&gt;"/></returns>
		protected static VList&lt;VEmployee&gt; Fill(DataSet dataSet, VList<VEmployee> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VEmployee>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VEmployee&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VEmployee>"/></returns>
		protected static VList&lt;VEmployee&gt; Fill(DataTable dataTable, VList<VEmployee> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VEmployee c = new VEmployee();
					c.EmployeeId = (Convert.IsDBNull(row["EmployeeID"]))?(int)0:(System.Int32)row["EmployeeID"];
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
					c.AdditionalContactInfo = (Convert.IsDBNull(row["AdditionalContactInfo"]))?null:(string)row["AdditionalContactInfo"];
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
		/// Fill an <see cref="VList&lt;VEmployee&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VEmployee&gt;"/></returns>
		protected VList<VEmployee> Fill(IDataReader reader, VList<VEmployee> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VEmployee entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VEmployee>("VEmployee",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VEmployee();
					}
					
					entity.SuppressEntityEvents = true;

					entity.EmployeeId = (System.Int32)reader[((int)VEmployeeColumn.EmployeeId)];
					//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32)reader["EmployeeID"];
					entity.Title = (reader.IsDBNull(((int)VEmployeeColumn.Title)))?null:(System.String)reader[((int)VEmployeeColumn.Title)];
					//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
					entity.FirstName = (System.String)reader[((int)VEmployeeColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.MiddleName = (reader.IsDBNull(((int)VEmployeeColumn.MiddleName)))?null:(System.String)reader[((int)VEmployeeColumn.MiddleName)];
					//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
					entity.LastName = (System.String)reader[((int)VEmployeeColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Suffix = (reader.IsDBNull(((int)VEmployeeColumn.Suffix)))?null:(System.String)reader[((int)VEmployeeColumn.Suffix)];
					//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
					entity.JobTitle = (System.String)reader[((int)VEmployeeColumn.JobTitle)];
					//entity.JobTitle = (Convert.IsDBNull(reader["JobTitle"]))?string.Empty:(System.String)reader["JobTitle"];
					entity.Phone = (reader.IsDBNull(((int)VEmployeeColumn.Phone)))?null:(System.String)reader[((int)VEmployeeColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.EmailAddress = (reader.IsDBNull(((int)VEmployeeColumn.EmailAddress)))?null:(System.String)reader[((int)VEmployeeColumn.EmailAddress)];
					//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
					entity.EmailPromotion = (System.Int32)reader[((int)VEmployeeColumn.EmailPromotion)];
					//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
					entity.AddressLine1 = (System.String)reader[((int)VEmployeeColumn.AddressLine1)];
					//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
					entity.AddressLine2 = (reader.IsDBNull(((int)VEmployeeColumn.AddressLine2)))?null:(System.String)reader[((int)VEmployeeColumn.AddressLine2)];
					//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
					entity.City = (System.String)reader[((int)VEmployeeColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.StateProvinceName = (System.String)reader[((int)VEmployeeColumn.StateProvinceName)];
					//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
					entity.PostalCode = (System.String)reader[((int)VEmployeeColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.CountryRegionName = (System.String)reader[((int)VEmployeeColumn.CountryRegionName)];
					//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
					entity.AdditionalContactInfo = (reader.IsDBNull(((int)VEmployeeColumn.AdditionalContactInfo)))?null:(string)reader[((int)VEmployeeColumn.AdditionalContactInfo)];
					//entity.AdditionalContactInfo = (Convert.IsDBNull(reader["AdditionalContactInfo"]))?null:(string)reader["AdditionalContactInfo"];
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
		/// Refreshes the <see cref="VEmployee"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VEmployee"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VEmployee entity)
		{
			reader.Read();
			entity.EmployeeId = (System.Int32)reader[((int)VEmployeeColumn.EmployeeId)];
			//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32)reader["EmployeeID"];
			entity.Title = (reader.IsDBNull(((int)VEmployeeColumn.Title)))?null:(System.String)reader[((int)VEmployeeColumn.Title)];
			//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
			entity.FirstName = (System.String)reader[((int)VEmployeeColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.MiddleName = (reader.IsDBNull(((int)VEmployeeColumn.MiddleName)))?null:(System.String)reader[((int)VEmployeeColumn.MiddleName)];
			//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
			entity.LastName = (System.String)reader[((int)VEmployeeColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Suffix = (reader.IsDBNull(((int)VEmployeeColumn.Suffix)))?null:(System.String)reader[((int)VEmployeeColumn.Suffix)];
			//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
			entity.JobTitle = (System.String)reader[((int)VEmployeeColumn.JobTitle)];
			//entity.JobTitle = (Convert.IsDBNull(reader["JobTitle"]))?string.Empty:(System.String)reader["JobTitle"];
			entity.Phone = (reader.IsDBNull(((int)VEmployeeColumn.Phone)))?null:(System.String)reader[((int)VEmployeeColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.EmailAddress = (reader.IsDBNull(((int)VEmployeeColumn.EmailAddress)))?null:(System.String)reader[((int)VEmployeeColumn.EmailAddress)];
			//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
			entity.EmailPromotion = (System.Int32)reader[((int)VEmployeeColumn.EmailPromotion)];
			//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
			entity.AddressLine1 = (System.String)reader[((int)VEmployeeColumn.AddressLine1)];
			//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
			entity.AddressLine2 = (reader.IsDBNull(((int)VEmployeeColumn.AddressLine2)))?null:(System.String)reader[((int)VEmployeeColumn.AddressLine2)];
			//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
			entity.City = (System.String)reader[((int)VEmployeeColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.StateProvinceName = (System.String)reader[((int)VEmployeeColumn.StateProvinceName)];
			//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
			entity.PostalCode = (System.String)reader[((int)VEmployeeColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.CountryRegionName = (System.String)reader[((int)VEmployeeColumn.CountryRegionName)];
			//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
			entity.AdditionalContactInfo = (reader.IsDBNull(((int)VEmployeeColumn.AdditionalContactInfo)))?null:(string)reader[((int)VEmployeeColumn.AdditionalContactInfo)];
			//entity.AdditionalContactInfo = (Convert.IsDBNull(reader["AdditionalContactInfo"]))?null:(string)reader["AdditionalContactInfo"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VEmployee"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VEmployee"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VEmployee entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeId = (Convert.IsDBNull(dataRow["EmployeeID"]))?(int)0:(System.Int32)dataRow["EmployeeID"];
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
			entity.AdditionalContactInfo = (Convert.IsDBNull(dataRow["AdditionalContactInfo"]))?null:(string)dataRow["AdditionalContactInfo"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VEmployeeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeFilterBuilder : SqlFilterBuilder<VEmployeeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeFilterBuilder class.
		/// </summary>
		public VEmployeeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeFilterBuilder

	#region VEmployeeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VEmployeeParameterBuilder : ParameterizedSqlFilterBuilder<VEmployeeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeParameterBuilder class.
		/// </summary>
		public VEmployeeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VEmployeeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VEmployeeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VEmployeeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VEmployeeParameterBuilder
	
	#region VEmployeeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VEmployee"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VEmployeeSortBuilder : SqlSortBuilder<VEmployeeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VEmployeeSqlSortBuilder class.
		/// </summary>
		public VEmployeeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VEmployeeSortBuilder

} // end namespace
