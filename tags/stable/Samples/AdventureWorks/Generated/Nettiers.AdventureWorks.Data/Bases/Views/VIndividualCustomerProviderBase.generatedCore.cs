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
	/// This class is the base class for any <see cref="VIndividualCustomerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VIndividualCustomerProviderBaseCore : EntityViewProviderBase<VIndividualCustomer>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VIndividualCustomer&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VIndividualCustomer&gt;"/></returns>
		protected static VList&lt;VIndividualCustomer&gt; Fill(DataSet dataSet, VList<VIndividualCustomer> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VIndividualCustomer>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VIndividualCustomer&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VIndividualCustomer>"/></returns>
		protected static VList&lt;VIndividualCustomer&gt; Fill(DataTable dataTable, VList<VIndividualCustomer> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VIndividualCustomer c = new VIndividualCustomer();
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.Title = (Convert.IsDBNull(row["Title"]))?string.Empty:(System.String)row["Title"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.MiddleName = (Convert.IsDBNull(row["MiddleName"]))?string.Empty:(System.String)row["MiddleName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.Suffix = (Convert.IsDBNull(row["Suffix"]))?string.Empty:(System.String)row["Suffix"];
					c.Phone = (Convert.IsDBNull(row["Phone"]))?string.Empty:(System.String)row["Phone"];
					c.EmailAddress = (Convert.IsDBNull(row["EmailAddress"]))?string.Empty:(System.String)row["EmailAddress"];
					c.EmailPromotion = (Convert.IsDBNull(row["EmailPromotion"]))?(int)0:(System.Int32)row["EmailPromotion"];
					c.AddressType = (Convert.IsDBNull(row["AddressType"]))?string.Empty:(System.String)row["AddressType"];
					c.AddressLine1 = (Convert.IsDBNull(row["AddressLine1"]))?string.Empty:(System.String)row["AddressLine1"];
					c.AddressLine2 = (Convert.IsDBNull(row["AddressLine2"]))?string.Empty:(System.String)row["AddressLine2"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.StateProvinceName = (Convert.IsDBNull(row["StateProvinceName"]))?string.Empty:(System.String)row["StateProvinceName"];
					c.PostalCode = (Convert.IsDBNull(row["PostalCode"]))?string.Empty:(System.String)row["PostalCode"];
					c.CountryRegionName = (Convert.IsDBNull(row["CountryRegionName"]))?string.Empty:(System.String)row["CountryRegionName"];
					c.Demographics = (Convert.IsDBNull(row["Demographics"]))?null:(string)row["Demographics"];
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
		/// Fill an <see cref="VList&lt;VIndividualCustomer&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VIndividualCustomer&gt;"/></returns>
		protected VList<VIndividualCustomer> Fill(IDataReader reader, VList<VIndividualCustomer> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VIndividualCustomer entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VIndividualCustomer>("VIndividualCustomer",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VIndividualCustomer();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CustomerId = (System.Int32)reader[((int)VIndividualCustomerColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.Title = (reader.IsDBNull(((int)VIndividualCustomerColumn.Title)))?null:(System.String)reader[((int)VIndividualCustomerColumn.Title)];
					//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
					entity.FirstName = (System.String)reader[((int)VIndividualCustomerColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.MiddleName = (reader.IsDBNull(((int)VIndividualCustomerColumn.MiddleName)))?null:(System.String)reader[((int)VIndividualCustomerColumn.MiddleName)];
					//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
					entity.LastName = (System.String)reader[((int)VIndividualCustomerColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Suffix = (reader.IsDBNull(((int)VIndividualCustomerColumn.Suffix)))?null:(System.String)reader[((int)VIndividualCustomerColumn.Suffix)];
					//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
					entity.Phone = (reader.IsDBNull(((int)VIndividualCustomerColumn.Phone)))?null:(System.String)reader[((int)VIndividualCustomerColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.EmailAddress = (reader.IsDBNull(((int)VIndividualCustomerColumn.EmailAddress)))?null:(System.String)reader[((int)VIndividualCustomerColumn.EmailAddress)];
					//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
					entity.EmailPromotion = (System.Int32)reader[((int)VIndividualCustomerColumn.EmailPromotion)];
					//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
					entity.AddressType = (System.String)reader[((int)VIndividualCustomerColumn.AddressType)];
					//entity.AddressType = (Convert.IsDBNull(reader["AddressType"]))?string.Empty:(System.String)reader["AddressType"];
					entity.AddressLine1 = (System.String)reader[((int)VIndividualCustomerColumn.AddressLine1)];
					//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
					entity.AddressLine2 = (reader.IsDBNull(((int)VIndividualCustomerColumn.AddressLine2)))?null:(System.String)reader[((int)VIndividualCustomerColumn.AddressLine2)];
					//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
					entity.City = (System.String)reader[((int)VIndividualCustomerColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.StateProvinceName = (System.String)reader[((int)VIndividualCustomerColumn.StateProvinceName)];
					//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
					entity.PostalCode = (System.String)reader[((int)VIndividualCustomerColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.CountryRegionName = (System.String)reader[((int)VIndividualCustomerColumn.CountryRegionName)];
					//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
					entity.Demographics = (reader.IsDBNull(((int)VIndividualCustomerColumn.Demographics)))?null:(string)reader[((int)VIndividualCustomerColumn.Demographics)];
					//entity.Demographics = (Convert.IsDBNull(reader["Demographics"]))?null:(string)reader["Demographics"];
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
		/// Refreshes the <see cref="VIndividualCustomer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VIndividualCustomer"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VIndividualCustomer entity)
		{
			reader.Read();
			entity.CustomerId = (System.Int32)reader[((int)VIndividualCustomerColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.Title = (reader.IsDBNull(((int)VIndividualCustomerColumn.Title)))?null:(System.String)reader[((int)VIndividualCustomerColumn.Title)];
			//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
			entity.FirstName = (System.String)reader[((int)VIndividualCustomerColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.MiddleName = (reader.IsDBNull(((int)VIndividualCustomerColumn.MiddleName)))?null:(System.String)reader[((int)VIndividualCustomerColumn.MiddleName)];
			//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
			entity.LastName = (System.String)reader[((int)VIndividualCustomerColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Suffix = (reader.IsDBNull(((int)VIndividualCustomerColumn.Suffix)))?null:(System.String)reader[((int)VIndividualCustomerColumn.Suffix)];
			//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
			entity.Phone = (reader.IsDBNull(((int)VIndividualCustomerColumn.Phone)))?null:(System.String)reader[((int)VIndividualCustomerColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.EmailAddress = (reader.IsDBNull(((int)VIndividualCustomerColumn.EmailAddress)))?null:(System.String)reader[((int)VIndividualCustomerColumn.EmailAddress)];
			//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
			entity.EmailPromotion = (System.Int32)reader[((int)VIndividualCustomerColumn.EmailPromotion)];
			//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
			entity.AddressType = (System.String)reader[((int)VIndividualCustomerColumn.AddressType)];
			//entity.AddressType = (Convert.IsDBNull(reader["AddressType"]))?string.Empty:(System.String)reader["AddressType"];
			entity.AddressLine1 = (System.String)reader[((int)VIndividualCustomerColumn.AddressLine1)];
			//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
			entity.AddressLine2 = (reader.IsDBNull(((int)VIndividualCustomerColumn.AddressLine2)))?null:(System.String)reader[((int)VIndividualCustomerColumn.AddressLine2)];
			//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
			entity.City = (System.String)reader[((int)VIndividualCustomerColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.StateProvinceName = (System.String)reader[((int)VIndividualCustomerColumn.StateProvinceName)];
			//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
			entity.PostalCode = (System.String)reader[((int)VIndividualCustomerColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.CountryRegionName = (System.String)reader[((int)VIndividualCustomerColumn.CountryRegionName)];
			//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
			entity.Demographics = (reader.IsDBNull(((int)VIndividualCustomerColumn.Demographics)))?null:(string)reader[((int)VIndividualCustomerColumn.Demographics)];
			//entity.Demographics = (Convert.IsDBNull(reader["Demographics"]))?null:(string)reader["Demographics"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VIndividualCustomer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VIndividualCustomer"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VIndividualCustomer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.Title = (Convert.IsDBNull(dataRow["Title"]))?string.Empty:(System.String)dataRow["Title"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?string.Empty:(System.String)dataRow["FirstName"];
			entity.MiddleName = (Convert.IsDBNull(dataRow["MiddleName"]))?string.Empty:(System.String)dataRow["MiddleName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?string.Empty:(System.String)dataRow["LastName"];
			entity.Suffix = (Convert.IsDBNull(dataRow["Suffix"]))?string.Empty:(System.String)dataRow["Suffix"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?string.Empty:(System.String)dataRow["Phone"];
			entity.EmailAddress = (Convert.IsDBNull(dataRow["EmailAddress"]))?string.Empty:(System.String)dataRow["EmailAddress"];
			entity.EmailPromotion = (Convert.IsDBNull(dataRow["EmailPromotion"]))?(int)0:(System.Int32)dataRow["EmailPromotion"];
			entity.AddressType = (Convert.IsDBNull(dataRow["AddressType"]))?string.Empty:(System.String)dataRow["AddressType"];
			entity.AddressLine1 = (Convert.IsDBNull(dataRow["AddressLine1"]))?string.Empty:(System.String)dataRow["AddressLine1"];
			entity.AddressLine2 = (Convert.IsDBNull(dataRow["AddressLine2"]))?string.Empty:(System.String)dataRow["AddressLine2"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.StateProvinceName = (Convert.IsDBNull(dataRow["StateProvinceName"]))?string.Empty:(System.String)dataRow["StateProvinceName"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?string.Empty:(System.String)dataRow["PostalCode"];
			entity.CountryRegionName = (Convert.IsDBNull(dataRow["CountryRegionName"]))?string.Empty:(System.String)dataRow["CountryRegionName"];
			entity.Demographics = (Convert.IsDBNull(dataRow["Demographics"]))?null:(string)dataRow["Demographics"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VIndividualCustomerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualCustomerFilterBuilder : SqlFilterBuilder<VIndividualCustomerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerFilterBuilder class.
		/// </summary>
		public VIndividualCustomerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VIndividualCustomerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VIndividualCustomerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VIndividualCustomerFilterBuilder

	#region VIndividualCustomerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualCustomerParameterBuilder : ParameterizedSqlFilterBuilder<VIndividualCustomerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerParameterBuilder class.
		/// </summary>
		public VIndividualCustomerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VIndividualCustomerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VIndividualCustomerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VIndividualCustomerParameterBuilder
	
	#region VIndividualCustomerSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualCustomer"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VIndividualCustomerSortBuilder : SqlSortBuilder<VIndividualCustomerColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualCustomerSqlSortBuilder class.
		/// </summary>
		public VIndividualCustomerSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VIndividualCustomerSortBuilder

} // end namespace
