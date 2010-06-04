<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="StateProvinceEdit.aspx.cs" Inherits="StateProvinceEdit" Title="StateProvince Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">State Province - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="StateProvinceId" runat="server" DataSourceID="StateProvinceDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/StateProvinceFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/StateProvinceFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>StateProvince not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:StateProvinceDataSource ID="StateProvinceDataSource" runat="server"
			SelectMethod="GetByStateProvinceId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="StateProvinceId" QueryStringField="StateProvinceId" Type="String" />

			</Parameters>
		</data:StateProvinceDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewAddress1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewAddress1_SelectedIndexChanged"			 			 
			DataSourceID="AddressDataSource1"
			DataKeyNames="AddressId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Address.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="AddressLine1" HeaderText="Address Line1" SortExpression="[AddressLine1]" />				
				<asp:BoundField DataField="AddressLine2" HeaderText="Address Line2" SortExpression="[AddressLine2]" />				
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]" />				
				<data:HyperLinkField HeaderText="State Province Id" DataNavigateUrlFormatString="StateProvinceEdit.aspx?StateProvinceId={0}" DataNavigateUrlFields="StateProvinceId" DataContainer="StateProvinceIdSource" DataTextField="StateProvinceCode" />
				<asp:BoundField DataField="PostalCode" HeaderText="Postal Code" SortExpression="[PostalCode]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Address Found! </b>
				<asp:HyperLink runat="server" ID="hypAddress" NavigateUrl="~/admin/AddressEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AddressDataSource ID="AddressDataSource1" runat="server" SelectMethod="Find"
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
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AddressFilter  Column="StateProvinceId" QueryStringField="StateProvinceId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AddressDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewSalesTaxRate2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewSalesTaxRate2_SelectedIndexChanged"			 			 
			DataSourceID="SalesTaxRateDataSource2"
			DataKeyNames="SalesTaxRateId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_SalesTaxRate.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="State Province Id" DataNavigateUrlFormatString="StateProvinceEdit.aspx?StateProvinceId={0}" DataNavigateUrlFields="StateProvinceId" DataContainer="StateProvinceIdSource" DataTextField="StateProvinceCode" />
				<asp:BoundField DataField="TaxType" HeaderText="Tax Type" SortExpression="[TaxType]" />				
				<asp:BoundField DataField="TaxRate" HeaderText="Tax Rate" SortExpression="[TaxRate]" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Sales Tax Rate Found! </b>
				<asp:HyperLink runat="server" ID="hypSalesTaxRate" NavigateUrl="~/admin/SalesTaxRateEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:SalesTaxRateDataSource ID="SalesTaxRateDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesTaxRateProperty Name="StateProvince"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:SalesTaxRateFilter  Column="StateProvinceId" QueryStringField="StateProvinceId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SalesTaxRateDataSource>		
		
		<br />
		

</asp:Content>

