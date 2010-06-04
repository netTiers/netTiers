<%@ Control Language="C#" ClassName="NullFkeyChildFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataNullFkeyChildId" runat="server" Text="Null Fkey Child Id:" AssociatedControlID="dataNullFkeyChildId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNullFkeyChildId" Text='<%# Bind("NullFkeyChildId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNullFkeyChildId" runat="server" Display="Dynamic" ControlToValidate="dataNullFkeyChildId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataNullFkeyChildId" runat="server" Display="Dynamic" ControlToValidate="dataNullFkeyChildId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNullFkeyParentId" runat="server" Text="Null Fkey Parent Id:" AssociatedControlID="dataNullFkeyParentId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataNullFkeyParentId" DataSourceID="NullFkeyParentIdNullFkeyParentDataSource" DataTextField="SomeText" DataValueField="NullFkeyParentId" SelectedValue='<%# Bind("NullFkeyParentId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:NullFkeyParentDataSource ID="NullFkeyParentIdNullFkeyParentDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSomeText" runat="server" Text="Some Text:" AssociatedControlID="dataSomeText" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSomeText" Text='<%# Bind("SomeText") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


