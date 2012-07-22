<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined" xmlns:asp="remove" xmlns:Ajax="remove" xmlns:Common="remove">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	<xsl:param name="elementName"/>
	
	<xsl:template match="P:Project">
		<xsl:variable name="table" select="P:TableMappings/P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
		
		<xsl:text disable-output-escaping="yes"><![CDATA[<%@ Control CodeBehind="Edit]]></xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>.ascx.cs" Inherits="</xsl:text>
		<xsl:value-of select="@RootNamespace"/>
		<xsl:text>.Web.WebControls.Edit</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text disable-output-escaping="yes"><![CDATA[" Language="C#" %>

]]></xsl:text>
		
			<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false']">
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
				
				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>Field</xsl:text>
					</xsl:attribute>
					
					<xsl:element name="span">
						<xsl:attribute name="class">
							<xsl:text>Label</xsl:text>
						</xsl:attribute>
						
						<xsl:value-of select="$displayName"/>
						<xsl:text>:</xsl:text>
					</xsl:element>
					<xsl:element name="span">
						<xsl:attribute name="class">
							<xsl:text>Input</xsl:text>
						</xsl:attribute>
						
						<xsl:choose>
							<xsl:when test="P:EnumerationMapping or $fk">
								<xsl:variable name="fieldName">
									<xsl:choose>
										<xsl:when test="P:EnumerationMapping">
											<xsl:value-of select="P:EnumerationMapping/@Name"/>
										</xsl:when>
										<xsl:when test="$fk">
											<xsl:value-of select="$fk/@PropertyName"/>
										</xsl:when>
									</xsl:choose>
									
									<xsl:text>Field</xsl:text>
								</xsl:variable>
								
								<xsl:element name="asp:DropDownList">
									<xsl:attribute name="ID">
										<xsl:value-of select="$fieldName"/>
									</xsl:attribute>
									<xsl:attribute name="runat">
										<xsl:text>server</xsl:text>
									</xsl:attribute>
									<xsl:attribute name="AppendDataBoundItems">
										<xsl:text>true</xsl:text>
									</xsl:attribute>
									
									<xsl:attribute name="DataValueField">
										<xsl:choose>
											<xsl:when test="$fk">
												<xsl:text>ID</xsl:text>
											</xsl:when>
										</xsl:choose>
									</xsl:attribute>
									
									<xsl:attribute name="DataTextField">
										<xsl:choose>
											<xsl:when test="$fk">
												<xsl:value-of select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$fk/@ReferencedTableMappingName]/P:Attributes/P:Attribute[@Key='DisplayField']/@Value"/>
											</xsl:when>
										</xsl:choose>
									</xsl:attribute>
									
									<xsl:if test="@Nullable='true'">
										<xsl:element name="asp:ListItem">
											<xsl:attribute name="Text">
												<xsl:text>(None)</xsl:text>
											</xsl:attribute>
										</xsl:element>
									</xsl:if>
								</xsl:element>
							</xsl:when>
							<xsl:when test="@DataType='string'">
								<xsl:element name="asp:TextBox">
									<xsl:attribute name="ID">
										<xsl:value-of select="@FieldName"/>
										<xsl:text>Field</xsl:text>
									</xsl:attribute>
									<xsl:attribute name="runat">
										<xsl:text>server</xsl:text>
									</xsl:attribute>
								</xsl:element>
								
								<xsl:if test="P:Attributes/P:Attribute[@Key='FieldMask']">
									<xsl:element name="Ajax:MaskedEditExtender">
										<xsl:attribute name="ID">
											<xsl:value-of select="@FieldName"/>
											<xsl:text>MaskedEditExtender</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="runat">
											<xsl:text>server</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="TargetControlID">
											<xsl:value-of select="@FieldName"/>
											<xsl:text>Field</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="Mask">
											<xsl:value-of select="P:Attributes/P:Attribute[@Key='FieldMask']/@Value"/>
										</xsl:attribute>
										<xsl:attribute name="ClearMaskOnLostFocus">
											<xsl:text>false</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="ClearTextOnInvalid">
											<xsl:text>true</xsl:text>
										</xsl:attribute>
									</xsl:element>
								</xsl:if>
								
								<xsl:if test="@Nullable='false'">
									<xsl:element name="asp:RequiredFieldValidator">
										<xsl:attribute name="ID">
											<xsl:value-of select="@FieldName"/>
											<xsl:text>Validator</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="runat">
											<xsl:text>server</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="ControlToValidate">
											<xsl:value-of select="@FieldName"/>
											<xsl:text>Field</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="ErrorMessage">
											<xsl:text>The </xsl:text>
											<xsl:value-of select="$displayName"/>
											<xsl:text> field is invalid.</xsl:text>
										</xsl:attribute>
										<xsl:attribute name="Required">
											<xsl:text>true</xsl:text>
										</xsl:attribute>
									</xsl:element>
								</xsl:if>
							</xsl:when>
							<xsl:when test="@DataType='bool'">
								<xsl:element name="asp:CheckBox">
									<xsl:attribute name="ID">
										<xsl:value-of select="@FieldName"/>
										<xsl:text>Field</xsl:text>
									</xsl:attribute>
									<xsl:attribute name="runat">
										<xsl:text>server</xsl:text>
									</xsl:attribute>
								</xsl:element>
							</xsl:when>
							<xsl:when test="@DataType='DateTime'">
								<xsl:element name="asp:Calendar">
									<xsl:attribute name="ID">
										<xsl:value-of select="@FieldName"/>
										<xsl:text>Field</xsl:text>
									</xsl:attribute>
									<xsl:attribute name="runat">
										<xsl:text>server</xsl:text>
									</xsl:attribute>
								</xsl:element>
							</xsl:when>
						</xsl:choose>
					</xsl:element>
				</xsl:element>
			</xsl:for-each>
			
		<xsl:element name="div">
			<xsl:attribute name="class">
				<xsl:text>Actions</xsl:text>
			</xsl:attribute>
			
			<xsl:element name="asp:LinkButton">
				<xsl:attribute name="ID">
					<xsl:text>SaveButton</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="runat">
					<xsl:text>server</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="Text">
					<xsl:text>Save</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="CssClass">
					<xsl:text>Action Accept</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="OnClick">
					<xsl:text>SaveButton_Click</xsl:text>
				</xsl:attribute>
			</xsl:element>
			
			<xsl:element name="asp:LinkButton">
				<xsl:attribute name="ID">
					<xsl:text>CancelButton</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="runat">
					<xsl:text>server</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="Text">
					<xsl:text>Cancel</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="CssClass">
					<xsl:text>Action Cancel</xsl:text>
				</xsl:attribute>
				<xsl:attribute name="OnClick">
					<xsl:text>CancelButton_Click</xsl:text>
				</xsl:attribute>
			</xsl:element>
		</xsl:element>
	</xsl:template>
</xsl:stylesheet>
