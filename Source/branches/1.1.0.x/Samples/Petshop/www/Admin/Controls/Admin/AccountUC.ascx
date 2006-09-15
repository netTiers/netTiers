<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountUC.ascx.cs" Inherits="AccountUC" EnableTheming="true"%>
<asp:ObjectDataSource 
	ID="objDsList" 
	runat="server"  
	TypeName="netTiers.PetShop.DataAccessLayer.Bases.AccountProviderBase" 
	DataObjectTypeName="netTiers.PetShop.Account" 
	SelectMethod="GetPaged"
	DeleteMethod="Delete" 
	SortParameterName="orderBy" 
	EnablePaging="True"  
	StartRowIndexParameterName="start"
	MaximumRowsParameterName="pageLength" 
	OnSelecting="objDsList_Selecting" 
	OnSelected="objDsList_Selected"
	OnDeleted="objDsList_Deleted"
	OnObjectCreating="objDsList_ObjectCreating"
	SelectCountMethod="GetTotalItems"
>
	<SelectParameters>
		<asp:Parameter Name="whereClause" Type="String" />
		<asp:Parameter Direction="Output" Name="count" Type="Int32" />
	</SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource 
	ID="objDsEdit" 
	runat="server" 
	TypeName="netTiers.PetShop.DataAccessLayer.Bases.AccountProviderBase"
	DataObjectTypeName="netTiers.PetShop.Account"
	DeleteMethod="Delete" 
	InsertMethod="Insert" 
	SelectMethod="GetById"
	UpdateMethod="Update"
	OnUpdating="objDsEdit_Updating"
	OnUpdated="objDsEdit_Updated"
	OnDeleted="objDsEdit_Deleted" 
	OnInserting="objDsEdit_Inserting"
	OnInserted="objDsEdit_Inserted" 
	OnSelected="objDsEdit_Selected" 
	OnObjectCreating="objDsEdit_ObjectCreating"
	
>
	<SelectParameters>
		<asp:ControlParameter ControlID="gvList" Name="Id" PropertyName="SelectedDataKey.Values['Id']" Type="String" />
	</SelectParameters>
	<DeleteParameters>
		<asp:Parameter Name="Id" Type="String" />
	</DeleteParameters>
	<UpdateParameters>
    </UpdateParameters>

</asp:ObjectDataSource>

<asp:ObjectDataSource ID="objDsFavoriteCategoryId" runat="server" SelectMethod="GetAll" TypeName="netTiers.PetShop.DataAccessLayer.Bases.CategoryProviderBase" DataObjectTypeName="netTiers.PetShop.Category"  OnObjectCreating="objDsFavoriteCategoryId_ObjectCreating" OnSelected="objDsFavoriteCategoryId_Selected">
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="objDsCreditCardId" runat="server" SelectMethod="GetAll" TypeName="netTiers.PetShop.DataAccessLayer.Bases.CreditCardProviderBase" DataObjectTypeName="netTiers.PetShop.CreditCard"  OnObjectCreating="objDsCreditCardId_ObjectCreating" OnSelected="objDsCreditCardId_Selected">
</asp:ObjectDataSource>

