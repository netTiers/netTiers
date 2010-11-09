<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductListPriceHistoryEdit.aspx.cs" Inherits="ProductListPriceHistoryEdit" Title="ProductListPriceHistory Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product List Price History - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ProductId, StartDate" runat="server" DataSourceID="ProductListPriceHistoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductListPriceHistoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductListPriceHistoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ProductListPriceHistory not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductListPriceHistoryDataSource ID="ProductListPriceHistoryDataSource" runat="server"
			SelectMethod="GetByProductIdStartDate"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ProductId" QueryStringField="ProductId" Type="String" />
<asp:QueryStringParameter Name="StartDate" QueryStringField="StartDate" Type="String" />

			</Parameters>
		</data:ProductListPriceHistoryDataSource>
		
		<br />


</asp:Content>

