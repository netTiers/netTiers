
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

public partial class UnitMeasureEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "UnitMeasureEdit.aspx?{0}", UnitMeasureDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "UnitMeasureEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "UnitMeasure.aspx");
		FormUtil.SetDefaultMode(FormView1, "UnitMeasureCode");
	}
	protected void GridViewBillOfMaterials1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("BillOfMaterialsId={0}", GridViewBillOfMaterials1.SelectedDataKey.Values[0]);
		Response.Redirect("BillOfMaterialsEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewProduct2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProductId={0}", GridViewProduct2.SelectedDataKey.Values[0]);
		Response.Redirect("ProductEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewProduct3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProductId={0}", GridViewProduct3.SelectedDataKey.Values[0]);
		Response.Redirect("ProductEdit.aspx?" + urlParams, true);		
	}	
}


