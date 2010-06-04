<%@ Control Language="C#" ClassName="JobCandidateFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmployeeId" runat="server" Text="Employee Id:" AssociatedControlID="dataEmployeeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataEmployeeId" DataSourceID="EmployeeIdEmployeeDataSource" DataTextField="NationalIdNumber" DataValueField="EmployeeId" SelectedValue='<%# Bind("EmployeeId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:EmployeeDataSource ID="EmployeeIdEmployeeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataResume" runat="server" Text="Resume:" AssociatedControlID="dataResume" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataResume" Value='<%# Bind("Resume") %>'></asp:HiddenField>
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


