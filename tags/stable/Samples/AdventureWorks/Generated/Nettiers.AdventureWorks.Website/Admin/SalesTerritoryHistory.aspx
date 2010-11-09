
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesTerritoryHistory.aspx.cs" Inherits="SalesTerritoryHistory" Title="SalesTerritoryHistory List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Territory History List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SalesTerritoryHistoryDataSource"
				DataKeyNames="SalesPersonId, StartDate, TerritoryId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SalesTerritoryHistory.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?SalesPersonId={0}" DataNavigateUrlFields="SalesPersonId" DataContainer="SalesPersonIdSource" DataTextField="SalesQuota" />
				<data:HyperLinkField HeaderText="Territory Id" DataNavigateUrlFormatString="SalesTerritoryEdit.aspx?TerritoryId={0}" DataNavigateUrlFields="TerritoryId" DataContainer="TerritoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression="[StartDate]" ReadOnly="True" />
				<asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="End Date" SortExpression="[EndDate]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SalesTerritoryHistory Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSalesTerritoryHistory" OnClientClick="javascript:location.href='SalesTerritoryHistoryEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SalesTerritoryHistoryDataSource ID="SalesTerritoryHistoryDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesTerritoryHistoryProperty Name="SalesPerson"/> 
					<data:SalesTerritoryHistoryProperty Name="SalesTerritory"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SalesTerritoryHistoryDataSource>
	    		
</asp:Content>



