<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CountryRegionCurrencyEdit.aspx.cs" Inherits="CountryRegionCurrencyEdit" Title="CountryRegionCurrency Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Country Region Currency - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="CountryRegionCode, CurrencyCode" runat="server" DataSourceID="CountryRegionCurrencyDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CountryRegionCurrencyFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CountryRegionCurrencyFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CountryRegionCurrency not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CountryRegionCurrencyDataSource ID="CountryRegionCurrencyDataSource" runat="server"
			SelectMethod="GetByCountryRegionCodeCurrencyCode"
		>
			<Parameters>
				<asp:QueryStringParameter Name="CountryRegionCode" QueryStringField="CountryRegionCode" Type="String" />
<asp:QueryStringParameter Name="CurrencyCode" QueryStringField="CurrencyCode" Type="String" />

			</Parameters>
		</data:CountryRegionCurrencyDataSource>
		
		<br />


</asp:Content>

