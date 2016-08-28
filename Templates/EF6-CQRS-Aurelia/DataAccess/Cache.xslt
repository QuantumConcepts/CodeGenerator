<?xml version="1.0" encoding="utf-8"?>

<x:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:x="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:fn="urn:custom-functions" exclude-result-prefixes="x">
    <x:output method="text" version="1.0" encoding="UTF-8" indent="no"/>

    <x:include href="../packages/CodeGenerator.Templates.EF6-CQRS-Aurelia.1.0.9/Common.xslt"/>

    <x:param name="elementName"/>

    <x:template match="P:Project">
        <x:apply-templates select="//P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
    </x:template>

    <x:template match="P:TableMapping">
        <x:variable name="table" select="."/>
        <x:variable name="pkColumn" select=".//P:ColumnMapping[@PrimaryKey='true']"/>

        <x:call-template name="generated-notice"/>

        <x:text>
using System;
using System.Collections.Generic;
using System.Linq;
using </x:text>
        <x:value-of select="/P:Project/@RootNamespace"/>
        <x:text>.DataAccess.Repositories;
using EntityType = </x:text>
        <x:value-of select="/P:Project/@RootNamespace"/>
        <x:text>.DataAccess.Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>;

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess.Cache'"/>
        </x:call-template>
        <x:text> {
    /// &lt;summary&gt;A cached repository for the </x:text>
        <x:value-of select="@ClassName"/>
        <x:text> class.&lt;/summary&gt;
    public partial class </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>Cache : BaseCache&lt;EntityType&gt; {
        public </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>Cache(IRepository&lt;EntityType&gt; repo) : base(repo) { }</x:text>
        
        <x:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ConnectionName=$table/@ConnectionName and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName]">
            <x:variable name="foreignKey" select="."/>
            <x:variable name="parentTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ParentTableMappingSchemaName and @TableName=$foreignKey/@ParentTableMappingName]"/>
            <x:variable name="referencedTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ReferencedTableMappingSchemaName and @TableName=$foreignKey/@ReferencedTableMappingName]"/>
            <x:variable name="parentTableName" select="@ParentTableMappingName"/>
            <x:variable name="parentColumnName" select="@ParentColumnMappingName"/>
            <x:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
            <x:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
            
            <x:text>

        public IEnumerable&lt;EntityType&gt; GetBy</x:text>
            <x:value-of select="@FieldName"/>
            <x:text>(</x:text>
            <x:value-of select="$referencedTableMapping/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
            <x:text> </x:text>
            <x:value-of select="fn:FirstToLower($referencedColumnName)"/>
            <x:text>) {
            return Search(o =&gt; object.Equals(o.</x:text>
            <x:value-of select="@FieldName"/>
            <x:text>, </x:text>
            <x:value-of select="fn:FirstToLower($referencedColumnName)"/>
            <x:text>));
        }</x:text>
        </x:for-each>

        <x:for-each select="P:UniqueIndexMappings/P:UniqueIndexMapping[@Exclude='false']">
            <x:text>

        <![CDATA[/// <summary>Gets the ]]></x:text>
            <x:value-of select="../../@ClassName"/>
            <x:text><![CDATA[ matching the unique index using the passed-in values.</summary>]]>
        public EntityType GetBy</x:text>
            <x:for-each select="P:ColumnNames/P:ColumnName">
                <x:variable name="columnName" select="text()"/>
                <x:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>

                <x:value-of select="$column/@FieldName"/>
                <x:if test="position()!=last()">
                    <x:text>And</x:text>
                </x:if>
            </x:for-each>
            <x:text>(</x:text>
            <x:for-each select="P:ColumnNames/P:ColumnName">
                <x:variable name="columnName" select="text()"/>
                <x:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>

                <x:choose>
                    <x:when test="$column/P:EnumerationMapping">
                        <x:text>DO.</x:text>
                        <x:value-of select="$column/P:EnumerationMapping/@Name"/>
                    </x:when>
                    <x:otherwise>
                        <x:value-of select="$column/@DataType"/>
                    </x:otherwise>
                </x:choose>
                <x:if test="$column/@Nullable='true'">
                    <x:text>?</x:text>
                </x:if>
                <x:text> </x:text>
                <x:value-of select="fn:FirstToLower($column/@FieldName)"/>

                <x:if test="position()!=last()">
                    <x:text>, </x:text>
                </x:if>
            </x:for-each>
            <x:text>) {
            return Search(o =&gt; </x:text>
            <x:for-each select="P:ColumnNames/P:ColumnName">
                <x:variable name="columnName" select="text()"/>
                <x:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
                
                <x:text>object.Equals(o.</x:text>
                <x:value-of select="$column/@FieldName"/>
                <x:text>, </x:text>
                <x:value-of select="fn:FirstToLower($column/@FieldName)"/>
                <x:text>)</x:text>

                <x:if test="position()!=last()">
                    <x:text> &amp;&amp; </x:text>
                </x:if>
            </x:for-each>
            <x:text>).SingleOrDefault();
        }</x:text>
        </x:for-each>

        <x:text>
    }
}
</x:text>
    </x:template>
</x:stylesheet>