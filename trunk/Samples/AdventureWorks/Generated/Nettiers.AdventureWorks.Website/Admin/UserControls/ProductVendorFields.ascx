<%@ Control Language="C#" ClassName="ProductVendorFields" %>

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
        <td class="literal"><asp:Label ID="lbldataVendorId" runat="server" Text="Vendor Id:" AssociatedControlID="dataVendorId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataVendorId" DataSourceID="VendorIdVendorDataSource" DataTextField="AccountNumber" DataValueField="VendorId" SelectedValue='<%# Bind("VendorId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:VendorDataSource ID="VendorIdVendorDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAverageLeadTime" runat="server" Text="Average Lead Time:" AssociatedControlID="dataAverageLeadTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAverageLeadTime" Text='<%# Bind("AverageLeadTime") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAverageLeadTime" runat="server" Display="Dynamic" ControlToValidate="dataAverageLeadTime" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAverageLeadTime" runat="server" Display="Dynamic" ControlToValidate="dataAverageLeadTime" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStandardPrice" runat="server" Text="Standard Price:" AssociatedControlID="dataStandardPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStandardPrice" Text='<%# Bind("StandardPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataStandardPrice" runat="server" Display="Dynamic" ControlToValidate="dataStandardPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataStandardPrice"  runat="server" ControlToValidate="dataStandardPrice" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastReceiptCost" runat="server" Text="Last Receipt Cost:" AssociatedControlID="dataLastReceiptCost" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastReceiptCost" Text='<%# Bind("LastReceiptCost") %>'></asp:TextBox><asp:RegularExpressionValidator ID="RegExVal_dataLastReceiptCost"  runat="server" ControlToValidate="dataLastReceiptCost" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastReceiptDate" runat="server" Text="Last Receipt Date:" AssociatedControlID="dataLastReceiptDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastReceiptDate" Text='<%# Bind("LastReceiptDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastReceiptDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMinOrderQty" runat="server" Text="Min Order Qty:" AssociatedControlID="dataMinOrderQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMinOrderQty" Text='<%# Bind("MinOrderQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMinOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataMinOrderQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMinOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataMinOrderQty" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaxOrderQty" runat="server" Text="Max Order Qty:" AssociatedControlID="dataMaxOrderQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaxOrderQty" Text='<%# Bind("MaxOrderQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaxOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataMaxOrderQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMaxOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataMaxOrderQty" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOnOrderQty" runat="server" Text="On Order Qty:" AssociatedControlID="dataOnOrderQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOnOrderQty" Text='<%# Bind("OnOrderQty") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataOnOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataOnOrderQty" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUnitMeasureCode" runat="server" Text="Unit Measure Code:" AssociatedControlID="dataUnitMeasureCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataUnitMeasureCode" DataSourceID="UnitMeasureCodeUnitMeasureDataSource" DataTextField="Name" DataValueField="UnitMeasureCode" SelectedValue='<%# Bind("UnitMeasureCode") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:UnitMeasureDataSource ID="UnitMeasureCodeUnitMeasureDataSource" runat="server" SelectMethod="GetAll"  />
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


