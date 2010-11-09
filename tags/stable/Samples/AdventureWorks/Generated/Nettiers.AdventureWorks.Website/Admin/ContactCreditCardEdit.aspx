<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ContactCreditCardEdit.aspx.cs" Inherits="ContactCreditCardEdit" Title="ContactCreditCard Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Contact Credit Card - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ContactId, CreditCardId" runat="server" DataSourceID="ContactCreditCardDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ContactCreditCardFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ContactCreditCardFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ContactCreditCard not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ContactCreditCardDataSource ID="ContactCreditCardDataSource" runat="server"
			SelectMethod="GetByContactIdCreditCardId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ContactId" QueryStringField="ContactId" Type="String" />
<asp:QueryStringParameter Name="CreditCardId" QueryStringField="CreditCardId" Type="String" />

			</Parameters>
		</data:ContactCreditCardDataSource>
		
		<br />


</asp:Content>

