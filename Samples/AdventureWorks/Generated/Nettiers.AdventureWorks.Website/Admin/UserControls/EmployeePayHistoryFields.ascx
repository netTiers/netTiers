<%@ Control Language="C#" ClassName="EmployeePayHistoryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmployeeId" runat="server" Text="Employee Id:" AssociatedControlID="dataEmployeeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataEmployeeId" DataSourceID="EmployeeIdEmployeeDataSource" DataTextField="NationalIdNumber" DataValueField="EmployeeId" SelectedValue='<%# Bind("EmployeeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:EmployeeDataSource ID="EmployeeIdEmployeeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRateChangeDate" runat="server" Text="Rate Change Date:" AssociatedControlID="dataRateChangeDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRateChangeDate" Text='<%# Bind("RateChangeDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataRateChangeDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataRateChangeDate" runat="server" Display="Dynamic" ControlToValidate="dataRateChangeDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRate" runat="server" Text="Rate:" AssociatedControlID="dataRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRate" Text='<%# Bind("Rate") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRate" runat="server" Display="Dynamic" ControlToValidate="dataRate" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataRate"  runat="server" ControlToValidate="dataRate" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPayFrequency" runat="server" Text="Pay Frequency:" AssociatedControlID="dataPayFrequency" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPayFrequency" Text='<%# Bind("PayFrequency") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPayFrequency" runat="server" Display="Dynamic" ControlToValidate="dataPayFrequency" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataPayFrequency" runat="server" Display="Dynamic" ControlToValidate="dataPayFrequency" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
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


