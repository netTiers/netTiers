<%@ Control Language="C#" ClassName="ProductReviewFields" %>

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
        <td class="literal"><asp:Label ID="lbldataReviewerName" runat="server" Text="Reviewer Name:" AssociatedControlID="dataReviewerName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReviewerName" Text='<%# Bind("ReviewerName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataReviewerName" runat="server" Display="Dynamic" ControlToValidate="dataReviewerName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReviewDate" runat="server" Text="Review Date:" AssociatedControlID="dataReviewDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReviewDate" Text='<%# Bind("ReviewDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataReviewDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataReviewDate" runat="server" Display="Dynamic" ControlToValidate="dataReviewDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailAddress" runat="server" Text="Email Address:" AssociatedControlID="dataEmailAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmailAddress" Text='<%# Bind("EmailAddress") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmailAddress" runat="server" Display="Dynamic" ControlToValidate="dataEmailAddress" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRating" runat="server" Text="Rating:" AssociatedControlID="dataRating" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRating" Text='<%# Bind("Rating") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRating" runat="server" Display="Dynamic" ControlToValidate="dataRating" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataRating" runat="server" Display="Dynamic" ControlToValidate="dataRating" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataComments" runat="server" Text="Comments:" AssociatedControlID="dataComments" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataComments" Text='<%# Bind("Comments") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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


