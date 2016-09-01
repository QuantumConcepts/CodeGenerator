<?xml version="1.0"?>

<x:stylesheet version="1.0" xmlns:x="http://www.w3.org/1999/XSL/Transform" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:fn="urn:custom-functions">
    <x:output method="text" encoding="utf-8" indent="no" version="1.0" />

    <x:include href="../Common.xslt"/>

    <x:template match="P:Project">
        <x:call-template name="generated-notice"/>

        <x:text>
using </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess.Cache'"/>
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

        <x:for-each select="//P:TableMapping[@Exclude='false']">
            <x:text>
            // </x:text>
            <x:value-of select="@ClassName"/>
            <x:text> Registrations</x:text>
            
            <x:apply-templates select="." mode="repository"/>
            <x:apply-templates select="." mode="entity-handler"/>
            <x:apply-templates select="." mode="persist-handler"/>
            <x:apply-templates select="." mode="delete-handler"/>
            
            <x:if test="current()!=last()">
                <x:text>
</x:text>
            </x:if>
        </x:for-each>
        
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
        <x:variable name="repoType">
            <x:value-of select="@ClassName"/>
            <x:text>Repository</x:text>
        </x:variable>
        <x:variable name="readRepoType">
            <x:choose>
                <x:when test=".//P:Attribute[@Key='cache']">
                    <x:value-of select="@ClassName"/>
                    <x:text>Cache</x:text>
                </x:when>
                <x:otherwise>
                    <x:value-of select="$repoType"/>
                </x:otherwise>
            </x:choose>
        </x:variable>
    
        <x:text>
            container.Register&lt;I</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>Repository, </x:text>
        <x:value-of select="$repoType"/>
        <x:text>&gt;();
            container.Register&lt;I</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>ReadRepository, </x:text>
        <x:value-of select="$readRepoType"/>
        <x:text>&gt;();
            container.Register&lt;I</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>WriteRepository, </x:text>
        <x:value-of select="$repoType"/>
        <x:text>&gt;();
            container.Register&lt;IReadRepository&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, </x:text>
        <x:value-of select="$readRepoType"/>
        <x:text>&gt;();
            container.Register&lt;ILiveReadRepository&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, </x:text>
        <x:value-of select="$repoType"/>
        <x:text>&gt;();
            container.Register&lt;IWriteRepository&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, </x:text>
        <x:value-of select="$repoType"/>
        <x:text>&gt;();
            container.Register&lt;IRepository&lt;Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;, </x:text>
        <x:value-of select="$repoType"/>
        <x:text>&gt;();</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="entity-handler">
        <x:text>
            container.Register&lt;I</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>CommandHandler, </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>CommandHandler&gt;();</x:text>
        <x:text>
            container.Register&lt;IEntityCommandHandler&lt;Entities.</x:text>
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