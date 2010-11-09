<%@ Control Language="C#" ClassName="DatabaseLogFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostTime" runat="server" Text="Post Time:" AssociatedControlID="dataPostTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostTime" Text='<%# Bind("PostTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataPostTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataPostTime" runat="server" Display="Dynamic" ControlToValidate="dataPostTime" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDatabaseUser" runat="server" Text="Database User:" AssociatedControlID="dataDatabaseUser" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDatabaseUser" Text='<%# Bind("DatabaseUser") %>' MaxLength="128"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDatabaseUser" runat="server" Display="Dynamic" ControlToValidate="dataDatabaseUser" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSafeNameEvent" runat="server" Text="Event:" AssociatedControlID="dataSafeNameEvent" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSafeNameEvent" Text='<%# Bind("SafeNameEvent") %>' MaxLength="128"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSafeNameEvent" runat="server" Display="Dynamic" ControlToValidate="dataSafeNameEvent" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSchema" runat="server" Text="Schema:" AssociatedControlID="dataSchema" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSchema" Text='<%# Bind("Schema") %>' MaxLength="128"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSafeNameObject" runat="server" Text="Object:" AssociatedControlID="dataSafeNameObject" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSafeNameObject" Text='<%# Bind("SafeNameObject") %>' MaxLength="128"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTsql" runat="server" Text="Tsql:" AssociatedControlID="dataTsql" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTsql" Text='<%# Bind("Tsql") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTsql" runat="server" Display="Dynamic" ControlToValidate="dataTsql" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataXmlEvent" runat="server" Text="Xml Event:" AssociatedControlID="dataXmlEvent" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataXmlEvent" Value='<%# Bind("XmlEvent") %>'></asp:HiddenField>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


