
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

public partial class PurchaseOrderHeaderEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "PurchaseOrderHeaderEdit.aspx?{0}", PurchaseOrderHeaderDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "PurchaseOrderHeaderEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "PurchaseOrderHeader.aspx");
		FormUtil.SetDefaultMode(FormView1, "PurchaseOrderId");
	}
	protected void GridViewPurchaseOrderDetail1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("PurchaseOrderId={0}&PurchaseOrderDetailId={1}", GridViewPurchaseOrderDetail1.SelectedDataKey.Values[0], GridViewPurchaseOrderDetail1.SelectedDataKey.Values[1]);
		Response.Redirect("PurchaseOrderDetailEdit.aspx?" + urlParams, true);		
	}	
}


