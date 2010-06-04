
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CurrencyRate.aspx.cs" Inherits="CurrencyRate" Title="CurrencyRate List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Currency Rate List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CurrencyRateDataSource"
				DataKeyNames="CurrencyRateId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CurrencyRate.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="CurrencyRateDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Currency Rate Date" SortExpression="[CurrencyRateDate]"  />
				<data:HyperLinkField HeaderText="From Currency Code" DataNavigateUrlFormatString="CurrencyEdit.aspx?CurrencyCode={0}" DataNavigateUrlFields="CurrencyCode" DataContainer="FromCurrencyCodeSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="To Currency Code" DataNavigateUrlFormatString="CurrencyEdit.aspx?CurrencyCode={0}" DataNavigateUrlFields="CurrencyCode" DataContainer="ToCurrencyCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="AverageRate" HeaderText="Average Rate" SortExpression="[AverageRate]"  />
				<asp:BoundField DataField="EndOfDayRate" HeaderText="End Of Day Rate" SortExpression="[EndOfDayRate]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CurrencyRate Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCurrencyRate" OnClientClick="javascript:location.href='CurrencyRateEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CurrencyRateDataSource ID="CurrencyRateDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CurrencyRateProperty Name="Currency"/> 
					<%--<data:CurrencyRateProperty Name="SalesOrderHeaderCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CurrencyRateDataSource>
	    		
</asp:Content>



