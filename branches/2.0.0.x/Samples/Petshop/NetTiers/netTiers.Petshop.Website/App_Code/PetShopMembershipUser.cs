using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

/// <summary>
/// Summary description for PetShopMembershipUser
/// Wraps Profile information along with <c>netTiers.Petshop.Entities.Account</c>
/// information for a custom <c>System.Web.Security.MembershipUser</c> class.
/// </summary>
public class PetShopMembershipUser  : System.Web.Security.MembershipUser
{
	protected netTiers.Petshop.Entities.Account m_account;

    #region ctor

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PetShopMembershipUser"/> class.
    /// </summary>
    public PetShopMembershipUser() 
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PetShopMembershipUser"/> class.
    /// </summary>
    /// <param name="account">The account.</param>
	public PetShopMembershipUser(netTiers.Petshop.Entities.Account account)
    {
        this.m_account = account;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets our custom Account entity used to track the membership information.
    /// </summary>
    /// <value>The account.</value>
	public netTiers.Petshop.Entities.Account Account
    {
        get
        {
            return m_account;
        }
    }

    /// <summary>
    /// Gets or sets the name of the first.
    /// </summary>
    /// <value>The name of the first.</value>
    [Bindable(true)]
    [Browsable(true)]
    public string FirstName
    {
        get { return m_account.FirstName; }
        set { m_account.FirstName = value; }
    }

    /// <summary>
    /// Gets or sets the name of the last.
    /// </summary>
    /// <value>The name of the last.</value>
    public string LastName
    {
        get { return m_account.LastName; }
        set { m_account.LastName = value; }
    }

    /// <summary>
    /// Gets the logon name of the membership user.
    /// </summary>
    /// <value></value>
    /// <returns>The logon name of the membership user.</returns>
    public override string UserName
    {
        get
        {
            return m_account.Login;
        }
    }

    /// <summary>
    /// Gets or sets the street address.
    /// </summary>
    /// <value>The street address.</value>
    public string StreetAddress
    {
        get { return m_account.StreetAddress; }
        set { m_account.StreetAddress = value; }
    }

    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <value>The postal code.</value>
    public string PostalCode
    {
        get { return m_account.PostalCode; }
        set { m_account.PostalCode = value; }
    }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    /// <value>The city.</value>
    public string City
    {
        get { return m_account.City; }
        set { m_account.City = value; }
    }

    /// <summary>
    /// Gets or sets the state or province.
    /// </summary>
    /// <value>The state or province.</value>
    public string StateOrProvince
    {
        get { return m_account.StateOrProvince; }
        set { m_account.StateOrProvince = value; }
    }

    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    /// <value>The country.</value>
    public string Country
    {
        get { return m_account.Country; }
        set { m_account.Country = value; }
    }

    /// <summary>
    /// Gets or sets the telephone number.
    /// </summary>
    /// <value>The telephone number.</value>
    public string TelephoneNumber
    {
        get { return m_account.TelephoneNumber; }
        set { m_account.TelephoneNumber = value; }
    }

    /// <summary>
    /// Gets or sets the e-mail address for the membership user.
    /// </summary>
    /// <value></value>
    /// <returns>The e-mail address for the membership user.</returns>
    public override string Email
    {
        get { return m_account.Email; }
        set { m_account.Email = value; }
    }

    /// <summary>
    /// Gets or sets the login.
    /// </summary>
    /// <value>The login.</value>
    public string Login
    {
        get { return m_account.Login; }
        set { m_account.Login = value; }
    }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    /// <value>The password.</value>
    public string Password
    {
        get { return m_account.Password; }
        set { m_account.Password = value; }
    }

    /// <summary>
    /// Gets or sets the I want my list.
    /// </summary>
    /// <value>The I want my list.</value>
    public System.Nullable<Boolean> IWantMyList
    {
        get { return m_account.IWantMyList; }
        set { m_account.IWantMyList = value; }
    }

    /// <summary>
    /// Gets or sets the I want my pet tips.
    /// </summary>
    /// <value>The I want my pet tips.</value>
    public System.Nullable<Boolean> IWantMyPetTips
    {
        get { return m_account.IWantPetTips; }
        set { m_account.IWantPetTips = value; }
    }

    /// <summary>
    /// Gets or sets the favorite language.
    /// </summary>
    /// <value>The favorite language.</value>
    public string FavoriteLanguage
    {
        get { return m_account.FavoriteLanguage; }
        set { m_account.FavoriteLanguage = value; }
    }

    /// <summary>
    /// Gets or sets the credit card id.
    /// </summary>
    /// <value>The credit card id.</value>
    public string CreditCardId
    {
        get { return m_account.CreditCardId; }
        set { m_account.CreditCardId = value; }
    }

    /// <summary>
    /// Gets or sets the favorite category id.
    /// </summary>
    /// <value>The favorite category id.</value>
    public string FavoriteCategoryId
    {
        get { return m_account.FavoriteCategoryId; }
        set { m_account.FavoriteCategoryId = value; }
    }

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    /// <value>The id.</value>
    public string Id
    {
        get { return m_account.Id; }
        set { m_account.Id = value; }
    }

    /// <summary>
    /// Gets or sets the original id.
    /// </summary>
    /// <value>The original id.</value>
    public string OriginalId
    {
        get { return m_account.OriginalId; }
        set { m_account.OriginalId = value; }
    }

    /// <summary>
    /// Gets or sets the time stamp.
    /// </summary>
    /// <value>The time stamp.</value>
    public byte[] TimeStamp
    {
        get { return m_account.Timestamp; }
        set { m_account.Timestamp = value; }
    }

    #endregion
}
