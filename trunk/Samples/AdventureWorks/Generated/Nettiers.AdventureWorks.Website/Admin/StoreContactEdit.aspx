<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="StoreContactEdit.aspx.cs" Inherits="StoreContactEdit" Title="StoreContact Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Store Contact - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="CustomerId, ContactId" runat="server" DataSourceID="StoreContactDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/StoreContactFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/StoreContactFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>StoreContact not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:StoreContactDataSource ID="StoreContactDataSource" runat="server"
			SelectMethod="GetByCustomerIdContactId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="CustomerId" QueryStringField="CustomerId" Type="String" />
<asp:QueryStringParameter Name="ContactId" QueryStringField="ContactId" Type="String" />

			</Parameters>
		</data:StoreContactDataSource>
		
		<br />


</asp:Content>

