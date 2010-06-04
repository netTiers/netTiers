
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

public partial class ProductModelEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ProductModelEdit.aspx?{0}", ProductModelDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ProductModelEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ProductModel.aspx");
		FormUtil.SetDefaultMode(FormView1, "ProductModelId");
	}
	protected void GridViewProduct1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProductId={0}", GridViewProduct1.SelectedDataKey.Values[0]);
		Response.Redirect("ProductEdit.aspx?" + urlParams, true);		
	}	
}


