
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

public partial class LocationEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "LocationEdit.aspx?{0}", LocationDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "LocationEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Location.aspx");
		FormUtil.SetDefaultMode(FormView1, "LocationId");
	}
	protected void GridViewWorkOrderRouting1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("WorkOrderId={0}&ProductId={1}&OperationSequence={2}", GridViewWorkOrderRouting1.SelectedDataKey.Values[0], GridViewWorkOrderRouting1.SelectedDataKey.Values[1], GridViewWorkOrderRouting1.SelectedDataKey.Values[2]);
		Response.Redirect("WorkOrderRoutingEdit.aspx?" + urlParams, true);		
	}	
}


