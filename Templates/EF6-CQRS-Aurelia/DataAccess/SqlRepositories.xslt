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
using </x:text>
        <x:value-of select="/P:Project/@RootNamespace"/>
        <x:text>.DataAccess.Entities;
using System;

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess.Repositories'"/>
        </x:call-template>
        <x:text> {
    public partial class </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>Repository : BaseSqlRepository&lt;</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt; {
        public </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>Repository(Func&lt;DataContext&gt; contextFactory) : base(contextFactory) { }
    }
}</x:text>
    </x:template>
</x:stylesheet>