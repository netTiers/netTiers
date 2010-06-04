<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductCostHistoryEdit.aspx.cs" Inherits="ProductCostHistoryEdit" Title="ProductCostHistory Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Cost History - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ProductId, StartDate" runat="server" DataSourceID="ProductCostHistoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductCostHistoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductCostHistoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ProductCostHistory not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductCostHistoryDataSource ID="ProductCostHistoryDataSource" runat="server"
			SelectMethod="GetByProductIdStartDate"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ProductId" QueryStringField="ProductId" Type="String" />
<asp:QueryStringParameter Name="StartDate" QueryStringField="StartDate" Type="String" />

			</Parameters>
		</data:ProductCostHistoryDataSource>
		
		<br />


</asp:Content>

