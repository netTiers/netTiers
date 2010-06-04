<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="NullFkeyParentEdit.aspx.cs" Inherits="NullFkeyParentEdit" Title="NullFkeyParent Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Null Fkey Parent - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="NullFkeyParentId" runat="server" DataSourceID="NullFkeyParentDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/NullFkeyParentFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/NullFkeyParentFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>NullFkeyParent not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:NullFkeyParentDataSource ID="NullFkeyParentDataSource" runat="server"
			SelectMethod="GetByNullFkeyParentId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="NullFkeyParentId" QueryStringField="NullFkeyParentId" Type="String" />

			</Parameters>
		</data:NullFkeyParentDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewNullFkeyChild1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewNullFkeyChild1_SelectedIndexChanged"			 			 
			DataSourceID="NullFkeyChildDataSource1"
			DataKeyNames="NullFkeyChildId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_NullFkeyChild.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Null Fkey Parent Id" DataNavigateUrlFormatString="NullFkeyParentEdit.aspx?NullFkeyParentId={0}" DataNavigateUrlFields="NullFkeyParentId" DataContainer="NullFkeyParentIdSource" DataTextField="SomeText" />
				<asp:BoundField DataField="SomeText" HeaderText="Some Text" SortExpression="[SomeText]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Null Fkey Child Found! </b>
				<asp:HyperLink runat="server" ID="hypNullFkeyChild" NavigateUrl="~/admin/NullFkeyChildEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:NullFkeyChildDataSource ID="NullFkeyChildDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:NullFkeyChildProperty Name="NullFkeyParent"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:NullFkeyChildFilter  Column="NullFkeyParentId" QueryStringField="NullFkeyParentId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:NullFkeyChildDataSource>		
		
		<br />
		

</asp:Content>

