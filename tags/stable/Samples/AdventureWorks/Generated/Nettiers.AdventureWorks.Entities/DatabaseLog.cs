#region Using directives

using System;

#endregion

namespace Nettiers.AdventureWorks.Entities
{	
	///<summary>
	/// Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog.	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class DatabaseLog : DatabaseLogBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="DatabaseLog"/> instance.
		///</summary>
		public DatabaseLog():base(){}	
		
		#endregion
	}
}
