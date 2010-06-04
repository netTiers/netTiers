<%@ Control Language="C#" ClassName="CustomerFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTerritoryId" runat="server" Text="Territory Id:" AssociatedControlID="dataTerritoryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTerritoryId" DataSourceID="TerritoryIdSalesTerritoryDataSource" DataTextField="Name" DataValueField="TerritoryId" SelectedValue='<%# Bind("TerritoryId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:SalesTerritoryDataSource ID="TerritoryIdSalesTerritoryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerType" runat="server" Text="Customer Type:" AssociatedControlID="dataCustomerType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomerType" Text='<%# Bind("CustomerType") %>' MaxLength="1"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCustomerType" runat="server" Display="Dynamic" ControlToValidate="dataCustomerType" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


