
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="StateProvince.aspx.cs" Inherits="StateProvince" Title="StateProvince List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">State Province List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="StateProvinceDataSource"
				DataKeyNames="StateProvinceId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_StateProvince.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="StateProvinceCode" HeaderText="State Province Code" SortExpression="[StateProvinceCode]"  />
				<data:HyperLinkField HeaderText="Country Region Code" DataNavigateUrlFormatString="CountryRegionEdit.aspx?CountryRegionCode={0}" DataNavigateUrlFields="CountryRegionCode" DataContainer="CountryRegionCodeSource" DataTextField="Name" />
				<data:BoundRadioButtonField DataField="IsOnlyStateProvinceFlag" HeaderText="Is Only State Province Flag" SortExpression="[IsOnlyStateProvinceFlag]"  />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<data:HyperLinkField HeaderText="Territory Id" DataNavigateUrlFormatString="SalesTerritoryEdit.aspx?TerritoryId={0}" DataNavigateUrlFields="TerritoryId" DataContainer="TerritoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No StateProvince Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnStateProvince" OnClientClick="javascript:location.href='StateProvinceEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:StateProvinceDataSource ID="StateProvinceDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:StateProvinceProperty Name="CountryRegion"/> 
					<data:StateProvinceProperty Name="SalesTerritory"/> 
					<%--<data:StateProvinceProperty Name="AddressCollection" />--%>
					<%--<data:StateProvinceProperty Name="SalesTaxRateCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:StateProvinceDataSource>
	    		
</asp:Content>



