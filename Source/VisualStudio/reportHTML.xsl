<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" indent="yes" />
	<xsl:template match="/NetTiersReport">		
		<html>
			<head>
                <link href="http://nettiers.com/common/styles.css" rel="stylesheet" type="text/css"/>
                <style>
				      span.executionTime {font-style: italic; color: #55AEED;}
	            </style>
			</head>
	
			<body>
				<table width="100%" border="0" cellspacing="2" cellpadding="2">
					<tr>
                        <td width="700">
                            <a href="http://nettiers.com/download.aspx" target="_blank"><img border="0" src="http://nettiers.com/img/netTiersLogo2.0_small.gif" alt=".netTiers 2.0"  /></a>
                            <hr /><div>
                              <a href="http://nettiers.com/">Website</a>
                             &#160;&#160; | &#160;&#160; 
                             <a href="http://community.codesmithtools.com/forums/default.aspx?GroupID=11/">Forums</a>
                             &#160;&#160; | &#160;&#160; 
                             <a href="http://sourceforge.net/projects/nettiers/">Sourceforge</a>
                             &#160;&#160; | &#160;&#160; 
                             <a href="https://www.nettiers.com/download.aspx">Downloads</a>
                            </div>
                           <hr />
                        <h2>Generation Report</h2>
                        <div style="width:70%">
                        <span class="content">.netTiers is a set of open source code generation templates that
                            simplify the tasks of creating customized Application Framework for your Microsoft.Net
                            applications in just a few minutes.&#160;
                            <br/>
                            <br/>
                            This report shows you a list of all of your selected .net class that were generated.  This report
                            also shows gives a quick start configuration instructions so that you can get started using .netTiers.
                            If you need further documentation, please check out the documentation section of this report.
                         </span>
                         </div>
                        </td>
					</tr>
				</table>
								
				<table width="100%" border="0" cellspacing="2" cellpadding="2">
				<tr>
					<td>
					<h2>Sections</h2>
                        <ol>
							<li><a href="#summary">Summary</a></li>
							<li><a href="#Configuration">Configuration</a></li>
							<li><a href="#documentation">Documentation</a></li>
							<li><a href="#details">Details - Generated Classes</a></li>
                        </ol>
						</td>
				</tr>
				<tr>
        			<td valign="top" width="100%" >
            <div id="Summary" style="display:inline">
              <a name="summary"></a>
              <h3>Generation Summary <a href="#top" class="calloutlink" >Top</a></h3>
				<span class="docSubHeader">Generated Solution Found: </span><br />
				<span class="content">
					<ul><li> <xsl:value-of select="//NetTiersReport/@SolutionLink" /> </li></ul>
				</span>
				
				<xsl:apply-templates select="summary"/>
            </div>
          	<div id="Configuration" style="display:inline">
              <a name="Configuration"></a>
              <h3>.netTiers Quick Configuration <a href="#top" class="calloutlink" >Top</a></h3>
			  <p> Below are the steps to to configure the .netTiers components.</p>
			
              <p>To Configure your application to use .netTiers, add the following sections to your App / Web config files.
			
			 You can find more information on how to set this up at<br/> 
			 <a href="http://docs.nettiers.com">.netTiers 2 Install and Configuration Document @ http://docs.netTiers.com</a>
            </p>
            <p>1. Add a new section to the configSettings</p>
            
<pre>
  &lt;section name="netTiersService"
		type="<xsl:value-of select="//NetTiersReport/@DALNameSpace" />.Bases.NetTiersServiceSection, <xsl:value-of select="//NetTiersReport/@DALNameSpace" />"
		allowDefinition="MachineToApplication"
		restartOnExternalChanges="true" /&gt;
</pre>
          <p>2.  Add an item to the ConnectionStrings Section</p>
<pre>
&lt;connectionStrings>
  &lt;add name="netTiersConnectionString" connectionString="<xsl:value-of select="//NetTiersReport/@ConnectionString" />" /&gt;
&lt;/connectionStrings&gt;
</pre>
         <p>3.  Add the netTierService configuration section to your configuration file. Comment / Uncomment which provider you plan on using / not using</p>
 <pre>
&lt;netTiersService defaultProvider="SqlNetTiersProvider"&gt;
  &lt;providers&gt;
    <!--
    *** SqlClient Provider ***
    connectionStringName: sqlclient connection string to the db
    useStoredProcedure: if true indicates that we use the stored procedures, otherwise, we use parametrized queries that are embedded.
    -->
    &lt;add 
	name="SqlNetTiersProvider" 
	type="<xsl:value-of select="//NetTiersReport/@DALNameSpace" />.SqlClient.SqlNetTiersProvider, <xsl:value-of select="//NetTiersReport/@DALNameSpace" />.SqlClient"
	connectionStringName="netTiersConnectionString"
	providerInvariantName="System.Data.SqlClient" 
	entityFactoryType="<xsl:value-of select="//NetTiersReport/@FactoryType" />"
	useEntityFactory="true"
	enableEntityTracking="false"
	enableMethodAuthorization="false"
	useStoredProcedure="false"
  /&gt;
    <!-- 
      *** WebserviceClient Provider ***
      The url parameter indicates the webservices url (ex: http://localhost/NorthWind/NorthWindServices.aspx)
    &lt;add 
      name="WsNetTiersProvider" 
      type="<xsl:value-of select="//NetTiersReport/@DALNameSpace" />.WebServiceClient.WsNetTiersProvider, <xsl:value-of select="//NetTiersReport/@DALNameSpace" />.WebServiceClient"
      url="http://localhost/NetTiersCTPWSNorthwindServices.asmx"
      />
    -->
  &lt;/providers&gt;
&lt;/netTiersService&gt;
 </pre>
          </div>
          <div id="Documentation" style="display:inline">
            <a name="documentation"></a>
            <h3>Documentation <a href="#top" class="calloutlink" >Top</a></h3>
            <a href="http://wiki.nettiers.com">.netTiers 2.0 Getting Started</a><br /><br />

            <b>Sample API Usage</b>
            <br /><table style="border: 1px dashed rgb(255, 153, 0); background-color: rgb(255, 255, 223);" bgcolor="#ffffdf"><tbody><tr><td><pre><font color="black" face="Courier New" size="2">
AccountService accountsService = <font color="blue">new</font> AccountsService();<font color="green">
//GetAll()</font>
TList&lt;Accounts&gt; accountList = accountsService.GetAll();

<font color="green">//GetPagedl()</font>
TList&lt;Accounts&gt; accountList = 
accountsService.GetPaged("IsActive = 1 AND AccountName LIKE 'smi%'");

<font color="green">//GetByFk()</font>
TList&lt;Accounts&gt; accountList = accountsService.GetByCustomerId(25);

<font color="green">//GetIX()</font>
TList&lt;Accounts&gt; accountList = accountsService.GetByAccountCreatedDate(<font color="blue">new</font> DateTime("1/1/2006"));<br /><br /><font color="green">
//Get()</font>
entity.Entitykey;
Accounts account = accountsService.Get(entity.EntityKey);

<font color="green">//Insert()</font>
Account accountEntity = <font color="blue">new</font> Account();
accountEntity.AccountName = "MyAccountName";
accountEntity.CreatedDate = DateTime.Now;

accountsService.Insert(accountEntity);
accountEntity.AccountId <font color="green">// is now populated</font>
<font color="green">
//Delete()</font>
bool result = accountsService.Delete(accountEntity);

<font color="green">//Delete()</font>
bool result = accountsService.Delete(23);

<font color="green">//Update()</font>
accountEntity.AccountName = "MyAccountName 2";
accountsService.Update(accountEntity);
        
<font color="green">//GetByManyToManyl()</font>
TList&lt;Customers&gt; accountList = accountsService.GetCustomers_From_AccountsReceivable();
					            
<font color="green">//GetCustomProcedureName()</font>
TList&lt;Accounts&gt; accountList = accountsService.GetByAccountMaturationDate();
    
<font color="green">//DeepLoadByIdl() using PK</font>
Account account = accountsService.DeepLoadByAccountId(id, <font color="blue">false</font>, DeepLoadType.IncludeChildren, typeof(Customers), typeof(TList&lt;ChartOfAccounts&gt;));<br /><br /><font color="green">//DeepLoadByIdl() using FK</font>
TList&lt;Account&gt; account = accountsService.DeepLoadByCustomerId(id, <font color="blue">false</font>, DeepLoadType.IncludeChildren, typeof(Customers), typeof(TList&lt;ChartOfAccounts&gt;));<br /><br /><font color="green">//already instatiated objects</font>
<font color="green">//DeepLoad</font>
accountsService.DeepLoad(myAccountEntity, <font color="blue">false</font>, DeepLoadType.IncludeChildren, typeof(Customers), typeof(TList&lt;ChartOfAccounts&gt;));<br /><br /><font color="green">
Response.Write(accountsService.CustomerIdSource.LastName); <font color="green">// is now filled</font>
Response.Write(accountsService.ChartOfAccountsCollection.Count); <font color="green">// is now filled</font>

//DeepSave</font>
accountsService.DeepSave(myAccountEntity, <font color="blue">false</font>, DeepSaveType.IncludeChildren, typeof(Customers), typeof(TList&lt;ChartOfAccounts&gt;));<br /><br /></font>
	</pre></td></tr></tbody></table>
            <br />
          </div>
          <div id="ReportDetails" style="display:inline">
            <a name="details"></a>
            <h3>Report Details <a href="#top" class="calloutlink" >Top</a></h3>
				<xsl:call-template name="report"/>
		  </div>
			</td>
		</tr>
	</table>
	<hr noshade="noshade"/>
					
	<table width="100%" border="0" cellspacing="2" cellpadding="2">
		<tr>
			<td></td>
			<td></td>
		</tr>
	</table>
	<xsl:call-template name="copyrightinfo"/>
	<xsl:call-template name="sourceforgeLogo"/>
	</body>
	</html>
	</xsl:template>
	
	<xsl:template name="copyrightinfo">
		<div align="center">
			.netTiersOpen Source Group, 2007
		</div>
	</xsl:template>
	
	<xsl:template name="sourceforgeLogo">
		<div align="center">
         <a href="http://sourceforge.net">
                <img src="http://sourceforge.net/sflogo.php?group_id=118735" width="88" height="31" border="0" alt="SourceForge Logo" />
              </a>
		</div>
	</xsl:template>
	
	<xsl:template match="summary">
	  <table>
	    <tr>
	      <td width="200">Total Object Created</td>
	      <td><xsl:value-of select="objectCount"></xsl:value-of></td>
	    </tr>
	    <tr>
	      <td  width="200">Total Errors / Warnings</td>
	      <td><xsl:value-of select="messageCount"></xsl:value-of></td>
	    </tr>
	  </table>
	</xsl:template>
	<xsl:template name="report">
		<ul>
			<xsl:apply-templates select="initialization" />
			<xsl:apply-templates select="common" />
			<xsl:apply-templates select="Table" />
         <xsl:apply-templates select="customStoredProcedures[@includeCustoms='true']" />
		</ul>
	</xsl:template>
	
	<xsl:template match="Table">
		<li>
			<h3><xsl:value-of select="@name" /></h3>
			<ul>
				<xsl:apply-templates />
			</ul>
			Execution time: <span class="executionTime"><xsl:value-of select="@executionTime" /></span>
			<p/>
		</li>
	</xsl:template>
		
	<xsl:template match="initialization">
		<li>
			<h3>Initialization</h3>
			<ul>
				<xsl:apply-templates />
			</ul>
			Execution time: <span class="executionTime"><xsl:value-of select="@executionTime" /></span>
			<p/>
		</li>		
	</xsl:template>
	
	<xsl:template match="common">
		<li>
			<h3>Common files</h3>
			<ul>
				<xsl:apply-templates select="File"/>
				<xsl:apply-templates select="Message" mode="error"/>
			</ul>
			Execution time: <span class="executionTime"><xsl:value-of select="@executionTime" /></span>
			<p/>
		</li>		
	</xsl:template>
		
	<xsl:template match="Message">
		<li>
			<span class="message{@level}"><xsl:value-of select="@message" /></span>
			<ul>
				<xsl:apply-templates select="File" />
			</ul>
			<xsl:if test="@executionTime">[<xsl:value-of select="@executionTime" />]<br/></xsl:if>
		</li>
	</xsl:template>
		
	<xsl:template match="Message" mode="error">
		<pre style="padding: 10px; border: 1px #808080 dashed; background: #ffffef; color: red;"><xsl:value-of select="@message"/></pre>
	</xsl:template>
	
	<xsl:template match="File">
		<li>
			<span class="file"><xsl:value-of select="@name" /></span>
			<xsl:apply-templates select="Message" mode="error"/>
			<!--<xsl:if test="Message">
				<pre style="padding: 10px; border: 1px #808080 dashed; background: #ffffef; color: red;"><xsl:value-of select="Message/@message"/></pre>
			</xsl:if>-->
		</li>
	</xsl:template>

   <xsl:template match="customStoredProcedures">
      <li>
         <h3>
            Custom Stored Procedures
         </h3>
         <ul>
            <xsl:apply-templates />
         </ul>
      </li>
   </xsl:template>
   
   <xsl:template match="customStoredProcedure">
      <li>
         <span class="file">
            <xsl:value-of select="@name" /> (applies to <xsl:value-of select="@relatedEntityType"/>: <xsl:value-of select="@relatedEntity"/>)
         </span>
      </li>
      <br/>
   </xsl:template>

</xsl:stylesheet>