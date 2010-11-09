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
	/// This class is the base class for any <see cref="VIndividualDemographicsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VIndividualDemographicsProviderBaseCore : EntityViewProviderBase<VIndividualDemographics>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VIndividualDemographics&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VIndividualDemographics&gt;"/></returns>
		protected static VList&lt;VIndividualDemographics&gt; Fill(DataSet dataSet, VList<VIndividualDemographics> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VIndividualDemographics>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VIndividualDemographics&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VIndividualDemographics>"/></returns>
		protected static VList&lt;VIndividualDemographics&gt; Fill(DataTable dataTable, VList<VIndividualDemographics> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VIndividualDemographics c = new VIndividualDemographics();
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.TotalPurchaseYtd = (Convert.IsDBNull(row["TotalPurchaseYTD"]))?0:(System.Decimal?)row["TotalPurchaseYTD"];
					c.DateFirstPurchase = (Convert.IsDBNull(row["DateFirstPurchase"]))?DateTime.MinValue:(System.DateTime?)row["DateFirstPurchase"];
					c.BirthDate = (Convert.IsDBNull(row["BirthDate"]))?DateTime.MinValue:(System.DateTime?)row["BirthDate"];
					c.MaritalStatus = (Convert.IsDBNull(row["MaritalStatus"]))?string.Empty:(System.String)row["MaritalStatus"];
					c.YearlyIncome = (Convert.IsDBNull(row["YearlyIncome"]))?string.Empty:(System.String)row["YearlyIncome"];
					c.Gender = (Convert.IsDBNull(row["Gender"]))?string.Empty:(System.String)row["Gender"];
					c.TotalChildren = (Convert.IsDBNull(row["TotalChildren"]))?(int)0:(System.Int32?)row["TotalChildren"];
					c.NumberChildrenAtHome = (Convert.IsDBNull(row["NumberChildrenAtHome"]))?(int)0:(System.Int32?)row["NumberChildrenAtHome"];
					c.Education = (Convert.IsDBNull(row["Education"]))?string.Empty:(System.String)row["Education"];
					c.Occupation = (Convert.IsDBNull(row["Occupation"]))?string.Empty:(System.String)row["Occupation"];
					c.HomeOwnerFlag = (Convert.IsDBNull(row["HomeOwnerFlag"]))?false:(System.Boolean?)row["HomeOwnerFlag"];
					c.NumberCarsOwned = (Convert.IsDBNull(row["NumberCarsOwned"]))?(int)0:(System.Int32?)row["NumberCarsOwned"];
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
		/// Fill an <see cref="VList&lt;VIndividualDemographics&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VIndividualDemographics&gt;"/></returns>
		protected VList<VIndividualDemographics> Fill(IDataReader reader, VList<VIndividualDemographics> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VIndividualDemographics entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VIndividualDemographics>("VIndividualDemographics",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VIndividualDemographics();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CustomerId = (System.Int32)reader[((int)VIndividualDemographicsColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.TotalPurchaseYtd = (reader.IsDBNull(((int)VIndividualDemographicsColumn.TotalPurchaseYtd)))?null:(System.Decimal?)reader[((int)VIndividualDemographicsColumn.TotalPurchaseYtd)];
					//entity.TotalPurchaseYtd = (Convert.IsDBNull(reader["TotalPurchaseYTD"]))?0:(System.Decimal?)reader["TotalPurchaseYTD"];
					entity.DateFirstPurchase = (reader.IsDBNull(((int)VIndividualDemographicsColumn.DateFirstPurchase)))?null:(System.DateTime?)reader[((int)VIndividualDemographicsColumn.DateFirstPurchase)];
					//entity.DateFirstPurchase = (Convert.IsDBNull(reader["DateFirstPurchase"]))?DateTime.MinValue:(System.DateTime?)reader["DateFirstPurchase"];
					entity.BirthDate = (reader.IsDBNull(((int)VIndividualDemographicsColumn.BirthDate)))?null:(System.DateTime?)reader[((int)VIndividualDemographicsColumn.BirthDate)];
					//entity.BirthDate = (Convert.IsDBNull(reader["BirthDate"]))?DateTime.MinValue:(System.DateTime?)reader["BirthDate"];
					entity.MaritalStatus = (reader.IsDBNull(((int)VIndividualDemographicsColumn.MaritalStatus)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.MaritalStatus)];
					//entity.MaritalStatus = (Convert.IsDBNull(reader["MaritalStatus"]))?string.Empty:(System.String)reader["MaritalStatus"];
					entity.YearlyIncome = (reader.IsDBNull(((int)VIndividualDemographicsColumn.YearlyIncome)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.YearlyIncome)];
					//entity.YearlyIncome = (Convert.IsDBNull(reader["YearlyIncome"]))?string.Empty:(System.String)reader["YearlyIncome"];
					entity.Gender = (reader.IsDBNull(((int)VIndividualDemographicsColumn.Gender)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.Gender)];
					//entity.Gender = (Convert.IsDBNull(reader["Gender"]))?string.Empty:(System.String)reader["Gender"];
					entity.TotalChildren = (reader.IsDBNull(((int)VIndividualDemographicsColumn.TotalChildren)))?null:(System.Int32?)reader[((int)VIndividualDemographicsColumn.TotalChildren)];
					//entity.TotalChildren = (Convert.IsDBNull(reader["TotalChildren"]))?(int)0:(System.Int32?)reader["TotalChildren"];
					entity.NumberChildrenAtHome = (reader.IsDBNull(((int)VIndividualDemographicsColumn.NumberChildrenAtHome)))?null:(System.Int32?)reader[((int)VIndividualDemographicsColumn.NumberChildrenAtHome)];
					//entity.NumberChildrenAtHome = (Convert.IsDBNull(reader["NumberChildrenAtHome"]))?(int)0:(System.Int32?)reader["NumberChildrenAtHome"];
					entity.Education = (reader.IsDBNull(((int)VIndividualDemographicsColumn.Education)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.Education)];
					//entity.Education = (Convert.IsDBNull(reader["Education"]))?string.Empty:(System.String)reader["Education"];
					entity.Occupation = (reader.IsDBNull(((int)VIndividualDemographicsColumn.Occupation)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.Occupation)];
					//entity.Occupation = (Convert.IsDBNull(reader["Occupation"]))?string.Empty:(System.String)reader["Occupation"];
					entity.HomeOwnerFlag = (reader.IsDBNull(((int)VIndividualDemographicsColumn.HomeOwnerFlag)))?null:(System.Boolean?)reader[((int)VIndividualDemographicsColumn.HomeOwnerFlag)];
					//entity.HomeOwnerFlag = (Convert.IsDBNull(reader["HomeOwnerFlag"]))?false:(System.Boolean?)reader["HomeOwnerFlag"];
					entity.NumberCarsOwned = (reader.IsDBNull(((int)VIndividualDemographicsColumn.NumberCarsOwned)))?null:(System.Int32?)reader[((int)VIndividualDemographicsColumn.NumberCarsOwned)];
					//entity.NumberCarsOwned = (Convert.IsDBNull(reader["NumberCarsOwned"]))?(int)0:(System.Int32?)reader["NumberCarsOwned"];
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
		/// Refreshes the <see cref="VIndividualDemographics"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VIndividualDemographics"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VIndividualDemographics entity)
		{
			reader.Read();
			entity.CustomerId = (System.Int32)reader[((int)VIndividualDemographicsColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.TotalPurchaseYtd = (reader.IsDBNull(((int)VIndividualDemographicsColumn.TotalPurchaseYtd)))?null:(System.Decimal?)reader[((int)VIndividualDemographicsColumn.TotalPurchaseYtd)];
			//entity.TotalPurchaseYtd = (Convert.IsDBNull(reader["TotalPurchaseYTD"]))?0:(System.Decimal?)reader["TotalPurchaseYTD"];
			entity.DateFirstPurchase = (reader.IsDBNull(((int)VIndividualDemographicsColumn.DateFirstPurchase)))?null:(System.DateTime?)reader[((int)VIndividualDemographicsColumn.DateFirstPurchase)];
			//entity.DateFirstPurchase = (Convert.IsDBNull(reader["DateFirstPurchase"]))?DateTime.MinValue:(System.DateTime?)reader["DateFirstPurchase"];
			entity.BirthDate = (reader.IsDBNull(((int)VIndividualDemographicsColumn.BirthDate)))?null:(System.DateTime?)reader[((int)VIndividualDemographicsColumn.BirthDate)];
			//entity.BirthDate = (Convert.IsDBNull(reader["BirthDate"]))?DateTime.MinValue:(System.DateTime?)reader["BirthDate"];
			entity.MaritalStatus = (reader.IsDBNull(((int)VIndividualDemographicsColumn.MaritalStatus)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.MaritalStatus)];
			//entity.MaritalStatus = (Convert.IsDBNull(reader["MaritalStatus"]))?string.Empty:(System.String)reader["MaritalStatus"];
			entity.YearlyIncome = (reader.IsDBNull(((int)VIndividualDemographicsColumn.YearlyIncome)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.YearlyIncome)];
			//entity.YearlyIncome = (Convert.IsDBNull(reader["YearlyIncome"]))?string.Empty:(System.String)reader["YearlyIncome"];
			entity.Gender = (reader.IsDBNull(((int)VIndividualDemographicsColumn.Gender)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.Gender)];
			//entity.Gender = (Convert.IsDBNull(reader["Gender"]))?string.Empty:(System.String)reader["Gender"];
			entity.TotalChildren = (reader.IsDBNull(((int)VIndividualDemographicsColumn.TotalChildren)))?null:(System.Int32?)reader[((int)VIndividualDemographicsColumn.TotalChildren)];
			//entity.TotalChildren = (Convert.IsDBNull(reader["TotalChildren"]))?(int)0:(System.Int32?)reader["TotalChildren"];
			entity.NumberChildrenAtHome = (reader.IsDBNull(((int)VIndividualDemographicsColumn.NumberChildrenAtHome)))?null:(System.Int32?)reader[((int)VIndividualDemographicsColumn.NumberChildrenAtHome)];
			//entity.NumberChildrenAtHome = (Convert.IsDBNull(reader["NumberChildrenAtHome"]))?(int)0:(System.Int32?)reader["NumberChildrenAtHome"];
			entity.Education = (reader.IsDBNull(((int)VIndividualDemographicsColumn.Education)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.Education)];
			//entity.Education = (Convert.IsDBNull(reader["Education"]))?string.Empty:(System.String)reader["Education"];
			entity.Occupation = (reader.IsDBNull(((int)VIndividualDemographicsColumn.Occupation)))?null:(System.String)reader[((int)VIndividualDemographicsColumn.Occupation)];
			//entity.Occupation = (Convert.IsDBNull(reader["Occupation"]))?string.Empty:(System.String)reader["Occupation"];
			entity.HomeOwnerFlag = (reader.IsDBNull(((int)VIndividualDemographicsColumn.HomeOwnerFlag)))?null:(System.Boolean?)reader[((int)VIndividualDemographicsColumn.HomeOwnerFlag)];
			//entity.HomeOwnerFlag = (Convert.IsDBNull(reader["HomeOwnerFlag"]))?false:(System.Boolean?)reader["HomeOwnerFlag"];
			entity.NumberCarsOwned = (reader.IsDBNull(((int)VIndividualDemographicsColumn.NumberCarsOwned)))?null:(System.Int32?)reader[((int)VIndividualDemographicsColumn.NumberCarsOwned)];
			//entity.NumberCarsOwned = (Convert.IsDBNull(reader["NumberCarsOwned"]))?(int)0:(System.Int32?)reader["NumberCarsOwned"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VIndividualDemographics"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VIndividualDemographics"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VIndividualDemographics entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.TotalPurchaseYtd = (Convert.IsDBNull(dataRow["TotalPurchaseYTD"]))?0:(System.Decimal?)dataRow["TotalPurchaseYTD"];
			entity.DateFirstPurchase = (Convert.IsDBNull(dataRow["DateFirstPurchase"]))?DateTime.MinValue:(System.DateTime?)dataRow["DateFirstPurchase"];
			entity.BirthDate = (Convert.IsDBNull(dataRow["BirthDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["BirthDate"];
			entity.MaritalStatus = (Convert.IsDBNull(dataRow["MaritalStatus"]))?string.Empty:(System.String)dataRow["MaritalStatus"];
			entity.YearlyIncome = (Convert.IsDBNull(dataRow["YearlyIncome"]))?string.Empty:(System.String)dataRow["YearlyIncome"];
			entity.Gender = (Convert.IsDBNull(dataRow["Gender"]))?string.Empty:(System.String)dataRow["Gender"];
			entity.TotalChildren = (Convert.IsDBNull(dataRow["TotalChildren"]))?(int)0:(System.Int32?)dataRow["TotalChildren"];
			entity.NumberChildrenAtHome = (Convert.IsDBNull(dataRow["NumberChildrenAtHome"]))?(int)0:(System.Int32?)dataRow["NumberChildrenAtHome"];
			entity.Education = (Convert.IsDBNull(dataRow["Education"]))?string.Empty:(System.String)dataRow["Education"];
			entity.Occupation = (Convert.IsDBNull(dataRow["Occupation"]))?string.Empty:(System.String)dataRow["Occupation"];
			entity.HomeOwnerFlag = (Convert.IsDBNull(dataRow["HomeOwnerFlag"]))?false:(System.Boolean?)dataRow["HomeOwnerFlag"];
			entity.NumberCarsOwned = (Convert.IsDBNull(dataRow["NumberCarsOwned"]))?(int)0:(System.Int32?)dataRow["NumberCarsOwned"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VIndividualDemographicsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualDemographicsFilterBuilder : SqlFilterBuilder<VIndividualDemographicsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsFilterBuilder class.
		/// </summary>
		public VIndividualDemographicsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VIndividualDemographicsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VIndividualDemographicsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VIndividualDemographicsFilterBuilder

	#region VIndividualDemographicsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VIndividualDemographicsParameterBuilder : ParameterizedSqlFilterBuilder<VIndividualDemographicsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsParameterBuilder class.
		/// </summary>
		public VIndividualDemographicsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VIndividualDemographicsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VIndividualDemographicsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VIndividualDemographicsParameterBuilder
	
	#region VIndividualDemographicsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VIndividualDemographics"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VIndividualDemographicsSortBuilder : SqlSortBuilder<VIndividualDemographicsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VIndividualDemographicsSqlSortBuilder class.
		/// </summary>
		public VIndividualDemographicsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VIndividualDemographicsSortBuilder

} // end namespace
