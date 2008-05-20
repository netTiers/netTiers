
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"  CodeFile="Item.aspx.cs" Inherits="Item" Title="Item List" %>

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
			DataSourceID="ItemDataSource"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
            DefaultSortColumnName="" 
            DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Item.xls"  
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"  />
				<asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"  />
				<asp:BoundField DataField="Currency" HeaderText="Currency" SortExpression="Currency"  />
				<asp:BoundField DataField="Photo" HeaderText="Photo" SortExpression="Photo"  />
				<asp:TemplateField HeaderText="Product">
				<ItemTemplate>
						<asp:Repeater ID="Id" runat="server" DataSourceID="ProductFilter">
							<ItemTemplate>
								<%# Eval("Name") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="ProductFilter" runat="server"
							DataSourceID="ProductDataSource1"
							Filter='<%# String.Format("Id = {0}", Eval("ProductId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


			</Columns>
			<EmptyDataTemplate>
				<b>No Item Found!</b>
				<asp:HyperLink runat="server" ID="hypItem" NavigateUrl="~/admin/ItemEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</netTiers:EntityGridView>
			
		<data:EntityDataSource ID="ProductDataSource1" runat="server"
			ProviderName="ProductProvider"
			EntityTypeName="Entities.Product, Entities"
			EntityKeyTypeName="System.String"
			SelectMethod="GetAll"
		/>

		<data:EntityDataSource ID="ItemDataSource" runat="server"
			ProviderName="ItemProvider"
			EntityTypeName="Entities.Item, Entities"
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



