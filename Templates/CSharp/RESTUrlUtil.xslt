<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>

    <xsl:include href="ServiceDocumentation-Common.xslt"/>

    <xsl:param name="templateName"/>

    <xsl:template match="P:Project">
        <xsl:call-template name="Using-System-All"/>
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
		
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.Service.Utils
{
	public partial class RESTUrlUtil : UrlUtil
	{
        public static partial class Service
        {
            public static partial class RESTSvc
            {</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed']">
			<xsl:variable name="TableName" select="@TableName"/>
            <xsl:variable name="PKColumn" select=".//P:ColumnMapping[@PrimaryKey='true']"/>

            <xsl:text>
				public static ResourceUrl Get</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>(int page) { return new ResourceUrl(RESTSvc.Url, "</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>/{0}".FormatString(page)); }
				public static ResourceUrl Get</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>Count() { return new ResourceUrl(RESTSvc.Url, "</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>/Count"); }
				public static ResourceUrl Get</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>PageCount() { return new ResourceUrl(RESTSvc.Url, "</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>/PageCount"); }
				public static ResourceUrl Get</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>ByID(int id) { return new ResourceUrl(RESTSvc.Url, "</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>/{0}".FormatString(id)); }</xsl:text>
			
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed' and @ParentTableMappingName=$TableName]">
                <xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
                <xsl:variable name="parentTable" select="//P:TableMapping[@TableName=$parentTableName]"/>
                <xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
                <xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
                <xsl:variable name="referencedTable" select="//P:TableMapping[@TableName=$referencedTableName]"/>
                <xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				<xsl:text>
				public static ResourceUrl Get</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
				<xsl:text>By</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(int </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>, int page) { return new ResourceUrl(RESTSvc.Url, "</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				<xsl:text>/{0}/</xsl:text>
				<xsl:value-of select="@PluralFieldName"/>
				<xsl:text>/{1}".FormatString(</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>, page)); }
				public static ResourceUrl Get</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
				<xsl:text>By</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Count(int </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>) { return new ResourceUrl(RESTSvc.Url, "</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				<xsl:text>/{0}/</xsl:text>
				<xsl:value-of select="@PluralFieldName"/>
				<xsl:text>/Count".FormatString(</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>)); }
				public static ResourceUrl Get</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
				<xsl:text>By</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>PageCount(int </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>) { return new ResourceUrl(RESTSvc.Url, "</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				<xsl:text>/{0}/</xsl:text>
				<xsl:value-of select="@PluralFieldName"/>
				<xsl:text>/PageCount".FormatString(</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>)); }
                public static ResourceUrl </xsl:text>
                <xsl:call-template name="Doc-FKSingular-SOAPMethod"/>
                <xsl:text>(</xsl:text>
                <xsl:value-of select="$PKColumn/@DataType"/>
                <xsl:text> </xsl:text>
                <xsl:call-template name="FirstCharacterToLowerCase">
                    <xsl:with-param name="input" select="$parentTable/@ClassName"/>
                </xsl:call-template>
                <xsl:value-of select="$PKColumn/@FieldName"/>
                <xsl:text>) { return new ResourceUrl(RESTSvc.Url, "</xsl:text>
                <xsl:value-of select="$parentTable/@ClassName"/>
                <xsl:text>/{0}/</xsl:text>
                <xsl:value-of select="@PropertyName"/>
                <xsl:text>".FormatString(</xsl:text>
                <xsl:call-template name="FirstCharacterToLowerCase">
                    <xsl:with-param name="input" select="$parentTable/@ClassName"/>
                </xsl:call-template>
                <xsl:value-of select="$PKColumn/@FieldName"/>
                <xsl:text>)); }</xsl:text>
            </xsl:for-each>
			
			<xsl:for-each select="P:UniqueIndexMappings/P:UniqueIndexMapping[@Exclude='false']">
				<xsl:text>
				public static ResourceUrl Get</xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text>By</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
					
					<xsl:value-of select="$column/@FieldName"/>
					<xsl:if test="position()!=last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
					
					<xsl:choose>
						<xsl:when test="$column/P:EnumerationMapping">
							<xsl:text>DO.</xsl:text>
							<xsl:value-of select="$column/P:EnumerationMapping/@Name"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="$column/@DataType"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text> </xsl:text>
					<xsl:call-template name="FirstCharacterToLowerCase">
						<xsl:with-param name="input" select="$column/@FieldName"/>
					</xsl:call-template>
					
					<xsl:if test="position()!=last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>) { return new ResourceUrl(RESTSvc.Url, "/</xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text>?</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
					
					<xsl:value-of select="$column/@FieldName"/>
					<xsl:text>={</xsl:text>
					<xsl:call-template name="FirstCharacterToLowerCase">
						<xsl:with-param name="input" select="$column/@FieldName"/>
					</xsl:call-template>
					<xsl:text>}</xsl:text>
					<xsl:if test="position()!=last()">
						<xsl:text>&amp;</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>".FormatString(</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
					
					<xsl:call-template name="FirstCharacterToLowerCase">
						<xsl:with-param name="input" select="$column/@FieldName"/>
					</xsl:call-template>
					
					<xsl:if test="position()!=last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>)); }</xsl:text>
			</xsl:for-each>
		</xsl:for-each>
		<xsl:text>
			}
		}
	}
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>