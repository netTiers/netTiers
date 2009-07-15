<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressForm.ascx.cs" Inherits="PetShop.UI.Controls.AddressForm" %>

<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td class="label" valign="top" width="50%">
            First Name<br />
            <asp:TextBox ID="txtFirstName" runat="server" Columns="30" CssClass="checkoutTextbox"
                MaxLength="80" Width="155px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="valFirstName" runat="server" ControlToValidate="txtFirstName"
                CssClass="asterisk" ErrorMessage="Please enter first name."></asp:RequiredFieldValidator>&nbsp;&nbsp;
        </td>
        <td class="label" colspan="2" valign="top">
            Last Name<br />
            <asp:TextBox ID="txtLastName" runat="server" Columns="30" CssClass="checkoutTextbox"
                MaxLength="80" Width="155px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="valLastName" runat="server" ControlToValidate="txtLastName"
                CssClass="asterisk" ErrorMessage="Please enter last name."></asp:RequiredFieldValidator>&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td class="label" colspan="3" valign="top">
            Address<br />
            <asp:TextBox ID="txtAddress1" runat="server" Columns="55" CssClass="checkoutTextbox"
                MaxLength="80" Width="330px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="valAddress1" runat="server" ControlToValidate="txtAddress1"
                CssClass="asterisk" ErrorMessage="Please enter street address."></asp:RequiredFieldValidator>&nbsp;
            <br />
            <asp:TextBox ID="txtAddress2" runat="server" Columns="55" CssClass="checkoutTextbox"
                MaxLength="80" Width="330px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="label" style="height: 19px" valign="top" width="50%">
            City<br />
            <asp:TextBox ID="txtCity" runat="server" Columns="55" CssClass="checkoutTextbox"
                MaxLength="80" Width="155px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="valCity" runat="server" ControlToValidate="txtCity"
                CssClass="asterisk" ErrorMessage="Please enter city."></asp:RequiredFieldValidator>&nbsp;&nbsp;
        </td>
        <td class="label" style="height: 19px" valign="top" width="20%">
            State<br />
            <asp:DropDownList ID="listState" runat="server" CssClass="checkoutDropdown">
                <asp:ListItem Value="AL">ALABAMA</asp:ListItem>
                <asp:ListItem Value="AK">ALASKA</asp:ListItem>
                <asp:ListItem Value="AS">AMERICAN SAMOA</asp:ListItem>
                <asp:ListItem Value="AZ">ARIZONA</asp:ListItem>
                <asp:ListItem Value="AR">ARKANSAS</asp:ListItem>
                <asp:ListItem Value="CA">CALIFORNIA</asp:ListItem>
                <asp:ListItem Value="CO">COLORADO</asp:ListItem>
                <asp:ListItem Value="CT">CONNECTICUT</asp:ListItem>
                <asp:ListItem Value="DE">DELAWARE</asp:ListItem>
                <asp:ListItem Value="DC">DISTRICT OF COLUMBIA</asp:ListItem>
                <asp:ListItem Value="FL">FLORIDA</asp:ListItem>
                <asp:ListItem Value="GA">GEORGIA</asp:ListItem>
                <asp:ListItem Value="GU">GUAM</asp:ListItem>
                <asp:ListItem Value="HI">HAWAII</asp:ListItem>
                <asp:ListItem Value="ID">IDAHO</asp:ListItem>
                <asp:ListItem Value="IL">ILLINOIS</asp:ListItem>
                <asp:ListItem Value="IN">INDIANA</asp:ListItem>
                <asp:ListItem Value="IA">IOWA</asp:ListItem>
                <asp:ListItem Value="KS">KANSAS</asp:ListItem>
                <asp:ListItem Value="KY">KENTUCKY</asp:ListItem>
                <asp:ListItem Value="LA">LOUISIANA</asp:ListItem>
                <asp:ListItem Value="ME">MAINE</asp:ListItem>
                <asp:ListItem Value="MH">MARSHALL ISLANDS</asp:ListItem>
                <asp:ListItem Value="MD">MARYLAND</asp:ListItem>
                <asp:ListItem Value="MA">MASSACHUSETTS</asp:ListItem>
                <asp:ListItem Value="MI">MICHIGAN</asp:ListItem>
                <asp:ListItem Value="MN">MINNESOTA</asp:ListItem>
                <asp:ListItem Value="MS">MISSISSIPPI</asp:ListItem>
                <asp:ListItem Value="MO">MISSOURI</asp:ListItem>
                <asp:ListItem Value="MT">MONTANA</asp:ListItem>
                <asp:ListItem Value="NE">NEBRASKA</asp:ListItem>
                <asp:ListItem Value="NV">NEVADA</asp:ListItem>
                <asp:ListItem Value="NH">NEW HAMPSHIRE</asp:ListItem>
                <asp:ListItem Value="NJ">NEW JERSEY</asp:ListItem>
                <asp:ListItem Value="NM">NEW MEXICO</asp:ListItem>
                <asp:ListItem Value="NY">NEW YORK</asp:ListItem>
                <asp:ListItem Value="NC">NORTH CAROLINA</asp:ListItem>
                <asp:ListItem Value="ND">NORTH DAKOTA</asp:ListItem>
                <asp:ListItem Value="OH">OHIO</asp:ListItem>
                <asp:ListItem Value="OK">OKLAHOMA</asp:ListItem>
                <asp:ListItem Value="OR">OREGON</asp:ListItem>
                <asp:ListItem Value="PW">PALAU</asp:ListItem>
                <asp:ListItem Value="PA">PENNSYLVANIA</asp:ListItem>
                <asp:ListItem Value="PR">PUERTO RICO</asp:ListItem>
                <asp:ListItem Value="RI">RHODE ISLAND</asp:ListItem>
                <asp:ListItem Value="SC">SOUTH CAROLINA</asp:ListItem>
                <asp:ListItem Value="SD">SOUTH DAKOTA</asp:ListItem>
                <asp:ListItem Value="TN">TENNESSEE</asp:ListItem>
                <asp:ListItem Value="TX">TEXAS</asp:ListItem>
                <asp:ListItem Value="UT">UTAH</asp:ListItem>
                <asp:ListItem Value="VT">VERMONT</asp:ListItem>
                <asp:ListItem Value="VI">VIRGIN ISLANDS</asp:ListItem>
                <asp:ListItem Value="VA">VIRGINIA</asp:ListItem>
                <asp:ListItem Value="WA">WASHINGTON</asp:ListItem>
                <asp:ListItem Value="WV">WEST VIRGINIA</asp:ListItem>
                <asp:ListItem Value="WI">WISCONSIN</asp:ListItem>
                <asp:ListItem Value="WY">WYOMING</asp:ListItem>
            </asp:DropDownList>
            <br />
        </td>
        <td class="label" style="width: 100px; height: 19px;" valign="top">
            Postal Code<br />
            <asp:TextBox ID="txtZip" runat="server" Columns="12" CssClass="checkoutTextbox" MaxLength="20"
                Width="65px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="valZip" runat="server" ControlToValidate="txtZip"
                CssClass="asterisk" Display="Dynamic" ErrorMessage="Please enter postal code."></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="valZip1" runat="server" ControlToValidate="txtZip" CssClass="asterisk" Display="Dynamic"
                    ErrorMessage="Postal code invalid." ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="label" style="height: 19px" valign="top" width="50%">
            Country<br />
            <asp:DropDownList ID="listCountry" runat="server" CssClass="checkoutDropdown">
                <asp:ListItem Value="USA">USA</asp:ListItem>
                <asp:ListItem Value="Canada">Canada</asp:ListItem>
                <asp:ListItem Value="Japan">Japan</asp:ListItem>
            </asp:DropDownList>
            <br />
            &nbsp;
        </td>
        <td class="label" style="height: 19px" valign="top" width="20%">
        </td>
        <td class="label" style="width: 100px; height: 19px;" valign="top">
        </td>
    </tr>
    <tr>
        <td class="label" colspan="3" valign="top">
            Phone Number<br />
            <asp:TextBox ID="txtPhone" runat="server" Columns="20" CssClass="checkoutTextbox"
                MaxLength="20" Width="155px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="valPhone" runat="server" ControlToValidate="txtPhone"
                CssClass="asterisk" ErrorMessage="Please enter telephone number."></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="valPhone1" runat="server" ControlToValidate="txtPhone" CssClass="asterisk"
                    Display="Dynamic" ErrorMessage="Phone number invalid." ValidationExpression="((\(?\d{3}\)? ?)|(\d{3}-?))?\d{3}-?\d{4}"></asp:RegularExpressionValidator>&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td class="label" colspan="3" style="height: 62px" valign="top">
            Email<br />
            <asp:TextBox ID="txtEmail" runat="server" Columns="55" CssClass="checkoutTextbox"
                MaxLength="80" Width="330px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                CssClass="asterisk" Display="Dynamic" ErrorMessage="Please enter email."></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="valEmail1" runat="server" ControlToValidate="txtEmail" CssClass="asterisk"
                    Display="Dynamic" ErrorMessage="Email invalid." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>&nbsp;&nbsp;
        </td>
    </tr>
</table>
