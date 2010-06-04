
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PurchaseOrderHeader.aspx.cs" Inherits="PurchaseOrderHeader" Title="PurchaseOrderHeader List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Purchase Order Header List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="PurchaseOrderHeaderDataSource"
				DataKeyNames="PurchaseOrderId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_PurchaseOrderHeader.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="RevisionNumber" HeaderText="Revision Number" SortExpression="[RevisionNumber]"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="[Status]"  />
				<data:HyperLinkField HeaderText="Employee Id" DataNavigateUrlFormatString="EmployeeEdit.aspx?EmployeeId={0}" DataNavigateUrlFields="EmployeeId" DataContainer="EmployeeIdSource" DataTextField="NationalIdNumber" />
				<data:HyperLinkField HeaderText="Vendor Id" DataNavigateUrlFormatString="VendorEdit.aspx?VendorId={0}" DataNavigateUrlFields="VendorId" DataContainer="VendorIdSource" DataTextField="AccountNumber" />
				<data:HyperLinkField HeaderText="Ship Method Id" DataNavigateUrlFormatString="ShipMethodEdit.aspx?ShipMethodId={0}" DataNavigateUrlFields="ShipMethodId" DataContainer="ShipMethodIdSource" DataTextField="Name" />
				<asp:BoundField DataField="OrderDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Order Date" SortExpression="[OrderDate]"  />
				<asp:BoundField DataField="ShipDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ship Date" SortExpression="[ShipDate]"  />
				<asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="[SubTotal]"  />
				<asp:BoundField DataField="TaxAmt" HeaderText="Tax Amt" SortExpression="[TaxAmt]"  />
				<asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="[Freight]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No PurchaseOrderHeader Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnPurchaseOrderHeader" OnClientClick="javascript:location.href='PurchaseOrderHeaderEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:PurchaseOrderHeaderDataSource ID="PurchaseOrderHeaderDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:PurchaseOrderHeaderProperty Name="Employee"/> 
					<data:PurchaseOrderHeaderProperty Name="ShipMethod"/> 
					<data:PurchaseOrderHeaderProperty Name="Vendor"/> 
					<%--<data:PurchaseOrderHeaderProperty Name="PurchaseOrderDetailCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:PurchaseOrderHeaderDataSource>
	    		
</asp:Content>



