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
using netTiers.Petshop.Web.UI;
#endregion

public partial class ItemEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

		if (Request.QueryString["id"] != null)
		{
		}
		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ItemEdit.aspx?id={0}", ItemDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ItemEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Item.aspx");
		FormUtil.SetDefaultMode(FormView1, "id");
	}

}


