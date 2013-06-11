<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
	<xsl:variable name="lowerCaseLetters" select="'abcdefghijklmnopqrstuvwxyz'"/>
	<xsl:variable name="upperCaseLetters" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ'"/>
	<xsl:variable name="newLine" select="'&#xD;&#xA;'"/>
	<xsl:variable name="tab" select="'&#x9;'"/>
	
	<xsl:key name="Table" match="P:TableMapping" use="concat(@SchemaName, @TableName)"/>
	
	<xsl:template name="ToLowerCase">
		<xsl:param name="input"/>
		<xsl:value-of select="translate($input, $upperCaseLetters, $lowerCaseLetters)"/>
	</xsl:template>

	<xsl:template name="ToUpperCase">
		<xsl:param name="input"/>
		<xsl:value-of select="translate($input, $lowerCaseLetters, $upperCaseLetters)"/>
	</xsl:template>

	<xsl:template name="FirstCharacterToLowerCase">
		<xsl:param name="input"/>
		<xsl:value-of select="concat(translate(substring($input, 1, 1), $upperCaseLetters, $lowerCaseLetters), substring($input, 2, string-length($input) - 1))"/>
	</xsl:template>
</xsl:stylesheet>