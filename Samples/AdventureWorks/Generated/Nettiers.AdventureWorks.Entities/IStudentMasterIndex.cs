﻿using System;
using System.ComponentModel;

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
	///		The data structure representation of the 'STUDENT_MASTER_INDEX' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IStudentMasterIndex 
	{
		/// <summary>			
		/// STUDENT_ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "STUDENT_MASTER_INDEX"</remarks>
		System.Int32 StudentId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalStudentId { get; set; }
			
		
		
		/// <summary>
		/// EPASS_ID : 
		/// </summary>
		System.String  EpassId  { get; set; }
		
		/// <summary>
		/// STUDENT_UPN : 
		/// </summary>
		System.String  StudentUpn  { get; set; }
		
		/// <summary>
		/// SSABSA_ID : 
		/// </summary>
		System.String  SsabsaId  { get; set; }
		
		/// <summary>
		/// SURNAME : 
		/// </summary>
		System.String  Surname  { get; set; }
		
		/// <summary>
		/// FIRST_NAME : 
		/// </summary>
		System.String  FirstName  { get; set; }
		
		/// <summary>
		/// OTHER_NAMES : 
		/// </summary>
		System.String  OtherNames  { get; set; }
		
		/// <summary>
		/// KNOWN_NAME : 
		/// </summary>
		System.String  KnownName  { get; set; }
		
		/// <summary>
		/// LEGAL_NAME : 
		/// </summary>
		System.String  LegalName  { get; set; }
		
		/// <summary>
		/// DOB : 
		/// </summary>
		System.DateTime?  Dob  { get; set; }
		
		/// <summary>
		/// GENDER : 
		/// </summary>
		System.String  Gender  { get; set; }
		
		/// <summary>
		/// INDIGENEOUS_STATUS : 
		/// </summary>
		System.String  IndigeneousStatus  { get; set; }
		
		/// <summary>
		/// LBOTE : 
		/// </summary>
		System.String  Lbote  { get; set; }
		
		/// <summary>
		/// ESL_PHASE : 
		/// </summary>
		System.String  EslPhase  { get; set; }
		
		/// <summary>
		/// TRIBAL_GROUP : 
		/// </summary>
		System.String  TribalGroup  { get; set; }
		
		/// <summary>
		/// SLP_CREATED_FLAG : 
		/// </summary>
		System.String  SlpCreatedFlag  { get; set; }
		
		/// <summary>
		/// ADDRESS_LINE_1 : 
		/// </summary>
		System.String  AddressLine1  { get; set; }
		
		/// <summary>
		/// ADDRESS_LINE_2 : 
		/// </summary>
		System.String  AddressLine2  { get; set; }
		
		/// <summary>
		/// ADDRESS_LINE_3 : 
		/// </summary>
		System.String  AddressLine3  { get; set; }
		
		/// <summary>
		/// ADDRESS_LINE_4 : 
		/// </summary>
		System.String  AddressLine4  { get; set; }
		
		/// <summary>
		/// SUBURB : 
		/// </summary>
		System.String  Suburb  { get; set; }
		
		/// <summary>
		/// POSTCODE : 
		/// </summary>
		System.String  Postcode  { get; set; }
		
		/// <summary>
		/// PHONE1 : 
		/// </summary>
		System.String  Phone1  { get; set; }
		
		/// <summary>
		/// PHONE2 : 
		/// </summary>
		System.String  Phone2  { get; set; }
		
		/// <summary>
		/// SOURCE_SYSTEM : 
		/// </summary>
		System.String  SourceSystem  { get; set; }
		
		/// <summary>
		/// PHONETIC_MATCH_ID : 
		/// </summary>
		System.Int32?  PhoneticMatchId  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


