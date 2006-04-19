<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" indent="yes" />

	<xsl:template match="/NetTiersReport">		
		<html>
			<head>
				<title> <xsl:value-of select="title" /> </title>
				<link href="http://nettiers.sourceforge.net/default.css" rel="stylesheet" type="text/css"/>
				<style>
					span.executionTime {font-style: italic; color: #003366;}
          TD.menu {
    	      FONT-FAMILY: Tahoma, Arial; HEIGHT: 30px; BACKGROUND-COLOR: #99cc99
          }
          .handCursor {  cursor: hand}
          .pointerCursor {  cursor: pointer}
         </style>
        <script language="javascript">
          var currentMenu="Summary";
          function showMenu(elementName){
            if(elementName != currentMenu){
              document.getElementById(elementName).style.display = "inline";
              document.getElementById(currentMenu).style.display = "none";
              currentMenu = elementName;
            }
          
          }
        </script>
			</head>
	
			<body>
				<table width="100%" border="0" cellspacing="2" cellpadding="2">
					<tr>
						<td width="300"><h1><img src="http://nettiers.sourceforge.net/images/logo.gif" alt=".NetTiers Logo. By Micheal" /></h1></td>
						<td><h2>.NetTiers generation report</h2></td>
					</tr>
				</table>
								
				<table width="100%" border="0" cellspacing="2" cellpadding="2">
				  	<tr>
					  <td width="15%" valign="top">					    	
					    	<xsl:call-template name="navigation"/>
						</td>
						<td valign="top"  class="codeCopy"> 
						  <table>
            <tr>
              <td class="menu" onmouseover="this.style.cursor='hand'" onclick="showMenu('Summary')">Generation Summary
              </td>
              <td class="menu" onmouseover="this.style.cursor='hand'" onclick="showMenu('Configuration')">Configuration</td>
              <td class="menu" onmouseover="this.style.cursor='hand'" onclick="showMenu('Documentation')">Documentation</td>
              <td class="menu" onmouseover="this.style.cursor='hand'" onclick="showMenu('ReportDetails')">Generation Details</td>
            </tr>
          </table>
          <div id="Summary" style="display:inline">
            
            <xsl:apply-templates select="summary"/>
          </div>
          <div id="Configuration" style="display:none">
			<p> Below are the steps to to configure the .netTiers components.  These are samples from Northwind.</p>
			
                        <p>To Configure your application to use .netTiers, add the following sections to 
              your App / Web config files
            </p>
            <p>1. Add a new section to the configSettings</p>
            
<pre>
  < section name="netTiersService"
		type="Northwind.DataAccessLayer.Bases.NetTiersServiceSection, Northwind.DataAccessLayer"
		allowDefinition="MachineToApplication"
		restartOnExternalChanges="true" />
</pre>
          <p>2.  Add an item to the ConnectionStrings Section</p>
<pre>
< connectionStrings>
  < add name="netTiersConnectionString" connectionString="Data Source=(local);Initial Catalog=Northwind;Integrated Security=true;Connection Timeout=1;" />
< /connectionStrings>
</pre>
         <p>3.  Add the netTierService configuration section to your configuration file. Comment / Uncomment which provider you plan on using / not using</p>
 <pre>
< netTiersService defaultProvider="SqlNetTiersProvider">
  < providers>
    <!--
    *** SqlClient Provider ***
    connectionStringName: sqlclient connection string to the db
    useStoredProcedure: if true indicates that we use the stored procedures, otherwise, we use parametrized queries that are embedded.
    -->
    < add 
	    name="SqlNetTiersProvider" 
	    type="Northwind.DataAccessLayer.SqlClient.SqlNetTiersProvider, Northwind.DataAccessLayer.SqlClient"
	    connectionStringName="netTiersConnectionString"
	    useStoredProcedure="false"
	    providerInvariantName="System.Data.SqlClient" />
    <!-- 
      *** WebserviceClient Provider ***
      The url parameter indicates the webservices url (ex: http://localhost/NorthWind/NorthWindServices.aspx)
    <add 
      name="WsNetTiersProvider" 
      type="Northwind.DataAccessLayer.WebServiceClient.WsNetTiersProvider, Northwind.DataAccessLayer.WebServiceClient"
      url="http://localhost/NetTiersCTPWSNorthwindServices.asmx"
      />
    -->
  < /providers>
< /netTiersService>
 </pre>

          </div>
          <div id="Documentation" style="display:none">
            Documentation Coming Soon ...
          </div>
					<div id="ReportDetails" style="display:none">
							<!-- Report Details Page -->
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
	
	<xsl:template name="navigation">
		<p><strong>Navigation</strong></p>
		<ul>
			<li><a href="http://nettiers.sourceforge.net/">Website</a></li>
			<li><a href="http://sourceforge.net/projects/nettiers/">Sourceforge&#160;Site</a></li>
			<li><a href="https://sourceforge.net/project/showfiles.php?group_id=118735">Downloads</a></li>
			<li><a href="https://sourceforge.net/tracker/?group_id=118735">Bugs</a></li>
		</ul>
		
		<p><strong>Documentation</strong></p>
		<ul>
			<li><a href="nettiers-manual.html">Manual</a></li>
			<li><a href="api/index.html">Sample Api Documentation</a></li>
			<li><a href="https://sourceforge.net/mailarchive/forum.php?forum_id=42604">Mailing&#160;List</a></li>
			<li><a href="nettiers-manual.html#faq">FAQ</a></li>
		</ul>

		<p><strong>Related Links</strong></p>
		<ul>
			<li><a href="http://www.codesmithtools.com/">CodeSmith</a></li>
			<li><a href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnbda/html/BOAGag.asp">3 tiers design</a></li>
		</ul>
	</xsl:template>
	
	<xsl:template name="copyrightinfo">
		<div align="center">
			.NetTiers&#160;2005
		</div>
	</xsl:template>
	
	<xsl:template name="sourceforgeLogo">
		<div align="center">
			<a href="http://sourceforge.net">
				<img src="http://sourceforge.net/sflogo.php?group_id=118735" width="88" height="31" border="0" alt="SourceForge Logo"/>
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

</xsl:stylesheet>