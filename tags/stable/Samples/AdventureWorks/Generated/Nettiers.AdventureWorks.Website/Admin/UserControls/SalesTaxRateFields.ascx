<%@ Control Language="C#" ClassName="SalesTaxRateFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataStateProvinceId" runat="server" Text="State Province Id:" AssociatedControlID="dataStateProvinceId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataStateProvinceId" DataSourceID="StateProvinceIdStateProvinceDataSource" DataTextField="StateProvinceCode" DataValueField="StateProvinceId" SelectedValue='<%# Bind("StateProvinceId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:StateProvinceDataSource ID="StateProvinceIdStateProvinceDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTaxType" runat="server" Text="Tax Type:" AssociatedControlID="dataTaxType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTaxType" Text='<%# Bind("TaxType") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTaxType" runat="server" Display="Dynamic" ControlToValidate="dataTaxType" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataTaxType" runat="server" Display="Dynamic" ControlToValidate="dataTaxType" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTaxRate" runat="server" Text="Tax Rate:" AssociatedControlID="dataTaxRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTaxRate" Text='<%# Bind("TaxRate") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTaxRate" runat="server" Display="Dynamic" ControlToValidate="dataTaxRate" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataTaxRate"  runat="server" ControlToValidate="dataTaxRate" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


