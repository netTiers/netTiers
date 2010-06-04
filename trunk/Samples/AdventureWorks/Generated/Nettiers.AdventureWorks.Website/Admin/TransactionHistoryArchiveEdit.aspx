<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TransactionHistoryArchiveEdit.aspx.cs" Inherits="TransactionHistoryArchiveEdit" Title="TransactionHistoryArchive Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Transaction History Archive - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="TransactionId" runat="server" DataSourceID="TransactionHistoryArchiveDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TransactionHistoryArchiveFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TransactionHistoryArchiveFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>TransactionHistoryArchive not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:TransactionHistoryArchiveDataSource ID="TransactionHistoryArchiveDataSource" runat="server"
			SelectMethod="GetByTransactionId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="TransactionId" QueryStringField="TransactionId" Type="String" />

			</Parameters>
		</data:TransactionHistoryArchiveDataSource>
		
		<br />

		

</asp:Content>

