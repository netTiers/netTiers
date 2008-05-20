<%@ Page Language="C#" MasterPageFile="~/MasterPages/global.master" %>

<script runat="server">
    protected void PaginateProducts(object sender, ObjectDataSourceStatusEventArgs e)
    {
        PagerProduct.ItemsCount = (int)e.OutputParameters["itemsCount"];

        // Verify the number of item found and switch to the correct view
        if (PagerProduct.ItemsCount == 0)
        {
            uxProductsMultiView.SetActiveView(uxNoProductView);
        }
        else
        {
            uxProductsMultiView.SetActiveView(uxProductsListView);
        }
    }

    protected void SetMyFavoriteButton_Click(object sender, EventArgs e)
    {
        Profile.FavoriteCategoryId = Request["CategoryId"];
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--
        Using Custom Category Datasource with GetById Method
    --%>
    <data:categorydatasource runat="server" ID="uxCategoryObjectDataSource" 
        enablepaging="False" 
        enablesorting="False" 
        enabletransaction="False" 
        selectmethod="GetById" cacheduration="30" enablecaching="False" ><Parameters>
<asp:QueryStringParameter Type="String" DefaultValue="7c6cc986-bee6-42ac-948a-bf8f579ac3dc" Name="categoryId" QueryStringField="CategoryId"></asp:QueryStringParameter>
</Parameters>
</data:categorydatasource>
    
    <%--    
        Using Custom Product DataSource with GetByCategoryId Read Param
    --%>
    <data:productdatasource id="uxProductsObjectDataSource" runat="server" enablepaging="True"
        enablesorting="True" selectmethod="GetByCategoryId" cacheduration="30" enablecaching="False" enabletransaction="True" >
        <Parameters>
                <asp:QueryStringParameter Type="String" DefaultValue="7c6cc986-bee6-42ac-948a-bf8f579ac3dc" Name="categoryId" QueryStringField="CategoryId"></asp:QueryStringParameter>
                <asp:ControlParameter PropertyName="CurrentPageIndex" Type="Int32" DefaultValue="0" Name="currentPage" ControlID="PagerProduct"></asp:ControlParameter>
                <asp:ControlParameter PropertyName="ItemsPerPage" Type="Int32" DefaultValue="10" Name="itemsPerPage" ControlID="PagerProduct"></asp:ControlParameter>
                <asp:Parameter Type="Int32" Direction="Output" Name="itemsCount"></asp:Parameter>
           </Parameters>
    </data:productdatasource>
    <asp:FormView ID="uxCategoryFormView" runat="server" DataSourceID="uxCategoryObjectDataSource" meta:resourcekey="uxCategoryFormViewResource1">
        <ItemTemplate>
            <h3>
                <%# Eval("Name") %>
            </h3>
            <div style="float: right;">
                <img src='images/<%# Eval("AdvicePhoto") %>' alt='<%# Eval("Name") %>' align="right"
                    style="float: right;" /></div>
        </ItemTemplate>
    </asp:FormView>
    <asp:LoginView runat="server" ID="SetMyFavoriteLoginView">
        <LoggedInTemplate>
            <asp:Button runat="server" Text="Set My Favorite" ID="SetMyFavoriteButton" OnClick="SetMyFavoriteButton_Click" meta:resourcekey="SetMyFavoriteButtonResource1" />
        </LoggedInTemplate>
    </asp:LoginView>
    <asp:MultiView ID="uxProductsMultiView" runat="server" ActiveViewIndex="0">
        <asp:View ID="uxProductsListView" runat="server">
            <asp:Repeater ID="uxProductsRepeater" runat="server" DataSourceID="uxProductsObjectDataSource"
                EnableViewState="False">
                <HeaderTemplate>
                    <!--<div class="category">-->
                </HeaderTemplate>
                <ItemTemplate>
                    <div style="background-color: #EFF3FB; height: 50px; padding: 4px;">
                        <b><a href='product.aspx?productId=<%# Eval("Id") %>'>
                            <%# Eval("Name") %>
                        </a></b>
                        <br />
                        <%# Eval("Description") %>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div style="background-color: #FFFFFF; height: 50px; padding: 2px;">
                        <b><a href='product.aspx?productId=<%# Eval("Id") %>'>
                            <%# Eval("Name") %>
                        </a></b>
                        <br />
                        <%# Eval("Description") %>
                    </div>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    <!--</div>-->
                </FooterTemplate>
            </asp:Repeater>
            <PG:Pager runat="server" ItemsPerPage="2" id="PagerProduct" NumericPageCount="10" itemscount="0" pageidparametername="pageId"></PG:Pager>
        </asp:View>
        <asp:View ID="uxNoProductView" runat="server">
            There's currently no product in this category.
        </asp:View>
    </asp:MultiView>
</asp:Content>
