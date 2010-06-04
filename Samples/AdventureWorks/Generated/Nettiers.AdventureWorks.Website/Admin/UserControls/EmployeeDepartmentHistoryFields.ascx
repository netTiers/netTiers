<%@ Control Language="C#" ClassName="EmployeeDepartmentHistoryFields" %>

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
        <td class="literal"><asp:Label ID="lbldataDepartmentId" runat="server" Text="Department Id:" AssociatedControlID="dataDepartmentId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDepartmentId" DataSourceID="DepartmentIdDepartmentDataSource" DataTextField="Name" DataValueField="DepartmentId" SelectedValue='<%# Bind("DepartmentId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DepartmentDataSource ID="DepartmentIdDepartmentDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShiftId" runat="server" Text="Shift Id:" AssociatedControlID="dataShiftId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataShiftId" DataSourceID="ShiftIdShiftDataSource" DataTextField="Name" DataValueField="ShiftId" SelectedValue='<%# Bind("ShiftId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ShiftDataSource ID="ShiftIdShiftDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStartDate" runat="server" Text="Start Date:" AssociatedControlID="dataStartDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStartDate" Text='<%# Bind("StartDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataStartDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataStartDate" runat="server" Display="Dynamic" ControlToValidate="dataStartDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEndDate" runat="server" Text="End Date:" AssociatedControlID="dataEndDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEndDate" Text='<%# Bind("EndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


