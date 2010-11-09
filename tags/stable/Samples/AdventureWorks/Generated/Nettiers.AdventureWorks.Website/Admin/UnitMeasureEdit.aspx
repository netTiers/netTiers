<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="UnitMeasureEdit.aspx.cs" Inherits="UnitMeasureEdit" Title="UnitMeasure Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Unit Measure - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="UnitMeasureCode" runat="server" DataSourceID="UnitMeasureDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UnitMeasureFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UnitMeasureFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>UnitMeasure not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:UnitMeasureDataSource ID="UnitMeasureDataSource" runat="server"
			SelectMethod="GetByUnitMeasureCode"
		>
			<Parameters>
				<asp:QueryStringParameter Name="UnitMeasureCode" QueryStringField="UnitMeasureCode" Type="String" />

			</Parameters>
		</data:UnitMeasureDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewBillOfMaterials1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewBillOfMaterials1_SelectedIndexChanged"			 			 
			DataSourceID="BillOfMaterialsDataSource1"
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
		
		<data:BillOfMaterialsDataSource ID="BillOfMaterialsDataSource1" runat="server" SelectMethod="Find"
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
						<data:BillOfMaterialsFilter  Column="UnitMeasureCode" QueryStringField="UnitMeasureCode" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:BillOfMaterialsDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewProduct2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewProduct2_SelectedIndexChanged"			 			 
			DataSourceID="ProductDataSource2"
			DataKeyNames="ProductId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Product.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="ProductNumber" HeaderText="Product Number" SortExpression="[ProductNumber]" />				
				<asp:BoundField DataField="MakeFlag" HeaderText="Make Flag" SortExpression="[MakeFlag]" />				
				<asp:BoundField DataField="FinishedGoodsFlag" HeaderText="Finished Goods Flag" SortExpression="[FinishedGoodsFlag]" />				
				<asp:BoundField DataField="Color" HeaderText="Color" SortExpression="[Color]" />				
				<asp:BoundField DataField="SafetyStockLevel" HeaderText="Safety Stock Level" SortExpression="[SafetyStockLevel]" />				
				<asp:BoundField DataField="ReorderPoint" HeaderText="Reorder Point" SortExpression="[ReorderPoint]" />				
				<asp:BoundField DataField="StandardCost" HeaderText="Standard Cost" SortExpression="[StandardCost]" />				
				<asp:BoundField DataField="ListPrice" HeaderText="List Price" SortExpression="[ListPrice]" />				
				<asp:BoundField DataField="Size" HeaderText="Size" SortExpression="[Size]" />				
				<data:HyperLinkField HeaderText="Size Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="SizeUnitMeasureCodeSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Weight Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="WeightUnitMeasureCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="[Weight]" />				
				<asp:BoundField DataField="DaysToManufacture" HeaderText="Days To Manufacture" SortExpression="[DaysToManufacture]" />				
				<asp:BoundField DataField="ProductLine" HeaderText="Product Line" SortExpression="[ProductLine]" />				
				<asp:BoundField DataField="SafeNameClass" HeaderText="Class" SortExpression="[Class]" />				
				<asp:BoundField DataField="Style" HeaderText="Style" SortExpression="[Style]" />				
				<data:HyperLinkField HeaderText="Product Subcategory Id" DataNavigateUrlFormatString="ProductSubcategoryEdit.aspx?ProductSubcategoryId={0}" DataNavigateUrlFields="ProductSubcategoryId" DataContainer="ProductSubcategoryIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Model Id" DataNavigateUrlFormatString="ProductModelEdit.aspx?ProductModelId={0}" DataNavigateUrlFields="ProductModelId" DataContainer="ProductModelIdSource" DataTextField="Name" />
				<asp:BoundField DataField="SellStartDate" HeaderText="Sell Start Date" SortExpression="[SellStartDate]" />				
				<asp:BoundField DataField="SellEndDate" HeaderText="Sell End Date" SortExpression="[SellEndDate]" />				
				<asp:BoundField DataField="DiscontinuedDate" HeaderText="Discontinued Date" SortExpression="[DiscontinuedDate]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Product Found! </b>
				<asp:HyperLink runat="server" ID="hypProduct" NavigateUrl="~/admin/ProductEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ProductDataSource ID="ProductDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductProperty Name="ProductModel"/> 
					<data:ProductProperty Name="ProductSubcategory"/> 
					<data:ProductProperty Name="UnitMeasure"/> 
					<%--<data:ProductProperty Name="ProductProductPhotoCollection" />--%>
					<%--<data:ProductProperty Name="TransactionHistoryCollection" />--%>
					<%--<data:ProductProperty Name="ProductVendorCollection" />--%>
					<%--<data:ProductProperty Name="BillOfMaterialsCollectionGetByProductAssemblyId" />--%>
					<%--<data:ProductProperty Name="DocumentIdDocumentCollection_From_ProductDocument" />--%>
					<%--<data:ProductProperty Name="SpecialOfferProductCollection" />--%>
					<%--<data:ProductProperty Name="ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto" />--%>
					<%--<data:ProductProperty Name="BillOfMaterialsCollectionGetByComponentId" />--%>
					<%--<data:ProductProperty Name="ProductInventoryCollection" />--%>
					<%--<data:ProductProperty Name="ProductDocumentCollection" />--%>
					<%--<data:ProductProperty Name="ProductReviewCollection" />--%>
					<%--<data:ProductProperty Name="VendorIdVendorCollection_From_ProductVendor" />--%>
					<%--<data:ProductProperty Name="WorkOrderCollection" />--%>
					<%--<data:ProductProperty Name="PurchaseOrderDetailCollection" />--%>
					<%--<data:ProductProperty Name="LocationIdLocationCollection_From_ProductInventory" />--%>
					<%--<data:ProductProperty Name="ProductListPriceHistoryCollection" />--%>
					<%--<data:ProductProperty Name="SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct" />--%>
					<%--<data:ProductProperty Name="ShoppingCartItemCollection" />--%>
					<%--<data:ProductProperty Name="ProductCostHistoryCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductFilter  Column="WeightUnitMeasureCode" QueryStringField="UnitMeasureCode" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewProduct3" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewProduct3_SelectedIndexChanged"			 			 
			DataSourceID="ProductDataSource3"
			DataKeyNames="ProductId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Product.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="ProductNumber" HeaderText="Product Number" SortExpression="[ProductNumber]" />				
				<asp:BoundField DataField="MakeFlag" HeaderText="Make Flag" SortExpression="[MakeFlag]" />				
				<asp:BoundField DataField="FinishedGoodsFlag" HeaderText="Finished Goods Flag" SortExpression="[FinishedGoodsFlag]" />				
				<asp:BoundField DataField="Color" HeaderText="Color" SortExpression="[Color]" />				
				<asp:BoundField DataField="SafetyStockLevel" HeaderText="Safety Stock Level" SortExpression="[SafetyStockLevel]" />				
				<asp:BoundField DataField="ReorderPoint" HeaderText="Reorder Point" SortExpression="[ReorderPoint]" />				
				<asp:BoundField DataField="StandardCost" HeaderText="Standard Cost" SortExpression="[StandardCost]" />				
				<asp:BoundField DataField="ListPrice" HeaderText="List Price" SortExpression="[ListPrice]" />				
				<asp:BoundField DataField="Size" HeaderText="Size" SortExpression="[Size]" />				
				<data:HyperLinkField HeaderText="Size Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="SizeUnitMeasureCodeSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Weight Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="WeightUnitMeasureCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="[Weight]" />				
				<asp:BoundField DataField="DaysToManufacture" HeaderText="Days To Manufacture" SortExpression="[DaysToManufacture]" />				
				<asp:BoundField DataField="ProductLine" HeaderText="Product Line" SortExpression="[ProductLine]" />				
				<asp:BoundField DataField="SafeNameClass" HeaderText="Class" SortExpression="[Class]" />				
				<asp:BoundField DataField="Style" HeaderText="Style" SortExpression="[Style]" />				
				<data:HyperLinkField HeaderText="Product Subcategory Id" DataNavigateUrlFormatString="ProductSubcategoryEdit.aspx?ProductSubcategoryId={0}" DataNavigateUrlFields="ProductSubcategoryId" DataContainer="ProductSubcategoryIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Model Id" DataNavigateUrlFormatString="ProductModelEdit.aspx?ProductModelId={0}" DataNavigateUrlFields="ProductModelId" DataContainer="ProductModelIdSource" DataTextField="Name" />
				<asp:BoundField DataField="SellStartDate" HeaderText="Sell Start Date" SortExpression="[SellStartDate]" />				
				<asp:BoundField DataField="SellEndDate" HeaderText="Sell End Date" SortExpression="[SellEndDate]" />				
				<asp:BoundField DataField="DiscontinuedDate" HeaderText="Discontinued Date" SortExpression="[DiscontinuedDate]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Product Found! </b>
				<asp:HyperLink runat="server" ID="hypProduct" NavigateUrl="~/admin/ProductEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ProductDataSource ID="ProductDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductProperty Name="ProductModel"/> 
					<data:ProductProperty Name="ProductSubcategory"/> 
					<data:ProductProperty Name="UnitMeasure"/> 
					<%--<data:ProductProperty Name="ProductProductPhotoCollection" />--%>
					<%--<data:ProductProperty Name="TransactionHistoryCollection" />--%>
					<%--<data:ProductProperty Name="ProductVendorCollection" />--%>
					<%--<data:ProductProperty Name="BillOfMaterialsCollectionGetByProductAssemblyId" />--%>
					<%--<data:ProductProperty Name="DocumentIdDocumentCollection_From_ProductDocument" />--%>
					<%--<data:ProductProperty Name="SpecialOfferProductCollection" />--%>
					<%--<data:ProductProperty Name="ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto" />--%>
					<%--<data:ProductProperty Name="BillOfMaterialsCollectionGetByComponentId" />--%>
					<%--<data:ProductProperty Name="ProductInventoryCollection" />--%>
					<%--<data:ProductProperty Name="ProductDocumentCollection" />--%>
					<%--<data:ProductProperty Name="ProductReviewCollection" />--%>
					<%--<data:ProductProperty Name="VendorIdVendorCollection_From_ProductVendor" />--%>
					<%--<data:ProductProperty Name="WorkOrderCollection" />--%>
					<%--<data:ProductProperty Name="PurchaseOrderDetailCollection" />--%>
					<%--<data:ProductProperty Name="LocationIdLocationCollection_From_ProductInventory" />--%>
					<%--<data:ProductProperty Name="ProductListPriceHistoryCollection" />--%>
					<%--<data:ProductProperty Name="SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct" />--%>
					<%--<data:ProductProperty Name="ShoppingCartItemCollection" />--%>
					<%--<data:ProductProperty Name="ProductCostHistoryCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductFilter  Column="SizeUnitMeasureCode" QueryStringField="UnitMeasureCode" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductDataSource>		
		
		<br />
		

</asp:Content>

