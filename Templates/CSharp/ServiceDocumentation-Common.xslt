<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
	<xsl:include href="..\..\..\Common\Source\Generator Files\CSharp\Common.xslt"/>

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

	<!--Filter-->
	<xsl:template name="Doc-Filter-Title">
		<xsl:text>Filter </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
	</xsl:template>

	<xsl:template name="Doc-Filter-RESTURI">
		<xsl:text>/</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>/Filter</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-Filter-SOAPMethod">
		<xsl:text>Filter</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
	</xsl:template>

	<xsl:template name="Doc-Filter-Output">
		<xsl:value-of select="@ClassName"/>
		<xsl:text> Collection</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-Filter-Description">
		<xsl:text>Returns a paginated representation of all of the </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text> which match the provided filter query.</xsl:text>
	</xsl:template>

	<!--Filter Count-->
	<xsl:template name="Doc-FilterCount-Title">
		<xsl:text>Count of Filtered </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
	</xsl:template>

	<xsl:template name="Doc-FilterCount-RESTURI">
		<xsl:text>/</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>/Filter/Count</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FilterCount-SOAPMethod">
		<xsl:text>Filter</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>Count</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FilterCount-Output">
		<xsl:text>int</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FilterCount-Description">
		<xsl:text>Returns how many </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text> exist based on the provided filter query.</xsl:text>
	</xsl:template>

	<!--Filter Page Count-->
	<xsl:template name="Doc-FilterPageCount-Title">
		<xsl:text>Page Count of Filtered </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
	</xsl:template>

	<xsl:template name="Doc-FilterPageCount-RESTURI">
		<xsl:text>/</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>/Filter/PageCount</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FilterPageCount-SOAPMethod">
		<xsl:text>Filter</xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text>PageCount</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FilterPageCount-Output">
		<xsl:text>int</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FilterPageCount-Description">
		<xsl:text>Returns how many pages of data exist for all </xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text> based on the provided filter query.</xsl:text>
	</xsl:template>

	<!--FK (Plural)-->
	<xsl:template name="Doc-FKPlural-Title">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		
		<xsl:text>All </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> by </xsl:text>
		<xsl:value-of select="@PropertyName"/>
	</xsl:template>

	<xsl:template name="Doc-FKPlural-RESTURI">
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

	<xsl:template name="Doc-FKPlural-SOAPMethod">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		
		<xsl:text>Get</xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text>By</xsl:text>
		<xsl:value-of select="@FieldName"/>
	</xsl:template>

	<xsl:template name="Doc-FKPlural-Output">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
		
		<xsl:value-of select="$parentClassName"/>
		<xsl:text> Collection</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FKPlural-Description">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		
		<xsl:text>Returns a paginated representation of all of the </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> based on the unique ID of the related </xsl:text>
		<xsl:value-of select="$referencedClassName"/>
		<xsl:text>.</xsl:text>
	</xsl:template>

	<!--FK (Plural) Count-->
	<xsl:template name="Doc-FKPluralCount-Title">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:text>Count of All </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> by </xsl:text>
		<xsl:value-of select="@PropertyName"/>
	</xsl:template>

	<xsl:template name="Doc-FKPluralCount-RESTURI">
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

	<xsl:template name="Doc-FKPluralCount-SOAPMethod">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>

		<xsl:text>Get</xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text>By</xsl:text>
		<xsl:value-of select="@FieldName"/>
		<xsl:text>Count</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FKPluralCount-Output">
		<xsl:text>int</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FKPluralCount-Description">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:text>Returns how many </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> exist based on the unique ID of the related </xsl:text>
		<xsl:value-of select="$referencedClassName"/>
		<xsl:text>.</xsl:text>
	</xsl:template>

	<!--FK (Plural) Page Count-->
	<xsl:template name="Doc-FKPluralPageCount-Title">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:text>Page Count of All </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> by </xsl:text>
    <xsl:value-of select="@PropertyName"/>
	</xsl:template>

	<xsl:template name="Doc-FKPluralPageCount-RESTURI">
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

	<xsl:template name="Doc-FKPluralPageCount-SOAPMethod">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>

		<xsl:text>Get</xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text>By</xsl:text>
		<xsl:value-of select="@FieldName"/>
		<xsl:text>PageCount</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FKPluralPageCount-Output">
		<xsl:text>int</xsl:text>
	</xsl:template>

	<xsl:template name="Doc-FKPluralPageCount-Description">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		
		<xsl:text>Returns how many pages of data exist for all </xsl:text>
		<xsl:value-of select="$parentPluralClassName"/>
		<xsl:text> based on the unique ID of the related </xsl:text>
		<xsl:value-of select="$referencedClassName"/>
		<xsl:text>.</xsl:text>
	</xsl:template>

  <!--FK (Singular)-->
  <xsl:template name="Doc-FKSingular-Title">
    <xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
    <xsl:variable name="parentClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
    <xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
    <xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

    <xsl:value-of select="$referencedClassName"/>
    <xsl:text> </xsl:text>
    <xsl:value-of select="$parentClassName"/>
  </xsl:template>

  <xsl:template name="Doc-FKSingular-RESTURI">
    <xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
    <xsl:variable name="parentTable" select="//P:TableMapping[@TableName=$parentTableName]"/>
    <xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
    <xsl:variable name="PKColumn" select="$parentTable//P:ColumnMapping[@PrimaryKey='true']"/>
    <xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
    <xsl:variable name="referencedTable" select="//P:TableMapping[@TableName=$referencedTableName]"/>
    <xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>

    <xsl:choose>
      <xsl:when test="P:Attributes/P:Attribute[@Key='UriTemplateOverride']">
        <xsl:value-of select="P:Attributes/P:Attribute[@Key='UriTemplateOverride']/@Value"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:text>/</xsl:text>
        <xsl:value-of select="$parentTable/@ClassName"/>
        <xsl:text>/{</xsl:text>
          <xsl:call-template name="FirstCharacterToLowerCase">
              <xsl:with-param name="input" select="$parentTable/@ClassName"/>
          </xsl:call-template>
          <xsl:value-of select="$PKColumn/@FieldName"/>
        <xsl:text>}/</xsl:text>
        <xsl:value-of select="@PropertyName"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template name="Doc-FKSingular-SOAPMethod">
    <xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
    <xsl:variable name="parentClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
    <xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
    <xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

    <xsl:text>Get</xsl:text>
    <xsl:value-of select="@PropertyName"/>
    <xsl:text>For</xsl:text>
    <xsl:value-of select="$parentClassName"/>
  </xsl:template>

  <xsl:template name="Doc-FKSingular-Output">
    <xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
    <xsl:variable name="parentClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>

    <xsl:value-of select="$parentClassName"/>
  </xsl:template>

  <xsl:template name="Doc-FKSingular-Description">
    <xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
    <xsl:variable name="parentClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
    <xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
    <xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

    <xsl:text>Returns the related </xsl:text>
    <xsl:value-of select="@PropertyName"/>
    <xsl:text> based on the unique ID of the related </xsl:text>
    <xsl:value-of select="$parentClassName"/>
    <xsl:text>.</xsl:text>
  </xsl:template>

	<!--UX-->
	<xsl:template name="Doc-UX-Title">
		<xsl:value-of select="../../@ClassName"/>
		<xsl:text> by </xsl:text>

		<xsl:for-each select="P:ColumnNames/P:ColumnName">
			<xsl:variable name="columnName" select="text()"/>
			<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>

			<xsl:value-of select="$column/@FieldName"/>
			<xsl:choose>
				<xsl:when test="position()!=last()">
					<xsl:text>, </xsl:text>
				</xsl:when>
				<xsl:when test="position()=(last()-1)">
					<xsl:text> and </xsl:text>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
	</xsl:template>

	<xsl:template name="Doc-UX-RESTURI">
		<xsl:text>/</xsl:text>
		<xsl:choose>
			<xsl:when test="P:Attributes/P:Attribute[@Key=UriTemplateOverride]">
				<xsl:value-of select="P:Attributes/P:Attribute[@Key=UriTemplateOverride]/@Value"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:text>/</xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text>?</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>

					<xsl:value-of select="$column/@FieldName"/>
					<xsl:if test="position()!=last()">
						<xsl:text>&amp;</xsl:text>
					</xsl:if>
				</xsl:for-each>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template name="Doc-UX-SOAPMethod">
		<xsl:text>Get</xsl:text>
		<xsl:value-of select="../../@ClassName"/>
		<xsl:text>By</xsl:text>
		<xsl:for-each select="P:ColumnNames/P:ColumnName">
			<xsl:variable name="columnName" select="text()"/>
			<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
					
			<xsl:value-of select="$column/@FieldName"/>
			<xsl:if test="position()!=last()">
				<xsl:text>And</xsl:text>
			</xsl:if>
		</xsl:for-each>
	</xsl:template>

	<xsl:template name="Doc-UX-Output">
		<xsl:value-of select="../../@ClassName"/>
	</xsl:template>

	<xsl:template name="Doc-UX-Description">
		<xsl:text>Returns a representation of a particular </xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text> based on the provided unique values.</xsl:text>
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
	
	<!--Custom-->
	<xsl:variable name="Doc-CustomMethods">
		<xsl:element name="Method">
			<xsl:attribute name="Title">
				<xsl:text>Version Information</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="AnchorName">
				<xsl:text>Version-Information</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="RESTURI">
				<xsl:text>/Version</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="RESTVerb">
				<xsl:text>GET</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="SOAPMethod">
				<xsl:text>Version</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="Output">
				<xsl:text>VersionInfo</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="Description">
				<xsl:text>Returns version information.</xsl:text>
			</xsl:attribute>
		</xsl:element>
	</xsl:variable>
	
	<!--HTML-->
  <xsl:template name="OverviewTable">
    <xsl:param name="Title"/>
    <xsl:param name="RESTURI"/>
    <xsl:param name="RESTVerb" select="'GET'"/>
    <xsl:param name="SOAPMethod"/>
    <xsl:param name="Output"/>
    <xsl:param name="CopyOutput"/>

    <xsl:element name="table">
      <xsl:attribute name="summary">
        <xsl:text>Table describing URIs, HTTP Verbs, Methods, and Output of </xsl:text>
        <xsl:value-of select="$Title"/>
        <xsl:text>.</xsl:text>
      </xsl:attribute>

      <xsl:element name="tbody">
        <xsl:if test="$RESTURI">
          <xsl:call-template name="TableFieldAndValue">
            <xsl:with-param name="Field" select="'REST URI:'"/>
            <xsl:with-param name="Value" select="$RESTURI"/>
            <xsl:with-param name="CopyValue" select="$CopyOutput"/>
          </xsl:call-template>
        </xsl:if>

        <xsl:if test="$RESTVerb">
          <xsl:call-template name="TableFieldAndValue">
          <xsl:with-param name="Field" select="'REST Verb:'"/>
          <xsl:with-param name="Value" select="$RESTVerb"/>
          <xsl:with-param name="CopyValue" select="$CopyOutput"/>
        </xsl:call-template>
        </xsl:if>

        <xsl:if test="$SOAPMethod">
            <xsl:call-template name="TableFieldAndValue">
          <xsl:with-param name="Field" select="'SOAP Method:'"/>
          <xsl:with-param name="Value" select="$SOAPMethod"/>
          <xsl:with-param name="CopyValue" select="$CopyOutput"/>
        </xsl:call-template>
        </xsl:if>

        <xsl:if test="$Output">
          <xsl:call-template name="TableFieldAndValue">
            <xsl:with-param name="Field" select="'Output:'"/>
            <xsl:with-param name="Value" select="$Output"/>
            <xsl:with-param name="CopyValue" select="$CopyOutput"/>
          </xsl:call-template>
        </xsl:if>
      </xsl:element>
    </xsl:element>
  </xsl:template>
  
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