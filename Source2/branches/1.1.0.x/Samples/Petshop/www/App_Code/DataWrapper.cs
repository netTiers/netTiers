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

using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;

/// <summary>
/// This class exposes all the business logic and data acces methods.
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
    /// Gets all the categories and sort them alphabetically.
    /// </summary>
    /// <returns></returns>
    public TList<Category> GetAllCategories()
    {
        TList<Category> categories = DataRepository.CategoryProvider.GetAll();
	categories.Sort(delegate(Category o1, Category o2) { return o1.Name.CompareTo(o2.Name); });
        return categories;
    }
    
    /// <summary>
    /// Gets the category from its id, with the sub Product Collection filled.
    /// </summary>
    /// <param name="categoryId">The category unique identifier.</param>
    /// <returns></returns>
    public Category GetCategoryByCategoryId(string categoryId)
    {
		Category category = DataRepository.CategoryProvider.GetById(categoryId);
		category.ProductCollection = DataRepository.ProductProvider.GetByCategoryId(category.Id);
        return category;
    }

    /// <summary>
    /// Gets a page of <see cref="Product"/>, by category.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="itemsPerPage">The items per page.</param>
    /// <param name="currentPage">The current page.</param>
    /// <param name="itemsCount">The items count.</param>
    /// <returns></returns>
    public TList<Product> GetProductsByCategory(string categoryId, int itemsPerPage, int currentPage, out int itemsCount)
    {
		try
		{
			// the following line will crash if someone try to inject something that is not a guid
			Guid categoryGuid = new Guid(categoryId);
			return DataRepository.ProductProvider.GetPaged(string.Format("CategoryId = '{0}'", categoryGuid), string.Empty, currentPage, itemsPerPage, out itemsCount);
		}
		catch (Exception)
		{
			// may occur if someone try to inject something in a querystring
			// anyway, we just return an empty list
			itemsCount = 0;
			return new TList<Product>();
		}
    }
    
    /// <summary>
    /// Gets a page of <see cref="Item"/> instances, by product.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <param name="itemsPerPage">The items per page.</param>
    /// <param name="currentPage">The current page.</param>
    /// <param name="itemsCount">The items count.</param>
    /// <returns></returns>
    public TList<Item> GetItemsByProduct(string productId, int itemsPerPage, int currentPage, out int itemsCount)
    {
		try
		{
			Guid productGuid = new Guid(productId);
			return DataRepository.ItemProvider.GetPaged(string.Format("ProductId = '{0}'", productGuid), string.Empty, currentPage, itemsPerPage, out itemsCount);
		}
		catch (Exception)
		{
			// may occur if someone try to inject something in a querystring
			// anyway, we just return an empty list
			itemsCount = 0;
			return new TList<Item>();
		}
    }

    /// <summary>
    /// Gets an item.
    /// </summary>
    /// <param name="itemId">The item unique identifier.</param>
    /// <returns></returns>
    public Item GetItemByItemId(string itemId)
    {
        return DataRepository.ItemProvider.GetById(itemId);
    }

    /// <summary>
    /// Gets the product by product id.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public Product GetProductByProductId(string productId)
    {
        return DataRepository.ProductProvider.GetById(productId);
    }

    /// <summary>
    /// Searches the specified querystring by calling the current SearchService.
    /// </summary>
    /// <param name="queryString">The query string.</param>
    /// <returns></returns>
    public List<ExtendedItem> Search(string queryString)
    {
        return PetShopSearchService.Search(queryString);
    }
}
