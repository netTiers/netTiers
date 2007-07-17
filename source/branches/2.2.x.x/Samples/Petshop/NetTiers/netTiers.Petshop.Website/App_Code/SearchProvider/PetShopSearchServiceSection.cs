using System;
using System.Configuration;

public class PetShopSearchServiceSection : ConfigurationSection
{
    [ConfigurationProperty("providers")]
    public ProviderSettingsCollection Providers
    {
        get { return (ProviderSettingsCollection) base["providers"]; }
    }

    [StringValidator(MinLength = 1)]
    [ConfigurationProperty("defaultProvider", DefaultValue = "LucenePetShopSearchProvider")]
    public string DefaultProvider
    {
        get { return (string) base["defaultProvider"]; }
        set { base["defaultProvider"] = value; }
    }
}


