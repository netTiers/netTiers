using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using PetShop.Business;
using PetShop.Services;

namespace PetShop.Controls
{
    /// <summary>
    /// Collection of utility methods for web tier
    /// </summary>
    public static class WebUtility
    {
        private const string CATEGORY_NAME_KEY = "category_name_{0}";
        private const string PRODUCT_NAME_KEY = "product_name_{0}";
        private const string REDIRECT_URL = "~/Search.aspx?keywords={0}";
        private static readonly bool enableCaching = bool.Parse(ConfigurationManager.AppSettings["EnableCaching"]);

        /// <summary>
        /// Method to make sure that user's inputs are not malicious
        /// </summary>
        /// <param name="text">User's Input</param>
        /// <param name="maxLength">Maximum length of input</param>
        /// <returns>The cleaned up version of the input</returns>
        public static string InputText(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " "); //two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n"); //<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " "); //&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty); //any other tags
            text = text.Replace("'", "''");
            return text;
        }

        /// <summary>
        /// Method to check whether input has other characters than numbers
        /// </summary>
        public static string CleanNonWord(string text)
        {
            return Regex.Replace(text, "\\W", "");
        }

        /// <summary>
        /// Method to redirect user to search page
        /// </summary>
        /// <param name="key">Search keyword</param> 
        public static void SearchRedirect(string key)
        {
            HttpContext.Current.Response.Redirect(string.Format(REDIRECT_URL, InputText(key, 255)));
        }

        /// <summary>
        /// Method to retrieve and cache category name by its ID
        /// </summary>
        /// <param name="categoryId">Category id</param>
        /// <returns>Category name</returns>
        public static string GetCategoryName(string categoryId)
        {
            var categoryService = new CategoryService();
            //CategoryService 
            if (!enableCaching)
                return categoryService.GetByCategoryId(categoryId).Name;

            string cacheKey = string.Format(CATEGORY_NAME_KEY, categoryId);

            // Check if the data exists in the data cache
            var data = (string) HttpRuntime.Cache[cacheKey];
            if (data == null)
            {
                // Caching duration from Web.config
                int cacheDuration = int.Parse(ConfigurationManager.AppSettings["CategoryCacheDuration"]);

                // If the data is not in the cache then fetch the data from the business logic tier
                data = categoryService.GetByCategoryId(categoryId).Name;

                // Store the output in the data cache, and Add the necessary AggregateCacheDependency object
                HttpRuntime.Cache.Add(cacheKey, data, null, DateTime.Now.AddHours(cacheDuration),
                                      Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }

            return data;
        }

        /// <summary>
        /// Method to retrieve and cache product name by its ID
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>Product name</returns>
        public static string GetProductName(string productId)
        {
            var productService = new ProductService();
            if (!enableCaching)
                return productService.GetByProductId(productId).Name;

            string cacheKey = string.Format(PRODUCT_NAME_KEY, productId);

            // Check if the data exists in the data cache
            var data = (string) HttpRuntime.Cache[cacheKey];

            if (data == null)
            {
                // Caching duration from Web.config
                int cacheDuration = int.Parse(ConfigurationManager.AppSettings["ProductCacheDuration"]);

                // If the data is not in the cache then fetch the data from the business logic tier
                data = productService.GetByProductId(productId).Name;

                // Store the output in the data cache, and Add the necessary AggregateCacheDependency object
                HttpRuntime.Cache.Add(cacheKey, data, null, DateTime.Now.AddHours(cacheDuration),
                                      Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }

            return data;
        }
    }
}