<%@ Control Language="C#" ClassName="SalesOrderDetailFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesOrderId" runat="server" Text="Sales Order Id:" AssociatedControlID="dataSalesOrderId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalesOrderId" DataSourceID="SalesOrderIdSalesOrderHeaderDataSource" DataTextField="RevisionNumber" DataValueField="SalesOrderId" SelectedValue='<%# Bind("SalesOrderId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SalesOrderHeaderDataSource ID="SalesOrderIdSalesOrderHeaderDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCarrierTrackingNumber" runat="server" Text="Carrier Tracking Number:" AssociatedControlID="dataCarrierTrackingNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCarrierTrackingNumber" Text='<%# Bind("CarrierTrackingNumber") %>' MaxLength="25"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrderQty" runat="server" Text="Order Qty:" AssociatedControlID="dataOrderQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrderQty" Text='<%# Bind("OrderQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataOrderQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataOrderQty" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSpecialOfferId" runat="server" Text="Special Offer Id:" AssociatedControlID="dataSpecialOfferId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSpecialOfferId" DataSourceID="SpecialOfferIdSpecialOfferProductDataSource" DataTextField="Rowguid" DataValueField="SpecialOfferId" SelectedValue='<%# Bind("SpecialOfferId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SpecialOfferProductDataSource ID="SpecialOfferIdSpecialOfferProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUnitPrice" runat="server" Text="Unit Price:" AssociatedControlID="dataUnitPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUnitPrice" Text='<%# Bind("UnitPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUnitPrice" runat="server" Display="Dynamic" ControlToValidate="dataUnitPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataUnitPrice"  runat="server" ControlToValidate="dataUnitPrice" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUnitPriceDiscount" runat="server" Text="Unit Price Discount:" AssociatedControlID="dataUnitPriceDiscount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUnitPriceDiscount" Text='<%# Bind("UnitPriceDiscount") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUnitPriceDiscount" runat="server" Display="Dynamic" ControlToValidate="dataUnitPriceDiscount" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataUnitPriceDiscount"  runat="server" ControlToValidate="dataUnitPriceDiscount" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
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


