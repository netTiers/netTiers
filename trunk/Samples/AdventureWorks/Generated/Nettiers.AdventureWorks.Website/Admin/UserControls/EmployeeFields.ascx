<%@ Control Language="C#" ClassName="EmployeeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataNationalIdNumber" runat="server" Text="National Id Number:" AssociatedControlID="dataNationalIdNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNationalIdNumber" Text='<%# Bind("NationalIdNumber") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNationalIdNumber" runat="server" Display="Dynamic" ControlToValidate="dataNationalIdNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataContactId" runat="server" Text="Contact Id:" AssociatedControlID="dataContactId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataContactId" DataSourceID="ContactIdContactDataSource" DataTextField="NameStyle" DataValueField="ContactId" SelectedValue='<%# Bind("ContactId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ContactDataSource ID="ContactIdContactDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLoginId" runat="server" Text="Login Id:" AssociatedControlID="dataLoginId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLoginId" Text='<%# Bind("LoginId") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLoginId" runat="server" Display="Dynamic" ControlToValidate="dataLoginId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataManagerId" runat="server" Text="Manager Id:" AssociatedControlID="dataManagerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataManagerId" DataSourceID="ManagerIdEmployeeDataSource" DataTextField="NationalIdNumber" DataValueField="EmployeeId" SelectedValue='<%# Bind("ManagerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:EmployeeDataSource ID="ManagerIdEmployeeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTitle" runat="server" Text="Title:" AssociatedControlID="dataTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTitle" Text='<%# Bind("Title") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTitle" runat="server" Display="Dynamic" ControlToValidate="dataTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBirthDate" runat="server" Text="Birth Date:" AssociatedControlID="dataBirthDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBirthDate" Text='<%# Bind("BirthDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataBirthDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataBirthDate" runat="server" Display="Dynamic" ControlToValidate="dataBirthDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaritalStatus" runat="server" Text="Marital Status:" AssociatedControlID="dataMaritalStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaritalStatus" Text='<%# Bind("MaritalStatus") %>' MaxLength="1"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaritalStatus" runat="server" Display="Dynamic" ControlToValidate="dataMaritalStatus" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGender" runat="server" Text="Gender:" AssociatedControlID="dataGender" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGender" Text='<%# Bind("Gender") %>' MaxLength="1"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataGender" runat="server" Display="Dynamic" ControlToValidate="dataGender" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHireDate" runat="server" Text="Hire Date:" AssociatedControlID="dataHireDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHireDate" Text='<%# Bind("HireDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataHireDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataHireDate" runat="server" Display="Dynamic" ControlToValidate="dataHireDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalariedFlag" runat="server" Text="Salaried Flag:" AssociatedControlID="dataSalariedFlag" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSalariedFlag" SelectedValue='<%# Bind("SalariedFlag") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataVacationHours" runat="server" Text="Vacation Hours:" AssociatedControlID="dataVacationHours" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataVacationHours" Text='<%# Bind("VacationHours") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataVacationHours" runat="server" Display="Dynamic" ControlToValidate="dataVacationHours" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataVacationHours" runat="server" Display="Dynamic" ControlToValidate="dataVacationHours" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSickLeaveHours" runat="server" Text="Sick Leave Hours:" AssociatedControlID="dataSickLeaveHours" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSickLeaveHours" Text='<%# Bind("SickLeaveHours") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSickLeaveHours" runat="server" Display="Dynamic" ControlToValidate="dataSickLeaveHours" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSickLeaveHours" runat="server" Display="Dynamic" ControlToValidate="dataSickLeaveHours" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrentFlag" runat="server" Text="Current Flag:" AssociatedControlID="dataCurrentFlag" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataCurrentFlag" SelectedValue='<%# Bind("CurrentFlag") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
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


