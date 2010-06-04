<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LocationEdit.aspx.cs" Inherits="LocationEdit" Title="Location Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Location - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="LocationId" runat="server" DataSourceID="LocationDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LocationFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LocationFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Location not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LocationDataSource ID="LocationDataSource" runat="server"
			SelectMethod="GetByLocationId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="LocationId" QueryStringField="LocationId" Type="String" />

			</Parameters>
		</data:LocationDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewWorkOrderRouting1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewWorkOrderRouting1_SelectedIndexChanged"			 			 
			DataSourceID="WorkOrderRoutingDataSource1"
			DataKeyNames="WorkOrderId, ProductId, OperationSequence"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_WorkOrderRouting.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Work Order Id" DataNavigateUrlFormatString="WorkOrderEdit.aspx?WorkOrderId={0}" DataNavigateUrlFields="WorkOrderId" DataContainer="WorkOrderIdSource" DataTextField="OrderQty" />
				<data:HyperLinkField HeaderText="Location Id" DataNavigateUrlFormatString="LocationEdit.aspx?LocationId={0}" DataNavigateUrlFields="LocationId" DataContainer="LocationIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ScheduledStartDate" HeaderText="Scheduled Start Date" SortExpression="[ScheduledStartDate]" />				
				<asp:BoundField DataField="ScheduledEndDate" HeaderText="Scheduled End Date" SortExpression="[ScheduledEndDate]" />				
				<asp:BoundField DataField="ActualStartDate" HeaderText="Actual Start Date" SortExpression="[ActualStartDate]" />				
				<asp:BoundField DataField="ActualEndDate" HeaderText="Actual End Date" SortExpression="[ActualEndDate]" />				
				<asp:BoundField DataField="ActualResourceHrs" HeaderText="Actual Resource Hrs" SortExpression="[ActualResourceHrs]" />				
				<asp:BoundField DataField="PlannedCost" HeaderText="Planned Cost" SortExpression="[PlannedCost]" />				
				<asp:BoundField DataField="ActualCost" HeaderText="Actual Cost" SortExpression="[ActualCost]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Work Order Routing Found! </b>
				<asp:HyperLink runat="server" ID="hypWorkOrderRouting" NavigateUrl="~/admin/WorkOrderRoutingEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:WorkOrderRoutingDataSource ID="WorkOrderRoutingDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:WorkOrderRoutingProperty Name="Location"/> 
					<data:WorkOrderRoutingProperty Name="WorkOrder"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:WorkOrderRoutingFilter  Column="LocationId" QueryStringField="LocationId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:WorkOrderRoutingDataSource>		
		
		<br />
		

</asp:Content>

