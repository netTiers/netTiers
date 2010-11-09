	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using PetShop.Business;
using PetShop.Business.Validation;

using PetShop.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace PetShop.Services
{		
	/// <summary>
	/// An component type implementation of the 'Cart' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CartService : PetShop.Services.CartServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CartService class.
		/// </summary>
		public CartService() : base()
		{
		}
		#endregion Constructors

        /// <summary>
        /// Saves the new order line items
        /// </summary>
        /// <param name="orderId">The order id of the item</param>
	    /// <param name="cartItems">The cart items</param>
	    public void SaveOrderLineItems(int orderId, TList<Cart> cartItems)
	    {
            var lineItemService = new LineItemService();
            var lineNum = 0;

            foreach (var item in cartItems)
            {
                var lineItem = new LineItem
                                   {
                                       OrderId = orderId,
                                       ItemId = item.ItemId,
                                       LineNum = ++lineNum,
                                       Quantity = item.Quantity,
                                       UnitPrice = item.Price
                                   };

                lineItemService.Save(lineItem);
            }

	    }
	}//End Class

} // end namespace
