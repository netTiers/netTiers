<%@ Page Title="Search" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="PetShop.UI.Search" %>
<%@ Register Src="Controls/SearchControl.ascx" TagName="SearchControl" TagPrefix="pc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="server">
    <pc:SearchControl ID="SearchControl1" runat="server" />
</asp:Content>
