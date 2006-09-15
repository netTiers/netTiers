using System;
using System.Drawing;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using System.Collections.Generic;

public class PetShopSearchService
{
    private static PetShopSearchProvider _provider = null;
    private static PetShopSearchProviderCollection _providers = null;
    private static object _lock = new object();

    public PetShopSearchProvider Provider
    {
        get { return _provider; }
    }

    public PetShopSearchProviderCollection Providers
    {
        get { return _providers; }
    }

	public static List<netTiers.PetShop.ExtendedItem> Search(string queryString)
    {
        // Make sure a provider is loaded
        LoadProviders();

        // Delegate to the provider
        return _provider.Search(queryString);
    }
      
   

    private static void LoadProviders()
    {
        // Avoid claiming lock if providers are already loaded
        if (_provider == null)
        {
            lock (_lock)
            {
                // Do this again to make sure _provider is still null
                if (_provider == null)
                {
                    // Get a reference to the <imageService> section
                    PetShopSearchServiceSection section = (PetShopSearchServiceSection)WebConfigurationManager.GetSection("petShopSearchService");

                    // Load registered providers and point _provider
                    // to the default provider
                    _providers = new PetShopSearchProviderCollection();
                    ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(PetShopSearchProvider));
                    _provider = _providers[section.DefaultProvider];

                    if (_provider == null)
                        throw new ProviderException("Unable to load default PetShopSearchService");
                }
            }
        }
    }
}

