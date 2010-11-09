
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

public partial class CurrencyEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CurrencyEdit.aspx?{0}", CurrencyDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CurrencyEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Currency.aspx");
		FormUtil.SetDefaultMode(FormView1, "CurrencyCode");
	}
	protected void GridViewCurrencyRate1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CurrencyRateId={0}", GridViewCurrencyRate1.SelectedDataKey.Values[0]);
		Response.Redirect("CurrencyRateEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewCurrencyRate2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CurrencyRateId={0}", GridViewCurrencyRate2.SelectedDataKey.Values[0]);
		Response.Redirect("CurrencyRateEdit.aspx?" + urlParams, true);		
	}	
}


