<%@ Page MasterPageFile="~/MasterPage.master" %>


<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

		<script src="http://js.track.semway.com/v1.2/tag.js" type="text/javascript"></script>
    <script type="text/javascript">
    <!--
        swtag();
    -->
    </script>
    <noscript>
			<img width="1" height="1" src="http://ws2.track.semway.com/v1.3/noscript.ashx" >
		</noscript>

<style>/* Paragraph and pre-formatted text appearance */
pre
{
	margin-top: .5em;
	margin-bottom: .5em;
	font-family: Monospace, Courier New, Courier;
	border: 1px #D0D0D0 solid;
	background-color: #F0F0F0;
	color: #003366;
	font-size: 100%;
	margin-left: 20px;
	padding: 4px;
	text-indent: 0;
}
</style>
<div class="book" lang="en">
<div class="titlepage">
<!--<div><div class="mediaobject" align="left"><img src="http://www.nettiers.com/images/logo.gif" align="left"></div><div><h1 class="title"><a name="IDAHAIO"></a>.NetTiers</h1></div><div><h2 class="subtitle">The .Net data tiers generator</h2></div><div></div></div></div><div><p class="copyright">Copyright © 2005 http://www.nettiers.com</p></div><div><p class="pubdate">$Date$</p></div><div><p class="releaseinfo">$Revision$</p></div></div>-->
<div class="authorgroup"><div class="author"><h3 class="author"><span class="firstname">John</span> <span class="surname">Roland</span></h3>
</div></div>
<hr>
</div>
<div class="toc"><p><b>Table of Contents</b></p><dl><dt><span class="preface"><a href="#IDAPBIO">Preface</a></span><dt><span class="chapter"><a href="#IDAPEIO">1. Concepts</a></span><dt><span class="chapter"><a href="#IDAGFIO">2. Northwind samples</a></span><dd><dl><dt><span class="section"><a href="#IDAKFIO">Sample model</a></span><dt><span class="section"><a href="#IDADHIO">Code examples :</a></span></dt></dl><dt><span class="chapter"><a href="#IDAXHIO">3. Configuration</a></span><dd><dl><dt><span class="section"><a href="#IDA1HIO"></a></span></dt></dl><dt><span class="chapter"><a href="#IDA0KIO">4. Deep load, Deep save</a></span><dd><dl><dt><span class="section"><a href="#IDA4KIO"></a></span></dt></dl><dt><span class="chapter"><a href="#IDAELIO">5. Adding Data access methods, based on your own stored procedures</a></span><dd><dl><dt><span class="section"><a href="#IDAILIO">Overview</a></span><dt><span class="section"><a href="#IDAFMIO">Sample</a></span></dt></dl><dt><span class="chapter"><a href="#IDAYMIO">6. the nAnt file</a></span><dt><span class="chapter"><a href="#IDANNIO">7. Templates parameters</a></span><dt><span class="chapter"><a href="#IDADSIO">8. Unit tests</a></span><dt><span class="chapter"><a href="#IDAHTIO">9. Recommandations</a></span><dd><dl><dt><span class="section"><a href="#IDALTIO">Database design guide</a></span></dt></dl><dt><span class="chapter"><a href="#IDAEUIO">10. Roadmap</a></span><dd><dl><dt><span class="section"><a href="#IDAIUIO">v0.9 - Childebert</a></span><dt><span class="section"><a href="#IDAEVIO">v1.0 - Clotaire</a></span><dt><span class="section"><a href="#IDA4VIO">v1.1 - Caribert</a></span></dt></dl><dt><span class="chapter"><a href="#IDANWIO">11. Project information</a></span><dd><dl><dt><span class="section"><a href="#IDARWIO">Description</a></span><dt><span class="section"><a href="#IDAFXIO">Contributors</a></span></dt></dl></dd></dl></div>
<div class="list-of-tables">
<p><b>List of Tables</b></p>
<dl>
<dt>2.1. <a href="#IDAQFIO">The employee Table</a>
<dt>7.1. <a href="#IDATNIO">DataSource category</a>
<dt>7.2. <a href="#IDA0OIO">General category</a>
<dt>7.3. <a href="#IDABRIO">Parameters for webservice</a></dt></dl>
</div>
<div class="preface" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDAPBIO"></a>Preface</h2></div></div>
</div>
<p>
	    	.netTiers are CodeSmith templates for object-relational mapping that takes an existing SQLServer database and automatically generates
	        a personalized DataTiers application block to use in your .net applications.  
	     </p>
