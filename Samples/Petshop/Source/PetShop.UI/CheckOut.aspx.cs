using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetShop.Business;
using PetShop.Controls;
using PetShop.Services;
using PetShop.Services.CustomCode;

namespace PetShop.UI
{
    public partial class CheckOut : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
            if(profile.IsAnonymous.Value)
            {
                Response.Redirect("~/SignIn.aspx");
            }

            if (billingForm.Address == null)
            {
                billingForm.Address = new Address(profile);
            }
        }

        /// <summary>
        /// Process the order
        /// </summary>
        protected void wzdCheckOut_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            var inventoryService = new InventoryService();
            Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
            if (profile.CartCollection.Count > 0)
            {
                // display ordered items
                CartListOrdered.Bind(profile.CartCollection);

                // display total and credit card information
                ltlTotalComplete.Text = ltlTotal.Text;
                ltlCreditCardComplete.Text = ltlCreditCard.Text;

                #region Create Order

                var order = new Order();

                order.UserId = profile.UniqueId.ToString();
                order.OrderDate = DateTime.Now;
                order.CreditCard = GetCreditCard();
                order.Courier = order.CreditCard.CardType;
                order.TotalPrice = profile.CartCollection.Sum(c => c.Total);
                order.AuthorizationNumber = 0;
                order.Locale = "en-us";

                #region Shipping Information

                order.ShipAddr1 = billingForm.Address.Address1;
                order.ShipAddr2 = billingForm.Address.Address2;
                order.ShipCity = billingForm.Address.City;
                order.ShipState = billingForm.Address.State;
                order.ShipZip = billingForm.Address.Zip;
                order.ShipCountry = billingForm.Address.Country;
                order.ShipToFirstName = billingForm.Address.FirstName;
                order.ShipToLastName = billingForm.Address.LastName;

                #endregion

                #region Billing Information

                order.BillAddr1 = shippingForm.Address.Address1;
                order.BillAddr2 = shippingForm.Address.Address2;
                order.BillCity = shippingForm.Address.City;
                order.BillState = shippingForm.Address.State;
                order.BillZip = shippingForm.Address.Zip;
                order.BillCountry = shippingForm.Address.Country;
                order.BillToFirstName = shippingForm.Address.FirstName;
                order.BillToLastName = shippingForm.Address.LastName;

                #endregion

                var orderService = new OrderService();
                orderService.DeepSave(order);

                #endregion

                int itemsOnBackOrder = 0;
                //Decrement and check the Inventory.
                foreach (Cart cart in profile.CartCollection)
                {
                    Inventory inventory = inventoryService.GetByItemId(cart.ItemId);
                    
                    if(cart.Quantity > inventory.Qty)
                    {
                        itemsOnBackOrder += cart.Quantity - inventory.Qty;
                    }

                    inventory.Qty -= cart.Quantity;

                    #region Reset the Inventory back to 10,000

                    if (inventory.Qty < 0)
                        inventory.Qty = 10000;

                    #endregion

                    inventoryService.DeepSave(inventory);
                }

                if(itemsOnBackOrder > 0)
                {
                    ItemsOnBackOrder.Text = string.Format("<br /><p style=\"color:red;\"><b>Backorder ALERT:</b> {0} items are on backorder.</p>", itemsOnBackOrder);   
                }

                var cartService = new CartService();
                cartService.SaveOrderLineItems(order.OrderId, profile.CartCollection);

                //profile.CartCollection.SaveOrderLineItems(order.OrderId);

                // destroy cart
                cartService.Delete(profile.CartCollection);
            }
            else
            {
                lblMsg.Text =
                    "<p><br>Can not process the order. Your cart is empty.</p><p class=SignUpLabel><a class=linkNewUser href=Default.aspx>Continue shopping</a></p>";
                wzdCheckOut.Visible = false;
            }
        }

        /// <summary>
        /// Create CreditCardInfo object from user input
        /// </summary>
        private CreditCard GetCreditCard()
        {
            string type = WebUtility.InputText(listCCType.SelectedValue, 40);
            string exp = WebUtility.InputText(txtExpDate.Text, 7);
            string number = WebUtility.InputText(txtCCNumber.Text, 20);
            return new CreditCard(type, number, exp);
        }

        /// <summary>
        /// Changing Wiszard steps
        /// </summary>
        protected void wzdCheckOut_ActiveStePChanged(object sender, EventArgs e)
        {
            if (wzdCheckOut.ActiveStepIndex == 3)
            {
                billingConfirm.Address = billingForm.Address;
                shippingConfirm.Address = shippingForm.Address;

                Profile profile = ProfileManager.Instance.GetCurrentUser(Page.User.Identity.Name);
                ltlTotal.Text = profile.CartCollection.Sum(c => c.Total).ToString("c");

                if (txtCCNumber.Text.Length > 4)
                    ltlCreditCard.Text = txtCCNumber.Text.Substring(txtCCNumber.Text.Length - 4, 4);
            }
        }

        /// <summary>
        /// Handler for "Ship to Billing Addredd" checkbox.
        /// Prefill/Clear shipping address form.
        /// </summary>
        protected void chkShipToBilling_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShipToBilling.Checked)
                shippingForm.Address = billingForm.Address;
        }

        /// <summary>
        /// Custom validator to check CC expiration date
        /// </summary>
        protected void ServerValidate(object source, ServerValidateEventArgs value)
        {
            DateTime dt;
            if (DateTime.TryParse(value.Value, out dt))
                value.IsValid = (dt > DateTime.Now);
            else
                value.IsValid = false;
        }
    }
}