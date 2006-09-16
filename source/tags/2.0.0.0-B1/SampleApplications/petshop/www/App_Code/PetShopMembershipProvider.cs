using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;


/// <summary>
/// Summary description for MyMemberShipsProvider
/// </summary>
public class PetShopMemberShipProvider : System.Web.Security.MembershipProvider
{
    public PetShopMemberShipProvider()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
    {
        base.Initialize(name, config);
        if (!string.IsNullOrEmpty(config["enablePasswordRetrieval"]))
        {
            enablePasswordRetrieval = bool.Parse(config["enablePasswordRetrieval"]);
        }
        if (!string.IsNullOrEmpty(config["enablePasswordReset"]))
        {
            enablePasswordReset = bool.Parse(config["enablePasswordReset"]);
        }
        if (!string.IsNullOrEmpty(config["requiresQuestionAndAnswer"]))
        {
            requiresQuestionAndAnswer = bool.Parse(config["requiresQuestionAndAnswer"]);
        }
        if (!string.IsNullOrEmpty(config["requiresUniqueEmail"] ))
        {
            requiresUniqueEmail = bool.Parse(config["requiresUniqueEmail"]);
        }
        if (!string.IsNullOrEmpty(config["passwordFormat"]))
        {
            passwordFormat = (MembershipPasswordFormat) Enum.Parse(typeof(MembershipPasswordFormat),config["passwordFormat"]);
        }

             // maxInvalidPasswordAttempts="5"
             //passwordAttemptWindow="10"
    }

    #region Properties

    private string m_ApplicationName;
    public override string ApplicationName
    {
        get
        {
            return m_ApplicationName;
        }
        set
        {
            m_ApplicationName = value;
        }
    }

    private bool enablePasswordReset;
    public override bool EnablePasswordReset
    {
        get { return enablePasswordReset; }
    }

    private bool enablePasswordRetrieval;
    public override bool EnablePasswordRetrieval
    {
        get { return enablePasswordRetrieval; }
    }

    private int maxInvalidPasswordAttemps;
    public override int MaxInvalidPasswordAttempts
    {
        get { return maxInvalidPasswordAttemps; }
    }

    private int minRequieredNonAlphanumericCharacters;
    public override int MinRequiredNonAlphanumericCharacters
    {
        get { return minRequieredNonAlphanumericCharacters; }
    }

    private int minRequeriedPasswordLength;
    public override int MinRequiredPasswordLength
    {
        get { return minRequeriedPasswordLength; }
    }

    private int passwordAttemptWindow;
    public override int PasswordAttemptWindow
    {
        get { return passwordAttemptWindow; }
    }

    private MembershipPasswordFormat passwordFormat;
    public override MembershipPasswordFormat PasswordFormat
    {
        get { return passwordFormat; }
    }

    private string passwordStrengthRegularExpression;
    public override string PasswordStrengthRegularExpression
    {
        get { return passwordStrengthRegularExpression; }
    }

    private bool requiresQuestionAndAnswer;
    public override bool RequiresQuestionAndAnswer
    {
        get { return requiresQuestionAndAnswer; }
    }

    private bool requiresUniqueEmail;
    public override bool RequiresUniqueEmail
    {
        get { return requiresUniqueEmail; }
    }

    #endregion

    #region NotImplemented

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override int GetNumberOfUsersOnline()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override string GetPassword(string username, string answer)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        return null;
    }

    public override string GetUserNameByEmail(string email)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override string ResetPassword(string username, string answer)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override bool UnlockUser(string userName)
    {
        throw new Exception("The method or operation is not implemented.");
    }


    #endregion

    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
        Account account = Account.CreateAccount(
            Guid.NewGuid().ToString()
            , null
            , null
            , null
            , null
            , null
            , null
            , null
            , null
            , email
            , username
            , password
            , false
            , false
            , null
            , null
            ,null);
        try
        {
            DataRepository.AccountProvider.Save(account);
            status = MembershipCreateStatus.Success;
        }
        catch
        {
            status = MembershipCreateStatus.InvalidUserName;
        }
        PetShopMembershipUser myMembershipUser = new PetShopMembershipUser(account);
        return myMembershipUser;
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
		Account account = DataRepository.AccountProvider.GetByLogin(username);
        PetShopMembershipUser memberShipUser = null;
        if (account != null)
        {
            memberShipUser = new PetShopMembershipUser(account);
        }
        return memberShipUser;
    }


    public override void UpdateUser(MembershipUser user)
    {
        UpdateUser((PetShopMembershipUser)user);
    }

    public override bool ValidateUser(string username, string password)
    {
        Account account = DataRepository.AccountProvider.GetByLogin(username);
 
        if (account != null && account.Password.Equals(password, StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }
        return false;
    }

    #region Update

    public void UpdateUser(PetShopMembershipUser mmu)
    {
        DataRepository.AccountProvider.Update(mmu.Account);
    }

    public void UpdateUser(string firstName, string lastName, string email, string telephoneNumber
        , string streetAddress, string stateOrProvince, string city, string postalCode, string country)
    {
        PetShopMembershipUser user = GetUser();
        user.FirstName = firstName;
        user.LastName = lastName;
        user.Email = email;
        user.TelephoneNumber = telephoneNumber;
        user.StreetAddress = streetAddress;
        user.StateOrProvince = stateOrProvince;
        user.City = city;
        user.PostalCode = postalCode;
        user.Country = country;
        UpdateUser(user);
    }

    public PetShopMembershipUser GetUser()
    {
        PetShopMembershipUser mmu = (PetShopMembershipUser)Membership.GetUser();
        return mmu;
    }

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
        PetShopMembershipUser user = GetUser();
        user.Password = newPassword;
        UpdateUser(user);
        return true;
    }

    #endregion

}
