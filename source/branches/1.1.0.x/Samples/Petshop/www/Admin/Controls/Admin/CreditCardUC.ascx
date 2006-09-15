<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreditCardUC.ascx.cs" Inherits="CreditCardUC" EnableTheming="true"%>
<asp:ObjectDataSource 
	ID="objDsList" 
	runat="server"  
	TypeName="netTiers.PetShop.DataAccessLayer.Bases.CreditCardProviderBase" 
	DataObjectTypeName="netTiers.PetShop.CreditCard" 
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
	TypeName="netTiers.PetShop.DataAccessLayer.Bases.CreditCardProviderBase"
	DataObjectTypeName="netTiers.PetShop.CreditCard"
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

&nbsp;&nbsp;
<asp:Table runat="server" ID="tblFilter" SkinID="FilterTable">
	<asp:TableRow runat="server">
		<asp:TableCell runat="server" SkinID="TitleCell">
			<asp:label id="lblTitle" runat="server" SkinID="TitleLabel" >CreditCard</asp:label>
		</asp:TableCell>
	</asp:TableRow>
	<asp:TableRow runat="server">
		<asp:TableCell runat="server" SkinID="FilterCell">
			<asp:Table runat="server" SkinID="FilterTableInner">
				<asp:TableRow runat="server">
					<asp:TableCell runat="server">&nbsp;Filter: 
						<asp:dropdownlist id="ddlFilterColumn" runat="server" SkinID="FilterColumn">
							<asp:ListItem Value="Id" Text="Id"></asp:ListItem>
							<asp:ListItem Value="Number" Text="Number"></asp:ListItem>
							<asp:ListItem Value="CardType" Text="CardType"></asp:ListItem>
							<asp:ListItem Value="ExpiryMonth" Text="ExpiryMonth"></asp:ListItem>
							<asp:ListItem Value="ExpiryYear" Text="ExpiryYear"></asp:ListItem>
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
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Number" SkinID="GridHeaderLabel" Text='Number'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblNumber" runat="server" Text='<%# FormatField(Container.DataItem,"Number") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="CardType" SkinID="GridHeaderLabel" Text='CardType'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblCardType" runat="server" Text='<%# FormatField(Container.DataItem,"CardType") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="ExpiryMonth" SkinID="GridHeaderLabel" Text='ExpiryMonth'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblExpiryMonth" runat="server" Text='<%# FormatField(Container.DataItem,"ExpiryMonth") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderTemplate>
							<asp:LinkButton runat="server" CommandName="Sort" CommandArgument="ExpiryYear" SkinID="GridHeaderLabel" Text='ExpiryYear'/>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label ID="lblExpiryYear" runat="server" Text='<%# FormatField(Container.DataItem,"ExpiryYear") %>' />
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
	<asp:HiddenField ID="updateNumber" Value='<%# Bind("Number") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateCardType" Value='<%# Bind("CardType") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateExpiryMonth" Value='<%# Bind("ExpiryMonth") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="updateExpiryYear" Value='<%# Bind("ExpiryYear") %>' runat="server"></asp:HiddenField>
		<asp:Table runat="server" SkinID="EditTable" >
				<asp:TableRow runat="server">
					<asp:TableCell runat="server" height="40">
						<span class="titlebox">Edit CreditCard</span>
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
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Number:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataNumber" Text='<%# Bind("Number") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNumber" runat="server" Display="Dynamic" ControlToValidate="dataNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">CardType:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataCardType" Text='<%# Bind("CardType") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCardType" runat="server" Display="Dynamic" ControlToValidate="dataCardType" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">ExpiryMonth:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataExpiryMonth" Text='<%# Bind("ExpiryMonth") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataExpiryMonth" runat="server" Display="Dynamic" ControlToValidate="dataExpiryMonth" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">ExpiryYear:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataExpiryYear" Text='<%# Bind("ExpiryYear") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataExpiryYear" runat="server" Display="Dynamic" ControlToValidate="dataExpiryYear" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
	<asp:HiddenField ID="insertNumber" Value='<%# Bind("Number") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertCardType" Value='<%# Bind("CardType") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertExpiryMonth" Value='<%# Bind("ExpiryMonth") %>' runat="server"></asp:HiddenField>
	<asp:HiddenField ID="insertExpiryYear" Value='<%# Bind("ExpiryYear") %>' runat="server"></asp:HiddenField>
		<asp:Table runat="server" SkinID="EditTable" >
				<asp:TableRow runat="server">
					<asp:TableCell runat="server" height="40">
						<span class="titlebox">New CreditCard</span>
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
								<asp:TableCell runat="server" SkinID="EditorLabelCell">Number:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertNumber" Text='<%# Bind("Number") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataInsertNumber" runat="server" Display="Dynamic" ControlToValidate="dataInsertNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">CardType:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertCardType" Text='<%# Bind("CardType") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataInsertCardType" runat="server" Display="Dynamic" ControlToValidate="dataInsertCardType" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">ExpiryMonth:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertExpiryMonth" Text='<%# Bind("ExpiryMonth") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataInsertExpiryMonth" runat="server" Display="Dynamic" ControlToValidate="dataInsertExpiryMonth" ErrorMessage="Required"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow runat="server">
								<asp:TableCell runat="server" SkinID="EditorLabelCell">ExpiryYear:</asp:TableCell>
								<asp:TableCell runat="server" SkinID="EditorDataCell">
									<asp:TextBox runat="server" id="dataInsertExpiryYear" Text='<%# Bind("ExpiryYear") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataInsertExpiryYear" runat="server" Display="Dynamic" ControlToValidate="dataInsertExpiryYear" ErrorMessage="Required"></asp:RequiredFieldValidator>
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

