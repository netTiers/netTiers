
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"  CodeFile="Account.aspx.cs" Inherits="Account" Title="Account List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

		<atlas:UpdateProgress runat="server" ID="up1">
			<ProgressTemplate>
				<div id="loadinfo" style="visibility:visible;position:absolute;right:10px;top:10px;">
					<asp:Image runat="server" ID="imgLoading" ImageUrl="~/images/loading.gif" />
				</div>
			</ProgressTemplate>
		</atlas:UpdateProgress>

    <atlas:UpdatePanel runat="server" ID="UpdatePanel1" Mode="Conditional">        
        <ContentTemplate>   
		
		<netTiers:EntityGridView ID="GridView1" runat="server"			
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridView_SelectedIndexChanged"
			DataSourceID="AccountDataSource"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
            DefaultSortColumnName="" 
            DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Account.xls"  
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly />
				<asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"  />
				<asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"  />
				<asp:BoundField DataField="StreetAddress" HeaderText="StreetAddress" SortExpression="StreetAddress"  />
				<asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode"  />
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="City"  />
				<asp:BoundField DataField="StateOrProvince" HeaderText="StateOrProvince" SortExpression="StateOrProvince"  />
				<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country"  />
				<asp:BoundField DataField="TelephoneNumber" HeaderText="TelephoneNumber" SortExpression="TelephoneNumber"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"  />
				<asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login"  />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password"  />
				<asp:BoundField DataField="IWantMyList" HeaderText="IWantMyList" SortExpression="IWantMyList"  />
				<asp:BoundField DataField="IWantPetTips" HeaderText="IWantPetTips" SortExpression="IWantPetTips"  />
				<asp:BoundField DataField="FavoriteLanguage" HeaderText="FavoriteLanguage" SortExpression="FavoriteLanguage"  />
				<asp:TemplateField HeaderText="CreditCard">
				<ItemTemplate>
						<asp:Repeater ID="Id" runat="server" DataSourceID="CreditCardFilter">
							<ItemTemplate>
								<%# Eval("Number") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="CreditCardFilter" runat="server"
							DataSourceID="CreditCardDataSource1"
							Filter='<%# String.Format("Id = {0}", Eval("CreditCardId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


				<asp:TemplateField HeaderText="Category">
				<ItemTemplate>
						<asp:Repeater ID="Id" runat="server" DataSourceID="CategoryFilter">
							<ItemTemplate>
								<%# Eval("Name") %>
							</ItemTemplate>
						</asp:Repeater>

						<data:EntityDataSourceFilter ID="CategoryFilter" runat="server"
							DataSourceID="CategoryDataSource1"
							Filter='<%# String.Format("Id = {0}", Eval("FavoriteCategoryId")) %>'
						/>
					</ItemTemplate>
				</asp:TemplateField>


			</Columns>
			<EmptyDataTemplate>
				<b>No Account Found!</b>
				<asp:HyperLink runat="server" ID="hypAccount" NavigateUrl="~/admin/AccountEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</netTiers:EntityGridView>
			
		<data:EntityDataSource ID="CreditCardDataSource1" runat="server"
			ProviderName="CreditCardProvider"
			EntityTypeName="Entities.CreditCard, Entities"
			EntityKeyTypeName="System.String"
			SelectMethod="GetAll"
		/>

		<data:EntityDataSource ID="CategoryDataSource1" runat="server"
			ProviderName="CategoryProvider"
			EntityTypeName="Entities.Category, Entities"
			EntityKeyTypeName="System.String"
			SelectMethod="GetAll"
		/>

		<data:EntityDataSource ID="AccountDataSource" runat="server"
			ProviderName="AccountProvider"
			EntityTypeName="Entities.Account, Entities"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:EntityDataSource>
	    
		</ContentTemplate>
    </atlas:UpdatePanel>		
</asp:Content>



