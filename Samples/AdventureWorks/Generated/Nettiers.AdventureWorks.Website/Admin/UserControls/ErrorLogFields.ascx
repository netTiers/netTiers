<%@ Control Language="C#" ClassName="ErrorLogFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataErrorTime" runat="server" Text="Error Time:" AssociatedControlID="dataErrorTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataErrorTime" Text='<%# Bind("ErrorTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataErrorTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataErrorTime" runat="server" Display="Dynamic" ControlToValidate="dataErrorTime" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserName" runat="server" Text="User Name:" AssociatedControlID="dataUserName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserName" Text='<%# Bind("UserName") %>' MaxLength="128"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserName" runat="server" Display="Dynamic" ControlToValidate="dataUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataErrorNumber" runat="server" Text="Error Number:" AssociatedControlID="dataErrorNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataErrorNumber" Text='<%# Bind("ErrorNumber") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataErrorNumber" runat="server" Display="Dynamic" ControlToValidate="dataErrorNumber" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataErrorNumber" runat="server" Display="Dynamic" ControlToValidate="dataErrorNumber" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataErrorSeverity" runat="server" Text="Error Severity:" AssociatedControlID="dataErrorSeverity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataErrorSeverity" Text='<%# Bind("ErrorSeverity") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataErrorSeverity" runat="server" Display="Dynamic" ControlToValidate="dataErrorSeverity" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataErrorState" runat="server" Text="Error State:" AssociatedControlID="dataErrorState" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataErrorState" Text='<%# Bind("ErrorState") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataErrorState" runat="server" Display="Dynamic" ControlToValidate="dataErrorState" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataErrorProcedure" runat="server" Text="Error Procedure:" AssociatedControlID="dataErrorProcedure" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataErrorProcedure" Text='<%# Bind("ErrorProcedure") %>' MaxLength="126"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataErrorLine" runat="server" Text="Error Line:" AssociatedControlID="dataErrorLine" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataErrorLine" Text='<%# Bind("ErrorLine") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataErrorLine" runat="server" Display="Dynamic" ControlToValidate="dataErrorLine" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataErrorMessage" runat="server" Text="Error Message:" AssociatedControlID="dataErrorMessage" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataErrorMessage" Text='<%# Bind("ErrorMessage") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataErrorMessage" runat="server" Display="Dynamic" ControlToValidate="dataErrorMessage" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


