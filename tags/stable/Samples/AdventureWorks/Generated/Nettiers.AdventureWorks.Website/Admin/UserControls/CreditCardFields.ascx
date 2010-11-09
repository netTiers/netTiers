<%@ Control Language="C#" ClassName="CreditCardFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCardType" runat="server" Text="Card Type:" AssociatedControlID="dataCardType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCardType" Text='<%# Bind("CardType") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCardType" runat="server" Display="Dynamic" ControlToValidate="dataCardType" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCardNumber" runat="server" Text="Card Number:" AssociatedControlID="dataCardNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCardNumber" Text='<%# Bind("CardNumber") %>' MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCardNumber" runat="server" Display="Dynamic" ControlToValidate="dataCardNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExpMonth" runat="server" Text="Exp Month:" AssociatedControlID="dataExpMonth" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExpMonth" Text='<%# Bind("ExpMonth") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataExpMonth" runat="server" Display="Dynamic" ControlToValidate="dataExpMonth" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataExpMonth" runat="server" Display="Dynamic" ControlToValidate="dataExpMonth" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExpYear" runat="server" Text="Exp Year:" AssociatedControlID="dataExpYear" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExpYear" Text='<%# Bind("ExpYear") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataExpYear" runat="server" Display="Dynamic" ControlToValidate="dataExpYear" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataExpYear" runat="server" Display="Dynamic" ControlToValidate="dataExpYear" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
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


