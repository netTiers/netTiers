<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesOrderHeaderEdit.aspx.cs" Inherits="SalesOrderHeaderEdit" Title="SalesOrderHeader Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Order Header - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SalesOrderId" runat="server" DataSourceID="SalesOrderHeaderDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesOrderHeaderFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesOrderHeaderFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SalesOrderHeader not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SalesOrderHeaderDataSource ID="SalesOrderHeaderDataSource" runat="server"
			SelectMethod="GetBySalesOrderId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SalesOrderId" QueryStringField="SalesOrderId" Type="String" />

			</Parameters>
		</data:SalesOrderHeaderDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewSalesOrderDetail1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewSalesOrderDetail1_SelectedIndexChanged"			 			 
			DataSourceID="SalesOrderDetailDataSource1"
			DataKeyNames="SalesOrderId, SalesOrderDetailId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_SalesOrderDetail.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Sales Order Id" DataNavigateUrlFormatString="SalesOrderHeaderEdit.aspx?SalesOrderId={0}" DataNavigateUrlFields="SalesOrderId" DataContainer="SalesOrderIdSource" DataTextField="RevisionNumber" />
				<asp:BoundField DataField="CarrierTrackingNumber" HeaderText="Carrier Tracking Number" SortExpression="[CarrierTrackingNumber]" />				
				<asp:BoundField DataField="OrderQty" HeaderText="Order Qty" SortExpression="[OrderQty]" />				

				<data:HyperLinkField HeaderText="Special Offer Id" DataNavigateUrlFormatString="SpecialOfferProductEdit.aspx?SpecialOfferId={0}" DataNavigateUrlFields="SpecialOfferId" DataContainer="SpecialOfferIdSource" DataTextField="Rowguid" />
				<asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="[UnitPrice]" />				
				<asp:BoundField DataField="UnitPriceDiscount" HeaderText="Unit Price Discount" SortExpression="[UnitPriceDiscount]" />				
				<asp:BoundField DataField="LineTotal" HeaderText="Line Total" SortExpression="[LineTotal]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Sales Order Detail Found! </b>
				<asp:HyperLink runat="server" ID="hypSalesOrderDetail" NavigateUrl="~/admin/SalesOrderDetailEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:SalesOrderDetailDataSource ID="SalesOrderDetailDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesOrderDetailProperty Name="SalesOrderHeader"/> 
					<data:SalesOrderDetailProperty Name="SpecialOfferProduct"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:SalesOrderDetailFilter  Column="SalesOrderId" QueryStringField="SalesOrderId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesOrderDetailDataSource>		
		
		<br />
		

</asp:Content>

