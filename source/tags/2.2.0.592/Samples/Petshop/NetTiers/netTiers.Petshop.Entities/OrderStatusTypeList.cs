
using System;

namespace netTiers.Petshop.Entities
{
	///<summary>
	/// 
	///</summary>
	/// <remark>this enumeration contains the items contained in the table OrderStatusType</remark>
	[Serializable]
	public enum OrderStatusTypeList
	{
		/// <summary> 
		/// Order has been placed
		/// </summary>
		Ordered = 1, 

		/// <summary> 
		/// Order has been shipped
		/// </summary>
		Shipped = 2, 

		/// <summary> 
		/// Order has been shipped and fulfilled
		/// </summary>
		Fulfilled = 3, 

		/// <summary> 
		/// Order has been canceled
		/// </summary>
		Canceled = 4

	}
}