&nbsp;&nbsp;
<asp:Table runat="server" ID="tblFilter" SkinID="FilterTable">
	<asp:TableRow runat="server">
		<asp:TableCell runat="server" SkinID="TitleCell">
			<asp:label id="lblTitle" runat="server" SkinID="TitleLabel" >Account</asp:label>
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow runat="server">
		<asp:TableCell runat="server" SkinID="FilterCell">
			<asp:Table runat="server" SkinID="FilterTableInner">
				<asp:TableRow runat="server">
					<asp:TableCell runat="server">&nbsp;Filter: 
						<asp:dropdownlist id="ddlFilterColumn" runat="server" SkinID="FilterColumn">
							<asp:ListItem Value="Id" Text="Id"></asp:ListItem>
							<asp:ListItem Value="FirstName" Text="FirstName"></asp:ListItem>
							<asp:ListItem Value="LastName" Text="LastName"></asp:ListItem>
							<asp:ListItem Value="StreetAddress" Text="StreetAddress"></asp:ListItem>
							<asp:ListItem Value="PostalCode" Text="PostalCode"></asp:ListItem>
							<asp:ListItem Value="City" Text="City"></asp:ListItem>
							<asp:ListItem Value="StateOrProvince" Text="StateOrProvince"></asp:ListItem>
							<asp:ListItem Value="Country" Text="Country"></asp:ListItem>
							<asp:ListItem Value="TelephoneNumber" Text="TelephoneNumber"></asp:ListItem>
							<asp:ListItem Value="Email" Text="Email"></asp:ListItem>
							<asp:ListItem Value="Login" Text="Login"></asp:ListItem>
							<asp:ListItem Value="Password" Text="Password"></asp:ListItem>
							<asp:ListItem Value="IWantMyList" Text="IWantMyList"></asp:ListItem>
							<asp:ListItem Value="IWantPetTips" Text="IWantPetTips"></asp:ListItem>
							<asp:ListItem Value="FavoriteLanguage" Text="FavoriteLanguage"></asp:ListItem>
							<asp:ListItem Value="CreditCardId" Text="CreditCardId"></asp:ListItem>
							<asp:ListItem Value="FavoriteCategoryId" Text="FavoriteCategoryId"></asp:ListItem>
							<asp:ListItem Value="Timestamp" Text="Timestamp"></asp:ListItem>
						</asp:dropdownlist>
						<asp:dropdownlist id="ddlFilterOperator" runat="server" SkinID="FilterOperator">
							<asp:ListItem Value="LIKE">Starts with</asp:ListItem>
							<asp:ListItem Value="=">Is Exactly</asp:ListItem>
							<asp:ListItem Value="&gt;">Greater Than</asp:ListItem>
							<asp:ListItem Value="&lt;">Less Than</asp:ListItem>
						</asp:dropdownlist>
						<asp:textbox id="txtFilterCriteria" runat="server" SkinID="FilterCriteria"></asp:textbox>
						
						<!--Foreign Key Filter Lists-->
						<asp:DropDownList runat="server" id="ddlFilterFavoriteCategoryId" DataSourceID="objDsFavoriteCategoryId" DataTextField="Name" DataValueField="Id" style="display:none;"></asp:DropDownList><asp:DropDownList runat="server" id="ddlFilterCreditCardId" DataSourceID="objDsCreditCardId" DataTextField="Number" DataValueField="Id" style="display:none;"></asp:DropDownList>
					</asp:TableCell>
					<asp:TableCell>
						<asp:Button id="btnFilter" runat="server" Text="Filter" SkinID="GridFilterButton" OnClick="btnFilter_Click"></asp:Button>&nbsp;
						<asp:Button id="btnClearFilter" runat="server" Text="Clear" SkinID="GridFilterClearButton" OnClick="btnClearFilter_Click"></asp:Button>
					</asp:TableCell>
				</asp:TableRow>
			</asp:Table>
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow runat="server">
		<asp:TableCell runat="server">
			<asp:GridView SkinID="AdminList" ID="gvList" AutogenerateColumns="false" runat="server" DataSourceID="objDsList" DataKeyNames="Id,OriginalId,Timestamp" OnRowCommand="gvList_RowCommand" AllowSorting="true">
				<Columns>
					<asp:TemplateField ShowHeader="False">
						<HeaderTemplate>
							<asp:Button ID="cmdAdd" runat="server" CommandName="New" CausesValidation="False" Text="Add" SkinID="GridAddButton" />
						</HeaderTemplate>
						<ItemTemplate>
						
							<asp:ImageButton ID="btnEdit" runat="server" SkinID="GridEditButton" CausesValidation="False" CommandName="Select" ></asp:ImageButton>
							<asp:ImageButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
								OnClientClick="return confirm('Are you sure you want to delete this record?');" SkinID="GridDeleteButton"></asp:ImageButton>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Id" SkinID="GridHeaderLabel" Text='Id'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblId" runat="server" Text='<%# FormatField(Container.DataItem,"Id") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="FirstName" SkinID="GridHeaderLabel" Text='FirstName'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblFirstName" runat="server" Text='<%# FormatField(Container.DataItem,"FirstName") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="LastName" SkinID="GridHeaderLabel" Text='LastName'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblLastName" runat="server" Text='<%# FormatField(Container.DataItem,"LastName") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="StreetAddress" SkinID="GridHeaderLabel" Text='StreetAddress'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblStreetAddress" runat="server" Text='<%# FormatField(Container.DataItem,"StreetAddress") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="PostalCode" SkinID="GridHeaderLabel" Text='PostalCode'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblPostalCode" runat="server" Text='<%# FormatField(Container.DataItem,"PostalCode") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="City" SkinID="GridHeaderLabel" Text='City'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblCity" runat="server" Text='<%# FormatField(Container.DataItem,"City") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="StateOrProvince" SkinID="GridHeaderLabel" Text='StateOrProvince'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblStateOrProvince" runat="server" Text='<%# FormatField(Container.DataItem,"StateOrProvince") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Country" SkinID="GridHeaderLabel" Text='Country'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblCountry" runat="server" Text='<%# FormatField(Container.DataItem,"Country") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="TelephoneNumber" SkinID="GridHeaderLabel" Text='TelephoneNumber'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblTelephoneNumber" runat="server" Text='<%# FormatField(Container.DataItem,"TelephoneNumber") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Email" SkinID="GridHeaderLabel" Text='Email'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblEmail" runat="server" Text='<%# FormatField(Container.DataItem,"Email") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Login" SkinID="GridHeaderLabel" Text='Login'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblLogin" runat="server" Text='<%# FormatField(Container.DataItem,"Login") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Password" SkinID="GridHeaderLabel" Text='Password'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblPassword" runat="server" Text='<%# FormatField(Container.DataItem,"Password") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="IWantMyList" SkinID="GridHeaderLabel" Text='IWantMyList'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblIWantMyList" runat="server" Text='<%# FormatField(Container.DataItem,"IWantMyList") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="IWantPetTips" SkinID="GridHeaderLabel" Text='IWantPetTips'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblIWantPetTips" runat="server" Text='<%# FormatField(Container.DataItem,"IWantPetTips") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="FavoriteLanguage" SkinID="GridHeaderLabel" Text='FavoriteLanguage'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblFavoriteLanguage" runat="server" Text='<%# FormatField(Container.DataItem,"FavoriteLanguage") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:Label runat="server" Text="CreditCardIdSource<br/>Number" />
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblCreditCardId" runat="server" Text='<%# FormatField(Container.DataItem,"CreditCardIdSource.Number") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:Label runat="server" Text="FavoriteCategoryIdSource<br/>Name" />
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblFavoriteCategoryId" runat="server" Text='<%# FormatField(Container.DataItem,"FavoriteCategoryIdSource.Name") %>' />
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<EmptyDataTemplate>
				    No records found.&nbsp;&nbsp;<asp:Button ID="cmdAdd" runat="server" CommandName="New" CausesValidation="False" Text="Add" SkinID="GridAddButton" />
				</EmptyDataTemplate>
			</asp:GridView>
		</asp:TableCell>
	</asp:TableRow>
