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

using netTiers.Petshop.Entities;
using netTiers.Petshop.Services;


/// <summary>
/// Summary description for ProfileProvider
/// </summary>
public class PetShopProfileProvider : System.Web.Profile.ProfileProvider
{
    public PetShopProfileProvider()
    {
    }

    /// <summary>
    /// Use a single <c cref="AccountService"></c> Object since we 
    /// won't be requiring the use of the service as a pipeline
    /// </summary>
    private static AccountService accountService = new AccountService();
    
    /// <summary>
    /// Gets the account service used to get data.  
    /// </summary>
    /// <value>The account service.</value>
    public AccountService AccountService
    {
        get { return accountService; }
    }

    #region Initialize Custom Petshop Profile Provider
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
        this.ApplicationName = (config["ApplicationName"] == null) ? "PetShop" : config["ApplicationName"];
    }
    #endregion 
    
    private string applicationName;
    
    /// <summary>
    /// Gets or sets the name of the currently running application.
    /// </summary>
    /// <value></value>
    /// <returns>A <see cref="T:System.String"></see> that contains the application's shortened name, which does not contain a full path or extension, for example, SimpleAppSettings.</returns>
    public override string ApplicationName
    {
        get
        {
            return applicationName;
        }
        set
        {
            applicationName = value;
        }
    }

    /// <summary>
    /// Returns the collection of settings property values for the specified application instance and settings property group.
    /// </summary>
    /// <param name="context">A <see cref="T:System.Configuration.SettingsContext"></see> describing the current application use.</param>
    /// <param name="collection">A <see cref="T:System.Configuration.SettingsPropertyCollection"></see> containing the settings property group whose values are to be retrieved.</param>
    /// <returns>
    /// A <see cref="T:System.Configuration.SettingsPropertyValueCollection"></see> containing the values for the specified settings property group.
    /// </returns>
    public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
    {
        // Do not get values for anonymous users
        System.Configuration.SettingsPropertyValueCollection result 
            = new System.Configuration.SettingsPropertyValueCollection();
        
        TypeConverter typeConverter;
        object value;

        string userName = (string)context["UserName"];

        Account account = null;

        //Get the current account entity from the database.
        //based on the userId
        if (System.Web.HttpContext.Current.Request.IsAuthenticated)
        {
            account = AccountService.GetByLogin(userName);
        }

        if (collection.Count > 0)
        {
            foreach (System.Configuration.SettingsProperty property in collection)
            {
                System.Configuration.SettingsPropertyValue propertyValue = new System.Configuration.SettingsPropertyValue(property);

                typeConverter = TypeDescriptor.GetConverter(propertyValue.PropertyValue);

                if (System.Web.HttpContext.Current.Request.IsAuthenticated)
                {
                    System.Reflection.PropertyInfo pi = account.GetType().GetProperty(property.Name);
                    object o = pi.GetValue(account, null);
                    
                    if (o == "null")
                    {
                        value = null;
                    }
                    else if (o != null)
                    {
                        value = o;
                    }
                    else
                    {
                        value = typeConverter.ConvertFrom(property.DefaultValue);
                    }
                }
                else
                {
                    value = typeConverter.ConvertFrom(property.DefaultValue);
                }

                propertyValue.PropertyValue = value;
                propertyValue.IsDirty = true;
                result.Add(propertyValue);
            }
        }
        return result;
    }



    /// <summary>
    /// Sets the values of the specified group of property settings.
    /// </summary>
    /// <param name="context">A <see cref="T:System.Configuration.SettingsContext"></see> describing the current application usage.</param>
    /// <param name="collection">A <see cref="T:System.Configuration.SettingsPropertyValueCollection"></see> representing the group of property settings to set.</param>
    public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
    {
        string userName = (string) context["UserName"];
        
        // Dynamically set all the properties of the entity based on the profile configured values.
        // Get infos form dataBase if is authenticated
        if (System.Web.HttpContext.Current.Request.IsAuthenticated)
        {
            Account account = AccountService.GetByLogin(userName);
            foreach (System.Configuration.SettingsPropertyValue propertyValue in collection)
            {
                System.Configuration.SettingsProperty property = new System.Configuration.SettingsProperty(propertyValue.Name);

                System.Reflection.PropertyInfo pi = account.GetType().GetProperty(property.Name);
                if (propertyValue.PropertyValue == "null")
                    propertyValue.PropertyValue = null;
                pi.SetValue(account, propertyValue.PropertyValue, null);
            }
            
            //Persist Account Profile Information, check if valid
            try
            {
                AccountService.Update(account);
            }
            catch(EntityNotValidException exc)
            {
                string err = string.Format("{0}\n{1}", Resources.Messaging.AccountNotValid, account.Error);
                // You can do something with this error message that formatted and has the error that has failed.
            }
        }
        else
        {
            foreach (System.Configuration.SettingsPropertyValue propertyValue in collection)
            {
                System.Configuration.SettingsProperty property = new System.Configuration.SettingsProperty(propertyValue.Name);
                property.DefaultValue = propertyValue.PropertyValue;
            }
        }
    }
    
    #region NotImplemented
    /// <summary>
    /// When overridden in a derived class, deletes all user-profile data for profiles in which the last activity date occurred before the specified date.
    /// </summary>
    /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"></see> values, specifying whether anonymous, authenticated, or both types of profiles are deleted.</param>
    /// <param name="userInactiveSinceDate">A <see cref="T:System.DateTime"></see> that identifies which user profiles are considered inactive. If the <see cref="P:System.Web.Profile.ProfileInfo.LastActivityDate"></see>  value of a user profile occurs on or before this date and time, the profile is considered inactive.</param>
    /// <returns>
    /// The number of profiles deleted from the data source.
    /// </returns>
    public override int DeleteInactiveProfiles(System.Web.Profile.ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// When overridden in a derived class, deletes profile properties and information for profiles that match the supplied list of user names.
    /// </summary>
    /// <param name="usernames">A string array of user names for profiles to be deleted.</param>
    /// <returns>
    /// The number of profiles deleted from the data source.
    /// </returns>
    public override int DeleteProfiles(string[] usernames)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// When overridden in a derived class, deletes profile properties and information for the supplied list of profiles.
    /// </summary>
    /// <param name="profiles">A <see cref="T:System.Web.Profile.ProfileInfoCollection"></see>  of information about profiles that are to be deleted.</param>
    /// <returns>
    /// The number of profiles deleted from the data source.
    /// </returns>
    public override int DeleteProfiles(System.Web.Profile.ProfileInfoCollection profiles)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// When overridden in a derived class, retrieves profile information for profiles in which the last activity date occurred on or before the specified date and the user name matches the specified user name.
    /// </summary>
    /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"></see> values, specifying whether anonymous, authenticated, or both types of profiles are returned.</param>
    /// <param name="usernameToMatch">The user name to search for.</param>
    /// <param name="userInactiveSinceDate">A <see cref="T:System.DateTime"></see> that identifies which user profiles are considered inactive. If the <see cref="P:System.Web.Profile.ProfileInfo.LastActivityDate"></see> value of a user profile occurs on or before this date and time, the profile is considered inactive.</param>
    /// <param name="pageIndex">The index of the page of results to return.</param>
    /// <param name="pageSize">The size of the page of results to return.</param>
    /// <param name="totalRecords">When this method returns, contains the total number of profiles.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Profile.ProfileInfoCollection"></see> containing user profile information for inactive profiles where the user name matches the supplied usernameToMatch parameter.
    /// </returns>
    public override System.Web.Profile.ProfileInfoCollection FindInactiveProfilesByUserName(System.Web.Profile.ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// When overridden in a derived class, retrieves profile information for profiles in which the user name matches the specified user names.
    /// </summary>
    /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"></see> values, specifying whether anonymous, authenticated, or both types of profiles are returned.</param>
    /// <param name="usernameToMatch">The user name to search for.</param>
    /// <param name="pageIndex">The index of the page of results to return.</param>
    /// <param name="pageSize">The size of the page of results to return.</param>
    /// <param name="totalRecords">When this method returns, contains the total number of profiles.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Profile.ProfileInfoCollection"></see> containing user-profile information for profiles where the user name matches the supplied usernameToMatch parameter.
    /// </returns>
    public override System.Web.Profile.ProfileInfoCollection FindProfilesByUserName(System.Web.Profile.ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// When overridden in a derived class, retrieves user-profile data from the data source for profiles in which the last activity date occurred on or before the specified date.
    /// </summary>
    /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"></see> values, specifying whether anonymous, authenticated, or both types of profiles are returned.</param>
    /// <param name="userInactiveSinceDate">A <see cref="T:System.DateTime"></see> that identifies which user profiles are considered inactive. If the <see cref="P:System.Web.Profile.ProfileInfo.LastActivityDate"></see>  of a user profile occurs on or before this date and time, the profile is considered inactive.</param>
    /// <param name="pageIndex">The index of the page of results to return.</param>
    /// <param name="pageSize">The size of the page of results to return.</param>
    /// <param name="totalRecords">When this method returns, contains the total number of profiles.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Profile.ProfileInfoCollection"></see> containing user-profile information about the inactive profiles.
    /// </returns>
    public override System.Web.Profile.ProfileInfoCollection GetAllInactiveProfiles(System.Web.Profile.ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// When overridden in a derived class, retrieves user profile data for all profiles in the data source.
    /// </summary>
    /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"></see> values, specifying whether anonymous, authenticated, or both types of profiles are returned.</param>
    /// <param name="pageIndex">The index of the page of results to return.</param>
    /// <param name="pageSize">The size of the page of results to return.</param>
    /// <param name="totalRecords">When this method returns, contains the total number of profiles.</param>
    /// <returns>
    /// A <see cref="T:System.Web.Profile.ProfileInfoCollection"></see> containing user-profile information for all profiles in the data source.
    /// </returns>
    public override System.Web.Profile.ProfileInfoCollection GetAllProfiles(System.Web.Profile.ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// When overridden in a derived class, returns the number of profiles in which the last activity date occurred on or before the specified date.
    /// </summary>
    /// <param name="authenticationOption">One of the <see cref="T:System.Web.Profile.ProfileAuthenticationOption"></see> values, specifying whether anonymous, authenticated, or both types of profiles are returned.</param>
    /// <param name="userInactiveSinceDate">A <see cref="T:System.DateTime"></see> that identifies which user profiles are considered inactive. If the <see cref="P:System.Web.Profile.ProfileInfo.LastActivityDate"></see>  of a user profile occurs on or before this date and time, the profile is considered inactive.</param>
    /// <returns>
    /// The number of profiles in which the last activity date occurred on or before the specified date.
    /// </returns>
    public override int GetNumberOfInactiveProfiles(System.Web.Profile.ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion
}
