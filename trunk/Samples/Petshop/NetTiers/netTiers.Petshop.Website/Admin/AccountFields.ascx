<%@ Control Language="C#" ClassName="AccountFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td>Id:</td>
				<td><asp:TextBox runat="server" id="dataId" Text='<%# Bind("Id") %>' MaxLength="36"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			<tr>
				<td>FirstName:</td>
				<td><asp:TextBox runat="server" id="dataFirstName" Text='<%# Bind("FirstName") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>LastName:</td>
				<td><asp:TextBox runat="server" id="dataLastName" Text='<%# Bind("LastName") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>StreetAddress:</td>
				<td><asp:TextBox runat="server" id="dataStreetAddress" Text='<%# Bind("StreetAddress") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>PostalCode:</td>
				<td><asp:TextBox runat="server" id="dataPostalCode" Text='<%# Bind("PostalCode") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>City:</td>
				<td><asp:TextBox runat="server" id="dataCity" Text='<%# Bind("City") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>StateOrProvince:</td>
				<td><asp:TextBox runat="server" id="dataStateOrProvince" Text='<%# Bind("StateOrProvince") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>Country:</td>
				<td><asp:TextBox runat="server" id="dataCountry" Text='<%# Bind("Country") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>TelephoneNumber:</td>
				<td><asp:TextBox runat="server" id="dataTelephoneNumber" Text='<%# Bind("TelephoneNumber") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>Email:</td>
				<td><asp:TextBox runat="server" id="dataEmail" Text='<%# Bind("Email") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>Login:</td>
				<td><asp:TextBox runat="server" id="dataLogin" Text='<%# Bind("Login") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>Password:</td>
				<td><asp:TextBox runat="server" id="dataPassword" Text='<%# Bind("Password") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>IWantMyList:</td>
				<td><asp:RadioButtonList runat="server" id="dataIWantMyList" SelectedValue='<%# Bind("IWantMyList") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList><br /></td>
			</tr>				
			<tr>
				<td>IWantPetTips:</td>
				<td><asp:RadioButtonList runat="server" id="dataIWantPetTips" SelectedValue='<%# Bind("IWantPetTips") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList><br /></td>
			</tr>				
			<tr>
				<td>FavoriteLanguage:</td>
				<td><asp:TextBox runat="server" id="dataFavoriteLanguage" Text='<%# Bind("FavoriteLanguage") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>CreditCardId:</td>
				<td><asp:DropDownList runat="server" id="dataCreditCardId" DataSourceID="CreditCardDataSource" DataTextField="Number" DataValueField="Id" SelectedValue='<%# Bind("CreditCardId") %>'></asp:DropDownList>
		<data:EntityDataSource ID="CreditCardDataSource" runat="server"
 				ProviderName="CreditCardProvider"
 				EntityTypeName="Entities.CreditCard, Entities"
 				EntityKeyTypeName="System.String"
 				EntityKeyName="Id"
 				SelectMethod="GetAll"
 		>
		</data:EntityDataSource>
<br /></td>
			</tr>				
			<tr>
				<td>FavoriteCategoryId:</td>
				<td><asp:DropDownList runat="server" id="dataFavoriteCategoryId" DataSourceID="CategoryDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("FavoriteCategoryId") %>'></asp:DropDownList>
		<data:EntityDataSource ID="CategoryDataSource" runat="server"
 				ProviderName="CategoryProvider"
 				EntityTypeName="Entities.Category, Entities"
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


