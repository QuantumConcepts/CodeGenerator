<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="../XSLTCommon.xslt"/>
    
	<xsl:param name="templateName"/>
	<xsl:param name="elementName" select="'Manufacturer'"/>
    
	<xsl:template match="P:Project">
		<xsl:param name="table" select="P:TableMappings/P:TableMapping[@TableName=$elementName]"/>
		
		<xsl:text>package supertrition.soap.client.objects;

import java.util.Date;

public class </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> extends BaseSoapObject
{</xsl:text>
		<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
			<xsl:text>
	private </xsl:text>
			<xsl:call-template name="GetJavaDataType">
				<xsl:with-param name="column" select="."/>
			</xsl:call-template>
			<xsl:text> _</xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="@FieldName"/>
			</xsl:call-template>
			<xsl:text>;</xsl:text>
		</xsl:for-each>
        
		<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false']">    
			<xsl:text>
	
	public </xsl:text>
			<xsl:call-template name="GetJavaDataType">
				<xsl:with-param name="column" select="."/>
			</xsl:call-template>
			<xsl:text> get</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>()
	{
		return this._</xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="@FieldName"/>
			</xsl:call-template>
			<xsl:text>;
	}
	
	public void set</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>(</xsl:text>
			<xsl:call-template name="GetJavaDataType">
				<xsl:with-param name="column" select="."/>
			</xsl:call-template>
			<xsl:text> value)
	{
		this._</xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="@FieldName"/>
			</xsl:call-template>
			<xsl:text> = value;
	}</xsl:text>
		</xsl:for-each>
		
		<xsl:if test="$table/P:Attributes/P:Attribute[@Key='ToString_Java']">
			<xsl:text>

	public String toString()
	{
		return </xsl:text>
			<xsl:value-of select="$table/P:Attributes/P:Attribute[@Key='ToString_Java']/@Value"/>
			<xsl:text>;
	}</xsl:text>
		</xsl:if>
		<xsl:text>
}</xsl:text>
	</xsl:template>
	
	<xsl:template name="GetJavaDataType">
		<xsl:param name="column"/>
		
		<xsl:choose>
			<xsl:when test="$column/@DataType='string'">
				<xsl:text>String</xsl:text>
			</xsl:when>
			<xsl:when test="$column/@DataType='decimal'">
				<xsl:text>double</xsl:text>
			</xsl:when>
			<xsl:when test="$column/@DataType='bool'">
				<xsl:text>Boolean</xsl:text>
			</xsl:when>
			<xsl:when test="$column/@DataType='DateTime'">
				<xsl:text>Date</xsl:text>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$column/@DataType"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
</xsl:stylesheet>