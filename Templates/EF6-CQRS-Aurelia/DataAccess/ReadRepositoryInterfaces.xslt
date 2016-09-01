<?xml version="1.0"?>

<x:stylesheet version="1.0" xmlns:x="http://www.w3.org/1999/XSL/Transform" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:fn="urn:custom-functions">
    <x:output method="text" encoding="utf-8" indent="no" version="1.0" />

    <x:include href="../Common.xslt"/>
    
    <x:param name="elementName"/>

    <x:template match="P:Project">
        <x:apply-templates select="//P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
    </x:template>

    <x:template match="P:TableMapping">
        <x:variable name="table" select="."/>
        <x:variable name="pkColumn" select=".//P:ColumnMapping[@PrimaryKey='true']"/>
        <x:variable name="childFKs" select="//P:ForeignKeyMapping[@Exclude='false' and not(.//P:Attribute[@Key='passthrough']) and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName]"/>
        <x:variable name="parentFKs" select="//P:ForeignKeyMapping[@Exclude='false' and not(.//P:Attribute[@Key='passthrough']) and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]"/>
        <x:variable name="passthroughFKs" select="//P:ForeignKeyMapping[@Exclude='false' and .//P:Attribute[@Key='passthrough'] and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]"/>

        <x:call-template name="generated-notice"/>

        <x:text>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityType = </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess'"/>
        </x:call-template>
        <x:text>.Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>;

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess.Repositories'"/>
        </x:call-template>
        <x:text> {
    public partial interface I</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>ReadRepository : IReadRepository&lt;EntityType&gt; {</x:text>

        <x:apply-templates select="$childFKs" mode="child">
            <x:with-param name="table" select="$table"/>
        </x:apply-templates>

        <x:apply-templates select="$parentFKs" mode="parent">
            <x:with-param name="table" select="$table"/>
        </x:apply-templates>

        <x:apply-templates select="$passthroughFKs" mode="passthrough">
            <x:with-param name="table" select="$table"/>
        </x:apply-templates>

        <x:apply-templates select=".//P:UniqueIndexMapping">
            <x:with-param name="table" select="$table"/>
        </x:apply-templates>
        
        <x:text>
    }
}</x:text>
    </x:template>

    <x:template match="P:ForeignKeyMapping" mode="child">
        <x:param name="table"/>
        <x:variable name="childTable" select="//P:TableMapping[@SchemaName=current()/@ReferencedTableMappingSchemaName and @TableName=current()/@ReferencedTableMappingName]"/>
        <x:variable name="childTablePK" select="$childTable//P:ColumnMapping[@ColumnName=current()/@ReferencedColumnMappingName]"/>
        <x:variable name="fieldNameLower" select="fn:FirstToLower(current()/@FieldName)"/>

        <x:text>
        /// &lt;summary&gt;Gets all </x:text>
        <x:value-of select="$table/@PluralClassName"/>
        <x:text> by </x:text>
        <x:value-of select="current()/@FieldName"/>
        <x:text>.&lt;/summary&gt;
        IEnumerable&lt;EntityType&gt; </x:text>
        <x:text>Get</x:text>
        <x:value-of select="@PluralPropertyName"/>
        <x:text>By</x:text>
        <x:value-of select="@PropertyName"/>
        <x:text>(</x:text>
        <x:value-of select="$childTablePK/@DataType"/>
        <x:text> </x:text>
        <x:value-of select="$fieldNameLower"/>
        <x:text>);</x:text>
    </x:template>

    <x:template match="P:ForeignKeyMapping" mode="parent">
        <x:param name="table"/>
        <x:variable name="parentTable" select="//P:TableMapping[@SchemaName=current()/@ParentTableMappingSchemaName and @TableName=current()/@ParentTableMappingName]"/>
        <x:variable name="parentTablePK" select="$parentTable//P:ColumnMapping[@ColumnName=current()/@ReferencedColumnMappingName]"/>
        <x:variable name="parentTablePKLower" select="fn:FirstToLower($parentTablePK/@FieldName)"/>

        <x:text>
        /// &lt;summary&gt;Gets a single </x:text>
        <x:value-of select="$table/@ClassName"/>
        <x:text> by the </x:text>
        <x:value-of select="$parentTablePK/@FieldName"/>
        <x:text> field of a related </x:text>
        <x:value-of select="$parentTable/@ClassName"/>
        <x:text>.&lt;/summary&gt;
        Task&lt;EntityType&gt; </x:text>
        <x:text>Get</x:text>
        <x:value-of select="@PropertyName"/>
        <x:text>By</x:text>
        <x:value-of select="$parentTable/@ClassName"/>
        <x:text>(</x:text>
        <x:value-of select="$parentTablePK/@DataType"/>
        <x:text> </x:text>
        <x:value-of select="$parentTablePKLower"/>
        <x:text>);</x:text>
    </x:template>

    <x:template match="P:ForeignKeyMapping" mode="passthrough">
        <x:param name="table"/>
        <x:variable name="linkingTable" select="//P:TableMapping[@SchemaName=current()/@ParentTableMappingSchemaName and @TableName=current()/@ParentTableMappingName]"/>
        <x:variable name="rightFK" select="//P:ForeignKeyMapping[@ParentTableMappingSchemaName=$linkingTable/@SchemaName and @ParentTableMappingName=$linkingTable/@TableName and @ForeignKeyName!=current()/@ForeignKeyName]"/>
        <x:variable name="rightTable" select="//P:TableMapping[@SchemaName=$rightFK/@ReferencedTableMappingSchemaName and @TableName=$rightFK/@ReferencedTableMappingName]"/>
        <x:variable name="rightTablePK" select="$rightTable//P:ColumnMapping[@ColumnName=current()/@ReferencedColumnMappingName]"/>
        <x:variable name="rightTablePKLower" select="fn:FirstToLower($rightTablePK/@FieldName)"/>

        <x:text>

        /// &lt;summary&gt;Gets a single </x:text>
        <x:value-of select="$table/@ClassName"/>
        <x:text> by the </x:text>
        <x:value-of select="$rightTablePK/@FieldName"/>
        <x:text> field of a related </x:text>
        <x:value-of select="$rightTable/@ClassName"/>
        <x:text>.&lt;/summary&gt;
        Task&lt;EntityType&gt; </x:text>
        <x:text>Get</x:text>
        <x:value-of select="$rightFK/@PluralPropertyName"/>
        <x:text>By</x:text>
        <x:value-of select="$rightFK/@PropertyName"/>
        <x:text>(</x:text>
        <x:value-of select="$rightTablePK/@DataType"/>
        <x:text> </x:text>
        <x:value-of select="$rightTablePKLower"/>
        <x:text>);</x:text>
    </x:template>

    <x:template match="P:UniqueIndexMapping">
        <x:param name="table"/>

        <x:text>

        /// &lt;summary&gt;Gets a single </x:text>
        <x:value-of select="$table/@ClassName"/>
        <x:text> by the unique field(s): </x:text>
        <x:for-each select=".//P:ColumnName">
            <x:variable name="column" select="$table//P:ColumnMapping[@ColumnName=current()/text()]"/>

            <x:value-of select="$column/@FieldName"/>

            <x:if test="position()!=last()">
                <x:text>, </x:text>
            </x:if>
        </x:for-each>
        <x:text>&lt;/summary&gt;
        Task&lt;EntityType&gt; </x:text>
        <x:text>GetBy</x:text>
        <x:for-each select=".//P:ColumnName">
            <x:value-of select="text()"/>

            <x:if test="position()!=last()">
                <x:text>And</x:text>
            </x:if>
        </x:for-each>
        <x:text>(</x:text>
        <x:for-each select=".//P:ColumnName">
            <x:variable name="column" select="$table//P:ColumnMapping[@ColumnName=current()/text()]"/>

            <x:value-of select="$column/@DataType"/>
            <x:if test="$column/@Nullable='true' and //P:DataTypeMapping[@ApplicationDataType=$column/@DataType]">
                <x:text>?</x:text>
            </x:if>
            <x:text> </x:text>
            <x:value-of select="fn:FirstToLower($column/@FieldName)"/>

            <x:if test="position()!=last()">
                <x:text>, </x:text>
            </x:if>
        </x:for-each>
        <x:text>);</x:text>
    </x:template>
</x:stylesheet>