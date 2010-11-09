<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SpecialOfferProductEdit.aspx.cs" Inherits="SpecialOfferProductEdit" Title="SpecialOfferProduct Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Special Offer Product - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SpecialOfferId, ProductId" runat="server" DataSourceID="SpecialOfferProductDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SpecialOfferProductFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SpecialOfferProductFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SpecialOfferProduct not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SpecialOfferProductDataSource ID="SpecialOfferProductDataSource" runat="server"
			SelectMethod="GetBySpecialOfferIdProductId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SpecialOfferId" QueryStringField="SpecialOfferId" Type="String" />
<asp:QueryStringParameter Name="ProductId" QueryStringField="ProductId" Type="String" />

			</Parameters>
		</data:SpecialOfferProductDataSource>
		
		<br />


</asp:Content>

