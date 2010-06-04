
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

public partial class ContactEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ContactEdit.aspx?{0}", ContactDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ContactEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Contact.aspx");
		FormUtil.SetDefaultMode(FormView1, "ContactId");
	}
	protected void GridViewEmployee1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("EmployeeId={0}", GridViewEmployee1.SelectedDataKey.Values[0]);
		Response.Redirect("EmployeeEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewSalesOrderHeader2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesOrderId={0}", GridViewSalesOrderHeader2.SelectedDataKey.Values[0]);
		Response.Redirect("SalesOrderHeaderEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewIndividual3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CustomerId={0}", GridViewIndividual3.SelectedDataKey.Values[0]);
		Response.Redirect("IndividualEdit.aspx?" + urlParams, true);		
	}	
}


