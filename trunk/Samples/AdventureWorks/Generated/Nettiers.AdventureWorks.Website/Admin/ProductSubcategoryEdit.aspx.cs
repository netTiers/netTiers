
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

public partial class ProductSubcategoryEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ProductSubcategoryEdit.aspx?{0}", ProductSubcategoryDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ProductSubcategoryEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ProductSubcategory.aspx");
		FormUtil.SetDefaultMode(FormView1, "ProductSubcategoryId");
	}
	protected void GridViewProduct1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProductId={0}", GridViewProduct1.SelectedDataKey.Values[0]);
		Response.Redirect("ProductEdit.aspx?" + urlParams, true);		
	}	
}


