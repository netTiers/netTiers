<%@ Page Language="C#" MasterPageFile="~/global.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server">
                <WizardSteps>
                    <asp:CreateUserWizardStep runat="server">
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep runat="server">
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </AnonymousTemplate>
        <LoggedInTemplate>
            Edit My Infos :<br />
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUser"
                        TypeName="PetShopMemberShipProvider" UpdateMethod="UpdateUser"></asp:ObjectDataSource>
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Edit">
                        <EditItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        FirstName:</td>
                                    <td>
                                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' /></td>
                                </tr>
                                <tr>
                                    <td>
                                        LastName:</td>
                                    <td>
                                        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Email:</td>
                                    <td>
                                        <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' /></td>
                                </tr>
                                <tr>
                                    <td>
                                        TelephoneNumber:</td>
                                    <td>
                                        <asp:TextBox ID="TelephoneNumberTextBox" runat="server" Text='<%# Bind("TelephoneNumber") %>' /></td>
                                </tr>
                                <tr>
                                    <td>
                                        StreetAddress:</td>
                                    <td>
                                        <asp:TextBox ID="StreetAddressTextBox" runat="server" Text='<%# Bind("StreetAddress") %>' /></td>
                                </tr>
                                <tr>
                                    <td>
                                        StateOrProvince:</td>
                                    <td>
                                        <asp:TextBox ID="StateOrProvinceTextBox" runat="server" Text='<%# Bind("StateOrProvince") %>' /></td>
                                </tr>
                                <tr>
                                    <td>
                                        City:</td>
                                    <td>
                                        <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' /></td>
                                </tr>
                                <tr>
                                    <td>
                                        PostalCode:</td>
                                    <td>
                                        <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Country:</td>
                                    <td>
                                        <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' /></td>
                                </tr>
                            </table>
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Update">
                            </asp:LinkButton>
                            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancel">
                            </asp:LinkButton>
                        </EditItemTemplate>
                    </asp:FormView>
            <br />
                    <asp:ChangePassword ID="ChangePassword1" runat="server">
                    </asp:ChangePassword>
            <br />
            &nbsp;
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
