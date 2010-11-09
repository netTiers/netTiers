<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesPersonQuotaHistoryEdit.aspx.cs" Inherits="SalesPersonQuotaHistoryEdit" Title="SalesPersonQuotaHistory Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Person Quota History - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="SalesPersonId, QuotaDate" runat="server" DataSourceID="SalesPersonQuotaHistoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesPersonQuotaHistoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SalesPersonQuotaHistoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SalesPersonQuotaHistory not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SalesPersonQuotaHistoryDataSource ID="SalesPersonQuotaHistoryDataSource" runat="server"
			SelectMethod="GetBySalesPersonIdQuotaDate"
		>
			<Parameters>
				<asp:QueryStringParameter Name="SalesPersonId" QueryStringField="SalesPersonId" Type="String" />
<asp:QueryStringParameter Name="QuotaDate" QueryStringField="QuotaDate" Type="String" />

			</Parameters>
		</data:SalesPersonQuotaHistoryDataSource>
		
		<br />


</asp:Content>

