<%@ Control Language="C#" ClassName="WorkOrderFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductId" runat="server" Text="Product Id:" AssociatedControlID="dataProductId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductId" DataSourceID="ProductIdProductDataSource" DataTextField="Name" DataValueField="ProductId" SelectedValue='<%# Bind("ProductId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductDataSource ID="ProductIdProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrderQty" runat="server" Text="Order Qty:" AssociatedControlID="dataOrderQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrderQty" Text='<%# Bind("OrderQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataOrderQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataOrderQty" runat="server" Display="Dynamic" ControlToValidate="dataOrderQty" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataScrappedQty" runat="server" Text="Scrapped Qty:" AssociatedControlID="dataScrappedQty" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataScrappedQty" Text='<%# Bind("ScrappedQty") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataScrappedQty" runat="server" Display="Dynamic" ControlToValidate="dataScrappedQty" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataScrappedQty" runat="server" Display="Dynamic" ControlToValidate="dataScrappedQty" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
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
        <td class="literal"><asp:Label ID="lbldataDueDate" runat="server" Text="Due Date:" AssociatedControlID="dataDueDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDueDate" Text='<%# Bind("DueDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDueDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataDueDate" runat="server" Display="Dynamic" ControlToValidate="dataDueDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataScrapReasonId" runat="server" Text="Scrap Reason Id:" AssociatedControlID="dataScrapReasonId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataScrapReasonId" DataSourceID="ScrapReasonIdScrapReasonDataSource" DataTextField="Name" DataValueField="ScrapReasonId" SelectedValue='<%# Bind("ScrapReasonId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ScrapReasonDataSource ID="ScrapReasonIdScrapReasonDataSource" runat="server" SelectMethod="GetAll"  />
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


