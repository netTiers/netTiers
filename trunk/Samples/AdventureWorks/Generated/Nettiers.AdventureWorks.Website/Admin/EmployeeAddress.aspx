
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="EmployeeAddress.aspx.cs" Inherits="EmployeeAddress" Title="EmployeeAddress List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Employee Address List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="EmployeeAddressDataSource"
				DataKeyNames="EmployeeId, AddressId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_EmployeeAddress.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Employee Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="EmployeeIdSource" DataTextField="NationalIdNumber" />
				<data:HyperLinkField HeaderText="Address Id" DataNavigateUrlFormatString="AddressEdit.aspx?AddressId={0}" DataNavigateUrlFields="AddressId" DataContainer="AddressIdSource" DataTextField="AddressLine1" />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No EmployeeAddress Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnEmployeeAddress" OnClientClick="javascript:location.href='EmployeeAddressEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:EmployeeAddressDataSource ID="EmployeeAddressDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:EmployeeAddressProperty Name="Address"/> 
					<data:EmployeeAddressProperty Name="Employee"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:EmployeeAddressDataSource>
	    		
</asp:Content>



