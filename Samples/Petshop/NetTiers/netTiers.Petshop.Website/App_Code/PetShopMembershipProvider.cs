using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Services;

/// <summary>
/// Summary description for PetshopMembershipProvider
/// </summary>
public class PetShopMemberShipProvider : System.Web.Security.MembershipProvider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="T:PetShopMemberShipProvider"/> class.
    /// </summary>
    public PetShopMemberShipProvider()
    {
    }

    #region Init Custom PetshopMembershipProvider
    /// <summary>
    /// Initializes the provider.
    /// </summary>
    /// <param name="name">The friendly name of the provider.</param>
    /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
    /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
    /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
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
    #endregion 

    /// <summary>
    /// Use a single <c cref="AccountService"></c> Object since we 
    /// won't be requiring the use of the service as a pipeline
    /// </summary>
    private static AccountService accountService = new AccountService();
    
    /// <summary>
    /// Gets or sets the account service.  
    /// </summary>
    /// <value>The account service.</value>
    public AccountService AccountService
    {
        get { return accountService; }
        set { accountService = value; }
    }


    /// <summary>
    /// Adds a new membership user to the data source.
    /// </summary>
    /// <param name="username">The user name for the new user.</param>
    /// <param name="password">The password for the new user.</param>
    /// <param name="email">The e-mail address for the new user.</param>
    /// <param name="passwordQuestion">The password question for the new user.</param>
    /// <param name="passwordAnswer">The password answer for the new user</param>
    /// <param name="isApproved">Whether or not the new user is approved to be validated.</param>
    /// <param name="providerUserKey">The unique identifier from the membership data source for the user.</param>
    /// <param name="status">A <see cref="T:System.Web.Security.MembershipCreateStatus"></see> enumeration value indicating whether the user was created successfully.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Security.MembershipUser"></see> object populated with the information for the newly created user.
    /// </returns>
    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
        //There are a several ways to create objects;
        //Each offer their own benefits in certain situations.
        
        /* Method 1 */
        //create objects directly using default ctor.
        //Account account = new Account();
        
        /* Method 2 */
        //create through a factory, where you can attach to events and add custom logic if needed.
        //if a dev implements IEntityCacheItem, then the object will be cached upon creation.
        //Account account = EntityFactory.Create("Account");

        
        //account.Id = Guid.NewGuid().ToString();
        //account.Email = email;
        //account.Password = password; 
        
        /* Method 3 */
        // Static Creational Method on the entity itself.
        
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
            , null);
        
        try
        {
            AccountService.Save(account);
            status = MembershipCreateStatus.Success;
        }
        catch
        {
            status = MembershipCreateStatus.InvalidUserName;
        }
        
        //Wrap our account user to the custom PetshopMembershipUser 
        //This allows us to use Microsoft's Membership Capabilities, but 
        //have us maintain our own capabilities as to what we want our user to 
        //have available.
        PetShopMembershipUser myMembershipUser = new PetShopMembershipUser(account);
        
        return myMembershipUser;
    }

    /// <summary>
    /// Gets information from the data source for a user. Provides an option to update the last-activity date/time stamp for the user.
    /// </summary>
    /// <param name="username">The name of the user to get information for.</param>
    /// <param name="userIsOnline">true to update the last-activity date/time stamp for the user; false to return user information without updating the last-activity date/time stamp for the user.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Security.MembershipUser"></see> object populated with the specified user's information from the data source.
    /// </returns>
    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
		Account account = AccountService.GetByLogin(username);
        
        PetShopMembershipUser memberShipUser = null;
        //wrap our account user to the custom PetshopMembershipUser 
        //This allows us to use Microsoft's Membership Capabilities, but 
        //have us maintain our own capabilities as to what we want our user to 
        //have available.
        if (account != null)
        {
            memberShipUser = new PetShopMembershipUser(account);
        }
        return memberShipUser;
    }


    /// <summary>
    /// Updates information about a user in the data source.
    /// </summary>
    /// <param name="user">A <see cref="T:System.Web.Security.MembershipUser"></see> object that represents the user to update and the updated information for the user.</param>
    public override void UpdateUser(MembershipUser user)
    {
        UpdateUser((PetShopMembershipUser)user);
    }

    /// <summary>
    /// Verifies that the specified user name and password exist in the data source.
    /// </summary>
    /// <param name="username">The name of the user to validate.</param>
    /// <param name="password">The password for the specified user.</param>
    /// <returns>
    /// true if the specified username and password are valid; otherwise, false.
    /// </returns>
    public override bool ValidateUser(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return false;
        
        // You can easily add an index to your Account table that is 
        // contains both columns username and password, and just have the 
        // database do the matching for you.
        // here we chose to maintain the logic for case sensitivity.
        Account account = AccountService.GetByLogin(username);
        if (account != null 
            && account.Password != null 
            && account.Password.Equals(password, StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }
        
        return false;
    }

    #region Update

    /// <summary>
    /// Updates the user.
    /// </summary>
    /// <param name="mmu">The mmu.</param>
    public void UpdateUser(PetShopMembershipUser mmu)
    {
        //Persist Account Profile Information, check if valid
        try
        {
            AccountService.Update(mmu.Account);
        }
        catch(EntityNotValidException exc)
        {
            string err = string.Format("{0}\n{1}", Resources.Messaging.AccountNotValid, mmu.Account.Error);
            
            // You can do something with this error message that 
            // formatted and has the error that has failed.
            // Here i'll make a web friendly message through the 
            // message in my resource file, and add the error
            throw new Exception(err, exc);
        }
    }

    /// <summary>
    /// Updates the user with the supplied information.
    /// </summary>
    /// <param name="firstName">Name of the first.</param>
    /// <param name="lastName">Name of the last.</param>
    /// <param name="email">The email.</param>
    /// <param name="telephoneNumber">The telephone number.</param>
    /// <param name="streetAddress">The street address.</param>
    /// <param name="stateOrProvince">The state or province.</param>
    /// <param name="city">The city.</param>
    /// <param name="postalCode">The postal code.</param>
    /// <param name="country">The country.</param>
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

    /// <summary>
    /// Gets the user as a <c>PetShopMembershipUser</c>.
    /// </summary>
    /// <returns>Membership user typecasted to PetShopMembershipUser</returns>
    public PetShopMembershipUser GetUser()
    {
        PetShopMembershipUser mmu = (PetShopMembershipUser)Membership.GetUser();
        return mmu;
    }

    /// <summary>
    /// Processes a request to update the password for a membership user.
    /// </summary>
    /// <param name="username">The user to update the password for.</param>
    /// <param name="oldPassword">The current password for the specified user.</param>
    /// <param name="newPassword">The new password for the specified user.</param>
    /// <returns>
    /// true if the password was updated successfully; otherwise, false.
    /// </returns>
    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
        PetShopMembershipUser user = GetUser();
        user.Password = newPassword;
        UpdateUser(user);
        return true;
    }
    #endregion

    #region Properties

    private string m_ApplicationName;
    /// <summary>
    /// The name of the application using the custom membership provider.
    /// </summary>
    /// <value></value>
    /// <returns>The name of the application using the custom membership provider.</returns>
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
    /// <summary>
    /// Indicates whether the membership provider is configured to allow users to reset their passwords.
    /// </summary>
    /// <value></value>
    /// <returns>true if the membership provider supports password reset; otherwise, false. The default is true.</returns>
    public override bool EnablePasswordReset
    {
        get { return enablePasswordReset; }
    }

    private bool enablePasswordRetrieval;
    /// <summary>
    /// Indicates whether the membership provider is configured to allow users to retrieve their passwords.
    /// </summary>
    /// <value></value>
    /// <returns>true if the membership provider is configured to support password retrieval; otherwise, false. The default is false.</returns>
    public override bool EnablePasswordRetrieval
    {
        get { return enablePasswordRetrieval; }
    }

    private int maxInvalidPasswordAttemps;
    /// <summary>
    /// Gets the number of invalid password or password-answer attempts allowed before the membership user is locked out.
    /// </summary>
    /// <value></value>
    /// <returns>The number of invalid password or password-answer attempts allowed before the membership user is locked out.</returns>
    public override int MaxInvalidPasswordAttempts
    {
        get { return maxInvalidPasswordAttemps; }
    }

    private int minRequieredNonAlphanumericCharacters;
    /// <summary>
    /// Gets the minimum number of special characters that must be present in a valid password.
    /// </summary>
    /// <value></value>
    /// <returns>The minimum number of special characters that must be present in a valid password.</returns>
    public override int MinRequiredNonAlphanumericCharacters
    {
        get { return minRequieredNonAlphanumericCharacters; }
    }

    private int minRequeriedPasswordLength;
    /// <summary>
    /// Gets the minimum length required for a password.
    /// </summary>
    /// <value></value>
    /// <returns>The minimum length required for a password. </returns>
    public override int MinRequiredPasswordLength
    {
        get { return minRequeriedPasswordLength; }
    }

    private int passwordAttemptWindow;
    /// <summary>
    /// Gets the number of minutes in which a maximum number of invalid password or password-answer attempts are allowed before the membership user is locked out.
    /// </summary>
    /// <value></value>
    /// <returns>The number of minutes in which a maximum number of invalid password or password-answer attempts are allowed before the membership user is locked out.</returns>
    public override int PasswordAttemptWindow
    {
        get { return passwordAttemptWindow; }
    }

    private MembershipPasswordFormat passwordFormat;
    /// <summary>
    /// Gets a value indicating the format for storing passwords in the membership data store.
    /// </summary>
    /// <value></value>
    /// <returns>One of the <see cref="T:System.Web.Security.MembershipPasswordFormat"></see> values indicating the format for storing passwords in the data store.</returns>
    public override MembershipPasswordFormat PasswordFormat
    {
        get { return passwordFormat; }
    }

    private string passwordStrengthRegularExpression;
    /// <summary>
    /// Gets the regular expression used to evaluate a password.
    /// </summary>
    /// <value></value>
    /// <returns>A regular expression used to evaluate a password.</returns>
    public override string PasswordStrengthRegularExpression
    {
        get { return passwordStrengthRegularExpression; }
    }

    private bool requiresQuestionAndAnswer;
    /// <summary>
    /// Gets a value indicating whether the membership provider is configured to require the user to answer a password question for password reset and retrieval.
    /// </summary>
    /// <value></value>
    /// <returns>true if a password answer is required for password reset and retrieval; otherwise, false. The default is true.</returns>
    public override bool RequiresQuestionAndAnswer
    {
        get { return requiresQuestionAndAnswer; }
    }

    private bool requiresUniqueEmail;
    /// <summary>
    /// Gets a value indicating whether the membership provider is configured to require a unique e-mail address for each user name.
    /// </summary>
    /// <value></value>
    /// <returns>true if the membership provider requires a unique e-mail address; otherwise, false. The default is true.</returns>
    public override bool RequiresUniqueEmail
    {
        get { return requiresUniqueEmail; }
    }

    #endregion
    
    #region NotImplemented Membership Methods

    /// <summary>
    /// Processes a request to update the password question and answer for a membership user.
    /// </summary>
    /// <param name="username">The user to change the password question and answer for.</param>
    /// <param name="password">The password for the specified user.</param>
    /// <param name="newPasswordQuestion">The new password question for the specified user.</param>
    /// <param name="newPasswordAnswer">The new password answer for the specified user.</param>
    /// <returns>
    /// true if the password question and answer are updated successfully; otherwise, false.
    /// </returns>
    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Removes a user from the membership data source.
    /// </summary>
    /// <param name="username">The name of the user to delete.</param>
    /// <param name="deleteAllRelatedData">true to delete data related to the user from the database; false to leave data related to the user in the database.</param>
    /// <returns>
    /// true if the user was successfully deleted; otherwise, false.
    /// </returns>
    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Gets a collection of membership users where the e-mail address contains the specified e-mail address to match.
    /// </summary>
    /// <param name="emailToMatch">The e-mail address to search for.</param>
    /// <param name="pageIndex">The index of the page of results to return. pageIndex is zero-based.</param>
    /// <param name="pageSize">The size of the page of results to return.</param>
    /// <param name="totalRecords">The total number of matched users.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Security.MembershipUserCollection"></see> collection that contains a page of pageSize<see cref="T:System.Web.Security.MembershipUser"></see> objects beginning at the page specified by pageIndex.
    /// </returns>
    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Gets a collection of membership users where the user name contains the specified user name to match.
    /// </summary>
    /// <param name="usernameToMatch">The user name to search for.</param>
    /// <param name="pageIndex">The index of the page of results to return. pageIndex is zero-based.</param>
    /// <param name="pageSize">The size of the page of results to return.</param>
    /// <param name="totalRecords">The total number of matched users.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Security.MembershipUserCollection"></see> collection that contains a page of pageSize<see cref="T:System.Web.Security.MembershipUser"></see> objects beginning at the page specified by pageIndex.
    /// </returns>
    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Gets a collection of all the users in the data source in pages of data.
    /// </summary>
    /// <param name="pageIndex">The index of the page of results to return. pageIndex is zero-based.</param>
    /// <param name="pageSize">The size of the page of results to return.</param>
    /// <param name="totalRecords">The total number of matched users.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Security.MembershipUserCollection"></see> collection that contains a page of pageSize<see cref="T:System.Web.Security.MembershipUser"></see> objects beginning at the page specified by pageIndex.
    /// </returns>
    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Gets the number of users currently accessing the application.
    /// </summary>
    /// <returns>
    /// The number of users currently accessing the application.
    /// </returns>
    public override int GetNumberOfUsersOnline()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Gets the password for the specified user name from the data source.
    /// </summary>
    /// <param name="username">The user to retrieve the password for.</param>
    /// <param name="answer">The password answer for the user.</param>
    /// <returns>
    /// The password for the specified user name.
    /// </returns>
    public override string GetPassword(string username, string answer)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Gets information from the data source for a user based on the unique identifier for the membership user. Provides an option to update the last-activity date/time stamp for the user.
    /// </summary>
    /// <param name="providerUserKey">The unique identifier for the membership user to get information for.</param>
    /// <param name="userIsOnline">true to update the last-activity date/time stamp for the user; false to return user information without updating the last-activity date/time stamp for the user.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Security.MembershipUser"></see> object populated with the specified user's information from the data source.
    /// </returns>
    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        return null;
    }

    /// <summary>
    /// Gets the user name associated with the specified e-mail address.
    /// </summary>
    /// <param name="email">The e-mail address to search for.</param>
    /// <returns>
    /// The user name associated with the specified e-mail address. If no match is found, return null.
    /// </returns>
    public override string GetUserNameByEmail(string email)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Resets a user's password to a new, automatically generated password.
    /// </summary>
    /// <param name="username">The user to reset the password for.</param>
    /// <param name="answer">The password answer for the specified user.</param>
    /// <returns>The new password for the specified user.</returns>
    public override string ResetPassword(string username, string answer)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Clears a lock so that the membership user can be validated.
    /// </summary>
    /// <param name="userName">The membership user to clear the lock status for.</param>
    /// <returns>
    /// true if the membership user was successfully unlocked; otherwise, false.
    /// </returns>
    public override bool UnlockUser(string userName)
    {
        throw new Exception("The method or operation is not implemented.");
    }


    #endregion
}
