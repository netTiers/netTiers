<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DatabaseLogEdit.aspx.cs" Inherits="DatabaseLogEdit" Title="DatabaseLog Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Database Log - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="DatabaseLogId" runat="server" DataSourceID="DatabaseLogDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DatabaseLogFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DatabaseLogFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>DatabaseLog not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DatabaseLogDataSource ID="DatabaseLogDataSource" runat="server"
			SelectMethod="GetByDatabaseLogId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="DatabaseLogId" QueryStringField="DatabaseLogId" Type="String" />

			</Parameters>
		</data:DatabaseLogDataSource>
		
		<br />

		

</asp:Content>

