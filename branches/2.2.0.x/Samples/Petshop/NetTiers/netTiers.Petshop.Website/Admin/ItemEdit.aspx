<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"  CodeFile="ItemEdit.aspx.cs" Inherits="ItemEdit" Title="Item Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
		<data:MultiFormView ID="FormView1" runat="server" DataSourceID="ItemDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="ItemFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="ItemFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Item not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
				<asp:Button ID="AddNewButton" runat="server" CausesValidation="False" CommandName="New" Text="Add New" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EntityDataSource ID="ItemDataSource" runat="server"
			ProviderName="ItemProvider"
			EntityTypeName="Entities.Item, Entities"
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



