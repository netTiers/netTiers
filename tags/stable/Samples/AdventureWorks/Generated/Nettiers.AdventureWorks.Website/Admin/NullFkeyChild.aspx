
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="NullFkeyChild.aspx.cs" Inherits="NullFkeyChild" Title="NullFkeyChild List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Null Fkey Child List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="NullFkeyChildDataSource"
				DataKeyNames="NullFkeyChildId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_NullFkeyChild.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="NullFkeyChildId" HeaderText="Null Fkey Child Id" SortExpression="[NullFKeyChildID]" ReadOnly="True" />
				<data:HyperLinkField HeaderText="Null Fkey Parent Id" DataNavigateUrlFormatString="NullFkeyParentEdit.aspx?NullFkeyParentId={0}" DataNavigateUrlFields="NullFkeyParentId" DataContainer="NullFkeyParentIdSource" DataTextField="SomeText" />
				<asp:BoundField DataField="SomeText" HeaderText="Some Text" SortExpression="[SomeText]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No NullFkeyChild Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnNullFkeyChild" OnClientClick="javascript:location.href='NullFkeyChildEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:NullFkeyChildDataSource ID="NullFkeyChildDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:NullFkeyChildProperty Name="NullFkeyParent"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:NullFkeyChildDataSource>
	    		
</asp:Content>



