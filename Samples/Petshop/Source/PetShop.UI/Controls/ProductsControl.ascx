<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsControl.ascx.cs" Inherits="PetShop.UI.Controls.ProductsControl" %>
<%@ OutputCache Duration="100000" VaryByParam="page;categoryId" %>

<div align="center" class="productsPosition">
    <PC:customlist ID="productsList" runat="server" 
    EmptyText="No products found." OnPageIndexChanged="PageChanged" PageSize="4" 
    RepeatColumns="2" CellPadding="16" CellSpacing="0" Width="500px">        
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" width="91"><a href='Items.aspx?productId=<%# Eval("ProductId") %>&categoryId=<%# Eval("categoryId") %>'><img id="imgProduct" alt='<%# Eval("Name") %>' src='<%# Eval("Image") %>' style="border-width: 0px;" runat="server" /></a></td>
                    <td width="26">&nbsp;</td>
                    <td valign="top" width="120"><a href='Items.aspx?productId=<%# Eval("ProductId") %>&categoryId=<%# Eval("categoryId") %>'><div class="productName"><%# Eval("Name") %></div></a><div class="productDescription"><%# Eval("Descn") %></div></td>                    
                </tr>               
            </table>            
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />        
    </PC:customlist>
 </div>