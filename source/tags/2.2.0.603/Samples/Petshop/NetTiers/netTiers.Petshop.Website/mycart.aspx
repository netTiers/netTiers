<%@ Page Language="C#" MasterPageFile="~/MasterPages/global.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<CART:CartGrid runat="server" id="Cart1">
	<HeaderTemplate>
		<div align="right">click <CART:EmptyCartLinkButton Text="here" runat="Server" ID="Emptycart" NAME="Emptycart"/> to empty cart</div>
	</HeaderTemplate>
	<Columns>
		<CART:DeleteCartColumnLinkButton runat="server" Text="Delete" type="Button" ID="Deletecartcolumn1"/>
		<CART:QuantityCartColumnTextBox runat="server" HeaderText="Qty" Size="5" maxlength="8" ID="Quantitycartcolumntextbox1">
			<HeaderStyle Font-Bold="True" ></HeaderStyle>
		</CART:QuantityCartColumnTextBox>
		<CART:TemplateCartColumn runat="server" HeaderText="Code" ID="Templatecartcolumn1">
			<HeaderStyle Font-Bold="True" ></HeaderStyle>
			<ItemTemplate>
				<a href="<%#Container.Item.ProductLink%>"><%#Container.Item.Code%></a>
			</ItemTemplate>			
		</CART:TemplateCartColumn>
		<CART:TemplateCartColumn runat="server" HeaderText="Description" ID="Templatecartcolumn2">
			<HeaderStyle Font-Bold="True" ></HeaderStyle>
			<ItemTemplate>
				<%#Container.Item.Description%>
			</ItemTemplate>
		</CART:TemplateCartColumn>
		<CART:TemplateCartColumn runat="Server" HeaderText="Amount" ID="Templatecartcolumn4">
			<HeaderStyle Font-Bold="True" Wrap="false" ></HeaderStyle>
			<ItemStyle Wrap="false" HorizontalAlign="Right" ></ItemStyle>
			<ItemTemplate>
				<%#Container.Item.RealPrice.ToString("c")%>
			</ItemTemplate>
		</CART:TemplateCartColumn>
		<CART:TemplateCartColumn runat="Server" HeaderText="Total" ID="Templatecartcolumn5">
			<HeaderStyle Font-Bold="True" Wrap="false"></HeaderStyle>
			<ItemStyle Wrap="false" HorizontalAlign="Right"></ItemStyle>
			<ItemTemplate>
				<b><%#Container.Item.FreeTaxAmount.ToString("c")%></b>
			</ItemTemplate>
		</CART:TemplateCartColumn>
	</Columns>
	<FooterTemplate>
		<br>
		<table border="0" cellpadding="4" cellspacing="0" width="100%">
			<tr>
				<td rowspan="3" width="100%" valign="middle" align="center">
					If you have modify a quantity, click on the next button:<br>
					<asp:Button Runat="server" Text="Refresh" ID="Button1"/> 
					<br>
					<br>
					<a href="<%#Container.ContinueShoppingLink%>">Click here to continue</a>
				</td>
				<td nowrap align="right">Sub-Total:</td>
				<td align="right" nowrap><b><%#Container.FreeTaxAmount.ToString("c")%></b></td>
			</tr>
			<tr>
				<td nowrap align="right">Applicable Taxes :</td>
				<td align="right" nowrap><b><%#Container.TaxAmount.ToString("c")%></b></td>
			</tr>
			<tr>
				<td nowrap align="right">Total Amount:</td>
				<td align="right" nowrap><b><%#Container.Amount.ToString("c")%></b></td>
			</tr>
		</table>
	</FooterTemplate>
	<EmptyCartTemplate>
		Your cart is empty<br>
		<a href="<%#Container.ContinueShoppingLink%>">Click here to continue</a>
	</EmptyCartTemplate>
</CART:CartGrid>
</asp:Content>

