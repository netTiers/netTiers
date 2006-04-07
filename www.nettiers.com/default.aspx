<%@ Page MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


	<p class="overview">
	 	   	.NetTiers are CodeSmith templates for object-relational mapping that takes an existing SQLServer database and automatically generates
	     a personnalized Data Tiers application block to use in your .Net applications.  
	</p>

<p class="announcements">
<b>Annoucements:</b><br />
    <b>2006/22/03: </b> Follow the project roadmap and report bugs on our new tracker: <a href="http://tracker.nettiers.com">http://tracker.nettiers.com</a>
</p>
						
	
	<p>
		Core features include:
	</p>
	
	<div class="itemizedlist">
		<ul type="disc">
			<li>Generates ready to use <span class="emphasis"><em>Visual Studio</em></span> projects and solution.</li>
			<li>Fully integrate with <em>Entreprise Library</em> application blocks architecture. Shipped with it's own plugin, so you can configure your application directly from the entlib configuration console.</li>
			<li>
				Generate <em>business entities</em> with a 1:1 mapping ( an entity for each table or view, with a property for each	column).
				<div class="itemizedlist">
					<ul type="circle">
						<li>Serializable</li>
						<li>trigger events</li>
						<li>Implements an IEntity interface, which contains the columns	that are present in every table</li>
						<li>Specific support for enums.</li>
						<li>
							Each object has a concrete and a base class which it inherit
							from. The concrete class is generated just once, so you have can use
							it to add you custom code.
						</li>
					</ul>
				</div>
			</li>
			<li>
				Generate <em>Data Access Layer Components</em> (DALC) for tables and views , with following database operations :
				<div class="itemizedlist">
					<ul type="circle">
						<li>upport for basic CRUD: UPDATE, DELETE, INSERT, SELECT ALL, PAGED SELECT, FIND</li>
						<li>Support for queries using primary key</li>
						<li>Support for queries using foreign key</li>
						<li>Support for queries using keys that are part of an index</li>
						<li>Support for queries using keys that are part of a junction table</li>
						<li>Support for user defined Methods, generated from queries that are detected throught a very simple naming rule (_TableName_MyMethodName)</li>
						<li>Support for Deep loading and saving, with children type selection and optional recursivity.</li>
						<li>Support for find methods, with paging and sorting. (builded with the datagrid in mind :-)</li>
						<li>NEW: Support for SqlView.</li>
						<li>NEW: Select between stored procedure or xml embedded queries.</li>
					</ul>
				</div>
			</li>
			<li>
				Generate <em>strongly-typed collections</em> for entities and repositories.

				<div class="itemizedlist">
					<ul type="circle">
						<li>Implement CollectionBase , IBindingList, IList and ICloneable</li>
						<li>Sortable, even Unsortable ;-)</li>
						<li>bindable to datagrid, or any winform or asp.net controls</li>
					</ul>
				</div>
			</li>
			<li>It creates <em>ASP.NET webservice</em> for distributed programming.</li>
			<li>Create the <em>stored procedures</em> script and can automatically install them on the server.</li>
			<li>Generates a complete <em>nAnt</em> build file, to compile, test and generate chm/html API documentation.</li>
			<li>A full set of <em>nUnit</em> tests.</li>
			
			<li>
				the code is fully <em>nDoc</em> commented (more, it use the Description extended properties of the data table and column) and follow the microsoft naming guidelines.
			</li>
			<li>Open source ! You can modify the templates and contribute (<a href="http://www.sourceforge.net/projects/nettiers" target="_top">http://www.sourceforge.net/projects/nettiers</a>)</li>
		</ul>
	</div>
					
</asp:Content>
