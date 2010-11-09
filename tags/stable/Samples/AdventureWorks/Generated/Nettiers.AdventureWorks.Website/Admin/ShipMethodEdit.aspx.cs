
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

public partial class ShipMethodEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ShipMethodEdit.aspx?{0}", ShipMethodDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ShipMethodEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ShipMethod.aspx");
		FormUtil.SetDefaultMode(FormView1, "ShipMethodId");
	}
	protected void GridViewSalesOrderHeader1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesOrderId={0}", GridViewSalesOrderHeader1.SelectedDataKey.Values[0]);
		Response.Redirect("SalesOrderHeaderEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewPurchaseOrderHeader2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("PurchaseOrderId={0}", GridViewPurchaseOrderHeader2.SelectedDataKey.Values[0]);
		Response.Redirect("PurchaseOrderHeaderEdit.aspx?" + urlParams, true);		
	}	
}


