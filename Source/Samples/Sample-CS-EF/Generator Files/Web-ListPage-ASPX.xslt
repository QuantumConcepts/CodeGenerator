<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined" xmlns:asp="remove" xmlns:Ajax="remove" xmlns:Common="remove" xmlns:Sample="remove">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	<xsl:param name="elementName"/>
	
	<xsl:template match="P:Project">
		<xsl:variable name="table" select="P:TableMappings/P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
		
		<xsl:text disable-output-escaping="yes"><![CDATA[<%@ Page Title="All ]]></xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text>" MasterPageFile="~/Main.Master" CodeBehind="Default.aspx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text disable-output-escaping="yes"><![CDATA[.Default" Language="C#" %>
<%@ Register TagPrefix="Sample" TagName="List" Src="~/WebControls/]]></xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text disable-output-escaping="yes"><![CDATA[List.ascx" %>

]]></xsl:text>
		
		<xsl:element name="asp:Content">
			<xsl:attribute name="runat">
				<xsl:text>server</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="ContentPlaceHolderID">
				<xsl:text>content</xsl:text>
			</xsl:attribute>
			
			<xsl:element name="div">
				<xsl:attribute name="id">
					<xsl:text>SubMenu</xsl:text>
				</xsl:attribute>
			
				<xsl:element name="a">
					<xsl:attribute name="href">
						<xsl:text>Edit.aspx</xsl:text>
					</xsl:attribute>
					
					<xsl:text>New...</xsl:text>
				</xsl:element>
			</xsl:element>
			
			<xsl:element name="Sample:List">
				<xsl:attribute name="ID">
					<xsl:text>ListControl</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="runat">
					<xsl:text>server</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="OnNeedsDataBinding">
					<xsl:text>ListControl_NeedsDataBinding</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="OnEdit">
					<xsl:text>ListControl_Edit</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="OnDelete">
					<xsl:text>ListControl_Delete</xsl:text>
				</xsl:attribute>
			</xsl:element>
		</xsl:element>
	</xsl:template>
</xsl:stylesheet>