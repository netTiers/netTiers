<%@ Control Language="C#" ClassName="TestTimestampFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDumbField" runat="server" Text="Dumb Field:" AssociatedControlID="dataDumbField" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataDumbField" SelectedValue='<%# Bind("DumbField") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


