<%@ Page Language="C#" MasterPageFile="~/MasterPages/global.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%--
    <asp:ObjectDataSource 
        ID="uxItemsObjectDataSource" 
        runat="server" 
        TypeName="DataWrapper" 
        SelectMethod="GetItemByItemId"
        >
        <SelectParameters>
            <asp:QueryStringParameter Name="itemId" type="string" QueryStringField="ItemId" Direction="Input" />            
        </SelectParameters>
    </asp:ObjectDataSource>
    --%>
    
    <data:itemdatasource 
        runat="server" 
        id="uxItemsObjectDataSource" 
        selectmethod="GetById" 
        EnableTransaction="True"
        >
        <Parameters>
            <asp:QueryStringParameter Name="Id" type="string" QueryStringField="ItemId" Direction="Input" />
        </Parameters>
    </data:itemdatasource>
    
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="uxItemsObjectDataSource">
    <HeaderTemplate>
        <div class="product">
    </HeaderTemplate>
    <ItemTemplate>
        <h3><%# Eval("Name")%></h3>
       <img src='images/<%#Eval("Photo") %>' /><br />
        <%# Eval("Description")%>
       <br />
           
        <span class="price"><%# Eval("Price")%><%# Eval("currency")%> </span><br /><br />
       
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
			ImageUrl='<%#Eval("Photo","images/{0}") %>' 
			ProductId='<%#Eval("Id") %>'
			ProductLink='<%#Eval("Id","item.aspx?itemid={0}")%>'
			 ></Cart:AddToCartButton>
					 
               
           
     </ItemTemplate>
     <FooterTemplate>     
        </div>
     </FooterTemplate>
    </asp:Repeater>
    
    <PG:Pager runat="server" ItemsPerPage="2" id="PagerProduct" NumericPageCount="2">
        <FirstPageTemplate><a href='<%#Container.NavigateUrl%>'><<</a></FirstPageTemplate>
        <PreviousPageTemplate><a href='<%#Container.NavigateUrl%>'><</a></PreviousPageTemplate>
        <PagesTemplate><a href='<%#Container.NavigateUrl%>'><%#Container.PageLabel%></a></PagesTemplate>
        <CurrentPageTemplate><%#Container.PageLabel%></CurrentPageTemplate>
        <NextPageTemplate><a href='<%#Container.NavigateUrl%>'>></a></NextPageTemplate>
        <LastPageTemplate><a href='<%#Container.NavigateUrl%>'>>></a></LastPageTemplate>
    </PG:Pager>
</asp:Content>

