<%@ Page Language="C#" MasterPageFile="~/global.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="Login1" runat="server" CreateUserText="Create Account" CreateUserUrl="myaccount.aspx">
            </asp:Login>
        </AnonymousTemplate>
        <LoggedInTemplate>You are now loged as <b><%#Context.User.Identity.Name%></b>. Click <a href="default.aspx">here</a> to navigate the petshop.</LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

