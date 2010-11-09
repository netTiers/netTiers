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
	/// This class is the base class for any <see cref="VProductModelCatalogDescriptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VProductModelCatalogDescriptionProviderBaseCore : EntityViewProviderBase<VProductModelCatalogDescription>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VProductModelCatalogDescription&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VProductModelCatalogDescription&gt;"/></returns>
		protected static VList&lt;VProductModelCatalogDescription&gt; Fill(DataSet dataSet, VList<VProductModelCatalogDescription> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VProductModelCatalogDescription>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VProductModelCatalogDescription&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VProductModelCatalogDescription>"/></returns>
		protected static VList&lt;VProductModelCatalogDescription&gt; Fill(DataTable dataTable, VList<VProductModelCatalogDescription> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VProductModelCatalogDescription c = new VProductModelCatalogDescription();
					c.ProductModelId = (Convert.IsDBNull(row["ProductModelID"]))?(int)0:(System.Int32)row["ProductModelID"];
					c.Name = (Convert.IsDBNull(row["Name"]))?string.Empty:(System.String)row["Name"];
					c.Summary = (Convert.IsDBNull(row["Summary"]))?string.Empty:(System.String)row["Summary"];
					c.Manufacturer = (Convert.IsDBNull(row["Manufacturer"]))?string.Empty:(System.String)row["Manufacturer"];
					c.Copyright = (Convert.IsDBNull(row["Copyright"]))?string.Empty:(System.String)row["Copyright"];
					c.ProductUrl = (Convert.IsDBNull(row["ProductURL"]))?string.Empty:(System.String)row["ProductURL"];
					c.WarrantyPeriod = (Convert.IsDBNull(row["WarrantyPeriod"]))?string.Empty:(System.String)row["WarrantyPeriod"];
					c.WarrantyDescription = (Convert.IsDBNull(row["WarrantyDescription"]))?string.Empty:(System.String)row["WarrantyDescription"];
					c.NoOfYears = (Convert.IsDBNull(row["NoOfYears"]))?string.Empty:(System.String)row["NoOfYears"];
					c.MaintenanceDescription = (Convert.IsDBNull(row["MaintenanceDescription"]))?string.Empty:(System.String)row["MaintenanceDescription"];
					c.Wheel = (Convert.IsDBNull(row["Wheel"]))?string.Empty:(System.String)row["Wheel"];
					c.Saddle = (Convert.IsDBNull(row["Saddle"]))?string.Empty:(System.String)row["Saddle"];
					c.Pedal = (Convert.IsDBNull(row["Pedal"]))?string.Empty:(System.String)row["Pedal"];
					c.BikeFrame = (Convert.IsDBNull(row["BikeFrame"]))?string.Empty:(System.String)row["BikeFrame"];
					c.Crankset = (Convert.IsDBNull(row["Crankset"]))?string.Empty:(System.String)row["Crankset"];
					c.PictureAngle = (Convert.IsDBNull(row["PictureAngle"]))?string.Empty:(System.String)row["PictureAngle"];
					c.PictureSize = (Convert.IsDBNull(row["PictureSize"]))?string.Empty:(System.String)row["PictureSize"];
					c.ProductPhotoId = (Convert.IsDBNull(row["ProductPhotoID"]))?string.Empty:(System.String)row["ProductPhotoID"];
					c.Material = (Convert.IsDBNull(row["Material"]))?string.Empty:(System.String)row["Material"];
					c.Color = (Convert.IsDBNull(row["Color"]))?string.Empty:(System.String)row["Color"];
					c.ProductLine = (Convert.IsDBNull(row["ProductLine"]))?string.Empty:(System.String)row["ProductLine"];
					c.Style = (Convert.IsDBNull(row["Style"]))?string.Empty:(System.String)row["Style"];
					c.RiderExperience = (Convert.IsDBNull(row["RiderExperience"]))?string.Empty:(System.String)row["RiderExperience"];
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
		/// Fill an <see cref="VList&lt;VProductModelCatalogDescription&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VProductModelCatalogDescription&gt;"/></returns>
		protected VList<VProductModelCatalogDescription> Fill(IDataReader reader, VList<VProductModelCatalogDescription> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VProductModelCatalogDescription entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VProductModelCatalogDescription>("VProductModelCatalogDescription",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VProductModelCatalogDescription();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProductModelId = (System.Int32)reader[((int)VProductModelCatalogDescriptionColumn.ProductModelId)];
					//entity.ProductModelId = (Convert.IsDBNull(reader["ProductModelID"]))?(int)0:(System.Int32)reader["ProductModelID"];
					entity.Name = (System.String)reader[((int)VProductModelCatalogDescriptionColumn.Name)];
					//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
					entity.Summary = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Summary)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Summary)];
					//entity.Summary = (Convert.IsDBNull(reader["Summary"]))?string.Empty:(System.String)reader["Summary"];
					entity.Manufacturer = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Manufacturer)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Manufacturer)];
					//entity.Manufacturer = (Convert.IsDBNull(reader["Manufacturer"]))?string.Empty:(System.String)reader["Manufacturer"];
					entity.Copyright = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Copyright)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Copyright)];
					//entity.Copyright = (Convert.IsDBNull(reader["Copyright"]))?string.Empty:(System.String)reader["Copyright"];
					entity.ProductUrl = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.ProductUrl)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.ProductUrl)];
					//entity.ProductUrl = (Convert.IsDBNull(reader["ProductURL"]))?string.Empty:(System.String)reader["ProductURL"];
					entity.WarrantyPeriod = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.WarrantyPeriod)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.WarrantyPeriod)];
					//entity.WarrantyPeriod = (Convert.IsDBNull(reader["WarrantyPeriod"]))?string.Empty:(System.String)reader["WarrantyPeriod"];
					entity.WarrantyDescription = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.WarrantyDescription)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.WarrantyDescription)];
					//entity.WarrantyDescription = (Convert.IsDBNull(reader["WarrantyDescription"]))?string.Empty:(System.String)reader["WarrantyDescription"];
					entity.NoOfYears = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.NoOfYears)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.NoOfYears)];
					//entity.NoOfYears = (Convert.IsDBNull(reader["NoOfYears"]))?string.Empty:(System.String)reader["NoOfYears"];
					entity.MaintenanceDescription = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.MaintenanceDescription)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.MaintenanceDescription)];
					//entity.MaintenanceDescription = (Convert.IsDBNull(reader["MaintenanceDescription"]))?string.Empty:(System.String)reader["MaintenanceDescription"];
					entity.Wheel = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Wheel)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Wheel)];
					//entity.Wheel = (Convert.IsDBNull(reader["Wheel"]))?string.Empty:(System.String)reader["Wheel"];
					entity.Saddle = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Saddle)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Saddle)];
					//entity.Saddle = (Convert.IsDBNull(reader["Saddle"]))?string.Empty:(System.String)reader["Saddle"];
					entity.Pedal = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Pedal)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Pedal)];
					//entity.Pedal = (Convert.IsDBNull(reader["Pedal"]))?string.Empty:(System.String)reader["Pedal"];
					entity.BikeFrame = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.BikeFrame)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.BikeFrame)];
					//entity.BikeFrame = (Convert.IsDBNull(reader["BikeFrame"]))?string.Empty:(System.String)reader["BikeFrame"];
					entity.Crankset = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Crankset)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Crankset)];
					//entity.Crankset = (Convert.IsDBNull(reader["Crankset"]))?string.Empty:(System.String)reader["Crankset"];
					entity.PictureAngle = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.PictureAngle)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.PictureAngle)];
					//entity.PictureAngle = (Convert.IsDBNull(reader["PictureAngle"]))?string.Empty:(System.String)reader["PictureAngle"];
					entity.PictureSize = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.PictureSize)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.PictureSize)];
					//entity.PictureSize = (Convert.IsDBNull(reader["PictureSize"]))?string.Empty:(System.String)reader["PictureSize"];
					entity.ProductPhotoId = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.ProductPhotoId)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.ProductPhotoId)];
					//entity.ProductPhotoId = (Convert.IsDBNull(reader["ProductPhotoID"]))?string.Empty:(System.String)reader["ProductPhotoID"];
					entity.Material = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Material)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Material)];
					//entity.Material = (Convert.IsDBNull(reader["Material"]))?string.Empty:(System.String)reader["Material"];
					entity.Color = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Color)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Color)];
					//entity.Color = (Convert.IsDBNull(reader["Color"]))?string.Empty:(System.String)reader["Color"];
					entity.ProductLine = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.ProductLine)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.ProductLine)];
					//entity.ProductLine = (Convert.IsDBNull(reader["ProductLine"]))?string.Empty:(System.String)reader["ProductLine"];
					entity.Style = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Style)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Style)];
					//entity.Style = (Convert.IsDBNull(reader["Style"]))?string.Empty:(System.String)reader["Style"];
					entity.RiderExperience = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.RiderExperience)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.RiderExperience)];
					//entity.RiderExperience = (Convert.IsDBNull(reader["RiderExperience"]))?string.Empty:(System.String)reader["RiderExperience"];
					entity.Rowguid = (System.Guid)reader[((int)VProductModelCatalogDescriptionColumn.Rowguid)];
					//entity.Rowguid = (Convert.IsDBNull(reader["rowguid"]))?Guid.Empty:(System.Guid)reader["rowguid"];
					entity.ModifiedDate = (System.DateTime)reader[((int)VProductModelCatalogDescriptionColumn.ModifiedDate)];
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
		/// Refreshes the <see cref="VProductModelCatalogDescription"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VProductModelCatalogDescription"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VProductModelCatalogDescription entity)
		{
			reader.Read();
			entity.ProductModelId = (System.Int32)reader[((int)VProductModelCatalogDescriptionColumn.ProductModelId)];
			//entity.ProductModelId = (Convert.IsDBNull(reader["ProductModelID"]))?(int)0:(System.Int32)reader["ProductModelID"];
			entity.Name = (System.String)reader[((int)VProductModelCatalogDescriptionColumn.Name)];
			//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
			entity.Summary = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Summary)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Summary)];
			//entity.Summary = (Convert.IsDBNull(reader["Summary"]))?string.Empty:(System.String)reader["Summary"];
			entity.Manufacturer = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Manufacturer)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Manufacturer)];
			//entity.Manufacturer = (Convert.IsDBNull(reader["Manufacturer"]))?string.Empty:(System.String)reader["Manufacturer"];
			entity.Copyright = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Copyright)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Copyright)];
			//entity.Copyright = (Convert.IsDBNull(reader["Copyright"]))?string.Empty:(System.String)reader["Copyright"];
			entity.ProductUrl = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.ProductUrl)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.ProductUrl)];
			//entity.ProductUrl = (Convert.IsDBNull(reader["ProductURL"]))?string.Empty:(System.String)reader["ProductURL"];
			entity.WarrantyPeriod = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.WarrantyPeriod)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.WarrantyPeriod)];
			//entity.WarrantyPeriod = (Convert.IsDBNull(reader["WarrantyPeriod"]))?string.Empty:(System.String)reader["WarrantyPeriod"];
			entity.WarrantyDescription = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.WarrantyDescription)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.WarrantyDescription)];
			//entity.WarrantyDescription = (Convert.IsDBNull(reader["WarrantyDescription"]))?string.Empty:(System.String)reader["WarrantyDescription"];
			entity.NoOfYears = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.NoOfYears)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.NoOfYears)];
			//entity.NoOfYears = (Convert.IsDBNull(reader["NoOfYears"]))?string.Empty:(System.String)reader["NoOfYears"];
			entity.MaintenanceDescription = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.MaintenanceDescription)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.MaintenanceDescription)];
			//entity.MaintenanceDescription = (Convert.IsDBNull(reader["MaintenanceDescription"]))?string.Empty:(System.String)reader["MaintenanceDescription"];
			entity.Wheel = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Wheel)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Wheel)];
			//entity.Wheel = (Convert.IsDBNull(reader["Wheel"]))?string.Empty:(System.String)reader["Wheel"];
			entity.Saddle = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Saddle)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Saddle)];
			//entity.Saddle = (Convert.IsDBNull(reader["Saddle"]))?string.Empty:(System.String)reader["Saddle"];
			entity.Pedal = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Pedal)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Pedal)];
			//entity.Pedal = (Convert.IsDBNull(reader["Pedal"]))?string.Empty:(System.String)reader["Pedal"];
			entity.BikeFrame = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.BikeFrame)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.BikeFrame)];
			//entity.BikeFrame = (Convert.IsDBNull(reader["BikeFrame"]))?string.Empty:(System.String)reader["BikeFrame"];
			entity.Crankset = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Crankset)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Crankset)];
			//entity.Crankset = (Convert.IsDBNull(reader["Crankset"]))?string.Empty:(System.String)reader["Crankset"];
			entity.PictureAngle = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.PictureAngle)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.PictureAngle)];
			//entity.PictureAngle = (Convert.IsDBNull(reader["PictureAngle"]))?string.Empty:(System.String)reader["PictureAngle"];
			entity.PictureSize = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.PictureSize)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.PictureSize)];
			//entity.PictureSize = (Convert.IsDBNull(reader["PictureSize"]))?string.Empty:(System.String)reader["PictureSize"];
			entity.ProductPhotoId = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.ProductPhotoId)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.ProductPhotoId)];
			//entity.ProductPhotoId = (Convert.IsDBNull(reader["ProductPhotoID"]))?string.Empty:(System.String)reader["ProductPhotoID"];
			entity.Material = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Material)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Material)];
			//entity.Material = (Convert.IsDBNull(reader["Material"]))?string.Empty:(System.String)reader["Material"];
			entity.Color = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Color)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Color)];
			//entity.Color = (Convert.IsDBNull(reader["Color"]))?string.Empty:(System.String)reader["Color"];
			entity.ProductLine = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.ProductLine)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.ProductLine)];
			//entity.ProductLine = (Convert.IsDBNull(reader["ProductLine"]))?string.Empty:(System.String)reader["ProductLine"];
			entity.Style = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.Style)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.Style)];
			//entity.Style = (Convert.IsDBNull(reader["Style"]))?string.Empty:(System.String)reader["Style"];
			entity.RiderExperience = (reader.IsDBNull(((int)VProductModelCatalogDescriptionColumn.RiderExperience)))?null:(System.String)reader[((int)VProductModelCatalogDescriptionColumn.RiderExperience)];
			//entity.RiderExperience = (Convert.IsDBNull(reader["RiderExperience"]))?string.Empty:(System.String)reader["RiderExperience"];
			entity.Rowguid = (System.Guid)reader[((int)VProductModelCatalogDescriptionColumn.Rowguid)];
			//entity.Rowguid = (Convert.IsDBNull(reader["rowguid"]))?Guid.Empty:(System.Guid)reader["rowguid"];
			entity.ModifiedDate = (System.DateTime)reader[((int)VProductModelCatalogDescriptionColumn.ModifiedDate)];
			//entity.ModifiedDate = (Convert.IsDBNull(reader["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)reader["ModifiedDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VProductModelCatalogDescription"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VProductModelCatalogDescription"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VProductModelCatalogDescription entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductModelId = (Convert.IsDBNull(dataRow["ProductModelID"]))?(int)0:(System.Int32)dataRow["ProductModelID"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?string.Empty:(System.String)dataRow["Name"];
			entity.Summary = (Convert.IsDBNull(dataRow["Summary"]))?string.Empty:(System.String)dataRow["Summary"];
			entity.Manufacturer = (Convert.IsDBNull(dataRow["Manufacturer"]))?string.Empty:(System.String)dataRow["Manufacturer"];
			entity.Copyright = (Convert.IsDBNull(dataRow["Copyright"]))?string.Empty:(System.String)dataRow["Copyright"];
			entity.ProductUrl = (Convert.IsDBNull(dataRow["ProductURL"]))?string.Empty:(System.String)dataRow["ProductURL"];
			entity.WarrantyPeriod = (Convert.IsDBNull(dataRow["WarrantyPeriod"]))?string.Empty:(System.String)dataRow["WarrantyPeriod"];
			entity.WarrantyDescription = (Convert.IsDBNull(dataRow["WarrantyDescription"]))?string.Empty:(System.String)dataRow["WarrantyDescription"];
			entity.NoOfYears = (Convert.IsDBNull(dataRow["NoOfYears"]))?string.Empty:(System.String)dataRow["NoOfYears"];
			entity.MaintenanceDescription = (Convert.IsDBNull(dataRow["MaintenanceDescription"]))?string.Empty:(System.String)dataRow["MaintenanceDescription"];
			entity.Wheel = (Convert.IsDBNull(dataRow["Wheel"]))?string.Empty:(System.String)dataRow["Wheel"];
			entity.Saddle = (Convert.IsDBNull(dataRow["Saddle"]))?string.Empty:(System.String)dataRow["Saddle"];
			entity.Pedal = (Convert.IsDBNull(dataRow["Pedal"]))?string.Empty:(System.String)dataRow["Pedal"];
			entity.BikeFrame = (Convert.IsDBNull(dataRow["BikeFrame"]))?string.Empty:(System.String)dataRow["BikeFrame"];
			entity.Crankset = (Convert.IsDBNull(dataRow["Crankset"]))?string.Empty:(System.String)dataRow["Crankset"];
			entity.PictureAngle = (Convert.IsDBNull(dataRow["PictureAngle"]))?string.Empty:(System.String)dataRow["PictureAngle"];
			entity.PictureSize = (Convert.IsDBNull(dataRow["PictureSize"]))?string.Empty:(System.String)dataRow["PictureSize"];
			entity.ProductPhotoId = (Convert.IsDBNull(dataRow["ProductPhotoID"]))?string.Empty:(System.String)dataRow["ProductPhotoID"];
			entity.Material = (Convert.IsDBNull(dataRow["Material"]))?string.Empty:(System.String)dataRow["Material"];
			entity.Color = (Convert.IsDBNull(dataRow["Color"]))?string.Empty:(System.String)dataRow["Color"];
			entity.ProductLine = (Convert.IsDBNull(dataRow["ProductLine"]))?string.Empty:(System.String)dataRow["ProductLine"];
			entity.Style = (Convert.IsDBNull(dataRow["Style"]))?string.Empty:(System.String)dataRow["Style"];
			entity.RiderExperience = (Convert.IsDBNull(dataRow["RiderExperience"]))?string.Empty:(System.String)dataRow["RiderExperience"];
			entity.Rowguid = (Convert.IsDBNull(dataRow["rowguid"]))?Guid.Empty:(System.Guid)dataRow["rowguid"];
			entity.ModifiedDate = (Convert.IsDBNull(dataRow["ModifiedDate"]))?DateTime.MinValue:(System.DateTime)dataRow["ModifiedDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VProductModelCatalogDescriptionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelCatalogDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelCatalogDescriptionFilterBuilder : SqlFilterBuilder<VProductModelCatalogDescriptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionFilterBuilder class.
		/// </summary>
		public VProductModelCatalogDescriptionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductModelCatalogDescriptionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductModelCatalogDescriptionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductModelCatalogDescriptionFilterBuilder

	#region VProductModelCatalogDescriptionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelCatalogDescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VProductModelCatalogDescriptionParameterBuilder : ParameterizedSqlFilterBuilder<VProductModelCatalogDescriptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionParameterBuilder class.
		/// </summary>
		public VProductModelCatalogDescriptionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VProductModelCatalogDescriptionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VProductModelCatalogDescriptionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VProductModelCatalogDescriptionParameterBuilder
	
	#region VProductModelCatalogDescriptionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VProductModelCatalogDescription"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VProductModelCatalogDescriptionSortBuilder : SqlSortBuilder<VProductModelCatalogDescriptionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VProductModelCatalogDescriptionSqlSortBuilder class.
		/// </summary>
		public VProductModelCatalogDescriptionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VProductModelCatalogDescriptionSortBuilder

} // end namespace
