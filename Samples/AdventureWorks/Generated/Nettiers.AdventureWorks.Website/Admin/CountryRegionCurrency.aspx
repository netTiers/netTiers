
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CountryRegionCurrency.aspx.cs" Inherits="CountryRegionCurrency" Title="CountryRegionCurrency List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Country Region Currency List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CountryRegionCurrencyDataSource"
				DataKeyNames="CountryRegionCode, CurrencyCode"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CountryRegionCurrency.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Country Region Code" DataNavigateUrlFormatString="CountryRegionEdit.aspx?CountryRegionCode={0}" DataNavigateUrlFields="CountryRegionCode" DataContainer="CountryRegionCodeSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Currency Code" DataNavigateUrlFormatString="CurrencyEdit.aspx?CurrencyCode={0}" DataNavigateUrlFields="CurrencyCode" DataContainer="CurrencyCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CountryRegionCurrency Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCountryRegionCurrency" OnClientClick="javascript:location.href='CountryRegionCurrencyEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CountryRegionCurrencyDataSource ID="CountryRegionCurrencyDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CountryRegionCurrencyProperty Name="CountryRegion"/> 
					<data:CountryRegionCurrencyProperty Name="Currency"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CountryRegionCurrencyDataSource>
	    		
</asp:Content>



