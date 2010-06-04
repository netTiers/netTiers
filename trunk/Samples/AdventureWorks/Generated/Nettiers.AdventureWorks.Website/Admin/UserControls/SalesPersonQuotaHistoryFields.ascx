<%@ Control Language="C#" ClassName="SalesPersonQuotaHistoryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person Id:" AssociatedControlID="dataSalesPersonId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource" DataTextField="SalesQuota" DataValueField="SalesPersonId" SelectedValue='<%# Bind("SalesPersonId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataQuotaDate" runat="server" Text="Quota Date:" AssociatedControlID="dataQuotaDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataQuotaDate" Text='<%# Bind("QuotaDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataQuotaDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataQuotaDate" runat="server" Display="Dynamic" ControlToValidate="dataQuotaDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesQuota" runat="server" Text="Sales Quota:" AssociatedControlID="dataSalesQuota" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalesQuota" Text='<%# Bind("SalesQuota") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSalesQuota" runat="server" Display="Dynamic" ControlToValidate="dataSalesQuota" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataSalesQuota"  runat="server" ControlToValidate="dataSalesQuota" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
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


