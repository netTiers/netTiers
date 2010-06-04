
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductModelIllustration.aspx.cs" Inherits="ProductModelIllustration" Title="ProductModelIllustration List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Model Illustration List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProductModelIllustrationDataSource"
				DataKeyNames="ProductModelId, IllustrationId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ProductModelIllustration.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Product Model Id" DataNavigateUrlFormatString="ProductModelEdit.aspx?ProductModelId={0}" DataNavigateUrlFields="ProductModelId" DataContainer="ProductModelIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Illustration Id" DataNavigateUrlFormatString="IllustrationEdit.aspx?IllustrationId={0}" DataNavigateUrlFields="IllustrationId" DataContainer="IllustrationIdSource" DataTextField="Diagram" />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ProductModelIllustration Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProductModelIllustration" OnClientClick="javascript:location.href='ProductModelIllustrationEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ProductModelIllustrationDataSource ID="ProductModelIllustrationDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductModelIllustrationProperty Name="Illustration"/> 
					<data:ProductModelIllustrationProperty Name="ProductModel"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ProductModelIllustrationDataSource>
	    		
</asp:Content>



