<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
  <xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes"/>

  <xsl:include href="ServiceDocumentation-Common.xslt"/>

  <xsl:template match="Diff">
    <xsl:call-template name="SectionHeader">
      <xsl:with-param name="title" select="'Service Method Changes'"/>
    </xsl:call-template>

    <xsl:element name="div">
      <xsl:attribute name="class">Collapsible Content</xsl:attribute>
      <xsl:apply-templates select="Method" mode="Root"/>
    </xsl:element>

    <xsl:call-template name="SectionHeader">
      <xsl:with-param name="title" select="'Service Type Changes'"/>
    </xsl:call-template>

    <xsl:element name="div">
      <xsl:attribute name="class">Collapsible Content</xsl:attribute>
      <xsl:apply-templates select="Type" mode="Root"/>
    </xsl:element>
  </xsl:template>

  <xsl:template name="SectionHeader">
    <xsl:param name="title"/>
    
    <xsl:element name="h3">
      <xsl:attribute name="class">Label Collapsible Header</xsl:attribute>

      <xsl:element name="span">
        <xsl:attribute name="class">Status</xsl:attribute>
        <xsl:text>Status</xsl:text>
      </xsl:element>

      <xsl:element name="span">
        <xsl:attribute name="class">Severity</xsl:attribute>
        <xsl:text>Severity</xsl:text>
      </xsl:element>

      <xsl:value-of select="$title"/>
    </xsl:element>
  </xsl:template>
  
  <xsl:template match="Method" mode="Root">
    <xsl:call-template name="ResultHeader">
      <xsl:with-param name="AnchorPrefix" select="'Method'"/>
      <xsl:with-param name="Title" select="qc:IsNull(Source, Target)/@Resource"/>
    </xsl:call-template>

    <xsl:element name="div">
      <xsl:attribute name="class">
        <xsl:text>Collapsible Content Collapsed</xsl:text>
      </xsl:attribute>

      <xsl:call-template name="Messages"/>
      <xsl:call-template name="Parameters"/>
      <xsl:apply-templates select="." mode="Internal"/>
    </xsl:element>
  </xsl:template>

  <xsl:template match="Method[@Status='Removed']" mode="Internal">
    <xsl:call-template name="MethodOverview">
      <xsl:with-param name="Title" select="Source/@Resource"/>
      <xsl:with-param name="RESTURI" select="Source/@RestURI"/>
      <xsl:with-param name="SOAPMethod" select="Source/@SoapMethod"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="Method[@Status='Added']" mode="Internal">
    <xsl:call-template name="MethodOverview">
      <xsl:with-param name="Title" select="Target/@Resource"/>
      <xsl:with-param name="RESTURI" select="Target/@RestURI"/>
      <xsl:with-param name="SOAPMethod" select="Target/@SoapMethod"/>
    </xsl:call-template>

    <xsl:call-template name="MethodMoreInfoLink">
      <xsl:with-param name="resource" select="Target/@Resource"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="Method[@Status='Changed']" mode="Internal">
    <xsl:if test="Source and Target">
      <xsl:element name="h4">Previous Version</xsl:element>

      <xsl:call-template name="MethodOverview">
        <xsl:with-param name="Title" select="Source/@Resource"/>
        <xsl:with-param name="RESTURI" select="Source/@RestURI"/>
        <xsl:with-param name="SOAPMethod" select="Source/@SoapMethod"/>
      </xsl:call-template>

      <xsl:element name="h4">New Version</xsl:element>

      <xsl:call-template name="MethodOverview">
        <xsl:with-param name="Title" select="Target/@Resource"/>
        <xsl:with-param name="RESTURI" select="Target/@RestURI"/>
        <xsl:with-param name="SOAPMethod" select="Target/@SoapMethod"/>
      </xsl:call-template>
    </xsl:if>

    <xsl:call-template name="Parameters"/>

    <xsl:if test="//Type/Target/@Name=./OutputParameter/Target/@Type">
      <xsl:call-template name="MethodOutputParameterMoreInfoLink">
        <xsl:with-param name="resource" select="OutputParameter/Target/@Type"/>
      </xsl:call-template>
    </xsl:if>

    <xsl:call-template name="MethodMoreInfoLink">
      <xsl:with-param name="resource" select="Target/@Resource"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="Method[@Status='NotChanged']" mode="Internal">
    <xsl:call-template name="Parameters"/>

    <xsl:call-template name="MethodMoreInfoLink">
      <xsl:with-param name="resource" select="Target/@Resource"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="Type" mode="Root">
    <xsl:call-template name="ResultHeader">
      <xsl:with-param name="AnchorPrefix" select="'Type'"/>
      <xsl:with-param name="Title" select="qc:IsNull(Source, Target)/@Name"/>
    </xsl:call-template>

    <xsl:element name="div">
      <xsl:attribute name="class">
        <xsl:text>Collapsible Content Collapsed</xsl:text>
      </xsl:attribute>

      <xsl:call-template name="Messages"/>
      <xsl:call-template name="Properties"/>
      <xsl:apply-templates select="." mode="Internal"/>
    </xsl:element>
  </xsl:template>

  <xsl:template match="Type[@Status='Added' or @Status='Changed']" mode="Internal">
    <xsl:call-template name="TypeMoreInfoLink">
      <xsl:with-param name="resource" select="Target/@Name"/>
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template name="ResultHeader">
    <xsl:param name="AnchorPrefix"/>
    <xsl:param name="Title"/>

    <xsl:element name="a">
      <xsl:attribute name="name">
        <xsl:value-of select="$AnchorPrefix"/>
        <xsl:text>-</xsl:text>
        <xsl:value-of select="qc:Replace($Title, ' ', '-')"/>
      </xsl:attribute>
    </xsl:element>
    
    <xsl:element name="h4">
      <xsl:attribute name="class">
        <xsl:text>Collapsible Header </xsl:text>
        <xsl:value-of select="@Status"/>
        <xsl:text> </xsl:text>
        <xsl:value-of select="@Severity"/>
      </xsl:attribute>

      <xsl:if test="@Status='Added' or @Status='Removed' or @Status='Changed'">
        <xsl:element name="span">
          <xsl:attribute name="class">Status</xsl:attribute>
          <xsl:value-of select="@StatusName"/>
        </xsl:element>
      </xsl:if>

      <xsl:if test="@Severity='NonBreaking' or @Severity='Indeterminate' or @Severity='Breaking'">
        <xsl:element name="span">
          <xsl:attribute name="class">Severity</xsl:attribute>
          <xsl:value-of select="@SeverityName"/>
        </xsl:element>
      </xsl:if>

      <xsl:value-of select="$Title"/>
    </xsl:element>
  </xsl:template>

  <xsl:template name="Messages">
    <xsl:if test="Message">
      <xsl:element name="ul">
        <xsl:attribute name="class">Messages</xsl:attribute>

        <xsl:for-each select="Message">
          <xsl:element name="li">
            <xsl:value-of select="text()"/>
          </xsl:element>
        </xsl:for-each>
      </xsl:element>
    </xsl:if>
  </xsl:template>

  <xsl:template name="MethodOverview">
    <xsl:param name="Title"/>
    <xsl:param name="Description"/>
    <xsl:param name="RESTURI"/>
    <xsl:param name="RESTVerb"/>
    <xsl:param name="SOAPMethod"/>
    <xsl:param name="Output"/>
    <xsl:param name="CopyOutput" select="false()"/>

    <xsl:if test="$Description!=''">
      <xsl:element name="p">
        <xsl:value-of select="$Description"/>
      </xsl:element>
    </xsl:if>

    <xsl:element name="div">
      <xsl:attribute name="class">
        <xsl:text>MethodTable</xsl:text>
      </xsl:attribute>

      <xsl:call-template name="OverviewTable">
        <xsl:with-param name="Title" select="$Title"/>
        <xsl:with-param name="RESTVerb" select="$RESTVerb"/>
        <xsl:with-param name="RESTURI" select="$RESTURI"/>
        <xsl:with-param name="SOAPMethod" select="$SOAPMethod"/>
        <xsl:with-param name="Output" select="$Output"/>
        <xsl:with-param name="CopyOutput" select="$CopyOutput"/>
      </xsl:call-template>
    </xsl:element>
  </xsl:template>

  <xsl:template name="MethodMoreInfoLink">
    <xsl:param name="resource"/>

    <xsl:text>For more information regarding this service method, please view the </xsl:text>
    <xsl:element name="a">
      <xsl:attribute name="href">
        <xsl:text>ServiceMethods#</xsl:text>
        <xsl:value-of select="qc:Replace($resource, ' ', '-')"/>
      </xsl:attribute>

      <xsl:text>service method documentation</xsl:text>
    </xsl:element>
    <xsl:text>.</xsl:text>
  </xsl:template>

  <xsl:template name="MethodOutputParameterMoreInfoLink">
    <xsl:param name="resource"/>

    <xsl:text>Please view the </xsl:text>
    <xsl:element name="a">
      <xsl:attribute name="href">
        <xsl:text>JavaScript:void(0);</xsl:text>
      </xsl:attribute>
      <xsl:attribute name="onclick">
        <xsl:text>jumpTo("Type-</xsl:text>
        <xsl:value-of select="qc:Replace($resource, ' ', '-')"/>
        <xsl:text>");</xsl:text>
      </xsl:attribute>

      <xsl:value-of select="$resource"/>
      <xsl:text> changes</xsl:text>
    </xsl:element>
    <xsl:text> for more information.</xsl:text>
  </xsl:template>

  <xsl:template name="TypeMoreInfoLink">
    <xsl:param name="resource"/>

    <xsl:text>For more information regarding this service type and related service methods, please view the </xsl:text>
    <xsl:element name="a">
      <xsl:attribute name="href">
        <xsl:text>ServiceTypes#</xsl:text>
        <xsl:value-of select="qc:Replace($resource, ' ', '-')"/>
      </xsl:attribute>

      <xsl:text>service type documentation</xsl:text>
    </xsl:element>
    <xsl:text>.</xsl:text>
  </xsl:template>

  <xsl:template name="Parameters">
    <xsl:if test="Parameter">
      <xsl:element name="div">
        <xsl:attribute name="class">
          <xsl:text>MethodParameters</xsl:text>
        </xsl:attribute>

        <xsl:element name="table">
          <xsl:attribute name="summary">
            <xsl:text>Table describing the changes which have been made to the parameters for </xsl:text>
            <xsl:value-of select="Target/@Resource"/>
            <xsl:text>.</xsl:text>
          </xsl:attribute>

          <xsl:element name="thead">
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
                <xsl:with-param name="Text" select="'Messages'"/>
              </xsl:call-template>
            </xsl:element>
          </xsl:element>

          <xsl:element name="tbody">
            <xsl:apply-templates />
          </xsl:element>
        </xsl:element>
      </xsl:element>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Parameter">
    <xsl:element name="tr">
      <xsl:attribute name="class">
        <xsl:value-of select="@Status"/>
        <xsl:text> </xsl:text>
        <xsl:value-of select="@Severity"/>
      </xsl:attribute>

      <xsl:call-template name="TableCell">
        <xsl:with-param name="Text" select="qc:IsNull(Target, Source)/@Name"/>
      </xsl:call-template>
      <xsl:call-template name="TableCell">
        <xsl:with-param name="Text" select="qc:IsNull(Target, Source)/@Type"/>
      </xsl:call-template>
      <xsl:element name="td">
        <xsl:call-template name="Messages"/>
      </xsl:element>
    </xsl:element>
  </xsl:template>

  <xsl:template name="Properties">
    <xsl:if test="Property">
      <xsl:element name="div">
        <xsl:attribute name="class">
          <xsl:text>TypeProperties</xsl:text>
        </xsl:attribute>

        <xsl:element name="table">
          <xsl:attribute name="summary">
            <xsl:text>Table describing the properties for </xsl:text>
            <xsl:value-of select="Target/@Name"/>
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
                <xsl:with-param name="Text" select="'Messages'"/>
              </xsl:call-template>
            </xsl:element>
          </xsl:element>

          <xsl:element name="tbody">
            <xsl:apply-templates />
          </xsl:element>
        </xsl:element>
      </xsl:element>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Property">
    <xsl:element name="tr">
      <xsl:attribute name="class">
        <xsl:value-of select="@Status"/>
        <xsl:text> </xsl:text>
        <xsl:value-of select="@Severity"/>
      </xsl:attribute>

      <xsl:call-template name="TableCell">
        <xsl:with-param name="Text" select="qc:IsNull(Target, Source)/@Name"/>
      </xsl:call-template>
      <xsl:call-template name="TableCell">
        <xsl:with-param name="Text" select="qc:IsNull(Target, Source)/@Type"/>
      </xsl:call-template>
      <xsl:element name="td">
        <xsl:attribute name="class">Messages</xsl:attribute>
        
        <xsl:if test="@Status='Added' or @Status='Removed' or @Status='Changed'">
          <xsl:element name="span">
            <xsl:attribute name="class">Status</xsl:attribute>
            <xsl:value-of select="@StatusName"/>
          </xsl:element>
        </xsl:if>

        <xsl:if test="@Severity='NonBreaking' or @Severity='Indeterminate' or @Severity='Breaking'">
          <xsl:element name="span">
            <xsl:attribute name="class">Severity</xsl:attribute>
            <xsl:value-of select="@SeverityName"/>
          </xsl:element>
        </xsl:if>
        
        <xsl:call-template name="Messages"/>
      </xsl:element>
    </xsl:element>
  </xsl:template>
  
  <xsl:template match="text()" />

  <xsl:template match="text()" mode="Internal" />
</xsl:stylesheet>
