<%@ Page Language="C#" Title="Untitled Page" %>

<script runat="server">

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        e.Authenticated = true;
    }
</script>

<html>
<head runat="server">
</head>
<body>
<form runat="server">
<asp:loginview id="LoginView1" runat="server">
    <AnonymousTemplate>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" >
        </asp:Login>
    </AnonymousTemplate>
</asp:loginview>
</form>
</body>
</html>
