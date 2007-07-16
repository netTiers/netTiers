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
Use [<xsl:value-of select="/root/database"/>]
Go
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
<xsl:apply-templates select="//procedures/procedure[not(@skip)]"/>
</xsl:template>

<xsl:template match="procedure">
	
<xsl:if test="/root/database[@includeDrop='true']">
-- Drop the <xsl:value-of select="@owner"/>.<xsl:value-of select="@name"/> procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'<xsl:value-of select="@owner"/>.<xsl:value-of select="@name"/>') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE <xsl:value-of select="@owner"/>.<xsl:value-of select="@name"/>
GO
</xsl:if>
<xsl:value-of select="comment"/>

CREATE PROCEDURE <xsl:value-of select="@owner"/>.<xsl:value-of select="@name"/>
<xsl:if test="count(parameters/parameter)!=0">(
<xsl:apply-templates select="parameters/parameter"/>)</xsl:if>
AS

<xsl:value-of select="body" disable-output-escaping="yes"/>
<xsl:if test="@grant and string-length(@grant) &gt; 0">
GO
GRANT EXEC ON <xsl:value-of select="@owner"/>.<xsl:value-of select="@name"/> TO <xsl:value-of select="@grant"/>
</xsl:if>
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
</xsl:template>

<xsl:template match="parameter">
	<xsl:value-of select="@name"/> <xsl:value-of select="@type"/> <xsl:value-of select="@param"/> <xsl:if test="@nulldefault = 'null'"> = null</xsl:if> <xsl:if test="@direction = 'InputOutput' or @direction = 'Output'"> OUTPUT</xsl:if><xsl:if test="last()!=position()">,</xsl:if>
</xsl:template>

<msxsl:script implements-prefix="sc" language="Javascript">
<![CDATA[
function align(ctx,length){

	var str = '         ' + ctx;
	str = str.substr(str.length - length);
	return str;
	
}

function crlf()
{
	return "\r\n";
}

function spaces(nb) {
	var str = '';
	for(var i=0; i<nb;i++) {
		str += ' ';
	}
	return str;
}

function FillRightSpace(ctx, width)
{
	var str = spaces(width);
	str = ctx + str;
	
	return str.substr(0,width);
}

function DropCR(ctx)
{
	var str = '' + ctx;
	str = str.Replace("\r","");
	return str;
}

]]>
</msxsl:script>

</xsl:stylesheet>