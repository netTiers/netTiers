using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration.Provider;
using System.Collections.Generic;

/// <summary>
/// Summary description for PetShopSearchProviderCollection
/// </summary>
public class PetShopSearchProviderCollection : ProviderCollection
{
    public new PetShopSearchProvider this[string name]
    {
        get { return (PetShopSearchProvider)base[name]; }
    }

    public void Add(PetShopSearchProvider provider)
    {
        if (provider == null)
            throw new ArgumentNullException("provider");

        if (!(provider is PetShopSearchProvider))
            throw new ArgumentException
                ("Invalid provider type", "provider");

        base.Add(provider);
    }
}
