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

        <x:call-template name="generated-notice"/>

        <x:text>
using EntityType = </x:text>
        <x:value-of select="/P:Project/@RootNamespace"/>
        <x:text>.DataAccess.Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>;

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess.Repositories'"/>
        </x:call-template>
        <x:text> {
    public partial interface I</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>Repository : IRepository&lt;EntityType&gt;, I</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>ReadRepository, I</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>WriteRepository, ILiveReadRepository&lt;EntityType&gt; {
    }
}</x:text>
    </x:template>
</x:stylesheet>