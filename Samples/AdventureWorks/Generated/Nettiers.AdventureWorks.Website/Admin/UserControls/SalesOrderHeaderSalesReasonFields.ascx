<%@ Control Language="C#" ClassName="SalesOrderHeaderSalesReasonFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesOrderId" runat="server" Text="Sales Order Id:" AssociatedControlID="dataSalesOrderId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalesOrderId" DataSourceID="SalesOrderIdSalesOrderHeaderDataSource" DataTextField="RevisionNumber" DataValueField="SalesOrderId" SelectedValue='<%# Bind("SalesOrderId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SalesOrderHeaderDataSource ID="SalesOrderIdSalesOrderHeaderDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesReasonId" runat="server" Text="Sales Reason Id:" AssociatedControlID="dataSalesReasonId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalesReasonId" DataSourceID="SalesReasonIdSalesReasonDataSource" DataTextField="Name" DataValueField="SalesReasonId" SelectedValue='<%# Bind("SalesReasonId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SalesReasonDataSource ID="SalesReasonIdSalesReasonDataSource" runat="server" SelectMethod="GetAll"  />
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


