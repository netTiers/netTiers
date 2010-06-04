<%@ Control Language="C#" ClassName="VendorFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAccountNumber" runat="server" Text="Account Number:" AssociatedControlID="dataAccountNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAccountNumber" Text='<%# Bind("AccountNumber") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAccountNumber" runat="server" Display="Dynamic" ControlToValidate="dataAccountNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreditRating" runat="server" Text="Credit Rating:" AssociatedControlID="dataCreditRating" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreditRating" Text='<%# Bind("CreditRating") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCreditRating" runat="server" Display="Dynamic" ControlToValidate="dataCreditRating" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCreditRating" runat="server" Display="Dynamic" ControlToValidate="dataCreditRating" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPreferredVendorStatus" runat="server" Text="Preferred Vendor Status:" AssociatedControlID="dataPreferredVendorStatus" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPreferredVendorStatus" SelectedValue='<%# Bind("PreferredVendorStatus") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActiveFlag" runat="server" Text="Active Flag:" AssociatedControlID="dataActiveFlag" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataActiveFlag" SelectedValue='<%# Bind("ActiveFlag") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPurchasingWebServiceUrl" runat="server" Text="Purchasing Web Service Url:" AssociatedControlID="dataPurchasingWebServiceUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPurchasingWebServiceUrl" Text='<%# Bind("PurchasingWebServiceUrl") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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


