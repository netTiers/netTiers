<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesPersonEdit.aspx.cs" Inherits="SalesPersonEdit" Title="SalesPerson Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Person - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SalesPersonId" runat="server" DataSourceID="SalesPersonDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesPersonFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesPersonFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SalesPerson not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SalesPersonDataSource ID="SalesPersonDataSource" runat="server"
			SelectMethod="GetBySalesPersonId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SalesPersonId" QueryStringField="SalesPersonId" Type="String" />

			</Parameters>
		</data:SalesPersonDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewStore1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewStore1_SelectedIndexChanged"			 			 
			DataSourceID="StoreDataSource1"
			DataKeyNames="CustomerId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Store.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?CustomerId={0}" DataNavigateUrlFields="CustomerId" DataContainer="CustomerIdSource" DataTextField="AccountNumber" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?SalesPersonId={0}" DataNavigateUrlFields="SalesPersonId" DataContainer="SalesPersonIdSource" DataTextField="SalesQuota" />
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Store Found! </b>
				<asp:HyperLink runat="server" ID="hypStore" NavigateUrl="~/admin/StoreEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:StoreDataSource ID="StoreDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:StoreProperty Name="Customer"/> 
					<data:StoreProperty Name="SalesPerson"/> 
					<%--<data:StoreProperty Name="StoreContactCollection" />--%>
					<%--<data:StoreProperty Name="ContactIdContactCollection_From_StoreContact" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:StoreFilter  Column="SalesPersonId" QueryStringField="SalesPersonId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:StoreDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewSalesPersonQuotaHistory2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewSalesPersonQuotaHistory2_SelectedIndexChanged"			 			 
			DataSourceID="SalesPersonQuotaHistoryDataSource2"
			DataKeyNames="SalesPersonId, QuotaDate"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_SalesPersonQuotaHistory.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?SalesPersonId={0}" DataNavigateUrlFields="SalesPersonId" DataContainer="SalesPersonIdSource" DataTextField="SalesQuota" />
				<asp:BoundField DataField="SalesQuota" HeaderText="Sales Quota" SortExpression="[SalesQuota]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Sales Person Quota History Found! </b>
				<asp:HyperLink runat="server" ID="hypSalesPersonQuotaHistory" NavigateUrl="~/admin/SalesPersonQuotaHistoryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:SalesPersonQuotaHistoryDataSource ID="SalesPersonQuotaHistoryDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesPersonQuotaHistoryProperty Name="SalesPerson"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:SalesPersonQuotaHistoryFilter  Column="SalesPersonId" QueryStringField="SalesPersonId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesPersonQuotaHistoryDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewSalesOrderHeader3" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewSalesOrderHeader3_SelectedIndexChanged"			 			 
			DataSourceID="SalesOrderHeaderDataSource3"
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
		
		<data:SalesOrderHeaderDataSource ID="SalesOrderHeaderDataSource3" runat="server" SelectMethod="Find"
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
						<data:SalesOrderHeaderFilter  Column="SalesPersonId" QueryStringField="SalesPersonId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesOrderHeaderDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewSalesTerritoryHistory4" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewSalesTerritoryHistory4_SelectedIndexChanged"			 			 
			DataSourceID="SalesTerritoryHistoryDataSource4"
			DataKeyNames="SalesPersonId, StartDate, TerritoryId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_SalesTerritoryHistory.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?SalesPersonId={0}" DataNavigateUrlFields="SalesPersonId" DataContainer="SalesPersonIdSource" DataTextField="SalesQuota" />
				<data:HyperLinkField HeaderText="Territory Id" DataNavigateUrlFormatString="SalesTerritoryEdit.aspx?TerritoryId={0}" DataNavigateUrlFields="TerritoryId" DataContainer="TerritoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="[EndDate]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Sales Territory History Found! </b>
				<asp:HyperLink runat="server" ID="hypSalesTerritoryHistory" NavigateUrl="~/admin/SalesTerritoryHistoryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:SalesTerritoryHistoryDataSource ID="SalesTerritoryHistoryDataSource4" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesTerritoryHistoryProperty Name="SalesPerson"/> 
					<data:SalesTerritoryHistoryProperty Name="SalesTerritory"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:SalesTerritoryHistoryFilter  Column="SalesPersonId" QueryStringField="SalesPersonId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesTerritoryHistoryDataSource>		
		
		<br />
		

</asp:Content>

