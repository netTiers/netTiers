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
	/// This class is the base class for any <see cref="VProductModelInstructionsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VProductModelInstructionsProviderBaseCore : EntityViewProviderBase<VProductModelInstructions>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VProductModelInstructions&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VProductModelInstructions&gt;"/></returns>
		protected static VList&lt;VProductModelInstructions&gt; Fill(DataSet dataSet, VList<VProductModelInstructions> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VProductModelInstructions>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VProductModelInstructions&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VProductModelInstructions>"/></returns>
		protected static VList&lt;VProductModelInstructions&gt; Fill(DataTable dataTable, VList<VProductModelInstructions> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VProductModelInstructions c = new VProductModelInstructions();
					c.ProductModelId = (Convert.IsDBNull(row["ProductModelID"]))?(int)0:(System.Int32)row["ProductModelID"];
					c.Name = (Convert.IsDBNull(row["Name"]))?string.Empty:(System.String)row["Name"];
					c.Instructions = (Convert.IsDBNull(row["Instructions"]))?string.Empty:(System.String)row["Instructions"];
					c.LocationId = (Convert.IsDBNull(row["LocationID"]))?(int)0:(System.Int32?)row["LocationID"];
					c.SetupHours = (Convert.IsDBNull(row["SetupHours"]))?0.0m:(System.Decimal?)row["SetupHours"];
					c.MachineHours = (Convert.IsDBNull(row["MachineHours"]))?0.0m:(System.Decimal?)row["MachineHours"];
					c.LaborHours = (Convert.IsDBNull(row["LaborHours"]))?0.0m:(System.Decimal?)row["LaborHours"];
					c.LotSize = (Convert.IsDBNull(row["LotSize"]))?(int)0:(System.Int32?)row["LotSize"];
					c.Step = (Convert.IsDBNull(row["Step"]))?string.Empty:(System.String)row["Step"];
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
		/// Fill an <see cref="VList&lt;VProductModelInstructions&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VProductModelInstructions&gt;"/></returns>
		protected VList<VProductModelInstructions> Fill(IDataReader reader, VList<VProductModelInstructions> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VProductModelInstructions entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VProductModelInstructions>("VProductModelInstructions",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VProductModelInstructions();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProductModelId = (System.Int32)reader[((int)VProductModelInstructionsColumn.ProductModelId)];
					//entity.ProductModelId = (Convert.IsDBNull(reader["ProductModelID"]))?(int)0:(System.Int32)reader["ProductModelID"];
					entity.Name = (System.String)reader[((int)VProductModelInstructionsColumn.Name)];
					//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
					entity.Instructions = (reader.IsDBNull(((int)VProductModelInstructionsColumn.Instructions)))?null:(System.String)reader[((int)VProductModelInstructionsColumn.Instructions)];
					//entity.Instructions = (Convert.IsDBNull(reader["Instructions"]))?string.Empty:(System.String)reader["Instructions"];
					entity.LocationId = (reader.IsDBNull(((int)VProductModelInstructionsColumn.LocationId)))?null:(System.Int32?)reader[((int)VProductModelInstructionsColumn.LocationId)];
					//entity.LocationId = (Convert.IsDBNull(reader["LocationID"]))?(int)0:(System.Int32?)reader["LocationID"];
					entity.SetupHours = (reader.IsDBNull(((int)VProductModelInstructionsColumn.SetupHours)))?null:(System.Decimal?)reader[((int)VProductModelInstructionsColumn.SetupHours)];
					//entity.SetupHours = (Convert.IsDBNull(reader["SetupHours"]))?0.0m:(System.Decimal?)reader["SetupHours"];
					entity.MachineHours = (reader.IsDBNull(((int)VProductModelInstructionsColumn.MachineHours)))?null:(System.Decimal?)reader[((int)VProductModelInstructionsColumn.MachineHours)];
					//entity.MachineHours = (Convert.IsDBNull(reader["MachineHours"]))?0.0m:(System.Decimal?)reader["MachineHours"];
					entity.LaborHours = (reader.IsDBNull(((int)VProductModelInstructionsColumn.LaborHours)))?null:(System.Decimal?)reader[((int)VProductModelInstructionsColumn.LaborHours)];
					//entity.LaborHours = (Convert.IsDBNull(reader["LaborHours"]))?0.0m:(System.Decimal?)reader["LaborHours"];
					entity.LotSize = (reader.IsDBNull(((int)VProductModelInstructionsColumn.LotSize)))?null:(System.Int32?)reader[((int)VProductModelInstructionsColumn.LotSize)];
					//entity.LotSize = (Convert.IsDBNull(reader["LotSize"]))?(int)0:(System.Int32?)reader["LotSize"];
					entity.Step = (reader.IsDBNull(((int)VProductModelInstructionsColumn.Step)))?null:(System.String)reader[((int)VProductModelInstructionsColumn.Step)];
					//entity.Step = (Convert.IsDBNull(reader["Step"]))?string.Empty:(System.String)reader["Step"];
					entity.Rowguid = (System.Guid)reader[((int)VProductModelInstructionsColumn.Rowguid)];
					//entity.Rowguid = (Convert.IsDBNull(reader["rowguid"]))?Guid.Empty:(System.Guid)reader["rowguid"];
					entity.ModifiedDate = (System.DateTime)reader[((int)VProductModelInstructionsColumn.ModifiedDate)];
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
		/// Refreshes the <see cref="VProductModelInstructions"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VProductModelInstructions"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VProductModelInstructions entity)
		{
			reader.Read();
			entity.ProductModelId = (System.Int32)reader[((int)VProductModelInstructionsColumn.ProductModelId)];
			//entity.ProductModelId = (Convert.IsDBNull(reader["ProductModelID"]))?(int)0:(System.Int32)reader["ProductModelID"];
			entity.Name = (System.String)reader[((int)VProductModelInstructionsColumn.Name)];
			//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
			entity.Instructions = (reader.IsDBNull(((int)VProductModelInstructionsColumn.Instructions)))?null:(System.String)reader[((int)VProductModelInstructionsColumn.Instructions)];
			//entity.Instructions = (Convert.IsDBNull(reader["Instructions"]))?string.Empty:(System.String)reader["Instructions"];
			entity.LocationId = (reader.IsDBNull(((int)VProductModelInstructionsColumn.LocationId)))?null:(System.Int32?)reader[((int)VProductModelInstructionsColumn.LocationId)];
			//entity.LocationId = (Convert.IsDBNull(reader["LocationID"]))?(int)0:(System.Int32?)reader["LocationID"];
			entity.SetupHours = (reader.IsDBNull(((int)VProductModelInstructionsColumn.SetupHours)))?null:(System.Decimal?)reader[((int)VProductModelInstructionsColumn.SetupHours)];
			//entity.SetupHours = (Convert.IsDBNull(reader["SetupHours"]))?0.0m:(System.Decimal?)reader["SetupHours"];
			entity.MachineHours = (reader.IsDBNull(((int)VProductModelInstructionsColumn.MachineHours)))?null:(System.Decimal?)reader[((int)VProductModelInstructionsColumn.MachineHours)];
			//entity.MachineHours = (Convert.IsDBNull(reader["MachineHours"]))?0.0m:(System.Decimal?)reader["MachineHours"];
			entity.LaborHours = (reader.IsDBNull(((int)VProductModelInstructionsColumn.LaborHours)))?null:(System.Decimal?)reader[((int)VProductModelInstructionsColumn.LaborHours)];
			//entity.LaborHours = (Convert.IsDBNull(reader["LaborHours"]))?0.0m:(System.Decimal?)reader["LaborHours"];
			entity.LotSize = (reader.IsDBNull(((int)VProductModelInstructionsColumn.LotSize)))?null:(System.Int32?)reader[((int)VProductModelInstructionsColumn.LotSize)];
			//entity.LotSize = (Convert.IsDBNull(reader["LotSize"]))?(int)0:(System.Int32?)reader["LotSize"];
			entity.Step = (reader.IsDBNull(((int)VProductModelInstructionsColumn.Step)))?null:(System.String)reader[((int)VProductModelInstructionsColumn.Step)];
			//entity.Step = (Convert.IsDBNull(reader["Step"]))?string.Empty:(System.String)reader["Step"];
			entity.Rowguid = (System.Guid)reader[((int)VProductModelInstructionsColumn.Rowguid)];
			//entity.Rowguid = (Convert.IsDBNull(reader["rowguid"]))?Guid.Empty:(System.Guid)reader["rowguid"];
			entity.ModifiedDate = (System.DateTime)reader[((int)VProductModelInstructionsColumn.ModifiedDate)];
			//entity.ModifiedDate = (Convert.IsDBNull(reader["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)reader["ModifiedDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VProductModelInstructions"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VProductModelInstructions"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VProductModelInstructions entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductModelId = (Convert.IsDBNull(dataRow["ProductModelID"]))?(int)0:(System.Int32)dataRow["ProductModelID"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?string.Empty:(System.String)dataRow["Name"];
			entity.Instructions = (Convert.IsDBNull(dataRow["Instructions"]))?string.Empty:(System.String)dataRow["Instructions"];
			entity.LocationId = (Convert.IsDBNull(dataRow["LocationID"]))?(int)0:(System.Int32?)dataRow["LocationID"];
			entity.SetupHours = (Convert.IsDBNull(dataRow["SetupHours"]))?0.0m:(System.Decimal?)dataRow["SetupHours"];
			entity.MachineHours = (Convert.IsDBNull(dataRow["MachineHours"]))?0.0m:(System.Decimal?)dataRow["MachineHours"];
			entity.LaborHours = (Convert.IsDBNull(dataRow["LaborHours"]))?0.0m:(System.Decimal?)dataRow["LaborHours"];
			entity.LotSize = (Convert.IsDBNull(dataRow["LotSize"]))?(int)0:(System.Int32?)dataRow["LotSize"];
			entity.Step = (Convert.IsDBNull(dataRow["Step"]))?string.Empty:(System.String)dataRow["Step"];
			entity.Rowguid = (Convert.IsDBNull(dataRow["rowguid"]))?Guid.Empty:(System.Guid)dataRow["rowguid"];
			entity.ModifiedDate = (Convert.IsDBNull(dataRow["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)dataRow["ModifiedDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VProductModelInstructionsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelInstructions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelInstructionsFilterBuilder : SqlFilterBuilder<VProductModelInstructionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsFilterBuilder class.
		/// </summary>
		public VProductModelInstructionsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductModelInstructionsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductModelInstructionsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductModelInstructionsFilterBuilder

	#region VProductModelInstructionsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelInstructions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelInstructionsParameterBuilder : ParameterizedSqlFilterBuilder<VProductModelInstructionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsParameterBuilder class.
		/// </summary>
		public VProductModelInstructionsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductModelInstructionsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductModelInstructionsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductModelInstructionsParameterBuilder
	
	#region VProductModelInstructionsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelInstructions"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VProductModelInstructionsSortBuilder : SqlSortBuilder<VProductModelInstructionsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelInstructionsSqlSortBuilder class.
		/// </summary>
		public VProductModelInstructionsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VProductModelInstructionsSortBuilder

} // end namespace
