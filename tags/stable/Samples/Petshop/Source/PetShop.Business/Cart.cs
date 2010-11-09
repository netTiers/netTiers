#region Using directives

using System;

#endregion

namespace PetShop.Business
{	
	///<summary>
	/// An object representation of the 'Cart' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Cart : CartBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Cart"/> instance.
		///</summary>
		public Cart():base(){}	
		
		#endregion

        /// <summary>
        /// Gets the Total of this cart item (Price * Quantity)
        /// </summary>
	    public decimal Total
	    {
	        get
	        {
	            return Price*Quantity;
	        }
	    }
	}
}
