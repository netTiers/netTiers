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
using System.IO;

public partial class Nightly : System.Web.UI.Page
{	
	public string SemWayId
	{
		get
		{
			if (ViewState["SemWayId"] ==  null)
			{
				ViewState["SemWayId"] = Guid.NewGuid().ToString();
			}
			return ViewState["SemWayId"].ToString(); 
		}
	}


    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			Button1.Attributes.Add("onclick", "swtag('scriptname=nightly-download', 'fx=11', 'SemWayId=" + SemWayId + "')");
			Button2.Attributes.Add("onclick", "swtag('scriptname=nightly-download', 'fx=20', 'SemWayId=" + SemWayId + "')");
		
			//Button1.Attributes.Add("onclick", "swtag('scriptname=nightly-download', 'fx=1.1');urchinTracker('/fx11_download.html')");
			//Button2.Attributes.Add("onclick", "swtag('scriptname=nightly-download', 'fx=2.0');urchinTracker('/fx20_download.html')");
		}
    }
	protected void Button1_Click(object sender, EventArgs e)
	{
		SWTracker.LogThis(62, SemWayId);
		HttpContext.Current.Response.Redirect("nightly/" + DropDownList1.SelectedValue);
	}
	protected void Button2_Click(object sender, EventArgs e)
	{
		SWTracker.LogThis(62, SemWayId);
		HttpContext.Current.Response.Redirect("nightly/" + DropDownList2.SelectedValue);
	}

	

}
