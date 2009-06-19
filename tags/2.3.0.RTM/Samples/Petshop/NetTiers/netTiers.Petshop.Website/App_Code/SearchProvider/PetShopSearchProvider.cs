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
/// Summary description for PetShopDataProviderBase
/// </summary>
public abstract class PetShopSearchProvider : ProviderBase         
{
	public abstract List<netTiers.Petshop.Entities.ExtendedItem> Search(string queryString);
}




//public class SearchResultItem
//{
//    public string ItemId;
//    public string ItemName;
//    public string ItemDescription;
//    public string ProductId;
//}

//public class SearchResults
//{
//    List<SearchResultItem> list = new List<SearchResultItem>();
//    double executionTime;
//}