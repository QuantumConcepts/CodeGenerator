<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined" xmlns:asp="remove" xmlns:Ajax="remove" xmlns:Common="remove">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes"/>
	
	<xsl:include href="Common.xslt"/>

	<xsl:param name="templateName"/>
	<xsl:param name="elementName"/>

	<xsl:template match="P:Project">
		<xsl:variable name="table" select="P:TableMappings/P:TableMapping[@TableName=$elementName]"/>
		<xsl:variable name="tableName" select="$table/@TableName"/>
		<xsl:variable name="className" select="$table/@ClassName"/>
		<xsl:variable name="pluralClassName" select="$table/@PluralClassName"/>
		<xsl:variable name="displayName">
			<xsl:choose>
				<xsl:when test="$table/P:Attributes/P:Attribute[@Key='DisplayName']">
					<xsl:value-of select="$table/P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$className"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>
		<xsl:variable name="pluralDisplayName">
			<xsl:choose>
				<xsl:when test="$table/P:Attributes/P:Attribute[@Key='PluralDisplayName']">
					<xsl:value-of select="$table/P:Attributes/P:Attribute[@Key='PluralDisplayName']/@Value"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$pluralClassName"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>
		<xsl:variable name="allColumns" select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false' and P:Attributes/P:Attribute[@Key='MVC-Admin-Show']]"/>
		
		<xsl:text>@* This view has been generated, do not edit! *@

</xsl:text>
		<xsl:call-template name="Razor-Using-Template">
			<xsl:with-param name="template" select="P:Templates/P:Template[@Name=$templateName]"/>
		</xsl:call-template>
		<xsl:call-template name="Razor-Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.Web.Areas.Administration.Models.</xsl:text>
				<xsl:value-of select="$pluralClassName"/>
			</xsl:with-param>
		</xsl:call-template>
		
		<xsl:text>
@model </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>EditModel

@{
	this.ViewBag.Title = string.Format("{0} </xsl:text>
		<xsl:value-of select="$displayName"/>
		<xsl:text>", this.Model.ID.HasValue ? "Edit" : "New");
}

@using (Html.BeginForm("Edit", "</xsl:text>
		<xsl:value-of select="$pluralClassName"/>
		<xsl:text><![CDATA[", FormMethod.Post, new { id = "Edit" }))
{
	<div class="Form Wide">
		@Html.EditorForModel()
	</div>
}]]>
</xsl:text>

		<xsl:if test="$table/P:Attributes/P:Attribute[@Key='MVC-Admin-Deletable']">
			<xsl:text>
@if (this.Model.ID.HasValue)
{
    using (Html.BeginForm("Delete", "</xsl:text>
		<xsl:value-of select="$pluralClassName"/>
		<xsl:text disable-output-escaping="yes">", FormMethod.Post, new { id = "Delete" }))
	{
		@Html.EditorFor(o =&gt; o.ID)
	}
}
</xsl:text>
		</xsl:if>

		<xsl:text><![CDATA[
<div class="Footer">
	<a href="JavaScript:$('form#Edit').submit()" class="Button" data-options='{ "icons": { "primary": "ui-icon-disk" } }'>Save</a>]]></xsl:text>
	
		<xsl:if test="$table/P:Attributes/P:Attribute[@Key='MVC-Admin-Deletable']">
			<xsl:text><![CDATA[
	
	@if (this.Model.ID.HasValue)
	{
		<a href="JavaScript:$('form#Delete').submit()" class="Button" data-options='{ "icons": { "primary": "ui-icon-trash" } }'>Delete</a>
	}]]></xsl:text>
		</xsl:if>
		
		<xsl:text><![CDATA[
	
	@{Html.RenderPartial("CancelLinkButton");}
</div>]]>
	</xsl:text>
	</xsl:template>
</xsl:stylesheet>