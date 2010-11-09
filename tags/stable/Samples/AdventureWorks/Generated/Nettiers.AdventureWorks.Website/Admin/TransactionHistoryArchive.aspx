
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TransactionHistoryArchive.aspx.cs" Inherits="TransactionHistoryArchive" Title="TransactionHistoryArchive List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Transaction History Archive List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TransactionHistoryArchiveDataSource"
				DataKeyNames="TransactionId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_TransactionHistoryArchive.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="TransactionId" HeaderText="Transaction Id" SortExpression="[TransactionID]" ReadOnly="True" />
				<asp:BoundField DataField="ProductId" HeaderText="Product Id" SortExpression="[ProductID]"  />
				<asp:BoundField DataField="ReferenceOrderId" HeaderText="Reference Order Id" SortExpression="[ReferenceOrderID]"  />
				<asp:BoundField DataField="ReferenceOrderLineId" HeaderText="Reference Order Line Id" SortExpression="[ReferenceOrderLineID]"  />
				<asp:BoundField DataField="TransactionDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Transaction Date" SortExpression="[TransactionDate]"  />
				<asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" SortExpression="[TransactionType]"  />
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="[Quantity]"  />
				<asp:BoundField DataField="ActualCost" HeaderText="Actual Cost" SortExpression="[ActualCost]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No TransactionHistoryArchive Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTransactionHistoryArchive" OnClientClick="javascript:location.href='TransactionHistoryArchiveEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:TransactionHistoryArchiveDataSource ID="TransactionHistoryArchiveDataSource" runat="server"
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
		</data:TransactionHistoryArchiveDataSource>
	    		
</asp:Content>



