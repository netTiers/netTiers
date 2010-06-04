<%@ Control Language="C#" ClassName="ContactCreditCardFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataContactId" runat="server" Text="Contact Id:" AssociatedControlID="dataContactId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataContactId" DataSourceID="ContactIdContactDataSource" DataTextField="NameStyle" DataValueField="ContactId" SelectedValue='<%# Bind("ContactId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ContactDataSource ID="ContactIdContactDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreditCardId" runat="server" Text="Credit Card Id:" AssociatedControlID="dataCreditCardId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCreditCardId" DataSourceID="CreditCardIdCreditCardDataSource" DataTextField="CardType" DataValueField="CreditCardId" SelectedValue='<%# Bind("CreditCardId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CreditCardDataSource ID="CreditCardIdCreditCardDataSource" runat="server" SelectMethod="GetAll"  />
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


