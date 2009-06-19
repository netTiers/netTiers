<%@ Control Language="C#" ClassName="CreditCardFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td>Id:</td>
				<td><asp:TextBox runat="server" id="dataId" Text='<%# Bind("Id") %>' MaxLength="36"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			<tr>
				<td>Number:</td>
				<td><asp:TextBox runat="server" id="dataNumber" Text='<%# Bind("Number") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNumber" runat="server" Display="Dynamic" ControlToValidate="dataNumber" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			<tr>
				<td>CardType:</td>
				<td><asp:TextBox runat="server" id="dataCardType" Text='<%# Bind("CardType") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCardType" runat="server" Display="Dynamic" ControlToValidate="dataCardType" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			<tr>
				<td>ExpiryMonth:</td>
				<td><asp:TextBox runat="server" id="dataExpiryMonth" Text='<%# Bind("ExpiryMonth") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataExpiryMonth" runat="server" Display="Dynamic" ControlToValidate="dataExpiryMonth" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			<tr>
				<td>ExpiryYear:</td>
				<td><asp:TextBox runat="server" id="dataExpiryYear" Text='<%# Bind("ExpiryYear") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataExpiryYear" runat="server" Display="Dynamic" ControlToValidate="dataExpiryYear" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