<p>
			Core features include:
		</p>
<div class="itemizedlist">
<ul type="disc">
<li>
				Generates ready to use <span class="emphasis"><em>Visual Studio</em></span> 
  projects and solution. 
  
<li>
				Fully integrate with entreprise library application 
  blocks architecture. Shipped with it's own plugin, so you can configure your 
  application directly from the entlib configuration console. 
  
<li>
				Generate the business objects (called entities) with a 1:1
				mapping ( an entity for each table, with a property for each
				column).
		
				<div class="itemizedlist">
<ul type="circle">
<li>
						Serializable 
    
<li>
						Trigger Entity Events 
    
<li>
						Implements an IEntity interface, which contains the 
    columns that are present in every table 
    
<li>
						Specific support for Enums, and Enum Generation.
					</li>
</ul>
</div>
<li>
					Generate Data Access Layer Components (DALC) for tables and views , with following database operations :
		
				<div class="itemizedlist">
<ul type="circle">
<li>
						Support for basic CRUD: UPDATE, DELETE, INSERT, 
    SELECT ALL, PAGED SELECT, FIND 
    
<li>
						Support for queries using primary key 
    
<li>
						Support for queries using foreign key 
    
<li>
						Support for queries using keys that are part of an index (Not already included as a pk or fk)
    
<li>
						Support for queries using keys that are part of a  junction table, (many to many relationships)
    
<li>
						Support for user defined Methods, generated from 
    queries that are detected throught a very simple naming rule 
    (_TableName_MyMethodName) 
     Or, you can view this post to find out more: 
<li>
						Support for Deep loading and saving, with children 
    type selection and optional recursivity. 
    
<li>
						Support for find methods, with paging and sorting. 
    (built with the grid family in mind) :-) 
    
<li>
						Support for Sql Views. 
    
<li>				Select between stored procedure or parameterized sql using an xml embedded query file.
					</li>
</ul>
</div>
<li>
				Generate strongly-typed generic collections for entities and repositories using TList<> and/or VList.

				<div class="itemizedlist">
<ul type="circle">
<li>
						Implement  BindingList&lt;T&gt;, IBindingListView, IBindingList, IList, ICloneable, IListSource, ITypedList, IDisposable, IComponent, IRaiseItemChangedEvents, IDeserializationCallback
    
<li>
						Sortable, even Unsortable! 
    
</li>
<li>
						Bindable to any gridview, datagrid, or any winform or asp.net control
					</li>
</ul>
</div>
<li>
				It creates <span class="emphasis"><em>ASP.NET Webservice</em></span> 
  for distributed programming. 
  
<li>
				Create the stored procedures script and can 
  automatically install them on the server. 
  
<li>
				Generates a complete <span class="emphasis"><em>nAnt</em></span> build file, to 
  compile, test and generate chm/html API documentation. 
  
<li>
				Create a full set of validation rules based on database schema information.  And includes a full framework to manage your own rules.
</li> 
<li>
				Each object has a concrete and a base class which it 
  inherit from. The concrete class is generated just once, so you have can use 
  it to add you custom code.   All of the base classes are also partial classes, so you can add
  framework wide functionality with no problems.
<li>
				Creates an EntityDataSource, you no longer have to mess with overcoming the shortcomings with the ObjectDataSource, .netTiers provides an advanced EntityDataSource that 
				knows about the repositories and creates a 100% declarative model.  NO CODE BEHIND WHATSOEVER!
<li>
				Create a full set of web administration controls, you can setup a web admin to your database in literally, minutes...				
</li> 
<li>
				Do I have to keep going, I mean come on, there are features out the wazzuua, download it today...				
</li> 
<li>
				A full set of nUnit tests. 
<li>
				The code is fully commented (it use to Description 
  extended properties of the data table and column) and follow the microsoft 
  naming guidelines. 
  
<li>
				Holy Cow, It's free and Open source! You can modify the templates like the control freak inside us all demands, and contribute so we can give back to the community. (<a href="http://www.sourceforge.net/projects/nettiers" target="_top">http://www.sourceforge.net/projects/nettiers</a>)
			</li>
</ul>
</div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDAPEIO"></a>Chapter&nbsp;1.&nbsp;Concepts</h2></div></div>
</div>
<p>
	       This data tiers concept is composed of custom business entities components (the data itself) and data access logic components (the persistence logic).
	       This design is inspired from the Microsoft patterns &amp; practices guide <a href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnbda/html/BOAGag.asp" target="_top">Designing Data Tier Components and Passing Data Through Tiers</a>:
	    </p>
