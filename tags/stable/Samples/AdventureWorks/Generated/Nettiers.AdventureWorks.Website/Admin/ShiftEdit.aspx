<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ShiftEdit.aspx.cs" Inherits="ShiftEdit" Title="Shift Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Shift - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ShiftId" runat="server" DataSourceID="ShiftDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ShiftFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ShiftFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Shift not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ShiftDataSource ID="ShiftDataSource" runat="server"
			SelectMethod="GetByShiftId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ShiftId" QueryStringField="ShiftId" Type="String" />

			</Parameters>
		</data:ShiftDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewEmployeeDepartmentHistory1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewEmployeeDepartmentHistory1_SelectedIndexChanged"			 			 
			DataSourceID="EmployeeDepartmentHistoryDataSource1"
			DataKeyNames="EmployeeId, StartDate, DepartmentId, ShiftId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_EmployeeDepartmentHistory.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Employee Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="EmployeeIdSource" DataTextField="NationalIdNumber" />
				<data:HyperLinkField HeaderText="Department Id" DataNavigateUrlFormatString="DepartmentEdit.aspx?DepartmentId={0}" DataNavigateUrlFields="DepartmentId" DataContainer="DepartmentIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Shift Id" DataNavigateUrlFormatString="ShiftEdit.aspx?ShiftId={0}" DataNavigateUrlFields="ShiftId" DataContainer="ShiftIdSource" DataTextField="Name" />
				<asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="[EndDate]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Employee Department History Found! </b>
				<asp:HyperLink runat="server" ID="hypEmployeeDepartmentHistory" NavigateUrl="~/admin/EmployeeDepartmentHistoryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:EmployeeDepartmentHistoryDataSource ID="EmployeeDepartmentHistoryDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:EmployeeDepartmentHistoryProperty Name="Department"/> 
					<data:EmployeeDepartmentHistoryProperty Name="Employee"/> 
					<data:EmployeeDepartmentHistoryProperty Name="Shift"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:EmployeeDepartmentHistoryFilter  Column="ShiftId" QueryStringField="ShiftId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:EmployeeDepartmentHistoryDataSource>		
		
		<br />
		

</asp:Content>

