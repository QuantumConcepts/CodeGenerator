<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined" xmlns:asp="remove" xmlns:Ajax="remove" xmlns:Common="remove">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	<xsl:param name="elementName"/>
	
	<xsl:template match="P:Project">
		<xsl:variable name="table" select="P:TableMappings/P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
		
		<xsl:text disable-output-escaping="yes"><![CDATA[<%@ Control CodeBehind="]]></xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>List.ascx.cs" Inherits="</xsl:text>
		<xsl:value-of select="@RootNamespace"/>
		<xsl:text>.Web.WebControls.</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text disable-output-escaping="yes"><![CDATA[List" Language="C#" %>

]]></xsl:text>
		
		<xsl:element name="asp:DataGrid">
			<xsl:attribute name="id">
				<xsl:text>Grid</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="runat">
				<xsl:text>server</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="DataKeyField">
				<xsl:value-of select="$table/P:ColumnMappings/P:ColumnMapping[@PrimaryKey='true']/@FieldName"/>
			</xsl:attribute>
			<xsl:attribute name="AutoGenerateColumns">
				<xsl:text>false</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="CssClass">
				<xsl:text>Grid</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="HeaderStyle-CssClass">
				<xsl:text>Header</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="AlternatingItemStyle-CssClass">
				<xsl:text>Alternate</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="OnItemCommand">
				<xsl:text>Grid_ItemCommand</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="OnNeedsDataBinding">
				<xsl:text>Grid_NeedsDataBinding</xsl:text>
			</xsl:attribute>
			
			<xsl:element namespace="asp" name="Columns">
				<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
					<xsl:variable name="columnName" select="@ColumnName"/>
					<xsl:variable name="fk" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
					<xsl:variable name="displayName">
						<xsl:choose>
							<xsl:when test="$fk">
								<xsl:value-of select="$fk/P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:variable>
					
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:element name="asp:TemplateColumn">
								<xsl:attribute name="HeaderText">
									<xsl:value-of select="$displayName"/>
								</xsl:attribute>
								<xsl:attribute name="HeaderStyle-Width">
									<xsl:text>150px</xsl:text>
								</xsl:attribute>
								<xsl:attribute name="ItemStyle-Width">
									<xsl:text>150px</xsl:text>
								</xsl:attribute>
								
								<xsl:element namespace="asp" name="ItemTemplate">
									<xsl:text disable-output-escaping="yes"><![CDATA[<%# Enum.GetName(typeof(]]></xsl:text>
									<xsl:value-of select="/P:Project/@RootNamespace"/>
									<xsl:text>.DataObjects.</xsl:text>
									<xsl:value-of select="P:EnumerationMapping/@Name"/>
									<xsl:text>), Eval("</xsl:text>
									<xsl:value-of select="@FieldName"/>
									<xsl:text disable-output-escaping="yes"><![CDATA[")) %>]]></xsl:text>
								</xsl:element>
							</xsl:element>
						</xsl:when>
						<xsl:when test="$fk">
							<xsl:element name="asp:BoundColumn">
								<xsl:attribute name="HeaderText">
									<xsl:value-of select="$displayName"/>
								</xsl:attribute>
								<xsl:attribute name="DataField">
									<xsl:value-of select="$fk/@PropertyName"/>
								</xsl:attribute>
							</xsl:element>
						</xsl:when>
						<xsl:otherwise>
							<xsl:element name="asp:BoundColumn">
								<xsl:attribute name="HeaderText">
									<xsl:value-of select="$displayName"/>
								</xsl:attribute>
								<xsl:attribute name="DataField">
									<xsl:value-of select="@FieldName"/>
								</xsl:attribute>
								
								<xsl:choose>
									<xsl:when test="@PrimaryKey='true'">
										<xsl:attribute name="HeaderStyle-Width">
											<xsl:text>50px</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="ItemStyle-Width">
											<xsl:text>50px</xsl:text>
										</xsl:attribute>
									</xsl:when>
									<xsl:when test="@DataType='int' or @DataType='decimal'">
										<xsl:attribute name="HeaderStyle-CssClass">
											<xsl:text>Numeric</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="ItemStyle-CssClass">
											<xsl:text>Numeric</xsl:text>
										</xsl:attribute>
									</xsl:when>
									<xsl:when test="@DataType='DateTime'">
										<xsl:attribute name="HeaderStyle-Width">
											<xsl:text>150px</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="ItemStyle-Width">
											<xsl:text>150px</xsl:text>
										</xsl:attribute>
									</xsl:when>
									<xsl:when test="@DataType='bool'">
										<xsl:attribute name="HeaderStyle-Width">
											<xsl:text>50px</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="ItemStyle-Width">
											<xsl:text>50px</xsl:text>
										</xsl:attribute>
									</xsl:when>
								</xsl:choose>
							</xsl:element>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:for-each>
				
				<xsl:element name="asp:ButtonColumn">
					<xsl:attribute name="Text">
						<xsl:text>Edit</xsl:text>
					</xsl:attribute>
					<xsl:attribute name="CommandName">
						<xsl:text>Edit</xsl:text>
					</xsl:attribute>
					<xsl:attribute name="ButtonType">
						<xsl:text>LinkButton</xsl:text>
					</xsl:attribute>
					<xsl:attribute name="HeaderStyle-CssClass">
						<xsl:text>Action</xsl:text>
					</xsl:attribute>
					<xsl:attribute name="ItemStyle-CssClass">
						<xsl:text>Action</xsl:text>
					</xsl:attribute>
				</xsl:element>
				
				<xsl:element name="asp:ButtonColumn">
					<xsl:attribute name="Text">
						<xsl:text>Delete</xsl:text>
					</xsl:attribute>
					<xsl:attribute name="CommandName">
						<xsl:text>Delete</xsl:text>
					</xsl:attribute>
					<xsl:attribute name="ButtonType">
						<xsl:text>LinkButton</xsl:text>
					</xsl:attribute>
					<xsl:attribute name="HeaderStyle-CssClass">
						<xsl:text>Action</xsl:text>
					</xsl:attribute>
					<xsl:attribute name="ItemStyle-CssClass">
						<xsl:text>Action</xsl:text>
					</xsl:attribute>
				</xsl:element>
			</xsl:element>
		</xsl:element>
	</xsl:template>
</xsl:stylesheet>