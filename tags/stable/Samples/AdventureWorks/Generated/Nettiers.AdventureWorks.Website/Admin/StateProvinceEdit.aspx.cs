
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

public partial class StateProvinceEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "StateProvinceEdit.aspx?{0}", StateProvinceDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "StateProvinceEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "StateProvince.aspx");
		FormUtil.SetDefaultMode(FormView1, "StateProvinceId");
	}
	protected void GridViewAddress1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("AddressId={0}", GridViewAddress1.SelectedDataKey.Values[0]);
		Response.Redirect("AddressEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewSalesTaxRate2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesTaxRateId={0}", GridViewSalesTaxRate2.SelectedDataKey.Values[0]);
		Response.Redirect("SalesTaxRateEdit.aspx?" + urlParams, true);		
	}	
}


