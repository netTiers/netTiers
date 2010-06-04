
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

public partial class StoreEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "StoreEdit.aspx?{0}", StoreDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "StoreEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Store.aspx");
		FormUtil.SetDefaultMode(FormView1, "CustomerId");
	}
}


