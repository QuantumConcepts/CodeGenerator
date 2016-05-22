<?xml version="1.0"?>

<x:stylesheet version="1.0" xmlns:x="http://www.w3.org/1999/XSL/Transform" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:fn="urn:custom-functions">
    <x:output method="text" encoding="utf-8" indent="no" version="1.0" />

    <x:include href="../Common.xslt"/>

    <x:template match="P:Project">
        <x:call-template name="generated-notice"/>

        <x:text>
using </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess.Entities'"/>
        </x:call-template>
        <x:text>;
using </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess.Repositories'"/>
        </x:call-template>
        <x:text>;
using </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Logic'"/>
        </x:call-template>
        <x:text>;</x:text>
        <x:apply-templates select="//P:TableMapping[@Exclude='false']" mode="using"/>
        <x:text>
using SimpleInjector;
using System.Collections.Generic;
using Entities = </x:text>
        <x:call-template name="get-full-namespace">
          <x:with-param name="projectName" select="'DataAccess.Entities'"/>
        </x:call-template>
        <x:text>;

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Logic'"/>
        </x:call-template>
        <x:text> {
    public partial class DependencyInjectionConfig {
        public static void RegisterGeneratedDependencies(Container container) {</x:text>

        <x:apply-templates select="//P:TableMapping[@Exclude='false']" mode="repository"/>
        <x:apply-templates select="//P:TableMapping[@Exclude='false']" mode="entity-handler"/>
        <x:apply-templates select="//P:TableMapping[@Exclude='false']" mode="get-all-handler"/>
        <x:apply-templates select="//P:TableMapping[@Exclude='false']" mode="search-handler"/>
        <x:apply-templates select="//P:TableMapping[@Exclude='false']" mode="get-handler"/>
        <x:apply-templates select="//P:TableMapping[@Exclude='false']" mode="persist-handler"/>
        <x:apply-templates select="//P:TableMapping[@Exclude='false']" mode="delete-handler"/>

        <x:text>
        }
    }
}</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="using">
        <x:text>
using </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Logic'"/>
        </x:call-template>
        <x:text>.</x:text>
        <x:value-of select="@PluralClassName"/>
        <x:text>;</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="repository">
        <x:text>
            container.Register&lt;IRepository&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>Repository&gt;();</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="entity-handler">
        <x:text>
            container.Register&lt;IEntityCommandHandler&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>CommandHandler&gt;();</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="get-all-handler">
        <x:text>
            container.Register&lt;ICommandHandler&lt;GetAllCommand&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, IEnumerable&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;&gt;, </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>CommandHandler&gt;();</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="search-handler">
        <x:text>
            container.Register&lt;ICommandHandler&lt;SearchCommand&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, IEnumerable&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;&gt;, </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>CommandHandler&gt;();</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="get-handler">
        <x:text>
            container.Register&lt;IAsyncCommandHandler&lt;GetCommand&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>CommandHandler&gt;();</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="persist-handler">
        <x:text>
            container.Register&lt;IAsyncCommandHandler&lt;PersistCommand&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;&gt;, </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>CommandHandler&gt;();</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="delete-handler">
        <x:text>
            container.Register&lt;IAsyncCommandHandler&lt;DeleteCommand&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;&gt;, </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>CommandHandler&gt;();</x:text>
    </x:template>
</x:stylesheet>