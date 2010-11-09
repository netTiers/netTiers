<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductModelProductDescriptionCultureEdit.aspx.cs" Inherits="ProductModelProductDescriptionCultureEdit" Title="ProductModelProductDescriptionCulture Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Model Product Description Culture - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ProductModelId, ProductDescriptionId, CultureId" runat="server" DataSourceID="ProductModelProductDescriptionCultureDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductModelProductDescriptionCultureFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductModelProductDescriptionCultureFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ProductModelProductDescriptionCulture not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductModelProductDescriptionCultureDataSource ID="ProductModelProductDescriptionCultureDataSource" runat="server"
			SelectMethod="GetByProductModelIdProductDescriptionIdCultureId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ProductModelId" QueryStringField="ProductModelId" Type="String" />
<asp:QueryStringParameter Name="ProductDescriptionId" QueryStringField="ProductDescriptionId" Type="String" />
<asp:QueryStringParameter Name="CultureId" QueryStringField="CultureId" Type="String" />

			</Parameters>
		</data:ProductModelProductDescriptionCultureDataSource>
		
		<br />


</asp:Content>

