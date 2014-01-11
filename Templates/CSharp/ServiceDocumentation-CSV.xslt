<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="ServiceDocumentation-Common.xslt"/>
	
	<xsl:template match="P:Project">
		<xsl:text>Resource,REST URI,REST Http Verb,SOAP Method,Input Parameters,Output,Description</xsl:text>
		<xsl:value-of select="$newLine"/>
		
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed']">
			<xsl:sort select="@ClassName"/>
			
			<xsl:variable name="TableName" select="@TableName"/>
			
			<!--All-->
			<xsl:call-template name="Doc-All-Title"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-All-RESTURI"/>
			<xsl:text>,</xsl:text>
			
			<xsl:text>GET,</xsl:text>

			<xsl:call-template name="Doc-All-SOAPMethod"/>
			<xsl:text>,</xsl:text>
			
			<xsl:text>int page,</xsl:text>

			<xsl:call-template name="Doc-All-Output"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-All-Description"/>
			<xsl:value-of select="$newLine"/>
			<!--END All-->

			<!--All Count-->
			<xsl:call-template name="Doc-AllCount-Title"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-AllCount-RESTURI"/>
			<xsl:text>,</xsl:text>

			<xsl:text>GET,</xsl:text>

			<xsl:call-template name="Doc-AllCount-SOAPMethod"/>
			<xsl:text>,</xsl:text>

			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-AllCount-Output"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-AllCount-Description"/>
			<xsl:value-of select="$newLine"/>
			<!--END All Count-->

			<!--All Page Count-->
			<xsl:call-template name="Doc-AllPageCount-Title"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-AllPageCount-RESTURI"/>
			<xsl:text>,</xsl:text>

			<xsl:text>GET,</xsl:text>

			<xsl:call-template name="Doc-AllPageCount-SOAPMethod"/>
			<xsl:text>,</xsl:text>

			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-AllPageCount-Output"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-AllPageCount-Description"/>
			<xsl:value-of select="$newLine"/>
			<!--END All Page Count-->
			
			<!--PK-->
			<xsl:call-template name="Doc-PK-Title"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-PK-RESTURI"/>
			<xsl:text>,</xsl:text>

			<xsl:text>GET,</xsl:text>

			<xsl:call-template name="Doc-PK-SOAPMethod"/>
			<xsl:text>,</xsl:text>

			<xsl:text>int id,</xsl:text>

			<xsl:call-template name="Doc-PK-Output"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-PK-Description"/>
			<xsl:value-of select="$newLine"/>
			<!--END PK-->
			
			<!--Filter-->
			<xsl:call-template name="Doc-Filter-Title"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-Filter-RESTURI"/>
			<xsl:text>,</xsl:text>
			
			<xsl:text>GET,</xsl:text>

			<xsl:call-template name="Doc-Filter-SOAPMethod"/>
			<xsl:text>,</xsl:text>
			
			<xsl:text>int page,</xsl:text>

			<xsl:call-template name="Doc-Filter-Output"/>
			<xsl:text>,</xsl:text>

			<xsl:call-template name="Doc-All-Description"/>
			<xsl:value-of select="$newLine"/>
			<!--END Filter-->
			
			<!--FK-->
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed' and @ParentTableMappingName=$TableName]">
				<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				
				<!--FK-->
				<xsl:call-template name="Doc-FKPlural-Title"/>
				<xsl:text>,</xsl:text>

				<xsl:call-template name="Doc-FKPlural-RESTURI"/>
				<xsl:text>,</xsl:text>

				<xsl:text>GET,</xsl:text>

				<xsl:call-template name="Doc-FKPlural-SOAPMethod"/>
				<xsl:text>,</xsl:text>
				
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>; int page,</xsl:text>

				<xsl:call-template name="Doc-FKPlural-Output"/>
				<xsl:text>,</xsl:text>

				<xsl:call-template name="Doc-FKPlural-Description"/>
				<xsl:value-of select="$newLine"/>
				<!--END FK-->

				<!--FK Count-->
				<xsl:call-template name="Doc-FKPluralCount-Title"/>
				<xsl:text>,</xsl:text>

				<xsl:call-template name="Doc-FKPluralCount-RESTURI"/>
				<xsl:text>,</xsl:text>

				<xsl:text>GET,</xsl:text>

				<xsl:call-template name="Doc-FKPluralCount-SOAPMethod"/>
				<xsl:text>,</xsl:text>

				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>,</xsl:text>

				<xsl:call-template name="Doc-FKPluralCount-Output"/>
				<xsl:text>,</xsl:text>

				<xsl:call-template name="Doc-FKPluralCount-Description"/>
				<xsl:value-of select="$newLine"/>
				<!--END FK Count-->

				<!--FK Page Count-->
				<xsl:call-template name="Doc-FKPluralPageCount-Title"/>
				<xsl:text>,</xsl:text>

				<xsl:call-template name="Doc-FKPluralPageCount-RESTURI"/>
				<xsl:text>,</xsl:text>

				<xsl:text>GET,</xsl:text>

				<xsl:call-template name="Doc-FKPluralPageCount-SOAPMethod"/>
				<xsl:text>,</xsl:text>

				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>,</xsl:text>

				<xsl:call-template name="Doc-FKPluralPageCount-Output"/>
				<xsl:text>,</xsl:text>

				<xsl:call-template name="Doc-FKPluralPageCount-Description"/>
				<xsl:value-of select="$newLine"/>
				<!--END FK Page Count-->
			</xsl:for-each>
			<!--END FK-->
		</xsl:for-each>
		
		<!--Custom-->
		<xsl:for-each select="msxsl:node-set($Doc-CustomMethods)/Method">
			<xsl:value-of select="@Title"/>
			<xsl:text>,</xsl:text>
			<xsl:value-of select="@RESTURI"/>
			<xsl:text>,</xsl:text>
			<xsl:value-of select="@RESTVerb"/>
			<xsl:text>,</xsl:text>
			<xsl:value-of select="@SOAPMethod"/>
			<xsl:text>,</xsl:text>
			<xsl:for-each select="P:Parameter">
				<xsl:call-template name="Doc-ParameterType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="Doc-ParameterName"/>
				
				<xsl:if test="current() != last()">
					<xsl:text>; </xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:text>,</xsl:text>
			<xsl:value-of select="@Output"/>
			<xsl:text>,</xsl:text>
			<xsl:value-of select="@Description"/>
			<xsl:value-of select="$newLine"/>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>