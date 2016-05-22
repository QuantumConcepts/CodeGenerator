<?xml version="1.0"?>

<x:stylesheet version="1.0" xmlns:x="http://www.w3.org/1999/XSL/Transform" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:fn="urn:custom-functions">
    <x:output method="text" encoding="utf-8" indent="no" version="1.0" />

    <x:include href="../Common.xslt"/>
    
    <x:template match="P:Project">
        <x:call-template name="generated-notice"/>

        <x:text>
using AutoMapper;
using System;
using Models = </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Api.Common.Models'"/>
        </x:call-template>
        <x:text>;
using Entities = </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess.Entities'"/>
        </x:call-template>
        <x:text>;

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Api.Web.Startup'"/>
        </x:call-template>
        <x:text> {
    public partial class AutoMapperConfig {
        static partial void RegisterGeneratedMappings(IMapperConfiguration cfg) {</x:text>

        <x:apply-templates select="//P:TableMapping[@Exclude='false']"/>

        <x:text>
        }
    }
}</x:text>
    </x:template>

    <x:template match="P:TableMapping">
        <x:text>
            cfg.CreateTwoWayMap&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>, Models.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>>();</x:text>
    </x:template>
</x:stylesheet>