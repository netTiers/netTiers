﻿using System;
using System.ComponentModel;

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
	///		The data structure representation of the 'ProductCostHistory' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IProductCostHistory 
	{
		/// <summary>			
		/// ProductID : Product identification number. Foreign key to Product.ProductID
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ProductCostHistory"</remarks>
		System.Int32 ProductId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalProductId { get; set; }
			
		/// <summary>			
		/// StartDate : Product cost start date.
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ProductCostHistory"</remarks>
		System.DateTime StartDate { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.DateTime OriginalStartDate { get; set; }
			
		
		
		/// <summary>
		/// EndDate : Product cost end date.
		/// </summary>
		System.DateTime?  EndDate  { get; set; }
		
		/// <summary>
		/// StandardCost : Standard cost of the product.
		/// </summary>
		System.Decimal  StandardCost  { get; set; }
		
		/// <summary>
		/// ModifiedDate : Date and time the record was last updated.
		/// </summary>
		System.DateTime  ModifiedDate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

