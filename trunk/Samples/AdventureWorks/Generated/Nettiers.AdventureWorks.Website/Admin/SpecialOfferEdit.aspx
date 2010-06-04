<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SpecialOfferEdit.aspx.cs" Inherits="SpecialOfferEdit" Title="SpecialOffer Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Special Offer - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SpecialOfferId" runat="server" DataSourceID="SpecialOfferDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SpecialOfferFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SpecialOfferFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SpecialOffer not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SpecialOfferDataSource ID="SpecialOfferDataSource" runat="server"
			SelectMethod="GetBySpecialOfferId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SpecialOfferId" QueryStringField="SpecialOfferId" Type="String" />

			</Parameters>
		</data:SpecialOfferDataSource>
		
		<br />

		

</asp:Content>

