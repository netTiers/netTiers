#region Using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;

#endregion

namespace netTiers.PetShop
{	
	///<summary>
	/// An object representation of the 'Item' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	public partial class Item:  ItemBase
	{		
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="Item"/> instance.
		///</summary>
		public Item():base(){}	
		///<summary>
		/// Creates a new <see cref="Item"/> instance.
		///</summary>
		///<param name="itemId"></param>
		///<param name="itemName"></param>
		///<param name="itemDescription"></param>
		///<param name="itemPrice"></param>
		///<param name="itemCurrency"></param>
		///<param name="itemPhoto"></param>
		///<param name="itemProductId"></param>
		public Item(System.String itemId, System.String itemName, System.String itemDescription, System.Double? itemPrice, 
			System.String itemCurrency, System.String itemPhoto, System.String itemProductId):
			base(itemId, itemName, itemDescription, itemPrice, 
			itemCurrency, itemPhoto, itemProductId)
		{}
		
		#endregion
		/// <summary>
      /// Adds custom validation rules to this object.
      /// </summary>
      protected override void AddValidationRules()
      {
         base.AddValidationRules();

         //Add custom validation rules
      }
	}
}
