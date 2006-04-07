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

public partial class Nightly : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			Button1.Attributes.Add("onclick", "urchinTracker('/fx11_download.html')");
			Button2.Attributes.Add("onclick", "urchinTracker('/fx20_download.html')");
		}
    }
	protected void Button1_Click(object sender, EventArgs e)
	{
		HttpContext.Current.Response.Redirect("nightly/" + DropDownList1.SelectedValue);
	}
	protected void Button2_Click(object sender, EventArgs e)
	{
		HttpContext.Current.Response.Redirect("nightly/" + DropDownList2.SelectedValue);
	}
}
