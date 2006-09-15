<%@ Page Language="C#" MasterPageFile="~/global.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script runat="server">
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
    <asp:ObjectDataSource 
        ID="uxItemsObjectDataSource" 
        runat="server" 
        TypeName="DataWrapper" 
        SelectMethod="GetItemsByProduct"
        OnSelected="PaginateItems" >
        <SelectParameters>
            <asp:QueryStringParameter Name="productId" type="string" QueryStringField="ProductId" Direction="Input" />
             <asp:ControlParameter ControlID="PagerProduct" Name="currentPage" PropertyName="CurrentPageIndex" type="Int32" DefaultValue="0"/>
            <asp:ControlParameter ControlID="PagerProduct" Name="itemsPerPage" PropertyName="ItemsPerPage" Type="Int32" DefaultValue="0" />
            <asp:Parameter Direction="Output" Name="itemsCount" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource 
        ID="uxProductObjectDataSource" 
        runat="server"
        typename="DataWrapper"
        SelectMethod="GetProductByProductId">
        <SelectParameters>
        <asp:QueryStringParameter Name="productId" QueryStringField="ProductId" Type="string" />
        </SelectParameters>    
    </asp:ObjectDataSource>
    <asp:FormView ID="uxProductFormView" runat="server" DataSourceID="uxProductObjectDataSource">
    <HeaderTemplate> <h3><%#Eval("Name") %> items</h3></HeaderTemplate>
    </asp:FormView>
    
    <asp:MultiView runat="server" ID="uxProductItemsMultiView" ActiveViewIndex="0">
        <asp:View runat="server" ID="uxItemsListView">
            <asp:DataList ID="datalist1" runat="server" DataSourceID="uxItemsObjectDataSource" Width="100%">
           
                <ItemTemplate>
                        
                                <b><a href='item.aspx?ItemId=<%#Eval("Id") %>'><%# Eval("Name")%></a></b><br />
                                <%# Eval("Description")%><br />
                                <div style="width: 100%; text-align:right;">
                                &nbsp;<span class="price"><%# Eval("Price")%><%# Eval("currency")%></span>
                                
                               <Cart:AddToCartButton 
					                id="Addtocartimagebutton1"
					                runat="Server" 
					                Description='<%#Eval("Description") %>'
					                Code='<%#Eval("Name") %>'
					                Text="Add to cart"
					                TaxRate="0" 
					                Reduce="0" 
					                UnitSale="1" 
					                PublicPrice='<%#Convert.ToDecimal(Eval("Price"))%>'
					                ImageUrl='images/<%#Eval("Photo") %>' 
					                ProductId='<%#Eval("Id") %>'
					                ProductLink='<%#Eval("Id","item.aspx?itemid={0}")%>'
					                 ></Cart:AddToCartButton>					 
                                 
                           </div>
                     </ItemTemplate>
                <ItemStyle BackColor="#ffffee" Width="100%" />
                <AlternatingItemStyle BackColor=white />
            
            </asp:DataList>
            
        </asp:View>
        <asp:View runat="server" ID="uxNoItemView" >
            There's currently no item for this product.
        </asp:View>
    </asp:MultiView>
    
    
    
    <PG:Pager runat="server" ItemsPerPage="10" id="PagerProduct" NumericPageCount="10">
        <FirstPageTemplate><a href='<%#Container.NavigateUrl%>'><<</a></FirstPageTemplate>
        <PreviousPageTemplate><a href='<%#Container.NavigateUrl%>'><</a></PreviousPageTemplate>
        <PagesTemplate><a href='<%#Container.NavigateUrl%>'><%#Container.PageLabel%></a></PagesTemplate>
        <CurrentPageTemplate><%#Container.PageLabel%></CurrentPageTemplate>
        <NextPageTemplate><a href='<%#Container.NavigateUrl%>'>></a></NextPageTemplate>
        <LastPageTemplate><a href='<%#Container.NavigateUrl%>'>>></a></LastPageTemplate>
    </PG:Pager>
</asp:Content>

