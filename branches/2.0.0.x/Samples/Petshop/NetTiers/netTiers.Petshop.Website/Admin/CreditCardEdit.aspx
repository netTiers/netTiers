<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"  CodeFile="CreditCardEdit.aspx.cs" Inherits="CreditCardEdit" Title="CreditCard Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
		<data:MultiFormView ID="FormView1" runat="server" DataSourceID="CreditCardDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="CreditCardFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="CreditCardFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CreditCard not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
				<asp:Button ID="AddNewButton" runat="server" CausesValidation="False" CommandName="New" Text="Add New" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EntityDataSource ID="CreditCardDataSource" runat="server"
			ProviderName="CreditCardProvider"
			EntityTypeName="Entities.CreditCard, Entities"
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



