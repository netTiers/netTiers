

#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Nettiers.AdventureWorks.Web.UI;
#endregion

public partial class EmployeeDepartmentHistory : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
		FormUtil.RedirectAfterUpdate(GridView1, "EmployeeDepartmentHistory.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
		FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));
    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("EmployeeId={0}&StartDate={1}&DepartmentId={2}&ShiftId={3}", GridView1.SelectedDataKey.Values[0], GridView1.SelectedDataKey.Values[1], GridView1.SelectedDataKey.Values[2], GridView1.SelectedDataKey.Values[3]);
		Response.Redirect("EmployeeDepartmentHistoryEdit.aspx?" + urlParams, true);
	}
	
}


