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
import {IModel} from "./IModel";

export class </x:text>
        <x:value-of select="@ClassName"/>
        <x:text> implements IModel {</x:text>

        <x:apply-templates select=".//P:ColumnMapping[@Exclude='false' and not(.//P:Attribute[@Key='exclude-from-api'])]"/>

        <x:text>
}</x:text>
    </x:template>

    <x:template match="P:ColumnMapping">
        <x:text>
	public </x:text>
        <x:value-of select="fn:FirstToLower(@FieldName)"/>
        <x:text>: </x:text>
        <x:call-template name="get-js-data-type"/>
        <x:text>;</x:text>
    </x:template>
</x:stylesheet>