
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"  CodeFile="Category.aspx.cs" Inherits="Category" Title="Category List" %>

<%@ Register Namespace="NetTiers" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

		<atlas:UpdateProgress runat="server" ID="up1">
			<ProgressTemplate>
				<div id="loadinfo" style="visibility:visible;position:absolute;right:10px;top:10px;">
					<asp:Image runat="server" ID="imgLoading" ImageUrl="~/images/loading.gif" />
				</div>
			</ProgressTemplate>
		</atlas:UpdateProgress>

    <atlas:UpdatePanel runat="server" ID="UpdatePanel1" Mode="Conditional"><ContentTemplate>
<netTiers:EntityGridView id="GridView1" runat="server" ExcelExportFileName="Export_Category.xls" DefaultSortDirection="Ascending" DefaultSortColumnName="Id" AllowMultiColumnSorting="False" DataKeyNames="Id" DataSourceID="CategoryDataSource" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AutoGenerateColumns="False" AllowExportToExcel="True" ExportToExcelText="Excel" PageSelectorPageSizeInterval="5" AllowSorting="True"><EmptyDataTemplate>
				<b>No Category Found!</b>
				<asp:HyperLink runat="server" ID="hypCategory" NavigateUrl="~/admin/CategoryEdit.aspx">Add New</asp:HyperLink>
			
</EmptyDataTemplate>
<Columns>
<asp:CommandField ShowSelectButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField ReadOnly="True" DataField="Id" SortExpression="Id" HeaderText="Id"></asp:BoundField>
<asp:BoundField DataField="Name" SortExpression="Name" HeaderText="Name"></asp:BoundField>
<asp:BoundField DataField="AdvicePhoto" SortExpression="AdvicePhoto" HeaderText="AdvicePhoto"></asp:BoundField>
</Columns>
</netTiers:EntityGridView> 
<data:EntityDataSource id="CategoryDataSource" runat="server" EnableSorting="True" EnablePaging="True" SelectMethod="GetPaged" EntityTypeName="Entities.Category, Entities" ProviderName="CategoryProvider">
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



