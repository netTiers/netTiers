<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"  CodeFile="ProductEdit.aspx.cs" Inherits="ProductEdit" Title="Product Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
		<data:MultiFormView ID="FormView1" runat="server" DataSourceID="ProductDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="ProductFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="ProductFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Product not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
				<asp:Button ID="AddNewButton" runat="server" CausesValidation="False" CommandName="New" Text="Add New" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EntityDataSource ID="ProductDataSource" runat="server"
			ProviderName="ProductProvider"
			EntityTypeName="Entities.Product, Entities"
			EntityKeyTypeName="System.String"
			EntityKeyName="Id"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="EntityId" QueryStringField="id" Type="String" />
			</Parameters>
		</data:EntityDataSource>
		
		<br />

		
		
</asp:Content>



