<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="EmployeeAddressEdit.aspx.cs" Inherits="EmployeeAddressEdit" Title="EmployeeAddress Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Employee Address - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="EmployeeId, AddressId" runat="server" DataSourceID="EmployeeAddressDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmployeeAddressFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmployeeAddressFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>EmployeeAddress not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EmployeeAddressDataSource ID="EmployeeAddressDataSource" runat="server"
			SelectMethod="GetByEmployeeIdAddressId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="EmployeeId" QueryStringField="EmployeeId" Type="String" />
<asp:QueryStringParameter Name="AddressId" QueryStringField="AddressId" Type="String" />

			</Parameters>
		</data:EmployeeAddressDataSource>
		
		<br />


</asp:Content>

