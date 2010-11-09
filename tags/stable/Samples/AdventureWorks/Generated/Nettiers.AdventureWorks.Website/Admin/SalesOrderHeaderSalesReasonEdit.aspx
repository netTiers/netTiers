<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesOrderHeaderSalesReasonEdit.aspx.cs" Inherits="SalesOrderHeaderSalesReasonEdit" Title="SalesOrderHeaderSalesReason Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Order Header Sales Reason - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SalesOrderId, SalesReasonId" runat="server" DataSourceID="SalesOrderHeaderSalesReasonDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesOrderHeaderSalesReasonFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesOrderHeaderSalesReasonFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SalesOrderHeaderSalesReason not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SalesOrderHeaderSalesReasonDataSource ID="SalesOrderHeaderSalesReasonDataSource" runat="server"
			SelectMethod="GetBySalesOrderIdSalesReasonId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SalesOrderId" QueryStringField="SalesOrderId" Type="String" />
<asp:QueryStringParameter Name="SalesReasonId" QueryStringField="SalesReasonId" Type="String" />

			</Parameters>
		</data:SalesOrderHeaderSalesReasonDataSource>
		
		<br />


</asp:Content>

