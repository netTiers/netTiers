<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rss.aspx.cs" Inherits="Rss" Title=".netTiers Rss feeds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="http://js.track.semway.com/v1.2/tag.js" type="text/javascript"></script>
    <script type="text/javascript">
    <!--
        swtag();
    -->
    </script>
    <noscript>
			<img width="1" height="1" src="http://ws2.track.semway.com/v1.3/noscript.ashx" >
		</noscript>

<ul>
<h3>.netTiers Rss feeds</h3>
    <li><a href="http://community.codesmithtools.com/forums/rss.aspx?ForumID=16&Mode=0"><img src="images/Livemark.png" border="0"/> .netTiers Forums</a></li>
    <li><a href="http://cia.navi.cx/stats/project/nettiers/.rss"><img src="images/Livemark.png" border="0"/>.netTiers commits</a></li>
</ul>
</asp:Content>

