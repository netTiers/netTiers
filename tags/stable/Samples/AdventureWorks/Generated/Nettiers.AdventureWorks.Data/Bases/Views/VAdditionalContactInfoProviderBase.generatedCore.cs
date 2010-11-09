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
	/// This class is the base class for any <see cref="VAdditionalContactInfoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VAdditionalContactInfoProviderBaseCore : EntityViewProviderBase<VAdditionalContactInfo>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VAdditionalContactInfo&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VAdditionalContactInfo&gt;"/></returns>
		protected static VList&lt;VAdditionalContactInfo&gt; Fill(DataSet dataSet, VList<VAdditionalContactInfo> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VAdditionalContactInfo>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VAdditionalContactInfo&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VAdditionalContactInfo>"/></returns>
		protected static VList&lt;VAdditionalContactInfo&gt; Fill(DataTable dataTable, VList<VAdditionalContactInfo> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VAdditionalContactInfo c = new VAdditionalContactInfo();
					c.ContactId = (Convert.IsDBNull(row["ContactID"]))?(int)0:(System.Int32)row["ContactID"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.MiddleName = (Convert.IsDBNull(row["MiddleName"]))?string.Empty:(System.String)row["MiddleName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.TelephoneNumber = (Convert.IsDBNull(row["TelephoneNumber"]))?string.Empty:(System.String)row["TelephoneNumber"];
					c.TelephoneSpecialInstructions = (Convert.IsDBNull(row["TelephoneSpecialInstructions"]))?string.Empty:(System.String)row["TelephoneSpecialInstructions"];
					c.Street = (Convert.IsDBNull(row["Street"]))?string.Empty:(System.String)row["Street"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.StateProvince = (Convert.IsDBNull(row["StateProvince"]))?string.Empty:(System.String)row["StateProvince"];
					c.PostalCode = (Convert.IsDBNull(row["PostalCode"]))?string.Empty:(System.String)row["PostalCode"];
					c.CountryRegion = (Convert.IsDBNull(row["CountryRegion"]))?string.Empty:(System.String)row["CountryRegion"];
					c.HomeAddressSpecialInstructions = (Convert.IsDBNull(row["HomeAddressSpecialInstructions"]))?string.Empty:(System.String)row["HomeAddressSpecialInstructions"];
					c.EmailAddress = (Convert.IsDBNull(row["EMailAddress"]))?string.Empty:(System.String)row["EMailAddress"];
					c.EmailSpecialInstructions = (Convert.IsDBNull(row["EMailSpecialInstructions"]))?string.Empty:(System.String)row["EMailSpecialInstructions"];
					c.EmailTelephoneNumber = (Convert.IsDBNull(row["EMailTelephoneNumber"]))?string.Empty:(System.String)row["EMailTelephoneNumber"];
					c.Rowguid = (Convert.IsDBNull(row["rowguid"]))?Guid.Empty:(System.Guid)row["rowguid"];
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
		/// Fill an <see cref="VList&lt;VAdditionalContactInfo&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VAdditionalContactInfo&gt;"/></returns>
		protected VList<VAdditionalContactInfo> Fill(IDataReader reader, VList<VAdditionalContactInfo> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VAdditionalContactInfo entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VAdditionalContactInfo>("VAdditionalContactInfo",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VAdditionalContactInfo();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ContactId = (System.Int32)reader[((int)VAdditionalContactInfoColumn.ContactId)];
					//entity.ContactId = (Convert.IsDBNull(reader["ContactID"]))?(int)0:(System.Int32)reader["ContactID"];
					entity.FirstName = (System.String)reader[((int)VAdditionalContactInfoColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.MiddleName = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.MiddleName)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.MiddleName)];
					//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
					entity.LastName = (System.String)reader[((int)VAdditionalContactInfoColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.TelephoneNumber = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.TelephoneNumber)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.TelephoneNumber)];
					//entity.TelephoneNumber = (Convert.IsDBNull(reader["TelephoneNumber"]))?string.Empty:(System.String)reader["TelephoneNumber"];
					entity.TelephoneSpecialInstructions = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.TelephoneSpecialInstructions)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.TelephoneSpecialInstructions)];
					//entity.TelephoneSpecialInstructions = (Convert.IsDBNull(reader["TelephoneSpecialInstructions"]))?string.Empty:(System.String)reader["TelephoneSpecialInstructions"];
					entity.Street = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.Street)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.Street)];
					//entity.Street = (Convert.IsDBNull(reader["Street"]))?string.Empty:(System.String)reader["Street"];
					entity.City = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.City)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.StateProvince = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.StateProvince)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.StateProvince)];
					//entity.StateProvince = (Convert.IsDBNull(reader["StateProvince"]))?string.Empty:(System.String)reader["StateProvince"];
					entity.PostalCode = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.PostalCode)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.CountryRegion = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.CountryRegion)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.CountryRegion)];
					//entity.CountryRegion = (Convert.IsDBNull(reader["CountryRegion"]))?string.Empty:(System.String)reader["CountryRegion"];
					entity.HomeAddressSpecialInstructions = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.HomeAddressSpecialInstructions)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.HomeAddressSpecialInstructions)];
					//entity.HomeAddressSpecialInstructions = (Convert.IsDBNull(reader["HomeAddressSpecialInstructions"]))?string.Empty:(System.String)reader["HomeAddressSpecialInstructions"];
					entity.EmailAddress = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.EmailAddress)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.EmailAddress)];
					//entity.EmailAddress = (Convert.IsDBNull(reader["EMailAddress"]))?string.Empty:(System.String)reader["EMailAddress"];
					entity.EmailSpecialInstructions = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.EmailSpecialInstructions)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.EmailSpecialInstructions)];
					//entity.EmailSpecialInstructions = (Convert.IsDBNull(reader["EMailSpecialInstructions"]))?string.Empty:(System.String)reader["EMailSpecialInstructions"];
					entity.EmailTelephoneNumber = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.EmailTelephoneNumber)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.EmailTelephoneNumber)];
					//entity.EmailTelephoneNumber = (Convert.IsDBNull(reader["EMailTelephoneNumber"]))?string.Empty:(System.String)reader["EMailTelephoneNumber"];
					entity.Rowguid = (System.Guid)reader[((int)VAdditionalContactInfoColumn.Rowguid)];
					//entity.Rowguid = (Convert.IsDBNull(reader["rowguid"]))?Guid.Empty:(System.Guid)reader["rowguid"];
					entity.ModifiedDate = (System.DateTime)reader[((int)VAdditionalContactInfoColumn.ModifiedDate)];
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
		/// Refreshes the <see cref="VAdditionalContactInfo"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VAdditionalContactInfo"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VAdditionalContactInfo entity)
		{
			reader.Read();
			entity.ContactId = (System.Int32)reader[((int)VAdditionalContactInfoColumn.ContactId)];
			//entity.ContactId = (Convert.IsDBNull(reader["ContactID"]))?(int)0:(System.Int32)reader["ContactID"];
			entity.FirstName = (System.String)reader[((int)VAdditionalContactInfoColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.MiddleName = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.MiddleName)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.MiddleName)];
			//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
			entity.LastName = (System.String)reader[((int)VAdditionalContactInfoColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.TelephoneNumber = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.TelephoneNumber)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.TelephoneNumber)];
			//entity.TelephoneNumber = (Convert.IsDBNull(reader["TelephoneNumber"]))?string.Empty:(System.String)reader["TelephoneNumber"];
			entity.TelephoneSpecialInstructions = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.TelephoneSpecialInstructions)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.TelephoneSpecialInstructions)];
			//entity.TelephoneSpecialInstructions = (Convert.IsDBNull(reader["TelephoneSpecialInstructions"]))?string.Empty:(System.String)reader["TelephoneSpecialInstructions"];
			entity.Street = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.Street)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.Street)];
			//entity.Street = (Convert.IsDBNull(reader["Street"]))?string.Empty:(System.String)reader["Street"];
			entity.City = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.City)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.StateProvince = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.StateProvince)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.StateProvince)];
			//entity.StateProvince = (Convert.IsDBNull(reader["StateProvince"]))?string.Empty:(System.String)reader["StateProvince"];
			entity.PostalCode = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.PostalCode)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.CountryRegion = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.CountryRegion)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.CountryRegion)];
			//entity.CountryRegion = (Convert.IsDBNull(reader["CountryRegion"]))?string.Empty:(System.String)reader["CountryRegion"];
			entity.HomeAddressSpecialInstructions = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.HomeAddressSpecialInstructions)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.HomeAddressSpecialInstructions)];
			//entity.HomeAddressSpecialInstructions = (Convert.IsDBNull(reader["HomeAddressSpecialInstructions"]))?string.Empty:(System.String)reader["HomeAddressSpecialInstructions"];
			entity.EmailAddress = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.EmailAddress)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.EmailAddress)];
			//entity.EmailAddress = (Convert.IsDBNull(reader["EMailAddress"]))?string.Empty:(System.String)reader["EMailAddress"];
			entity.EmailSpecialInstructions = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.EmailSpecialInstructions)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.EmailSpecialInstructions)];
			//entity.EmailSpecialInstructions = (Convert.IsDBNull(reader["EMailSpecialInstructions"]))?string.Empty:(System.String)reader["EMailSpecialInstructions"];
			entity.EmailTelephoneNumber = (reader.IsDBNull(((int)VAdditionalContactInfoColumn.EmailTelephoneNumber)))?null:(System.String)reader[((int)VAdditionalContactInfoColumn.EmailTelephoneNumber)];
			//entity.EmailTelephoneNumber = (Convert.IsDBNull(reader["EMailTelephoneNumber"]))?string.Empty:(System.String)reader["EMailTelephoneNumber"];
			entity.Rowguid = (System.Guid)reader[((int)VAdditionalContactInfoColumn.Rowguid)];
			//entity.Rowguid = (Convert.IsDBNull(reader["rowguid"]))?Guid.Empty:(System.Guid)reader["rowguid"];
			entity.ModifiedDate = (System.DateTime)reader[((int)VAdditionalContactInfoColumn.ModifiedDate)];
			//entity.ModifiedDate = (Convert.IsDBNull(reader["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)reader["ModifiedDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VAdditionalContactInfo"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VAdditionalContactInfo"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VAdditionalContactInfo entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ContactId = (Convert.IsDBNull(dataRow["ContactID"]))?(int)0:(System.Int32)dataRow["ContactID"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?string.Empty:(System.String)dataRow["FirstName"];
			entity.MiddleName = (Convert.IsDBNull(dataRow["MiddleName"]))?string.Empty:(System.String)dataRow["MiddleName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?string.Empty:(System.String)dataRow["LastName"];
			entity.TelephoneNumber = (Convert.IsDBNull(dataRow["TelephoneNumber"]))?string.Empty:(System.String)dataRow["TelephoneNumber"];
			entity.TelephoneSpecialInstructions = (Convert.IsDBNull(dataRow["TelephoneSpecialInstructions"]))?string.Empty:(System.String)dataRow["TelephoneSpecialInstructions"];
			entity.Street = (Convert.IsDBNull(dataRow["Street"]))?string.Empty:(System.String)dataRow["Street"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.StateProvince = (Convert.IsDBNull(dataRow["StateProvince"]))?string.Empty:(System.String)dataRow["StateProvince"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?string.Empty:(System.String)dataRow["PostalCode"];
			entity.CountryRegion = (Convert.IsDBNull(dataRow["CountryRegion"]))?string.Empty:(System.String)dataRow["CountryRegion"];
			entity.HomeAddressSpecialInstructions = (Convert.IsDBNull(dataRow["HomeAddressSpecialInstructions"]))?string.Empty:(System.String)dataRow["HomeAddressSpecialInstructions"];
			entity.EmailAddress = (Convert.IsDBNull(dataRow["EMailAddress"]))?string.Empty:(System.String)dataRow["EMailAddress"];
			entity.EmailSpecialInstructions = (Convert.IsDBNull(dataRow["EMailSpecialInstructions"]))?string.Empty:(System.String)dataRow["EMailSpecialInstructions"];
			entity.EmailTelephoneNumber = (Convert.IsDBNull(dataRow["EMailTelephoneNumber"]))?string.Empty:(System.String)dataRow["EMailTelephoneNumber"];
			entity.Rowguid = (Convert.IsDBNull(dataRow["rowguid"]))?Guid.Empty:(System.Guid)dataRow["rowguid"];
			entity.ModifiedDate = (Convert.IsDBNull(dataRow["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)dataRow["ModifiedDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VAdditionalContactInfoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VAdditionalContactInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VAdditionalContactInfoFilterBuilder : SqlFilterBuilder<VAdditionalContactInfoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoFilterBuilder class.
		/// </summary>
		public VAdditionalContactInfoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VAdditionalContactInfoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VAdditionalContactInfoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VAdditionalContactInfoFilterBuilder

	#region VAdditionalContactInfoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VAdditionalContactInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VAdditionalContactInfoParameterBuilder : ParameterizedSqlFilterBuilder<VAdditionalContactInfoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoParameterBuilder class.
		/// </summary>
		public VAdditionalContactInfoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VAdditionalContactInfoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VAdditionalContactInfoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VAdditionalContactInfoParameterBuilder
	
	#region VAdditionalContactInfoSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VAdditionalContactInfo"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VAdditionalContactInfoSortBuilder : SqlSortBuilder<VAdditionalContactInfoColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VAdditionalContactInfoSqlSortBuilder class.
		/// </summary>
		public VAdditionalContactInfoSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VAdditionalContactInfoSortBuilder

} // end namespace
