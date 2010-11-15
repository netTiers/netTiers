﻿using System;
using System.ComponentModel;

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
	///		The data structure representation of the 'ProductInventory' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IProductInventory 
	{
		/// <summary>			
		/// ProductID : Product identification number. Foreign key to Product.ProductID.
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ProductInventory"</remarks>
		System.Int32 ProductId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalProductId { get; set; }
			
		/// <summary>			
		/// LocationID : Inventory location identification number. Foreign key to Location.LocationID. 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ProductInventory"</remarks>
		System.Int16 LocationId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int16 OriginalLocationId { get; set; }
			
		
		
		/// <summary>
		/// Shelf : Storage compartment within an inventory location.
		/// </summary>
		System.String  Shelf  { get; set; }
		
		/// <summary>
		/// Bin : Storage container on a shelf in an inventory location.
		/// </summary>
		System.Byte  Bin  { get; set; }
		
		/// <summary>
		/// Quantity : Quantity of products in the inventory location.
		/// </summary>
		System.Int16  Quantity  { get; set; }
		
		/// <summary>
		/// rowguid : ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
		/// </summary>
		System.Guid  Rowguid  { get; set; }
		
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

