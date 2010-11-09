<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesTerritoryHistoryEdit.aspx.cs" Inherits="SalesTerritoryHistoryEdit" Title="SalesTerritoryHistory Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Territory History - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SalesPersonId, StartDate, TerritoryId" runat="server" DataSourceID="SalesTerritoryHistoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesTerritoryHistoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesTerritoryHistoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SalesTerritoryHistory not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SalesTerritoryHistoryDataSource ID="SalesTerritoryHistoryDataSource" runat="server"
			SelectMethod="GetBySalesPersonIdStartDateTerritoryId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SalesPersonId" QueryStringField="SalesPersonId" Type="String" />
<asp:QueryStringParameter Name="StartDate" QueryStringField="StartDate" Type="String" />
<asp:QueryStringParameter Name="TerritoryId" QueryStringField="TerritoryId" Type="String" />

			</Parameters>
		</data:SalesTerritoryHistoryDataSource>
		
		<br />


</asp:Content>

