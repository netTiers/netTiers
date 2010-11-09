<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ContactEdit.aspx.cs" Inherits="ContactEdit" Title="Contact Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Contact - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ContactId" runat="server" DataSourceID="ContactDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ContactFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ContactFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Contact not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ContactDataSource ID="ContactDataSource" runat="server"
			SelectMethod="GetByContactId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ContactId" QueryStringField="ContactId" Type="String" />

			</Parameters>
		</data:ContactDataSource>
		
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
						<data:EmployeeFilter  Column="ContactId" QueryStringField="ContactId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:EmployeeDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewSalesOrderHeader2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewSalesOrderHeader2_SelectedIndexChanged"			 			 
			DataSourceID="SalesOrderHeaderDataSource2"
			DataKeyNames="SalesOrderId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_SalesOrderHeader.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="RevisionNumber" HeaderText="Revision Number" SortExpression="[RevisionNumber]" />				
				<asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="[OrderDate]" />				
				<asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="[DueDate]" />				
				<asp:BoundField DataField="ShipDate" HeaderText="Ship Date" SortExpression="[ShipDate]" />				
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="[Status]" />				
				<asp:BoundField DataField="OnlineOrderFlag" HeaderText="Online Order Flag" SortExpression="[OnlineOrderFlag]" />				
				<asp:BoundField DataField="SalesOrderNumber" HeaderText="Sales Order Number" SortExpression="[SalesOrderNumber]" />				
				<asp:BoundField DataField="PurchaseOrderNumber" HeaderText="Purchase Order Number" SortExpression="[PurchaseOrderNumber]" />				
				<asp:BoundField DataField="AccountNumber" HeaderText="Account Number" SortExpression="[AccountNumber]" />				
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?CustomerId={0}" DataNavigateUrlFields="CustomerId" DataContainer="CustomerIdSource" DataTextField="AccountNumber" />
				<data:HyperLinkField HeaderText="Contact Id" DataNavigateUrlFormatString="ContactEdit.aspx?ContactId={0}" DataNavigateUrlFields="ContactId" DataContainer="ContactIdSource" DataTextField="NameStyle" />
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?SalesPersonId={0}" DataNavigateUrlFields="SalesPersonId" DataContainer="SalesPersonIdSource" DataTextField="SalesQuota" />
				<data:HyperLinkField HeaderText="Territory Id" DataNavigateUrlFormatString="SalesTerritoryEdit.aspx?TerritoryId={0}" DataNavigateUrlFields="TerritoryId" DataContainer="TerritoryIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Bill To Address Id" DataNavigateUrlFormatString="AddressEdit.aspx?AddressId={0}" DataNavigateUrlFields="AddressId" DataContainer="BillToAddressIdSource" DataTextField="AddressLine1" />
				<data:HyperLinkField HeaderText="Ship To Address Id" DataNavigateUrlFormatString="AddressEdit.aspx?AddressId={0}" DataNavigateUrlFields="AddressId" DataContainer="ShipToAddressIdSource" DataTextField="AddressLine1" />
				<data:HyperLinkField HeaderText="Ship Method Id" DataNavigateUrlFormatString="ShipMethodEdit.aspx?ShipMethodId={0}" DataNavigateUrlFields="ShipMethodId" DataContainer="ShipMethodIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Credit Card Id" DataNavigateUrlFormatString="CreditCardEdit.aspx?CreditCardId={0}" DataNavigateUrlFields="CreditCardId" DataContainer="CreditCardIdSource" DataTextField="CardType" />
				<asp:BoundField DataField="CreditCardApprovalCode" HeaderText="Credit Card Approval Code" SortExpression="[CreditCardApprovalCode]" />				
				<data:HyperLinkField HeaderText="Currency Rate Id" DataNavigateUrlFormatString="CurrencyRateEdit.aspx?CurrencyRateId={0}" DataNavigateUrlFields="CurrencyRateId" DataContainer="CurrencyRateIdSource" DataTextField="CurrencyRateDate" />
				<asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="[SubTotal]" />				
				<asp:BoundField DataField="TaxAmt" HeaderText="Tax Amt" SortExpression="[TaxAmt]" />				
				<asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="[Freight]" />				
				<asp:BoundField DataField="TotalDue" HeaderText="Total Due" SortExpression="[TotalDue]" />				
				<asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression="[Comment]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Sales Order Header Found! </b>
				<asp:HyperLink runat="server" ID="hypSalesOrderHeader" NavigateUrl="~/admin/SalesOrderHeaderEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:SalesOrderHeaderDataSource ID="SalesOrderHeaderDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesOrderHeaderProperty Name="Address"/> 
					<data:SalesOrderHeaderProperty Name="Contact"/> 
					<data:SalesOrderHeaderProperty Name="CreditCard"/> 
					<data:SalesOrderHeaderProperty Name="CurrencyRate"/> 
					<data:SalesOrderHeaderProperty Name="Customer"/> 
					<data:SalesOrderHeaderProperty Name="SalesPerson"/> 
					<data:SalesOrderHeaderProperty Name="SalesTerritory"/> 
					<data:SalesOrderHeaderProperty Name="ShipMethod"/> 
					<%--<data:SalesOrderHeaderProperty Name="SalesOrderHeaderSalesReasonCollection" />--%>
					<%--<data:SalesOrderHeaderProperty Name="SalesOrderDetailCollection" />--%>
					<%--<data:SalesOrderHeaderProperty Name="SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:SalesOrderHeaderFilter  Column="ContactId" QueryStringField="ContactId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesOrderHeaderDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewIndividual3" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewIndividual3_SelectedIndexChanged"			 			 
			DataSourceID="IndividualDataSource3"
			DataKeyNames="CustomerId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Individual.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?CustomerId={0}" DataNavigateUrlFields="CustomerId" DataContainer="CustomerIdSource" DataTextField="AccountNumber" />
				<data:HyperLinkField HeaderText="Contact Id" DataNavigateUrlFormatString="ContactEdit.aspx?ContactId={0}" DataNavigateUrlFields="ContactId" DataContainer="ContactIdSource" DataTextField="NameStyle" />
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Individual Found! </b>
				<asp:HyperLink runat="server" ID="hypIndividual" NavigateUrl="~/admin/IndividualEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:IndividualDataSource ID="IndividualDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:IndividualProperty Name="Contact"/> 
					<data:IndividualProperty Name="Customer"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:IndividualFilter  Column="ContactId" QueryStringField="ContactId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:IndividualDataSource>		
		
		<br />
		

</asp:Content>

