<%@ Control Language="C#" ClassName="SpecialOfferProductFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSpecialOfferId" runat="server" Text="Special Offer Id:" AssociatedControlID="dataSpecialOfferId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSpecialOfferId" DataSourceID="SpecialOfferIdSpecialOfferDataSource" DataTextField="Description" DataValueField="SpecialOfferId" SelectedValue='<%# Bind("SpecialOfferId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SpecialOfferDataSource ID="SpecialOfferIdSpecialOfferDataSource" runat="server" SelectMethod="GetAll"  />
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
        <td class="literal"><asp:Label ID="lbldataModifiedDate" runat="server" Text="Modified Date:" AssociatedControlID="dataModifiedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedDate" Text='<%# Bind("ModifiedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataModifiedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataModifiedDate" runat="server" Display="Dynamic" ControlToValidate="dataModifiedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


