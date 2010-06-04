<%@ Control Language="C#" ClassName="SalesTerritoryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountryRegionCode" runat="server" Text="Country Region Code:" AssociatedControlID="dataCountryRegionCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCountryRegionCode" Text='<%# Bind("CountryRegionCode") %>' MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCountryRegionCode" runat="server" Display="Dynamic" ControlToValidate="dataCountryRegionCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGroup" runat="server" Text="Group:" AssociatedControlID="dataGroup" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGroup" Text='<%# Bind("Group") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataGroup" runat="server" Display="Dynamic" ControlToValidate="dataGroup" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
        <td class="literal"><asp:Label ID="lbldataCostYtd" runat="server" Text="Cost Ytd:" AssociatedControlID="dataCostYtd" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCostYtd" Text='<%# Bind("CostYtd") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCostYtd" runat="server" Display="Dynamic" ControlToValidate="dataCostYtd" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataCostYtd"  runat="server" ControlToValidate="dataCostYtd" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCostLastYear" runat="server" Text="Cost Last Year:" AssociatedControlID="dataCostLastYear" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCostLastYear" Text='<%# Bind("CostLastYear") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCostLastYear" runat="server" Display="Dynamic" ControlToValidate="dataCostLastYear" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataCostLastYear"  runat="server" ControlToValidate="dataCostLastYear" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
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


