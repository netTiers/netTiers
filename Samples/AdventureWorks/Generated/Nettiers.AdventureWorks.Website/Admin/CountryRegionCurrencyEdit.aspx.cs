
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

public partial class CountryRegionCurrencyEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CountryRegionCurrencyEdit.aspx?{0}", CountryRegionCurrencyDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CountryRegionCurrencyEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CountryRegionCurrency.aspx");
		FormUtil.SetDefaultMode(FormView1, "CountryRegionCode");
	}
}