</asp:Table>
&nbsp; &nbsp;<asp:FormView ID="fvEditor" SkinID="AdminEdit" runat="server" DataKeyNames="Id,OriginalId,Timestamp" DataSourceID="objDsEdit" 
OnItemCommand="fvEditor_ItemCommand" 
OnItemDeleted="fvEditor_ItemDeleted" 
OnItemInserted="fvEditor_ItemInserted" 
OnItemUpdated="fvEditor_ItemUpdated"
OnDataBound="fvEditor_DataBound"
OnItemUpdating="fvEditor_ItemUpdating"
OnItemInserting="fvEditor_ItemInserting"
Visible="false">
	<EditItemTemplate>		
	<asp:HiddenField ID="updateId" Value='<%# Bind("Id") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateFirstName" Value='<%# Bind("FirstName") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateLastName" Value='<%# Bind("LastName") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateStreetAddress" Value='<%# Bind("StreetAddress") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updatePostalCode" Value='<%# Bind("PostalCode") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateCity" Value='<%# Bind("City") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateStateOrProvince" Value='<%# Bind("StateOrProvince") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateCountry" Value='<%# Bind("Country") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateTelephoneNumber" Value='<%# Bind("TelephoneNumber") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateEmail" Value='<%# Bind("Email") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateLogin" Value='<%# Bind("Login") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updatePassword" Value='<%# Bind("Password") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateIWantMyList" Value='<%# Bind("IWantMyList") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateIWantPetTips" Value='<%# Bind("IWantPetTips") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateFavoriteLanguage" Value='<%# Bind("FavoriteLanguage") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateCreditCardId" Value='<%# Bind("CreditCardId") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateFavoriteCategoryId" Value='<%# Bind("FavoriteCategoryId") %>' runat="server"></asp:HiddenField>
		<asp:Table runat="server" SkinID="EditTable" >
				<asp:TableRow runat="server">
					<asp:TableCell runat="server" height="40">
						<span class="titlebox">Edit Account</span>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow runat="server" Visible="false">
					<asp:TableCell runat="server" ID="tcError"></asp:TableCell>
				</asp:TableRow>
				<asp:TableRow runat="server">
					<asp:TableCell runat="server" BackColor="AliceBlue">
						<asp:Table runat="server" CellPadding="3" CellSpacing="1">
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Id:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataId" Text='<%# Bind("Id") %>' MaxLength="36"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">FirstName:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataFirstName" Text='<%# Bind("FirstName") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">LastName:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataLastName" Text='<%# Bind("LastName") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">StreetAddress:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataStreetAddress" Text='<%# Bind("StreetAddress") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">PostalCode:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataPostalCode" Text='<%# Bind("PostalCode") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">City:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataCity" Text='<%# Bind("City") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">StateOrProvince:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataStateOrProvince" Text='<%# Bind("StateOrProvince") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Country:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataCountry" Text='<%# Bind("Country") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">TelephoneNumber:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataTelephoneNumber" Text='<%# Bind("TelephoneNumber") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Email:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataEmail" Text='<%# Bind("Email") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Login:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataLogin" Text='<%# Bind("Login") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Password:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataPassword" Text='<%# Bind("Password") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">IWantMyList:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:RadioButtonList runat="server" id="dataIWantMyList" SelectedValue='<%# Bind("IWantMyList") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">IWantPetTips:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:RadioButtonList runat="server" id="dataIWantPetTips" SelectedValue='<%# Bind("IWantPetTips") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">FavoriteLanguage:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataFavoriteLanguage" Text='<%# Bind("FavoriteLanguage") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">CreditCardId:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:DropDownList runat="server" id="dataCreditCardId" DataSourceID="objDsCreditCardId" DataTextField="Number" DataValueField="Id" SelectedValue='<%# BindWithNull(Eval("CreditCardId"),string.Empty) %>'></asp:DropDownList>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">FavoriteCategoryId:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:DropDownList runat="server" id="dataFavoriteCategoryId" DataSourceID="objDsFavoriteCategoryId" DataTextField="Name" DataValueField="Id" SelectedValue='<%# BindWithNull(Eval("FavoriteCategoryId"),string.Empty) %>'></asp:DropDownList>
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableFooterRow runat="server">
					<asp:TableCell runat="server">
						<asp:Table runat="server" Width="100%">
							<asp:TableRow runat="server">
								<asp:TableCell runat="server">
		
									<asp:Button ID="btnSave" runat="server" Text="Save" SkinID="EditorSaveButton" CommandName="Update"></asp:Button>&nbsp;
									<asp:Button ID="btnDelete" runat="server" CausesValidation="False" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?');"
										 SkinID="EditorDeleteButton"></asp:Button>
								</asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="right">
									<asp:Button ID="btnCancel" runat="server" CausesValidation="False"
										Text="Cancel" SkinID="EditorCancelButton"></asp:Button>
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</asp:TableCell>
				</asp:TableFooterRow>
			</asp:Table>
	</EditItemTemplate>
	<ItemTemplate>
	
	</ItemTemplate>
	<InsertItemTemplate>
	<asp:HiddenField ID="insertId" Value='<%# Bind("Id") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertFirstName" Value='<%# Bind("FirstName") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertLastName" Value='<%# Bind("LastName") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertStreetAddress" Value='<%# Bind("StreetAddress") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertPostalCode" Value='<%# Bind("PostalCode") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertCity" Value='<%# Bind("City") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertStateOrProvince" Value='<%# Bind("StateOrProvince") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertCountry" Value='<%# Bind("Country") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertTelephoneNumber" Value='<%# Bind("TelephoneNumber") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertEmail" Value='<%# Bind("Email") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertLogin" Value='<%# Bind("Login") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertPassword" Value='<%# Bind("Password") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertIWantMyList" Value='<%# Bind("IWantMyList") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertIWantPetTips" Value='<%# Bind("IWantPetTips") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertFavoriteLanguage" Value='<%# Bind("FavoriteLanguage") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertCreditCardId" Value='<%# Bind("CreditCardId") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertFavoriteCategoryId" Value='<%# Bind("FavoriteCategoryId") %>' runat="server"></asp:HiddenField>
		<asp:Table runat="server" SkinID="EditTable" >
				<asp:TableRow runat="server">
					<asp:TableCell runat="server" height="40">
						<span class="titlebox">New Account</span>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow runat="server" Visible="false">
					<asp:TableCell runat="server" ID="tcError"></asp:TableCell>
				</asp:TableRow>
				<asp:TableRow runat="server">
					<asp:TableCell runat="server" BackColor="AliceBlue">
						<asp:Table runat="server" CellPadding="3" CellSpacing="1">
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Id:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertId" Text='<%# Bind("Id") %>' MaxLength="36"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataInsertId" runat="server" Display="Dynamic" ControlToValidate="dataInsertId" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">FirstName:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertFirstName" Text='<%# Bind("FirstName") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">LastName:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertLastName" Text='<%# Bind("LastName") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">StreetAddress:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertStreetAddress" Text='<%# Bind("StreetAddress") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">PostalCode:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertPostalCode" Text='<%# Bind("PostalCode") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">City:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertCity" Text='<%# Bind("City") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">StateOrProvince:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertStateOrProvince" Text='<%# Bind("StateOrProvince") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Country:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertCountry" Text='<%# Bind("Country") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">TelephoneNumber:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertTelephoneNumber" Text='<%# Bind("TelephoneNumber") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Email:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertEmail" Text='<%# Bind("Email") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Login:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertLogin" Text='<%# Bind("Login") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Password:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertPassword" Text='<%# Bind("Password") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">IWantMyList:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:RadioButtonList runat="server" id="dataInsertIWantMyList" SelectedValue='<%# Bind("IWantMyList") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">IWantPetTips:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:RadioButtonList runat="server" id="dataInsertIWantPetTips" SelectedValue='<%# Bind("IWantPetTips") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">FavoriteLanguage:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertFavoriteLanguage" Text='<%# Bind("FavoriteLanguage") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">CreditCardId:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:DropDownList runat="server" id="dataInsertCreditCardId" DataSourceID="objDsCreditCardId" DataTextField="Number" DataValueField="Id" SelectedValue='<%# BindWithNull(Eval("CreditCardId"),string.Empty) %>'></asp:DropDownList>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">FavoriteCategoryId:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:DropDownList runat="server" id="dataInsertFavoriteCategoryId" DataSourceID="objDsFavoriteCategoryId" DataTextField="Name" DataValueField="Id" SelectedValue='<%# BindWithNull(Eval("FavoriteCategoryId"),string.Empty) %>'></asp:DropDownList>
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableFooterRow runat="server">
					<asp:TableCell runat="server">
						<asp:Table runat="server" Width="100%">
							<asp:TableRow runat="server">
								<asp:TableCell runat="server">
		
									<asp:Button ID="btnSave" runat="server" Text="Save" SkinID="EditorSaveButton" CommandName="Insert"></asp:Button>&nbsp;
								</asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="right">
									<asp:Button ID="btnCancel" runat="server" CausesValidation="False"
										Text="Cancel" SkinID="EditorCancelButton"></asp:Button>
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</asp:TableCell>
				</asp:TableFooterRow>
			</asp:Table>
	</InsertItemTemplate>	
