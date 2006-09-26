<%@ Page Language="C#" MasterPageFile="~/MasterPages/global.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script runat="server">
    //You may want to put this code in the codebehind.
    protected void PaginateItems(object sender, ObjectDataSourceStatusEventArgs e)
    {
        PagerProduct.ItemsCount = (int)e.OutputParameters["itemsCount"];

        // Verify the number of item found and switch to the correct view
        if (PagerProduct.ItemsCount == 0)
        {
            uxProductItemsMultiView.SetActiveView(uxNoItemView);
        }
        else
        {
            uxProductItemsMultiView.SetActiveView(uxItemsListView);
        }
    }
</script>

<%--
    ItemDataSource
    Custom Item DataSource using GetById 
    Switching to Design Mode, you'll get full UI Property Builder Experience
--%>

<data:ItemDataSource runat="server" id="uxItemsObjectDataSource" 
    enablepaging="True" 
    enablesorting="True" 
    selectmethod="GetByProductId" cacheduration="30" enablecaching="False" enabletransaction="True" ><Parameters>
<asp:QueryStringParameter Type="String" Name="productId" QueryStringField="ProductId"></asp:QueryStringParameter>
<asp:ControlParameter PropertyName="CurrentPageIndex" Type="Int32" DefaultValue="0" Name="currentPage" ControlID="PagerProduct"></asp:ControlParameter>
<asp:ControlParameter PropertyName="ItemsPerPage" Type="Int32" DefaultValue="0" Name="itemsPerPage" ControlID="PagerProduct"></asp:ControlParameter>
<asp:Parameter Type="Int32" Direction="Output" Name="itemsCount"></asp:Parameter>
</Parameters>
</data:ItemDataSource>

<%-- 
    ProductDataSource
    Custom Product DataSource using GetById
    Switching to Design Mode, you'll get full UI Property Builder Experience
 --%>
<data:ProductDataSource 
    runat="server" 
    id="uxProductObjectDataSource" 
    enablepaging="False" 
    enablesorting="False" 
    selectmethod="GetById" cacheduration="30" enablecaching="False" enabletransaction="True" ><Parameters>
<asp:QueryStringParameter Type="String" Name="id" QueryStringField="ProductId"></asp:QueryStringParameter>
</Parameters>
</data:ProductDataSource>

    <asp:FormView ID="uxProductFormView" runat="server" DataSourceID="uxProductObjectDataSource" meta:resourcekey="uxProductFormViewResource1">
    <HeaderTemplate> <h3>
        <%# Eval("Name") %>
        items</h3></HeaderTemplate>
    </asp:FormView>
    
    <asp:MultiView runat="server" ID="uxProductItemsMultiView" ActiveViewIndex="0">
        <asp:View runat="server" ID="uxItemsListView">
            <asp:DataList ID="datalist1" runat="server" DataSourceID="uxItemsObjectDataSource" Width="100%" meta:resourcekey="datalist1Resource1">
           
                <ItemTemplate>
                        
                                <b><a href='item.aspx?ItemId=<%# Eval("Id") %>'>
                                    <%# Eval("Name") %>
                                </a></b><br />
                    <%# Eval("Description") %>
                    <br />
                                <div style="width: 100%; text-align:right;">
                                &nbsp;<span class="price"><%# Eval("Price") %><%# Eval("currency") %></span>
                                
                               <Cart:AddToCartButton 
					                id="Addtocartimagebutton1"
					                runat="server" 
					                Description='<%# Eval("Description") %>'
					                Code='<%# Eval("Name") %>'
					                Text="Add to cart"
					                TaxRate="0" 
					                Reduce="0" 
					                PublicPrice='<%# Convert.ToDecimal(Eval("Price")) %>'
					                ImageUrl='images/&lt;%#Eval(&quot;Photo&quot;) %&gt;' 
					                ProductId='<%# Eval("Id") %>'
					                ProductLink='<%# Eval("Id","item.aspx?itemid={0}") %>' availability="" badquantityerrortext="bad quantity" meta:resourcekey="Addtocartimagebutton1Resource1" quantity="1"
					                 ></Cart:AddToCartButton>					 
                                 
                           </div>
                     </ItemTemplate>
                <ItemStyle BackColor="#FFFFEE" Width="100%" />
                <AlternatingItemStyle BackColor="White" />
            
            </asp:DataList>
            
        </asp:View>
        <asp:View runat="server" ID="uxNoItemView" >
            There's currently no item for this product.
        </asp:View>
    </asp:MultiView>
    
    
    <PG:Pager runat="server" ItemsPerPage="10" id="PagerProduct" NumericPageCount="10" itemscount="0" pageidparametername="pageId" ></PG:Pager>
</asp:Content>