<div class="mediaobject"><img src="http://www.nettiers.com/images/design.gif"></div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDAGFIO"></a>Chapter&nbsp;2.&nbsp;Northwind samples</h2></div></div>
</div>
<div class="toc">
<p><b>Table of Contents</b></p>
<dl>
<dt><span class="section"><a href="#IDAKFIO">Sample model</a></span>
<dt><span class="section"><a href="#IDADHIO">Code examples :</a></span></dt></dl>
</div>
<div class="section" lang="en">
<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDAKFIO"></a>Sample model</h2></div></div>
</div>
<p>To demonstrate the basis of the templates, we will use the following "Employee" Table:</p>
<div class="table"><a name="IDAQFIO"></a><p class="title"><b>Table&nbsp;2.1.&nbsp;The employee Table</b></p>
<table summary="The employee Table" border="1">
<colgroup><col><col><col></colgroup>
<thead>
<tr>
<th>The Employee Northwind table</th>
<th>The generated OO architecture</th>
<td class="auto-generated">&nbsp;</td>
</tr>
</thead>
<tbody>
<tr>
<td>
								<div class="mediaobject"><img src="http://www.nettiers.com/images/Employee_DatabaseTable.png"></div>
							</td>
<td>
								<div class="mediaobject"><img src="http://www.nettiers.com/images/FullDiagram.png"></div>
							</td>
<td class="auto-generated">&nbsp;</td>
</tr>
</tbody>
</table>
</div>
</div>
<div class="section" lang="en">
<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDADHIO"></a>Code examples :</h2></div></div>
</div>
<pre class="programlisting">using Northwind.DataAccessLayer;
			
// Get all the employee, sort it on the LastName and print them out 
TList&lt;Employees&gt; employees = DataRepository.EmployeeProvider.GetAll();
employees.Sort(EmployeeColumns.LastName, ListSortDirection.Ascending);
foreach(Employee employee in employees)
{
	Console.WriteLine("{1} {0}", employee.FirstName, employee.LastName);
}
</pre>
<pre class="programlisting">using Northwind.DataAccessLayer;

// Create a new record and save
Employee employee = new Employee();
employee.FirstName = "John";employee.LastName = "Doe";
employee.BirthDate = DateTime.Now;employee.Address = "10 , fake street";
employee.City = "Metroplolis";employee.Country = "USA";
employee.HireDate = DateTime.Now;
employee.HomePhone = "0123456789";
employee.Notes = "This is a fake employee";
employee.Title = "M";
employee.TitleOfCourtesy = "Dear";
employee.PostalCode = "5556";
employee.Region = "New-York";

DataRepository.EmployeeProvider.Insert(employee);

//look, new id already populated
Console.WriteLine("New Employee ID" + employee.EmployeeId);
	
	</pre>
<pre class="programlisting">using Northwind.DataAccessLayer;

// Select by Index and Update
TList&lt;Employees&gt; employees = DataRepository.EmployeeProvider.GetByLastName("Doe");
if (employees.Count == 1)
{
	employees[0].Notes = "This is a modified fake employee";
	DataRepository.EmployeeProvider.Save(employees[0]);
	
	Console.Write(employees[0]);
}
	</pre>
<pre class="programlisting">using Northwind.DataAccessLayer;

// Select by primary key and Delete 
// (Demonstrate that insert, update, delete methods can also take collection as parameter)
Employee employee = SqlDataRepository.EmployeeProvider.GetByEmployeeID(13);
DataRepository.EmployeeProvider.Delete(employees);
	</pre>
<pre class="programlisting">using Northwind.DataAccessLayer;

