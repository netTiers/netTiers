
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Document.aspx.cs" Inherits="Document" Title="Document List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Document List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DocumentDataSource"
				DataKeyNames="DocumentId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Document.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="[Title]"  />
				<asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="[FileName]"  />
				<asp:BoundField DataField="FileExtension" HeaderText="File Extension" SortExpression="[FileExtension]"  />
				<asp:BoundField DataField="Revision" HeaderText="Revision" SortExpression="[Revision]"  />
				<asp:BoundField DataField="ChangeNumber" HeaderText="Change Number" SortExpression="[ChangeNumber]"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="[Status]"  />
				<asp:BoundField DataField="DocumentSummary" HeaderText="Document Summary" SortExpression="[DocumentSummary]"  />
				<asp:BoundField DataField="Document" HeaderText="Document" SortExpression="[Document]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Document Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDocument" OnClientClick="javascript:location.href='DocumentEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DocumentDataSource ID="DocumentDataSource" runat="server"
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
		</data:DocumentDataSource>
	    		
</asp:Content>



