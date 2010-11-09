
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

public partial class IndividualEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "IndividualEdit.aspx?{0}", IndividualDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "IndividualEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Individual.aspx");
		FormUtil.SetDefaultMode(FormView1, "CustomerId");
	}
}


