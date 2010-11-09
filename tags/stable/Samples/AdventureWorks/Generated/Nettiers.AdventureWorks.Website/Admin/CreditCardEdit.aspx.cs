
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

public partial class CreditCardEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CreditCardEdit.aspx?{0}", CreditCardDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CreditCardEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CreditCard.aspx");
		FormUtil.SetDefaultMode(FormView1, "CreditCardId");
	}
	protected void GridViewSalesOrderHeader1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("SalesOrderId={0}", GridViewSalesOrderHeader1.SelectedDataKey.Values[0]);
		Response.Redirect("SalesOrderHeaderEdit.aspx?" + urlParams, true);		
	}	
}


