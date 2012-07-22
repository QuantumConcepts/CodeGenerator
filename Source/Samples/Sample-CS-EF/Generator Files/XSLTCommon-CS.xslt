<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:QuantumConcepts="http://schemas.s-3.com/user-defined">
	<xsl:include href="XSLTCommon.xslt"/>
	
	<xsl:template name="Using">
		<xsl:param name="alias"/>
		<xsl:param name="namespace"/>
		<xsl:text>using </xsl:text>
		<xsl:if test="$alias">
			<xsl:value-of select="$alias"/>
			<xsl:text> </xsl:text>
		</xsl:if>
		<xsl:value-of select="$namespace"/>
		<xsl:text>;</xsl:text>
		<xsl:value-of select="$newLine"/>
	</xsl:template>
	
	<xsl:template name="Using-System">
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System'"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="Using-System-Collections">
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Collections.Generic'"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="Using-System-Linq">
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Linq'"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="Using-System-All">
		<xsl:call-template name="Using-System"/>
		<xsl:call-template name="Using-System-Collections"/>
		<xsl:call-template name="Using-System-Linq"/>
	</xsl:template>
	
	<xsl:template name="Using-Project">
		<xsl:for-each select="P:Project/P:Attributes/P:Attribute[@Key='Using']">
			<xsl:call-template name="Using">
				<xsl:with-param name="namespace" select="@Value"/>
			</xsl:call-template>
		</xsl:for-each>
	</xsl:template>
	
	<xsl:template name="Using-Template">
		<xsl:param name="template"/>
		
		<xsl:for-each select="$template/P:Attributes/P:Attribute[@Key='Using']">
			<xsl:call-template name="Using">
				<xsl:with-param name="namespace" select="@Value"/>
			</xsl:call-template>
		</xsl:for-each>
	</xsl:template>
	
	<xsl:template name="Using-All">
		<xsl:param name="template"/>
		
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using-Project"/>
		<xsl:call-template name="Using-Template">
			<xsl:with-param name="Template" select="$template"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="GetParameterName">
		<xsl:param name="parameter" select="."/>
		<xsl:if test="$parameter/@Name != ''">
			<xsl:value-of select="$parameter/@Name"/>
		</xsl:if>
	</xsl:template>
	
	<xsl:template name="GetReturnParameterDefinition">
		<xsl:call-template name="GetParameterDefinition">
			<xsl:with-param name="parameter" select="./P:ReturnParameter"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="GetParameterDefinition">
		<xsl:param name="parameter" select="."/>
		<xsl:param name="prefix"/>
		<xsl:call-template name="GetParameterModifier"/>
		<xsl:call-template name="GetParameterDataTypeAndName">
			<xsl:with-param name="parameter" select="$parameter"/>
			<xsl:with-param name="prefix" select="$prefix"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="GetParameterDataTypeAndName">
		<xsl:param name="parameter" select="."/>
		<xsl:param name="prefix"/>
		<xsl:call-template name="GetParameterDataType">
			<xsl:with-param name="parameter" select="$parameter"/>
			<xsl:with-param name="prefix" select="$prefix"/>
		</xsl:call-template>
		<xsl:text> </xsl:text>
		<xsl:call-template name="GetParameterName">
			<xsl:with-param name="parameter" select="$parameter"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="GetParameterModifierAndName">
		<xsl:param name="parameter" select="."/>
		<xsl:param name="prefix"/>
		<xsl:param name="ignoreParams"/>
		<xsl:call-template name="GetParameterModifier">
			<xsl:with-param name="parameter" select="$parameter"/>
			<xsl:with-param name="ignoreParams" select="$ignoreParams"/>
		</xsl:call-template>
		<xsl:call-template name="GetParameterName">
			<xsl:with-param name="parameter" select="$parameter"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="GetParameterModifier">
		<xsl:param name="parameter" select="."/>
		<xsl:param name="ignoreParams"/>
		<xsl:if test="$parameter/@Modifier != 'None' and ($ignoreParams!='Y' or $parameter/@Modifier != 'Params')">
			<xsl:call-template name="ToLowerCase">
				<xsl:with-param name="input" select="$parameter/@Modifier"/>
			</xsl:call-template>
			<xsl:text> </xsl:text>
		</xsl:if>
	</xsl:template>
	
	<xsl:template name="GetReturnParameterDataTypeForAPI">
		<xsl:param name="prefix"/>
		<xsl:call-template name="GetParameterDataType">
			<xsl:with-param name="parameter" select="./P:ReturnParameter"/>
			<xsl:with-param name="prefix" select="$prefix"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="GetParameterDataType">
		<xsl:param name="parameter" select="."/>
		<xsl:param name="prefix"/>
		<xsl:choose>
			<xsl:when test="$parameter/@Quantifier='List'">
				<xsl:text>List&lt;</xsl:text>
			</xsl:when>
			<xsl:when test="$parameter/@Quantifier='IEnumerable'">
				<xsl:text>IEnumerable&lt;</xsl:text>
			</xsl:when>
		</xsl:choose>
		<xsl:call-template name="GetParameterBaseDataType">
			<xsl:with-param name="parameter" select="$parameter"/>
			<xsl:with-param name="prefix" select="$prefix"/>
		</xsl:call-template>
		<xsl:choose>
			<xsl:when test="$parameter/@Quantifier='Array'">
				<xsl:text>[]</xsl:text>
			</xsl:when>
			<xsl:when test="$parameter/@Quantifier='List' or $parameter/@Quantifier='IEnumerable'">
				<xsl:text>&gt;</xsl:text>
			</xsl:when>
		</xsl:choose>
	</xsl:template>
	
	<xsl:template name="GetParameterBaseDataType">
		<xsl:param name="parameter" select="."/>
		<xsl:param name="prefix"/>
		<xsl:choose>
			<xsl:when test="$parameter/@Type = 'Void'">
				<xsl:text>void</xsl:text>
			</xsl:when>
			<xsl:when test="$parameter/@Type = 'DataObject'">
				<xsl:variable name="referencedTableMappingClassName" select="$parameter/@DataTypeReferencedTableMappingName"/>
				<xsl:value-of select="$prefix"/>
				<xsl:value-of select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$referencedTableMappingClassName]/@ClassName"/>
			</xsl:when>
			<xsl:when test="$parameter/@Type = 'Enum'">
				<xsl:variable name="referencedTableMappingClassName" select="$parameter/@DataTypeReferencedTableMappingName"/>
				<xsl:variable name="referencedEnumColumnMappingName" select="$parameter/@DataTypeReferencedEnumColumnMappingName"/>
				<xsl:value-of select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$referencedTableMappingClassName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedEnumColumnMappingName]/P:EnumerationMapping/@Name"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$parameter/@OtherDataType"/>
			</xsl:otherwise>
		</xsl:choose>
		<xsl:if test="$parameter/@Nullable='true'">
			<xsl:text>?</xsl:text>
		</xsl:if>
	</xsl:template>
	
	<xsl:template name="GetAllParameterDefinitionsForAPI">
		<xsl:param name="prefix"/>
		<xsl:for-each select="P:Parameters/P:Parameter">
			<xsl:call-template name="GetParameterDefinition">
				<xsl:with-param name="prefix" select="$prefix"/>
			</xsl:call-template>
			<xsl:if test="position() != last()">
				<xsl:text>, </xsl:text>
			</xsl:if>
		</xsl:for-each>
	</xsl:template>
	
	<xsl:template name="GetAllParameterModifiersAndNamesForAPI">
		<xsl:param name="prefix"/>
		<xsl:for-each select="P:Parameters/P:Parameter">
			<xsl:call-template name="GetParameterModifierAndName">
				<xsl:with-param name="ignoreParams" select="'Y'"/>
				<xsl:with-param name="prefix" select="$prefix"/>
			</xsl:call-template>
			<xsl:if test="position() != last()">
				<xsl:text>, </xsl:text>
			</xsl:if>
		</xsl:for-each>
	</xsl:template>
	
	<xsl:template name="GetSummaryDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:param name="element" select="."/>
		<xsl:if test="$element/P:Annotations/P:Annotation[@Type='summary']">
			<xsl:value-of select="$newLine"/>
			<xsl:value-of select="$spacingBefore"/>
			<xsl:text>/// &lt;summary&gt;</xsl:text>
			<xsl:value-of select="$element/P:Annotations/P:Annotation[@Type='summary']/P:Text/text()"/>
			<xsl:text>&lt;/summary&gt;</xsl:text>
		</xsl:if>
	</xsl:template>
	
	<xsl:template name="GetTableMappingDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:call-template name="GetSummaryDocumentation">
			<xsl:with-param name="spacingBefore" select="$spacingBefore"/>
			<xsl:with-param name="element" select="."/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="GetColumnMappingDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:call-template name="GetSummaryDocumentation">
			<xsl:with-param name="spacingBefore" select="$spacingBefore"/>
			<xsl:with-param name="element" select="."/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="GetEnumerationMappingDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:choose>
			<xsl:when test="@IsReference='true'">
				<xsl:variable name="tableName" select="@ReferencedTableName"/>
				<xsl:variable name="columnName" select="@ReferencedColumnName"/>
				<xsl:call-template name="GetSummaryDocumentation">
					<xsl:with-param name="spacingBefore" select="$spacingBefore"/>
					<xsl:with-param name="element" select="../../../P:TableMapping[@TableName=$tableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]/P:EnumerationMapping"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:call-template name="GetSummaryDocumentation">
					<xsl:with-param name="spacingBefore" select="$spacingBefore"/>
					<xsl:with-param name="element" select="../."/>
				</xsl:call-template>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	
	<xsl:template name="GetForeignKeyMappingDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:call-template name="GetSummaryDocumentation">
			<xsl:with-param name="spacingBefore" select="$spacingBefore"/>
			<xsl:with-param name="element" select="."/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="GetAPIDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:call-template name="GetSummaryDocumentation">
			<xsl:with-param name="spacingBefore" select="$spacingBefore"/>
			<xsl:with-param name="element" select="."/>
		</xsl:call-template>
		<xsl:for-each select="P:Parameters/P:Parameter[@IsReturnParameter='false']/P:Annotations/P:Annotation[@Type='param']">
			<xsl:value-of select="$newLine"/>
			<xsl:value-of select="$spacingBefore"/>
			<xsl:text>/// &lt;param name="</xsl:text>
			<xsl:value-of select="../../@Name"/>
			<xsl:text>"&gt;</xsl:text>
			<xsl:value-of select="P:Text/text()"/>
			<xsl:text>&lt;/param&gt;</xsl:text>
		</xsl:for-each>
		<xsl:if test="P:Annotations/P:Annotation[@Type='returns']">
			<xsl:value-of select="$newLine"/>
			<xsl:value-of select="$spacingBefore"/>
			<xsl:text>/// &lt;returns&gt;</xsl:text>
			<xsl:value-of select="P:Annotations/P:Annotation[@Type='returns']/P:Text/text()"/>
			<xsl:text>&lt;/returns&gt;</xsl:text>
		</xsl:if>
	</xsl:template>
	
	<xsl:template name="GetGetAllDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$spacingBefore"/>
		<xsl:text><![CDATA[/// <summary>Gets a list of all of the ]]></xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text><![CDATA[ in the database.</summary>]]></xsl:text>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$spacingBefore"/>
		<xsl:text><![CDATA[/// <returns>An IEnumerable of ]]></xsl:text>
		<xsl:value-of select="@PluralClassName"/>
		<xsl:text><![CDATA[.</returns>]]></xsl:text>
	</xsl:template>
	
	<xsl:template name="GetGetByIDDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$spacingBefore"/>
		<xsl:text><![CDATA[/// <summary>Gets the ]]></xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text><![CDATA[ with the specified primary key.</summary>]]></xsl:text>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$spacingBefore"/>
		<xsl:text><![CDATA[/// <param name="id">The primary key of the ]]></xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text><![CDATA[ to return.</param>
		/// <returns>The matching ]]></xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text><![CDATA[, if one exists, or null.</returns>]]></xsl:text>
	</xsl:template>
	
	<xsl:template name="GetGetByIDDocumentation_RESTOverload">
		<xsl:param name="spacingBefore"/>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$spacingBefore"/>
		<xsl:text><![CDATA[/// <summary>REST Overload: Gets the ]]></xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text><![CDATA[ with the specified primary key.</summary>]]></xsl:text>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$spacingBefore"/>
		<xsl:text><![CDATA[/// <param name="id">The string primary key of the ]]></xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text><![CDATA[ to return.</param>
		/// <returns>The matching ]]></xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text><![CDATA[, if one exists, or null.</returns>]]></xsl:text>
	</xsl:template>
	
	<xsl:template name="GetForeignKeyGetDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$spacingBefore"/>
		<xsl:text><![CDATA[/// <summary>Gets a list of all of the ]]></xsl:text>
		<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:text> in the database which are associated with the </xsl:text>
		<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		<xsl:text> table via the </xsl:text>
		<xsl:value-of select="$referencedColumnName"/>
		<xsl:text><![CDATA[ column.</summary>]]></xsl:text>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$spacingBefore"/>
		<xsl:text><![CDATA[/// <param name="]]></xsl:text>
		<xsl:call-template name="FirstCharacterToLowerCase">
			<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		</xsl:call-template>
		<xsl:value-of select="$referencedColumnName"/>
		<xsl:text><![CDATA[">The ]]></xsl:text>
		<xsl:value-of select="$referencedColumnName"/>
		<xsl:text> of the </xsl:text>
		<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
		<xsl:text> for which to retrieve the child </xsl:text>
		<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:text><![CDATA[.</param>]]></xsl:text>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$spacingBefore"/>
		<xsl:text><![CDATA[/// <returns>An IEnumerable of ]]></xsl:text>
		<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:text><![CDATA[.</returns>]]></xsl:text>
	</xsl:template>
	
	<xsl:template name="GetUniqueIndexMappingDocumentation">
		<xsl:param name="spacingBefore"/>
		<xsl:call-template name="GetSummaryDocumentation">
			<xsl:with-param name="spacingBefore" select="$spacingBefore"/>
			<xsl:with-param name="element" select="."/>
		</xsl:call-template>
	</xsl:template>
</xsl:stylesheet>