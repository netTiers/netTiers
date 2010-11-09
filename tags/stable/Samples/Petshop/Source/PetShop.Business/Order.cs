#region Using directives

using System;

#endregion

namespace PetShop.Business
{	
	///<summary>
	/// An object representation of the 'Orders' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Order : OrderBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Order"/> instance.
		///</summary>
		public Order():base(){}	
		
		#endregion

	    ///<summary>
	    /// Gets/Sets the Credit card
	    ///</summary>
	    public CreditCard CreditCard { get; set; }
	}
}
