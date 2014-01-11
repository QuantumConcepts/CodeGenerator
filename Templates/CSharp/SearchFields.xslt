<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="..\..\..\Common\Source\Generator Files\CSharp\Common.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System'"/>
		</xsl:call-template>
		<xsl:call-template name="Using-Project"/>
		<xsl:call-template name="Using-Template">
			<xsl:with-param name="template" select="P:Templates/P:Template[@Name=$templateName]"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:text>DO = </xsl:text>
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.DataObjects</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.DataAccess</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		
		<xsl:text>
namespace  </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.Logic.Search
{
	///&lt;summary&gt;This class handles the registration for all of the Search Fields.&lt;/summary&gt;
	public static class SearchFieldRegistrar
	{
		///&lt;summary&gt;Touches each Search Field class in order to cause it to register its SearchFields.&lt;/summary&gt;
		public static void Initialize()
		{</xsl:text>
		
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:text>
			</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>SearchFields.Initialize();</xsl:text>
		</xsl:for-each>
		
		<xsl:text>
		}
	}</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:variable name="currentClassName" select="@ClassName"/>
			
			<xsl:text>
	
	///&lt;summary&gt;Exposes SearchFields which allow complex searches to be performed on </xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>.&lt;/summary&gt;
	public static class </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>SearchFields
	{</xsl:text>
	
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
				<xsl:variable name="dataType">
					<xsl:variable name="baseDataType" select="@DataType"/>
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:text>DO.</xsl:text>
							<xsl:value-of select="P:EnumerationMapping/@Name"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@DataType"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:if test="@Nullable='true' and (P:EnumerationMapping or ../../../../P:DataTypeMappings/P:DataTypeMapping[@ApplicationDataType=$baseDataType]/@Nullable='true')">
						<xsl:text>?</xsl:text>
					</xsl:if>
				</xsl:variable>
				
				<xsl:call-template name="GetColumnMappingDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
		public static LinqSearchField&lt;</xsl:text>
			<xsl:value-of select="$currentClassName"/>
			<xsl:text>, </xsl:text>
			<xsl:value-of select="$dataType"/>
			<xsl:text>&gt; </xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text> { get; private set; }
		</xsl:text>
        		</xsl:for-each>

			<xsl:text>
		///&lt;summary&gt;This method initializes the static members (search fields) of this class.&lt;/summary&gt;
		public static void Initialize()
		{</xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
				<xsl:variable name="dataType">
					<xsl:variable name="baseDataType" select="@DataType"/>
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:text>DO.</xsl:text>
							<xsl:value-of select="P:EnumerationMapping/@Name"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@DataType"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:if test="@Nullable='true' and (P:EnumerationMapping or ../../../../P:DataTypeMappings/P:DataTypeMapping[@ApplicationDataType=$baseDataType]/@Nullable='true')">
						<xsl:text>?</xsl:text>
					</xsl:if>
				</xsl:variable>
				
				<xsl:text>
			</xsl:text>
				<xsl:value-of select="$currentClassName"/>
				<xsl:text>SearchFields.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> = LinqSearchField&lt;</xsl:text>
				<xsl:value-of select="$currentClassName"/>
				<xsl:text>, </xsl:text>
				<xsl:value-of select="$dataType"/>
				<xsl:text>&gt;.Create(o => o.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>);</xsl:text>
			</xsl:for-each>
		<xsl:text>
		}
	}</xsl:text>
    		</xsl:for-each>
        	
        	<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>