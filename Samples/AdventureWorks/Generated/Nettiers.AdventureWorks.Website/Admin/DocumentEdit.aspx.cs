
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

public partial class DocumentEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DocumentEdit.aspx?{0}", DocumentDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DocumentEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Document.aspx");
		FormUtil.SetDefaultMode(FormView1, "DocumentId");
	}
}


