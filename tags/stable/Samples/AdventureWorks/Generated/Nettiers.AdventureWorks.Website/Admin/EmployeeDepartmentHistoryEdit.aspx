<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="EmployeeDepartmentHistoryEdit.aspx.cs" Inherits="EmployeeDepartmentHistoryEdit" Title="EmployeeDepartmentHistory Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Employee Department History - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="EmployeeId, StartDate, DepartmentId, ShiftId" runat="server" DataSourceID="EmployeeDepartmentHistoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmployeeDepartmentHistoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmployeeDepartmentHistoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>EmployeeDepartmentHistory not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EmployeeDepartmentHistoryDataSource ID="EmployeeDepartmentHistoryDataSource" runat="server"
			SelectMethod="GetByEmployeeIdStartDateDepartmentIdShiftId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="EmployeeId" QueryStringField="EmployeeId" Type="String" />
<asp:QueryStringParameter Name="StartDate" QueryStringField="StartDate" Type="String" />
<asp:QueryStringParameter Name="DepartmentId" QueryStringField="DepartmentId" Type="String" />
<asp:QueryStringParameter Name="ShiftId" QueryStringField="ShiftId" Type="String" />

			</Parameters>
		</data:EmployeeDepartmentHistoryDataSource>
		
		<br />


</asp:Content>

