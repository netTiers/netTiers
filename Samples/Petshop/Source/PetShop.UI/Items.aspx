<%@ Page Title="Items" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="PetShop.UI.Items" %>

<%@ Register Src="Controls/ItemsControl.ascx" TagName="ItemsControl" TagPrefix="PC" %>

<asp:Content ID="cntPage" runat="Server" ContentPlaceHolderID="cphPage" EnableViewState="false">
    <PC:ItemsControl ID="ItemsControl1" runat="server" />
</asp:Content>
