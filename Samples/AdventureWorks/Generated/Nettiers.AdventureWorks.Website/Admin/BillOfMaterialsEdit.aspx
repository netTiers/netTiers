<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="BillOfMaterialsEdit.aspx.cs" Inherits="BillOfMaterialsEdit" Title="BillOfMaterials Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Bill Of Materials - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="BillOfMaterialsId" runat="server" DataSourceID="BillOfMaterialsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/BillOfMaterialsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/BillOfMaterialsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>BillOfMaterials not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:BillOfMaterialsDataSource ID="BillOfMaterialsDataSource" runat="server"
			SelectMethod="GetByBillOfMaterialsId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="BillOfMaterialsId" QueryStringField="BillOfMaterialsId" Type="String" />

			</Parameters>
		</data:BillOfMaterialsDataSource>
		
		<br />

		

</asp:Content>

