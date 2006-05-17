<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feeds.aspx.cs" Inherits="Feeds" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:XmlDataSource ID="dsCommits" Runat="server" XPath="rss/channel/item[position() < 10]"
            DataFile="http://community.codesmithtools.com/forums/rss.aspx?ForumID=16&Mode=0" CacheDuration="60">
        </asp:XmlDataSource><br />
        &nbsp;
        <asp:Repeater ID="Repeater1" Runat="server" DataSourceID="dsCommits">
            <HeaderTemplate>
                <table cellpadding="1" cellspacing="1" border="0">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><b><a href="<%#XPath("link")%>"><%#XPath("title")%></a></b></td>
                </tr>
                <tr>
                    <td><%#XPath("description")%></td>
                </tr>
                <tr>
                    <td><b>Posted:</b> <%#XPath("pubDate")%></td>
                </tr>
            </ItemTemplate>
            <SeparatorTemplate>
                <tr>
                    <td height="1" bgcolor="#f4f4f4"></td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>        
        </asp:Repeater>

<!--
http://cia.navi.cx/stats/project/nettiers/.rss
http://community.codesmithtools.com/forums/rss.aspx?ForumID=16&Mode=0-->
    
    
        <asp:DataList ID="DataList1" Runat="server" DataSourceID="XmlDataSource1" 

         BorderColor="Tan" BackColor="LightGoldenrodYellow" BorderWidth="1px" 

         CellPadding="2" ForeColor="Black" Width="600px" Visible=false>

            <ItemTemplate>

                <asp:Label ID="Label1" Runat="server" Text='<%# XPath("pubDate") %>' ForeColor="gray" Font-Bold="True"

                    Font-Names="Verdana" Font-Size="XX-Small"></asp:Label><br />

                <asp:HyperLink ID="HyperLink1" Runat="server" Text='<%# XPath("title") %>' NavigateUrl='<%# XPath("link") %>'

                    Target="_blank" Font-Names="Verdana" Font-Size="X-Small"></asp:HyperLink><br />

                <%# XPath("description") %>

            </ItemTemplate>

            <AlternatingItemTemplate>

                <asp:Label ID="Label3" Runat="server" Text='<%# XPath("pubDate") %>' 

                 ForeColor="gray" Font-Bold="True"

                 Font-Names="Verdana" Font-Size="XX-Small"></asp:Label><br />

                <asp:HyperLink ID="HyperLink2" Runat="server" 

                 Text='<%# XPath("title") %>' NavigateUrl='<%# XPath("link") %>'

                 Target="_blank" Font-Names="Verdana" Font-Size="X-Small"></asp:HyperLink><br />

                <%# XPath("description") %>

            </AlternatingItemTemplate>

            <AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>

            <ItemStyle Font-Names="Verdana" Font-Size="X-Small"></ItemStyle>

        </asp:DataList>    

        <asp:XmlDataSource ID="XmlDataSource1" Runat="server" 
         DataFile="http://cia.navi.cx/stats/project/nettiers/.rss" 
         XPath="rss/channel/item">

        </asp:XmlDataSource>

<!-- http://cia.navi.cx/stats/project/nettiers/.rss -->

</asp:Content>
    