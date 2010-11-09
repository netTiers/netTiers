<%@ Page Title="Products" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="PetShop.UI.Products" %>
<%@ Register Src="Controls/ProductsControl.ascx" TagName="ProductsControl" TagPrefix="PC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="server">
    <PC:ProductsControl ID="ProductsControl1" runat="server" />
</asp:Content>
