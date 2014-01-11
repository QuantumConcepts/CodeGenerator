<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined" xmlns:common="remove" xmlns:asp="remove">
  <xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes"/>

  <xsl:include href="ServiceDocumentation-Common.xslt"/>

  <xsl:template match="P:Project">
    <xsl:text disable-output-escaping="yes"><![CDATA[<%@Control Language="C#" Inherits="System.Web.UI.UserControl" %>]]></xsl:text>
    <xsl:value-of select="$newLine"/>
    <xsl:value-of select="$newLine"/>
    <xsl:comment>This is a generated file. Any manual changes will be overwritten.</xsl:comment>
    <xsl:value-of select="$newLine"/>
    <xsl:value-of select="$newLine"/>

    <xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute[@Key='ServiceExposed']]">
      <xsl:sort select="@ClassName"/>

      <xsl:variable name="tableName" select="@TableName"/>
      <xsl:variable name="className" select="@ClassName"/>
      <xsl:variable name="pluralClassName" select="@PluralClassName"/>

      <xsl:element name="a">
        <xsl:attribute name="name">
          <xsl:value-of select="$className"/>
        </xsl:attribute>

        <xsl:text> </xsl:text>
      </xsl:element>

      <xsl:element name="h3">
        <xsl:attribute name="class">
          <xsl:text>Collapsible Header</xsl:text>
        </xsl:attribute>

        <xsl:value-of select="$className"/>
      </xsl:element>

      <xsl:element name="div">
        <xsl:attribute name="class">
          <xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
        </xsl:attribute>

        <xsl:element name="common:OptionalImage">
          <xsl:attribute name="runat">
            <xsl:text>server</xsl:text>
          </xsl:attribute>
          <xsl:attribute name="ImageUrl">
            <xsl:text>~/App_Resources/Images/ServiceTypes/</xsl:text>
            <xsl:value-of select="$tableName"/>
            <xsl:text>.png</xsl:text>
          </xsl:attribute>
          <xsl:attribute name="CssClass">
            <xsl:text>ServiceType</xsl:text>
          </xsl:attribute>
        </xsl:element>

        <xsl:if test="P:Annotations/P:Annotation[@Type='summary']">
          <xsl:element name="p">
            <xsl:value-of select="P:Annotations/P:Annotation[@Type='summary']/P:Text/text()"/>
          </xsl:element>
        </xsl:if>

        <xsl:element name="div">
          <xsl:attribute name="class">
            <xsl:text>TypeProperties</xsl:text>
          </xsl:attribute>

          <xsl:element name="table">
            <xsl:attribute name="summary">
              <xsl:text>Table describing the properties for </xsl:text>
              <xsl:value-of select="$className"/>
              <xsl:text>.</xsl:text>
            </xsl:attribute>

            <xsl:element name="thead">
              <xsl:element name="tr">
                <xsl:call-template name="TableHeaderCell">
                  <xsl:with-param name="Scope" select="'col'"/>
                  <xsl:with-param name="Text" select="'Property'"/>
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
            </xsl:element>

            <xsl:element name="tbody">
              <xsl:variable name="Properties">
                <xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
                  <xsl:element name="Property">
                    <xsl:attribute name="Name">
                      <xsl:value-of select="@FieldName"/>
                    </xsl:attribute>
                    <xsl:attribute name="Type">
                      <xsl:value-of select="@DataType"/>
                    </xsl:attribute>
                    <xsl:attribute name="Description">
                      <xsl:value-of select="P:Annotations/P:Annotation[@Type='summary']/P:Text/text()" />
                    </xsl:attribute>
                    <xsl:attribute name="IsID">
                      <xsl:value-of select="substring(@FieldName, string-length(@FieldName) - 1, 2) = 'ID'" />
                    </xsl:attribute>
                  </xsl:element>
                </xsl:for-each>
              </xsl:variable>

              <xsl:for-each select="msxsl:node-set($Properties)/Property">
                <xsl:sort select="@Name != 'ID'"/>
                <xsl:sort select="qc:If(@IsID, substring(@Name, 0, string-length(@Name) - 2), @Name)"/>
                <xsl:sort select="qc:If(@IsID, 1, 2)"/>

                <xsl:call-template name="PropertyTableRow">
                  <xsl:with-param name="FieldName" select="@Name"/>
                  <xsl:with-param name="Type" select="@Type"/>
                  <xsl:with-param name="Description" select="@Description"/>
                </xsl:call-template>
              </xsl:for-each>
            </xsl:element>
          </xsl:element>
        </xsl:element>
      </xsl:element>

      <xsl:element name="a">
        <xsl:attribute name="name">
          <xsl:value-of select="$className"/>
          <xsl:text>-Collection</xsl:text>
        </xsl:attribute>

        <xsl:text> </xsl:text>
      </xsl:element>

      <xsl:element name="h3">
        <xsl:attribute name="class">
          <xsl:text>Collapsible Header</xsl:text>
        </xsl:attribute>

        <xsl:value-of select="$className"/>
        <xsl:text> Collection</xsl:text>
      </xsl:element>

      <xsl:element name="div">
        <xsl:attribute name="class">
          <xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
        </xsl:attribute>

        <xsl:element name="p">
          <xsl:text>A collection of </xsl:text>
          <xsl:element name="a">
            <xsl:attribute name="href">
              <xsl:text>JavaScript: void(0);</xsl:text>
              <xsl:value-of select="$className"/>
            </xsl:attribute>
            <xsl:attribute name="onclick">
              <xsl:text>jumpTo('</xsl:text>
              <xsl:value-of select="$className"/>
              <xsl:text>');</xsl:text>
            </xsl:attribute>

            <xsl:value-of select="$pluralClassName"/>
          </xsl:element>
          <xsl:text>.</xsl:text>
        </xsl:element>
      </xsl:element>
    </xsl:for-each>
    <xsl:value-of select="$newLine"/>
    <xsl:value-of select="$newLine"/>
  </xsl:template>

  <xsl:template name="PropertyTableRow">
    <xsl:param name="FieldName"/>
    <xsl:param name="Description"/>
    <xsl:param name="Type"/>

    <xsl:element name="tr">
      <xsl:call-template name="TableCell">
        <xsl:with-param name="Text" select="$FieldName"/>
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
