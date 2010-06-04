
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="EmployeePayHistory.aspx.cs" Inherits="EmployeePayHistory" Title="EmployeePayHistory List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Employee Pay History List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="EmployeePayHistoryDataSource"
				DataKeyNames="EmployeeId, RateChangeDate"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_EmployeePayHistory.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Employee Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="EmployeeIdSource" DataTextField="NationalIdNumber" />
				<asp:BoundField DataField="RateChangeDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Rate Change Date" SortExpression="[RateChangeDate]" ReadOnly="True" />
				<asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="[Rate]"  />
				<asp:BoundField DataField="PayFrequency" HeaderText="Pay Frequency" SortExpression="[PayFrequency]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No EmployeePayHistory Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnEmployeePayHistory" OnClientClick="javascript:location.href='EmployeePayHistoryEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:EmployeePayHistoryDataSource ID="EmployeePayHistoryDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:EmployeePayHistoryProperty Name="Employee"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:EmployeePayHistoryDataSource>
	    		
</asp:Content>



