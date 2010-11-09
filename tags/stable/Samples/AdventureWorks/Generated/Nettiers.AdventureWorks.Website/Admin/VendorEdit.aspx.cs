
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

public partial class VendorEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "VendorEdit.aspx?{0}", VendorDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "VendorEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Vendor.aspx");
		FormUtil.SetDefaultMode(FormView1, "VendorId");
	}
	protected void GridViewPurchaseOrderHeader1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("PurchaseOrderId={0}", GridViewPurchaseOrderHeader1.SelectedDataKey.Values[0]);
		Response.Redirect("PurchaseOrderHeaderEdit.aspx?" + urlParams, true);		
	}	
}


