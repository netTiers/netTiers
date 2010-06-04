<%@ Control Language="C#" ClassName="StateProvinceFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataStateProvinceCode" runat="server" Text="State Province Code:" AssociatedControlID="dataStateProvinceCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStateProvinceCode" Text='<%# Bind("StateProvinceCode") %>' MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataStateProvinceCode" runat="server" Display="Dynamic" ControlToValidate="dataStateProvinceCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountryRegionCode" runat="server" Text="Country Region Code:" AssociatedControlID="dataCountryRegionCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCountryRegionCode" DataSourceID="CountryRegionCodeCountryRegionDataSource" DataTextField="Name" DataValueField="CountryRegionCode" SelectedValue='<%# Bind("CountryRegionCode") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CountryRegionDataSource ID="CountryRegionCodeCountryRegionDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsOnlyStateProvinceFlag" runat="server" Text="Is Only State Province Flag:" AssociatedControlID="dataIsOnlyStateProvinceFlag" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsOnlyStateProvinceFlag" SelectedValue='<%# Bind("IsOnlyStateProvinceFlag") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTerritoryId" runat="server" Text="Territory Id:" AssociatedControlID="dataTerritoryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTerritoryId" DataSourceID="TerritoryIdSalesTerritoryDataSource" DataTextField="Name" DataValueField="TerritoryId" SelectedValue='<%# Bind("TerritoryId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SalesTerritoryDataSource ID="TerritoryIdSalesTerritoryDataSource" runat="server" SelectMethod="GetAll"  />
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


