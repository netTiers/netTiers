
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"  CodeFile="Product.aspx.cs" Inherits="Product" Title="Product List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

		<atlas:UpdateProgress runat="server" ID="up1">
			<ProgressTemplate>
				<div id="loadinfo" style="visibility:visible;position:absolute;right:10px;top:10px;">
					<asp:Image runat="server" ID="imgLoading" ImageUrl="~/images/loading.gif" />
				</div>
			</ProgressTemplate>
		</atlas:UpdateProgress>

    <atlas:UpdatePanel runat="server" ID="UpdatePanel1" Mode="Conditional">        
        <ContentTemplate>   
		
		<netTiers:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="ProductDataSource"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
            DefaultSortColumnName="" 
            DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Product.xls"  
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"  />
				<asp:TemplateField HeaderText="Category">
				<ItemTemplate>
						<asp:Repeater ID="Id" runat="server" DataSourceID="CategoryFilter">
							<ItemTemplate>
								<%# Eval("Name") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="CategoryFilter" runat="server"
							DataSourceID="CategoryDataSource1"
							Filter='<%# String.Format("Id = {0}", Eval("CategoryId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


			</Columns>
			<EmptyDataTemplate>
				<b>No Product Found!</b>
				<asp:HyperLink runat="server" ID="hypProduct" NavigateUrl="~/admin/ProductEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</netTiers:EntityGridView>
			
		<data:EntityDataSource ID="CategoryDataSource1" runat="server"
			ProviderName="CategoryProvider"
			EntityTypeName="Entities.Category, Entities"
			EntityKeyTypeName="System.String"
			SelectMethod="GetAll"
		/>

		<data:EntityDataSource ID="ProductDataSource" runat="server"
			ProviderName="ProductProvider"
			EntityTypeName="Entities.Product, Entities"
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
		</data:EntityDataSource>
	    
		</ContentTemplate>
    </atlas:UpdatePanel>		
</asp:Content>



