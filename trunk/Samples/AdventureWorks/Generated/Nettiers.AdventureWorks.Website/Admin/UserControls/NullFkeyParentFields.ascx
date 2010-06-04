<%@ Control Language="C#" ClassName="NullFkeyParentFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataNullFkeyParentId" runat="server" Text="Null Fkey Parent Id:" AssociatedControlID="dataNullFkeyParentId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNullFkeyParentId" Text='<%# Bind("NullFkeyParentId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNullFkeyParentId" runat="server" Display="Dynamic" ControlToValidate="dataNullFkeyParentId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataNullFkeyParentId" runat="server" Display="Dynamic" ControlToValidate="dataNullFkeyParentId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
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


