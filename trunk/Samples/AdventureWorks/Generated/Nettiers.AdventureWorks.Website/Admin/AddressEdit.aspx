<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AddressEdit.aspx.cs" Inherits="AddressEdit" Title="Address Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Address - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="AddressId" runat="server" DataSourceID="AddressDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AddressFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AddressFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Address not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AddressDataSource ID="AddressDataSource" runat="server"
			SelectMethod="GetByAddressId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="AddressId" QueryStringField="AddressId" Type="String" />

			</Parameters>
		</data:AddressDataSource>
		
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
						<data:SalesOrderHeaderFilter  Column="BillToAddressId" QueryStringField="AddressId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesOrderHeaderDataSource>		
		
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
						<data:SalesOrderHeaderFilter  Column="ShipToAddressId" QueryStringField="AddressId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesOrderHeaderDataSource>		
		
		<br />
		

</asp:Content>

