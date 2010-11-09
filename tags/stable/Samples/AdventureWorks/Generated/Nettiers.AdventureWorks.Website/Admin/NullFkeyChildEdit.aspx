<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="NullFkeyChildEdit.aspx.cs" Inherits="NullFkeyChildEdit" Title="NullFkeyChild Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Null Fkey Child - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="NullFkeyChildId" runat="server" DataSourceID="NullFkeyChildDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/NullFkeyChildFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/NullFkeyChildFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>NullFkeyChild not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:NullFkeyChildDataSource ID="NullFkeyChildDataSource" runat="server"
			SelectMethod="GetByNullFkeyChildId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="NullFkeyChildId" QueryStringField="NullFkeyChildId" Type="String" />

			</Parameters>
		</data:NullFkeyChildDataSource>
		
		<br />

		

</asp:Content>

