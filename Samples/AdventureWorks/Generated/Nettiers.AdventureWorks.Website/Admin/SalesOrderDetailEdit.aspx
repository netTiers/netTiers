<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesOrderDetailEdit.aspx.cs" Inherits="SalesOrderDetailEdit" Title="SalesOrderDetail Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Order Detail - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SalesOrderId, SalesOrderDetailId" runat="server" DataSourceID="SalesOrderDetailDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesOrderDetailFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesOrderDetailFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SalesOrderDetail not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SalesOrderDetailDataSource ID="SalesOrderDetailDataSource" runat="server"
			SelectMethod="GetBySalesOrderIdSalesOrderDetailId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SalesOrderId" QueryStringField="SalesOrderId" Type="String" />
<asp:QueryStringParameter Name="SalesOrderDetailId" QueryStringField="SalesOrderDetailId" Type="String" />

			</Parameters>
		</data:SalesOrderDetailDataSource>
		
		<br />


</asp:Content>

