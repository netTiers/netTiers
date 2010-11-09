<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AwBuildVersionEdit.aspx.cs" Inherits="AwBuildVersionEdit" Title="AwBuildVersion Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aw Build Version - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SystemInformationId" runat="server" DataSourceID="AwBuildVersionDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AwBuildVersionFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AwBuildVersionFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AwBuildVersion not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AwBuildVersionDataSource ID="AwBuildVersionDataSource" runat="server"
			SelectMethod="GetBySystemInformationId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SystemInformationId" QueryStringField="SystemInformationId" Type="String" />

			</Parameters>
		</data:AwBuildVersionDataSource>
		
		<br />

		

</asp:Content>

