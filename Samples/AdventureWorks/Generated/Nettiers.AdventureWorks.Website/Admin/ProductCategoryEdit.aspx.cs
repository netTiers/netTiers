
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Nettiers.AdventureWorks.Web.UI;
#endregion

public partial class ProductCategoryEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ProductCategoryEdit.aspx?{0}", ProductCategoryDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ProductCategoryEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ProductCategory.aspx");
		FormUtil.SetDefaultMode(FormView1, "ProductCategoryId");
	}
	protected void GridViewProductSubcategory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProductSubcategoryId={0}", GridViewProductSubcategory1.SelectedDataKey.Values[0]);
		Response.Redirect("ProductSubcategoryEdit.aspx?" + urlParams, true);		
	}	
}


