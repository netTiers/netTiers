
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PurchaseOrderDetail.aspx.cs" Inherits="PurchaseOrderDetail" Title="PurchaseOrderDetail List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Purchase Order Detail List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="PurchaseOrderDetailDataSource"
				DataKeyNames="PurchaseOrderId, PurchaseOrderDetailId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_PurchaseOrderDetail.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Purchase Order Id" DataNavigateUrlFormatString="PurchaseOrderHeaderEdit.aspx?PurchaseOrderId={0}" DataNavigateUrlFields="PurchaseOrderId" DataContainer="PurchaseOrderIdSource" DataTextField="RevisionNumber" />
				<asp:BoundField DataField="DueDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Due Date" SortExpression="[DueDate]"  />
				<asp:BoundField DataField="OrderQty" HeaderText="Order Qty" SortExpression="[OrderQty]"  />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="[UnitPrice]"  />
				<asp:BoundField DataField="ReceivedQty" HeaderText="Received Qty" SortExpression="[ReceivedQty]"  />
				<asp:BoundField DataField="RejectedQty" HeaderText="Rejected Qty" SortExpression="[RejectedQty]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No PurchaseOrderDetail Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnPurchaseOrderDetail" OnClientClick="javascript:location.href='PurchaseOrderDetailEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:PurchaseOrderDetailDataSource ID="PurchaseOrderDetailDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:PurchaseOrderDetailProperty Name="Product"/> 
					<data:PurchaseOrderDetailProperty Name="PurchaseOrderHeader"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:PurchaseOrderDetailDataSource>
	    		
</asp:Content>



