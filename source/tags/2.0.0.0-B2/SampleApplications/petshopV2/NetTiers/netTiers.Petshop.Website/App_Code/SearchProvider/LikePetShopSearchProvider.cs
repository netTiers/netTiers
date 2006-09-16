using System;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for PetShopSearchProvider
/// </summary>
public class LikePetShopSearchProvider : PetShopSearchProvider
{
    
    /// <summary>
    /// Initializes a new instance of the <see cref="T:LucenePetShopSearchProvider"/> class.
    /// </summary>
    public LikePetShopSearchProvider()
    {
        
    }

	public override List<netTiers.Petshop.Entities.ExtendedItem> Search(string queryString)
    {
		List<netTiers.Petshop.Entities.ExtendedItem> results = new List<netTiers.Petshop.Entities.ExtendedItem>();
		foreach (netTiers.Petshop.Entities.ExtendedItem item in netTiers.Petshop.Data.DataRepository.ExtendedItemProvider.Get(string.Format("ItemName like '%{0}%' or ItemDescription like '%{0}%'", queryString), string.Empty))
        {
            results.Add(item);
        }
        return results;
    }
}
