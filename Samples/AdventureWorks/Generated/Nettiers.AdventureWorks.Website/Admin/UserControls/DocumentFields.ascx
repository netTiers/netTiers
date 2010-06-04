<%@ Control Language="C#" ClassName="DocumentFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTitle" runat="server" Text="Title:" AssociatedControlID="dataTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTitle" Text='<%# Bind("Title") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTitle" runat="server" Display="Dynamic" ControlToValidate="dataTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFileName" runat="server" Text="File Name:" AssociatedControlID="dataFileName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFileName" Text='<%# Bind("FileName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFileName" runat="server" Display="Dynamic" ControlToValidate="dataFileName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFileExtension" runat="server" Text="File Extension:" AssociatedControlID="dataFileExtension" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFileExtension" Text='<%# Bind("FileExtension") %>' MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFileExtension" runat="server" Display="Dynamic" ControlToValidate="dataFileExtension" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRevision" runat="server" Text="Revision:" AssociatedControlID="dataRevision" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRevision" Text='<%# Bind("Revision") %>' MaxLength="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRevision" runat="server" Display="Dynamic" ControlToValidate="dataRevision" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataChangeNumber" runat="server" Text="Change Number:" AssociatedControlID="dataChangeNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataChangeNumber" Text='<%# Bind("ChangeNumber") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataChangeNumber" runat="server" Display="Dynamic" ControlToValidate="dataChangeNumber" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataChangeNumber" runat="server" Display="Dynamic" ControlToValidate="dataChangeNumber" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStatus" runat="server" Text="Status:" AssociatedControlID="dataStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStatus" Text='<%# Bind("Status") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataStatus" runat="server" Display="Dynamic" ControlToValidate="dataStatus" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDocumentSummary" runat="server" Text="Document Summary:" AssociatedControlID="dataDocumentSummary" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDocumentSummary" Text='<%# Bind("DocumentSummary") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDocument" runat="server" Text="Document:" AssociatedControlID="dataDocument" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataDocument" Value='<%# Bind("Document") %>'></asp:HiddenField>
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