// The SqlClient can work with transactions.
// Also show the Save method, wich encapsulate the use of Insert, Update and Delete methods.
TransactionManager transaction = DataRepository.CreateTransaction();
transaction.BeginTransaction(/*IsolationLevel.ReadUncommited*/);
try
{
	// Insert
	Employee employee = new Employee();
	employee.FirstName = "John";
	employee.LastName = "Doe";
	employee.BirthDate = DateTime.Now;
	employee.Address = "10 , fake street";
	employee.City = "Metroplolis";
	employee.Country = "USA";
	employee.HireDate = DateTime.Now;
	employee.HomePhone = "0123456789";
	mployee.Notes = "This is a fake employee";
	employee.Title = "M";
	employee.TitleOfCourtesy = "Doctor";
	employee.PostalCode = "5556";
	employee.Region = "New-York";
	DataRepository.EmployeeProvider.Save(transaction, employee);
	
	// modify the employee instance
	employee.Notes = "This is a modified fake employee";
	
	// Update
	DataRepository.EmployeeProvider.Save(transaction, employee); 
	transaction.Commit();
	Console.WriteLine("ok");

} 
catch(Exception ex)
{
	try { transaction.Rollback();} catch(){}
	Console.WriteLine("nok : {0}", ex);
}
	</pre>
<pre class="programlisting">/*
	DeepSave helper method can help you to save an object and its children in one call.
*/
	
	using Northwind.DataAccessLayer;

	Order order = Order.CreateOrder("ALFKI", 1, DateTime.Now, DateTime.Now, DateTime.Now, 1, 0.1m, "ship name", "ship address" , "paris", "idf", "75000", "france");
	order.OrderDetailCollection.Add(order.OrderID, 1, 15.6m, 10, 0.02f);
	order.OrderDetailCollection.Add(order.OrderID, 2, 122.6m, 43, 0.03f);

	DataRepository.OrderProvider.DeepSave(order);
	
	Console.WriteLine("new order saved: orderId is: " + order.OrderID.ToString());
			
	</pre>
<pre class="programlisting">/*
	You can configure multiple data provider in the configuration console, and write code to acces a specific one, instead of the default.
*/
	using Northwind.DataAccessLayer;

	SqlDataProvider myRepository = DataRepository.Providers["my second data provider"] as Northwind.DataAccessLayer.SqlClient.SqlDataProvider;
	
	this.listBox1.DataSource = myRepository.ProductProvider.GetAll();
	this.listBox1.DisplayMember = "ProductName";
	this.listBox1.ValueMember = "ProductID";
	
	//Or if you can't have it pre-configured, you can change the connection string at runtime.
	
	using Northwind.DataAccessLayer;

    //New syntax using a declared connection string:

    TList&lt;Products&gt; list = DataRepository.Connections["NorthwindConnectionString2"].Provider.CustomersProvider.GetAll();

    //New syntax using a dynamic connection string:

    DataRepository.AddConnection("DynamicConnectionString", "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true;");

    TList&lt;Products&lt; list = DataRepository.Connections["DynamicConnectionString"].Provider.ProductsProvider.GetAll();	
	this.listBox1.DataSource = list;
	this.listBox1.DisplayMember = "ProductName";
	this.listBox1.ValueMember = "ProductID";
	</pre>
</div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDAXHIO"></a>Chapter&nbsp;3.&nbsp;Configuration</h2></div></div>
</div>
<div class="toc">
<p><b>Table of Contents</b></p>
<dl>
<dt><span class="section"><a href="#IDA1HIO"></a></span></dt>
</dl>
</div>
<div class="section" lang="en">
<div class="titlepage"></div>
            <p> Below are the steps to to configure the .netTiers components.  These are samples from Northwind.</p>
            <p>To Configure your application to use .netTiers, add the following sections to 
              your App / Web config files.
			
			 You can find more information on how to set this up at, 
			 <a href="http://community.codesmithtools.com/forums/permalink/9769/9769/ShowThread.aspx#9769">.netTiers 2 Install and Configuration Document</a></p>
            <p>1. Add a new section to the configSettings</p>
            <pre>  &lt;section name="netTiersService"
		type="Northwind.DataAccessLayer.Bases.NetTiersServiceSection, Northwind.DataAccessLayer"
		allowDefinition="MachineToApplication"
		restartOnExternalChanges="true" /&gt;
</pre>
            <p>2.  Add an item to the ConnectionStrings Section</p>
            <pre>&lt;connectionStrings&gt;
  &lt;add name="netTiersConnectionString" connectionString="Data Source=(local);Initial Catalog=Northwind;Integrated Security=true;Connection Timeout=1;" /&gt;
&lt;/connectionStrings&gt;
</pre>
            <p>3.  Add the netTierService configuration section to your configuration file. Comment / Uncomment which provider you plan on using / not using</p>
            <pre>&lt;netTiersService defaultProvider="SqlNetTiersProvider"&gt;
  &lt;providers&gt;
    
    &lt;add 
	    name="SqlNetTiersProvider" 
	    type="Northwind.DataAccessLayer.SqlClient.SqlNetTiersProvider, Northwind.DataAccessLayer.SqlClient"
	    connectionStringName="netTiersConnectionString"
	    useStoredProcedure="false"
	    providerInvariantName="System.Data.SqlClient" /&gt;
    
  &lt;/providers&gt;
