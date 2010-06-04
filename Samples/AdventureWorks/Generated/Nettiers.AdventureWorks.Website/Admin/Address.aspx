
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Address.aspx.cs" Inherits="Address" Title="Address List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Address List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AddressDataSource"
				DataKeyNames="AddressId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Address.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="AddressLine1" HeaderText="Address Line1" SortExpression="[AddressLine1]"  />
				<asp:BoundField DataField="AddressLine2" HeaderText="Address Line2" SortExpression="[AddressLine2]"  />
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]"  />
				<data:HyperLinkField HeaderText="State Province Id" DataNavigateUrlFormatString="StateProvinceEdit.aspx?StateProvinceId={0}" DataNavigateUrlFields="StateProvinceId" DataContainer="StateProvinceIdSource" DataTextField="StateProvinceCode" />
				<asp:BoundField DataField="PostalCode" HeaderText="Postal Code" SortExpression="[PostalCode]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Address Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAddress" OnClientClick="javascript:location.href='AddressEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AddressDataSource ID="AddressDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AddressProperty Name="StateProvince"/> 
					<%--<data:AddressProperty Name="CustomerAddressCollection" />--%>
					<%--<data:AddressProperty Name="CustomerIdCustomerCollection_From_CustomerAddress" />--%>
					<%--<data:AddressProperty Name="SalesOrderHeaderCollectionGetByBillToAddressId" />--%>
					<%--<data:AddressProperty Name="EmployeeAddressCollection" />--%>
					<%--<data:AddressProperty Name="SalesOrderHeaderCollectionGetByShipToAddressId" />--%>
					<%--<data:AddressProperty Name="VendorIdVendorCollection_From_VendorAddress" />--%>
					<%--<data:AddressProperty Name="VendorAddressCollection" />--%>
					<%--<data:AddressProperty Name="EmployeeIdEmployeeCollection_From_EmployeeAddress" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AddressDataSource>
	    		
</asp:Content>



