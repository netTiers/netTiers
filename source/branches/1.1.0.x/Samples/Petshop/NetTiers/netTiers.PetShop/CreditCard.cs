#region Using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;

#endregion

namespace netTiers.PetShop
{	
	///<summary>
	/// An object representation of the 'CreditCard' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	public partial class CreditCard:  CreditCardBase
	{		
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="CreditCard"/> instance.
		///</summary>
		public CreditCard():base(){}	
		///<summary>
		/// Creates a new <see cref="CreditCard"/> instance.
		///</summary>
		///<param name="creditCardId"></param>
		///<param name="creditCardNumber"></param>
		///<param name="creditCardCardType"></param>
		///<param name="creditCardExpiryMonth"></param>
		///<param name="creditCardExpiryYear"></param>
		public CreditCard(System.String creditCardId, System.String creditCardNumber, System.String creditCardCardType, 
			System.String creditCardExpiryMonth, System.String creditCardExpiryYear):
			base(creditCardId, creditCardNumber, creditCardCardType, 
			creditCardExpiryMonth, creditCardExpiryYear)
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
