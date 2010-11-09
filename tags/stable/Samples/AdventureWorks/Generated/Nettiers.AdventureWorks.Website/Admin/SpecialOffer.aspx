
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SpecialOffer.aspx.cs" Inherits="SpecialOffer" Title="SpecialOffer List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Special Offer List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SpecialOfferDataSource"
				DataKeyNames="SpecialOfferId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SpecialOffer.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<asp:BoundField DataField="DiscountPct" HeaderText="Discount Pct" SortExpression="[DiscountPct]"  />
				<asp:BoundField DataField="Type" HeaderText="Type" SortExpression="[Type]"  />
				<asp:BoundField DataField="Category" HeaderText="Category" SortExpression="[Category]"  />
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression="[StartDate]"  />
				<asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="End Date" SortExpression="[EndDate]"  />
				<asp:BoundField DataField="MinQty" HeaderText="Min Qty" SortExpression="[MinQty]"  />
				<asp:BoundField DataField="MaxQty" HeaderText="Max Qty" SortExpression="[MaxQty]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SpecialOffer Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSpecialOffer" OnClientClick="javascript:location.href='SpecialOfferEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SpecialOfferDataSource ID="SpecialOfferDataSource" runat="server"
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
		</data:SpecialOfferDataSource>
	    		
</asp:Content>



