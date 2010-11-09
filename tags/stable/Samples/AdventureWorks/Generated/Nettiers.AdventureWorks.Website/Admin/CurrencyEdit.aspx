<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CurrencyEdit.aspx.cs" Inherits="CurrencyEdit" Title="Currency Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Currency - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="CurrencyCode" runat="server" DataSourceID="CurrencyDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CurrencyFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CurrencyFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Currency not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CurrencyDataSource ID="CurrencyDataSource" runat="server"
			SelectMethod="GetByCurrencyCode"
		>
			<Parameters>
				<asp:QueryStringParameter Name="CurrencyCode" QueryStringField="CurrencyCode" Type="String" />

			</Parameters>
		</data:CurrencyDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewCurrencyRate1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewCurrencyRate1_SelectedIndexChanged"			 			 
			DataSourceID="CurrencyRateDataSource1"
			DataKeyNames="CurrencyRateId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CurrencyRate.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="CurrencyRateDate" HeaderText="Currency Rate Date" SortExpression="[CurrencyRateDate]" />				
				<data:HyperLinkField HeaderText="From Currency Code" DataNavigateUrlFormatString="CurrencyEdit.aspx?CurrencyCode={0}" DataNavigateUrlFields="CurrencyCode" DataContainer="FromCurrencyCodeSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="To Currency Code" DataNavigateUrlFormatString="CurrencyEdit.aspx?CurrencyCode={0}" DataNavigateUrlFields="CurrencyCode" DataContainer="ToCurrencyCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="AverageRate" HeaderText="Average Rate" SortExpression="[AverageRate]" />				
				<asp:BoundField DataField="EndOfDayRate" HeaderText="End Of Day Rate" SortExpression="[EndOfDayRate]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Currency Rate Found! </b>
				<asp:HyperLink runat="server" ID="hypCurrencyRate" NavigateUrl="~/admin/CurrencyRateEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CurrencyRateDataSource ID="CurrencyRateDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CurrencyRateProperty Name="Currency"/> 
					<%--<data:CurrencyRateProperty Name="SalesOrderHeaderCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CurrencyRateFilter  Column="FromCurrencyCode" QueryStringField="CurrencyCode" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CurrencyRateDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewCurrencyRate2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewCurrencyRate2_SelectedIndexChanged"			 			 
			DataSourceID="CurrencyRateDataSource2"
			DataKeyNames="CurrencyRateId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CurrencyRate.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="CurrencyRateDate" HeaderText="Currency Rate Date" SortExpression="[CurrencyRateDate]" />				
				<data:HyperLinkField HeaderText="From Currency Code" DataNavigateUrlFormatString="CurrencyEdit.aspx?CurrencyCode={0}" DataNavigateUrlFields="CurrencyCode" DataContainer="FromCurrencyCodeSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="To Currency Code" DataNavigateUrlFormatString="CurrencyEdit.aspx?CurrencyCode={0}" DataNavigateUrlFields="CurrencyCode" DataContainer="ToCurrencyCodeSource" DataTextField="Name" />
				<asp:BoundField DataField="AverageRate" HeaderText="Average Rate" SortExpression="[AverageRate]" />				
				<asp:BoundField DataField="EndOfDayRate" HeaderText="End Of Day Rate" SortExpression="[EndOfDayRate]" />				
				<asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="[ModifiedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Currency Rate Found! </b>
				<asp:HyperLink runat="server" ID="hypCurrencyRate" NavigateUrl="~/admin/CurrencyRateEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CurrencyRateDataSource ID="CurrencyRateDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CurrencyRateProperty Name="Currency"/> 
					<%--<data:CurrencyRateProperty Name="SalesOrderHeaderCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CurrencyRateFilter  Column="ToCurrencyCode" QueryStringField="CurrencyCode" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CurrencyRateDataSource>		
		
		<br />
		

</asp:Content>

