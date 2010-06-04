<%@ Control Language="C#" ClassName="TimestampPkFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSomeText" runat="server" Text="Some Text:" AssociatedControlID="dataSomeText" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSomeText" Text='<%# Bind("SomeText") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


