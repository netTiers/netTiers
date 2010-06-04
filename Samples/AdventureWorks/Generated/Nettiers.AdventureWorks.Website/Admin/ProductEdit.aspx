<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductEdit.aspx.cs" Inherits="ProductEdit" Title="Product Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ProductId" runat="server" DataSourceID="ProductDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Product not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductDataSource ID="ProductDataSource" runat="server"
			SelectMethod="GetByProductId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ProductId" QueryStringField="ProductId" Type="String" />

			</Parameters>
		</data:ProductDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewTransactionHistory1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewTransactionHistory1_SelectedIndexChanged"			 			 
			DataSourceID="TransactionHistoryDataSource1"
			DataKeyNames="TransactionId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_TransactionHistory.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ReferenceOrderId" HeaderText="Reference Order Id" SortExpression="[ReferenceOrderID]" />				
				<asp:BoundField DataField="ReferenceOrderLineId" HeaderText="Reference Order Line Id" SortExpression="[ReferenceOrderLineID]" />				
				<asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="[TransactionDate]" />				
				<asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" SortExpression="[TransactionType]" />				
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="[Quantity]" />				
				<asp:BoundField DataField="ActualCost" HeaderText="Actual Cost" SortExpression="[ActualCost]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Transaction History Found! </b>
				<asp:HyperLink runat="server" ID="hypTransactionHistory" NavigateUrl="~/admin/TransactionHistoryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:TransactionHistoryDataSource ID="TransactionHistoryDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:TransactionHistoryProperty Name="Product"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:TransactionHistoryFilter  Column="ProductId" QueryStringField="ProductId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:TransactionHistoryDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewBillOfMaterials2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewBillOfMaterials2_SelectedIndexChanged"			 			 
			DataSourceID="BillOfMaterialsDataSource2"
			DataKeyNames="BillOfMaterialsId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_BillOfMaterials.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Assembly Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductAssemblyIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Component Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ComponentIdSource" DataTextField="Name" />
				<asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="[StartDate]" />				
				<asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="[EndDate]" />				
				<data:HyperLinkField HeaderText="Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="UnitMeasureCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="BomLevel" HeaderText="Bom Level" SortExpression="[BOMLevel]" />				
				<asp:BoundField DataField="PerAssemblyQty" HeaderText="Per Assembly Qty" SortExpression="[PerAssemblyQty]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Bill Of Materials Found! </b>
				<asp:HyperLink runat="server" ID="hypBillOfMaterials" NavigateUrl="~/admin/BillOfMaterialsEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:BillOfMaterialsDataSource ID="BillOfMaterialsDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:BillOfMaterialsProperty Name="Product"/> 
					<data:BillOfMaterialsProperty Name="UnitMeasure"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:BillOfMaterialsFilter  Column="ProductAssemblyId" QueryStringField="ProductId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:BillOfMaterialsDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewBillOfMaterials3" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewBillOfMaterials3_SelectedIndexChanged"			 			 
			DataSourceID="BillOfMaterialsDataSource3"
			DataKeyNames="BillOfMaterialsId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_BillOfMaterials.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Assembly Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductAssemblyIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Component Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ComponentIdSource" DataTextField="Name" />
				<asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="[StartDate]" />				
				<asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="[EndDate]" />				
				<data:HyperLinkField HeaderText="Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="UnitMeasureCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="BomLevel" HeaderText="Bom Level" SortExpression="[BOMLevel]" />				
				<asp:BoundField DataField="PerAssemblyQty" HeaderText="Per Assembly Qty" SortExpression="[PerAssemblyQty]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Bill Of Materials Found! </b>
				<asp:HyperLink runat="server" ID="hypBillOfMaterials" NavigateUrl="~/admin/BillOfMaterialsEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:BillOfMaterialsDataSource ID="BillOfMaterialsDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:BillOfMaterialsProperty Name="Product"/> 
					<data:BillOfMaterialsProperty Name="UnitMeasure"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:BillOfMaterialsFilter  Column="ComponentId" QueryStringField="ProductId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:BillOfMaterialsDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewProductReview4" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewProductReview4_SelectedIndexChanged"			 			 
			DataSourceID="ProductReviewDataSource4"
			DataKeyNames="ProductReviewId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ProductReview.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ReviewerName" HeaderText="Reviewer Name" SortExpression="[ReviewerName]" />				
				<asp:BoundField DataField="ReviewDate" HeaderText="Review Date" SortExpression="[ReviewDate]" />				
				<asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="[EmailAddress]" />				
				<asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="[Rating]" />				
				<asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="[Comments]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Product Review Found! </b>
				<asp:HyperLink runat="server" ID="hypProductReview" NavigateUrl="~/admin/ProductReviewEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ProductReviewDataSource ID="ProductReviewDataSource4" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductReviewProperty Name="Product"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductReviewFilter  Column="ProductId" QueryStringField="ProductId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductReviewDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewWorkOrder5" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewWorkOrder5_SelectedIndexChanged"			 			 
			DataSourceID="WorkOrderDataSource5"
			DataKeyNames="WorkOrderId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_WorkOrder.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="OrderQty" HeaderText="Order Qty" SortExpression="[OrderQty]" />				
				<asp:BoundField DataField="StockedQty" HeaderText="Stocked Qty" SortExpression="[StockedQty]" />				
				<asp:BoundField DataField="ScrappedQty" HeaderText="Scrapped Qty" SortExpression="[ScrappedQty]" />				
				<asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="[StartDate]" />				
				<asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="[EndDate]" />				
				<asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="[DueDate]" />				
				<data:HyperLinkField HeaderText="Scrap Reason Id" DataNavigateUrlFormatString="ScrapReasonEdit.aspx?ScrapReasonId={0}" DataNavigateUrlFields="ScrapReasonId" DataContainer="ScrapReasonIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Work Order Found! </b>
				<asp:HyperLink runat="server" ID="hypWorkOrder" NavigateUrl="~/admin/WorkOrderEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:WorkOrderDataSource ID="WorkOrderDataSource5" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:WorkOrderProperty Name="Product"/> 
					<data:WorkOrderProperty Name="ScrapReason"/> 
					<%--<data:WorkOrderProperty Name="WorkOrderRoutingCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:WorkOrderFilter  Column="ProductId" QueryStringField="ProductId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:WorkOrderDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewPurchaseOrderDetail6" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewPurchaseOrderDetail6_SelectedIndexChanged"			 			 
			DataSourceID="PurchaseOrderDetailDataSource6"
			DataKeyNames="PurchaseOrderId, PurchaseOrderDetailId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_PurchaseOrderDetail.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Purchase Order Id" DataNavigateUrlFormatString="PurchaseOrderHeaderEdit.aspx?PurchaseOrderId={0}" DataNavigateUrlFields="PurchaseOrderId" DataContainer="PurchaseOrderIdSource" DataTextField="RevisionNumber" />
				<asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="[DueDate]" />				
				<asp:BoundField DataField="OrderQty" HeaderText="Order Qty" SortExpression="[OrderQty]" />				
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="[UnitPrice]" />				
				<asp:BoundField DataField="LineTotal" HeaderText="Line Total" SortExpression="[LineTotal]" />				
				<asp:BoundField DataField="ReceivedQty" HeaderText="Received Qty" SortExpression="[ReceivedQty]" />				
				<asp:BoundField DataField="RejectedQty" HeaderText="Rejected Qty" SortExpression="[RejectedQty]" />				
				<asp:BoundField DataField="StockedQty" HeaderText="Stocked Qty" SortExpression="[StockedQty]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Purchase Order Detail Found! </b>
				<asp:HyperLink runat="server" ID="hypPurchaseOrderDetail" NavigateUrl="~/admin/PurchaseOrderDetailEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:PurchaseOrderDetailDataSource ID="PurchaseOrderDetailDataSource6" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:PurchaseOrderDetailProperty Name="Product"/> 
					<data:PurchaseOrderDetailProperty Name="PurchaseOrderHeader"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:PurchaseOrderDetailFilter  Column="ProductId" QueryStringField="ProductId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:PurchaseOrderDetailDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewProductListPriceHistory7" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewProductListPriceHistory7_SelectedIndexChanged"			 			 
			DataSourceID="ProductListPriceHistoryDataSource7"
			DataKeyNames="ProductId, StartDate"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ProductListPriceHistory.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="[EndDate]" />				
				<asp:BoundField DataField="ListPrice" HeaderText="List Price" SortExpression="[ListPrice]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Product List Price History Found! </b>
				<asp:HyperLink runat="server" ID="hypProductListPriceHistory" NavigateUrl="~/admin/ProductListPriceHistoryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ProductListPriceHistoryDataSource ID="ProductListPriceHistoryDataSource7" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductListPriceHistoryProperty Name="Product"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductListPriceHistoryFilter  Column="ProductId" QueryStringField="ProductId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductListPriceHistoryDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewShoppingCartItem8" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewShoppingCartItem8_SelectedIndexChanged"			 			 
			DataSourceID="ShoppingCartItemDataSource8"
			DataKeyNames="ShoppingCartItemId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ShoppingCartItem.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="ShoppingCartId" HeaderText="Shopping Cart Id" SortExpression="[ShoppingCartID]" />				
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="[Quantity]" />				
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="[DateCreated]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Shopping Cart Item Found! </b>
				<asp:HyperLink runat="server" ID="hypShoppingCartItem" NavigateUrl="~/admin/ShoppingCartItemEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ShoppingCartItemDataSource ID="ShoppingCartItemDataSource8" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ShoppingCartItemProperty Name="Product"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ShoppingCartItemFilter  Column="ProductId" QueryStringField="ProductId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ShoppingCartItemDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewProductCostHistory9" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewProductCostHistory9_SelectedIndexChanged"			 			 
			DataSourceID="ProductCostHistoryDataSource9"
			DataKeyNames="ProductId, StartDate"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ProductCostHistory.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="[EndDate]" />				
				<asp:BoundField DataField="StandardCost" HeaderText="Standard Cost" SortExpression="[StandardCost]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Product Cost History Found! </b>
				<asp:HyperLink runat="server" ID="hypProductCostHistory" NavigateUrl="~/admin/ProductCostHistoryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ProductCostHistoryDataSource ID="ProductCostHistoryDataSource9" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductCostHistoryProperty Name="Product"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductCostHistoryFilter  Column="ProductId" QueryStringField="ProductId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductCostHistoryDataSource>		
		
		<br />
		

</asp:Content>

