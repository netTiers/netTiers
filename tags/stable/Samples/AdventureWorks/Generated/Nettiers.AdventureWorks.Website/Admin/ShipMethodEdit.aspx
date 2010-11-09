<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ShipMethodEdit.aspx.cs" Inherits="ShipMethodEdit" Title="ShipMethod Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Ship Method - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ShipMethodId" runat="server" DataSourceID="ShipMethodDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ShipMethodFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ShipMethodFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ShipMethod not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ShipMethodDataSource ID="ShipMethodDataSource" runat="server"
			SelectMethod="GetByShipMethodId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ShipMethodId" QueryStringField="ShipMethodId" Type="String" />

			</Parameters>
		</data:ShipMethodDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewSalesOrderHeader1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewSalesOrderHeader1_SelectedIndexChanged"			 			 
			DataSourceID="SalesOrderHeaderDataSource1"
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
		
		<data:SalesOrderHeaderDataSource ID="SalesOrderHeaderDataSource1" runat="server" SelectMethod="Find"
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
						<data:SalesOrderHeaderFilter  Column="ShipMethodId" QueryStringField="ShipMethodId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesOrderHeaderDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewPurchaseOrderHeader2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewPurchaseOrderHeader2_SelectedIndexChanged"			 			 
			DataSourceID="PurchaseOrderHeaderDataSource2"
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
		
		<data:PurchaseOrderHeaderDataSource ID="PurchaseOrderHeaderDataSource2" runat="server" SelectMethod="Find"
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
						<data:PurchaseOrderHeaderFilter  Column="ShipMethodId" QueryStringField="ShipMethodId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:PurchaseOrderHeaderDataSource>		
		
		<br />
		

</asp:Content>

