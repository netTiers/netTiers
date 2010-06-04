
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

public partial class NullFkeyChildEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "NullFkeyChildEdit.aspx?{0}", NullFkeyChildDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "NullFkeyChildEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "NullFkeyChild.aspx");
		FormUtil.SetDefaultMode(FormView1, "NullFkeyChildId");
	}
}


