<%@ Control Language="C#" ClassName="PurchaseOrderHeaderFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataRevisionNumber" runat="server" Text="Revision Number:" AssociatedControlID="dataRevisionNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRevisionNumber" Text='<%# Bind("RevisionNumber") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRevisionNumber" runat="server" Display="Dynamic" ControlToValidate="dataRevisionNumber" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataRevisionNumber" runat="server" Display="Dynamic" ControlToValidate="dataRevisionNumber" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStatus" runat="server" Text="Status:" AssociatedControlID="dataStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmployeeId" runat="server" Text="Employee Id:" AssociatedControlID="dataEmployeeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataEmployeeId" DataSourceID="EmployeeIdEmployeeDataSource" DataTextField="NationalIdNumber" DataValueField="EmployeeId" SelectedValue='<%# Bind("EmployeeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:EmployeeDataSource ID="EmployeeIdEmployeeDataSource" runat="server" SelectMethod="GetAll"  />
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
        <td class="literal"><asp:Label ID="lbldataShipMethodId" runat="server" Text="Ship Method Id:" AssociatedControlID="dataShipMethodId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataShipMethodId" DataSourceID="ShipMethodIdShipMethodDataSource" DataTextField="Name" DataValueField="ShipMethodId" SelectedValue='<%# Bind("ShipMethodId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ShipMethodDataSource ID="ShipMethodIdShipMethodDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrderDate" runat="server" Text="Order Date:" AssociatedControlID="dataOrderDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrderDate" Text='<%# Bind("OrderDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataOrderDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataOrderDate" runat="server" Display="Dynamic" ControlToValidate="dataOrderDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShipDate" runat="server" Text="Ship Date:" AssociatedControlID="dataShipDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataShipDate" Text='<%# Bind("ShipDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataShipDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSubTotal" runat="server" Text="Sub Total:" AssociatedControlID="dataSubTotal" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSubTotal" Text='<%# Bind("SubTotal") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSubTotal" runat="server" Display="Dynamic" ControlToValidate="dataSubTotal" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataSubTotal"  runat="server" ControlToValidate="dataSubTotal" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTaxAmt" runat="server" Text="Tax Amt:" AssociatedControlID="dataTaxAmt" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTaxAmt" Text='<%# Bind("TaxAmt") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTaxAmt" runat="server" Display="Dynamic" ControlToValidate="dataTaxAmt" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataTaxAmt"  runat="server" ControlToValidate="dataTaxAmt" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFreight" runat="server" Text="Freight:" AssociatedControlID="dataFreight" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFreight" Text='<%# Bind("Freight") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFreight" runat="server" Display="Dynamic" ControlToValidate="dataFreight" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataFreight"  runat="server" ControlToValidate="dataFreight" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
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


