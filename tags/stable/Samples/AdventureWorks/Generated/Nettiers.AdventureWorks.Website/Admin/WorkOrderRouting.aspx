
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="WorkOrderRouting.aspx.cs" Inherits="WorkOrderRouting" Title="WorkOrderRouting List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Work Order Routing List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="WorkOrderRoutingDataSource"
				DataKeyNames="WorkOrderId, ProductId, OperationSequence"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_WorkOrderRouting.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Work Order Id" DataNavigateUrlFormatString="WorkOrderEdit.aspx?WorkOrderId={0}" DataNavigateUrlFields="WorkOrderId" DataContainer="WorkOrderIdSource" DataTextField="OrderQty" />
				<asp:BoundField DataField="ProductId" HeaderText="Product Id" SortExpression="[ProductID]" ReadOnly="True" />
				<asp:BoundField DataField="OperationSequence" HeaderText="Operation Sequence" SortExpression="[OperationSequence]" ReadOnly="True" />
				<data:HyperLinkField HeaderText="Location Id" DataNavigateUrlFormatString="LocationEdit.aspx?LocationId={0}" DataNavigateUrlFields="LocationId" DataContainer="LocationIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ScheduledStartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Scheduled Start Date" SortExpression="[ScheduledStartDate]"  />
				<asp:BoundField DataField="ScheduledEndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Scheduled End Date" SortExpression="[ScheduledEndDate]"  />
				<asp:BoundField DataField="ActualStartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Actual Start Date" SortExpression="[ActualStartDate]"  />
				<asp:BoundField DataField="ActualEndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Actual End Date" SortExpression="[ActualEndDate]"  />
				<asp:BoundField DataField="ActualResourceHrs" HeaderText="Actual Resource Hrs" SortExpression="[ActualResourceHrs]"  />
				<asp:BoundField DataField="PlannedCost" HeaderText="Planned Cost" SortExpression="[PlannedCost]"  />
				<asp:BoundField DataField="ActualCost" HeaderText="Actual Cost" SortExpression="[ActualCost]"  />
				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No WorkOrderRouting Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnWorkOrderRouting" OnClientClick="javascript:location.href='WorkOrderRoutingEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:WorkOrderRoutingDataSource ID="WorkOrderRoutingDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:WorkOrderRoutingProperty Name="Location"/> 
					<data:WorkOrderRoutingProperty Name="WorkOrder"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:WorkOrderRoutingDataSource>
	    		
</asp:Content>



