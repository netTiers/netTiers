<%@ Control Language="C#" ClassName="ProductModelProductDescriptionCultureFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductModelId" runat="server" Text="Product Model Id:" AssociatedControlID="dataProductModelId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductModelId" DataSourceID="ProductModelIdProductModelDataSource" DataTextField="Name" DataValueField="ProductModelId" SelectedValue='<%# Bind("ProductModelId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductModelDataSource ID="ProductModelIdProductModelDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductDescriptionId" runat="server" Text="Product Description Id:" AssociatedControlID="dataProductDescriptionId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductDescriptionId" DataSourceID="ProductDescriptionIdProductDescriptionDataSource" DataTextField="Description" DataValueField="ProductDescriptionId" SelectedValue='<%# Bind("ProductDescriptionId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductDescriptionDataSource ID="ProductDescriptionIdProductDescriptionDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCultureId" runat="server" Text="Culture Id:" AssociatedControlID="dataCultureId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCultureId" DataSourceID="CultureIdCultureDataSource" DataTextField="Name" DataValueField="CultureId" SelectedValue='<%# Bind("CultureId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CultureDataSource ID="CultureIdCultureDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedDate" runat="server" Text="Modified Date:" AssociatedControlID="dataModifiedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedDate" Text='<%# Bind("ModifiedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataModifiedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataModifiedDate" runat="server" Display="Dynamic" ControlToValidate="dataModifiedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


