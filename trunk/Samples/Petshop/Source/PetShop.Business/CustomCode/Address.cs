using System;

namespace PetShop.Business
{
    public class Address
    {
        #region Constructor(s)

        /// <summary>
        /// Default constructor
        /// </summary>
        private Address()
        {
        }

        /// <summary>
        /// Constructor with specified initial values.
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="address1">Address line 1</param>
        /// <param name="address2">Address line 2</param>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <param name="zip">Postal Code</param>
        /// <param name="country">Country</param>
        /// <param name="phone">Phone number at this address.</param>
        /// <param name="email">Email at this address.</param>
        public Address(string firstName, string lastName, string address1, string address2, string city, string state, string zip, string country, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
            Phone = phone;
            Email = email;
        }

        /// <summary>
        /// Constructor with specified initial values.
        /// </summary>
        /// <param name="profile">User's Profile</param>
        public Address(Profile profile)
        {
            if (!string.IsNullOrEmpty(profile.Username) && profile.AccountCollection.Count > 0)
            {
                //Just grab the first account.
                Account account = profile.AccountCollection[0];
                FirstName = account.FirstName;
                LastName =  account.LastName;
                Address1 = account.Address1;
                Address2 = account.Address2;
                City = account.City;
                State = account.State;
                Zip = account.Zip;
                Country = account.Country;
                Phone = account.Phone;
                Email = account.Email;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Address line 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address line 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Postal Code
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Phone number at this address.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email at this address.
        /// </summary>
        public string Email { get; set; }

        #endregion
    }
}