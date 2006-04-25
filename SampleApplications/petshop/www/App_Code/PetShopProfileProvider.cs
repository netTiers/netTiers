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

using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;


/// <summary>
/// Summary description for ProfileProvider
/// </summary>
public class PetShopProfileProvider : System.Web.Profile.ProfileProvider
{
    public PetShopProfileProvider()
    {
    }

    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
    {
        base.Initialize(name, config);
        this.ApplicationName = (config["ApplicationName"] == null) ? "PetShop" : config["ApplicationName"];
    }

    #region NotImplemented

    public override int DeleteInactiveProfiles(System.Web.Profile.ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override int DeleteProfiles(string[] usernames)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override int DeleteProfiles(System.Web.Profile.ProfileInfoCollection profiles)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override System.Web.Profile.ProfileInfoCollection FindInactiveProfilesByUserName(System.Web.Profile.ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override System.Web.Profile.ProfileInfoCollection FindProfilesByUserName(System.Web.Profile.ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override System.Web.Profile.ProfileInfoCollection GetAllInactiveProfiles(System.Web.Profile.ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override System.Web.Profile.ProfileInfoCollection GetAllProfiles(System.Web.Profile.ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override int GetNumberOfInactiveProfiles(System.Web.Profile.ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    private string applicationName;
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

    public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
    {
        // Do not get values for anonymous users
        System.Configuration.SettingsPropertyValueCollection result = new System.Configuration.SettingsPropertyValueCollection();
        TypeConverter typeConverter;
        object value;

        string userName = (string) context["UserName"];

        Account account = null;

        // Get infos from dataBase
        if (System.Web.HttpContext.Current.Request.IsAuthenticated)
        {
            account = DataRepository.AccountProvider.GetByLogin(userName);
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
                    if (o != null)
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

    public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
    {
        string userName = (string) context["UserName"];

        // Get infos form dataBase if is authenticated
        if (System.Web.HttpContext.Current.Request.IsAuthenticated)
        {
            Account account = DataRepository.AccountProvider.GetByLogin(userName);
            foreach (System.Configuration.SettingsPropertyValue propertyValue in collection)
            {
                System.Configuration.SettingsProperty property = new System.Configuration.SettingsProperty(propertyValue.Name);

                System.Reflection.PropertyInfo pi = account.GetType().GetProperty(property.Name);
                pi.SetValue(account, propertyValue.PropertyValue, null);
            }
            DataRepository.AccountProvider.Update(account);
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
}
