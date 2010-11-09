
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

public partial class ProductEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ProductEdit.aspx?{0}", ProductDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ProductEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Product.aspx");
		FormUtil.SetDefaultMode(FormView1, "ProductId");
	}
	protected void GridViewTransactionHistory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("TransactionId={0}", GridViewTransactionHistory1.SelectedDataKey.Values[0]);
		Response.Redirect("TransactionHistoryEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewBillOfMaterials2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("BillOfMaterialsId={0}", GridViewBillOfMaterials2.SelectedDataKey.Values[0]);
		Response.Redirect("BillOfMaterialsEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewBillOfMaterials3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("BillOfMaterialsId={0}", GridViewBillOfMaterials3.SelectedDataKey.Values[0]);
		Response.Redirect("BillOfMaterialsEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewProductReview4_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProductReviewId={0}", GridViewProductReview4.SelectedDataKey.Values[0]);
		Response.Redirect("ProductReviewEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewWorkOrder5_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("WorkOrderId={0}", GridViewWorkOrder5.SelectedDataKey.Values[0]);
		Response.Redirect("WorkOrderEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewPurchaseOrderDetail6_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("PurchaseOrderId={0}&PurchaseOrderDetailId={1}", GridViewPurchaseOrderDetail6.SelectedDataKey.Values[0], GridViewPurchaseOrderDetail6.SelectedDataKey.Values[1]);
		Response.Redirect("PurchaseOrderDetailEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewProductListPriceHistory7_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProductId={0}&StartDate={1}", GridViewProductListPriceHistory7.SelectedDataKey.Values[0], GridViewProductListPriceHistory7.SelectedDataKey.Values[1]);
		Response.Redirect("ProductListPriceHistoryEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewShoppingCartItem8_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ShoppingCartItemId={0}", GridViewShoppingCartItem8.SelectedDataKey.Values[0]);
		Response.Redirect("ShoppingCartItemEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewProductCostHistory9_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ProductId={0}&StartDate={1}", GridViewProductCostHistory9.SelectedDataKey.Values[0], GridViewProductCostHistory9.SelectedDataKey.Values[1]);
		Response.Redirect("ProductCostHistoryEdit.aspx?" + urlParams, true);		
	}	
}


