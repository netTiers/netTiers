
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductModelProductDescriptionCulture.aspx.cs" Inherits="ProductModelProductDescriptionCulture" Title="ProductModelProductDescriptionCulture List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Model Product Description Culture List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProductModelProductDescriptionCultureDataSource"
				DataKeyNames="ProductModelId, ProductDescriptionId, CultureId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ProductModelProductDescriptionCulture.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Product Model Id" DataNavigateUrlFormatString="ProductModelEdit.aspx?ProductModelId={0}" DataNavigateUrlFields="ProductModelId" DataContainer="ProductModelIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Description Id" DataNavigateUrlFormatString="ProductDescriptionEdit.aspx?ProductDescriptionId={0}" DataNavigateUrlFields="ProductDescriptionId" DataContainer="ProductDescriptionIdSource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Culture Id" DataNavigateUrlFormatString="CultureEdit.aspx?CultureId={0}" DataNavigateUrlFields="CultureId" DataContainer="CultureIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ProductModelProductDescriptionCulture Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProductModelProductDescriptionCulture" OnClientClick="javascript:location.href='ProductModelProductDescriptionCultureEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ProductModelProductDescriptionCultureDataSource ID="ProductModelProductDescriptionCultureDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductModelProductDescriptionCultureProperty Name="Culture"/> 
					<data:ProductModelProductDescriptionCultureProperty Name="ProductDescription"/> 
					<data:ProductModelProductDescriptionCultureProperty Name="ProductModel"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ProductModelProductDescriptionCultureDataSource>
	    		
</asp:Content>



