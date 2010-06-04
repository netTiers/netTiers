<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="VendorAddressEdit.aspx.cs" Inherits="VendorAddressEdit" Title="VendorAddress Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Vendor Address - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="VendorId, AddressId" runat="server" DataSourceID="VendorAddressDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/VendorAddressFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/VendorAddressFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>VendorAddress not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:VendorAddressDataSource ID="VendorAddressDataSource" runat="server"
			SelectMethod="GetByVendorIdAddressId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="VendorId" QueryStringField="VendorId" Type="String" />
<asp:QueryStringParameter Name="AddressId" QueryStringField="AddressId" Type="String" />

			</Parameters>
		</data:VendorAddressDataSource>
		
		<br />


</asp:Content>

