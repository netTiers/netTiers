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
USE [<xsl:value-of select="/root/database"/>]
GO
<xsl:apply-templates select="//views/view[not(@skip)]"/>
</xsl:template>

<xsl:template match="view">
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS <xsl:value-of select="/root/database/@setAnsiNulls"/>
GO

<xsl:value-of select="comment"/>

ALTER VIEW [<xsl:value-of select="@owner"/>].[<xsl:value-of select="@name"/>]
AS

<xsl:value-of select="body" disable-output-escaping="yes"/>

GO

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