<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" StylesheetTheme="AdminPage"%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>WebAdmin</title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Petshop WebAdmin</h3>
    <table width="100%">
        <tr valign="top">
        <td width="150">
              
            <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DataSourceID="XmlDataSource1"
                DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57"
                StaticSubMenuIndent="10px" OnMenuItemClick="MenuItem_Click">
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <DynamicMenuStyle BackColor="#F7F6F3" />
                <StaticSelectedStyle BackColor="#5D7B9D" />
                <DynamicSelectedStyle BackColor="#5D7B9D" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <DataBindings>
                    <asp:MenuItemBinding DataMember="node" 
                        TextField="text" />
                </DataBindings>
                <DynamicItemTemplate>
                    <%# Eval("Text") %>
                </DynamicItemTemplate>
            </asp:Menu>
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="MenuDefinition.xml" XPath="MenuNodes/node" ></asp:XmlDataSource>
        
        </td>
        <td>
        <asp:PlaceHolder runat="server" ID="plAdmin" />         
        </td>
       </tr>
    </table>      
    </form>
</body>
</html>
