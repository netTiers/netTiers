<%@ Control Language="C#" ClassName="AwBuildVersionFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDatabaseVersion" runat="server" Text="Database Version:" AssociatedControlID="dataDatabaseVersion" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDatabaseVersion" Text='<%# Bind("DatabaseVersion") %>' MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDatabaseVersion" runat="server" Display="Dynamic" ControlToValidate="dataDatabaseVersion" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataVersionDate" runat="server" Text="Version Date:" AssociatedControlID="dataVersionDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataVersionDate" Text='<%# Bind("VersionDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataVersionDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataVersionDate" runat="server" Display="Dynamic" ControlToValidate="dataVersionDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