</asp:FormView>


<script language="javascript" type="text/javascript">

function ShowFilter(containerName)
{
	
	if ( document.getElementById )
	{
		var oFilter = document.getElementById(containerName + "_ddlFilterColumn");
		if ( oFilter )
		{
			
			var filterColumn = oFilter.options[oFilter.selectedIndex].value;
			
			switch ( filterColumn )
			{
				case "FavoriteCategoryId":
					HideAll(containerName);
					ShowElement(containerName + "_ddlFilterFavoriteCategoryId");
					break;
				case "CreditCardId":
					HideAll(containerName);
					ShowElement(containerName + "_ddlFilterCreditCardId");
					break;
				default:
					HideAll(containerName);
					ShowDefault(containerName);
					break;
			}	
		}
	}
	
}

function ShowDefault(containerName)
{
	ShowElement(containerName + "_txtFilterCriteria");
	ShowElement(containerName + "_ddlFilterOperator");
}

function HideAll(containerName)
{

	HideElement(containerName + "_txtFilterCriteria");
	HideElement(containerName + "_ddlFilterOperator");
	HideElement(containerName + "_ddlFilterFavoriteCategoryId");
	HideElement(containerName + "_ddlFilterCreditCardId");
	
}

function HideElement(elementId)
{
	if ( document.getElementById )
	{
		o = document.getElementById(elementId);
		if ( o )
		{
			o.style.display = "none";
		}
	}
}

function ShowElement(elementId)
{
	if ( document.getElementById )
	{
		o = document.getElementById(elementId);
		if ( o )
		{
			o.style.display = "";
		}
	}
}

</script>

