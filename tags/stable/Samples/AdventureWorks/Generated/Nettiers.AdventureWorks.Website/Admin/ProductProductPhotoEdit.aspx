<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductProductPhotoEdit.aspx.cs" Inherits="ProductProductPhotoEdit" Title="ProductProductPhoto Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Product Photo - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ProductId, ProductPhotoId" runat="server" DataSourceID="ProductProductPhotoDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductProductPhotoFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductProductPhotoFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ProductProductPhoto not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductProductPhotoDataSource ID="ProductProductPhotoDataSource" runat="server"
			SelectMethod="GetByProductIdProductPhotoId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ProductId" QueryStringField="ProductId" Type="String" />
<asp:QueryStringParameter Name="ProductPhotoId" QueryStringField="ProductPhotoId" Type="String" />

			</Parameters>
		</data:ProductProductPhotoDataSource>
		
		<br />


</asp:Content>

