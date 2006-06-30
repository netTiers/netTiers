#region Using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;

#endregion

namespace netTiers.Petshop.Entities
{	
	///<summary>
	/// An object representation of the 'ExtendedItem' view. [No description found in the database]	
	///</summary>
	/// <remarks>
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class ExtendedItem: ExtendedItemBase
	{
		#region Constructors
		///<summary>
		/// Creates a new <see cref="ExtendedItem"/> instance.
		///</summary>
		public ExtendedItem():base(){}	
		
		///<summary>
		/// Creates a new <see cref="ExtendedItemBase"/> instance.
		///</summary>
		///<param name="itemId"></param>
		///<param name="itemName"></param>
		///<param name="itemDescription"></param>
		///<param name="itemPrice"></param>
		///<param name="itemPhoto"></param>
		///<param name="productId"></param>
		///<param name="productName"></param>
		///<param name="productDescription"></param>
		///<param name="categoryId"></param>
		///<param name="categoryName"></param>
		public ExtendedItem(System.String itemId, System.String itemName, System.String itemDescription, System.Double? itemPrice, System.String itemPhoto, System.String productId, System.String productName, System.String productDescription, System.String categoryId, System.String categoryName)
			:base(itemId, itemName, itemDescription, itemPrice, itemPhoto, productId, productName, productDescription, categoryId, categoryName){}
		
		#endregion
	}
}
