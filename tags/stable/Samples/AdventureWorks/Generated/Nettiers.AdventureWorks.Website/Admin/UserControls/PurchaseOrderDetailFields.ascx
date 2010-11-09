<%@ Control Language="C#" ClassName="PurchaseOrderDetailFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataPurchaseOrderId" runat="server" Text="Purchase Order Id:" AssociatedControlID="dataPurchaseOrderId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataPurchaseOrderId" DataSourceID="PurchaseOrderIdPurchaseOrderHeaderDataSource" DataTextField="RevisionNumber" DataValueField="PurchaseOrderId" SelectedValue='<%# Bind("PurchaseOrderId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:PurchaseOrderHeaderDataSource ID="PurchaseOrderIdPurchaseOrderHeaderDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDueDate" runat="server" Text="Due Date:" AssociatedControlID="dataDueDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDueDate" Text='<%# Bind("DueDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDueDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataDueDate" runat="server" Display="Dynamic" ControlToValidate="dataDueDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrderQty" runat="server" Text="Order Qty:" AssociatedControlID="dataOrderQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrderQty" Text='<%# Bind("OrderQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataOrderQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataOrderQty" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
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
        <td class="literal"><asp:Label ID="lbldataUnitPrice" runat="server" Text="Unit Price:" AssociatedControlID="dataUnitPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUnitPrice" Text='<%# Bind("UnitPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUnitPrice" runat="server" Display="Dynamic" ControlToValidate="dataUnitPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataUnitPrice"  runat="server" ControlToValidate="dataUnitPrice" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReceivedQty" runat="server" Text="Received Qty:" AssociatedControlID="dataReceivedQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReceivedQty" Text='<%# Bind("ReceivedQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataReceivedQty" runat="server" Display="Dynamic" ControlToValidate="dataReceivedQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataReceivedQty" runat="server" Display="Dynamic" ControlToValidate="dataReceivedQty" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRejectedQty" runat="server" Text="Rejected Qty:" AssociatedControlID="dataRejectedQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRejectedQty" Text='<%# Bind("RejectedQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRejectedQty" runat="server" Display="Dynamic" ControlToValidate="dataRejectedQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataRejectedQty" runat="server" Display="Dynamic" ControlToValidate="dataRejectedQty" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
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


