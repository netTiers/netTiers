<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" 
				xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:sc="http://serialcoder.net"
                extension-element-prefixes="msxsl sc"
                xml:space="preserve"
				>

	<xsl:output method="text"/>
	
	<xsl:template match="/">
		--Setup the cursor ( YOU NEED TO RUN THE FOLLOWING SQL FIRST BEFORE EXECUTING SP'S!!!!!!!!).
		
		--create or replace package types 
		--as 
		--	type cursorType is ref cursor; 
		--end; 
		
		<xsl:apply-templates select="//procedures/procedure[not(@skip)]"/>
	</xsl:template>
	
	<xsl:template match="procedure">
	<xsl:value-of select="comment"/>
	CREATE OR REPLACE PROCEDURE <xsl:value-of select="@owner"/>.<xsl:value-of select="@name"/>
	
	<xsl:if test="count(parameters/parameter)!=0">(
		<xsl:apply-templates select="parameters/parameter"/>)
	</xsl:if>
	
	<xsl:value-of select="body" disable-output-escaping="yes"/>
	END;
	
	GO
	</xsl:template>
	
	<xsl:template match="parameter">
		<xsl:value-of select="@name"/><xsl:if test="@direction = 'Input'"> IN</xsl:if><xsl:if test="@direction = 'Output'"> OUT</xsl:if><xsl:if test="@direction = 'InputOutput'"> IN OUT</xsl:if> <xsl:value-of select="@type"/> <xsl:value-of select="@param"/> <xsl:if test="@nulldefault = 'null'"> = null</xsl:if><xsl:if test="last()!=position()">,</xsl:if>
	</xsl:template>

</xsl:stylesheet>
