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
		<xsl:variable name="readonly" select="$table/@ReadOnly='true' or $table/P:Attributes/P:Attribute[@Key='MVC-Admin-Readonly']"/>
		
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
@model IndexModel

@{
	this.ViewBag.Title = "</xsl:text>
		<xsl:value-of select="$pluralDisplayName"/>
		<xsl:text>";
}

@section Title
{</xsl:text>
		
    		<xsl:if test="not($readonly)">
    			<xsl:text><![CDATA[
	<a href="@Url.Action("Add")" class="Button" data-options='{ "icons": { "primary": "ui-icon-plus" } }'>New ]]></xsl:text>
	    	<xsl:value-of select="$displayName"/>
	    	<xsl:text><![CDATA[</a> ]]></xsl:text>
    		</xsl:if>
    		
    		<xsl:text>
	@this.ViewBag.Title
}

@using (Html.BeginForm("Index", "</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text>", FormMethod.Get))
{<![CDATA[
	<div class="Form Inline Filter">
		@Html.EditorForModel()

		<div class="Footer">
			<button class="Button Small" data-options='{ "icons": { "primary": "ui-icon-check" } }'>Apply</button>
		</div>
	</div>]]>
}

@{Html.RenderPartial("Pager", new PagerModel("Index", "</xsl:text>
		<xsl:value-of select="$pluralClassName"/>
		<xsl:text>", "</xsl:text>
		<xsl:call-template name="ToLowerCase">
			<xsl:with-param name="input" select="$displayName"/>
		</xsl:call-template>
		<xsl:text>", "</xsl:text>
		<xsl:call-template name="ToLowerCase">
			<xsl:with-param name="input" select="$pluralDisplayName"/>
		</xsl:call-template>
		<xsl:text>", this.Model.TotalCount, this.Model.Page, this.Model.PageCount), this.ViewData);}

@{
	SplitButtonModel splitButtonModel = new SplitButtonModel(new SplitButtonItem());
	</xsl:text>

		<xsl:choose>
    			<xsl:when test="$readonly">
    				<xsl:text>
	splitButtonModel.DefaultButton.Text = "Details";
	splitButtonModel.DefaultButton.Href = Url.Action("Detail", new { ID = "{ID}", ReturnUrl = this.Request.Url.ToString() });
	splitButtonModel.DefaultButton.Options = "{ \"icons\": { \"primary\": \"ui-icon-search\" } }";</xsl:text>
			</xsl:when>
			<xsl:otherwise>
				<xsl:text>
	splitButtonModel.DefaultButton.Text = "Edit";
	splitButtonModel.DefaultButton.Href = Url.Action("Edit", new { ID = "{ID}", ReturnUrl = this.Request.Url.ToString() });
	splitButtonModel.DefaultButton.Options = "{ \"icons\": { \"primary\": \"ui-icon-pencil\" } }";</xsl:text>
			</xsl:otherwise>
		</xsl:choose>
		
		<xsl:text>
	
	Html.RenderPartial("Table", new TableModel(splitButtonModel, this.Model.Items));
}
</xsl:text>	
	</xsl:template>
</xsl:stylesheet>