<%@ Control Language="C#" ClassName="ProductPhotoFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataThumbNailPhoto" runat="server" Text="Thumb Nail Photo:" AssociatedControlID="dataThumbNailPhoto" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataThumbNailPhoto" Value='<%# Bind("ThumbNailPhoto") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataThumbnailPhotoFileName" runat="server" Text="Thumbnail Photo File Name:" AssociatedControlID="dataThumbnailPhotoFileName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataThumbnailPhotoFileName" Text='<%# Bind("ThumbnailPhotoFileName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLargePhoto" runat="server" Text="Large Photo:" AssociatedControlID="dataLargePhoto" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataLargePhoto" Value='<%# Bind("LargePhoto") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLargePhotoFileName" runat="server" Text="Large Photo File Name:" AssociatedControlID="dataLargePhotoFileName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLargePhotoFileName" Text='<%# Bind("LargePhotoFileName") %>' MaxLength="50"></asp:TextBox>
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


