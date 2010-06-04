#region Using directives

using System;

#endregion

namespace Nettiers.AdventureWorks.Entities
{	
	///<summary>
	/// Record of each purchase order, sales order, or work order transaction year to date.	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class TransactionHistory : TransactionHistoryBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="TransactionHistory"/> instance.
		///</summary>
		public TransactionHistory():base(){}	
		
		#endregion
	}
}
