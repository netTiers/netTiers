
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;

namespace netTiers.PetShop.DataAccessLayer.Bases
{
	/// <summary>
	/// Reprensents the strongly typed collection of NetTiersProvider.
	/// </summary>
	public class NetTiersProviderCollection : ProviderCollection
	{
		/// <summary>
	    /// Gets the <see cref="T:NetTiersProvider"/> with the specified name.
	    /// </summary>
	    /// <value></value>
	    public new NetTiersProvider this[string name]
	    {
	        get { return (NetTiersProvider)base[name]; }
	    }
	
		/// <summary>
	    /// Adds the specified provider.
	    /// </summary>
	    /// <param name="provider">The provider.</param>
	    public void Add(NetTiersProvider provider)
	    {
	        if (provider == null)
	        {
	            throw new ArgumentNullException("provider");
	        }
	        if (!(provider is NetTiersProvider))
	        {
	            throw new ArgumentException("Invalid provider type", "provider");
	        }
	        base.Add(provider);
	    }
	}
}
