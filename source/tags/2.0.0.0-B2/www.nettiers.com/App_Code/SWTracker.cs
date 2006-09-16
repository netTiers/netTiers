using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SWTracker
/// </summary>
public class SWTracker
{
	public SWTracker()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public static void LogThis(int goaldId, string semWayId)
	{
		if (HttpContext.Current.Request.Cookies["__SWSTATE"] == null)
		{
			return;
		}
				
		SqlConnection conn = new SqlConnection("server=(local);database=petshop; uid=petshopuser;pwd=1.petshop.1;Trusted_Connection=false;CONNECTION TIMEOUT=1;application name=nettierspetshop");

		try
		{
			SqlCommand command = new SqlCommand();
			command.CommandType = CommandType.Text;
			command.Connection = conn;
			command.CommandText = "INSERT INTO Tracker (UTC, SemWayId, ConsumerId, UserAgent, Ip, GoalId) VALUES(@utc, @semwayid, @consumerid, @useragent, @ip, @GoalId)";
			command.Parameters.Add("@utc", SqlDbType.DateTime);
			command.Parameters.Add("@semwayid", SqlDbType.NVarChar);
			command.Parameters.Add("@consumerid", SqlDbType.BigInt);
			command.Parameters.Add("@useragent", SqlDbType.NVarChar);
			command.Parameters.Add("@ip", SqlDbType.NVarChar);
			command.Parameters.Add("@goalId", SqlDbType.Int);

			command.Parameters["@utc"].Value = DateTime.Now.ToUniversalTime();
			command.Parameters["@semwayid"].Value = semWayId;
			command.Parameters["@consumerid"].Value = HttpContext.Current.Request.Cookies["__SWSTATE"].Value;
			command.Parameters["@useragent"].Value = HttpContext.Current.Request.UserAgent;
			command.Parameters["@ip"].Value = HttpContext.Current.Request.UserHostAddress;
			command.Parameters["@goalId"].Value = goaldId;

			conn.Open();
			command.ExecuteNonQuery();

		}
		catch (SqlException sex)
		{
			HttpContext.Current.Response.Write(sex);
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
