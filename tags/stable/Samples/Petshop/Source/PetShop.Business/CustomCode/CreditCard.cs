using System;

namespace PetShop.Business
{
    /// <summary>
    /// Business entity used to model credit card information.
    /// </summary>
    [Serializable]
    public class CreditCard
    {
        #region Constructor(s)

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreditCard()
        {
        }

        /// <summary>
        /// Constructor with specified initial values.
        /// </summary>
        /// <param name="cardType">Card type, e.g. Visa, Master Card, American Express.</param>
        /// <param name="cardNumber">Number on the card.</param>
        /// <param name="cardExpiration">Expiry Date, form  MM/YY.</param>
        public CreditCard(string cardType, string cardNumber, string cardExpiration)
        {
            CardType = cardType;
            CardNumber = cardNumber;
            CardExpiration = cardExpiration;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Card type, e.g. Visa, Master Card, American Express.
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// Number on the card.
        /// </summary>
        public string CardNumber { get; set; }
        
        /// <summary>
        /// Expiry Date, form  MM/YY.
        /// </summary>
        public string CardExpiration { get; set; }

        #endregion
    }
}