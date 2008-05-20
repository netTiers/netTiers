
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"  CodeFile="CreditCard.aspx.cs" Inherits="CreditCard" Title="CreditCard List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

		<atlas:UpdateProgress runat="server" ID="up1">
			<ProgressTemplate>
				<div id="loadinfo" style="visibility:visible;position:absolute;right:10px;top:10px;">
					<asp:Image runat="server" ID="imgLoading" ImageUrl="~/images/loading.gif" />
				</div>
			</ProgressTemplate>
		</atlas:UpdateProgress>

    <atlas:UpdatePanel runat="server" ID="UpdatePanel1" Mode="Conditional">        
        <ContentTemplate>   
		
		<netTiers:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="CreditCardDataSource"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
            DefaultSortColumnName="" 
            DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CreditCard.xls"  
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly />
				<asp:BoundField DataField="Number" HeaderText="Number" SortExpression="Number"  />
				<asp:BoundField DataField="CardType" HeaderText="CardType" SortExpression="CardType"  />
				<asp:BoundField DataField="ExpiryMonth" HeaderText="ExpiryMonth" SortExpression="ExpiryMonth"  />
				<asp:BoundField DataField="ExpiryYear" HeaderText="ExpiryYear" SortExpression="ExpiryYear"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CreditCard Found!</b>
				<asp:HyperLink runat="server" ID="hypCreditCard" NavigateUrl="~/admin/CreditCardEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</netTiers:EntityGridView>
			
		<data:EntityDataSource ID="CreditCardDataSource" runat="server"
			ProviderName="CreditCardProvider"
			EntityTypeName="Entities.CreditCard, Entities"
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
		</data:EntityDataSource>
	    
		</ContentTemplate>
    </atlas:UpdatePanel>		
</asp:Content>



