
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

public partial class CountryRegionEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CountryRegionEdit.aspx?{0}", CountryRegionDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CountryRegionEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CountryRegion.aspx");
		FormUtil.SetDefaultMode(FormView1, "CountryRegionCode");
	}
	protected void GridViewStateProvince1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("StateProvinceId={0}", GridViewStateProvince1.SelectedDataKey.Values[0]);
		Response.Redirect("StateProvinceEdit.aspx?" + urlParams, true);		
	}	
}


