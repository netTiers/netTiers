<%@ Control Language="C#" ClassName="CountryRegionCurrencyFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountryRegionCode" runat="server" Text="Country Region Code:" AssociatedControlID="dataCountryRegionCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCountryRegionCode" DataSourceID="CountryRegionCodeCountryRegionDataSource" DataTextField="Name" DataValueField="CountryRegionCode" SelectedValue='<%# Bind("CountryRegionCode") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CountryRegionDataSource ID="CountryRegionCodeCountryRegionDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrencyCode" runat="server" Text="Currency Code:" AssociatedControlID="dataCurrencyCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCurrencyCode" DataSourceID="CurrencyCodeCurrencyDataSource" DataTextField="Name" DataValueField="CurrencyCode" SelectedValue='<%# Bind("CurrencyCode") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CurrencyDataSource ID="CurrencyCodeCurrencyDataSource" runat="server" SelectMethod="GetAll"  />
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


