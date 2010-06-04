<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ShoppingCartItemEdit.aspx.cs" Inherits="ShoppingCartItemEdit" Title="ShoppingCartItem Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Shopping Cart Item - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ShoppingCartItemId" runat="server" DataSourceID="ShoppingCartItemDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ShoppingCartItemFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ShoppingCartItemFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ShoppingCartItem not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ShoppingCartItemDataSource ID="ShoppingCartItemDataSource" runat="server"
			SelectMethod="GetByShoppingCartItemId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ShoppingCartItemId" QueryStringField="ShoppingCartItemId" Type="String" />

			</Parameters>
		</data:ShoppingCartItemDataSource>
		
		<br />

		

</asp:Content>

