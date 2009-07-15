using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetShop.Business;
using PetShop.Controls;

namespace PetShop.UI.Controls
{
    public partial class CreditCardForm : UserControl
    {
        /// <summary>
        /// Property to set/get credit card info
        /// </summary>
        public CreditCard CreditCard
        {
            get
            {
                // Make sure we clean the input
                string type = WebUtility.InputText(listCctype.SelectedValue, 40);
                string exp = WebUtility.InputText(txtExpdate.Text, 7);
                string number = WebUtility.InputText(txtCcnumber.Text, 20);
                return new CreditCard(type, number, exp);
            }
            set
            {
                if (value != null)
                {
                    if (!string.IsNullOrEmpty(value.CardNumber))
                        txtCcnumber.Text = value.CardNumber;
                    if (!string.IsNullOrEmpty(value.CardExpiration))
                        txtExpdate.Text = value.CardExpiration;
                    if (!string.IsNullOrEmpty(value.CardType))
                        listCctype.Items.FindByValue(value.CardType).Selected = true;
                }
            }
        }

        /// <summary>
        /// Custom validator to check the expiration date
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