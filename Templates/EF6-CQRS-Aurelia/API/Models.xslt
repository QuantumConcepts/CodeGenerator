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

        <x:call-template name="generated-notice"/>
        
        <x:text>
using System;
using System.Collections.Generic;

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Api.Common.Models'"/>
        </x:call-template>
        <x:text> {
    public partial class </x:text>
        <x:value-of select="@ClassName"/>
        <x:text> : IModel {</x:text>

        <x:apply-templates select=".//P:ColumnMapping[@Exclude='false' and not(.//P:Attribute[@Key='ExcludeFromAPI'])]"/>

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
</x:stylesheet>