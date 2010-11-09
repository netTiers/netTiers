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
	/// This class is the base class for any <see cref="VVendorProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VVendorProviderBaseCore : EntityViewProviderBase<VVendor>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VVendor&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VVendor&gt;"/></returns>
		protected static VList&lt;VVendor&gt; Fill(DataSet dataSet, VList<VVendor> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VVendor>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VVendor&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VVendor>"/></returns>
		protected static VList&lt;VVendor&gt; Fill(DataTable dataTable, VList<VVendor> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VVendor c = new VVendor();
					c.VendorId = (Convert.IsDBNull(row["VendorID"]))?(int)0:(System.Int32)row["VendorID"];
					c.Name = (Convert.IsDBNull(row["Name"]))?string.Empty:(System.String)row["Name"];
					c.ContactType = (Convert.IsDBNull(row["ContactType"]))?string.Empty:(System.String)row["ContactType"];
					c.Title = (Convert.IsDBNull(row["Title"]))?string.Empty:(System.String)row["Title"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.MiddleName = (Convert.IsDBNull(row["MiddleName"]))?string.Empty:(System.String)row["MiddleName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.Suffix = (Convert.IsDBNull(row["Suffix"]))?string.Empty:(System.String)row["Suffix"];
					c.Phone = (Convert.IsDBNull(row["Phone"]))?string.Empty:(System.String)row["Phone"];
					c.EmailAddress = (Convert.IsDBNull(row["EmailAddress"]))?string.Empty:(System.String)row["EmailAddress"];
					c.EmailPromotion = (Convert.IsDBNull(row["EmailPromotion"]))?(int)0:(System.Int32)row["EmailPromotion"];
					c.AddressLine1 = (Convert.IsDBNull(row["AddressLine1"]))?string.Empty:(System.String)row["AddressLine1"];
					c.AddressLine2 = (Convert.IsDBNull(row["AddressLine2"]))?string.Empty:(System.String)row["AddressLine2"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.StateProvinceName = (Convert.IsDBNull(row["StateProvinceName"]))?string.Empty:(System.String)row["StateProvinceName"];
					c.PostalCode = (Convert.IsDBNull(row["PostalCode"]))?string.Empty:(System.String)row["PostalCode"];
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
		/// Fill an <see cref="VList&lt;VVendor&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VVendor&gt;"/></returns>
		protected VList<VVendor> Fill(IDataReader reader, VList<VVendor> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VVendor entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VVendor>("VVendor",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VVendor();
					}
					
					entity.SuppressEntityEvents = true;

					entity.VendorId = (System.Int32)reader[((int)VVendorColumn.VendorId)];
					//entity.VendorId = (Convert.IsDBNull(reader["VendorID"]))?(int)0:(System.Int32)reader["VendorID"];
					entity.Name = (System.String)reader[((int)VVendorColumn.Name)];
					//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
					entity.ContactType = (System.String)reader[((int)VVendorColumn.ContactType)];
					//entity.ContactType = (Convert.IsDBNull(reader["ContactType"]))?string.Empty:(System.String)reader["ContactType"];
					entity.Title = (reader.IsDBNull(((int)VVendorColumn.Title)))?null:(System.String)reader[((int)VVendorColumn.Title)];
					//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
					entity.FirstName = (System.String)reader[((int)VVendorColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.MiddleName = (reader.IsDBNull(((int)VVendorColumn.MiddleName)))?null:(System.String)reader[((int)VVendorColumn.MiddleName)];
					//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
					entity.LastName = (System.String)reader[((int)VVendorColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Suffix = (reader.IsDBNull(((int)VVendorColumn.Suffix)))?null:(System.String)reader[((int)VVendorColumn.Suffix)];
					//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
					entity.Phone = (reader.IsDBNull(((int)VVendorColumn.Phone)))?null:(System.String)reader[((int)VVendorColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.EmailAddress = (reader.IsDBNull(((int)VVendorColumn.EmailAddress)))?null:(System.String)reader[((int)VVendorColumn.EmailAddress)];
					//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
					entity.EmailPromotion = (System.Int32)reader[((int)VVendorColumn.EmailPromotion)];
					//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
					entity.AddressLine1 = (System.String)reader[((int)VVendorColumn.AddressLine1)];
					//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
					entity.AddressLine2 = (reader.IsDBNull(((int)VVendorColumn.AddressLine2)))?null:(System.String)reader[((int)VVendorColumn.AddressLine2)];
					//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
					entity.City = (System.String)reader[((int)VVendorColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.StateProvinceName = (System.String)reader[((int)VVendorColumn.StateProvinceName)];
					//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
					entity.PostalCode = (System.String)reader[((int)VVendorColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.CountryRegionName = (System.String)reader[((int)VVendorColumn.CountryRegionName)];
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
		/// Refreshes the <see cref="VVendor"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VVendor"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VVendor entity)
		{
			reader.Read();
			entity.VendorId = (System.Int32)reader[((int)VVendorColumn.VendorId)];
			//entity.VendorId = (Convert.IsDBNull(reader["VendorID"]))?(int)0:(System.Int32)reader["VendorID"];
			entity.Name = (System.String)reader[((int)VVendorColumn.Name)];
			//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
			entity.ContactType = (System.String)reader[((int)VVendorColumn.ContactType)];
			//entity.ContactType = (Convert.IsDBNull(reader["ContactType"]))?string.Empty:(System.String)reader["ContactType"];
			entity.Title = (reader.IsDBNull(((int)VVendorColumn.Title)))?null:(System.String)reader[((int)VVendorColumn.Title)];
			//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
			entity.FirstName = (System.String)reader[((int)VVendorColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.MiddleName = (reader.IsDBNull(((int)VVendorColumn.MiddleName)))?null:(System.String)reader[((int)VVendorColumn.MiddleName)];
			//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
			entity.LastName = (System.String)reader[((int)VVendorColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Suffix = (reader.IsDBNull(((int)VVendorColumn.Suffix)))?null:(System.String)reader[((int)VVendorColumn.Suffix)];
			//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
			entity.Phone = (reader.IsDBNull(((int)VVendorColumn.Phone)))?null:(System.String)reader[((int)VVendorColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.EmailAddress = (reader.IsDBNull(((int)VVendorColumn.EmailAddress)))?null:(System.String)reader[((int)VVendorColumn.EmailAddress)];
			//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
			entity.EmailPromotion = (System.Int32)reader[((int)VVendorColumn.EmailPromotion)];
			//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
			entity.AddressLine1 = (System.String)reader[((int)VVendorColumn.AddressLine1)];
			//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
			entity.AddressLine2 = (reader.IsDBNull(((int)VVendorColumn.AddressLine2)))?null:(System.String)reader[((int)VVendorColumn.AddressLine2)];
			//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
			entity.City = (System.String)reader[((int)VVendorColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.StateProvinceName = (System.String)reader[((int)VVendorColumn.StateProvinceName)];
			//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
			entity.PostalCode = (System.String)reader[((int)VVendorColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.CountryRegionName = (System.String)reader[((int)VVendorColumn.CountryRegionName)];
			//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VVendor"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VVendor"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VVendor entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.VendorId = (Convert.IsDBNull(dataRow["VendorID"]))?(int)0:(System.Int32)dataRow["VendorID"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?string.Empty:(System.String)dataRow["Name"];
			entity.ContactType = (Convert.IsDBNull(dataRow["ContactType"]))?string.Empty:(System.String)dataRow["ContactType"];
			entity.Title = (Convert.IsDBNull(dataRow["Title"]))?string.Empty:(System.String)dataRow["Title"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?string.Empty:(System.String)dataRow["FirstName"];
			entity.MiddleName = (Convert.IsDBNull(dataRow["MiddleName"]))?string.Empty:(System.String)dataRow["MiddleName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?string.Empty:(System.String)dataRow["LastName"];
			entity.Suffix = (Convert.IsDBNull(dataRow["Suffix"]))?string.Empty:(System.String)dataRow["Suffix"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?string.Empty:(System.String)dataRow["Phone"];
			entity.EmailAddress = (Convert.IsDBNull(dataRow["EmailAddress"]))?string.Empty:(System.String)dataRow["EmailAddress"];
			entity.EmailPromotion = (Convert.IsDBNull(dataRow["EmailPromotion"]))?(int)0:(System.Int32)dataRow["EmailPromotion"];
			entity.AddressLine1 = (Convert.IsDBNull(dataRow["AddressLine1"]))?string.Empty:(System.String)dataRow["AddressLine1"];
			entity.AddressLine2 = (Convert.IsDBNull(dataRow["AddressLine2"]))?string.Empty:(System.String)dataRow["AddressLine2"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.StateProvinceName = (Convert.IsDBNull(dataRow["StateProvinceName"]))?string.Empty:(System.String)dataRow["StateProvinceName"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?string.Empty:(System.String)dataRow["PostalCode"];
			entity.CountryRegionName = (Convert.IsDBNull(dataRow["CountryRegionName"]))?string.Empty:(System.String)dataRow["CountryRegionName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VVendorFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VVendorFilterBuilder : SqlFilterBuilder<VVendorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VVendorFilterBuilder class.
		/// </summary>
		public VVendorFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VVendorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VVendorFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VVendorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VVendorFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VVendorFilterBuilder

	#region VVendorParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VVendor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VVendorParameterBuilder : ParameterizedSqlFilterBuilder<VVendorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VVendorParameterBuilder class.
		/// </summary>
		public VVendorParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VVendorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VVendorParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VVendorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VVendorParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VVendorParameterBuilder
	
	#region VVendorSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VVendor"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VVendorSortBuilder : SqlSortBuilder<VVendorColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VVendorSqlSortBuilder class.
		/// </summary>
		public VVendorSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VVendorSortBuilder

} // end namespace
