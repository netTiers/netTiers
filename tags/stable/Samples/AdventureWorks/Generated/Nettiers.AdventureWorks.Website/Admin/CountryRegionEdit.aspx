<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CountryRegionEdit.aspx.cs" Inherits="CountryRegionEdit" Title="CountryRegion Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Country Region - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="CountryRegionCode" runat="server" DataSourceID="CountryRegionDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CountryRegionFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CountryRegionFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CountryRegion not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CountryRegionDataSource ID="CountryRegionDataSource" runat="server"
			SelectMethod="GetByCountryRegionCode"
		>
			<Parameters>
				<asp:QueryStringParameter Name="CountryRegionCode" QueryStringField="CountryRegionCode" Type="String" />

			</Parameters>
		</data:CountryRegionDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewStateProvince1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewStateProvince1_SelectedIndexChanged"			 			 
			DataSourceID="StateProvinceDataSource1"
			DataKeyNames="StateProvinceId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_StateProvince.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="StateProvinceCode" HeaderText="State Province Code" SortExpression="[StateProvinceCode]" />				
				<data:HyperLinkField HeaderText="Country Region Code" DataNavigateUrlFormatString="CountryRegionEdit.aspx?CountryRegionCode={0}" DataNavigateUrlFields="CountryRegionCode" DataContainer="CountryRegionCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="IsOnlyStateProvinceFlag" HeaderText="Is Only State Province Flag" SortExpression="[IsOnlyStateProvinceFlag]" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<data:HyperLinkField HeaderText="Territory Id" DataNavigateUrlFormatString="SalesTerritoryEdit.aspx?TerritoryId={0}" DataNavigateUrlFields="TerritoryId" DataContainer="TerritoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Rowguid" HeaderText="Rowguid" SortExpression="[rowguid]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No State Province Found! </b>
				<asp:HyperLink runat="server" ID="hypStateProvince" NavigateUrl="~/admin/StateProvinceEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:StateProvinceDataSource ID="StateProvinceDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:StateProvinceProperty Name="CountryRegion"/> 
					<data:StateProvinceProperty Name="SalesTerritory"/> 
					<%--<data:StateProvinceProperty Name="AddressCollection" />--%>
					<%--<data:StateProvinceProperty Name="SalesTaxRateCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:StateProvinceFilter  Column="CountryRegionCode" QueryStringField="CountryRegionCode" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:StateProvinceDataSource>		
		
		<br />
		

</asp:Content>

