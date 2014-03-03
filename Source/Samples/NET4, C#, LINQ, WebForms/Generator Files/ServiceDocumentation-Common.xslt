<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt">
	<xsl:include href="XSLTCommon-CS.xslt"/>

	<!--All-->
	<xsl:template name="Doc-All-Title">
		<xsl:text>All </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
	</xsl:template>

	<xsl:template name="Doc-All-RESTURI">
		<xsl:text>/</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>/{page}</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-All-SOAPMethod">
		<xsl:text>Get</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
	</xsl:template>

	<xsl:template name="Doc-All-Output">
		<xsl:value-of select="@ClassName"/>
		<xsl:text> Collection</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-All-Description">
		<xsl:text>Returns a paginated representation of all of the </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>.</xsl:text>
	</xsl:template>

	<!--All Count-->
	<xsl:template name="Doc-AllCount-Title">
		<xsl:text>Count of All </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
	</xsl:template>

	<xsl:template name="Doc-AllCount-RESTURI">
		<xsl:text>/</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>/Count</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-AllCount-SOAPMethod">
		<xsl:text>Get</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>Count</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-AllCount-Output">
		<xsl:text>int</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-AllCount-Description">
		<xsl:text>Returns how many </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text> exist.</xsl:text>
	</xsl:template>

	<!--All Page Count-->
	<xsl:template name="Doc-AllPageCount-Title">
		<xsl:text>Page Count of All </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
	</xsl:template>

	<xsl:template name="Doc-AllPageCount-RESTURI">
		<xsl:text>/</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>/PageCount</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-AllPageCount-SOAPMethod">
		<xsl:text>Get</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>PageCount</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-AllPageCount-Output">
		<xsl:text>int</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-AllPageCount-Description">
		<xsl:text>Returns how many pages of data exist for all </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>.</xsl:text>
	</xsl:template>

	<!--PK-->
	<xsl:template name="Doc-PK-Title">
		<xsl:value-of select="@ClassName"/>
	</xsl:template>

	<xsl:template name="Doc-PK-RESTURI">
		<xsl:text>/</xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text>/{id}</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-PK-SOAPMethod">
		<xsl:text>Get</xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text>ByID</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-PK-Output">
		<xsl:value-of select="@ClassName"/>
	</xsl:template>

	<xsl:template name="Doc-PK-Description">
		<xsl:text>Returns a representation of a particular </xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text> based on its identifier.</xsl:text>
	</xsl:template>

	<!--FK-->
	<xsl:template name="Doc-FK-Title">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		
		<xsl:text>All </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> by </xsl:text>
		<xsl:value-of select="$referencedClassName"/>
	</xsl:template>

	<xsl:template name="Doc-FK-RESTURI">
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		
		<xsl:choose>
			<xsl:when test="P:Attributes/P:Attribute[@Key=UriTemplateOverride]">
				<xsl:value-of select="P:Attributes/P:Attribute[@Key=UriTemplateOverride]/@Value"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:text>/</xsl:text>
				<xsl:value-of select="$referencedClassName"/>
				<xsl:text>/{</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedClassName"/>
				</xsl:call-template>
				<xsl:value-of select="@ReferencedColumnMappingName"/>
				<xsl:text>}/</xsl:text>
				<xsl:value-of select="@PluralFieldName"/>
				<xsl:text>/{page}</xsl:text>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template name="Doc-FK-SOAPMethod">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		
		<xsl:text>Get</xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text>By</xsl:text>
		<xsl:value-of select="@FieldName"/>
	</xsl:template>

	<xsl:template name="Doc-FK-Output">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
		
		<xsl:value-of select="$parentClassName"/>
		<xsl:text> Collection,</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FK-Description">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		
		<xsl:text>Returns a paginated representation of all of the </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> based on the primary key of the related </xsl:text>
		<xsl:value-of select="$referencedClassName"/>
		<xsl:text>.</xsl:text>
	</xsl:template>

	<!--FK Count-->
	<xsl:template name="Doc-FKCount-Title">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:text>Count of All </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> by </xsl:text>
		<xsl:value-of select="$referencedClassName"/>
	</xsl:template>

	<xsl:template name="Doc-FKCount-RESTURI">
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:choose>
			<xsl:when test="P:Attributes/P:Attribute[@Key=UriTemplateOverride]">
				<xsl:value-of select="P:Attributes/P:Attribute[@Key=UriTemplateOverride]/@Value"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:text>/</xsl:text>
				<xsl:value-of select="$referencedClassName"/>
				<xsl:text>/{</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedClassName"/>
				</xsl:call-template>
				<xsl:value-of select="@ReferencedColumnMappingName"/>
				<xsl:text>}/</xsl:text>
				<xsl:value-of select="@PluralFieldName"/>
				<xsl:text>/Count</xsl:text>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template name="Doc-FKCount-SOAPMethod">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>

		<xsl:text>Get</xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text>By</xsl:text>
		<xsl:value-of select="@FieldName"/>
		<xsl:text>Count</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FKCount-Output">
		<xsl:text>int</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FKCount-Description">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:text>Returns how many </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> exist based on the primary key of the related </xsl:text>
		<xsl:value-of select="$referencedClassName"/>
		<xsl:text>.</xsl:text>
	</xsl:template>

	<!--FK Page Count-->
	<xsl:template name="Doc-FKPageCount-Title">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:text>Page Count of All </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> by </xsl:text>
		<xsl:value-of select="$referencedClassName"/>
	</xsl:template>

	<xsl:template name="Doc-FKPageCount-RESTURI">
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:choose>
			<xsl:when test="P:Attributes/P:Attribute[@Key=UriTemplateOverride]">
				<xsl:value-of select="P:Attributes/P:Attribute[@Key=UriTemplateOverride]/@Value"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:text>/</xsl:text>
				<xsl:value-of select="$referencedClassName"/>
				<xsl:text>/{</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedClassName"/>
				</xsl:call-template>
				<xsl:value-of select="@ReferencedColumnMappingName"/>
				<xsl:text>}/</xsl:text>
				<xsl:value-of select="@PluralFieldName"/>
				<xsl:text>/PageCount</xsl:text>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template name="Doc-FKPageCount-SOAPMethod">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>

		<xsl:text>Get</xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text>By</xsl:text>
		<xsl:value-of select="@FieldName"/>
		<xsl:text>PageCount</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FKPageCount-Output">
		<xsl:text>int</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FKPageCount-Description">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		
		<xsl:text>Returns how many pages of data exist for all </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> based on the primary key of the related </xsl:text>
		<xsl:value-of select="$referencedClassName"/>
		<xsl:text>.</xsl:text>
	</xsl:template>
	
	<!--Common-->
	<xsl:variable name="Doc-Parameter-Page-Name" select="'page'"/>
	<xsl:variable name="Doc-Parameter-Page-Type" select="'int'"/>
	<xsl:variable name="Doc-Parameter-Page-Description" select="'The index of the page of data to retrieve. A value of 1 indicates the first page of data.'"/>
	
	<xsl:template name="Doc-ParameterName">
		<xsl:choose>
			<xsl:when test="@IsPage">
				<xsl:value-of select="$Doc-Parameter-Page-Name"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="@Name"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	
	<xsl:template name="Doc-ParameterType">
		<xsl:choose>
			<xsl:when test="@IsPage">
				<xsl:value-of select="$Doc-Parameter-Page-Type"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="@Type"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	
	<xsl:template name="Doc-ParameterDescription">
		<xsl:choose>
			<xsl:when test="@IsPage">
				<xsl:value-of select="$Doc-Parameter-Page-Description"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="@Description"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	
	<!--HTML-->
	<xsl:template name="TableFieldAndValue">
		<xsl:param name="Field"/>
		<xsl:param name="Value"/>
		<xsl:param name="CopyField"/>
		<xsl:param name="CopyValue"/>
		
		<xsl:element name="tr">
			<xsl:call-template name="TableHeaderCell">
				<xsl:with-param name="Scope" select="'row'"/>
				<xsl:with-param name="Text" select="$Field"/>
				<xsl:with-param name="Copy" select="$CopyField"/>
			</xsl:call-template>
			<xsl:call-template name="TableCell">
				<xsl:with-param name="Text" select="$Value"/>
				<xsl:with-param name="Copy" select="$CopyValue"/>
			</xsl:call-template>
		</xsl:element>
	</xsl:template>
	
	<xsl:template name="TableHeaderCell">
		<xsl:param name="Scope"/>
		<xsl:param name="Text"/>
		<xsl:param name="Copy"/>
		
		<xsl:element name="th">
			<xsl:attribute name="scope">
				<xsl:value-of select="$Scope"/>
			</xsl:attribute>
			
			<xsl:choose>
				<xsl:when test="$Copy">
					<xsl:copy-of select="$Text"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$Text"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:element>
	</xsl:template>
	
	<xsl:template name="TableCell">
		<xsl:param name="Text"/>
		<xsl:param name="Copy"/>
		
		<xsl:element name="td">
			<xsl:choose>
				<xsl:when test="$Copy">
					<xsl:copy-of select="$Text"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$Text"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:element>
	</xsl:template>
	
	<xsl:template name="BR">
		<xsl:element name="br"/>
	</xsl:template>
</xsl:stylesheet>