
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

public partial class SalesPersonEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "SalesPersonEdit.aspx?{0}", SalesPersonDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "SalesPersonEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "SalesPerson.aspx");
		FormUtil.SetDefaultMode(FormView1, "SalesPersonId");
	}
	protected void GridViewStore1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CustomerId={0}", GridViewStore1.SelectedDataKey.Values[0]);
		Response.Redirect("StoreEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewSalesPersonQuotaHistory2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesPersonId={0}&QuotaDate={1}", GridViewSalesPersonQuotaHistory2.SelectedDataKey.Values[0], GridViewSalesPersonQuotaHistory2.SelectedDataKey.Values[1]);
		Response.Redirect("SalesPersonQuotaHistoryEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewSalesOrderHeader3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesOrderId={0}", GridViewSalesOrderHeader3.SelectedDataKey.Values[0]);
		Response.Redirect("SalesOrderHeaderEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewSalesTerritoryHistory4_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesPersonId={0}&StartDate={1}&TerritoryId={2}", GridViewSalesTerritoryHistory4.SelectedDataKey.Values[0], GridViewSalesTerritoryHistory4.SelectedDataKey.Values[1], GridViewSalesTerritoryHistory4.SelectedDataKey.Values[2]);
		Response.Redirect("SalesTerritoryHistoryEdit.aspx?" + urlParams, true);		
	}	
}


