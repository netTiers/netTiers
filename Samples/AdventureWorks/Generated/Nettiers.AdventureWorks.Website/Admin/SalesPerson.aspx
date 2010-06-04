
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesPerson.aspx.cs" Inherits="SalesPerson" Title="SalesPerson List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Person List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SalesPersonDataSource"
				DataKeyNames="SalesPersonId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SalesPerson.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="SalesPersonIdSource" DataTextField="NationalIdNumber" />
				<data:HyperLinkField HeaderText="Territory Id" DataNavigateUrlFormatString="SalesTerritoryEdit.aspx?TerritoryId={0}" DataNavigateUrlFields="TerritoryId" DataContainer="TerritoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="SalesQuota" HeaderText="Sales Quota" SortExpression="[SalesQuota]"  />
				<asp:BoundField DataField="Bonus" HeaderText="Bonus" SortExpression="[Bonus]"  />
				<asp:BoundField DataField="CommissionPct" HeaderText="Commission Pct" SortExpression="[CommissionPct]"  />
				<asp:BoundField DataField="SalesYtd" HeaderText="Sales Ytd" SortExpression="[SalesYTD]"  />
				<asp:BoundField DataField="SalesLastYear" HeaderText="Sales Last Year" SortExpression="[SalesLastYear]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SalesPerson Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSalesPerson" OnClientClick="javascript:location.href='SalesPersonEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SalesPersonDataSource ID="SalesPersonDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesPersonProperty Name="Employee"/> 
					<data:SalesPersonProperty Name="SalesTerritory"/> 
					<%--<data:SalesPersonProperty Name="StoreCollection" />--%>
					<%--<data:SalesPersonProperty Name="SalesPersonQuotaHistoryCollection" />--%>
					<%--<data:SalesPersonProperty Name="SalesOrderHeaderCollection" />--%>
					<%--<data:SalesPersonProperty Name="SalesTerritoryHistoryCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SalesPersonDataSource>
	    		
</asp:Content>



