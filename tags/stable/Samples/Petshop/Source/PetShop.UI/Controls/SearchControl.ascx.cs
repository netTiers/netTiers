using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetShop.Business;
using PetShop.Services;

namespace PetShop.UI.Controls
{
    public partial class SearchControl : UserControl
    {
        /// <summary>
        /// Rebind control 
        /// </summary>
        protected void PageChanged(object sender, DataGridPageChangedEventArgs e)
        {
            //reset index
            searchList.CurrentPageIndex = e.NewPageIndex;

            //get category id
            string keywordKey = Request.QueryString["keywords"];

            //ProductList list = ProductList.NewList();
            var list = new List<Product>();
            var allProducts = new ProductService().GetAll();
            foreach (Product product in allProducts)
            {
                bool isResult = product.Name.ToLowerInvariant().Contains(keywordKey.ToLowerInvariant()) ||
                                product.Descn.ToLowerInvariant().Contains(keywordKey.ToLowerInvariant());

                if (isResult)
                {
                    list.Add(product);
                }
            }

            //bind data
            searchList.DataSource = list;
            searchList.DataBind();
        }

        /// <summary>
        /// Add cache dependency
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}