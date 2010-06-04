<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PurchaseOrderDetailEdit.aspx.cs" Inherits="PurchaseOrderDetailEdit" Title="PurchaseOrderDetail Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Purchase Order Detail - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="PurchaseOrderId, PurchaseOrderDetailId" runat="server" DataSourceID="PurchaseOrderDetailDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PurchaseOrderDetailFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PurchaseOrderDetailFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>PurchaseOrderDetail not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:PurchaseOrderDetailDataSource ID="PurchaseOrderDetailDataSource" runat="server"
			SelectMethod="GetByPurchaseOrderIdPurchaseOrderDetailId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="PurchaseOrderId" QueryStringField="PurchaseOrderId" Type="String" />
<asp:QueryStringParameter Name="PurchaseOrderDetailId" QueryStringField="PurchaseOrderDetailId" Type="String" />

			</Parameters>
		</data:PurchaseOrderDetailDataSource>
		
		<br />


</asp:Content>

