
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesOrderHeaderSalesReason.aspx.cs" Inherits="SalesOrderHeaderSalesReason" Title="SalesOrderHeaderSalesReason List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Order Header Sales Reason List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SalesOrderHeaderSalesReasonDataSource"
				DataKeyNames="SalesOrderId, SalesReasonId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SalesOrderHeaderSalesReason.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Sales Order Id" DataNavigateUrlFormatString="SalesOrderHeaderEdit.aspx?SalesOrderId={0}" DataNavigateUrlFields="SalesOrderId" DataContainer="SalesOrderIdSource" DataTextField="RevisionNumber" />
				<data:HyperLinkField HeaderText="Sales Reason Id" DataNavigateUrlFormatString="SalesReasonEdit.aspx?SalesReasonId={0}" DataNavigateUrlFields="SalesReasonId" DataContainer="SalesReasonIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SalesOrderHeaderSalesReason Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSalesOrderHeaderSalesReason" OnClientClick="javascript:location.href='SalesOrderHeaderSalesReasonEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SalesOrderHeaderSalesReasonDataSource ID="SalesOrderHeaderSalesReasonDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesOrderHeaderSalesReasonProperty Name="SalesOrderHeader"/> 
					<data:SalesOrderHeaderSalesReasonProperty Name="SalesReason"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SalesOrderHeaderSalesReasonDataSource>
	    		
</asp:Content>



