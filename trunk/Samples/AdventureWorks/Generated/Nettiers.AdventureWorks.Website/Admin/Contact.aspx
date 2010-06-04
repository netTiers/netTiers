
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Contact.aspx.cs" Inherits="Contact" Title="Contact List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Contact List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ContactDataSource"
				DataKeyNames="ContactId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Contact.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:BoundRadioButtonField DataField="NameStyle" HeaderText="Name Style" SortExpression="[NameStyle]"  />
				<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="[Title]"  />
				<asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="[FirstName]"  />
				<asp:BoundField DataField="MiddleName" HeaderText="Middle Name" SortExpression="[MiddleName]"  />
				<asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="[LastName]"  />
				<asp:BoundField DataField="Suffix" HeaderText="Suffix" SortExpression="[Suffix]"  />
				<asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="[EmailAddress]"  />
				<asp:BoundField DataField="EmailPromotion" HeaderText="Email Promotion" SortExpression="[EmailPromotion]"  />
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="[Phone]"  />
				<asp:BoundField DataField="PasswordHash" HeaderText="Password Hash" SortExpression="[PasswordHash]"  />
				<asp:BoundField DataField="PasswordSalt" HeaderText="Password Salt" SortExpression="[PasswordSalt]"  />

				<asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Date" SortExpression="[ModifiedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Contact Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnContact" OnClientClick="javascript:location.href='ContactEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ContactDataSource ID="ContactDataSource" runat="server"
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
		</data:ContactDataSource>
	    		
</asp:Content>



