<%@ Control Language="C#" ClassName="ProductListPriceHistoryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductId" runat="server" Text="Product Id:" AssociatedControlID="dataProductId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductId" DataSourceID="ProductIdProductDataSource" DataTextField="Name" DataValueField="ProductId" SelectedValue='<%# Bind("ProductId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductDataSource ID="ProductIdProductDataSource" runat="server" SelectMethod="GetAll"  />
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
					<asp:TextBox runat="server" ID="dataEndDate" Text='<%# Bind("EndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataListPrice" runat="server" Text="List Price:" AssociatedControlID="dataListPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataListPrice" Text='<%# Bind("ListPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataListPrice" runat="server" Display="Dynamic" ControlToValidate="dataListPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataListPrice"  runat="server" ControlToValidate="dataListPrice" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
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


