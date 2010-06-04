<%@ Control Language="C#" ClassName="WorkOrderRoutingFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWorkOrderId" runat="server" Text="Work Order Id:" AssociatedControlID="dataWorkOrderId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataWorkOrderId" DataSourceID="WorkOrderIdWorkOrderDataSource" DataTextField="OrderQty" DataValueField="WorkOrderId" SelectedValue='<%# Bind("WorkOrderId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:WorkOrderDataSource ID="WorkOrderIdWorkOrderDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductId" runat="server" Text="Product Id:" AssociatedControlID="dataProductId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductId" Text='<%# Bind("ProductId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProductId" runat="server" Display="Dynamic" ControlToValidate="dataProductId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataProductId" runat="server" Display="Dynamic" ControlToValidate="dataProductId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOperationSequence" runat="server" Text="Operation Sequence:" AssociatedControlID="dataOperationSequence" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOperationSequence" Text='<%# Bind("OperationSequence") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOperationSequence" runat="server" Display="Dynamic" ControlToValidate="dataOperationSequence" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataOperationSequence" runat="server" Display="Dynamic" ControlToValidate="dataOperationSequence" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocationId" runat="server" Text="Location Id:" AssociatedControlID="dataLocationId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLocationId" DataSourceID="LocationIdLocationDataSource" DataTextField="Name" DataValueField="LocationId" SelectedValue='<%# Bind("LocationId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LocationDataSource ID="LocationIdLocationDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataScheduledStartDate" runat="server" Text="Scheduled Start Date:" AssociatedControlID="dataScheduledStartDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataScheduledStartDate" Text='<%# Bind("ScheduledStartDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataScheduledStartDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataScheduledStartDate" runat="server" Display="Dynamic" ControlToValidate="dataScheduledStartDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataScheduledEndDate" runat="server" Text="Scheduled End Date:" AssociatedControlID="dataScheduledEndDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataScheduledEndDate" Text='<%# Bind("ScheduledEndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataScheduledEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataScheduledEndDate" runat="server" Display="Dynamic" ControlToValidate="dataScheduledEndDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActualStartDate" runat="server" Text="Actual Start Date:" AssociatedControlID="dataActualStartDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataActualStartDate" Text='<%# Bind("ActualStartDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataActualStartDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActualEndDate" runat="server" Text="Actual End Date:" AssociatedControlID="dataActualEndDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataActualEndDate" Text='<%# Bind("ActualEndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataActualEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActualResourceHrs" runat="server" Text="Actual Resource Hrs:" AssociatedControlID="dataActualResourceHrs" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataActualResourceHrs" Text='<%# Bind("ActualResourceHrs") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataActualResourceHrs" runat="server" Display="Dynamic" ControlToValidate="dataActualResourceHrs" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPlannedCost" runat="server" Text="Planned Cost:" AssociatedControlID="dataPlannedCost" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPlannedCost" Text='<%# Bind("PlannedCost") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPlannedCost" runat="server" Display="Dynamic" ControlToValidate="dataPlannedCost" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataPlannedCost"  runat="server" ControlToValidate="dataPlannedCost" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActualCost" runat="server" Text="Actual Cost:" AssociatedControlID="dataActualCost" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataActualCost" Text='<%# Bind("ActualCost") %>'></asp:TextBox><asp:RegularExpressionValidator ID="RegExVal_dataActualCost"  runat="server" ControlToValidate="dataActualCost" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedDate" runat="server" Text="Modified Date:" AssociatedControlID="dataModifiedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedDate" Text='<%# Bind("ModifiedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataModifiedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataModifiedDate" runat="server" Display="Dynamic" ControlToValidate="dataModifiedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


