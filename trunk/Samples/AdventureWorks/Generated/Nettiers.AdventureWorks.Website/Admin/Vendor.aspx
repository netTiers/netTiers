
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Vendor.aspx.cs" Inherits="Vendor" Title="Vendor List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Vendor List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="VendorDataSource"
				DataKeyNames="VendorId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Vendor.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="AccountNumber" HeaderText="Account Number" SortExpression="[AccountNumber]"  />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="CreditRating" HeaderText="Credit Rating" SortExpression="[CreditRating]"  />
				<data:BoundRadioButtonField DataField="PreferredVendorStatus" HeaderText="Preferred Vendor Status" SortExpression="[PreferredVendorStatus]"  />
				<data:BoundRadioButtonField DataField="ActiveFlag" HeaderText="Active Flag" SortExpression="[ActiveFlag]"  />
				<asp:BoundField DataField="PurchasingWebServiceUrl" HeaderText="Purchasing Web Service Url" SortExpression="[PurchasingWebServiceURL]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Vendor Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnVendor" OnClientClick="javascript:location.href='VendorEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:VendorDataSource ID="VendorDataSource" runat="server"
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
		</data:VendorDataSource>
	    		
</asp:Content>



