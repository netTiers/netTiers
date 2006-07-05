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
    
    <data:ItemDataSource ID="uxItemsObjectDataSource" runat="server" CacheDuration="30"
        EnableCaching="False" EnablePaging="False" EnableSorting="False" EnableTransaction="True"
        SelectMethod="GetById"><Parameters>
            <asp:QueryStringParameter Type="String" Name="Id" QueryStringField="ItemId"></asp:QueryStringParameter>
            </Parameters>
    </data:ItemDataSource>
    
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="uxItemsObjectDataSource">
    <HeaderTemplate>
        <div class="product">
    </HeaderTemplate>
    <ItemTemplate>
        <h3>
            <%# Eval("Name") %>
        </h3>
       <img  alt="Photo" src='images/<%# Eval("Photo") %>' /><br />
        <%# Eval("Description") %>
       <br />
           
        <span class="price">
            <%# Eval("Price") %>
            <%# Eval("currency") %>
        </span><br /><br />
       
        <Cart:AddToCartButton 
			id="Addtocartimagebutton1"
			runat="server" 
			Description='<%# Eval("Description") %>'
			Code='<%# Eval("Name") %>'
			Text="Add to cart"
			TaxRate="0" 
			Reduce="0" 
			PublicPrice='<%# Convert.ToDecimal(Eval("Price")) %>'
			ImageUrl='<%# Eval("Photo","images/{0}") %>' 
			ProductId='<%# Eval("Id") %>'
			ProductLink='<%# Eval("Id","item.aspx?itemid={0}") %>' availability="" badquantityerrortext="bad quantity" meta:resourcekey="Addtocartimagebutton1Resource1" quantity="1"
			 ></Cart:AddToCartButton>
					 
               
           
     </ItemTemplate>
     <FooterTemplate>     
        </div>
     </FooterTemplate>
    </asp:Repeater>
    
    <PG:Pager runat="server" ItemsPerPage="2" id="PagerProduct" NumericPageCount="2" itemscount="0" pageidparametername="pageId" ></PG:Pager>
</asp:Content>

