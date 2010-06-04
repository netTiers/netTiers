
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

public partial class CurrencyRateEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CurrencyRateEdit.aspx?{0}", CurrencyRateDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CurrencyRateEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CurrencyRate.aspx");
		FormUtil.SetDefaultMode(FormView1, "CurrencyRateId");
	}
	protected void GridViewSalesOrderHeader1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesOrderId={0}", GridViewSalesOrderHeader1.SelectedDataKey.Values[0]);
		Response.Redirect("SalesOrderHeaderEdit.aspx?" + urlParams, true);		
	}	
}