&lt;/netTiersService&gt;
 </pre>
</div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDA0KIO"></a>Chapter&nbsp;4.&nbsp;Deep load, Deep save</h2></div></div>
</div>
<div class="toc">
<p><b>Table of Contents</b></p>
<dl>
<dt><span class="section"><a href="#IDA4KIO"></a></span></dt>
</dl>
</div>
<div class="section" lang="en">
<div class="titlepage"></div>
</div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDAELIO"></a>Chapter&nbsp;5.&nbsp;Adding Data access methods, based on your own stored procedures</h2></div></div>
</div>
<div class="toc">
<p><b>Table of Contents</b></p>
<dl>
<dt><span class="section"><a href="#IDAILIO">Overview</a></span>
<dt><span class="section"><a href="#IDAFMIO">Sample</a></span></dt></dl>
</div>
<div class="section" lang="en">
<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDAILIO"></a>Overview</h2></div></div>
</div>
<p>
	          To add new methods to the Data access logic components (xxRepository classes), you can add them to the
	          concrete classes. As opposite to the Base classes which are overwriten at each generation, the concrete class at only generated once.
	          That solution is good, but presents some disavantages:
	          <div class="itemizedlist"><ul type="disc"><li>You'll have to write many overloads in order to offer 
  the same functionality than generated code</ul></div>There is an alternative: generate methods from 
your own stored procedures. To activate this, turn the "Include custom sql" 
option to True. Then your stored procedure name must starts with '_TableName_' 
followed by the text you want as Method name. This naming convention will permit 
the templates to detect your stored procedure, and to create the method in the 
correct repository class (xxTableNameRepository). 
<br />
<a href="http://community.codesmithtools.com/forums/permalink/11431/11431/ShowThread.aspx#11431">More info:</a>
</div>
<div class="section" lang="en">
<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDAFMIO"></a>Sample</h2></div></div>
</div>
<p>
An explanation is probably an example, just take a look at the Product table from the Northwind database,
and imagine we want the list of products that have units in stock that are bellow a given value.
So we first create the following stored procedure:
			</p>
<pre class="programlisting">-- Get the products that have less units in stock than the @UnitsInStock parameter.
CREATE PROCEDURE dbo._Products_GetWithStockBelow
@UnitsInStock smallint
AS

SELECT
[ProductID],
[ProductName],
[SupplierID],
[CategoryID],
[QuantityPerUnit],
[UnitPrice],
[UnitsInStock],
[UnitsOnOrder],
[ReorderLevel],
[Discontinued]
FROM
[dbo].[Products]
WHERE
[UnitsInStock] &lt; @UnitsInStock
GO
	      </pre>
<p>
				After that we can run the generation, and look at the SqlClient ProductRepository class "Custom Methods" region:
			</p>
<pre class="programlisting">	          
/// &lt;summary&gt;
///	This method wrap the '_Products_GetWithStockBelow' stored procedure. 
/// &lt;/summary&gt;
/// &lt;param name="UnitsInStock"&gt; A &lt;c&gt;System.Int16&lt;/c&gt; instance.&lt;/param&gt;
/// &lt;param name="start"&gt;Row number at which to start reading.&lt;/param&gt;
/// &lt;param name="pageLength"&gt;Number of rows to return.&lt;/param&gt;
/// &lt;remark&gt;This method is generate from a stored procedure.&lt;/remark&gt;
/// &lt;returns&gt;A &lt;see cref="ProductCollection" /&gt; instance.&lt;/returns&gt;
public  ProductCollection GetWithStockBelow(int start, int pageLength , System.Int16 UnitsInStock)
{
	return GetWithStockBelow(this.transactionManager, this.connectionString, 0, int.MaxValue , UnitsInStock);
}

