
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

public partial class ScrapReasonEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ScrapReasonEdit.aspx?{0}", ScrapReasonDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ScrapReasonEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ScrapReason.aspx");
		FormUtil.SetDefaultMode(FormView1, "ScrapReasonId");
	}
	protected void GridViewWorkOrder1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("WorkOrderId={0}", GridViewWorkOrder1.SelectedDataKey.Values[0]);
		Response.Redirect("WorkOrderEdit.aspx?" + urlParams, true);		
	}	
}


