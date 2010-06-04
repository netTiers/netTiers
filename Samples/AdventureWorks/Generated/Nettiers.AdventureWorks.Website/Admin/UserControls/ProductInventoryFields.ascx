<%@ Control Language="C#" ClassName="ProductInventoryFields" %>

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
        <td class="literal"><asp:Label ID="lbldataLocationId" runat="server" Text="Location Id:" AssociatedControlID="dataLocationId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLocationId" DataSourceID="LocationIdLocationDataSource" DataTextField="Name" DataValueField="LocationId" SelectedValue='<%# Bind("LocationId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LocationDataSource ID="LocationIdLocationDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShelf" runat="server" Text="Shelf:" AssociatedControlID="dataShelf" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataShelf" Text='<%# Bind("Shelf") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataShelf" runat="server" Display="Dynamic" ControlToValidate="dataShelf" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBin" runat="server" Text="Bin:" AssociatedControlID="dataBin" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBin" Text='<%# Bind("Bin") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBin" runat="server" Display="Dynamic" ControlToValidate="dataBin" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataBin" runat="server" Display="Dynamic" ControlToValidate="dataBin" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataQuantity" runat="server" Text="Quantity:" AssociatedControlID="dataQuantity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataQuantity" Text='<%# Bind("Quantity") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
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