/// &lt;summary&gt;
///	This method wrap the '_Products_GetWithStockBelow' stored procedure. 
/// &lt;/summary&gt;
/// &lt;param name="UnitsInStock"&gt; A &lt;c&gt;System.Int16&lt;/c&gt; instance.&lt;/param&gt;
/// &lt;param name="transactionManager"&gt;&lt;see cref="TransactionManager" /&gt; object&lt;/param&gt;
/// &lt;remark&gt;This method is generate from a stored procedure.&lt;/remark&gt;
/// &lt;returns&gt;A &lt;see cref="ProductCollection" /&gt; instance.&lt;/returns&gt;
public  ProductCollection GetWithStockBelow(TransactionManager transactionManager , System.Int16 UnitsInStock)
{
	return GetWithStockBelow(transactionManager, string.Empty , 0, int.MaxValue , UnitsInStock);
}

/// &lt;summary&gt;
///	This method wrap the '_Products_GetWithStockBelow' stored procedure. 
/// &lt;/summary&gt;
/// &lt;param name="UnitsInStock"&gt; A &lt;c&gt;System.Int16&lt;/c&gt; instance.&lt;/param&gt;
/// &lt;remark&gt;This method is generate from a stored procedure.&lt;/remark&gt;
/// &lt;returns&gt;A &lt;see cref="ProductCollection" /&gt; instance.&lt;/returns&gt;
public  ProductCollection GetWithStockBelow(System.Int16 UnitsInStock)
{
	return GetWithStockBelow(this.transactionManager, this.connectionString, 0, int.MaxValue , UnitsInStock);
}

	
/// &lt;summary&gt;
///	This method wrap the '_Products_GetWithStockBelow' stored procedure. 
/// &lt;/summary&gt;
/// &lt;param name="UnitsInStock"&gt; A &lt;c&gt;System.Int16&lt;/c&gt; instance.&lt;/param&gt;
/// &lt;param name="start"&gt;Row number at which to start reading.&lt;/param&gt;
/// &lt;param name="pageLength"&gt;Number of rows to return.&lt;/param&gt;
/// &lt;param name="transactionManager"&gt;&lt;see cref="TransactionManager" /&gt; object&lt;/param&gt;
/// &lt;param name="connectionString"&gt;Connection string to datasource.&lt;/param&gt;
/// &lt;remark&gt;This method is generate from a stored procedure.&lt;/remark&gt;
/// &lt;returns&gt;A &lt;see cref="ProductCollection" /&gt; instance.&lt;/returns&gt;
protected  ProductCollection GetWithStockBelow(TransactionManager transactionManager, string connectionString, int start, int pageLength , System.Int16 UnitsInStock)
{
	SqlDataReader reader;
	if (transactionManager != null)
		reader = SqlHelper.ExecuteReader(transactionManager.TransactionObject, "_Products_GetWithStockBelow", UnitsInStock);
	else
		reader = SqlHelper.ExecuteReader(connectionString, "_Products_GetWithStockBelow", UnitsInStock);
	
	//Create Collection
	ProductCollection rows = new ProductCollection();
	Fill(reader, rows, start, pageLength);
	reader.Close();
	return rows;
}
	
	          </pre>
<p>
	            As you can see, all the overloads are generated, with parameters and paging for both sqlClient and webServiceClient.
	       </p>
</div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDAYMIO"></a>Chapter&nbsp;6.&nbsp;the nAnt file</h2></div></div>
</div>
<p>
	            The template generates a nAnt build file. I will not explain here what is nant, you can find more information at <a href="http://nant.sourceforge.net" target="_top">nAnt homepage</a>.
	            Basically, it is used to compile the program from a command line, and without the need of visual studio,
	            but  it's not limited to that: it also contains targets to run nUnit tests and build nDoc documentation.
	        </p>
<div class="mediaobject"><img src="http://www.nettiers.com/images/nAnt.PNG"></div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDANNIO"></a>Chapter&nbsp;7.&nbsp;Template parameters</h2></div></div>
</div>
<p>The templates are configurable in many aspects:</p>
<div class="table"><a name="IDATNIO"></a><p class="title"><b>Table&nbsp;7.1.&nbsp;DataSource category</b></p>
<table summary="DataSource category" border="1">
<colgroup><col><col></colgroup>
<tbody>
<tr>
<td>SourceDatabase</td>
<td>The database from which you want to create the application block.</td>
</tr>
<tr>
<td>SourceTables</td>
<td>The list of table you want to include in the generation.</td>
</tr>
<tr>
<td>EntireDatabase</td>
<td>Indicates if all the tables have to be included, in consequence it overrides the SourceTables list.</td>
</tr>
</tbody>
</table>
</div>
<div class="table"><a name="IDA0OIO"></a><p class="title"><b>Table&nbsp;7.2.&nbsp;General category</b></p>
<table summary="General category" border="1">
<colgroup><col><col></colgroup>
<tbody>
<tr>
<td>OuputDirectory</td>
<td>The root path destination for the generation.</td>
</tr>
<tr>
<td>BusinessLogicLayerFolderName</td>
<td>The OuputDirectory's sub-folder name for the BLL code
					(entity and entity collection), it is recommended to let it
					blank.</td>
