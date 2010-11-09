#region Using directives

using System;

#endregion

namespace Nettiers.AdventureWorks.Entities
{	
	///<summary>
	/// Employee information such as salary, department, and title.	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Employee : EmployeeBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Employee"/> instance.
		///</summary>
		public Employee():base(){}	
		
		#endregion
	}
}
