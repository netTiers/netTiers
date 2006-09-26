using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using netTiers.Petshop.Entities;

namespace NetTiers
{

/// <summary>
/// Shows an example of using a Server Control for the Languages DropDownList.
/// Also shows how to use the Entity Cache even if it's not an entity type.
/// </summary>
public class CultureList : DropDownList
{
    private readonly string cacheKey = "netTiers.Petshop.Web.UI.CultureList";
    /// <summary>
    /// Initializes a new instance of the <see cref="T:CultureList"/> class.
    /// </summary>
    public CultureList()
    {
    }

    /// <summary>
    /// Handles the <see cref="E:System.Web.UI.Control.Init"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        
		this.DataSource=SupportedCultures;
		this.DataValueField = "code"; 
		this.DataTextField = "displayName"; 
        this.DataBind();
        
        this.SelectedIndexChanged +=new EventHandler(CultureList_SelectedIndexChanged);
           
        
        int index = -1;
        for (int i = 0; i < this.Items.Count; i++)
        {
            if (Profile == null) break;
            
            string lang = Profile.GetPropertyValue("FavoriteLanguage") as string;
            
            if (this.Items[i].Value == lang)
            {
                index = i;
            }
        }
        if (index >= 0)
            this.SelectedIndex = index;

    }
    
    

    /// <summary>
    /// Handles the SelectedIndexChanged event of the CultureList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    void CultureList_SelectedIndexChanged(object sender, EventArgs e)
    {
           if (!this.Page.IsPostBack)
                return;
            
		string culture = this.SelectedValue;

        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture= new System.Globalization.CultureInfo(culture);

		if (Profile.GetPropertyValue("FavoriteLanguage") != null)
		     Profile.SetPropertyValue("FavoriteLanguage", culture);
        
        Profile.Save();
    }

    /// <summary>
    /// Gets the members profile.profile.GetPropertyValue("Culture") as string;
    /// </summary>
    /// <value>The profile.</value>
    private ProfileBase Profile
    {
        get
        {
            if (HttpContext.Current == null) 
                return null;
            
            ProfileBase profile = HttpContext.Current.Profile;
            return profile;          
        }
    }
  
    
    /// <summary>
    /// Gets or sets the supported cultures for this website.
    /// They are found in the App_Data/SupportedCultures.xml file.
    /// </summary>
    /// <value>The supported cultures.</value>
    public DataSet SupportedCultures
    {
        get
        {
            
            EntityCache.ConfigurationFile = this.Page.Server.MapPath("~/entlib.config");
            DataSet ds = EntityCache.GetItem<DataSet>(cacheKey);
            if (ds == null)
            {
            	ds = new DataSet("supportedCultures");
            
				string sPath = this.MapPathSecure("~/App_Data/");
				ds.ReadXml(sPath + "SupportedCultures.xml");
                EntityCache.AddCache(cacheKey, ds);
            }
            return ds;
        }
        set {  EntityCache.AddCache(cacheKey, value); }
    }
  }
}