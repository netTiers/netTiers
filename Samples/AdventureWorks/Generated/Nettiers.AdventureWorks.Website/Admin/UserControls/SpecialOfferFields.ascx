<%@ Control Language="C#" ClassName="SpecialOfferFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDescription" runat="server" Display="Dynamic" ControlToValidate="dataDescription" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiscountPct" runat="server" Text="Discount Pct:" AssociatedControlID="dataDiscountPct" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiscountPct" Text='<%# Bind("DiscountPct") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDiscountPct" runat="server" Display="Dynamic" ControlToValidate="dataDiscountPct" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataDiscountPct"  runat="server" ControlToValidate="dataDiscountPct" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataType" runat="server" Text="Type:" AssociatedControlID="dataType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataType" Text='<%# Bind("Type") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataType" runat="server" Display="Dynamic" ControlToValidate="dataType" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCategory" runat="server" Text="Category:" AssociatedControlID="dataCategory" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCategory" Text='<%# Bind("Category") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCategory" runat="server" Display="Dynamic" ControlToValidate="dataCategory" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStartDate" runat="server" Text="Start Date:" AssociatedControlID="dataStartDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStartDate" Text='<%# Bind("StartDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataStartDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataStartDate" runat="server" Display="Dynamic" ControlToValidate="dataStartDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEndDate" runat="server" Text="End Date:" AssociatedControlID="dataEndDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEndDate" Text='<%# Bind("EndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataEndDate" runat="server" Display="Dynamic" ControlToValidate="dataEndDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMinQty" runat="server" Text="Min Qty:" AssociatedControlID="dataMinQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMinQty" Text='<%# Bind("MinQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMinQty" runat="server" Display="Dynamic" ControlToValidate="dataMinQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMinQty" runat="server" Display="Dynamic" ControlToValidate="dataMinQty" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaxQty" runat="server" Text="Max Qty:" AssociatedControlID="dataMaxQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaxQty" Text='<%# Bind("MaxQty") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMaxQty" runat="server" Display="Dynamic" ControlToValidate="dataMaxQty" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
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


