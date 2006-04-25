#region Using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;

#endregion

namespace netTiers.PetShop
{	
	///<summary>
	/// An object representation of the 'Product' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	public partial class Product:  ProductBase
	{		
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="Product"/> instance.
		///</summary>
		public Product():base(){}	
		///<summary>
		/// Creates a new <see cref="Product"/> instance.
		///</summary>
		///<param name="productId"></param>
		///<param name="productName"></param>
		///<param name="productDescription"></param>
		///<param name="productCategoryId"></param>
		public Product(System.String productId, System.String productName, System.String productDescription, 
			System.String productCategoryId):
			base(productId, productName, productDescription, 
			productCategoryId)
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
