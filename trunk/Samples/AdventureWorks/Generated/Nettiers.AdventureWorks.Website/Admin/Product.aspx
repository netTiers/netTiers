
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Product.aspx.cs" Inherits="Product" Title="Product List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProductDataSource"
				DataKeyNames="ProductId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Product.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="ProductNumber" HeaderText="Product Number" SortExpression="[ProductNumber]"  />
				<data:BoundRadioButtonField DataField="MakeFlag" HeaderText="Make Flag" SortExpression="[MakeFlag]"  />
				<data:BoundRadioButtonField DataField="FinishedGoodsFlag" HeaderText="Finished Goods Flag" SortExpression="[FinishedGoodsFlag]"  />
				<asp:BoundField DataField="Color" HeaderText="Color" SortExpression="[Color]"  />
				<asp:BoundField DataField="SafetyStockLevel" HeaderText="Safety Stock Level" SortExpression="[SafetyStockLevel]"  />
				<asp:BoundField DataField="ReorderPoint" HeaderText="Reorder Point" SortExpression="[ReorderPoint]"  />
				<asp:BoundField DataField="StandardCost" HeaderText="Standard Cost" SortExpression="[StandardCost]"  />
				<asp:BoundField DataField="ListPrice" HeaderText="List Price" SortExpression="[ListPrice]"  />
				<asp:BoundField DataField="Size" HeaderText="Size" SortExpression="[Size]"  />
				<data:HyperLinkField HeaderText="Size Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="SizeUnitMeasureCodeSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Weight Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="WeightUnitMeasureCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="[Weight]"  />
				<asp:BoundField DataField="DaysToManufacture" HeaderText="Days To Manufacture" SortExpression="[DaysToManufacture]"  />
				<asp:BoundField DataField="ProductLine" HeaderText="Product Line" SortExpression="[ProductLine]"  />
				<asp:BoundField DataField="SafeNameClass" HeaderText="Class" SortExpression="[Class]"  />
				<asp:BoundField DataField="Style" HeaderText="Style" SortExpression="[Style]"  />
				<data:HyperLinkField HeaderText="Product Subcategory Id" DataNavigateUrlFormatString="ProductSubcategoryEdit.aspx?ProductSubcategoryId={0}" DataNavigateUrlFields="ProductSubcategoryId" DataContainer="ProductSubcategoryIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Model Id" DataNavigateUrlFormatString="ProductModelEdit.aspx?ProductModelId={0}" DataNavigateUrlFields="ProductModelId" DataContainer="ProductModelIdSource" DataTextField="Name" />
				<asp:BoundField DataField="SellStartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Sell Start Date" SortExpression="[SellStartDate]"  />
				<asp:BoundField DataField="SellEndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Sell End Date" SortExpression="[SellEndDate]"  />
				<asp:BoundField DataField="DiscontinuedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Discontinued Date" SortExpression="[DiscontinuedDate]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Product Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProduct" OnClientClick="javascript:location.href='ProductEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ProductDataSource ID="ProductDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
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
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ProductDataSource>
	    		
</asp:Content>



