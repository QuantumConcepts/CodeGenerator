<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>

	<xsl:include href="Common.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Data.Linq'"/>
		</xsl:call-template>
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
<xsl:text>.DataObjects
{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:variable name="currentTableName" select="@TableName"/>
			<xsl:variable name="currentClassName" select="@ClassName"/>
			<xsl:variable name="currentPluralClassName" select="@PluralClassName"/>
			<xsl:call-template name="GetTableMappingDocumentation">
				<xsl:with-param name="spacingBefore" select="$tab"/>
			</xsl:call-template>
			<xsl:text>
	[DataContract]
	public partial class </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> : IDataObject
	{</xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
				<xsl:variable name="dataType" select="@DataType"/>
				<xsl:call-template name="GetColumnMappingDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
		protected </xsl:text>
				<xsl:choose>
					<xsl:when test="P:EnumerationMapping">
						<xsl:value-of select="P:EnumerationMapping/@Name"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@DataType"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:if test="@Nullable='true' and (P:EnumerationMapping or ../../../../P:DataTypeMappings/P:DataTypeMapping[@ApplicationDataType=$dataType]/@Nullable='true')">
					<xsl:text>?</xsl:text>
				</xsl:if>
				<xsl:text> _</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>;
			</xsl:text>
			</xsl:for-each>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
				<xsl:variable name="dataType" select="@DataType"/>
				<xsl:text>
		<![CDATA[/// <summary>The ]]></xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> Property maps to the </xsl:text>
				<xsl:value-of select="@ColumnName"/>
				<xsl:text><![CDATA[ column in the database.</summary>]]>
		[DataMember]
		public </xsl:text>
				<xsl:choose>
					<xsl:when test="P:EnumerationMapping">
						<xsl:value-of select="P:EnumerationMapping/@Name"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@DataType"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:if test="@Nullable='true' and (P:EnumerationMapping or ../../../../P:DataTypeMappings/P:DataTypeMapping[@ApplicationDataType=$dataType]/@Nullable='true')">
					<xsl:text>?</xsl:text>
				</xsl:if>
				<xsl:text> </xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> { get { return _</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>; } set { _</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> = value</xsl:text>
				<xsl:text>; } }</xsl:text>
				<xsl:if test="position()!=last()">
					<xsl:value-of select="$newLine"/>
				</xsl:if>
			</xsl:for-each>
			<xsl:text>
	}</xsl:text>
			<xsl:if test="position()!=last()">
				<xsl:value-of select="$newLine"/>
			</xsl:if>
		</xsl:for-each>
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>