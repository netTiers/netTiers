<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="VendorContactEdit.aspx.cs" Inherits="VendorContactEdit" Title="VendorContact Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Vendor Contact - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="VendorId, ContactId" runat="server" DataSourceID="VendorContactDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/VendorContactFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/VendorContactFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>VendorContact not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:VendorContactDataSource ID="VendorContactDataSource" runat="server"
			SelectMethod="GetByVendorIdContactId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="VendorId" QueryStringField="VendorId" Type="String" />
<asp:QueryStringParameter Name="ContactId" QueryStringField="ContactId" Type="String" />

			</Parameters>
		</data:VendorContactDataSource>
		
		<br />


</asp:Content>

