<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	<xsl:strip-space elements="*"/>
	
	<xsl:include href="Common.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System" />
		<xsl:call-template name="Using-Project"/>
		<xsl:call-template name="Using-Template">
			<xsl:with-param name="template" select="P:Templates/P:Template[@Name=$templateName]"/>
		</xsl:call-template>
		
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
		<xsl:text>.DataObjects</xsl:text>
		<xsl:text>
{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping/P:ColumnMappings/P:ColumnMapping/P:EnumerationMapping[@IsReference='false']">
			<xsl:call-template name="GetEnumerationMappingDocumentation">
				<xsl:with-param name="spacingBefore" select="$tab"/>
			</xsl:call-template>
			
			<xsl:text>
	public enum </xsl:text>
			<xsl:value-of select="@Name"/>
			<xsl:text>
	{</xsl:text>
			<xsl:for-each select="P:Values/P:EnumerationValueMapping">
				<xsl:text>
		/// &lt;summary&gt;</xsl:text>
				<xsl:value-of select="@Name"/>
				<xsl:text>: </xsl:text>
				<xsl:value-of select="P:Description/text()"/>
				<xsl:text>. (Database Value: </xsl:text>
				<xsl:value-of select="@DatabaseValue"/>
				<xsl:text>)&lt;/summary&gt;
		[Description("</xsl:text>
				<xsl:value-of select="P:Description/text()"/>
				<xsl:text>")]
		</xsl:text>
				<xsl:value-of select="@Name"/>
				<xsl:if test="position() != last()">
					<xsl:text>,
		</xsl:text>
				</xsl:if>
		</xsl:for-each>
	}<xsl:if test="position() != last()">
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$newLine"/>
	</xsl:if>
	</xsl:for-each>
}</xsl:template>
</xsl:stylesheet>