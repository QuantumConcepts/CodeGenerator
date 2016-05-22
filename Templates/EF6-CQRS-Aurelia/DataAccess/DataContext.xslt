<?xml version="1.0"?>

<x:stylesheet version="1.0" xmlns:x="http://www.w3.org/1999/XSL/Transform" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd">
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
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace </x:text>
        <x:call-template name="get-full-namespace">
            <x:with-param name="projectName" select="'DataAccess'"/>
        </x:call-template>
        <x:text> {
    public partial class DataContext : DbContext {</x:text>

        <x:apply-templates mode="ref" select=".//P:TableMapping[@Exclude='false']"/>

        <x:text>

        public DataContext() : base("name=Entities") { }

        protected override void OnModelCreating(DbModelBuilder builder) {
            base.OnModelCreating(builder);
</x:text>
        
        <x:apply-templates mode="call-build" select=".//P:TableMapping[@Exclude='false']"/>

        <x:text>
        }</x:text>

        <x:apply-templates mode="build" select=".//P:TableMapping[@Exclude='false']"/>

        <x:text>
    }
}</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="ref">
        <x:text>
        public virtual DbSet&lt;</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt; </x:text>
        <x:value-of select="@PluralClassName"/>
        <x:text> { get; set; }</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="call-build">
        <x:text>
            Build</x:text>
        <x:value-of select="@PluralClassName"/>
        <x:text>(builder);</x:text>
    </x:template>

    <x:template match="P:TableMapping" mode="build">
        <x:variable name="table" select="."/>
        <x:variable name="pkColumn" select=".//P:ColumnMapping[@PrimaryKey='true']"/>
        
        <x:text>

        private void Build</x:text>
        <x:value-of select="@PluralClassName"/>
        <x:text>(DbModelBuilder builder) {
            var entityBuilder = builder.Entity&lt;</x:text>
        <x:value-of select="@ClassName"/>
        <x:text>&gt;();

            entityBuilder
                .ToTable("</x:text>
        <x:value-of select="@TableName"/>
        <x:text>")
                .HasKey(o => o.</x:text>
        <x:value-of select="$pkColumn/@FieldName"/>
        <x:text>);

            entityBuilder
                .Property(o => o.</x:text>
        <x:value-of select="$pkColumn/@FieldName"/>
        <x:text>)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);</x:text>

        <x:apply-templates mode="child" select="//P:ForeignKeyMapping[@Exclude='false' and not(.//P:Attribute[@Key='passthrough']) and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName]"/>
        <!--<x:apply-templates mode="parent" select="//P:ForeignKeyMapping[@Exclude='false' and not(.//P:Attribute[@Key='passthrough']) and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]"/>-->
        <x:apply-templates mode="passthrough" select="//P:ForeignKeyMapping[@Exclude='false' and .//P:Attribute[@Key='passthrough'] and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]"/>

        <x:text>
        }</x:text>
    </x:template>

    <x:template match="P:ForeignKeyMapping" mode="child">
        <x:text>

            entityBuilder
                .HasRequired(o => o.</x:text>
        <x:value-of select="@PropertyName"/>
        <x:text>)
                .WithMany(o => o.</x:text>
        <x:value-of select="@PluralPropertyName"/>
        <x:text>)
                .HasForeignKey(o => o.</x:text>
        <x:value-of select="@FieldName"/>
        <x:text>);</x:text>
    </x:template>

    <!--<x:template match="P:ForeignKeyMapping" mode="parent">
        <x:variable name="parentTable" select="//P:TableMapping[@SchemaName=current()/@ParentTableMappingSchemaName and @TableName=current()/@ParentTableMappingName]"/>

    </x:template>-->

    <x:template match="P:ForeignKeyMapping" mode="passthrough">
        <x:variable name="leftTable" select="//P:TableMapping[@SchemaName=current()/@ReferencedTableMappingSchemaName and @TableName=current()/@ReferencedTableMappingName]"/>
        <x:variable name="leftFK" select="."/>
        <x:variable name="linkingTable" select="//P:TableMapping[@SchemaName=current()/@ParentTableMappingSchemaName and @TableName=current()/@ParentTableMappingName]"/>
        <x:variable name="rightFK" select="//P:ForeignKeyMapping[@ParentTableMappingSchemaName=$linkingTable/@SchemaName and @ParentTableMappingName=$linkingTable/@TableName and @ForeignKeyName!=current()/@ForeignKeyName]"/>
        <x:variable name="rightTable" select="//P:TableMapping[@SchemaName=$rightFK/@ReferencedTableMappingSchemaName and @TableName=$rightFK/@ReferencedTableMappingName]"/>

        <x:text>

            entityBuilder
                .HasMany(o => o.</x:text>
        <x:value-of select="$leftFK/@PluralPropertyName"/>
        <x:text>)
                .WithMany(o => o.</x:text>
        <x:value-of select="$rightFK/@PluralPropertyName"/>
        <x:text>)
                .Map(m => m
                    .MapLeftKey("</x:text>
        <x:value-of select="$leftFK/@FieldName"/>
        <x:text>")
                    .MapRightKey("</x:text>
        <x:value-of select="$rightFK/@FieldName"/>
        <x:text>")
                    .ToTable("</x:text>
        <x:value-of select="$linkingTable/@TableName"/>
        <x:text>"));</x:text>
    </x:template>
</x:stylesheet>