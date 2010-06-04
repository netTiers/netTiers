
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Employee.aspx.cs" Inherits="Employee" Title="Employee List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Employee List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="EmployeeDataSource"
				DataKeyNames="EmployeeId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Employee.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="NationalIdNumber" HeaderText="National Id Number" SortExpression="[NationalIDNumber]"  />
				<data:HyperLinkField HeaderText="Contact Id" DataNavigateUrlFormatString="ContactEdit.aspx?ContactId={0}" DataNavigateUrlFields="ContactId" DataContainer="ContactIdSource" DataTextField="NameStyle" />
				<asp:BoundField DataField="LoginId" HeaderText="Login Id" SortExpression="[LoginID]"  />
				<data:HyperLinkField HeaderText="Manager Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="ManagerIdSource" DataTextField="NationalIdNumber" />
				<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="[Title]"  />
				<asp:BoundField DataField="BirthDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Birth Date" SortExpression="[BirthDate]"  />
				<asp:BoundField DataField="MaritalStatus" HeaderText="Marital Status" SortExpression="[MaritalStatus]"  />
				<asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="[Gender]"  />
				<asp:BoundField DataField="HireDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Hire Date" SortExpression="[HireDate]"  />
				<data:BoundRadioButtonField DataField="SalariedFlag" HeaderText="Salaried Flag" SortExpression="[SalariedFlag]"  />
				<asp:BoundField DataField="VacationHours" HeaderText="Vacation Hours" SortExpression="[VacationHours]"  />
				<asp:BoundField DataField="SickLeaveHours" HeaderText="Sick Leave Hours" SortExpression="[SickLeaveHours]"  />
				<data:BoundRadioButtonField DataField="CurrentFlag" HeaderText="Current Flag" SortExpression="[CurrentFlag]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Employee Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnEmployee" OnClientClick="javascript:location.href='EmployeeEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:EmployeeDataSource ID="EmployeeDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:EmployeeProperty Name="Contact"/> 
					<data:EmployeeProperty Name="Employee"/> 
					<%--<data:EmployeeProperty Name="EmployeeCollection" />--%>
					<%--<data:EmployeeProperty Name="JobCandidateCollection" />--%>
					<%--<data:EmployeeProperty Name="SalesPerson" />--%>
					<%--<data:EmployeeProperty Name="EmployeeAddressCollection" />--%>
					<%--<data:EmployeeProperty Name="EmployeePayHistoryCollection" />--%>
					<%--<data:EmployeeProperty Name="PurchaseOrderHeaderCollection" />--%>
					<%--<data:EmployeeProperty Name="AddressIdAddressCollection_From_EmployeeAddress" />--%>
					<%--<data:EmployeeProperty Name="EmployeeDepartmentHistoryCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:EmployeeDataSource>
	    		
</asp:Content>



