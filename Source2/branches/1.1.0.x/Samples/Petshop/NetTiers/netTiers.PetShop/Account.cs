#region Using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;

#endregion

namespace netTiers.PetShop
{	
	///<summary>
	/// An object representation of the 'Account' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	public partial class Account:  AccountBase
	{		
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="Account"/> instance.
		///</summary>
		public Account():base(){}	
		///<summary>
		/// Creates a new <see cref="Account"/> instance.
		///</summary>
		///<param name="accountId"></param>
		///<param name="accountFirstName"></param>
		///<param name="accountLastName"></param>
		///<param name="accountStreetAddress"></param>
		///<param name="accountPostalCode"></param>
		///<param name="accountCity"></param>
		///<param name="accountStateOrProvince"></param>
		///<param name="accountCountry"></param>
		///<param name="accountTelephoneNumber"></param>
		///<param name="accountEmail"></param>
		///<param name="accountLogin"></param>
		///<param name="accountPassword"></param>
		///<param name="accountIWantMyList"></param>
		///<param name="accountIWantPetTips"></param>
		///<param name="accountFavoriteLanguage"></param>
		///<param name="accountCreditCardId"></param>
		///<param name="accountFavoriteCategoryId"></param>
		public Account(System.String accountId, System.String accountFirstName, System.String accountLastName, 
			System.String accountStreetAddress, System.String accountPostalCode, System.String accountCity, System.String accountStateOrProvince, 
			System.String accountCountry, System.String accountTelephoneNumber, System.String accountEmail, System.String accountLogin, 
			System.String accountPassword, System.Boolean? accountIWantMyList, System.Boolean? accountIWantPetTips, System.String accountFavoriteLanguage, 
			System.String accountCreditCardId, System.String accountFavoriteCategoryId):
			base(accountId, accountFirstName, accountLastName, 
			accountStreetAddress, accountPostalCode, accountCity, accountStateOrProvince, 
			accountCountry, accountTelephoneNumber, accountEmail, accountLogin, 
			accountPassword, accountIWantMyList, accountIWantPetTips, accountFavoriteLanguage, 
			accountCreditCardId, accountFavoriteCategoryId)
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
