#region Using directives

using System;

#endregion

namespace Nettiers.AdventureWorks.Entities
{	
	///<summary>
	/// Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct.	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class ErrorLog : ErrorLogBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="ErrorLog"/> instance.
		///</summary>
		public ErrorLog():base(){}	
		
		#endregion
	}
}
