<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">	
	<xsl:include href="../CSharp/Common.xslt"/>

	<xsl:template name="Razor-Using">
		<xsl:param name="alias"/>
		<xsl:param name="namespace"/>
		
		<xsl:text>@</xsl:text>
		
		<xsl:call-template name="Using">
			<xsl:with-param name="alias" select="$alias"/>
			<xsl:with-param name="namespace" select="$namespace"/>
		</xsl:call-template>
	</xsl:template>


  <xsl:template name="Razor-Using-System">
    <xsl:text>@</xsl:text>

    <xsl:call-template name="Using-System"/>
  </xsl:template>

  <xsl:template name="Razor-Using-System-Collections">
    <xsl:text>@</xsl:text>

    <xsl:call-template name="Using-System-Collections"/>
  </xsl:template>

  <xsl:template name="Razor-Using-System-Linq">
    <xsl:text>@</xsl:text>

    <xsl:call-template name="Using-System-Linq"/>
  </xsl:template>

  <xsl:template name="Razor-Using-System-All">
    <xsl:call-template name="Razor-Using-System"/>
    <xsl:call-template name="Razor-Using-System-Collections"/>
    <xsl:call-template name="Razor-Using-System-Linq"/>
  </xsl:template>

  <xsl:template name="Razor-Using-Project">
    <xsl:for-each select="/P:Project/P:Attributes/P:Attribute[@Key='Using']">
      <xsl:call-template name="Razor-Using">
        <xsl:with-param name="namespace" select="@Value"/>
      </xsl:call-template>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="Razor-Using-Template">
    <xsl:param name="template"/>

    <xsl:for-each select="$template/P:Attributes/P:Attribute[@Key='Using']">
      <xsl:call-template name="Razor-Using">
        <xsl:with-param name="namespace" select="@Value"/>
      </xsl:call-template>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="Razor-Using-All">
    <xsl:param name="template"/>

    <xsl:call-template name="Razor-Using-System-All"/>
    <xsl:call-template name="Razor-Using-Project"/>
    <xsl:call-template name="Razor-Using-Template">
      <xsl:with-param name="Template" select="$template"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>