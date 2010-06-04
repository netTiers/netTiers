#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="StudentMasterIndexProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class StudentMasterIndexProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.StudentMasterIndex, Nettiers.AdventureWorks.Entities.StudentMasterIndexKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StudentMasterIndexKey key)
		{
			return Delete(transactionManager, key.StudentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_studentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _studentId)
		{
			return Delete(null, _studentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_studentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _studentId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override Nettiers.AdventureWorks.Entities.StudentMasterIndex Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StudentMasterIndexKey key, int start, int pageLength)
		{
			return GetByStudentId(transactionManager, key.StudentId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_STUDENT_MASTER_INDEX index.
		/// </summary>
		/// <param name="_studentId"></param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StudentMasterIndex GetByStudentId(System.Int32 _studentId)
		{
			int count = -1;
			return GetByStudentId(null,_studentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_STUDENT_MASTER_INDEX index.
		/// </summary>
		/// <param name="_studentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StudentMasterIndex GetByStudentId(System.Int32 _studentId, int start, int pageLength)
		{
			int count = -1;
			return GetByStudentId(null, _studentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_STUDENT_MASTER_INDEX index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_studentId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StudentMasterIndex GetByStudentId(TransactionManager transactionManager, System.Int32 _studentId)
		{
			int count = -1;
			return GetByStudentId(transactionManager, _studentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_STUDENT_MASTER_INDEX index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_studentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StudentMasterIndex GetByStudentId(TransactionManager transactionManager, System.Int32 _studentId, int start, int pageLength)
		{
			int count = -1;
			return GetByStudentId(transactionManager, _studentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_STUDENT_MASTER_INDEX index.
		/// </summary>
		/// <param name="_studentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.StudentMasterIndex GetByStudentId(System.Int32 _studentId, int start, int pageLength, out int count)
		{
			return GetByStudentId(null, _studentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_STUDENT_MASTER_INDEX index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_studentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.StudentMasterIndex GetByStudentId(TransactionManager transactionManager, System.Int32 _studentId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;StudentMasterIndex&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;StudentMasterIndex&gt;"/></returns>
		public static TList<StudentMasterIndex> Fill(IDataReader reader, TList<StudentMasterIndex> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				Nettiers.AdventureWorks.Entities.StudentMasterIndex c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("StudentMasterIndex")
					.Append("|").Append((System.Int32)reader[((int)StudentMasterIndexColumn.StudentId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<StudentMasterIndex>(
					key.ToString(), // EntityTrackingKey
					"StudentMasterIndex",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.StudentMasterIndex();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.StudentId = (System.Int32)reader[((int)StudentMasterIndexColumn.StudentId - 1)];
					c.OriginalStudentId = c.StudentId;
					c.EpassId = (reader.IsDBNull(((int)StudentMasterIndexColumn.EpassId - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.EpassId - 1)];
					c.StudentUpn = (reader.IsDBNull(((int)StudentMasterIndexColumn.StudentUpn - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.StudentUpn - 1)];
					c.SsabsaId = (reader.IsDBNull(((int)StudentMasterIndexColumn.SsabsaId - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.SsabsaId - 1)];
					c.Surname = (reader.IsDBNull(((int)StudentMasterIndexColumn.Surname - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Surname - 1)];
					c.FirstName = (reader.IsDBNull(((int)StudentMasterIndexColumn.FirstName - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.FirstName - 1)];
					c.OtherNames = (reader.IsDBNull(((int)StudentMasterIndexColumn.OtherNames - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.OtherNames - 1)];
					c.KnownName = (reader.IsDBNull(((int)StudentMasterIndexColumn.KnownName - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.KnownName - 1)];
					c.LegalName = (reader.IsDBNull(((int)StudentMasterIndexColumn.LegalName - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.LegalName - 1)];
					c.Dob = (reader.IsDBNull(((int)StudentMasterIndexColumn.Dob - 1)))?null:(System.DateTime?)reader[((int)StudentMasterIndexColumn.Dob - 1)];
					c.Gender = (reader.IsDBNull(((int)StudentMasterIndexColumn.Gender - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Gender - 1)];
					c.IndigeneousStatus = (reader.IsDBNull(((int)StudentMasterIndexColumn.IndigeneousStatus - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.IndigeneousStatus - 1)];
					c.Lbote = (reader.IsDBNull(((int)StudentMasterIndexColumn.Lbote - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Lbote - 1)];
					c.EslPhase = (reader.IsDBNull(((int)StudentMasterIndexColumn.EslPhase - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.EslPhase - 1)];
					c.TribalGroup = (reader.IsDBNull(((int)StudentMasterIndexColumn.TribalGroup - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.TribalGroup - 1)];
					c.SlpCreatedFlag = (reader.IsDBNull(((int)StudentMasterIndexColumn.SlpCreatedFlag - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.SlpCreatedFlag - 1)];
					c.AddressLine1 = (reader.IsDBNull(((int)StudentMasterIndexColumn.AddressLine1 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.AddressLine1 - 1)];
					c.AddressLine2 = (reader.IsDBNull(((int)StudentMasterIndexColumn.AddressLine2 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.AddressLine2 - 1)];
					c.AddressLine3 = (reader.IsDBNull(((int)StudentMasterIndexColumn.AddressLine3 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.AddressLine3 - 1)];
					c.AddressLine4 = (reader.IsDBNull(((int)StudentMasterIndexColumn.AddressLine4 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.AddressLine4 - 1)];
					c.Suburb = (reader.IsDBNull(((int)StudentMasterIndexColumn.Suburb - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Suburb - 1)];
					c.Postcode = (reader.IsDBNull(((int)StudentMasterIndexColumn.Postcode - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Postcode - 1)];
					c.Phone1 = (reader.IsDBNull(((int)StudentMasterIndexColumn.Phone1 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Phone1 - 1)];
					c.Phone2 = (reader.IsDBNull(((int)StudentMasterIndexColumn.Phone2 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Phone2 - 1)];
					c.SourceSystem = (reader.IsDBNull(((int)StudentMasterIndexColumn.SourceSystem - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.SourceSystem - 1)];
					c.PhoneticMatchId = (reader.IsDBNull(((int)StudentMasterIndexColumn.PhoneticMatchId - 1)))?null:(System.Int32?)reader[((int)StudentMasterIndexColumn.PhoneticMatchId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.StudentMasterIndex entity)
		{
			if (!reader.Read()) return;
			
			entity.StudentId = (System.Int32)reader[((int)StudentMasterIndexColumn.StudentId - 1)];
			entity.OriginalStudentId = (System.Int32)reader["STUDENT_ID"];
			entity.EpassId = (reader.IsDBNull(((int)StudentMasterIndexColumn.EpassId - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.EpassId - 1)];
			entity.StudentUpn = (reader.IsDBNull(((int)StudentMasterIndexColumn.StudentUpn - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.StudentUpn - 1)];
			entity.SsabsaId = (reader.IsDBNull(((int)StudentMasterIndexColumn.SsabsaId - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.SsabsaId - 1)];
			entity.Surname = (reader.IsDBNull(((int)StudentMasterIndexColumn.Surname - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Surname - 1)];
			entity.FirstName = (reader.IsDBNull(((int)StudentMasterIndexColumn.FirstName - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.FirstName - 1)];
			entity.OtherNames = (reader.IsDBNull(((int)StudentMasterIndexColumn.OtherNames - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.OtherNames - 1)];
			entity.KnownName = (reader.IsDBNull(((int)StudentMasterIndexColumn.KnownName - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.KnownName - 1)];
			entity.LegalName = (reader.IsDBNull(((int)StudentMasterIndexColumn.LegalName - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.LegalName - 1)];
			entity.Dob = (reader.IsDBNull(((int)StudentMasterIndexColumn.Dob - 1)))?null:(System.DateTime?)reader[((int)StudentMasterIndexColumn.Dob - 1)];
			entity.Gender = (reader.IsDBNull(((int)StudentMasterIndexColumn.Gender - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Gender - 1)];
			entity.IndigeneousStatus = (reader.IsDBNull(((int)StudentMasterIndexColumn.IndigeneousStatus - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.IndigeneousStatus - 1)];
			entity.Lbote = (reader.IsDBNull(((int)StudentMasterIndexColumn.Lbote - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Lbote - 1)];
			entity.EslPhase = (reader.IsDBNull(((int)StudentMasterIndexColumn.EslPhase - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.EslPhase - 1)];
			entity.TribalGroup = (reader.IsDBNull(((int)StudentMasterIndexColumn.TribalGroup - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.TribalGroup - 1)];
			entity.SlpCreatedFlag = (reader.IsDBNull(((int)StudentMasterIndexColumn.SlpCreatedFlag - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.SlpCreatedFlag - 1)];
			entity.AddressLine1 = (reader.IsDBNull(((int)StudentMasterIndexColumn.AddressLine1 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.AddressLine1 - 1)];
			entity.AddressLine2 = (reader.IsDBNull(((int)StudentMasterIndexColumn.AddressLine2 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.AddressLine2 - 1)];
			entity.AddressLine3 = (reader.IsDBNull(((int)StudentMasterIndexColumn.AddressLine3 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.AddressLine3 - 1)];
			entity.AddressLine4 = (reader.IsDBNull(((int)StudentMasterIndexColumn.AddressLine4 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.AddressLine4 - 1)];
			entity.Suburb = (reader.IsDBNull(((int)StudentMasterIndexColumn.Suburb - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Suburb - 1)];
			entity.Postcode = (reader.IsDBNull(((int)StudentMasterIndexColumn.Postcode - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Postcode - 1)];
			entity.Phone1 = (reader.IsDBNull(((int)StudentMasterIndexColumn.Phone1 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Phone1 - 1)];
			entity.Phone2 = (reader.IsDBNull(((int)StudentMasterIndexColumn.Phone2 - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.Phone2 - 1)];
			entity.SourceSystem = (reader.IsDBNull(((int)StudentMasterIndexColumn.SourceSystem - 1)))?null:(System.String)reader[((int)StudentMasterIndexColumn.SourceSystem - 1)];
			entity.PhoneticMatchId = (reader.IsDBNull(((int)StudentMasterIndexColumn.PhoneticMatchId - 1)))?null:(System.Int32?)reader[((int)StudentMasterIndexColumn.PhoneticMatchId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.StudentMasterIndex entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.StudentId = (System.Int32)dataRow["STUDENT_ID"];
			entity.OriginalStudentId = (System.Int32)dataRow["STUDENT_ID"];
			entity.EpassId = Convert.IsDBNull(dataRow["EPASS_ID"]) ? null : (System.String)dataRow["EPASS_ID"];
			entity.StudentUpn = Convert.IsDBNull(dataRow["STUDENT_UPN"]) ? null : (System.String)dataRow["STUDENT_UPN"];
			entity.SsabsaId = Convert.IsDBNull(dataRow["SSABSA_ID"]) ? null : (System.String)dataRow["SSABSA_ID"];
			entity.Surname = Convert.IsDBNull(dataRow["SURNAME"]) ? null : (System.String)dataRow["SURNAME"];
			entity.FirstName = Convert.IsDBNull(dataRow["FIRST_NAME"]) ? null : (System.String)dataRow["FIRST_NAME"];
			entity.OtherNames = Convert.IsDBNull(dataRow["OTHER_NAMES"]) ? null : (System.String)dataRow["OTHER_NAMES"];
			entity.KnownName = Convert.IsDBNull(dataRow["KNOWN_NAME"]) ? null : (System.String)dataRow["KNOWN_NAME"];
			entity.LegalName = Convert.IsDBNull(dataRow["LEGAL_NAME"]) ? null : (System.String)dataRow["LEGAL_NAME"];
			entity.Dob = Convert.IsDBNull(dataRow["DOB"]) ? null : (System.DateTime?)dataRow["DOB"];
			entity.Gender = Convert.IsDBNull(dataRow["GENDER"]) ? null : (System.String)dataRow["GENDER"];
			entity.IndigeneousStatus = Convert.IsDBNull(dataRow["INDIGENEOUS_STATUS"]) ? null : (System.String)dataRow["INDIGENEOUS_STATUS"];
			entity.Lbote = Convert.IsDBNull(dataRow["LBOTE"]) ? null : (System.String)dataRow["LBOTE"];
			entity.EslPhase = Convert.IsDBNull(dataRow["ESL_PHASE"]) ? null : (System.String)dataRow["ESL_PHASE"];
			entity.TribalGroup = Convert.IsDBNull(dataRow["TRIBAL_GROUP"]) ? null : (System.String)dataRow["TRIBAL_GROUP"];
			entity.SlpCreatedFlag = Convert.IsDBNull(dataRow["SLP_CREATED_FLAG"]) ? null : (System.String)dataRow["SLP_CREATED_FLAG"];
			entity.AddressLine1 = Convert.IsDBNull(dataRow["ADDRESS_LINE_1"]) ? null : (System.String)dataRow["ADDRESS_LINE_1"];
			entity.AddressLine2 = Convert.IsDBNull(dataRow["ADDRESS_LINE_2"]) ? null : (System.String)dataRow["ADDRESS_LINE_2"];
			entity.AddressLine3 = Convert.IsDBNull(dataRow["ADDRESS_LINE_3"]) ? null : (System.String)dataRow["ADDRESS_LINE_3"];
			entity.AddressLine4 = Convert.IsDBNull(dataRow["ADDRESS_LINE_4"]) ? null : (System.String)dataRow["ADDRESS_LINE_4"];
			entity.Suburb = Convert.IsDBNull(dataRow["SUBURB"]) ? null : (System.String)dataRow["SUBURB"];
			entity.Postcode = Convert.IsDBNull(dataRow["POSTCODE"]) ? null : (System.String)dataRow["POSTCODE"];
			entity.Phone1 = Convert.IsDBNull(dataRow["PHONE1"]) ? null : (System.String)dataRow["PHONE1"];
			entity.Phone2 = Convert.IsDBNull(dataRow["PHONE2"]) ? null : (System.String)dataRow["PHONE2"];
			entity.SourceSystem = Convert.IsDBNull(dataRow["SOURCE_SYSTEM"]) ? null : (System.String)dataRow["SOURCE_SYSTEM"];
			entity.PhoneticMatchId = Convert.IsDBNull(dataRow["PHONETIC_MATCH_ID"]) ? null : (System.Int32?)dataRow["PHONETIC_MATCH_ID"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.StudentMasterIndex"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.StudentMasterIndex Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StudentMasterIndex entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			DeepHandles deepHandles = new DeepHandles();
			
			//Fire all DeepLoad Items
			deepHandles.InvokeAll();
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.StudentMasterIndex object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.StudentMasterIndex instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.StudentMasterIndex Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.StudentMasterIndex entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			DeepHandles deepHandles = new DeepHandles();
			//Fire all DeepSave Items
			if (deepHandles.ContainsDuplicates())
				innerList.CancelSession = true;
			else
				deepHandles.InvokeAll();
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region StudentMasterIndexChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.StudentMasterIndex</c>
	///</summary>
	public enum StudentMasterIndexChildEntityTypes
	{
	}
	
	#endregion StudentMasterIndexChildEntityTypes
	
	#region StudentMasterIndexFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;StudentMasterIndexColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StudentMasterIndex"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StudentMasterIndexFilterBuilder : SqlFilterBuilder<StudentMasterIndexColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexFilterBuilder class.
		/// </summary>
		public StudentMasterIndexFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StudentMasterIndexFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StudentMasterIndexFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StudentMasterIndexFilterBuilder
	
	#region StudentMasterIndexParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;StudentMasterIndexColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StudentMasterIndex"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StudentMasterIndexParameterBuilder : ParameterizedSqlFilterBuilder<StudentMasterIndexColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexParameterBuilder class.
		/// </summary>
		public StudentMasterIndexParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StudentMasterIndexParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StudentMasterIndexParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StudentMasterIndexParameterBuilder
	
	#region StudentMasterIndexSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;StudentMasterIndexColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StudentMasterIndex"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class StudentMasterIndexSortBuilder : SqlSortBuilder<StudentMasterIndexColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StudentMasterIndexSqlSortBuilder class.
		/// </summary>
		public StudentMasterIndexSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion StudentMasterIndexSortBuilder
	
} // end namespace
