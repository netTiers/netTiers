
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesTerritory.aspx.cs" Inherits="SalesTerritory" Title="SalesTerritory List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Territory List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SalesTerritoryDataSource"
				DataKeyNames="TerritoryId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SalesTerritory.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="CountryRegionCode" HeaderText="Country Region Code" SortExpression="[CountryRegionCode]"  />
				<asp:BoundField DataField="Group" HeaderText="Group" SortExpression="[Group]"  />
				<asp:BoundField DataField="SalesYtd" HeaderText="Sales Ytd" SortExpression="[SalesYTD]"  />
				<asp:BoundField DataField="SalesLastYear" HeaderText="Sales Last Year" SortExpression="[SalesLastYear]"  />
				<asp:BoundField DataField="CostYtd" HeaderText="Cost Ytd" SortExpression="[CostYTD]"  />
				<asp:BoundField DataField="CostLastYear" HeaderText="Cost Last Year" SortExpression="[CostLastYear]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SalesTerritory Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSalesTerritory" OnClientClick="javascript:location.href='SalesTerritoryEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SalesTerritoryDataSource ID="SalesTerritoryDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SalesTerritoryDataSource>
	    		
</asp:Content>



