<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="../XSLTCommon.xslt"/>
    
	<xsl:param name="templateName"/>
	<xsl:param name="elementName" select="'Author'"/>
    
	<xsl:template match="P:Project">
		<xsl:param name="table" select="P:TableMappings/P:TableMapping[@TableName=$elementName]"/>
		
		<xsl:text>package supertrition.soap.client.objects;

import java.util.Date;

import org.ksoap2.serialization.SoapObject;

import supertrition.soap.client.ResponseUtil;
import supertrition.soap.client.SoapException;

public class </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Factory extends BaseSoapObjectFactory&lt;</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>&gt;
{
	public static </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> parse(SoapObject soapObject) throws SoapException
	{
		</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> instance = new </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>();
		</xsl:text>
		<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
			<xsl:text>
		instance.set</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>(</xsl:text>
			<xsl:call-template name="GetJavaSOAPConverter">
				<xsl:with-param name="column" select="."/>
			</xsl:call-template>
			<xsl:text>);</xsl:text>
		</xsl:for-each>
		<xsl:text>
		
		return instance;
	}
}</xsl:text>
	</xsl:template>
	
	<xsl:template name="GetJavaSOAPConverter">
		<xsl:param name="column"/>
		
		<xsl:text>ResponseUtil.</xsl:text>
		
		<xsl:choose>
			<xsl:when test="$column/@DataType='string'">
				<xsl:text>getStringProperty</xsl:text>
			</xsl:when>
			<xsl:when test="$column/@DataType='int'">
				<xsl:text>getIntegerProperty</xsl:text>
			</xsl:when>
			<xsl:when test="$column/@DataType='decimal'">
				<xsl:text>getDoubleProperty</xsl:text>
			</xsl:when>
			<xsl:when test="$column/@DataType='bool'">
				<xsl:text>getBooleanProperty</xsl:text>
			</xsl:when>
			<xsl:when test="$column/@DataType='DateTime'">
				<xsl:text>getDateProperty</xsl:text>
			</xsl:when>
			<xsl:when test="$column/@DataType='string'">
				<xsl:text>getStringProperty</xsl:text>
			</xsl:when>
			<xsl:when test="$column/@DataType='byte[]'">
				<xsl:text>getByteArrayProperty</xsl:text>
			</xsl:when>
		</xsl:choose>
		
		<xsl:text>(soapObject, "</xsl:text>
		<xsl:value-of select="$column/@FieldName"/>
		<xsl:text>")</xsl:text>
	</xsl:template>
</xsl:stylesheet>