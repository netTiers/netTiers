<%@ Page Language="C#" MasterPageFile="~/MasterPages/global.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="Login1" runat="server" CreateUserText="Create New Account" CreateUserUrl="myaccount.aspx" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Width="384px" DestinationPageUrl="~/default.aspx">
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <TextBoxStyle Font-Size="0.8em" />
                <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            </asp:Login>
        </AnonymousTemplate>
        <LoggedInTemplate>Welcome <b><%=Membership.GetUser().UserName%></b>. <a href="default.aspx">Continue </a> to the petshop.</LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

