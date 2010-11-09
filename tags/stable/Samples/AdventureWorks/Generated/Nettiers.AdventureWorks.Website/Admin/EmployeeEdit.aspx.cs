
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

public partial class EmployeeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "EmployeeEdit.aspx?{0}", EmployeeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "EmployeeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Employee.aspx");
		FormUtil.SetDefaultMode(FormView1, "EmployeeId");
	}
	protected void GridViewEmployee1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("EmployeeId={0}", GridViewEmployee1.SelectedDataKey.Values[0]);
		Response.Redirect("EmployeeEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewJobCandidate2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("JobCandidateId={0}", GridViewJobCandidate2.SelectedDataKey.Values[0]);
		Response.Redirect("JobCandidateEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewEmployeePayHistory3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("EmployeeId={0}&RateChangeDate={1}", GridViewEmployeePayHistory3.SelectedDataKey.Values[0], GridViewEmployeePayHistory3.SelectedDataKey.Values[1]);
		Response.Redirect("EmployeePayHistoryEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewPurchaseOrderHeader4_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("PurchaseOrderId={0}", GridViewPurchaseOrderHeader4.SelectedDataKey.Values[0]);
		Response.Redirect("PurchaseOrderHeaderEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewEmployeeDepartmentHistory5_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("EmployeeId={0}&StartDate={1}&DepartmentId={2}&ShiftId={3}", GridViewEmployeeDepartmentHistory5.SelectedDataKey.Values[0], GridViewEmployeeDepartmentHistory5.SelectedDataKey.Values[1], GridViewEmployeeDepartmentHistory5.SelectedDataKey.Values[2], GridViewEmployeeDepartmentHistory5.SelectedDataKey.Values[3]);
		Response.Redirect("EmployeeDepartmentHistoryEdit.aspx?" + urlParams, true);		
	}	
}


