<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="PetShop.UI.UserProfile" Title="User Profile" %>
<%@ Register Src="Controls/AddressForm.ascx" TagName="AddressForm" TagPrefix="PC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="server">
    <div align="center" class="profilePosition">
        <table border="0" cellpadding="0" cellspacing="0" class="formContent" width="380">
            <tr>
                <td>
                    <div class="checkoutHeaders" align="left">
                        Billing Information</div>
                    <div class="info">
                        User Name:
                        <asp:LoginName ID="LoginName" runat="server" />
                        <br />
                    </div>
                    <asp:Panel ID="panFocus" runat="server" DefaultButton="btnSubmit">
                        <PC:AddressForm id="AddressForm" runat="server" />
                        <asp:Label ID="lblMessage" runat="server" CssClass="label"></asp:Label>
                        <div align="right" class="checkoutButtonBg">
                            <asp:LinkButton ID="btnSubmit" runat="server" CssClass="submit" OnClick="btnSubmit_Click"
                                Text="Update">
                            </asp:LinkButton></div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
