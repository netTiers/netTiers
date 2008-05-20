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

using System.Collections.Generic;

using netTiers.Petshop.Entities;

/// <summary>
/// This class exposes custom object datasource access for custom implementations, such as a search provider.
/// It is mostly used by the ObjectDataSource controls embedded in the aspx forms.
/// </summary>
[DataObject]
public class DataWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="T:DataWrapper"/> class.
    /// </summary>
    public DataWrapper()
    {
    }

    /// <summary>
    /// Searches the specified querystring by calling the current SearchService.
    /// Currently using a DotLucene Search Service
    /// <c cref="PetShopSearchService"></c>
    /// </summary>
    /// <param name="queryString">The query string.</param>
    /// <returns></returns>
    public List<ExtendedItem> Search(string queryString)
    {
        return PetShopSearchService.Search(queryString);
    }
}