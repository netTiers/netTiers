﻿<%@ Control Language="C#" ClassName="VendorAddressFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataVendorId" runat="server" Text="Vendor Id:" AssociatedControlID="dataVendorId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataVendorId" DataSourceID="VendorIdVendorDataSource" DataTextField="AccountNumber" DataValueField="VendorId" SelectedValue='<%# Bind("VendorId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:VendorDataSource ID="VendorIdVendorDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddressId" runat="server" Text="Address Id:" AssociatedControlID="dataAddressId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAddressId" DataSourceID="AddressIdAddressDataSource" DataTextField="AddressLine1" DataValueField="AddressId" SelectedValue='<%# Bind("AddressId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AddressDataSource ID="AddressIdAddressDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddressTypeId" runat="server" Text="Address Type Id:" AssociatedControlID="dataAddressTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAddressTypeId" DataSourceID="AddressTypeIdAddressTypeDataSource" DataTextField="Name" DataValueField="AddressTypeId" SelectedValue='<%# Bind("AddressTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AddressTypeDataSource ID="AddressTypeIdAddressTypeDataSource" runat="server" SelectMethod="GetAll"  />
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


