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
/// Summary description for MyMemberShipUser
/// </summary>
public class PetShopMembershipUser  : System.Web.Security.MembershipUser
{
	protected netTiers.PetShop.Account m_account;

    #region ctor

    public PetShopMembershipUser() 
    {
    }

	public PetShopMembershipUser(netTiers.PetShop.Account account)
    {
        this.m_account = account;
    }

    #endregion

    #region Properties

	public netTiers.PetShop.Account Account
    {
        get
        {
            return m_account;
        }
    }

    [Bindable(true)]
    [Browsable(true)]
    public string FirstName
    {
        get { return m_account.FirstName; }
        set { m_account.FirstName = value; }
    }

    public string LastName
    {
        get { return m_account.LastName; }
        set { m_account.LastName = value; }
    }

    public override string UserName
    {
        get
        {
            return m_account.Login;
        }
    }

    public string StreetAddress
    {
        get { return m_account.StreetAddress; }
        set { m_account.StreetAddress = value; }
    }

    public string PostalCode
    {
        get { return m_account.PostalCode; }
        set { m_account.PostalCode = value; }
    }

    public string City
    {
        get { return m_account.City; }
        set { m_account.City = value; }
    }

    public string StateOrProvince
    {
        get { return m_account.StateOrProvince; }
        set { m_account.StateOrProvince = value; }
    }

    public string Country
    {
        get { return m_account.Country; }
        set { m_account.Country = value; }
    }

    public string TelephoneNumber
    {
        get { return m_account.TelephoneNumber; }
        set { m_account.TelephoneNumber = value; }
    }

    public override string Email
    {
        get { return m_account.Email; }
        set { m_account.Email = value; }
    }

    public string Login
    {
        get { return m_account.Login; }
        set { m_account.Login = value; }
    }

    public string Password
    {
        get { return m_account.Password; }
        set { m_account.Password = value; }
    }

    public System.Nullable<Boolean> IWantMyList
    {
        get { return m_account.IWantMyList; }
        set { m_account.IWantMyList = value; }
    }

    public System.Nullable<Boolean> IWantMyPetTips
    {
        get { return m_account.IWantPetTips; }
        set { m_account.IWantPetTips = value; }
    }

    public string FavoriteLanguage
    {
        get { return m_account.FavoriteLanguage; }
        set { m_account.FavoriteLanguage = value; }
    }

    public string CreditCardId
    {
        get { return m_account.CreditCardId; }
        set { m_account.CreditCardId = value; }
    }

    public string FavoriteCategoryId
    {
        get { return m_account.FavoriteCategoryId; }
        set { m_account.FavoriteCategoryId = value; }
    }

    public string Id
    {
        get { return m_account.Id; }
        set { m_account.Id = value; }
    }

    public string OriginalId
    {
        get { return m_account.OriginalId; }
        set { m_account.OriginalId = value; }
    }

    public byte[] TimeStamp
    {
        get { return m_account.Timestamp; }
        set { m_account.Timestamp = value; }
    }

    #endregion
}
