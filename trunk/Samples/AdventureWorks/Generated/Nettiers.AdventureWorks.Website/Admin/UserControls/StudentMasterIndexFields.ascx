<%@ Control Language="C#" ClassName="StudentMasterIndexFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddressLine1" runat="server" Text="Address Line1:" AssociatedControlID="dataAddressLine1" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddressLine1" Text='<%# Bind("AddressLine1") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddressLine2" runat="server" Text="Address Line2:" AssociatedControlID="dataAddressLine2" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddressLine2" Text='<%# Bind("AddressLine2") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddressLine3" runat="server" Text="Address Line3:" AssociatedControlID="dataAddressLine3" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddressLine3" Text='<%# Bind("AddressLine3") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEslPhase" runat="server" Text="Esl Phase:" AssociatedControlID="dataEslPhase" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEslPhase" Text='<%# Bind("EslPhase") %>' MaxLength="25"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTribalGroup" runat="server" Text="Tribal Group:" AssociatedControlID="dataTribalGroup" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTribalGroup" Text='<%# Bind("TribalGroup") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSlpCreatedFlag" runat="server" Text="Slp Created Flag:" AssociatedControlID="dataSlpCreatedFlag" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSlpCreatedFlag" Text='<%# Bind("SlpCreatedFlag") %>' MaxLength="3"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddressLine4" runat="server" Text="Address Line4:" AssociatedControlID="dataAddressLine4" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddressLine4" Text='<%# Bind("AddressLine4") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhone2" runat="server" Text="Phone2:" AssociatedControlID="dataPhone2" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhone2" Text='<%# Bind("Phone2") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSourceSystem" runat="server" Text="Source System:" AssociatedControlID="dataSourceSystem" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSourceSystem" Text='<%# Bind("SourceSystem") %>' MaxLength="25"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhoneticMatchId" runat="server" Text="Phonetic Match Id:" AssociatedControlID="dataPhoneticMatchId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhoneticMatchId" Text='<%# Bind("PhoneticMatchId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPhoneticMatchId" runat="server" Display="Dynamic" ControlToValidate="dataPhoneticMatchId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSuburb" runat="server" Text="Suburb:" AssociatedControlID="dataSuburb" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSuburb" Text='<%# Bind("Suburb") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostcode" runat="server" Text="Postcode:" AssociatedControlID="dataPostcode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostcode" Text='<%# Bind("Postcode") %>' MaxLength="4"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhone1" runat="server" Text="Phone1:" AssociatedControlID="dataPhone1" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhone1" Text='<%# Bind("Phone1") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSsabsaId" runat="server" Text="Ssabsa Id:" AssociatedControlID="dataSsabsaId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSsabsaId" Text='<%# Bind("SsabsaId") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSurname" runat="server" Text="Surname:" AssociatedControlID="dataSurname" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSurname" Text='<%# Bind("Surname") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirstName" runat="server" Text="First Name:" AssociatedControlID="dataFirstName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirstName" Text='<%# Bind("FirstName") %>' MaxLength="25"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStudentId" runat="server" Text="Student Id:" AssociatedControlID="dataStudentId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStudentId" Text='<%# Bind("StudentId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataStudentId" runat="server" Display="Dynamic" ControlToValidate="dataStudentId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataStudentId" runat="server" Display="Dynamic" ControlToValidate="dataStudentId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEpassId" runat="server" Text="Epass Id:" AssociatedControlID="dataEpassId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEpassId" Text='<%# Bind("EpassId") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStudentUpn" runat="server" Text="Student Upn:" AssociatedControlID="dataStudentUpn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStudentUpn" Text='<%# Bind("StudentUpn") %>' MaxLength="13"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOtherNames" runat="server" Text="Other Names:" AssociatedControlID="dataOtherNames" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOtherNames" Text='<%# Bind("OtherNames") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGender" runat="server" Text="Gender:" AssociatedControlID="dataGender" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGender" Text='<%# Bind("Gender") %>' MaxLength="6"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIndigeneousStatus" runat="server" Text="Indigeneous Status:" AssociatedControlID="dataIndigeneousStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIndigeneousStatus" Text='<%# Bind("IndigeneousStatus") %>' MaxLength="40"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLbote" runat="server" Text="Lbote:" AssociatedControlID="dataLbote" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLbote" Text='<%# Bind("Lbote") %>' MaxLength="3"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataKnownName" runat="server" Text="Known Name:" AssociatedControlID="dataKnownName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataKnownName" Text='<%# Bind("KnownName") %>' MaxLength="25"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLegalName" runat="server" Text="Legal Name:" AssociatedControlID="dataLegalName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLegalName" Text='<%# Bind("LegalName") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDob" runat="server" Text="Dob:" AssociatedControlID="dataDob" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDob" Text='<%# Bind("Dob", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDob" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


