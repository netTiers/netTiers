<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItemUC.ascx.cs" Inherits="ItemUC" EnableTheming="true"%>
<asp:ObjectDataSource 
	ID="objDsList" 
	runat="server"  
	TypeName="netTiers.PetShop.DataAccessLayer.Bases.ItemProviderBase" 
	DataObjectTypeName="netTiers.PetShop.Item" 
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
	TypeName="netTiers.PetShop.DataAccessLayer.Bases.ItemProviderBase"
	DataObjectTypeName="netTiers.PetShop.Item"
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

<asp:ObjectDataSource ID="objDsProductId" runat="server" SelectMethod="GetAll" TypeName="netTiers.PetShop.DataAccessLayer.Bases.ProductProviderBase" DataObjectTypeName="netTiers.PetShop.Product"  OnObjectCreating="objDsProductId_ObjectCreating">
</asp:ObjectDataSource>

&nbsp;&nbsp;
<asp:Table runat="server" ID="tblFilter" SkinID="FilterTable">
	<asp:TableRow runat="server">
		<asp:TableCell runat="server" SkinID="TitleCell">
			<asp:label id="lblTitle" runat="server" SkinID="TitleLabel" >Item</asp:label>
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow runat="server">
		<asp:TableCell runat="server" SkinID="FilterCell">
			<asp:Table runat="server" SkinID="FilterTableInner">
				<asp:TableRow runat="server">
					<asp:TableCell runat="server">&nbsp;Filter: 
						<asp:dropdownlist id="ddlFilterColumn" runat="server" SkinID="FilterColumn">
							<asp:ListItem Value="Id" Text="Id"></asp:ListItem>
							<asp:ListItem Value="Name" Text="Name"></asp:ListItem>
							<asp:ListItem Value="Description" Text="Description"></asp:ListItem>
							<asp:ListItem Value="Price" Text="Price"></asp:ListItem>
							<asp:ListItem Value="Currency" Text="Currency"></asp:ListItem>
							<asp:ListItem Value="Photo" Text="Photo"></asp:ListItem>
							<asp:ListItem Value="ProductId" Text="ProductId"></asp:ListItem>
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
						<asp:DropDownList runat="server" id="ddlFilterProductId" DataSourceID="objDsProductId" DataTextField="Name" DataValueField="Id" style="display:none;"></asp:DropDownList>
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
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Name" SkinID="GridHeaderLabel" Text='Name'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblName" runat="server" Text='<%# FormatField(Container.DataItem,"Name") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Description" SkinID="GridHeaderLabel" Text='Description'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblDescription" runat="server" Text='<%# FormatField(Container.DataItem,"Description") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Price" SkinID="GridHeaderLabel" Text='Price'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblPrice" runat="server" Text='<%# FormatField(Container.DataItem,"Price") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Currency" SkinID="GridHeaderLabel" Text='Currency'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblCurrency" runat="server" Text='<%# FormatField(Container.DataItem,"Currency") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Photo" SkinID="GridHeaderLabel" Text='Photo'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblPhoto" runat="server" Text='<%# FormatField(Container.DataItem,"Photo") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:Label runat="server" Text="ProductIdSource<br/>Name" />
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblProductId" runat="server" Text='<%# FormatField(Container.DataItem,"ProductIdSource.Name") %>' />
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
	<asp:HiddenField ID="updateName" Value='<%# Bind("Name") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateDescription" Value='<%# Bind("Description") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updatePrice" Value='<%# Bind("Price") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateCurrency" Value='<%# Bind("Currency") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updatePhoto" Value='<%# Bind("Photo") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateProductId" Value='<%# Bind("ProductId") %>' runat="server"></asp:HiddenField>
		<asp:Table runat="server" SkinID="EditTable" >
				<asp:TableRow runat="server">
					<asp:TableCell runat="server" height="40">
						<span class="titlebox">Edit Item</span>
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
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Name:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataName" Text='<%# Bind("Name") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Description:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataDescription" Text='<%# Bind("Description") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Price:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataPrice" Text='<%# Bind("Price") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPrice" runat="server" Display="Dynamic" ControlToValidate="dataPrice" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Currency:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataCurrency" Text='<%# Bind("Currency") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Photo:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataPhoto" Text='<%# Bind("Photo") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">ProductId:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:DropDownList runat="server" id="dataProductId" DataSourceID="objDsProductId" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductId") %>'></asp:DropDownList>
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
	<asp:HiddenField ID="insertName" Value='<%# Bind("Name") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertDescription" Value='<%# Bind("Description") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertPrice" Value='<%# Bind("Price") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertCurrency" Value='<%# Bind("Currency") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertPhoto" Value='<%# Bind("Photo") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertProductId" Value='<%# Bind("ProductId") %>' runat="server"></asp:HiddenField>
		<asp:Table runat="server" SkinID="EditTable" >
				<asp:TableRow runat="server">
					<asp:TableCell runat="server" height="40">
						<span class="titlebox">New Item</span>
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
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Name:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertName" Text='<%# Bind("Name") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataInsertName" runat="server" Display="Dynamic" ControlToValidate="dataInsertName" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Description:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertDescription" Text='<%# Bind("Description") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Price:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertPrice" Text='<%# Bind("Price") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataInsertPrice" runat="server" Display="Dynamic" ControlToValidate="dataInsertPrice" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Currency:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertCurrency" Text='<%# Bind("Currency") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Photo:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertPhoto" Text='<%# Bind("Photo") %>' MaxLength="255"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">ProductId:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:DropDownList runat="server" id="dataInsertProductId" DataSourceID="objDsProductId" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductId") %>'></asp:DropDownList>
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
				case "ProductId":
					HideAll(containerName);
					ShowElement(containerName + "_ddlFilterProductId");
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
	HideElement(containerName + "_ddlFilterProductId");
	
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

