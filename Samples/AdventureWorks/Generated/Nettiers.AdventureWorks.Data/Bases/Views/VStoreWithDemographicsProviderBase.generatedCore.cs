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
	/// This class is the base class for any <see cref="VStoreWithDemographicsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VStoreWithDemographicsProviderBaseCore : EntityViewProviderBase<VStoreWithDemographics>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VStoreWithDemographics&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VStoreWithDemographics&gt;"/></returns>
		protected static VList&lt;VStoreWithDemographics&gt; Fill(DataSet dataSet, VList<VStoreWithDemographics> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VStoreWithDemographics>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VStoreWithDemographics&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VStoreWithDemographics>"/></returns>
		protected static VList&lt;VStoreWithDemographics&gt; Fill(DataTable dataTable, VList<VStoreWithDemographics> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VStoreWithDemographics c = new VStoreWithDemographics();
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
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
					c.AddressType = (Convert.IsDBNull(row["AddressType"]))?string.Empty:(System.String)row["AddressType"];
					c.AddressLine1 = (Convert.IsDBNull(row["AddressLine1"]))?string.Empty:(System.String)row["AddressLine1"];
					c.AddressLine2 = (Convert.IsDBNull(row["AddressLine2"]))?string.Empty:(System.String)row["AddressLine2"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.StateProvinceName = (Convert.IsDBNull(row["StateProvinceName"]))?string.Empty:(System.String)row["StateProvinceName"];
					c.PostalCode = (Convert.IsDBNull(row["PostalCode"]))?string.Empty:(System.String)row["PostalCode"];
					c.CountryRegionName = (Convert.IsDBNull(row["CountryRegionName"]))?string.Empty:(System.String)row["CountryRegionName"];
					c.AnnualSales = (Convert.IsDBNull(row["AnnualSales"]))?0:(System.Decimal?)row["AnnualSales"];
					c.AnnualRevenue = (Convert.IsDBNull(row["AnnualRevenue"]))?0:(System.Decimal?)row["AnnualRevenue"];
					c.BankName = (Convert.IsDBNull(row["BankName"]))?string.Empty:(System.String)row["BankName"];
					c.BusinessType = (Convert.IsDBNull(row["BusinessType"]))?string.Empty:(System.String)row["BusinessType"];
					c.YearOpened = (Convert.IsDBNull(row["YearOpened"]))?(int)0:(System.Int32?)row["YearOpened"];
					c.Specialty = (Convert.IsDBNull(row["Specialty"]))?string.Empty:(System.String)row["Specialty"];
					c.SquareFeet = (Convert.IsDBNull(row["SquareFeet"]))?(int)0:(System.Int32?)row["SquareFeet"];
					c.Brands = (Convert.IsDBNull(row["Brands"]))?string.Empty:(System.String)row["Brands"];
					c.Internet = (Convert.IsDBNull(row["Internet"]))?string.Empty:(System.String)row["Internet"];
					c.NumberEmployees = (Convert.IsDBNull(row["NumberEmployees"]))?(int)0:(System.Int32?)row["NumberEmployees"];
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
		/// Fill an <see cref="VList&lt;VStoreWithDemographics&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VStoreWithDemographics&gt;"/></returns>
		protected VList<VStoreWithDemographics> Fill(IDataReader reader, VList<VStoreWithDemographics> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VStoreWithDemographics entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VStoreWithDemographics>("VStoreWithDemographics",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VStoreWithDemographics();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CustomerId = (System.Int32)reader[((int)VStoreWithDemographicsColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.Name = (System.String)reader[((int)VStoreWithDemographicsColumn.Name)];
					//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
					entity.ContactType = (System.String)reader[((int)VStoreWithDemographicsColumn.ContactType)];
					//entity.ContactType = (Convert.IsDBNull(reader["ContactType"]))?string.Empty:(System.String)reader["ContactType"];
					entity.Title = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Title)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Title)];
					//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
					entity.FirstName = (System.String)reader[((int)VStoreWithDemographicsColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.MiddleName = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.MiddleName)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.MiddleName)];
					//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
					entity.LastName = (System.String)reader[((int)VStoreWithDemographicsColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Suffix = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Suffix)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Suffix)];
					//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
					entity.Phone = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Phone)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.EmailAddress = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.EmailAddress)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.EmailAddress)];
					//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
					entity.EmailPromotion = (System.Int32)reader[((int)VStoreWithDemographicsColumn.EmailPromotion)];
					//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
					entity.AddressType = (System.String)reader[((int)VStoreWithDemographicsColumn.AddressType)];
					//entity.AddressType = (Convert.IsDBNull(reader["AddressType"]))?string.Empty:(System.String)reader["AddressType"];
					entity.AddressLine1 = (System.String)reader[((int)VStoreWithDemographicsColumn.AddressLine1)];
					//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
					entity.AddressLine2 = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.AddressLine2)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.AddressLine2)];
					//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
					entity.City = (System.String)reader[((int)VStoreWithDemographicsColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.StateProvinceName = (System.String)reader[((int)VStoreWithDemographicsColumn.StateProvinceName)];
					//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
					entity.PostalCode = (System.String)reader[((int)VStoreWithDemographicsColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.CountryRegionName = (System.String)reader[((int)VStoreWithDemographicsColumn.CountryRegionName)];
					//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
					entity.AnnualSales = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.AnnualSales)))?null:(System.Decimal?)reader[((int)VStoreWithDemographicsColumn.AnnualSales)];
					//entity.AnnualSales = (Convert.IsDBNull(reader["AnnualSales"]))?0:(System.Decimal?)reader["AnnualSales"];
					entity.AnnualRevenue = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.AnnualRevenue)))?null:(System.Decimal?)reader[((int)VStoreWithDemographicsColumn.AnnualRevenue)];
					//entity.AnnualRevenue = (Convert.IsDBNull(reader["AnnualRevenue"]))?0:(System.Decimal?)reader["AnnualRevenue"];
					entity.BankName = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.BankName)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.BankName)];
					//entity.BankName = (Convert.IsDBNull(reader["BankName"]))?string.Empty:(System.String)reader["BankName"];
					entity.BusinessType = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.BusinessType)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.BusinessType)];
					//entity.BusinessType = (Convert.IsDBNull(reader["BusinessType"]))?string.Empty:(System.String)reader["BusinessType"];
					entity.YearOpened = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.YearOpened)))?null:(System.Int32?)reader[((int)VStoreWithDemographicsColumn.YearOpened)];
					//entity.YearOpened = (Convert.IsDBNull(reader["YearOpened"]))?(int)0:(System.Int32?)reader["YearOpened"];
					entity.Specialty = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Specialty)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Specialty)];
					//entity.Specialty = (Convert.IsDBNull(reader["Specialty"]))?string.Empty:(System.String)reader["Specialty"];
					entity.SquareFeet = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.SquareFeet)))?null:(System.Int32?)reader[((int)VStoreWithDemographicsColumn.SquareFeet)];
					//entity.SquareFeet = (Convert.IsDBNull(reader["SquareFeet"]))?(int)0:(System.Int32?)reader["SquareFeet"];
					entity.Brands = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Brands)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Brands)];
					//entity.Brands = (Convert.IsDBNull(reader["Brands"]))?string.Empty:(System.String)reader["Brands"];
					entity.Internet = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Internet)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Internet)];
					//entity.Internet = (Convert.IsDBNull(reader["Internet"]))?string.Empty:(System.String)reader["Internet"];
					entity.NumberEmployees = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.NumberEmployees)))?null:(System.Int32?)reader[((int)VStoreWithDemographicsColumn.NumberEmployees)];
					//entity.NumberEmployees = (Convert.IsDBNull(reader["NumberEmployees"]))?(int)0:(System.Int32?)reader["NumberEmployees"];
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
		/// Refreshes the <see cref="VStoreWithDemographics"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VStoreWithDemographics"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VStoreWithDemographics entity)
		{
			reader.Read();
			entity.CustomerId = (System.Int32)reader[((int)VStoreWithDemographicsColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.Name = (System.String)reader[((int)VStoreWithDemographicsColumn.Name)];
			//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
			entity.ContactType = (System.String)reader[((int)VStoreWithDemographicsColumn.ContactType)];
			//entity.ContactType = (Convert.IsDBNull(reader["ContactType"]))?string.Empty:(System.String)reader["ContactType"];
			entity.Title = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Title)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Title)];
			//entity.Title = (Convert.IsDBNull(reader["Title"]))?string.Empty:(System.String)reader["Title"];
			entity.FirstName = (System.String)reader[((int)VStoreWithDemographicsColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.MiddleName = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.MiddleName)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.MiddleName)];
			//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
			entity.LastName = (System.String)reader[((int)VStoreWithDemographicsColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Suffix = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Suffix)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Suffix)];
			//entity.Suffix = (Convert.IsDBNull(reader["Suffix"]))?string.Empty:(System.String)reader["Suffix"];
			entity.Phone = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Phone)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.EmailAddress = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.EmailAddress)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.EmailAddress)];
			//entity.EmailAddress = (Convert.IsDBNull(reader["EmailAddress"]))?string.Empty:(System.String)reader["EmailAddress"];
			entity.EmailPromotion = (System.Int32)reader[((int)VStoreWithDemographicsColumn.EmailPromotion)];
			//entity.EmailPromotion = (Convert.IsDBNull(reader["EmailPromotion"]))?(int)0:(System.Int32)reader["EmailPromotion"];
			entity.AddressType = (System.String)reader[((int)VStoreWithDemographicsColumn.AddressType)];
			//entity.AddressType = (Convert.IsDBNull(reader["AddressType"]))?string.Empty:(System.String)reader["AddressType"];
			entity.AddressLine1 = (System.String)reader[((int)VStoreWithDemographicsColumn.AddressLine1)];
			//entity.AddressLine1 = (Convert.IsDBNull(reader["AddressLine1"]))?string.Empty:(System.String)reader["AddressLine1"];
			entity.AddressLine2 = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.AddressLine2)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.AddressLine2)];
			//entity.AddressLine2 = (Convert.IsDBNull(reader["AddressLine2"]))?string.Empty:(System.String)reader["AddressLine2"];
			entity.City = (System.String)reader[((int)VStoreWithDemographicsColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.StateProvinceName = (System.String)reader[((int)VStoreWithDemographicsColumn.StateProvinceName)];
			//entity.StateProvinceName = (Convert.IsDBNull(reader["StateProvinceName"]))?string.Empty:(System.String)reader["StateProvinceName"];
			entity.PostalCode = (System.String)reader[((int)VStoreWithDemographicsColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.CountryRegionName = (System.String)reader[((int)VStoreWithDemographicsColumn.CountryRegionName)];
			//entity.CountryRegionName = (Convert.IsDBNull(reader["CountryRegionName"]))?string.Empty:(System.String)reader["CountryRegionName"];
			entity.AnnualSales = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.AnnualSales)))?null:(System.Decimal?)reader[((int)VStoreWithDemographicsColumn.AnnualSales)];
			//entity.AnnualSales = (Convert.IsDBNull(reader["AnnualSales"]))?0:(System.Decimal?)reader["AnnualSales"];
			entity.AnnualRevenue = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.AnnualRevenue)))?null:(System.Decimal?)reader[((int)VStoreWithDemographicsColumn.AnnualRevenue)];
			//entity.AnnualRevenue = (Convert.IsDBNull(reader["AnnualRevenue"]))?0:(System.Decimal?)reader["AnnualRevenue"];
			entity.BankName = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.BankName)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.BankName)];
			//entity.BankName = (Convert.IsDBNull(reader["BankName"]))?string.Empty:(System.String)reader["BankName"];
			entity.BusinessType = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.BusinessType)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.BusinessType)];
			//entity.BusinessType = (Convert.IsDBNull(reader["BusinessType"]))?string.Empty:(System.String)reader["BusinessType"];
			entity.YearOpened = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.YearOpened)))?null:(System.Int32?)reader[((int)VStoreWithDemographicsColumn.YearOpened)];
			//entity.YearOpened = (Convert.IsDBNull(reader["YearOpened"]))?(int)0:(System.Int32?)reader["YearOpened"];
			entity.Specialty = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Specialty)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Specialty)];
			//entity.Specialty = (Convert.IsDBNull(reader["Specialty"]))?string.Empty:(System.String)reader["Specialty"];
			entity.SquareFeet = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.SquareFeet)))?null:(System.Int32?)reader[((int)VStoreWithDemographicsColumn.SquareFeet)];
			//entity.SquareFeet = (Convert.IsDBNull(reader["SquareFeet"]))?(int)0:(System.Int32?)reader["SquareFeet"];
			entity.Brands = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Brands)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Brands)];
			//entity.Brands = (Convert.IsDBNull(reader["Brands"]))?string.Empty:(System.String)reader["Brands"];
			entity.Internet = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.Internet)))?null:(System.String)reader[((int)VStoreWithDemographicsColumn.Internet)];
			//entity.Internet = (Convert.IsDBNull(reader["Internet"]))?string.Empty:(System.String)reader["Internet"];
			entity.NumberEmployees = (reader.IsDBNull(((int)VStoreWithDemographicsColumn.NumberEmployees)))?null:(System.Int32?)reader[((int)VStoreWithDemographicsColumn.NumberEmployees)];
			//entity.NumberEmployees = (Convert.IsDBNull(reader["NumberEmployees"]))?(int)0:(System.Int32?)reader["NumberEmployees"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VStoreWithDemographics"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VStoreWithDemographics"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VStoreWithDemographics entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
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
			entity.AddressType = (Convert.IsDBNull(dataRow["AddressType"]))?string.Empty:(System.String)dataRow["AddressType"];
			entity.AddressLine1 = (Convert.IsDBNull(dataRow["AddressLine1"]))?string.Empty:(System.String)dataRow["AddressLine1"];
			entity.AddressLine2 = (Convert.IsDBNull(dataRow["AddressLine2"]))?string.Empty:(System.String)dataRow["AddressLine2"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.StateProvinceName = (Convert.IsDBNull(dataRow["StateProvinceName"]))?string.Empty:(System.String)dataRow["StateProvinceName"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?string.Empty:(System.String)dataRow["PostalCode"];
			entity.CountryRegionName = (Convert.IsDBNull(dataRow["CountryRegionName"]))?string.Empty:(System.String)dataRow["CountryRegionName"];
			entity.AnnualSales = (Convert.IsDBNull(dataRow["AnnualSales"]))?0:(System.Decimal?)dataRow["AnnualSales"];
			entity.AnnualRevenue = (Convert.IsDBNull(dataRow["AnnualRevenue"]))?0:(System.Decimal?)dataRow["AnnualRevenue"];
			entity.BankName = (Convert.IsDBNull(dataRow["BankName"]))?string.Empty:(System.String)dataRow["BankName"];
			entity.BusinessType = (Convert.IsDBNull(dataRow["BusinessType"]))?string.Empty:(System.String)dataRow["BusinessType"];
			entity.YearOpened = (Convert.IsDBNull(dataRow["YearOpened"]))?(int)0:(System.Int32?)dataRow["YearOpened"];
			entity.Specialty = (Convert.IsDBNull(dataRow["Specialty"]))?string.Empty:(System.String)dataRow["Specialty"];
			entity.SquareFeet = (Convert.IsDBNull(dataRow["SquareFeet"]))?(int)0:(System.Int32?)dataRow["SquareFeet"];
			entity.Brands = (Convert.IsDBNull(dataRow["Brands"]))?string.Empty:(System.String)dataRow["Brands"];
			entity.Internet = (Convert.IsDBNull(dataRow["Internet"]))?string.Empty:(System.String)dataRow["Internet"];
			entity.NumberEmployees = (Convert.IsDBNull(dataRow["NumberEmployees"]))?(int)0:(System.Int32?)dataRow["NumberEmployees"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VStoreWithDemographicsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStoreWithDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStoreWithDemographicsFilterBuilder : SqlFilterBuilder<VStoreWithDemographicsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsFilterBuilder class.
		/// </summary>
		public VStoreWithDemographicsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VStoreWithDemographicsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VStoreWithDemographicsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VStoreWithDemographicsFilterBuilder

	#region VStoreWithDemographicsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStoreWithDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VStoreWithDemographicsParameterBuilder : ParameterizedSqlFilterBuilder<VStoreWithDemographicsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsParameterBuilder class.
		/// </summary>
		public VStoreWithDemographicsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VStoreWithDemographicsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VStoreWithDemographicsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VStoreWithDemographicsParameterBuilder
	
	#region VStoreWithDemographicsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VStoreWithDemographics"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VStoreWithDemographicsSortBuilder : SqlSortBuilder<VStoreWithDemographicsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VStoreWithDemographicsSqlSortBuilder class.
		/// </summary>
		public VStoreWithDemographicsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VStoreWithDemographicsSortBuilder

} // end namespace
