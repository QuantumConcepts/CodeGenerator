<?xml version="1.0"?>

<x:stylesheet version="1.0" xmlns:x="http://www.w3.org/1999/XSL/Transform" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd">
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

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess.Entities'"/>
        </x:call-template>
        <x:text> {
    public partial class </x:text>
        <x:value-of select="@ClassName"/>
        <x:text> : IEntity {</x:text>

        <x:apply-templates select=".//P:ColumnMapping[@Exclude='false']"/>

        <x:call-template name="new-line"/>

        <x:apply-templates mode="child" select="$childFKs"/>
        <x:apply-templates mode="parent" select="$parentFKs"/>
        <x:apply-templates mode="passthrough" select="$passthroughFKs"/>
        
        <x:text>
    }
}</x:text>
    </x:template>

    <x:template match="P:ColumnMapping">
        <x:text>
        public </x:text>
        <x:value-of select="@DataType"/>
        <x:if test="@Nullable='true'">
            <x:text>?</x:text>
        </x:if>
        <x:text> </x:text>
        <x:value-of select="@FieldName"/>
        <x:text> { get; set; }</x:text>
    </x:template>

    <x:template match="P:ForeignKeyMapping" mode="child">
        <x:variable name="childTable" select="//P:TableMapping[@SchemaName=current()/@ReferencedTableMappingSchemaName and @TableName=current()/@ReferencedTableMappingName]"/>

        <x:text>
        public virtual </x:text>
        <x:value-of select="$childTable/@ClassName"/>
        <x:text> </x:text>
        <x:value-of select="@PropertyName"/>
        <x:text> { get; set; }</x:text>
    </x:template>

    <x:template match="P:ForeignKeyMapping" mode="parent">
        <x:variable name="parentTable" select="//P:TableMapping[@SchemaName=current()/@ParentTableMappingSchemaName and @TableName=current()/@ParentTableMappingName]"/>

        <x:text>
        public virtual IList&lt;</x:text>
        <x:value-of select="$parentTable/@ClassName"/>
        <x:text>&gt; </x:text>
        <x:value-of select="@PluralPropertyName"/>
        <x:text> { get; set; } = new List&lt;</x:text>
        <x:value-of select="$parentTable/@ClassName"/>
        <x:text>&gt;();</x:text>
    </x:template>

    <x:template match="P:ForeignKeyMapping" mode="passthrough">
        <x:variable name="linkingTable" select="//P:TableMapping[@SchemaName=current()/@ParentTableMappingSchemaName and @TableName=current()/@ParentTableMappingName]"/>
        <x:variable name="rightFK" select="//P:ForeignKeyMapping[@ParentTableMappingSchemaName=$linkingTable/@SchemaName and @ParentTableMappingName=$linkingTable/@TableName and @ForeignKeyName!=current()/@ForeignKeyName]"/>
        <x:variable name="rightTable" select="//P:TableMapping[@SchemaName=$rightFK/@ReferencedTableMappingSchemaName and @TableName=$rightFK/@ReferencedTableMappingName]"/>

        <x:text>
        public virtual IList&lt;</x:text>
        <x:value-of select="$rightTable/@ClassName"/>
        <x:text>&gt; </x:text>
        <x:value-of select="@PluralPropertyName"/>
        <x:text> { get; set; } = new List&lt;</x:text>
        <x:value-of select="$rightTable/@ClassName"/>
        <x:text>&gt;();</x:text>
    </x:template>
</x:stylesheet>