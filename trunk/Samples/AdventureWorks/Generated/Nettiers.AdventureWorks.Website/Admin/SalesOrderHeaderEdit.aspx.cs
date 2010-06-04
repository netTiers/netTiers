
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

public partial class SalesOrderHeaderEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "SalesOrderHeaderEdit.aspx?{0}", SalesOrderHeaderDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "SalesOrderHeaderEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "SalesOrderHeader.aspx");
		FormUtil.SetDefaultMode(FormView1, "SalesOrderId");
	}
	protected void GridViewSalesOrderDetail1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesOrderId={0}&SalesOrderDetailId={1}", GridViewSalesOrderDetail1.SelectedDataKey.Values[0], GridViewSalesOrderDetail1.SelectedDataKey.Values[1]);
		Response.Redirect("SalesOrderDetailEdit.aspx?" + urlParams, true);		
	}	
}


