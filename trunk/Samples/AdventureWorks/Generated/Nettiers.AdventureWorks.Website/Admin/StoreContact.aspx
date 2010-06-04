
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="StoreContact.aspx.cs" Inherits="StoreContact" Title="StoreContact List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Store Contact List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="StoreContactDataSource"
				DataKeyNames="CustomerId, ContactId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_StoreContact.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="StoreEdit.aspx?CustomerId={0}" DataNavigateUrlFields="CustomerId" DataContainer="CustomerIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Contact Id" DataNavigateUrlFormatString="ContactEdit.aspx?ContactId={0}" DataNavigateUrlFields="ContactId" DataContainer="ContactIdSource" DataTextField="NameStyle" />
				<data:HyperLinkField HeaderText="Contact Type Id" DataNavigateUrlFormatString="ContactTypeEdit.aspx?ContactTypeId={0}" DataNavigateUrlFields="ContactTypeId" DataContainer="ContactTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No StoreContact Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnStoreContact" OnClientClick="javascript:location.href='StoreContactEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:StoreContactDataSource ID="StoreContactDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:StoreContactProperty Name="Contact"/> 
					<data:StoreContactProperty Name="ContactType"/> 
					<data:StoreContactProperty Name="Store"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:StoreContactDataSource>
	    		
</asp:Content>



