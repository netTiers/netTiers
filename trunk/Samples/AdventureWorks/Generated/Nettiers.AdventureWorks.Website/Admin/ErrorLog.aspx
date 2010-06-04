
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ErrorLog.aspx.cs" Inherits="ErrorLog" Title="ErrorLog List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Error Log List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ErrorLogDataSource"
				DataKeyNames="ErrorLogId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ErrorLog.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ErrorTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Error Time" SortExpression="[ErrorTime]"  />
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]"  />
				<asp:BoundField DataField="ErrorNumber" HeaderText="Error Number" SortExpression="[ErrorNumber]"  />
				<asp:BoundField DataField="ErrorSeverity" HeaderText="Error Severity" SortExpression="[ErrorSeverity]"  />
				<asp:BoundField DataField="ErrorState" HeaderText="Error State" SortExpression="[ErrorState]"  />
				<asp:BoundField DataField="ErrorProcedure" HeaderText="Error Procedure" SortExpression="[ErrorProcedure]"  />
				<asp:BoundField DataField="ErrorLine" HeaderText="Error Line" SortExpression="[ErrorLine]"  />
				<asp:BoundField DataField="ErrorMessage" HeaderText="Error Message" SortExpression="[ErrorMessage]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ErrorLog Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnErrorLog" OnClientClick="javascript:location.href='ErrorLogEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ErrorLogDataSource ID="ErrorLogDataSource" runat="server"
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
		</data:ErrorLogDataSource>
	    		
</asp:Content>



