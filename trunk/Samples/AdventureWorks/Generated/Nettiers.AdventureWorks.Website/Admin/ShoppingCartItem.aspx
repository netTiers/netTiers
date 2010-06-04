
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ShoppingCartItem.aspx.cs" Inherits="ShoppingCartItem" Title="ShoppingCartItem List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Shopping Cart Item List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ShoppingCartItemDataSource"
				DataKeyNames="ShoppingCartItemId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ShoppingCartItem.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ShoppingCartId" HeaderText="Shopping Cart Id" SortExpression="[ShoppingCartID]"  />
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="[Quantity]"  />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="DateCreated" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Date Created" SortExpression="[DateCreated]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ShoppingCartItem Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnShoppingCartItem" OnClientClick="javascript:location.href='ShoppingCartItemEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ShoppingCartItemDataSource ID="ShoppingCartItemDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ShoppingCartItemProperty Name="Product"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ShoppingCartItemDataSource>
	    		
</asp:Content>



