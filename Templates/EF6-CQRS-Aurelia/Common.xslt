<?xml version="1.0"?>

<x:stylesheet version="1.0" xmlns:x="http://www.w3.org/1999/XSL/Transform" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:fn="urn:custom-functions">
    <x:output method="text" encoding="utf-8" indent="no" version="1.0" />

    <x:template name="generated-notice">
        <x:text>
/***************************************************
*                                                  *
* This file is generated, do not edit it manually. *
*                                                  *
***************************************************/
</x:text>
    </x:template>

    <x:template name="new-line">
        <x:text>
</x:text>
    </x:template>

    <ms:script implements-prefix="fn" language="C#">
        <![CDATA[
        public string ToLower(string text) {
            return (text == null ? null : text.ToLower());
        }
        
        public string FirstToLower(string text) {
            if (text == null)
                return null;
            else {
                StringBuilder sb = new StringBuilder();
                
                sb.Append(text.Substring(0, 1).ToLower());
                sb.Append(text.Substring(1));
                
                return sb.ToString();
            }
        }
        ]]>
    </ms:script>

    <x:template name="get-full-namespace">
        <x:param name="projectName"/>

        <x:value-of select="/P:Project/@RootNamespace"/>

        <x:if test="$projectName">
            <x:variable name="projectNamespace" select="/P:Project//P:Attribute[@Key=concat('namespace-', $projectName)]/@Value"/>

            <x:text>.</x:text>

            <x:choose>
                <x:when test="$projectNamespace">
                    <x:value-of select="$projectNamespace"/>
                </x:when>
                <x:otherwise>
                    <x:value-of select="$projectName"/>
                </x:otherwise>
            </x:choose>
        </x:if>
    </x:template>

    <x:template name="get-js-data-type">
        <x:param name="dataType" select="./@DataType"/>

        <x:choose>
            <x:when test="$dataType='bool'">
                <x:text>boolean</x:text>
            </x:when>
            <x:when test="$dataType='int' or $dataType='decimal' or $dataType='double' or $dataType='Int64'">
                <x:text>number</x:text>
            </x:when>
            <x:when test="$dataType='Guid'">
                <x:text>string</x:text>
            </x:when>
            <x:when test="$dataType='DateTime'">
                <x:text>Date</x:text>
            </x:when>
            <x:otherwise>
                <x:value-of select="$dataType"/>
            </x:otherwise>
        </x:choose>
    </x:template>

    <x:template match="text()|@*">
        <x:apply-templates/>
    </x:template>
</x:stylesheet>