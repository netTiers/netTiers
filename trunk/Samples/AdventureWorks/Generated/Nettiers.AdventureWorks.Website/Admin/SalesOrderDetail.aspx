
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesOrderDetail.aspx.cs" Inherits="SalesOrderDetail" Title="SalesOrderDetail List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Order Detail List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SalesOrderDetailDataSource"
				DataKeyNames="SalesOrderId, SalesOrderDetailId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SalesOrderDetail.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Sales Order Id" DataNavigateUrlFormatString="SalesOrderHeaderEdit.aspx?SalesOrderId={0}" DataNavigateUrlFields="SalesOrderId" DataContainer="SalesOrderIdSource" DataTextField="RevisionNumber" />
				<asp:BoundField DataField="CarrierTrackingNumber" HeaderText="Carrier Tracking Number" SortExpression="[CarrierTrackingNumber]"  />
				<asp:BoundField DataField="OrderQty" HeaderText="Order Qty" SortExpression="[OrderQty]"  />

				<data:HyperLinkField HeaderText="Special Offer Id / Product Id" DataNavigateUrlFormatString="SpecialOfferProductEdit.aspx?SpecialOfferId={0}&ProductId={1}" DataNavigateUrlFields="SpecialOfferId,ProductId" DataContainer="SpecialOfferIdProductIdSource" DataTextField="Rowguid" />
				<asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="[UnitPrice]"  />
				<asp:BoundField DataField="UnitPriceDiscount" HeaderText="Unit Price Discount" SortExpression="[UnitPriceDiscount]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SalesOrderDetail Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSalesOrderDetail" OnClientClick="javascript:location.href='SalesOrderDetailEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SalesOrderDetailDataSource ID="SalesOrderDetailDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesOrderDetailProperty Name="SalesOrderHeader"/> 
					<data:SalesOrderDetailProperty Name="SpecialOfferProduct"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SalesOrderDetailDataSource>
	    		
</asp:Content>



