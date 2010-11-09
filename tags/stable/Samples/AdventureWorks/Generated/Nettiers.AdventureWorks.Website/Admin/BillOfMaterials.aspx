
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="BillOfMaterials.aspx.cs" Inherits="BillOfMaterials" Title="BillOfMaterials List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Bill Of Materials List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="BillOfMaterialsDataSource"
				DataKeyNames="BillOfMaterialsId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_BillOfMaterials.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Product Assembly Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductAssemblyIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Component Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ComponentIdSource" DataTextField="Name" />
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression="[StartDate]"  />
				<asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="End Date" SortExpression="[EndDate]"  />
				<data:HyperLinkField HeaderText="Unit Measure Code" DataNavigateUrlFormatString="UnitMeasureEdit.aspx?UnitMeasureCode={0}" DataNavigateUrlFields="UnitMeasureCode" DataContainer="UnitMeasureCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="BomLevel" HeaderText="Bom Level" SortExpression="[BOMLevel]"  />
				<asp:BoundField DataField="PerAssemblyQty" HeaderText="Per Assembly Qty" SortExpression="[PerAssemblyQty]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No BillOfMaterials Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnBillOfMaterials" OnClientClick="javascript:location.href='BillOfMaterialsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:BillOfMaterialsDataSource ID="BillOfMaterialsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:BillOfMaterialsProperty Name="Product"/> 
					<data:BillOfMaterialsProperty Name="UnitMeasure"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:BillOfMaterialsDataSource>
	    		
</asp:Content>



