<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CustomerAddressEdit.aspx.cs" Inherits="CustomerAddressEdit" Title="CustomerAddress Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer Address - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="CustomerId, AddressId" runat="server" DataSourceID="CustomerAddressDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerAddressFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerAddressFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CustomerAddress not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CustomerAddressDataSource ID="CustomerAddressDataSource" runat="server"
			SelectMethod="GetByCustomerIdAddressId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="CustomerId" QueryStringField="CustomerId" Type="String" />
<asp:QueryStringParameter Name="AddressId" QueryStringField="AddressId" Type="String" />

			</Parameters>
		</data:CustomerAddressDataSource>
		
		<br />


</asp:Content>

