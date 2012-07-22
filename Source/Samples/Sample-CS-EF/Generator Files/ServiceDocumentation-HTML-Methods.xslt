<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:asp="remove" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes"/>

	<xsl:include href="ServiceDocumentation-Common.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:text disable-output-escaping="yes"><![CDATA[<%@ Page Title="Service Methods" MasterPageFile="~/Main.Master" Inherits="System.Web.UI.Page" Language="C#" %>]]></xsl:text>
		
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$newLine"/>
		
		<xsl:element name="asp:Content">
			<xsl:attribute name="runat">
				<xsl:text>server</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="ContentPlaceHolderID">
				<xsl:text>content</xsl:text>
			</xsl:attribute>
			
			<xsl:for-each
				select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed']">
				<xsl:sort select="@ClassName"/>
	
				<xsl:variable name="TableName" select="@TableName"/>
	
				<!--All-->
				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock</xsl:text>
					</xsl:attribute>
	
					<xsl:element name="h3">
						<xsl:call-template name="Doc-All-Title"/>
					</xsl:element>
	
					<xsl:element name="p">
						<xsl:call-template name="Doc-All-Description"/>
					</xsl:element>
	
					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodTable</xsl:text>
						</xsl:attribute>
	
						<xsl:call-template name="OverviewTable">
							<xsl:with-param name="Title">
								<xsl:call-template name="Doc-All-Title"/>
							</xsl:with-param>
							<xsl:with-param name="RESTURI">
								<xsl:call-template name="Doc-All-RESTURI"/>
							</xsl:with-param>
							<xsl:with-param name="SOAPMethod">
								<xsl:call-template name="Doc-All-SOAPMethod"/>
							</xsl:with-param>
							<xsl:with-param name="Output">
								<xsl:element name="a">
									<xsl:attribute name="href">
										<xsl:text>Types.aspx#</xsl:text>
										<xsl:value-of select="@ClassName"/>
										<xsl:text>-Collection</xsl:text>
									</xsl:attribute>
	
									<xsl:call-template name="Doc-All-Output"/>
								</xsl:element>
							</xsl:with-param>
							<xsl:with-param name="CopyOutput" select="true()"/>
						</xsl:call-template>
					</xsl:element>
	
					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodParameters</xsl:text>
						</xsl:attribute>
	
						<xsl:element name="table">
							<xsl:attribute name="summary">
								<xsl:text>Table describing the parameters for </xsl:text>
								<xsl:call-template name="Doc-All-Title"/>
								<xsl:text>.</xsl:text>
							</xsl:attribute>
	
							<xsl:element name="thead">
								<xsl:call-template name="ParameterTableHeader"/>
							</xsl:element>
	
							<xsl:element name="tbody">
								<xsl:call-template name="ParameterTableRow-Page"/>
							</xsl:element>
						</xsl:element>
					</xsl:element>
				</xsl:element>
				<!--END All-->
	
				<!--All Count-->
				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock</xsl:text>
					</xsl:attribute>
	
					<xsl:element name="h3">
						<xsl:call-template name="Doc-AllCount-Title"/>
					</xsl:element>
	
					<xsl:element name="p">
						<xsl:call-template name="Doc-AllCount-Description"/>
					</xsl:element>
	
					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodTable</xsl:text>
						</xsl:attribute>
	
						<xsl:call-template name="OverviewTable">
							<xsl:with-param name="Title">
								<xsl:call-template name="Doc-AllCount-Title"/>
							</xsl:with-param>
							<xsl:with-param name="RESTURI">
								<xsl:call-template name="Doc-AllCount-RESTURI"/>
							</xsl:with-param>
							<xsl:with-param name="SOAPMethod">
								<xsl:call-template name="Doc-AllCount-SOAPMethod"/>
							</xsl:with-param>
							<xsl:with-param name="Output">
								<xsl:call-template name="Doc-AllCount-Output"/>
							</xsl:with-param>
						</xsl:call-template>
					</xsl:element>
				</xsl:element>
				<!--END All Count-->
	
				<!--All Page Count-->
				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock</xsl:text>
					</xsl:attribute>
	
					<xsl:element name="h3">
						<xsl:call-template name="Doc-AllPageCount-Title"/>
					</xsl:element>
	
					<xsl:element name="p">
						<xsl:call-template name="Doc-AllPageCount-Description"/>
					</xsl:element>
	
					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodTable</xsl:text>
						</xsl:attribute>
	
						<xsl:call-template name="OverviewTable">
							<xsl:with-param name="Title">
								<xsl:call-template name="Doc-AllPageCount-Title"/>
							</xsl:with-param>
							<xsl:with-param name="RESTURI">
								<xsl:call-template name="Doc-AllPageCount-RESTURI"/>
							</xsl:with-param>
							<xsl:with-param name="SOAPMethod">
								<xsl:call-template name="Doc-AllPageCount-SOAPMethod"/>
							</xsl:with-param>
							<xsl:with-param name="Output">
								<xsl:call-template name="Doc-AllPageCount-Output"/>
							</xsl:with-param>
						</xsl:call-template>
					</xsl:element>
				</xsl:element>
				<!--END All Page Count-->
	
				<!--PK-->
				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock</xsl:text>
					</xsl:attribute>
	
					<xsl:element name="h3">
						<xsl:call-template name="Doc-PK-Title"/>
					</xsl:element>
	
					<xsl:element name="p">
						<xsl:call-template name="Doc-PK-Description"/>
					</xsl:element>
	
					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodTable</xsl:text>
						</xsl:attribute>
	
						<xsl:call-template name="OverviewTable">
							<xsl:with-param name="Title">
								<xsl:call-template name="Doc-PK-Title"/>
							</xsl:with-param>
							<xsl:with-param name="RESTURI">
								<xsl:call-template name="Doc-PK-RESTURI"/>
							</xsl:with-param>
							<xsl:with-param name="SOAPMethod">
								<xsl:call-template name="Doc-PK-SOAPMethod"/>
							</xsl:with-param>
							<xsl:with-param name="Output">
								<xsl:element name="a">
									<xsl:attribute name="href">
										<xsl:text>Types.aspx#</xsl:text>
										<xsl:value-of select="@ClassName"/>
									</xsl:attribute>
	
									<xsl:call-template name="Doc-PK-Output"/>
								</xsl:element>
							</xsl:with-param>
							<xsl:with-param name="CopyOutput" select="true()"/>
						</xsl:call-template>
					</xsl:element>
	
					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodParameters</xsl:text>
						</xsl:attribute>
	
						<xsl:element name="table">
							<xsl:attribute name="summary">
								<xsl:text>Table describing the parameters for </xsl:text>
								<xsl:call-template name="Doc-PK-Title"/>
								<xsl:text>.</xsl:text>
							</xsl:attribute>
	
							<xsl:element name="thead">
								<xsl:call-template name="ParameterTableHeader"/>
							</xsl:element>
	
							<xsl:element name="tbody">
								<xsl:call-template name="ParameterTableRow">
									<xsl:with-param name="Parameter" select="'id'"/>
									<xsl:with-param name="Type" select="'int'"/>
									<xsl:with-param name="Description">
										<xsl:text>The primary key identifier of the </xsl:text>
										<xsl:value-of select="@ClassName"/>
										<xsl:text> instance to retrieve.</xsl:text>
									</xsl:with-param>
								</xsl:call-template>
							</xsl:element>
						</xsl:element>
					</xsl:element>
				</xsl:element>
				<!--END PK-->
	
				<!--FK-->
				<xsl:for-each
					select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed' and @ParentTableMappingName=$TableName]">
					<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
					<xsl:variable name="parentClassName"
						select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
	
					<!--FK-->
					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>ServiceBlock</xsl:text>
						</xsl:attribute>
	
						<xsl:element name="h3">
							<xsl:call-template name="Doc-FK-Title"/>
						</xsl:element>
	
						<xsl:element name="p">
							<xsl:call-template name="Doc-FK-Description"/>
						</xsl:element>
	
						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodTable</xsl:text>
							</xsl:attribute>
	
							<xsl:call-template name="OverviewTable">
								<xsl:with-param name="Title">
									<xsl:call-template name="Doc-FK-Title"/>
								</xsl:with-param>
								<xsl:with-param name="RESTURI">
									<xsl:call-template name="Doc-FK-RESTURI"/>
								</xsl:with-param>
								<xsl:with-param name="SOAPMethod">
									<xsl:call-template name="Doc-FK-SOAPMethod"/>
								</xsl:with-param>
								<xsl:with-param name="Output">
									<xsl:element name="a">
										<xsl:attribute name="href">
											<xsl:text>Types.aspx#</xsl:text>
											<xsl:value-of select="$parentClassName"/>
											<xsl:text>-Collection</xsl:text>
										</xsl:attribute>
	
										<xsl:call-template name="Doc-FK-Output"/>
									</xsl:element>
								</xsl:with-param>
								<xsl:with-param name="CopyOutput" select="true()"/>
							</xsl:call-template>
						</xsl:element>
	
						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodParameters</xsl:text>
							</xsl:attribute>
	
							<xsl:element name="table">
								<xsl:attribute name="summary">
									<xsl:text>Table describing the parameters for </xsl:text>
									<xsl:call-template name="Doc-FK-Title"/>
									<xsl:text>.</xsl:text>
								</xsl:attribute>
	
								<xsl:element name="thead">
									<xsl:call-template name="ParameterTableHeader"/>
								</xsl:element>
	
								<xsl:element name="tbody">
									<xsl:call-template name="ParameterTableRow-FK-PK"/>
									<xsl:call-template name="ParameterTableRow-Page"/>
								</xsl:element>
							</xsl:element>
						</xsl:element>
					</xsl:element>
					<!--END FK-->
	
					<!--FK All Count-->
					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>ServiceBlock</xsl:text>
						</xsl:attribute>
	
						<xsl:element name="h3">
							<xsl:call-template name="Doc-FKCount-Title"/>
						</xsl:element>
	
						<xsl:element name="p">
							<xsl:call-template name="Doc-FKCount-Description"/>
						</xsl:element>
	
						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodTable</xsl:text>
							</xsl:attribute>
	
							<xsl:call-template name="OverviewTable">
								<xsl:with-param name="Title">
									<xsl:call-template name="Doc-FKCount-Title"/>
								</xsl:with-param>
								<xsl:with-param name="RESTURI">
									<xsl:call-template name="Doc-FKCount-RESTURI"/>
								</xsl:with-param>
								<xsl:with-param name="SOAPMethod">
									<xsl:call-template name="Doc-FKCount-SOAPMethod"/>
								</xsl:with-param>
								<xsl:with-param name="Output">
									<xsl:call-template name="Doc-FKCount-Output"/>
								</xsl:with-param>
							</xsl:call-template>
						</xsl:element>
	
						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodParameters</xsl:text>
							</xsl:attribute>
	
							<xsl:element name="table">
								<xsl:attribute name="summary">
									<xsl:text>Table describing the parameters for </xsl:text>
									<xsl:call-template name="Doc-FKCount-Title"/>
									<xsl:text>.</xsl:text>
								</xsl:attribute>
	
								<xsl:element name="thead">
									<xsl:call-template name="ParameterTableHeader"/>
								</xsl:element>
	
								<xsl:element name="tbody">
									<xsl:call-template name="ParameterTableRow-FK-PK"/>
								</xsl:element>
							</xsl:element>
						</xsl:element>
					</xsl:element>
					<!--END FK All Count-->
	
					<!--FK Page Count-->
					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>ServiceBlock</xsl:text>
						</xsl:attribute>
	
						<xsl:element name="h3">
							<xsl:call-template name="Doc-FKPageCount-Title"/>
						</xsl:element>
	
						<xsl:element name="p">
							<xsl:call-template name="Doc-FKPageCount-Description"/>
						</xsl:element>
	
						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodTable</xsl:text>
							</xsl:attribute>
	
							<xsl:call-template name="OverviewTable">
								<xsl:with-param name="Title">
									<xsl:call-template name="Doc-FKPageCount-Title"/>
								</xsl:with-param>
								<xsl:with-param name="RESTURI">
									<xsl:call-template name="Doc-FKPageCount-RESTURI"/>
								</xsl:with-param>
								<xsl:with-param name="SOAPMethod">
									<xsl:call-template name="Doc-FKPageCount-SOAPMethod"/>
								</xsl:with-param>
								<xsl:with-param name="Output">
									<xsl:call-template name="Doc-FKPageCount-Output"/>
								</xsl:with-param>
							</xsl:call-template>
						</xsl:element>
	
						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodParameters</xsl:text>
							</xsl:attribute>
	
							<xsl:element name="table">
								<xsl:attribute name="summary">
									<xsl:text>Table describing the parameters for </xsl:text>
									<xsl:call-template name="Doc-FKPageCount-Title"/>
									<xsl:text>.</xsl:text>
								</xsl:attribute>
	
								<xsl:element name="thead">
									<xsl:call-template name="ParameterTableHeader"/>
								</xsl:element>
	
								<xsl:element name="tbody">
									<xsl:call-template name="ParameterTableRow-FK-PK"/>
								</xsl:element>
							</xsl:element>
						</xsl:element>
					</xsl:element>
					<!--END FK Page Count-->
				</xsl:for-each>
				<!--END FK-->
			</xsl:for-each>
			
			<xsl:element name="script">
				<xsl:attribute name="type">
					<xsl:text>text/javascript</xsl:text>
				</xsl:attribute>
				<xsl:text>$(document).ready(function () { $(".MethodParameters table th:nth-child(2)").addClass("SecondColumn"); });</xsl:text>
			</xsl:element>
		</xsl:element>
	</xsl:template>

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
				<xsl:call-template name="TableFieldAndValue">
					<xsl:with-param name="Field" select="'REST URI:'"/>
					<xsl:with-param name="Value" select="$RESTURI"/>
				</xsl:call-template>

				<xsl:call-template name="TableFieldAndValue">
					<xsl:with-param name="Field" select="'REST Verb:'"/>
					<xsl:with-param name="Value" select="$RESTVerb"/>
				</xsl:call-template>

				<xsl:call-template name="TableFieldAndValue">
					<xsl:with-param name="Field" select="'SOAP Method:'"/>
					<xsl:with-param name="Value" select="$SOAPMethod"/>
				</xsl:call-template>

				<xsl:call-template name="TableFieldAndValue">
					<xsl:with-param name="Field" select="'Output:'"/>
					<xsl:with-param name="Value" select="$Output"/>
					<xsl:with-param name="CopyValue" select="$CopyOutput"/>
				</xsl:call-template>
			</xsl:element>
		</xsl:element>
	</xsl:template>

	<xsl:template name="ParameterTableHeader">
		<xsl:element name="tr">
			<xsl:call-template name="TableHeaderCell">
				<xsl:with-param name="Scope" select="'col'"/>
				<xsl:with-param name="Text" select="'Parameter'"/>
			</xsl:call-template>
			<xsl:call-template name="TableHeaderCell">
				<xsl:with-param name="Scope" select="'col'"/>
				<xsl:with-param name="Text" select="'Type'"/>
			</xsl:call-template>
			<xsl:call-template name="TableHeaderCell">
				<xsl:with-param name="Scope" select="'col'"/>
				<xsl:with-param name="Text" select="'Description'"/>
			</xsl:call-template>
		</xsl:element>
	</xsl:template>

	<xsl:template name="ParameterTableRow-Page">
		<xsl:call-template name="ParameterTableRow">
			<xsl:with-param name="Parameter" select="'page'"/>
			<xsl:with-param name="Type" select="'int'"/>
			<xsl:with-param name="Description"
				select="'The index of the page of data to retrieve. A value of 1 indicates the first page of data.'"
			/>
		</xsl:call-template>
	</xsl:template>

	<xsl:template name="ParameterTableRow-FK-PK">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName"
			select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
		<xsl:variable name="referencedClassName"
			select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:call-template name="ParameterTableRow">
			<xsl:with-param name="Parameter">
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input"
						select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"
					/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
			</xsl:with-param>
			<xsl:with-param name="Type"
				select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
			<xsl:with-param name="Description">
				<xsl:text>The foreign key identifier of the </xsl:text>
				<xsl:value-of select="$referencedClassName"/>
				<xsl:text> instance from which to retrieve the child </xsl:text>
				<xsl:value-of select="$parentPluralClassName"/>
				<xsl:text>.</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
	</xsl:template>

	<xsl:template name="ParameterTableRow">
		<xsl:param name="Parameter"/>
		<xsl:param name="Type"/>
		<xsl:param name="Description"/>

		<xsl:element name="tr">
			<xsl:call-template name="TableCell">
				<xsl:with-param name="Text" select="$Parameter"/>
			</xsl:call-template>
			<xsl:call-template name="TableCell">
				<xsl:with-param name="Text" select="$Type"/>
			</xsl:call-template>
			<xsl:call-template name="TableCell">
				<xsl:with-param name="Text" select="$Description"/>
			</xsl:call-template>
		</xsl:element>
	</xsl:template>
</xsl:stylesheet>
