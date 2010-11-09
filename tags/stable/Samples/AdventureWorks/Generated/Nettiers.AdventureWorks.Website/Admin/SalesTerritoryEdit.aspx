<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesTerritoryEdit.aspx.cs" Inherits="SalesTerritoryEdit" Title="SalesTerritory Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Territory - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="TerritoryId" runat="server" DataSourceID="SalesTerritoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesTerritoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesTerritoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SalesTerritory not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SalesTerritoryDataSource ID="SalesTerritoryDataSource" runat="server"
			SelectMethod="GetByTerritoryId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="TerritoryId" QueryStringField="TerritoryId" Type="String" />

			</Parameters>
		</data:SalesTerritoryDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewStateProvince1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewStateProvince1_SelectedIndexChanged"			 			 
			DataSourceID="StateProvinceDataSource1"
			DataKeyNames="StateProvinceId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_StateProvince.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="StateProvinceCode" HeaderText="State Province Code" SortExpression="[StateProvinceCode]" />				
				<data:HyperLinkField HeaderText="Country Region Code" DataNavigateUrlFormatString="CountryRegionEdit.aspx?CountryRegionCode={0}" DataNavigateUrlFields="CountryRegionCode" DataContainer="CountryRegionCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="IsOnlyStateProvinceFlag" HeaderText="Is Only State Province Flag" SortExpression="[IsOnlyStateProvinceFlag]" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<data:HyperLinkField HeaderText="Territory Id" DataNavigateUrlFormatString="SalesTerritoryEdit.aspx?TerritoryId={0}" DataNavigateUrlFields="TerritoryId" DataContainer="TerritoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No State Province Found! </b>
				<asp:HyperLink runat="server" ID="hypStateProvince" NavigateUrl="~/admin/StateProvinceEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:StateProvinceDataSource ID="StateProvinceDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:StateProvinceProperty Name="CountryRegion"/> 
					<data:StateProvinceProperty Name="SalesTerritory"/> 
					<%--<data:StateProvinceProperty Name="AddressCollection" />--%>
					<%--<data:StateProvinceProperty Name="SalesTaxRateCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:StateProvinceFilter  Column="TerritoryId" QueryStringField="TerritoryId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:StateProvinceDataSource>		
		
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
						<data:SalesOrderHeaderFilter  Column="TerritoryId" QueryStringField="TerritoryId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesOrderHeaderDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewSalesPerson3" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewSalesPerson3_SelectedIndexChanged"			 			 
			DataSourceID="SalesPersonDataSource3"
			DataKeyNames="SalesPersonId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_SalesPerson.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="SalesPersonIdSource" DataTextField="NationalIdNumber" />
				<data:HyperLinkField HeaderText="Territory Id" DataNavigateUrlFormatString="SalesTerritoryEdit.aspx?TerritoryId={0}" DataNavigateUrlFields="TerritoryId" DataContainer="TerritoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="SalesQuota" HeaderText="Sales Quota" SortExpression="[SalesQuota]" />				
				<asp:BoundField DataField="Bonus" HeaderText="Bonus" SortExpression="[Bonus]" />				
				<asp:BoundField DataField="CommissionPct" HeaderText="Commission Pct" SortExpression="[CommissionPct]" />				
				<asp:BoundField DataField="SalesYtd" HeaderText="Sales Ytd" SortExpression="[SalesYTD]" />				
				<asp:BoundField DataField="SalesLastYear" HeaderText="Sales Last Year" SortExpression="[SalesLastYear]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Sales Person Found! </b>
				<asp:HyperLink runat="server" ID="hypSalesPerson" NavigateUrl="~/admin/SalesPersonEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:SalesPersonDataSource ID="SalesPersonDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesPersonProperty Name="Employee"/> 
					<data:SalesPersonProperty Name="SalesTerritory"/> 
					<%--<data:SalesPersonProperty Name="StoreCollection" />--%>
					<%--<data:SalesPersonProperty Name="SalesPersonQuotaHistoryCollection" />--%>
					<%--<data:SalesPersonProperty Name="SalesOrderHeaderCollection" />--%>
					<%--<data:SalesPersonProperty Name="SalesTerritoryHistoryCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:SalesPersonFilter  Column="TerritoryId" QueryStringField="TerritoryId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesPersonDataSource>		
		
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
						<data:SalesTerritoryHistoryFilter  Column="TerritoryId" QueryStringField="TerritoryId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesTerritoryHistoryDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewCustomer5" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewCustomer5_SelectedIndexChanged"			 			 
			DataSourceID="CustomerDataSource5"
			DataKeyNames="CustomerId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Customer.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Territory Id" DataNavigateUrlFormatString="SalesTerritoryEdit.aspx?TerritoryId={0}" DataNavigateUrlFields="TerritoryId" DataContainer="TerritoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="AccountNumber" HeaderText="Account Number" SortExpression="[AccountNumber]" />				
				<asp:BoundField DataField="CustomerType" HeaderText="Customer Type" SortExpression="[CustomerType]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Customer Found! </b>
				<asp:HyperLink runat="server" ID="hypCustomer" NavigateUrl="~/admin/CustomerEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CustomerDataSource ID="CustomerDataSource5" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerProperty Name="SalesTerritory"/> 
					<%--<data:CustomerProperty Name="Store" />--%>
					<%--<data:CustomerProperty Name="SalesOrderHeaderCollection" />--%>
					<%--<data:CustomerProperty Name="AddressIdAddressCollection_From_CustomerAddress" />--%>
					<%--<data:CustomerProperty Name="Individual" />--%>
					<%--<data:CustomerProperty Name="CustomerAddressCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CustomerFilter  Column="TerritoryId" QueryStringField="TerritoryId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerDataSource>		
		
		<br />
		

</asp:Content>

