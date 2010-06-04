
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductVendor.aspx.cs" Inherits="ProductVendor" Title="ProductVendor List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Vendor List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProductVendorDataSource"
				DataKeyNames="ProductId, VendorId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ProductVendor.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Vendor Id" DataNavigateUrlFormatString="VendorEdit.aspx?VendorId={0}" DataNavigateUrlFields="VendorId" DataContainer="VendorIdSource" DataTextField="AccountNumber" />
				<asp:BoundField DataField="AverageLeadTime" HeaderText="Average Lead Time" SortExpression="[AverageLeadTime]"  />
				<asp:BoundField DataField="StandardPrice" HeaderText="Standard Price" SortExpression="[StandardPrice]"  />
				<asp:BoundField DataField="LastReceiptCost" HeaderText="Last Receipt Cost" SortExpression="[LastReceiptCost]"  />
				<asp:BoundField DataField="LastReceiptDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Receipt Date" SortExpression="[LastReceiptDate]"  />
				<asp:BoundField DataField="MinOrderQty" HeaderText="Min Order Qty" SortExpression="[MinOrderQty]"  />
				<asp:BoundField DataField="MaxOrderQty" HeaderText="Max Order Qty" SortExpression="[MaxOrderQty]"  />
				<asp:BoundField DataField="OnOrderQty" HeaderText="On Order Qty" SortExpression="[OnOrderQty]"  />
				<data:HyperLinkField HeaderText="Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="UnitMeasureCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ProductVendor Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProductVendor" OnClientClick="javascript:location.href='ProductVendorEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ProductVendorDataSource ID="ProductVendorDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductVendorProperty Name="Product"/> 
					<data:ProductVendorProperty Name="UnitMeasure"/> 
					<data:ProductVendorProperty Name="Vendor"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ProductVendorDataSource>
	    		
</asp:Content>



