<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationControl.ascx.cs" Inherits="PetShop.UI.Controls.NavigationControl" %>
<%@ OutputCache Duration="100000" VaryByParam="*" %>

<asp:Repeater ID="rePCategories" runat="server">
    <HeaderTemplate>
        <table cellspacing="0" border="0" style="border-collapse: collapse;">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="<%= ControlStyle %>">
                <asp:HyperLink runat="server" ID="lnkCategory" NavigateUrl='<%# string.Format("~/Products.aspx?page=0&categoryId={0}", Eval("CategoryId")) %>'
                    Text='<%# Eval("Name") %>' /><asp:HiddenField runat="server" ID="hidCategoryId" Value='<%# Eval("CategoryId") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
