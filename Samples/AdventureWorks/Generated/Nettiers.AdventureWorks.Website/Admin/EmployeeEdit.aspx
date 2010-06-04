<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="EmployeeEdit.aspx.cs" Inherits="EmployeeEdit" Title="Employee Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Employee - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="EmployeeId" runat="server" DataSourceID="EmployeeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmployeeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EmployeeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Employee not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EmployeeDataSource ID="EmployeeDataSource" runat="server"
			SelectMethod="GetByEmployeeId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="EmployeeId" QueryStringField="EmployeeId" Type="String" />

			</Parameters>
		</data:EmployeeDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewEmployee1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewEmployee1_SelectedIndexChanged"			 			 
			DataSourceID="EmployeeDataSource1"
			DataKeyNames="EmployeeId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Employee.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="NationalIdNumber" HeaderText="National Id Number" SortExpression="[NationalIDNumber]" />				
				<data:HyperLinkField HeaderText="Contact Id" DataNavigateUrlFormatString="ContactEdit.aspx?ContactId={0}" DataNavigateUrlFields="ContactId" DataContainer="ContactIdSource" DataTextField="NameStyle" />
				<asp:BoundField DataField="LoginId" HeaderText="Login Id" SortExpression="[LoginID]" />				
				<data:HyperLinkField HeaderText="Manager Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="ManagerIdSource" DataTextField="NationalIdNumber" />
				<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="[Title]" />				
				<asp:BoundField DataField="BirthDate" HeaderText="Birth Date" SortExpression="[BirthDate]" />				
				<asp:BoundField DataField="MaritalStatus" HeaderText="Marital Status" SortExpression="[MaritalStatus]" />				
				<asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="[Gender]" />				
				<asp:BoundField DataField="HireDate" HeaderText="Hire Date" SortExpression="[HireDate]" />				
				<asp:BoundField DataField="SalariedFlag" HeaderText="Salaried Flag" SortExpression="[SalariedFlag]" />				
				<asp:BoundField DataField="VacationHours" HeaderText="Vacation Hours" SortExpression="[VacationHours]" />				
				<asp:BoundField DataField="SickLeaveHours" HeaderText="Sick Leave Hours" SortExpression="[SickLeaveHours]" />				
				<asp:BoundField DataField="CurrentFlag" HeaderText="Current Flag" SortExpression="[CurrentFlag]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Employee Found! </b>
				<asp:HyperLink runat="server" ID="hypEmployee" NavigateUrl="~/admin/EmployeeEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:EmployeeDataSource ID="EmployeeDataSource1" runat="server" SelectMethod="Find"
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
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:EmployeeFilter  Column="ManagerId" QueryStringField="EmployeeId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:EmployeeDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewJobCandidate2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewJobCandidate2_SelectedIndexChanged"			 			 
			DataSourceID="JobCandidateDataSource2"
			DataKeyNames="JobCandidateId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_JobCandidate.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Employee Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="EmployeeIdSource" DataTextField="NationalIdNumber" />
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Job Candidate Found! </b>
				<asp:HyperLink runat="server" ID="hypJobCandidate" NavigateUrl="~/admin/JobCandidateEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:JobCandidateDataSource ID="JobCandidateDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:JobCandidateProperty Name="Employee"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:JobCandidateFilter  Column="EmployeeId" QueryStringField="EmployeeId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:JobCandidateDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewEmployeePayHistory3" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewEmployeePayHistory3_SelectedIndexChanged"			 			 
			DataSourceID="EmployeePayHistoryDataSource3"
			DataKeyNames="EmployeeId, RateChangeDate"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_EmployeePayHistory.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Employee Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="EmployeeIdSource" DataTextField="NationalIdNumber" />
				<asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="[Rate]" />				
				<asp:BoundField DataField="PayFrequency" HeaderText="Pay Frequency" SortExpression="[PayFrequency]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Employee Pay History Found! </b>
				<asp:HyperLink runat="server" ID="hypEmployeePayHistory" NavigateUrl="~/admin/EmployeePayHistoryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:EmployeePayHistoryDataSource ID="EmployeePayHistoryDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:EmployeePayHistoryProperty Name="Employee"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:EmployeePayHistoryFilter  Column="EmployeeId" QueryStringField="EmployeeId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:EmployeePayHistoryDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewPurchaseOrderHeader4" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewPurchaseOrderHeader4_SelectedIndexChanged"			 			 
			DataSourceID="PurchaseOrderHeaderDataSource4"
			DataKeyNames="PurchaseOrderId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_PurchaseOrderHeader.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="RevisionNumber" HeaderText="Revision Number" SortExpression="[RevisionNumber]" />				
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="[Status]" />				
				<data:HyperLinkField HeaderText="Employee Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="EmployeeIdSource" DataTextField="NationalIdNumber" />
				<data:HyperLinkField HeaderText="Vendor Id" DataNavigateUrlFormatString="VendorEdit.aspx?VendorId={0}" DataNavigateUrlFields="VendorId" DataContainer="VendorIdSource" DataTextField="AccountNumber" />
				<data:HyperLinkField HeaderText="Ship Method Id" DataNavigateUrlFormatString="ShipMethodEdit.aspx?ShipMethodId={0}" DataNavigateUrlFields="ShipMethodId" DataContainer="ShipMethodIdSource" DataTextField="Name" />
				<asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="[OrderDate]" />				
				<asp:BoundField DataField="ShipDate" HeaderText="Ship Date" SortExpression="[ShipDate]" />				
				<asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="[SubTotal]" />				
				<asp:BoundField DataField="TaxAmt" HeaderText="Tax Amt" SortExpression="[TaxAmt]" />				
				<asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="[Freight]" />				
				<asp:BoundField DataField="TotalDue" HeaderText="Total Due" SortExpression="[TotalDue]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Purchase Order Header Found! </b>
				<asp:HyperLink runat="server" ID="hypPurchaseOrderHeader" NavigateUrl="~/admin/PurchaseOrderHeaderEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:PurchaseOrderHeaderDataSource ID="PurchaseOrderHeaderDataSource4" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:PurchaseOrderHeaderProperty Name="Employee"/> 
					<data:PurchaseOrderHeaderProperty Name="ShipMethod"/> 
					<data:PurchaseOrderHeaderProperty Name="Vendor"/> 
					<%--<data:PurchaseOrderHeaderProperty Name="PurchaseOrderDetailCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:PurchaseOrderHeaderFilter  Column="EmployeeId" QueryStringField="EmployeeId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:PurchaseOrderHeaderDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewEmployeeDepartmentHistory5" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewEmployeeDepartmentHistory5_SelectedIndexChanged"			 			 
			DataSourceID="EmployeeDepartmentHistoryDataSource5"
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
		
		<data:EmployeeDepartmentHistoryDataSource ID="EmployeeDepartmentHistoryDataSource5" runat="server" SelectMethod="Find"
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
						<data:EmployeeDepartmentHistoryFilter  Column="EmployeeId" QueryStringField="EmployeeId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:EmployeeDepartmentHistoryDataSource>		
		
		<br />
		

</asp:Content>

