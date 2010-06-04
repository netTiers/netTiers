<%@ Control Language="C#" ClassName="BillOfMaterialsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductAssemblyId" runat="server" Text="Product Assembly Id:" AssociatedControlID="dataProductAssemblyId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductAssemblyId" DataSourceID="ProductAssemblyIdProductDataSource" DataTextField="Name" DataValueField="ProductId" SelectedValue='<%# Bind("ProductAssemblyId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ProductDataSource ID="ProductAssemblyIdProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataComponentId" runat="server" Text="Component Id:" AssociatedControlID="dataComponentId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataComponentId" DataSourceID="ComponentIdProductDataSource" DataTextField="Name" DataValueField="ProductId" SelectedValue='<%# Bind("ComponentId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductDataSource ID="ComponentIdProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStartDate" runat="server" Text="Start Date:" AssociatedControlID="dataStartDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStartDate" Text='<%# Bind("StartDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataStartDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataStartDate" runat="server" Display="Dynamic" ControlToValidate="dataStartDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEndDate" runat="server" Text="End Date:" AssociatedControlID="dataEndDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEndDate" Text='<%# Bind("EndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUnitMeasureCode" runat="server" Text="Unit Measure Code:" AssociatedControlID="dataUnitMeasureCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataUnitMeasureCode" DataSourceID="UnitMeasureCodeUnitMeasureDataSource" DataTextField="Name" DataValueField="UnitMeasureCode" SelectedValue='<%# Bind("UnitMeasureCode") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:UnitMeasureDataSource ID="UnitMeasureCodeUnitMeasureDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBomLevel" runat="server" Text="Bom Level:" AssociatedControlID="dataBomLevel" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBomLevel" Text='<%# Bind("BomLevel") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBomLevel" runat="server" Display="Dynamic" ControlToValidate="dataBomLevel" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataBomLevel" runat="server" Display="Dynamic" ControlToValidate="dataBomLevel" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPerAssemblyQty" runat="server" Text="Per Assembly Qty:" AssociatedControlID="dataPerAssemblyQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPerAssemblyQty" Text='<%# Bind("PerAssemblyQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPerAssemblyQty" runat="server" Display="Dynamic" ControlToValidate="dataPerAssemblyQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataPerAssemblyQty" runat="server" Display="Dynamic" ControlToValidate="dataPerAssemblyQty" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
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


