<%@ Control Language="C#" ClassName="TestProductFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataImageFileType" runat="server" Text="Image File Type:" AssociatedControlID="dataImageFileType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataImageFileType" Text='<%# Bind("ImageFileType") %>' MaxLength="1"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFullImageFileType" runat="server" Text="Full Image File Type:" AssociatedControlID="dataFullImageFileType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFullImageFileType" Text='<%# Bind("FullImageFileType") %>' MaxLength="1"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrgProductId" runat="server" Text="Org Product Id:" AssociatedControlID="dataOrgProductId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrgProductId" Text='<%# Bind("OrgProductId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataOrgProductId" runat="server" Display="Dynamic" ControlToValidate="dataOrgProductId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataConnectorCode" runat="server" Text="Connector Code:" AssociatedControlID="dataConnectorCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataConnectorCode" Text='<%# Bind("ConnectorCode") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBaseId" runat="server" Text="Base Id:" AssociatedControlID="dataBaseId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBaseId" Text='<%# Bind("BaseId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataBaseId" runat="server" Display="Dynamic" ControlToValidate="dataBaseId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdatedBy" runat="server" Text="Updated By:" AssociatedControlID="dataUpdatedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdatedBy" Text='<%# Bind("UpdatedBy") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataUpdatedBy" runat="server" Display="Dynamic" ControlToValidate="dataUpdatedBy" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdatedDate" runat="server" Text="Updated Date:" AssociatedControlID="dataUpdatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdatedDate" Text='<%# Bind("UpdatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddedDate" runat="server" Text="Added Date:" AssociatedControlID="dataAddedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddedDate" Text='<%# Bind("AddedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataAddedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStatus" runat="server" Text="Status:" AssociatedControlID="dataStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>' MaxLength="1"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddedBy" runat="server" Text="Added By:" AssociatedControlID="dataAddedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddedBy" Text='<%# Bind("AddedBy") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataAddedBy" runat="server" Display="Dynamic" ControlToValidate="dataAddedBy" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductLink" runat="server" Text="Product Link:" AssociatedControlID="dataProductLink" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductLink" Text='<%# Bind("ProductLink") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBrandName" runat="server" Text="Brand Name:" AssociatedControlID="dataBrandName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBrandName" Text='<%# Bind("BrandName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductName" runat="server" Text="Product Name:" AssociatedControlID="dataProductName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductName" Text='<%# Bind("ProductName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataManufacturerId" runat="server" Text="Manufacturer Id:" AssociatedControlID="dataManufacturerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataManufacturerId" Text='<%# Bind("ManufacturerId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataManufacturerId" runat="server" Display="Dynamic" ControlToValidate="dataManufacturerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductTypeId" runat="server" Text="Product Type Id:" AssociatedControlID="dataProductTypeId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductTypeId" Text='<%# Bind("ProductTypeId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataProductTypeId" runat="server" Display="Dynamic" ControlToValidate="dataProductTypeId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDownloadId" runat="server" Text="Download Id:" AssociatedControlID="dataDownloadId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDownloadId" Text='<%# Bind("DownloadId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDownloadId" runat="server" Display="Dynamic" ControlToValidate="dataDownloadId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModelName" runat="server" Text="Model Name:" AssociatedControlID="dataModelName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModelName" Text='<%# Bind("ModelName") %>' MaxLength="150"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayName" runat="server" Text="Display Name:" AssociatedControlID="dataDisplayName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayName" Text='<%# Bind("DisplayName") %>' MaxLength="150"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTypeName" runat="server" Text="Type Name:" AssociatedControlID="dataTypeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTypeName" Text='<%# Bind("TypeName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductCode" runat="server" Text="Product Code:" AssociatedControlID="dataProductCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductCode" Text='<%# Bind("ProductCode") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUniqueIdentifier" runat="server" Text="Unique Identifier:" AssociatedControlID="dataUniqueIdentifier" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUniqueIdentifier" Text='<%# Bind("UniqueIdentifier") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


