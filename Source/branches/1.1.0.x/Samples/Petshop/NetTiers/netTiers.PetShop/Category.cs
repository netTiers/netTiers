#region Using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;

#endregion

namespace netTiers.PetShop
{	
	///<summary>
	/// An object representation of the 'Category' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	public partial class Category:  CategoryBase
	{		
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="Category"/> instance.
		///</summary>
		public Category():base(){}	
		///<summary>
		/// Creates a new <see cref="Category"/> instance.
		///</summary>
		///<param name="categoryId"></param>
		///<param name="categoryName"></param>
		///<param name="categoryAdvicePhoto"></param>
		public Category(System.String categoryId, System.String categoryName, System.String categoryAdvicePhoto):
			base(categoryId, categoryName, categoryAdvicePhoto)
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
