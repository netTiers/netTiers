<%@ Control Language="C#" ClassName="TestVariantFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataVariantField" runat="server" Text="Variant Field:" AssociatedControlID="dataVariantField" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataVariantField" Value='<%# Bind("VariantField") %>'></asp:HiddenField>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


