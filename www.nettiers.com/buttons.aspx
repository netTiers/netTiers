<%@ Page MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h3>Google Toolbar 4 Buttons</h3>

<script src="http://js.track.semway.com/v1.2/tag.js" type="text/javascript"></script>
    <script type="text/javascript">
    <!--
        swtag();
    -->
    </script>
    <noscript>
			<img width="1" height="1" src="http://ws2.track.semway.com/v1.3/noscript.ashx" >
		</noscript>

On this page you can find buttons for the latest google toolbar (download the toolbar <a href="http://www.google.com/tools/toolbar/T4/index.html">here</a> )
<p />
<table width=420>
    <tr>        
        <td>
            <table width=200>
            <tr>
                <td><img src="Buttons/nettiers-cs.gif" /> <b>.netTiers Forums feed</b></td>
            </tr>
            <tr>
                <td>
                List of posts from the .netTiers forums. New posts are accessible via the button dropdown list. Button is highlighted on new commit.
                <form action="http://toolbar.google.com/buttons/add" style="margin-bottom:0px" method="get"> <input type="hidden" name="url" value="http://www.nettiers.com/buttons/netTiers-Forums.xml" />   <input type="submit" value="Add to Toolbar"/>   </form>
                </td>
            </tr>   
            </table>    
        </td>
        <td width=20></td>
        <td>
            <table width=200>
                <tr><td><img src="Buttons/nettiers-rss.gif" /> <b>Subversion commits</b></td></tr>
                <tr>
                    <td>
                        List of commits published as a rss feed. Accessible via the button dropdown list. Button is highlighted on new commit.
                        <form action="http://toolbar.google.com/buttons/add" style="margin-bottom:0px" method="get"> <input type="hidden" name="url" value="http://www.nettiers.com/buttons/netTiers-Commits.xml"/> <input type="submit" value="Add to Toolbar"/>   </form>
                    </td>
                </tr>
            </table>
        </td>
    </tr>    
</table>

</asp:Content>