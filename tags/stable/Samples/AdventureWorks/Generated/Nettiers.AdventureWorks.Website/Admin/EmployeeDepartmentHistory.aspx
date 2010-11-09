
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="EmployeeDepartmentHistory.aspx.cs" Inherits="EmployeeDepartmentHistory" Title="EmployeeDepartmentHistory List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Employee Department History List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="EmployeeDepartmentHistoryDataSource"
				DataKeyNames="EmployeeId, StartDate, DepartmentId, ShiftId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_EmployeeDepartmentHistory.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Employee Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="EmployeeIdSource" DataTextField="NationalIdNumber" />
				<data:HyperLinkField HeaderText="Department Id" DataNavigateUrlFormatString="DepartmentEdit.aspx?DepartmentId={0}" DataNavigateUrlFields="DepartmentId" DataContainer="DepartmentIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Shift Id" DataNavigateUrlFormatString="ShiftEdit.aspx?ShiftId={0}" DataNavigateUrlFields="ShiftId" DataContainer="ShiftIdSource" DataTextField="Name" />
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression="[StartDate]" ReadOnly="True" />
				<asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="End Date" SortExpression="[EndDate]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No EmployeeDepartmentHistory Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnEmployeeDepartmentHistory" OnClientClick="javascript:location.href='EmployeeDepartmentHistoryEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:EmployeeDepartmentHistoryDataSource ID="EmployeeDepartmentHistoryDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
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
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:EmployeeDepartmentHistoryDataSource>
	    		
</asp:Content>



