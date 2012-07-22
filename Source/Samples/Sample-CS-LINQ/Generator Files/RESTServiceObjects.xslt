<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Collections.Generic'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Runtime.Serialization'"/>
		</xsl:call-template>
		<xsl:call-template name="Using-Project"/>
		<xsl:call-template name="Using-Template">
			<xsl:with-param name="template" select="P:Templates/P:Template[@Name=$templateName]"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.Service.Utils</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		
		<xsl:text>
namespace  </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.Service.ServiceObjects.REST
{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:variable name="TableName" select="@TableName"/>
			<xsl:call-template name="GetTableMappingDocumentation">
				<xsl:with-param name="spacingBefore" select="$tab"/>
			</xsl:call-template>
			<xsl:text>
	[DataContract]
	public partial class </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> : ServiceObjects.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>
	{
		[DataMember]
		public List&lt;Link&gt; Links { get; set;}
	
		public </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>()
		{
			this.Links = new List&lt;Link&gt;();
		}
		
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
			</xsl:text>
			
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed' and @ParentTableMappingName=$TableName]">
				<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				<xsl:variable name="referencedTable" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]"/>
				<xsl:variable name="referencedColumn" select="$referencedTable/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]"/>
				<xsl:variable name="parentTable" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]"/>
				<xsl:variable name="parentColumn" select="$parentTable/P:ColumnMappings/P:ColumnMapping[@ColumnName=$parentColumnName]"/>
				<xsl:choose>
					<xsl:when test="$parentColumn/@Nullable='true'">
						<xsl:text>
			
			if (newObj.</xsl:text>
						<xsl:value-of select="$parentColumn/@FieldName"/>
						<xsl:text>.HasValue)
				</xsl:text>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>
			</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>newObj.Links.Add(new Link("</xsl:text>
				<xsl:value-of select="@PropertyName"/>
				<xsl:text>", LinkType.</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>, RESTUrlUtil.Service.RESTSvc.Get</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>ByID(newObj.</xsl:text>
				<xsl:value-of select="$parentColumn/@FieldName"/>
				<xsl:if test="$parentColumn/@Nullable='true'">
					<xsl:text>.Value</xsl:text>
				</xsl:if>
				<xsl:text>)));</xsl:text>
			</xsl:for-each>
			
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed' and @ReferencedTableMappingName=$TableName]">
				<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				<xsl:variable name="referencedTable" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]"/>
				<xsl:variable name="referencedColumn" select="$referencedTable/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]"/>
				<xsl:variable name="parentTable" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]"/>
				<xsl:variable name="parentColumn" select="$parentTable/P:ColumnMappings/P:ColumnMapping[@ColumnName=$parentColumnName]"/>
				<xsl:text>
			newObj.Links.Add(new Link("</xsl:text>
				<xsl:value-of select="@PluralPropertyName"/>
				<xsl:text>", LinkType.</xsl:text>
				<xsl:value-of select="$parentTable/@PluralClassName"/>
				<xsl:text>, RESTUrlUtil.Service.RESTSvc.Get</xsl:text>
				<xsl:value-of select="$parentTable/@PluralClassName"/>
				<xsl:text>By</xsl:text>
				<xsl:value-of select="$parentColumn/@FieldName"/>
				<xsl:text>(newObj.</xsl:text>
				<xsl:value-of select="$referencedColumn/@FieldName"/>
				<xsl:text>, 1)));</xsl:text>
			</xsl:for-each>
			
			<xsl:text>
			
			return newObj;
		}
	}
</xsl:text>
		</xsl:for-each>
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>