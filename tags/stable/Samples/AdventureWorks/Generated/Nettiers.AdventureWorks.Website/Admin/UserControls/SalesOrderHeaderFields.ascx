<%@ Control Language="C#" ClassName="SalesOrderHeaderFields" %>

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
        <td class="literal"><asp:Label ID="lbldataOrderDate" runat="server" Text="Order Date:" AssociatedControlID="dataOrderDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrderDate" Text='<%# Bind("OrderDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataOrderDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataOrderDate" runat="server" Display="Dynamic" ControlToValidate="dataOrderDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDueDate" runat="server" Text="Due Date:" AssociatedControlID="dataDueDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDueDate" Text='<%# Bind("DueDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDueDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataDueDate" runat="server" Display="Dynamic" ControlToValidate="dataDueDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShipDate" runat="server" Text="Ship Date:" AssociatedControlID="dataShipDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataShipDate" Text='<%# Bind("ShipDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataShipDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStatus" runat="server" Text="Status:" AssociatedControlID="dataStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOnlineOrderFlag" runat="server" Text="Online Order Flag:" AssociatedControlID="dataOnlineOrderFlag" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataOnlineOrderFlag" SelectedValue='<%# Bind("OnlineOrderFlag") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPurchaseOrderNumber" runat="server" Text="Purchase Order Number:" AssociatedControlID="dataPurchaseOrderNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPurchaseOrderNumber" Text='<%# Bind("PurchaseOrderNumber") %>' MaxLength="25"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAccountNumber" runat="server" Text="Account Number:" AssociatedControlID="dataAccountNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAccountNumber" Text='<%# Bind("AccountNumber") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerIdCustomerDataSource" DataTextField="AccountNumber" DataValueField="CustomerId" SelectedValue='<%# Bind("CustomerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CustomerDataSource ID="CustomerIdCustomerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataContactId" runat="server" Text="Contact Id:" AssociatedControlID="dataContactId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataContactId" DataSourceID="ContactIdContactDataSource" DataTextField="NameStyle" DataValueField="ContactId" SelectedValue='<%# Bind("ContactId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ContactDataSource ID="ContactIdContactDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person Id:" AssociatedControlID="dataSalesPersonId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource" DataTextField="SalesQuota" DataValueField="SalesPersonId" SelectedValue='<%# Bind("SalesPersonId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTerritoryId" runat="server" Text="Territory Id:" AssociatedControlID="dataTerritoryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTerritoryId" DataSourceID="TerritoryIdSalesTerritoryDataSource" DataTextField="Name" DataValueField="TerritoryId" SelectedValue='<%# Bind("TerritoryId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:SalesTerritoryDataSource ID="TerritoryIdSalesTerritoryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillToAddressId" runat="server" Text="Bill To Address Id:" AssociatedControlID="dataBillToAddressId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataBillToAddressId" DataSourceID="BillToAddressIdAddressDataSource" DataTextField="AddressLine1" DataValueField="AddressId" SelectedValue='<%# Bind("BillToAddressId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AddressDataSource ID="BillToAddressIdAddressDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShipToAddressId" runat="server" Text="Ship To Address Id:" AssociatedControlID="dataShipToAddressId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataShipToAddressId" DataSourceID="ShipToAddressIdAddressDataSource" DataTextField="AddressLine1" DataValueField="AddressId" SelectedValue='<%# Bind("ShipToAddressId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AddressDataSource ID="ShipToAddressIdAddressDataSource" runat="server" SelectMethod="GetAll"  />
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
        <td class="literal"><asp:Label ID="lbldataCreditCardId" runat="server" Text="Credit Card Id:" AssociatedControlID="dataCreditCardId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCreditCardId" DataSourceID="CreditCardIdCreditCardDataSource" DataTextField="CardType" DataValueField="CreditCardId" SelectedValue='<%# Bind("CreditCardId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CreditCardDataSource ID="CreditCardIdCreditCardDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreditCardApprovalCode" runat="server" Text="Credit Card Approval Code:" AssociatedControlID="dataCreditCardApprovalCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreditCardApprovalCode" Text='<%# Bind("CreditCardApprovalCode") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrencyRateId" runat="server" Text="Currency Rate Id:" AssociatedControlID="dataCurrencyRateId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCurrencyRateId" DataSourceID="CurrencyRateIdCurrencyRateDataSource" DataTextField="CurrencyRateDate" DataValueField="CurrencyRateId" SelectedValue='<%# Bind("CurrencyRateId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CurrencyRateDataSource ID="CurrencyRateIdCurrencyRateDataSource" runat="server" SelectMethod="GetAll"  />
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
        <td class="literal"><asp:Label ID="lbldataComment" runat="server" Text="Comment:" AssociatedControlID="dataComment" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataComment" Text='<%# Bind("Comment") %>' MaxLength="128"></asp:TextBox>
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


