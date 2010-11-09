<%@ Control Language="C#" ClassName="ProductFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductNumber" runat="server" Text="Product Number:" AssociatedControlID="dataProductNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductNumber" Text='<%# Bind("ProductNumber") %>' MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProductNumber" runat="server" Display="Dynamic" ControlToValidate="dataProductNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMakeFlag" runat="server" Text="Make Flag:" AssociatedControlID="dataMakeFlag" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataMakeFlag" SelectedValue='<%# Bind("MakeFlag") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFinishedGoodsFlag" runat="server" Text="Finished Goods Flag:" AssociatedControlID="dataFinishedGoodsFlag" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataFinishedGoodsFlag" SelectedValue='<%# Bind("FinishedGoodsFlag") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataColor" runat="server" Text="Color:" AssociatedControlID="dataColor" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataColor" Text='<%# Bind("Color") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSafetyStockLevel" runat="server" Text="Safety Stock Level:" AssociatedControlID="dataSafetyStockLevel" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSafetyStockLevel" Text='<%# Bind("SafetyStockLevel") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSafetyStockLevel" runat="server" Display="Dynamic" ControlToValidate="dataSafetyStockLevel" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSafetyStockLevel" runat="server" Display="Dynamic" ControlToValidate="dataSafetyStockLevel" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReorderPoint" runat="server" Text="Reorder Point:" AssociatedControlID="dataReorderPoint" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReorderPoint" Text='<%# Bind("ReorderPoint") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataReorderPoint" runat="server" Display="Dynamic" ControlToValidate="dataReorderPoint" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataReorderPoint" runat="server" Display="Dynamic" ControlToValidate="dataReorderPoint" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStandardCost" runat="server" Text="Standard Cost:" AssociatedControlID="dataStandardCost" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStandardCost" Text='<%# Bind("StandardCost") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataStandardCost" runat="server" Display="Dynamic" ControlToValidate="dataStandardCost" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataStandardCost"  runat="server" ControlToValidate="dataStandardCost" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataListPrice" runat="server" Text="List Price:" AssociatedControlID="dataListPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataListPrice" Text='<%# Bind("ListPrice") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataListPrice" runat="server" Display="Dynamic" ControlToValidate="dataListPrice" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExVal_dataListPrice"  runat="server" ControlToValidate="dataListPrice" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSize" runat="server" Text="Size:" AssociatedControlID="dataSize" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSize" Text='<%# Bind("Size") %>' MaxLength="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSizeUnitMeasureCode" runat="server" Text="Size Unit Measure Code:" AssociatedControlID="dataSizeUnitMeasureCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSizeUnitMeasureCode" DataSourceID="SizeUnitMeasureCodeUnitMeasureDataSource" DataTextField="Name" DataValueField="UnitMeasureCode" SelectedValue='<%# Bind("SizeUnitMeasureCode") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:UnitMeasureDataSource ID="SizeUnitMeasureCodeUnitMeasureDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWeightUnitMeasureCode" runat="server" Text="Weight Unit Measure Code:" AssociatedControlID="dataWeightUnitMeasureCode" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataWeightUnitMeasureCode" DataSourceID="WeightUnitMeasureCodeUnitMeasureDataSource" DataTextField="Name" DataValueField="UnitMeasureCode" SelectedValue='<%# Bind("WeightUnitMeasureCode") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:UnitMeasureDataSource ID="WeightUnitMeasureCodeUnitMeasureDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWeight" runat="server" Text="Weight:" AssociatedControlID="dataWeight" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWeight" Text='<%# Bind("Weight") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWeight" runat="server" Display="Dynamic" ControlToValidate="dataWeight" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDaysToManufacture" runat="server" Text="Days To Manufacture:" AssociatedControlID="dataDaysToManufacture" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDaysToManufacture" Text='<%# Bind("DaysToManufacture") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDaysToManufacture" runat="server" Display="Dynamic" ControlToValidate="dataDaysToManufacture" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataDaysToManufacture" runat="server" Display="Dynamic" ControlToValidate="dataDaysToManufacture" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductLine" runat="server" Text="Product Line:" AssociatedControlID="dataProductLine" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductLine" Text='<%# Bind("ProductLine") %>' MaxLength="2"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSafeNameClass" runat="server" Text="Class:" AssociatedControlID="dataSafeNameClass" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSafeNameClass" Text='<%# Bind("SafeNameClass") %>' MaxLength="2"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStyle" runat="server" Text="Style:" AssociatedControlID="dataStyle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStyle" Text='<%# Bind("Style") %>' MaxLength="2"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductSubcategoryId" runat="server" Text="Product Subcategory Id:" AssociatedControlID="dataProductSubcategoryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductSubcategoryId" DataSourceID="ProductSubcategoryIdProductSubcategoryDataSource" DataTextField="Name" DataValueField="ProductSubcategoryId" SelectedValue='<%# Bind("ProductSubcategoryId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ProductSubcategoryDataSource ID="ProductSubcategoryIdProductSubcategoryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductModelId" runat="server" Text="Product Model Id:" AssociatedControlID="dataProductModelId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductModelId" DataSourceID="ProductModelIdProductModelDataSource" DataTextField="Name" DataValueField="ProductModelId" SelectedValue='<%# Bind("ProductModelId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ProductModelDataSource ID="ProductModelIdProductModelDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSellStartDate" runat="server" Text="Sell Start Date:" AssociatedControlID="dataSellStartDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSellStartDate" Text='<%# Bind("SellStartDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataSellStartDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataSellStartDate" runat="server" Display="Dynamic" ControlToValidate="dataSellStartDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSellEndDate" runat="server" Text="Sell End Date:" AssociatedControlID="dataSellEndDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSellEndDate" Text='<%# Bind("SellEndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataSellEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiscontinuedDate" runat="server" Text="Discontinued Date:" AssociatedControlID="dataDiscontinuedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiscontinuedDate" Text='<%# Bind("DiscontinuedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDiscontinuedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


