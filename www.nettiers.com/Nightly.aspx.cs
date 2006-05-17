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
using System.Data.SqlClient;

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
		LogThis();
		HttpContext.Current.Response.Redirect("nightly/" + DropDownList1.SelectedValue);
	}
	protected void Button2_Click(object sender, EventArgs e)
	{
		LogThis();
		HttpContext.Current.Response.Redirect("nightly/" + DropDownList2.SelectedValue);
	}

	void LogThis()
	{
		if (Request.Cookies["__SWSTATE"] != null)
		{
			SqlConnection conn = new SqlConnection("server=(local);database=petshop; uid=petshopuser;pwd=1.petshop.1;Trusted_Connection=false;CONNECTION TIMEOUT=1;application name=nettierspetshop");

			try
			{
				SqlCommand command = new SqlCommand();
				command.CommandType = CommandType.Text;
				command.Connection = conn;
				command.CommandText = "INSERT INTO SWTrack (UTC, SemWayId, ConsumerId, UserAgent) VALUES(@utc, @semwayid, @consumerid, @useragent)";
				command.Parameters.Add("@utc", SqlDbType.DateTime);
				command.Parameters.Add("@semwayid", SqlDbType.NVarChar);
				command.Parameters.Add("@consumerid", SqlDbType.BigInt);
				command.Parameters.Add("@useragent", SqlDbType.NVarChar);

				command.Parameters["@utc"].Value = DateTime.Now.ToUniversalTime();
				command.Parameters["@semwayid"].Value = SemWayId;
				command.Parameters["@consumerid"].Value = Request.Cookies["__SWSTATE"].Value;
				command.Parameters["@useragent"].Value = Request.UserAgent;

				conn.Open();
				command.ExecuteNonQuery();
				
			}
			catch (SqlException sex)
			{
				Response.Write(sex);
			}
			finally
			{
				conn.Close();
			}


			//StreamWriter writer = File.AppendText(@"C:\Inetpub\wwwroot\nettiers.com\wwwroot\nightly\semway.log");
			//writer.Write(string.Format("{0:yyyy/MM/dd hh:mm};{1}", DateTime.Now.ToUniversalTime(), SemWayId));
			//writer.Flush();
			//writer.Close();
		}
	}

}
