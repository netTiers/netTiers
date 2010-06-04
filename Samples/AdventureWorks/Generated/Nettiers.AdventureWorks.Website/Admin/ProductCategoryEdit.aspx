<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductCategoryEdit.aspx.cs" Inherits="ProductCategoryEdit" Title="ProductCategory Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Category - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ProductCategoryId" runat="server" DataSourceID="ProductCategoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductCategoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductCategoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ProductCategory not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductCategoryDataSource ID="ProductCategoryDataSource" runat="server"
			SelectMethod="GetByProductCategoryId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ProductCategoryId" QueryStringField="ProductCategoryId" Type="String" />

			</Parameters>
		</data:ProductCategoryDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewProductSubcategory1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewProductSubcategory1_SelectedIndexChanged"			 			 
			DataSourceID="ProductSubcategoryDataSource1"
			DataKeyNames="ProductSubcategoryId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ProductSubcategory.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Category Id" DataNavigateUrlFormatString="ProductCategoryEdit.aspx?ProductCategoryId={0}" DataNavigateUrlFields="ProductCategoryId" DataContainer="ProductCategoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Product Subcategory Found! </b>
				<asp:HyperLink runat="server" ID="hypProductSubcategory" NavigateUrl="~/admin/ProductSubcategoryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ProductSubcategoryDataSource ID="ProductSubcategoryDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductSubcategoryProperty Name="ProductCategory"/> 
					<%--<data:ProductSubcategoryProperty Name="ProductCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductSubcategoryFilter  Column="ProductCategoryId" QueryStringField="ProductCategoryId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductSubcategoryDataSource>		
		
		<br />
		

</asp:Content>

