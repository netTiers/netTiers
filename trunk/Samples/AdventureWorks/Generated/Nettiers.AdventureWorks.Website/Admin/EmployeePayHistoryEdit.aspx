<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="EmployeePayHistoryEdit.aspx.cs" Inherits="EmployeePayHistoryEdit" Title="EmployeePayHistory Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Employee Pay History - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="EmployeeId, RateChangeDate" runat="server" DataSourceID="EmployeePayHistoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmployeePayHistoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmployeePayHistoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>EmployeePayHistory not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EmployeePayHistoryDataSource ID="EmployeePayHistoryDataSource" runat="server"
			SelectMethod="GetByEmployeeIdRateChangeDate"
		>
			<Parameters>
				<asp:QueryStringParameter Name="EmployeeId" QueryStringField="EmployeeId" Type="String" />
<asp:QueryStringParameter Name="RateChangeDate" QueryStringField="RateChangeDate" Type="String" />

			</Parameters>
		</data:EmployeePayHistoryDataSource>
		
		<br />


</asp:Content>

