<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Runtime.Serialization'"/>
		</xsl:call-template>
		<xsl:call-template name="Using-Project"/>
		<xsl:call-template name="Using-Template">
			<xsl:with-param name="template" select="P:Templates/P:Template[@Name=$templateName]"/>
		</xsl:call-template>
		
		<xsl:text>
namespace  </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.Service.ServiceObjects.SOAP
{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:text>
	[DataContract]
	public partial class </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> : ServiceObjects.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>
	{</xsl:text>
			<xsl:text>
		public static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> FromDataAccessObject(DataAccess.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> obj)
		{
			if (obj == null)
				return null;

            </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> newObj = new </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>();
			ServiceObjects.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.Copy(obj, newObj);
			
			return newObj;
		}
	}
</xsl:text>
		</xsl:for-each>
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>