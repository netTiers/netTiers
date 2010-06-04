
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductListPriceHistory.aspx.cs" Inherits="ProductListPriceHistory" Title="ProductListPriceHistory List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product List Price History List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProductListPriceHistoryDataSource"
				DataKeyNames="ProductId, StartDate"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ProductListPriceHistory.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression="[StartDate]" ReadOnly="True" />
				<asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="End Date" SortExpression="[EndDate]"  />
				<asp:BoundField DataField="ListPrice" HeaderText="List Price" SortExpression="[ListPrice]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ProductListPriceHistory Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProductListPriceHistory" OnClientClick="javascript:location.href='ProductListPriceHistoryEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ProductListPriceHistoryDataSource ID="ProductListPriceHistoryDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductListPriceHistoryProperty Name="Product"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ProductListPriceHistoryDataSource>
	    		
</asp:Content>



