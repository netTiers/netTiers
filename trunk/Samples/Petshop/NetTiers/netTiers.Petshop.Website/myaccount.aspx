<%@ Page Language="C#" MasterPageFile="~/MasterPages/global.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" meta:resourcekey="ValidationSummary1Resource1" />
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" meta:resourcekey="CreateUserWizard1Resource1">
                <WizardSteps>
                    <asp:CreateUserWizardStep runat="server" meta:resourcekey="CreateUserWizardStepResource1">
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep runat="server" meta:resourcekey="CompleteWizardStepResource1">
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </AnonymousTemplate>
        <LoggedInTemplate>
            Edit My Profile :<br />
                    <asp:ObjectDataSource 
                        ID="ObjectDataSource1" 
                        runat="server" 
                        SelectMethod="GetUser"
                        TypeName="PetShopMemberShipProvider" 
                        UpdateMethod="UpdateUser"></asp:ObjectDataSource>
                        
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Edit" meta:resourcekey="FormView1Resource1">
                        <EditItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        FirstName:</td>
                                    <td>
                                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' meta:resourcekey="FirstNameTextBoxResource1" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        LastName:</td>
                                    <td>
                                        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' meta:resourcekey="LastNameTextBoxResource1" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Email:</td>
                                    <td>
                                        <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' meta:resourcekey="EmailTextBoxResource1" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        TelephoneNumber:</td>
                                    <td>
                                        <asp:TextBox ID="TelephoneNumberTextBox" runat="server" Text='<%# Bind("TelephoneNumber") %>' meta:resourcekey="TelephoneNumberTextBoxResource1" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        StreetAddress:</td>
                                    <td>
                                        <asp:TextBox ID="StreetAddressTextBox" runat="server" Text='<%# Bind("StreetAddress") %>' meta:resourcekey="StreetAddressTextBoxResource1" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        StateOrProvince:</td>
                                    <td>
                                        <asp:TextBox ID="StateOrProvinceTextBox" runat="server" Text='<%# Bind("StateOrProvince") %>' meta:resourcekey="StateOrProvinceTextBoxResource1" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        City:</td>
                                    <td>
                                        <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' meta:resourcekey="CityTextBoxResource1" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        PostalCode:</td>
                                    <td>
                                        <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' meta:resourcekey="PostalCodeTextBoxResource1" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Country:</td>
                                    <td>
                                        <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' meta:resourcekey="CountryTextBoxResource1" /></td>
                                </tr>
                            </table>
                            <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update"
                                Text="Update" meta:resourcekey="UpdateButtonResource1"></asp:LinkButton>
                            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancel" meta:resourcekey="UpdateCancelButtonResource1"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:FormView>
            <br />
                    <asp:ChangePassword ID="ChangePassword1" runat="server" meta:resourcekey="ChangePassword1Resource1">
                    </asp:ChangePassword>
            <br />
            &nbsp;
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
