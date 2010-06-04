<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ScrapReasonEdit.aspx.cs" Inherits="ScrapReasonEdit" Title="ScrapReason Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Scrap Reason - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ScrapReasonId" runat="server" DataSourceID="ScrapReasonDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ScrapReasonFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ScrapReasonFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ScrapReason not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ScrapReasonDataSource ID="ScrapReasonDataSource" runat="server"
			SelectMethod="GetByScrapReasonId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ScrapReasonId" QueryStringField="ScrapReasonId" Type="String" />

			</Parameters>
		</data:ScrapReasonDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewWorkOrder1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewWorkOrder1_SelectedIndexChanged"			 			 
			DataSourceID="WorkOrderDataSource1"
			DataKeyNames="WorkOrderId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_WorkOrder.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="OrderQty" HeaderText="Order Qty" SortExpression="[OrderQty]" />				
				<asp:BoundField DataField="StockedQty" HeaderText="Stocked Qty" SortExpression="[StockedQty]" />				
				<asp:BoundField DataField="ScrappedQty" HeaderText="Scrapped Qty" SortExpression="[ScrappedQty]" />				
				<asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="[StartDate]" />				
				<asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="[EndDate]" />				
				<asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="[DueDate]" />				
				<data:HyperLinkField HeaderText="Scrap Reason Id" DataNavigateUrlFormatString="ScrapReasonEdit.aspx?ScrapReasonId={0}" DataNavigateUrlFields="ScrapReasonId" DataContainer="ScrapReasonIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Work Order Found! </b>
				<asp:HyperLink runat="server" ID="hypWorkOrder" NavigateUrl="~/admin/WorkOrderEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:WorkOrderDataSource ID="WorkOrderDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:WorkOrderProperty Name="Product"/> 
					<data:WorkOrderProperty Name="ScrapReason"/> 
					<%--<data:WorkOrderProperty Name="WorkOrderRoutingCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:WorkOrderFilter  Column="ScrapReasonId" QueryStringField="ScrapReasonId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:WorkOrderDataSource>		
		
		<br />
		

</asp:Content>

