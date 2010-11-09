
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

public partial class DepartmentEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DepartmentEdit.aspx?{0}", DepartmentDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DepartmentEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Department.aspx");
		FormUtil.SetDefaultMode(FormView1, "DepartmentId");
	}
	protected void GridViewEmployeeDepartmentHistory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("EmployeeId={0}&StartDate={1}&DepartmentId={2}&ShiftId={3}", GridViewEmployeeDepartmentHistory1.SelectedDataKey.Values[0], GridViewEmployeeDepartmentHistory1.SelectedDataKey.Values[1], GridViewEmployeeDepartmentHistory1.SelectedDataKey.Values[2], GridViewEmployeeDepartmentHistory1.SelectedDataKey.Values[3]);
		Response.Redirect("EmployeeDepartmentHistoryEdit.aspx?" + urlParams, true);		
	}	
}


