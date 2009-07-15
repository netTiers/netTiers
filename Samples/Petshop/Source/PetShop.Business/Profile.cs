#region Using directives

using System;

#endregion

namespace PetShop.Business
{	
	///<summary>
	/// An object representation of the 'Profiles' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Profile : ProfileBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Profile"/> instance.
		///</summary>
		public Profile():base(){}	
		
		#endregion

        public TList<Cart> WishList
        {
            get; private set;
        }
	}
}
