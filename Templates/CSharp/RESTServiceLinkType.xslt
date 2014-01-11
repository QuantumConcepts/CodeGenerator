<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="..\..\..\Common\Source\Generator Files\CSharp\Common.xslt"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System'"/>
		</xsl:call-template>
		
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.Service.ServiceObjects.REST
{
	<![CDATA[/// <summary>Exposes functionality through one or more service end points.</summary>]]>
	public enum LinkType
	{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed']">
			<xsl:text>
		</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>,
		</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:if test="position() != last()">
				<xsl:text>,</xsl:text>
			</xsl:if>
		</xsl:for-each>
		<xsl:text>
	}
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>