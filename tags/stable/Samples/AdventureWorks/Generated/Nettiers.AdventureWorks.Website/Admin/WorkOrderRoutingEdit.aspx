<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="WorkOrderRoutingEdit.aspx.cs" Inherits="WorkOrderRoutingEdit" Title="WorkOrderRouting Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Work Order Routing - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="WorkOrderId, ProductId, OperationSequence" runat="server" DataSourceID="WorkOrderRoutingDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/WorkOrderRoutingFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/WorkOrderRoutingFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>WorkOrderRouting not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:WorkOrderRoutingDataSource ID="WorkOrderRoutingDataSource" runat="server"
			SelectMethod="GetByWorkOrderIdProductIdOperationSequence"
		>
			<Parameters>
				<asp:QueryStringParameter Name="WorkOrderId" QueryStringField="WorkOrderId" Type="String" />
<asp:QueryStringParameter Name="ProductId" QueryStringField="ProductId" Type="String" />
<asp:QueryStringParameter Name="OperationSequence" QueryStringField="OperationSequence" Type="String" />

			</Parameters>
		</data:WorkOrderRoutingDataSource>
		
		<br />


</asp:Content>

