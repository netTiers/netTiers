
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

public partial class SalesTerritoryEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "SalesTerritoryEdit.aspx?{0}", SalesTerritoryDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "SalesTerritoryEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "SalesTerritory.aspx");
		FormUtil.SetDefaultMode(FormView1, "TerritoryId");
	}
	protected void GridViewStateProvince1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("StateProvinceId={0}", GridViewStateProvince1.SelectedDataKey.Values[0]);
		Response.Redirect("StateProvinceEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewSalesOrderHeader2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesOrderId={0}", GridViewSalesOrderHeader2.SelectedDataKey.Values[0]);
		Response.Redirect("SalesOrderHeaderEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewSalesPerson3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesPersonId={0}", GridViewSalesPerson3.SelectedDataKey.Values[0]);
		Response.Redirect("SalesPersonEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewSalesTerritoryHistory4_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesPersonId={0}&StartDate={1}&TerritoryId={2}", GridViewSalesTerritoryHistory4.SelectedDataKey.Values[0], GridViewSalesTerritoryHistory4.SelectedDataKey.Values[1], GridViewSalesTerritoryHistory4.SelectedDataKey.Values[2]);
		Response.Redirect("SalesTerritoryHistoryEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewCustomer5_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CustomerId={0}", GridViewCustomer5.SelectedDataKey.Values[0]);
		Response.Redirect("CustomerEdit.aspx?" + urlParams, true);		
	}	
}


