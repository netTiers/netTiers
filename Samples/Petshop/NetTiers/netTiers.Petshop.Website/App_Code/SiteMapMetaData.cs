using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using netTiers.Petshop.Entities;
using netTiers.Petshop.Services;

/// <summary>
/// Summary description for SiteMapContainer
/// </summary>
public class SiteMapMetaData
{

    private static CategoryService categoryService = new CategoryService();
    private static ProductService productService = new ProductService();
    private static ItemService itemService = new ItemService();
    
    private TList<Category> categoryList;
    private TList<Item> itemList;
    private TList<Product> productList;


    /// <summary>
    /// Gets the category list.
    /// </summary>
    /// <value>The category list.</value>
    public TList<Category> CategoryList
    {
        get
        {
            if(categoryList == null)
                categoryList = categoryService.GetAll();
            
            return categoryList;
        }
    }


    /// <summary>
    /// Gets the product list.
    /// </summary>
    /// <value>The product list.</value>
    public TList<Product> ProductList
    {
        get
        {
            if(productList == null)
                productList = productService.GetAll();
            
            return productList;
        }
    }



    /// <summary>
    /// Gets the item list.
    /// </summary>
    /// <value>The item list.</value>
    public TList<Item> ItemList
    {
        get
        {
            if(itemList == null)
                itemList = itemService.GetAll();
            
            return itemList;
        }
    }
    
    
    public SiteMapMetaData()
    {
    }
}
