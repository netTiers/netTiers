<%@ Control Language="C#" ClassName="CurrencyRateFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrencyRateDate" runat="server" Text="Currency Rate Date:" AssociatedControlID="dataCurrencyRateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCurrencyRateDate" Text='<%# Bind("CurrencyRateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCurrencyRateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataCurrencyRateDate" runat="server" Display="Dynamic" ControlToValidate="dataCurrencyRateDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFromCurrencyCode" runat="server" Text="From Currency Code:" AssociatedControlID="dataFromCurrencyCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataFromCurrencyCode" DataSourceID="FromCurrencyCodeCurrencyDataSource" DataTextField="Name" DataValueField="CurrencyCode" SelectedValue='<%# Bind("FromCurrencyCode") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CurrencyDataSource ID="FromCurrencyCodeCurrencyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataToCurrencyCode" runat="server" Text="To Currency Code:" AssociatedControlID="dataToCurrencyCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataToCurrencyCode" DataSourceID="ToCurrencyCodeCurrencyDataSource" DataTextField="Name" DataValueField="CurrencyCode" SelectedValue='<%# Bind("ToCurrencyCode") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CurrencyDataSource ID="ToCurrencyCodeCurrencyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAverageRate" runat="server" Text="Average Rate:" AssociatedControlID="dataAverageRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAverageRate" Text='<%# Bind("AverageRate") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAverageRate" runat="server" Display="Dynamic" ControlToValidate="dataAverageRate" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataAverageRate"  runat="server" ControlToValidate="dataAverageRate" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEndOfDayRate" runat="server" Text="End Of Day Rate:" AssociatedControlID="dataEndOfDayRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEndOfDayRate" Text='<%# Bind("EndOfDayRate") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEndOfDayRate" runat="server" Display="Dynamic" ControlToValidate="dataEndOfDayRate" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataEndOfDayRate"  runat="server" ControlToValidate="dataEndOfDayRate" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
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


