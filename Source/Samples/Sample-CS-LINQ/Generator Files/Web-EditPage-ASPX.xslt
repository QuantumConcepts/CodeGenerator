<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined" xmlns:asp="remove" xmlns:Ajax="remove" xmlns:Common="remove" xmlns:Sample="remove">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	<xsl:param name="elementName"/>
	
	<xsl:template match="P:Project">
		<xsl:variable name="table" select="P:TableMappings/P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
		
		<xsl:text disable-output-escaping="yes"><![CDATA[<%@ Page Title="Create or Edit ]]></xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>" MasterPageFile="~/Main.Master" CodeBehind="Edit.aspx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text disable-output-escaping="yes"><![CDATA[.Edit" Language="C#" %>
<%@ Register TagPrefix="Sample" TagName="Edit" Src="~/WebControls/Edit]]></xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text disable-output-escaping="yes"><![CDATA[.ascx" %>

]]></xsl:text>
		
		<xsl:element name="asp:Content">
			<xsl:attribute name="runat">
				<xsl:text>server</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="ContentPlaceHolderID">
				<xsl:text>content</xsl:text>
			</xsl:attribute>
			
			<xsl:element name="Sample:Edit">
				<xsl:attribute name="ID">
					<xsl:text>EditControl</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="runat">
					<xsl:text>server</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="OnSaved">
					<xsl:text>EditControl_Saved</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="OnCancelled">
					<xsl:text>EditControl_Cancelled</xsl:text>
				</xsl:attribute>
			</xsl:element>
		</xsl:element>
	</xsl:template>
</xsl:stylesheet>