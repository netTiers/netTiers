<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="PetShop.UI.ShoppingCart" %>
<%@ Register Src="Controls/ShoppingCartControl.ascx" TagName="ShoppingCartControl" TagPrefix="PC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="server">
<div align="center" class="cartPosition">   
<PC:shoppingcartcontrol id="ShoppingCartControl1" runat="server"></PC:shoppingcartcontrol>
    <table border="0" cellpadding="0" cellspacing="0" align="center" width="387">
        <tr><td class="linkCheckOut" colspan="2">&nbsp;</td></tr>
       <tr>
            <td nowrap="nowrap" align="right" width="100%"><a href="javascript:history.back();"><img border="0" src="Comm_Images/button-home.gif"></a></td>
            <td align="left" nowrap="nowrap"><a class="linkCheckOut" href="javascript:history.back();">Continue Shopping</a></td>
        </tr>
            <tr><td class="linkCheckOut" colspan="2">&nbsp;</td></tr>
        <tr>
            <td align="right" nowrap="nowrap"><a href="CheckOut.aspx"><img border="0" src="Comm_Images/button-checkout.gif"></a></td>
            <td nowrap="nowrap" align="left"><a class="linkCheckOut" href="CheckOut.aspx">Check Out</a></td>
        </tr>
    </table>
</div>
</asp:Content>
