<?xml version="1.0"?>

<x:stylesheet version="1.0" xmlns:x="http://www.w3.org/1999/XSL/Transform" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:fn="urn:custom-functions">
    <x:output method="text" encoding="utf-8" indent="no" version="1.0" />

    <x:include href="../Common.xslt"/>
    
    <x:param name="elementName"/>

    <x:template match="P:Project">
        <x:apply-templates select="//P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
    </x:template>

    <x:template match="P:TableMapping">
        <x:variable name="table" select="."/>
        <x:variable name="pkColumn" select=".//P:ColumnMapping[@PrimaryKey='true']"/>
        <x:variable name="pkNameLower" select="fn:ToLower($pkColumn/@FieldName)"/>
        <x:variable name="childFKs" select="//P:ForeignKeyMapping[@Exclude='false' and not(.//P:Attribute[@Key='passthrough']) and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName]"/>
        <x:variable name="parentFKs" select="//P:ForeignKeyMapping[@Exclude='false' and not(.//P:Attribute[@Key='passthrough']) and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]"/>
        <x:variable name="passthroughFKs" select="//P:ForeignKeyMapping[@Exclude='false' and .//P:Attribute[@Key='passthrough'] and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]"/>
        
        <x:call-template name="generated-notice"/>
        
        <x:text>
using AutoMapper;
using QuantumConcepts.Common.Extensions;
using </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Logic'"/>
        </x:call-template>
        <x:text>;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Entities = </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess'"/>
        </x:call-template>
        <x:text>.Entities;
using EntityType = </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess'"/>
        </x:call-template>
        <x:text>.Entities.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>;
using ModelType = </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Api.Common.Models'"/>
        </x:call-template>
        <x:text>.</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>;
