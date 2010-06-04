<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductModelIllustrationEdit.aspx.cs" Inherits="ProductModelIllustrationEdit" Title="ProductModelIllustration Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Model Illustration - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ProductModelId, IllustrationId" runat="server" DataSourceID="ProductModelIllustrationDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductModelIllustrationFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductModelIllustrationFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ProductModelIllustration not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductModelIllustrationDataSource ID="ProductModelIllustrationDataSource" runat="server"
			SelectMethod="GetByProductModelIdIllustrationId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ProductModelId" QueryStringField="ProductModelId" Type="String" />
<asp:QueryStringParameter Name="IllustrationId" QueryStringField="IllustrationId" Type="String" />

			</Parameters>
		</data:ProductModelIllustrationDataSource>
		
		<br />


</asp:Content>

