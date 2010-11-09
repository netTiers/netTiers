<%@ Control Language="C#" ClassName="ShoppingCartItemFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataShoppingCartId" runat="server" Text="Shopping Cart Id:" AssociatedControlID="dataShoppingCartId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataShoppingCartId" Text='<%# Bind("ShoppingCartId") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataShoppingCartId" runat="server" Display="Dynamic" ControlToValidate="dataShoppingCartId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataQuantity" runat="server" Text="Quantity:" AssociatedControlID="dataQuantity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataQuantity" Text='<%# Bind("Quantity") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductId" runat="server" Text="Product Id:" AssociatedControlID="dataProductId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductId" DataSourceID="ProductIdProductDataSource" DataTextField="Name" DataValueField="ProductId" SelectedValue='<%# Bind("ProductId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductDataSource ID="ProductIdProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDateCreated" runat="server" Text="Date Created:" AssociatedControlID="dataDateCreated" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDateCreated" Text='<%# Bind("DateCreated", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDateCreated" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataDateCreated" runat="server" Display="Dynamic" ControlToValidate="dataDateCreated" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


