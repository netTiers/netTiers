<%@ Control Language="C#" ClassName="ContactFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataNameStyle" runat="server" Text="Name Style:" AssociatedControlID="dataNameStyle" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataNameStyle" SelectedValue='<%# Bind("NameStyle") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTitle" runat="server" Text="Title:" AssociatedControlID="dataTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTitle" Text='<%# Bind("Title") %>' MaxLength="8"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirstName" runat="server" Text="First Name:" AssociatedControlID="dataFirstName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirstName" Text='<%# Bind("FirstName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFirstName" runat="server" Display="Dynamic" ControlToValidate="dataFirstName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMiddleName" runat="server" Text="Middle Name:" AssociatedControlID="dataMiddleName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMiddleName" Text='<%# Bind("MiddleName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastName" runat="server" Text="Last Name:" AssociatedControlID="dataLastName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastName" Text='<%# Bind("LastName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLastName" runat="server" Display="Dynamic" ControlToValidate="dataLastName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSuffix" runat="server" Text="Suffix:" AssociatedControlID="dataSuffix" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSuffix" Text='<%# Bind("Suffix") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailAddress" runat="server" Text="Email Address:" AssociatedControlID="dataEmailAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmailAddress" Text='<%# Bind("EmailAddress") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailPromotion" runat="server" Text="Email Promotion:" AssociatedControlID="dataEmailPromotion" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmailPromotion" Text='<%# Bind("EmailPromotion") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmailPromotion" runat="server" Display="Dynamic" ControlToValidate="dataEmailPromotion" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataEmailPromotion" runat="server" Display="Dynamic" ControlToValidate="dataEmailPromotion" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhone" runat="server" Text="Phone:" AssociatedControlID="dataPhone" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhone" Text='<%# Bind("Phone") %>' MaxLength="25"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPasswordHash" runat="server" Text="Password Hash:" AssociatedControlID="dataPasswordHash" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPasswordHash" Text='<%# Bind("PasswordHash") %>' MaxLength="128"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPasswordHash" runat="server" Display="Dynamic" ControlToValidate="dataPasswordHash" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPasswordSalt" runat="server" Text="Password Salt:" AssociatedControlID="dataPasswordSalt" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPasswordSalt" Text='<%# Bind("PasswordSalt") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPasswordSalt" runat="server" Display="Dynamic" ControlToValidate="dataPasswordSalt" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAdditionalContactInfo" runat="server" Text="Additional Contact Info:" AssociatedControlID="dataAdditionalContactInfo" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataAdditionalContactInfo" Value='<%# Bind("AdditionalContactInfo") %>'></asp:HiddenField>
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


