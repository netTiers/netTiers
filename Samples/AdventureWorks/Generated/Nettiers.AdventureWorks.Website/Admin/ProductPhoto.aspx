
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductPhoto.aspx.cs" Inherits="ProductPhoto" Title="ProductPhoto List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Photo List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProductPhotoDataSource"
				DataKeyNames="ProductPhotoId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ProductPhoto.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ThumbNailPhoto" HeaderText="Thumb Nail Photo" SortExpression="[ThumbNailPhoto]"  />
				<asp:BoundField DataField="ThumbnailPhotoFileName" HeaderText="Thumbnail Photo File Name" SortExpression="[ThumbnailPhotoFileName]"  />
				<asp:BoundField DataField="LargePhoto" HeaderText="Large Photo" SortExpression="[LargePhoto]"  />
				<asp:BoundField DataField="LargePhotoFileName" HeaderText="Large Photo File Name" SortExpression="[LargePhotoFileName]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ProductPhoto Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProductPhoto" OnClientClick="javascript:location.href='ProductPhotoEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ProductPhotoDataSource ID="ProductPhotoDataSource" runat="server"
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
		</data:ProductPhotoDataSource>
	    		
</asp:Content>



