<%@ Page Language="C#" MasterPageFile="~/MasterPages/global.master" %>
<script runat="server">
    
    protected void uxSearchObjectDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        // Verify the number of item found

        if (((System.Collections.Generic.List<netTiers.Petshop.Entities.ExtendedItem>)e.ReturnValue).Count == 0)
        {
            MultiView1.SetActiveView(NoResultView);
        }
        else
        {
            MultiView1.SetActiveView(ResultView);
        }
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- Since we're using a custom search agent, we use an object datasource to make the call. --%>
    <asp:ObjectDataSource ID="uxSearchObjectDataSource" runat="server"
        TypeName="DataWrapper" SelectMethod="Search" OnSelected="uxSearchObjectDataSource_Selected" >
        <SelectParameters>
            <asp:QueryStringParameter Name="queryString" Direction="Input" QueryStringField="q" Type="string" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
       
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="ResultView" runat="server">
            <asp:Repeater ID="uxSearchResults" runat="server" DataSourceID="uxSearchObjectDataSource">
                 <HeaderTemplate>
                 <table width="100%">
                    <tr>
                        <td><h3>Search results for : <%=HttpContext.Current.Request["q"] %></h3></td>
                        <td></td>
                    </tr>
                 </table>
                 </HeaderTemplate>
                 <ItemTemplate>
                 <p>
                    <img alt="" src='images/<%#Eval("ItemPhoto") %>' align="left" hspace="10" width="80"/>
                    <b><a href='Item.aspx?ItemId=<%#Eval("ItemId") %>'><%# Eval("ItemName") %></a></b><br />
                    
                    <%# Eval("ItemDescription") %>
                 </p>
                </ItemTemplate>
                <SeparatorTemplate><hr /></SeparatorTemplate>
            </asp:Repeater>
        </asp:View>
        <asp:View ID="NoResultView" runat="server">
            Your search - <b><%=HttpContext.Current.Request["q"] %></b> - did not match any documents.
            <br />
            <br />
            Suggestions:
            <blockquote>
                - Make sure all words are spelled correctly.<br />
                - Try different keywords.<br />
                - Try more general keywords.
            </blockquote>
        </asp:View>
    </asp:MultiView>
</asp:Content>