</tr>
<tr>
<td>DataAccessLayerFolderName</td>
<td>The OuputDirectory's sub-folder name for the
					DAL(Repository) code (recommended value: DataAccessLayer)</td>
</tr>
<tr>
<td>SqlFolderName</td>
<td>The OuputDirectory's sub-folder name for the stored
					procedure script (recommended value: SQL)</td>
</tr>
<tr>
<td>NameSpace</td>
<td>The root namespace for the project. DAL subfolder name is
					used with this parameter for the DAL namespace (namespace
					structure = directory structure)</td>
</tr>
<tr>
<td>GenerateUnitTest</td>
<td>Indicates if the nUnit tests have to be generated.</td>
</tr>
<tr>
<td>VsNetIntegration</td>
<td>Specify the kind of visual studio integratrion: none,
					single project, separated project (BLL and DAL).</td>
</tr>
<tr>
<td>VsNetVersion</td>
<td>Specify the version of visual studio.</td>
</tr>
</tbody>
</table>
</div>
<div class="table"><a name="IDABRIO"></a><p class="title"><b>Table&nbsp;7.3.&nbsp;Parameters for webservice</b></p>
<table summary="Parameters for webservice" border="1">
<colgroup><col><col></colgroup>
<tbody>
<tr>
<td>GenerateWebService</td>
<td>Indicates if the asp.net webservice and the associated DAL
					have to be generated.</td>
