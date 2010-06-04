
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CreditCard.aspx.cs" Inherits="CreditCard" Title="CreditCard List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Credit Card List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CreditCardDataSource"
				DataKeyNames="CreditCardId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CreditCard.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="CardType" HeaderText="Card Type" SortExpression="[CardType]"  />
				<asp:BoundField DataField="CardNumber" HeaderText="Card Number" SortExpression="[CardNumber]"  />
				<asp:BoundField DataField="ExpMonth" HeaderText="Exp Month" SortExpression="[ExpMonth]"  />
				<asp:BoundField DataField="ExpYear" HeaderText="Exp Year" SortExpression="[ExpYear]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CreditCard Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCreditCard" OnClientClick="javascript:location.href='CreditCardEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CreditCardDataSource ID="CreditCardDataSource" runat="server"
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
		</data:CreditCardDataSource>
	    		
</asp:Content>



