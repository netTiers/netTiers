<%@ Control Language="C#" ClassName="AddressFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddressLine1" runat="server" Text="Address Line1:" AssociatedControlID="dataAddressLine1" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddressLine1" Text='<%# Bind("AddressLine1") %>' MaxLength="60"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAddressLine1" runat="server" Display="Dynamic" ControlToValidate="dataAddressLine1" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddressLine2" runat="server" Text="Address Line2:" AssociatedControlID="dataAddressLine2" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddressLine2" Text='<%# Bind("AddressLine2") %>' MaxLength="60"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCity" runat="server" Text="City:" AssociatedControlID="dataCity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCity" Text='<%# Bind("City") %>' MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCity" runat="server" Display="Dynamic" ControlToValidate="dataCity" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStateProvinceId" runat="server" Text="State Province Id:" AssociatedControlID="dataStateProvinceId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataStateProvinceId" DataSourceID="StateProvinceIdStateProvinceDataSource" DataTextField="StateProvinceCode" DataValueField="StateProvinceId" SelectedValue='<%# Bind("StateProvinceId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:StateProvinceDataSource ID="StateProvinceIdStateProvinceDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostalCode" runat="server" Text="Postal Code:" AssociatedControlID="dataPostalCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostalCode" Text='<%# Bind("PostalCode") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPostalCode" runat="server" Display="Dynamic" ControlToValidate="dataPostalCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