using HandlerType = </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Logic'"/>
        </x:call-template>
        <x:text>.</x:text>
        <x:value-of select="@PluralClassName"/>
        <x:text>.I</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>CommandHandler;

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'Api.Web'"/>
        </x:call-template>
        <x:text>.</x:text>
        <x:value-of select="@PluralClassName"/>
        <x:text> {
    [Authorize]
    [RoutePrefix("</x:text>
        <x:value-of select="@PluralClassName"/>
        <x:text>")]
    public partial class </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>Controller : BaseController&lt;EntityType, ModelType&gt; {
        protected new HandlerType Handler { get; set; }

        public </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>Controller(ICommandHandler&lt;SearchCommand&lt;Entities.User&gt;, IEnumerable&lt;Entities.User&gt;&gt; userSearchCommandHandler, HandlerType handler, IMapper mapper)
            : base(userSearchCommandHandler, handler, mapper) {
            this.Handler = handler;
        }

        /// &lt;summary&gt;Gets all </x:text>
        <x:value-of select="@PluralClassName"/>
        <x:text>.&lt;/summary&gt;
        [HttpGet]
        [Route(Name = "GetAll</x:text>
        <x:value-of select="@PluralClassName"/>
        <x:text>")]
        [ResponseType(typeof(IEnumerable&lt;ModelType&gt;))]
        public new Task&lt;IHttpActionResult&gt; GetAll() {
            return base.GetAll();
        }
        
        /// &lt;summary&gt;Gets the </x:text>
        <x:value-of select="@ClassName"></x:value-of>
        <x:text> identified by the </x:text>
        <x:value-of select="$pkColumn/@FieldName"/>
        <x:text> field.&lt;/summary&gt;
        [HttpGet]
        [Route("{</x:text>
        <x:value-of select="$pkNameLower"/>
        <x:text>}", Name = "Get</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>")]
        [ResponseType(typeof(ModelType))]
        public new Task&lt;IHttpActionResult&gt; Get(</x:text>
        <x:value-of select="$pkColumn/@DataType"/>
        <x:text> </x:text>
        <x:value-of select="$pkNameLower"/>
        <x:text>) {
            return base.Get(</x:text>
        <x:value-of select="$pkNameLower"/>
        <x:text>);
        }

        /// &lt;summary&gt;Creates a new </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>.&lt;/summary&gt;
        [HttpPost]
        [Route(Name = "Create</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>")]
        [ResponseType(typeof(ModelType))]
        public new Task&lt;IHttpActionResult&gt; Create(ModelType model) {
            return base.Create(model);
        }

        /// &lt;summary&gt;Updates an existing </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>.&lt;/summary&gt;
        [HttpPut]
        [Route("{</x:text>
        <x:value-of select="$pkNameLower"/>
        <x:text>}", Name = "Update</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>")]
        [ResponseType(typeof(ModelType))]
        public new Task&lt;IHttpActionResult&gt; Update(</x:text>
        <x:value-of select="$pkColumn/@DataType"/>
        <x:text> </x:text>
        <x:value-of select="$pkNameLower"/>
        <x:text>, ModelType model) {
            return base.Update(</x:text>
        <x:value-of select="$pkNameLower"/>
        <x:text>, model);
        }

        /// &lt;summary&gt;Deletes a single </x:text>
        <x:value-of select="@ClassName"/>
        <x:text>.&lt;/summary&gt;
        [HttpDelete]
        [Route("{</x:text>
        <x:value-of select="$pkNameLower"/>
        <x:text>}", Name = "Delete</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>")]
        public new Task&lt;IHttpActionResult&gt; Delete(</x:text>
        <x:value-of select="$pkColumn/@DataType"/>
        <x:text> </x:text>
        <x:value-of select="$pkNameLower"/>
        <x:text>) {
            return base.Delete(</x:text>
        <x:value-of select="$pkNameLower"/>
        <x:text>);
        }</x:text>

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
        <x:variable name="routeName">
            <x:text>Get</x:text>
            <x:value-of select="@PluralPropertyName"/>
            <x:text>By</x:text>
            <x:value-of select="@PropertyName"/>
        </x:variable>
        
        <x:text>

        /// &lt;summary&gt;Gets all </x:text>
        <x:value-of select="$table/@PluralClassName"/>
        <x:text> by </x:text>
        <x:value-of select="current()/@FieldName"/>
        <x:text>.&lt;/summary&gt;
        [HttpGet]
        [Route("~/</x:text>
        <x:value-of select="$childTable/@PluralClassName"/>
        <x:text>/{</x:text>
        <x:value-of select="$fieldNameLower"/>
        <x:text>}/</x:text>
        <x:value-of select="@PluralPropertyName"/>
        <x:text>", Name = "</x:text>
        <x:value-of select="$routeName"/>
        <x:text>")]
        [ResponseType(typeof(IEnumerable&lt;ModelType&gt;))]
        public Task&lt;IHttpActionResult&gt; </x:text>
        <x:value-of select="$routeName"/>
        <x:text>(</x:text>
        <x:value-of select="$childTablePK/@DataType"/>
        <x:text> </x:text>
        <x:value-of select="$fieldNameLower"/>
        <x:text>) {
           return ExecuteQuery(o =&gt; o.</x:text>
        <x:value-of select="@FieldName"/>
        <x:text> == </x:text>
        <x:value-of select="$fieldNameLower"/>
        <x:text>);
        }</x:text>
    </x:template>

    <x:template match="P:ForeignKeyMapping" mode="parent">
        <x:param name="table"/>
        <x:variable name="parentTable" select="//P:TableMapping[@SchemaName=current()/@ParentTableMappingSchemaName and @TableName=current()/@ParentTableMappingName]"/>
        <x:variable name="parentTablePK" select="$parentTable//P:ColumnMapping[@ColumnName=current()/@ReferencedColumnMappingName]"/>
        <x:variable name="parentTablePKLower" select="fn:FirstToLower($parentTablePK/@FieldName)"/>
        <x:variable name="routeName">
            <x:text>Get</x:text>
            <x:value-of select="@PropertyName"/>
            <x:text>By</x:text>
            <x:value-of select="$parentTable/@ClassName"/>
        </x:variable>

        <x:text>

        /// &lt;summary&gt;Gets a single </x:text>
        <x:value-of select="$table/@ClassName"/>
        <x:text> by the </x:text>
        <x:value-of select="$parentTablePK/@FieldName"/>
        <x:text> field of a related </x:text>
        <x:value-of select="$parentTable/@ClassName"/>
        <x:text>.&lt;/summary&gt;
        [HttpGet]
        [Route("~/</x:text>
        <x:value-of select="$parentTable/@PluralClassName"/>
        <x:text>/{</x:text>
        <x:value-of select="$parentTablePKLower"/>
        <x:text>}/</x:text>
        <x:value-of select="@PropertyName"/>
        <x:text>", Name = "</x:text>
        <x:value-of select="$routeName"/>
        <x:text>")]
        [ResponseType(typeof(ModelType))]
        public Task&lt;IHttpActionResult&gt; </x:text>
        <x:value-of select="$routeName"/>
        <x:text>(</x:text>
        <x:value-of select="$parentTablePK/@DataType"/>
        <x:text> </x:text>
        <x:value-of select="$parentTablePKLower"/>
        <x:text>) {
           return ExecuteQuery(parent =&gt; parent.</x:text>
        <x:value-of select="@PluralPropertyName"/>
        <x:text>.Any(child =&gt; child.</x:text>
        <x:value-of select="$parentTablePK/@FieldName"/>
        <x:text> == </x:text>
        <x:value-of select="$parentTablePKLower"/>
        <x:text>));
        }</x:text>
    </x:template>

    <x:template match="P:ForeignKeyMapping" mode="passthrough">
        <x:param name="table"/>
        <x:variable name="linkingTable" select="//P:TableMapping[@SchemaName=current()/@ParentTableMappingSchemaName and @TableName=current()/@ParentTableMappingName]"/>
        <x:variable name="rightFK" select="//P:ForeignKeyMapping[@ParentTableMappingSchemaName=$linkingTable/@SchemaName and @ParentTableMappingName=$linkingTable/@TableName and @ForeignKeyName!=current()/@ForeignKeyName]"/>
        <x:variable name="rightTable" select="//P:TableMapping[@SchemaName=$rightFK/@ReferencedTableMappingSchemaName and @TableName=$rightFK/@ReferencedTableMappingName]"/>
        <x:variable name="rightTablePK" select="$rightTable//P:ColumnMapping[@ColumnName=current()/@ReferencedColumnMappingName]"/>
        <x:variable name="rightTablePKLower" select="fn:FirstToLower($rightTablePK/@FieldName)"/>
        <x:variable name="routeName">
            <x:text>Get</x:text>
            <x:value-of select="$rightFK/@PluralPropertyName"/>
            <x:text>By</x:text>
            <x:value-of select="$rightFK/@PropertyName"/>
        </x:variable>

        <x:text>

        /// &lt;summary&gt;Gets a single </x:text>
        <x:value-of select="$table/@ClassName"/>
        <x:text> by the </x:text>
        <x:value-of select="$rightTablePK/@FieldName"/>
        <x:text> field of a related </x:text>
        <x:value-of select="$rightTable/@ClassName"/>
        <x:text>.&lt;/summary&gt;
        [HttpGet]
        [Route("~/</x:text>
        <x:value-of select="$rightTable/@PluralClassName"/>
        <x:text>/{</x:text>
        <x:value-of select="$rightTablePKLower"/>
        <x:text>}/</x:text>
        <x:value-of select="$rightFK/@PluralPropertyName"/>
        <x:text>", Name = "</x:text>
        <x:value-of select="$routeName"/>
        <x:text>")]
        [ResponseType(typeof(ModelType))]
        public Task&lt;IHttpActionResult&gt; </x:text>
        <x:value-of select="$routeName"/>
        <x:text>(</x:text>
        <x:value-of select="$rightTablePK/@DataType"/>
        <x:text> </x:text>
        <x:value-of select="$rightTablePKLower"/>
        <x:text>) {
           return ExecuteQuery(parent =&gt; parent.</x:text>
        <x:value-of select="@PluralPropertyName"/>
        <x:text>.Any(child =&gt; child.</x:text>
        <x:value-of select="$rightTablePK/@FieldName"/>
        <x:text> == </x:text>
        <x:value-of select="$rightTablePKLower"/>
        <x:text>));
        }</x:text>
    </x:template>

    <x:template match="P:UniqueIndexMapping">
        <x:param name="table"/>
        <x:variable name="routeName">
            <x:text>Get</x:text>
            <x:value-of select="$table/@ClassName"/>
            <x:text>By</x:text>
            <x:for-each select=".//P:ColumnName">
                <x:value-of select="text()"/>

                <x:if test="position()!=last()">
                    <x:text>And</x:text>
                </x:if>
            </x:for-each>
        </x:variable>
        <x:variable name="functionName">
            <x:text>GetBy</x:text>
            <x:for-each select=".//P:ColumnName">
                <x:value-of select="text()"/>

                <x:if test="position()!=last()">
                    <x:text>And</x:text>
                </x:if>
            </x:for-each>
        </x:variable>

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
        [HttpGet]
        [Route("~/</x:text>
        <x:value-of select="$table/@PluralClassName"/>
        <x:text>/</x:text>
        <x:for-each select=".//P:ColumnName">
            <x:variable name="column" select="$table//P:ColumnMapping[@ColumnName=current()/text()]"/>

            <x:value-of select="$column/@FieldName"/>
            <x:text>={</x:text>
            <x:value-of select="fn:FirstToLower($column/@FieldName)"/>
            <x:text>}</x:text>
            
            <x:if test="position()!=last()">
                <x:text>/</x:text>
            </x:if>
        </x:for-each>
        <x:text>", Name = "</x:text>
        <x:value-of select="$routeName"/>
        <x:text>")]
        [ResponseType(typeof(ModelType))]
        public Task&lt;IHttpActionResult&gt; </x:text>
        <x:value-of select="$functionName"/>
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
        <x:text>) {
            return ExecuteQuery(o =&gt; </x:text>
        <x:for-each select=".//P:ColumnName">
            <x:variable name="column" select="$table//P:ColumnMapping[@ColumnName=current()/text()]"/>

            <x:text>object.Equals(o.</x:text>
            <x:value-of select="$column/@FieldName"/>
            <x:text>, </x:text>
            <x:value-of select="fn:FirstToLower($column/@FieldName)"/>
            <x:text>)</x:text>

            <x:if test="position()!=last()">
                <x:text> &amp;&amp;
                                     </x:text>
            </x:if>
        </x:for-each>
        <x:text>);
        }</x:text>
    </x:template>
</x:stylesheet>