</tr>
<tr>
<td>WebServiceOutputPath</td>
<td>The full path to the asp.net webservice folder (example:	c:\inetpub\wwwroot\WebServices)</td>
</tr>
<tr>
<td>WebServiceUrl</td>
<td>The url that match with the WebServiceOutputPath (example:
					http://localhost/Services/DatabaseNameRepository)</td>
</tr>
</tbody>
</table>
</div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDADSIO"></a>Chapter&nbsp;8.&nbsp;Unit tests</h2></div></div>
</div>
<p>
				The templates can optionnaly generate nUnit tests. So far these tests are limited to:
			</p>
<div class="itemizedlist">
<ul type="disc">
<li>Insert 
  
<li>Update 
  
<li>GetAll 
  
<li>Delete 
  
<li>DeepLoad 
  
<li>Serialization</li></ul>
</div>
<div class="screenshot">
<div class="mediaobject"><img src="http://www.nettiers.com/images/Northwind_UnitTests.png"></div>
</div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDAHTIO"></a>Chapter&nbsp;9.&nbsp;Recommendations</h2></div></div>
</div>
<div class="toc">
<p><b>Table of Contents</b></p>
<dl>
<dt><span class="section"><a href="#IDALTIO">Database design guidelines</a></span></dt></dl>
</div>
<div class="section" lang="en">
<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDALTIO"></a>Database design guidelines</h2></div></div>
</div>
<p>
				In a perfect world, the following rules should be applied to your database to get the best of the templates:
			</p>
<div class="itemizedlist">
<ul type="disc">
<li>
					Tables name are singular and Pascal Case. 
  
<li>
					Fields are Pascal Case and a description is provided. 

  
<li>
					Foreign keys are associated to a relation 
  
<li>
					Field or group of fields that will be used to made a 
  query on this table are indexed. 
  
<li>
					Custom stored procedure's name start with an 
  underscore, followed by the name of the target table. 
  
<li>
					Don't end a table's name with the word "Collection". 
  
<li>
					Don't have a table named "ListItem".
				</li>
</ul>
</div>
</div>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDAEUIO"></a>Chapter&nbsp;10.&nbsp;Roadmap</h2></div></div>
</div>
<div class="toc">
<p><b>Table of Contents</b></p>
<dl>
<dt><span class="section"><a href="#IDAIUIO">v0.9 - Childebert</a></span>
<dt><span class="section"><a href="#IDAEVIO">v1.0 - Clotaire</a></span>
<dt><span class="section"><a href="#IDA4VIO">v1.1 - Caribert</a></span></dt></dl>
</div>
<div class="section" lang="en">
<%--<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDAIUIO"></a>v0.9 - Childebert</h2></div></div>
</div>
<div class="itemizedlist">
<ul type="disc">
<li>
<p>Deep loading and saving</p>
<li>
<p>More coverage with the unit test</p>
<li>
<p>Inclusion of custom SQL queries in the DataAccessLayer</p>
<li>
<p>Generation of msbuild, nAnt and nDoc files</p>
</li>
</ul>
</div>
</div>
<div class="section" lang="en">
<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDAEVIO"></a>v1.0 - Clotaire</h2></div></div>
</div>
<div class="itemizedlist">
<ul type="disc">
<li>
					Support for views 
  
<li>
					Enum generation 
  
<li>
					Use of entreprise library configuration and data 
  access application blocks 
  
<li>
					Generation report 
  
<li>
					Support for composite primary key. 
  
<li>
					Support for computed columns. 
  
<li>
					Automatic concurrency support for tables with a 
  timestamp (rowversion) column. 
  
<li>
					Codesmith 3 compliancy. 
  
<li>
					User customization of namespaces and classes name.
				</li>
</ul>
</div>
</div>
<div class="section" lang="en">
<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDA4VIO"></a>v1.1 - Caribert</h2></div></div>
</div>
<div class="itemizedlist">
<ul type="disc">
<li>
					A winform wizard interface 
  
<li>
					Batch file generation 
  
<li>
					Business rule validator
				</li>
</ul>
</div>
</div>--%>
</div>
<div class="chapter" lang="en">
<div class="titlepage">
<div><div><h2 class="title"><a name="IDANWIO"></a>Chapter&nbsp;11.&nbsp;Project information</h2></div></div>
</div>
<div class="toc">
<p><b>Table of Contents</b></p>
<dl>
<dt><span class="section"><a href="#IDARWIO">Description</a></span>
<dt><span class="section"><a href="#IDAFXIO">Contributors</a></span></dt></dl>
</div>
<div class="section" lang="en">
<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDARWIO"></a>Description</h2></div></div>
</div>
<p>The project is open source and is hosted at <a href="http://sourceforge.net/projects/nettiers" target="_top">sourceforge</a>. You
			can also search for information or support via the <a href="http://community.codesmithtools.com/forums/default.aspx?GroupID=11" target="_top">codesmith
			forum</a>. The templates were originally developed by
			<span class="authorinitials">Ryan Hurdon</span> and are now maintained by
			<span class="authorinitials">John Roland</span>. </p>
</div>
<div class="section" lang="en">
<div class="titlepage">
<div><div><h2 class="title" style="CLEAR: both"><a name="IDAFXIO"></a>Contributors</h2></div></div>
</div>
<div class="itemizedlist">
<fieldset style="width:400px;">
    <legend >Creators</legend>
       <ul type="disc">
        <li>Ryan Hurdon (Creator of the templates) 
		</li>  
		<li>John Roland (refactoring, base classes, webservice, 
  unit tests, events, Visual studio integration, debugging) </li>			
  </ul>
</fieldset>
<br />
<fieldset style="width:400px;">
    <legend>Active Members</legend>
    <span>
    <b>Roles Include:</b> Architecture, Project Guidance, Project Support, Active Development, etc...<br />
   </span>
    <ul>
	    <li> John Roland </li> <li> Robert Hinojosa</li><li>  Ben Johnson</li><li>  John Teague</li><li>Bobby Diaz</li><li>  Phil Buldoc</li><li>  Eric J. Smith</li><li> Clynton</li></ul>
</fieldset>
	<br />
<fieldset style="width:400px;">
    <legend >Other Contributors</legend>
    <span>Thanks to all of you for allowing us to have such an awesome growing community!</span>
<ul>
<li>
					Oskar Austegard for the sptemplate script. </li>
  
<li>
					Dave Kekish (multiple primary keys) </li>
  
<li>
					Fabio Fabrizio (Find methods, GetPaged methods) </li>
  
<li>
					_ab for computed columns </li>
  
<li>Steven Smith for the shuffle method on collection</li><li>Mike Shanty (EntityDataSource Tag Generation, Caching Scheme, Logo)</li><li>and many, many more.</li></ul>
</fieldset>

</div>
<a href="http://sourceforge.net" target="_top">
				<div class="mediaobject"><img src="http://sourceforge.net/sflogo.php?group_id=118735&amp;type=7"></div>
			</a></div>
</div>
</div>

</asp:Content>