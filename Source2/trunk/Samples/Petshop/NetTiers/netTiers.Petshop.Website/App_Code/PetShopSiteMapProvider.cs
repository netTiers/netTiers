using System;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Configuration.Provider;
using System.Security.Permissions;
using System.Data.Common;

using netTiers.Petshop.Entities;


public class PetShopSiteMapProvider : StaticSiteMapProvider
{
    private const string _errmsg1 = "Missing node ID";
    private const string _errmsg2 = "Duplicate node ID";
    private const string _errmsg3 = "Missing parent ID";
    private const string _errmsg4 = "Invalid parent ID";

    private Dictionary<string, SiteMapNode> _nodes = new Dictionary<string, SiteMapNode>(16);    
    private SiteMapNode _root;

    public override void Initialize(string name, NameValueCollection config)
    {
        // Verify that config isn't null
        if (config == null)
            throw new ArgumentNullException("config");

        // Assign the provider a default name if it doesn't have one
        if (String.IsNullOrEmpty(name))
            name = "PetShopSiteMapProvider";

        // Add a default "description" attribute to config if the
        // attribute doesn't exist or is empty
        if (string.IsNullOrEmpty(config["description"]))
        {
            config.Remove("description");
            config.Add("description", "PetShop site map provider");
        }

        // Call the base class's Initialize method
        base.Initialize(name, config);
                

        // In beta 2, SiteMapProvider processes the
        // securityTrimmingEnabled attribute but fails to remove it.
        // Remove it now so we can check for unrecognized
        // configuration attributes.

        if (config["securityTrimmingEnabled"] != null)
            config.Remove("securityTrimmingEnabled");

        // Throw an exception if unrecognized attributes remain
        if (config.Count > 0)
        {
            string attr = config.GetKey(0);
            if (!String.IsNullOrEmpty(attr))
                throw new ProviderException
                    ("Unrecognized attribute: " + attr);
        }

        BuildSiteMap();
    }

    public override SiteMapNode BuildSiteMap()
    {
        lock (this)
        {
            // Return immediately if this method has been called before
            if (_root != null)
                return _root;
                        
            
            _root = new SiteMapNode(this, "000", "~/default.aspx", "Homepage", "homepage");

            SiteMapMetaData data = new SiteMapMetaData();

            foreach (Category category in data.CategoryList)
            {
                SiteMapNode categoryNode = CreateSiteMapNodeFromCategory(category);
                
                data.ProductList.Filter = string.Format("CategoryId = '{0}'", category.Id);
                category.ProductCollection = data.ProductList; 
                
                foreach (Product product in category.ProductCollection)
                {
                    SiteMapNode productNode = CreateSiteMapNodeFromProduct(product);
                    AddNode(productNode, categoryNode);

                    data.ItemList.Filter = string.Format("ProductId = '{0}'", product.Id);
                    product.ItemCollection = data.ItemList;
                    
                    foreach(Item item in product.ItemCollection)
                    {
                        SiteMapNode itemNode = CreateSiteMapNodeFromItem(item);
                        AddNode(itemNode, productNode);
                    }
                 }

                AddNode(categoryNode, _root);
            }
           
            // Return the root SiteMapNode
            return _root;
        }
    }

    protected override SiteMapNode GetRootNodeCore()
    {        
        return _root;
    }
   

    private SiteMapNode CreateSiteMapNodeFromCategory(Category category)
    {
        // Make sure the node ID is unique
        if (_nodes.ContainsKey(category.Id))
            throw new ProviderException(_errmsg2);

        // Get title, URL, description, and roles from the DataReader
        string id = category.Id;
        string title = category.Name;
        string url = string.Format("~/Category.aspx?CategoryId={0}", category.Id);
        string description = category.Name;
        
        /* useless for us */
        string roles = null;
        string[] rolelist = null;
        if (!String.IsNullOrEmpty(roles))
            rolelist = roles.Split(new char[] { ',', ';' }, 512);
        /* end */

        // Create a SiteMapNode
        SiteMapNode node = new SiteMapNode(this, id, url, title, description, rolelist, null, null, null);

        // Record the node in the _nodes dictionary
        _nodes.Add(id, node);

        // Return the node        
        return node;
    }


	private SiteMapNode CreateSiteMapNodeFromProduct(Product product)
    {
        // Make sure the node ID is unique
        if (_nodes.ContainsKey(product.Id))
            throw new ProviderException(_errmsg2);

        // Get title, URL, description, and roles from the DataReader
        string id = product.Id;
        string title = product.Name;
        string url = string.Format("~/Product.aspx?ProductId={0}", product.Id);
        string description = product.Name;

        /* useless for us */
        string roles = null;
        string[] rolelist = null;
        if (!String.IsNullOrEmpty(roles))
            rolelist = roles.Split(new char[] { ',', ';' }, 512);
        /* end */

        // Create a SiteMapNode
        SiteMapNode node = new SiteMapNode(this, id, url, title, description, rolelist, null, null, null);

        // Record the node in the _nodes dictionary
        _nodes.Add(id, node);

        // Return the node        
        return node;
    }

	private SiteMapNode CreateSiteMapNodeFromItem(netTiers.Petshop.Entities.Item item)
    {
        // Make sure the node ID is unique
        if (_nodes.ContainsKey(item.Id))
            throw new ProviderException(_errmsg2);

        // Get title, URL, description, and roles from the DataReader
        string id = item.Id;
        string title = item.Name;
        string url = string.Format("~/Item.aspx?ItemId={0}", item.Id);
        string description = item.Description;

        /* useless for us */
        string roles = null;
        string[] rolelist = null;
        if (!String.IsNullOrEmpty(roles))
            rolelist = roles.Split(new char[] { ',', ';' }, 512);
        /* end */

        // Create a SiteMapNode
        SiteMapNode node = new SiteMapNode(this, id, url, title, description, rolelist, null, null, null);

        // Record the node in the _nodes dictionary
        _nodes.Add(id, node);

        // Return the node        
        return node;
    }
}

