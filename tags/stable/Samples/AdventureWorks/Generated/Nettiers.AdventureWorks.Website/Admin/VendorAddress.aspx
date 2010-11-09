
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="VendorAddress.aspx.cs" Inherits="VendorAddress" Title="VendorAddress List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Vendor Address List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="VendorAddressDataSource"
				DataKeyNames="VendorId, AddressId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_VendorAddress.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Vendor Id" DataNavigateUrlFormatString="VendorEdit.aspx?VendorId={0}" DataNavigateUrlFields="VendorId" DataContainer="VendorIdSource" DataTextField="AccountNumber" />
				<data:HyperLinkField HeaderText="Address Id" DataNavigateUrlFormatString="AddressEdit.aspx?AddressId={0}" DataNavigateUrlFields="AddressId" DataContainer="AddressIdSource" DataTextField="AddressLine1" />
				<data:HyperLinkField HeaderText="Address Type Id" DataNavigateUrlFormatString="AddressTypeEdit.aspx?AddressTypeId={0}" DataNavigateUrlFields="AddressTypeId" DataContainer="AddressTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No VendorAddress Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnVendorAddress" OnClientClick="javascript:location.href='VendorAddressEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:VendorAddressDataSource ID="VendorAddressDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:VendorAddressProperty Name="Address"/> 
					<data:VendorAddressProperty Name="AddressType"/> 
					<data:VendorAddressProperty Name="Vendor"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:VendorAddressDataSource>
	    		
</asp:Content>



