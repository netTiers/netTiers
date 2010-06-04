<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductDescriptionEdit.aspx.cs" Inherits="ProductDescriptionEdit" Title="ProductDescription Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Description - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ProductDescriptionId" runat="server" DataSourceID="ProductDescriptionDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductDescriptionFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductDescriptionFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ProductDescription not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductDescriptionDataSource ID="ProductDescriptionDataSource" runat="server"
			SelectMethod="GetByProductDescriptionId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ProductDescriptionId" QueryStringField="ProductDescriptionId" Type="String" />

			</Parameters>
		</data:ProductDescriptionDataSource>
		
		<br />

		

</asp:Content>

