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
<xsl:text>.Testing.UnitTestSuite.Services
{
    public partial class RESTServicesTestFixture : BaseHttpTestFixture
	{
		private readonly string[] RESTUrls =
		{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed']">
			<xsl:variable name="TableName" select="@TableName"/>
			<xsl:text>
			"</xsl:text>
			<xsl:choose>
				<xsl:when test="P:Attributes/P:Attribute[@Key=GetAllUriTemplateOverride]">
					<xsl:value-of select="P:Attributes/P:Attribute[@Key=GetAllUriTemplateOverride]/@Value"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:text>/</xsl:text>
					<xsl:value-of select="@PluralClassName"/>
					<xsl:text>/1</xsl:text>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:text>",
			"</xsl:text>
			<xsl:choose>
				<xsl:when test="P:Attributes/P:Attribute[@Key=GetAllPageCountUriTemplateOverride]">
					<xsl:value-of select="P:Attributes/P:Attribute[@Key=GetAllPageCountUriTemplateOverride]/@Value"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:text>/</xsl:text>
					<xsl:value-of select="@PluralClassName"/>
					<xsl:text>/Count</xsl:text>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:text>",
			"</xsl:text>
			<xsl:choose>
				<xsl:when test="P:Attributes/P:Attribute[@Key=GetAllPageCountUriTemplateOverride]">
					<xsl:value-of select="P:Attributes/P:Attribute[@Key=GetAllPageCountUriTemplateOverride]/@Value"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:text>/</xsl:text>
					<xsl:value-of select="@PluralClassName"/>
					<xsl:text>/PageCount</xsl:text>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:text>",
			"</xsl:text>
			<xsl:choose>
				<xsl:when test="P:Attributes/P:Attribute[@Key=GetByIDUriTemplateOverride]">
					<xsl:value-of select="P:Attributes/P:Attribute[@Key=GetByIDUriTemplateOverride]/@Value"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:text>/</xsl:text>
					<xsl:value-of select="@ClassName"/>
					<xsl:text>/1</xsl:text>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:text>",
			"</xsl:text>
			<xsl:choose>
				<xsl:when test="P:Attributes/P:Attribute[@Key=GetByIDUriTemplateOverride]">
					<xsl:value-of select="P:Attributes/P:Attribute[@Key=GetByIDUriTemplateOverride]/@Value"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:text>/</xsl:text>
					<xsl:value-of select="@PluralClassName"/>
					<xsl:text>/Filter</xsl:text>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:text>",
			"</xsl:text>
			<xsl:choose>
				<xsl:when test="P:Attributes/P:Attribute[@Key=GetByIDUriTemplateOverride]">
					<xsl:value-of select="P:Attributes/P:Attribute[@Key=GetByIDUriTemplateOverride]/@Value"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:text>/</xsl:text>
					<xsl:value-of select="@PluralClassName"/>
					<xsl:text>/Filter/Count</xsl:text>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:text>",
			"</xsl:text>
			<xsl:choose>
				<xsl:when test="P:Attributes/P:Attribute[@Key=GetByIDUriTemplateOverride]">
					<xsl:value-of select="P:Attributes/P:Attribute[@Key=GetByIDUriTemplateOverride]/@Value"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:text>/</xsl:text>
					<xsl:value-of select="@PluralClassName"/>
					<xsl:text>/Filter/PageCount</xsl:text>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:text>",</xsl:text>

			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed' and @ParentTableMappingName=$TableName]">
				<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				<xsl:text>
			"</xsl:text>
				<xsl:choose>
					<xsl:when test="P:Attributes/P:Attribute[@Key=UriTemplateOverride]">
						<xsl:value-of select="P:Attributes/P:Attribute[@Key=UriTemplateOverride]/@Value"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>/</xsl:text>
						<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
						<xsl:text>/1/</xsl:text>
						<xsl:value-of select="@PluralFieldName"/>
						<xsl:text>/1</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>",
			"</xsl:text>
				<xsl:choose>
					<xsl:when test="P:Attributes/P:Attribute[@Key=PageCountUriTemplateOverride]">
						<xsl:value-of select="P:Attributes/P:Attribute[@Key=PageCountUriTemplateOverride]/@Value"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>/</xsl:text>
						<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
						<xsl:text>/1/</xsl:text>
						<xsl:value-of select="@PluralFieldName"/>
						<xsl:text>/Count</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>",
			"</xsl:text>
				<xsl:choose>
					<xsl:when test="P:Attributes/P:Attribute[@Key=PageCountUriTemplateOverride]">
						<xsl:value-of select="P:Attributes/P:Attribute[@Key=PageCountUriTemplateOverride]/@Value"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>/</xsl:text>
						<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
						<xsl:text>/1/</xsl:text>
						<xsl:value-of select="@PluralFieldName"/>
						<xsl:text>/PageCount</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>",</xsl:text>
			</xsl:for-each>
			
			<xsl:for-each select="P:UniqueIndexMappings/P:UniqueIndexMapping[@Exclude='false']">
				<xsl:text>
			"</xsl:text>
				<xsl:choose>
					<xsl:when test="P:Attributes/P:Attribute[@Key=UriTemplateOverride]">
						<xsl:value-of select="P:Attributes/P:Attribute[@Key=UriTemplateOverride]/@Value"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>/</xsl:text>
						<xsl:value-of select="../../@ClassName"/>
						<xsl:text>?</xsl:text>
						<xsl:for-each select="P:ColumnNames/P:ColumnName">
							<xsl:variable name="columnName" select="text()"/>
							<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
							
							<xsl:value-of select="$column/@FieldName"/>
							<xsl:text>=1</xsl:text>
							<xsl:if test="position()!=last()">
								<xsl:text>&amp;</xsl:text>
							</xsl:if>
						</xsl:for-each>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>",</xsl:text>
			</xsl:for-each>
		</xsl:for-each>
		<xsl:text>
		};
	}
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>