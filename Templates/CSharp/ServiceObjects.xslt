<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>

	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Collections.Generic'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Runtime.Serialization'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'QuantumConcepts.Common.Extensions'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'QuantumConcepts.Common.Utils'"/>
		</xsl:call-template>
		<xsl:call-template name="Using-Project"/>
		<xsl:call-template name="Using-Template">
			<xsl:with-param name="template" select="P:Templates/P:Template[@Name=$templateName]"/>
		</xsl:call-template>
		
		<xsl:text>
namespace  </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.Service.ServiceObjects
{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:variable name="tableName" select="@TableName"/>
			<xsl:variable name="className" select="@ClassName"/>
			<xsl:variable name="pluralClassName" select="@PluralClassName"/>
			<xsl:call-template name="GetTableMappingDocumentation">
				<xsl:with-param name="spacingBefore" select="$tab"/>
			</xsl:call-template>
			<xsl:text>
	[DataContract]
	public partial class </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> : DataObjects.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>
	{</xsl:text>
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName=$tableName]">
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:if test="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableMappingName]/@Exclude='false' and ../../P:TableMappings/P:TableMapping[@TableName=$parentTableMappingName]/@Exclude='false'">
					<xsl:text>
		[DataMember]
		public string </xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text> { get; private set; }
</xsl:text>
				</xsl:if>
			</xsl:for-each>
			
			<xsl:text>
		public static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> FromDataAccessObject(DataAccess.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> obj)
		{
			if (obj == null)
				return null;

            return new </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>()
            {</xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
				<xsl:text>
				</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> = obj.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:if test="position()!=last()">
					<xsl:text>, </xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName=$tableName]">
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:if test="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableMappingName]/@Exclude='false' and ../../P:TableMappings/P:TableMapping[@TableName=$parentTableMappingName]/@Exclude='false'">
					<xsl:text>,
				</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text> = obj.</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>.ValueOrDefault(o =&gt; o.ToString())</xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:text>
            };
		}
	}
</xsl:text>
		</xsl:for-each>
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>