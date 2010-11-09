using System;

using PetShop.Business;

namespace PetShop.UI.Controls
{
    public partial class CartList : System.Web.UI.UserControl
    {
        /// <summary>
        /// Bind control
        /// </summary>
        public void Bind(TList<Cart> cart)
        {
            if (cart != null)
            {
                repOrdered.DataSource = cart;
                repOrdered.DataBind();
            }

        }
    }
}