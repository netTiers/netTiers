<%@ Control Language="C#" ClassName="SalesPersonFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person Id:" AssociatedControlID="dataSalesPersonId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdEmployeeDataSource" DataTextField="NationalIdNumber" DataValueField="EmployeeId" SelectedValue='<%# Bind("SalesPersonId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:EmployeeDataSource ID="SalesPersonIdEmployeeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTerritoryId" runat="server" Text="Territory Id:" AssociatedControlID="dataTerritoryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTerritoryId" DataSourceID="TerritoryIdSalesTerritoryDataSource" DataTextField="Name" DataValueField="TerritoryId" SelectedValue='<%# Bind("TerritoryId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:SalesTerritoryDataSource ID="TerritoryIdSalesTerritoryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesQuota" runat="server" Text="Sales Quota:" AssociatedControlID="dataSalesQuota" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalesQuota" Text='<%# Bind("SalesQuota") %>'></asp:TextBox><asp:RegularExpressionValidator ID="RegExVal_dataSalesQuota"  runat="server" ControlToValidate="dataSalesQuota" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBonus" runat="server" Text="Bonus:" AssociatedControlID="dataBonus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBonus" Text='<%# Bind("Bonus") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBonus" runat="server" Display="Dynamic" ControlToValidate="dataBonus" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataBonus"  runat="server" ControlToValidate="dataBonus" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCommissionPct" runat="server" Text="Commission Pct:" AssociatedControlID="dataCommissionPct" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCommissionPct" Text='<%# Bind("CommissionPct") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCommissionPct" runat="server" Display="Dynamic" ControlToValidate="dataCommissionPct" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataCommissionPct"  runat="server" ControlToValidate="dataCommissionPct" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesYtd" runat="server" Text="Sales Ytd:" AssociatedControlID="dataSalesYtd" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalesYtd" Text='<%# Bind("SalesYtd") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSalesYtd" runat="server" Display="Dynamic" ControlToValidate="dataSalesYtd" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataSalesYtd"  runat="server" ControlToValidate="dataSalesYtd" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesLastYear" runat="server" Text="Sales Last Year:" AssociatedControlID="dataSalesLastYear" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalesLastYear" Text='<%# Bind("SalesLastYear") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSalesLastYear" runat="server" Display="Dynamic" ControlToValidate="dataSalesLastYear" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataSalesLastYear"  runat="server" ControlToValidate="dataSalesLastYear" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
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


