<%@ Control Language="C#" ClassName="ItemFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td>Id:</td>
				<td><asp:TextBox runat="server" id="dataId" Text='<%# Bind("Id") %>' MaxLength="36"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			<tr>
				<td>Name:</td>
				<td><asp:TextBox runat="server" id="dataName" Text='<%# Bind("Name") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			<tr>
				<td>Description:</td>
				<td><asp:TextBox runat="server" id="dataDescription" Text='<%# Bind("Description") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>Price:</td>
				<td><asp:TextBox runat="server" id="dataPrice" Text='<%# Bind("Price") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPrice" runat="server" Display="Dynamic" ControlToValidate="dataPrice" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator><br /></td>
			</tr>				
			<tr>
				<td>Currency:</td>
				<td><asp:TextBox runat="server" id="dataCurrency" Text='<%# Bind("Currency") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>Photo:</td>
				<td><asp:TextBox runat="server" id="dataPhoto" Text='<%# Bind("Photo") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>ProductId:</td>
				<td><asp:DropDownList runat="server" id="dataProductId" DataSourceID="ProductDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductId") %>'></asp:DropDownList>
		<data:EntityDataSource ID="ProductDataSource" runat="server"
 				ProviderName="ProductProvider"
 				EntityTypeName="Entities.Product, Entities"
 				EntityKeyTypeName="System.String"
 				EntityKeyName="Id"
 				SelectMethod="GetAll"
 		>
		</data:EntityDataSource>
<br /></td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


