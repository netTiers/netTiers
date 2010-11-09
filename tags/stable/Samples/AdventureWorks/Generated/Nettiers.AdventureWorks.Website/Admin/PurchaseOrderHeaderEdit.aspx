<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PurchaseOrderHeaderEdit.aspx.cs" Inherits="PurchaseOrderHeaderEdit" Title="PurchaseOrderHeader Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Purchase Order Header - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="PurchaseOrderId" runat="server" DataSourceID="PurchaseOrderHeaderDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PurchaseOrderHeaderFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PurchaseOrderHeaderFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>PurchaseOrderHeader not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:PurchaseOrderHeaderDataSource ID="PurchaseOrderHeaderDataSource" runat="server"
			SelectMethod="GetByPurchaseOrderId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="PurchaseOrderId" QueryStringField="PurchaseOrderId" Type="String" />

			</Parameters>
		</data:PurchaseOrderHeaderDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewPurchaseOrderDetail1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewPurchaseOrderDetail1_SelectedIndexChanged"			 			 
			DataSourceID="PurchaseOrderDetailDataSource1"
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
		
		<data:PurchaseOrderDetailDataSource ID="PurchaseOrderDetailDataSource1" runat="server" SelectMethod="Find"
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
						<data:PurchaseOrderDetailFilter  Column="PurchaseOrderId" QueryStringField="PurchaseOrderId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:PurchaseOrderDetailDataSource>		
		
		<br />
		

</asp:Content>

