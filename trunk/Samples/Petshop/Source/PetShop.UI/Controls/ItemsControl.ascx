<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemsControl.ascx.cs" Inherits="PetShop.UI.Controls.ItemsControl" %>
<%@ Import Namespace="PetShop.Business"%>
<div class="paging">
    <a href='Products.aspx?categoryId=<%=Request.QueryString["categoryId"] %>&productId=<%=Request.QueryString["productId"] %>'>
        &#060;&nbsp;Back to list</a></div>
<div class="itemsPosition" align="center">
    <PC:CustomGrid ID="itemsGrid" runat="server" EmptyText="No items found." OnPageIndexChanged="PageChanged"
        PageSize="2">
        <headertemplate>
            <table cellspacing="0" cellpadding="0" border="0" width="387">
        </headertemplate>
        <itemtemplate>
            <tr align="left" valign="top">
                <td valign="top" width="148">
                    <img id="imgItem" alt='<%# Eval("Name") %>' src='<%# Eval("Image") %>' style="border-width: 0px;" runat="server" /></td>
                <td width="33">&nbsp;</td>
                <td valign="top" width="206">
                <table cellspacing="0" cellpadding="0" border="0">
		            <tr>
			            <td class="itemText">Name:</td>
			            <td class="itemName"><%# string.Format("{0} {1}", Eval("Product.Name"), Eval("Name")) %></td>
		            </tr>
		            <tr class="itemText">
			            <td>Quantity:</td>
			            <td><%# Inventory.GetInventory(Eval("ItemId").ToString()).Qty %></td>
		            </tr>
		            <tr class="itemText">
			            <td>Price:</td>
			            <td><%# Eval("ListPrice", "{0:c}")%></td>
		            </tr>
		            <tr class="itemText">
			            <td colspan="2"><asp:HyperLink ID="lnkCart" runat="server" NavigateUrl='<%# string.Format("~/ShoppingCart.aspx?addItem={0}", Eval("ItemId")) %>'  SkinID="lnkCart"></asp:HyperLink></td>
		            </tr>
		            <tr class="itemText">
			            <td colspan="2"><asp:HyperLink ID="lnkWishList" runat="server" NavigateUrl='<%# string.Format("~/WishList.aspx?addItem={0}", Eval("ItemId")) %>'  SkinID="lnkWishlist"></asp:HyperLink></td>
		            </tr>
	            </table>            
	            </td>
            </tr>            
        </itemtemplate>
        <separatortemplate>
            <tr>
                <td height="50" colspan="3">&nbsp;</td>
            </tr>
        </separatortemplate>
        <footertemplate>
            </table></footertemplate>
    </PC:CustomGrid>
</div>