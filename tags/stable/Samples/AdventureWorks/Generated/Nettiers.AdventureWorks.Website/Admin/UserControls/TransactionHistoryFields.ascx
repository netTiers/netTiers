<%@ Control Language="C#" ClassName="TransactionHistoryFields" %>

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
        <td class="literal"><asp:Label ID="lbldataReferenceOrderId" runat="server" Text="Reference Order Id:" AssociatedControlID="dataReferenceOrderId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReferenceOrderId" Text='<%# Bind("ReferenceOrderId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataReferenceOrderId" runat="server" Display="Dynamic" ControlToValidate="dataReferenceOrderId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataReferenceOrderId" runat="server" Display="Dynamic" ControlToValidate="dataReferenceOrderId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReferenceOrderLineId" runat="server" Text="Reference Order Line Id:" AssociatedControlID="dataReferenceOrderLineId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReferenceOrderLineId" Text='<%# Bind("ReferenceOrderLineId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataReferenceOrderLineId" runat="server" Display="Dynamic" ControlToValidate="dataReferenceOrderLineId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataReferenceOrderLineId" runat="server" Display="Dynamic" ControlToValidate="dataReferenceOrderLineId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTransactionDate" runat="server" Text="Transaction Date:" AssociatedControlID="dataTransactionDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTransactionDate" Text='<%# Bind("TransactionDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataTransactionDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataTransactionDate" runat="server" Display="Dynamic" ControlToValidate="dataTransactionDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTransactionType" runat="server" Text="Transaction Type:" AssociatedControlID="dataTransactionType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTransactionType" Text='<%# Bind("TransactionType") %>' MaxLength="1"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTransactionType" runat="server" Display="Dynamic" ControlToValidate="dataTransactionType" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataQuantity" runat="server" Text="Quantity:" AssociatedControlID="dataQuantity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataQuantity" Text='<%# Bind("Quantity") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActualCost" runat="server" Text="Actual Cost:" AssociatedControlID="dataActualCost" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataActualCost" Text='<%# Bind("ActualCost") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataActualCost" runat="server" Display="Dynamic" ControlToValidate="dataActualCost" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataActualCost"  runat="server" ControlToValidate="dataActualCost" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
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


