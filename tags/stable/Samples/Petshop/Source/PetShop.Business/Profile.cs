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
        #region Private members

        TList<Cart> _wishList = new TList<Cart>();

        #endregion

        #region Constructors

        ///<summary>
		/// Creates a new <see cref="Profile"/> instance.
		///</summary>
		public Profile() : base()
		{
		}	
		
		#endregion

        ///<summary>
        /// A Wishlist.
        ///</summary>
        public TList<Cart> WishList
        {
            get
            {
                //NEED TO FIX THIS.
                return _wishList;
            }
            private set
            {
                if (value != null)
                    _wishList = value;
            }
        }
	}
}
