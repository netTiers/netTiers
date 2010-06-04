
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DatabaseLog.aspx.cs" Inherits="DatabaseLog" Title="DatabaseLog List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Database Log List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DatabaseLogDataSource"
				DataKeyNames="DatabaseLogId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DatabaseLog.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="PostTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Post Time" SortExpression="[PostTime]"  />
				<asp:BoundField DataField="DatabaseUser" HeaderText="Database User" SortExpression="[DatabaseUser]"  />
				<asp:BoundField DataField="SafeNameEvent" HeaderText="Event" SortExpression="[Event]"  />
				<asp:BoundField DataField="Schema" HeaderText="Schema" SortExpression="[Schema]"  />
				<asp:BoundField DataField="SafeNameObject" HeaderText="Object" SortExpression="[Object]"  />
				<asp:BoundField DataField="Tsql" HeaderText="Tsql" SortExpression="[TSQL]"  />

			</Columns>
			<EmptyDataTemplate>
				<b>No DatabaseLog Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDatabaseLog" OnClientClick="javascript:location.href='DatabaseLogEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DatabaseLogDataSource ID="DatabaseLogDataSource" runat="server"
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
		</data:DatabaseLogDataSource>
	    		
</asp:Content>



