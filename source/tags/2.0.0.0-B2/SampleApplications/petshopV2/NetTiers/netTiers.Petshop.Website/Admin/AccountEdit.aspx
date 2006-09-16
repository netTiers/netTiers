<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"  CodeFile="AccountEdit.aspx.cs" Inherits="AccountEdit" Title="Account Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
		<data:MultiFormView ID="FormView1" runat="server" DataSourceID="AccountDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="AccountFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="AccountFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Account not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
				<asp:Button ID="AddNewButton" runat="server" CausesValidation="False" CommandName="New" Text="Add New" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EntityDataSource ID="AccountDataSource" runat="server"
			ProviderName="AccountProvider"
			EntityTypeName="Entities.Account, Entities"
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



