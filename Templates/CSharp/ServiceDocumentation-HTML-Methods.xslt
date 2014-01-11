<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:asp="remove" xmlns:ACT="remove" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes"/>

	<xsl:include href="ServiceDocumentation-Common.xslt"/>

	<xsl:template match="P:Project">
		<xsl:comment>This is a generated file. Any manual changes will be overwritten.</xsl:comment>
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$newLine"/>

		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed']">
			<xsl:sort select="@ClassName"/>
			<xsl:variable name="TableName" select="@TableName"/>

      <xsl:call-template name="Anchor">
        <xsl:with-param name="resource" select="@ClassName"/>
      </xsl:call-template>
      
			<xsl:element name="h3">
				<xsl:attribute name="class">
					<xsl:text>Collapsible Header</xsl:text>
				</xsl:attribute>

				<xsl:value-of select="@ClassName"/>
			</xsl:element>

			<xsl:element name="div">
				<xsl:attribute name="class">
					<xsl:text>Collapsible Content Collapsed</xsl:text>
				</xsl:attribute>

				<!--All-->
        <xsl:call-template name="Anchor">
          <xsl:with-param name="resource">
            <xsl:call-template name="Doc-All-Title"/>
          </xsl:with-param>
        </xsl:call-template>
				
				<xsl:element name="h4">
					<xsl:attribute name="class">
						<xsl:text>Collapsible Header</xsl:text>
					</xsl:attribute>

					<xsl:call-template name="Doc-All-Title"/>
				</xsl:element>

				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
					</xsl:attribute>

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
										<xsl:text>ServiceTypes#</xsl:text>
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
        <xsl:call-template name="Anchor">
          <xsl:with-param name="resource">
            <xsl:call-template name="Doc-AllCount-Title"/>
          </xsl:with-param>
        </xsl:call-template>

				<xsl:element name="h4">
					<xsl:attribute name="class">
						<xsl:text>Collapsible Header</xsl:text>
					</xsl:attribute>

					<xsl:call-template name="Doc-AllCount-Title"/>
				</xsl:element>

				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
					</xsl:attribute>

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
        <xsl:call-template name="Anchor">
          <xsl:with-param name="resource">
            <xsl:call-template name="Doc-AllPageCount-Title"/>
          </xsl:with-param>
        </xsl:call-template>

				<xsl:element name="h4">
					<xsl:attribute name="class">
						<xsl:text>Collapsible Header</xsl:text>
					</xsl:attribute>

					<xsl:call-template name="Doc-AllPageCount-Title"/>
				</xsl:element>

				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
					</xsl:attribute>

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
        <xsl:call-template name="Anchor">
          <xsl:with-param name="resource">
            <xsl:call-template name="Doc-PK-Title"/>
          </xsl:with-param>
        </xsl:call-template>

				<xsl:element name="h4">
					<xsl:attribute name="class">
						<xsl:text>Collapsible Header</xsl:text>
					</xsl:attribute>

					<xsl:call-template name="Doc-PK-Title"/>
				</xsl:element>

				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
					</xsl:attribute>

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
										<xsl:text>ServiceTypes#</xsl:text>
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

				<!--Filter-->
        <xsl:call-template name="Anchor">
          <xsl:with-param name="resource">
            <xsl:call-template name="Doc-Filter-Title"/>
          </xsl:with-param>
        </xsl:call-template>

				<xsl:element name="h4">
					<xsl:attribute name="class">
						<xsl:text>Collapsible Header</xsl:text>
					</xsl:attribute>

					<xsl:call-template name="Doc-Filter-Title"/>
				</xsl:element>

				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
					</xsl:attribute>

					<xsl:element name="p">
						<xsl:call-template name="Doc-Filter-Description"/>
					</xsl:element>

					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodTable</xsl:text>
						</xsl:attribute>

						<xsl:call-template name="OverviewTable">
							<xsl:with-param name="Title">
								<xsl:call-template name="Doc-Filter-Title"/>
							</xsl:with-param>
							<xsl:with-param name="RESTURI">
								<xsl:call-template name="Doc-Filter-RESTURI"/>
							</xsl:with-param>
							<xsl:with-param name="RESTVerb">
								<xsl:text>POST</xsl:text>
							</xsl:with-param>
							<xsl:with-param name="SOAPMethod">
								<xsl:call-template name="Doc-Filter-SOAPMethod"/>
							</xsl:with-param>
							<xsl:with-param name="Output">
								<xsl:element name="a">
									<xsl:attribute name="href">
										<xsl:text>ServiceTypes#</xsl:text>
										<xsl:value-of select="@ClassName"/>
										<xsl:text>-Collection</xsl:text>
									</xsl:attribute>

									<xsl:call-template name="Doc-Filter-Output"/>
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
								<xsl:call-template name="Doc-Filter-Title"/>
								<xsl:text>.</xsl:text>
							</xsl:attribute>

							<xsl:element name="thead">
								<xsl:call-template name="ParameterTableHeader"/>
							</xsl:element>

							<xsl:element name="tbody">
								<xsl:call-template name="ParameterTableRow-Filter-Query"/>
								<xsl:call-template name="ParameterTableRow-Page"/>
							</xsl:element>
						</xsl:element>
					</xsl:element>
				</xsl:element>
				<!--END Filter-->

				<!--Filter Count-->
        <xsl:call-template name="Anchor">
          <xsl:with-param name="resource">
            <xsl:call-template name="Doc-FilterCount-Title"/>
          </xsl:with-param>
        </xsl:call-template>

				<xsl:element name="h4">
					<xsl:attribute name="class">
						<xsl:text>Collapsible Header</xsl:text>
					</xsl:attribute>

					<xsl:call-template name="Doc-FilterCount-Title"/>
				</xsl:element>

				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
					</xsl:attribute>

					<xsl:element name="p">
						<xsl:call-template name="Doc-FilterCount-Description"/>
					</xsl:element>

					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodTable</xsl:text>
						</xsl:attribute>

						<xsl:call-template name="OverviewTable">
							<xsl:with-param name="Title">
								<xsl:call-template name="Doc-FilterCount-Title"/>
							</xsl:with-param>
							<xsl:with-param name="RESTURI">
								<xsl:call-template name="Doc-FilterCount-RESTURI"/>
							</xsl:with-param>
							<xsl:with-param name="RESTVerb">
								<xsl:text>POST</xsl:text>
							</xsl:with-param>
							<xsl:with-param name="SOAPMethod">
								<xsl:call-template name="Doc-FilterCount-SOAPMethod"/>
							</xsl:with-param>
							<xsl:with-param name="Output">
								<xsl:call-template name="Doc-FilterCount-Output"/>
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
								<xsl:call-template name="Doc-FilterCount-Title"/>
								<xsl:text>.</xsl:text>
							</xsl:attribute>

							<xsl:element name="thead">
								<xsl:call-template name="ParameterTableHeader"/>
							</xsl:element>

							<xsl:element name="tbody">
								<xsl:call-template name="ParameterTableRow-Filter-Query"/>
							</xsl:element>
						</xsl:element>
					</xsl:element>
				</xsl:element>
				<!--END Filter Count-->

				<!--Filter Page Count-->
        <xsl:call-template name="Anchor">
          <xsl:with-param name="resource">
            <xsl:call-template name="Doc-FilterPageCount-Title"/>
          </xsl:with-param>
        </xsl:call-template>

				<xsl:element name="h4">
					<xsl:attribute name="class">
						<xsl:text>Collapsible Header</xsl:text>
					</xsl:attribute>

					<xsl:call-template name="Doc-FilterPageCount-Title"/>
				</xsl:element>

				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
					</xsl:attribute>

					<xsl:element name="p">
						<xsl:call-template name="Doc-FilterPageCount-Description"/>
					</xsl:element>

					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodTable</xsl:text>
						</xsl:attribute>

						<xsl:call-template name="OverviewTable">
							<xsl:with-param name="Title">
								<xsl:call-template name="Doc-FilterPageCount-Title"/>
							</xsl:with-param>
							<xsl:with-param name="RESTURI">
								<xsl:call-template name="Doc-FilterPageCount-RESTURI"/>
							</xsl:with-param>
							<xsl:with-param name="RESTVerb">
								<xsl:text>POST</xsl:text>
							</xsl:with-param>
							<xsl:with-param name="SOAPMethod">
								<xsl:call-template name="Doc-FilterPageCount-SOAPMethod"/>
							</xsl:with-param>
							<xsl:with-param name="Output">
								<xsl:call-template name="Doc-FilterPageCount-Output"/>
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
								<xsl:call-template name="Doc-FilterPageCount-Title"/>
								<xsl:text>.</xsl:text>
							</xsl:attribute>

							<xsl:element name="thead">
								<xsl:call-template name="ParameterTableHeader"/>
							</xsl:element>

							<xsl:element name="tbody">
								<xsl:call-template name="ParameterTableRow-Filter-Query"/>
							</xsl:element>
						</xsl:element>
					</xsl:element>
				</xsl:element>
				<!--END Filter Page Count-->

				<!--FK-->
				<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed' and @ParentTableMappingName=$TableName]">
					<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
					<xsl:variable name="parentTable" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]"/>

					<!--FK-->
          <xsl:call-template name="Anchor">
            <xsl:with-param name="resource">
              <xsl:call-template name="Doc-FKPlural-Title"/>
            </xsl:with-param>
          </xsl:call-template>

					<xsl:element name="h4">
						<xsl:attribute name="class">
							<xsl:text>Collapsible Header</xsl:text>
						</xsl:attribute>

						<xsl:call-template name="Doc-FKPlural-Title"/>
					</xsl:element>

					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
						</xsl:attribute>

						<xsl:element name="p">
							<xsl:call-template name="Doc-FKPlural-Description"/>
						</xsl:element>

						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodTable</xsl:text>
							</xsl:attribute>

							<xsl:call-template name="OverviewTable">
								<xsl:with-param name="Title">
									<xsl:call-template name="Doc-FKPlural-Title"/>
								</xsl:with-param>
								<xsl:with-param name="RESTURI">
									<xsl:call-template name="Doc-FKPlural-RESTURI"/>
								</xsl:with-param>
								<xsl:with-param name="SOAPMethod">
									<xsl:call-template name="Doc-FKPlural-SOAPMethod"/>
								</xsl:with-param>
								<xsl:with-param name="Output">
									<xsl:element name="a">
										<xsl:attribute name="href">
											<xsl:text>ServiceTypes#</xsl:text>
											<xsl:value-of select="$parentTable/@ClassName"/>
											<xsl:text>-Collection</xsl:text>
										</xsl:attribute>

										<xsl:call-template name="Doc-FKPlural-Output"/>
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
									<xsl:call-template name="Doc-FKPlural-Title"/>
									<xsl:text>.</xsl:text>
								</xsl:attribute>

								<xsl:element name="thead">
									<xsl:call-template name="ParameterTableHeader"/>
								</xsl:element>

								<xsl:element name="tbody">
									<xsl:call-template name="ParameterTableRow-FK-ID"/>
									<xsl:call-template name="ParameterTableRow-Page"/>
								</xsl:element>
							</xsl:element>
						</xsl:element>
					</xsl:element>
					<!--END FK-->

					<!--FK All Count-->
          <xsl:call-template name="Anchor">
            <xsl:with-param name="resource">
              <xsl:call-template name="Doc-FKPluralCount-Title"/>
            </xsl:with-param>
          </xsl:call-template>

					<xsl:element name="h4">
						<xsl:attribute name="class">
							<xsl:text>Collapsible Header</xsl:text>
						</xsl:attribute>

						<xsl:call-template name="Doc-FKPluralCount-Title"/>
					</xsl:element>

					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
						</xsl:attribute>

						<xsl:element name="p">
							<xsl:call-template name="Doc-FKPluralCount-Description"/>
						</xsl:element>

						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodTable</xsl:text>
							</xsl:attribute>

							<xsl:call-template name="OverviewTable">
								<xsl:with-param name="Title">
									<xsl:call-template name="Doc-FKPluralCount-Title"/>
								</xsl:with-param>
								<xsl:with-param name="RESTURI">
									<xsl:call-template name="Doc-FKPluralCount-RESTURI"/>
								</xsl:with-param>
								<xsl:with-param name="SOAPMethod">
									<xsl:call-template name="Doc-FKPluralCount-SOAPMethod"/>
								</xsl:with-param>
								<xsl:with-param name="Output">
									<xsl:call-template name="Doc-FKPluralCount-Output"/>
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
									<xsl:call-template name="Doc-FKPluralCount-Title"/>
									<xsl:text>.</xsl:text>
								</xsl:attribute>

								<xsl:element name="thead">
									<xsl:call-template name="ParameterTableHeader"/>
								</xsl:element>

								<xsl:element name="tbody">
									<xsl:call-template name="ParameterTableRow-FK-ID"/>
								</xsl:element>
							</xsl:element>
						</xsl:element>
					</xsl:element>
					<!--END FK All Count-->

					<!--FK Page Count-->
          <xsl:call-template name="Anchor">
            <xsl:with-param name="resource">
              <xsl:call-template name="Doc-FKPluralPageCount-Title"/>
            </xsl:with-param>
          </xsl:call-template>

					<xsl:element name="h4">
						<xsl:attribute name="class">
							<xsl:text>Collapsible Header</xsl:text>
						</xsl:attribute>

						<xsl:call-template name="Doc-FKPluralPageCount-Title"/>
					</xsl:element>

					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
						</xsl:attribute>

						<xsl:element name="p">
							<xsl:call-template name="Doc-FKPluralPageCount-Description"/>
						</xsl:element>

						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodTable</xsl:text>
							</xsl:attribute>

							<xsl:call-template name="OverviewTable">
								<xsl:with-param name="Title">
									<xsl:call-template name="Doc-FKPluralPageCount-Title"/>
								</xsl:with-param>
								<xsl:with-param name="RESTURI">
									<xsl:call-template name="Doc-FKPluralPageCount-RESTURI"/>
								</xsl:with-param>
								<xsl:with-param name="SOAPMethod">
									<xsl:call-template name="Doc-FKPluralPageCount-SOAPMethod"/>
								</xsl:with-param>
								<xsl:with-param name="Output">
									<xsl:call-template name="Doc-FKPluralPageCount-Output"/>
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
									<xsl:call-template name="Doc-FKPluralPageCount-Title"/>
									<xsl:text>.</xsl:text>
								</xsl:attribute>

								<xsl:element name="thead">
									<xsl:call-template name="ParameterTableHeader"/>
								</xsl:element>

								<xsl:element name="tbody">
									<xsl:call-template name="ParameterTableRow-FK-ID"/>
								</xsl:element>
							</xsl:element>
						</xsl:element>
					</xsl:element>
					<!--END FK Page Count-->
				</xsl:for-each>
				<!--END FK-->

				<!-- UX -->
        <xsl:call-template name="Anchor">
          <xsl:with-param name="resource">
            <xsl:call-template name="Doc-UX-Title"/>
          </xsl:with-param>
        </xsl:call-template>

				<xsl:for-each select="P:UniqueIndexMappings/P:UniqueIndexMapping[@Exclude='false']">
					<xsl:element name="h4">
						<xsl:attribute name="class">
							<xsl:text>Collapsible Header</xsl:text>
						</xsl:attribute>

						<xsl:call-template name="Doc-UX-Title"/>
					</xsl:element>

					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
						</xsl:attribute>

						<xsl:element name="p">
							<xsl:call-template name="Doc-UX-Description"/>
						</xsl:element>

						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodTable</xsl:text>
							</xsl:attribute>

							<xsl:call-template name="OverviewTable">
								<xsl:with-param name="Title">
									<xsl:call-template name="Doc-UX-Title"/>
								</xsl:with-param>
								<xsl:with-param name="RESTURI">
									<xsl:call-template name="Doc-UX-RESTURI"/>
								</xsl:with-param>
								<xsl:with-param name="SOAPMethod">
									<xsl:call-template name="Doc-UX-SOAPMethod"/>
								</xsl:with-param>
								<xsl:with-param name="Output">
									<xsl:element name="a">
										<xsl:attribute name="href">
											<xsl:text>ServiceTypes#</xsl:text>
											<xsl:value-of select="../../@ClassName"/>
										</xsl:attribute>

										<xsl:call-template name="Doc-UX-Output"/>
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
									<xsl:call-template name="Doc-UX-Title"/>
									<xsl:text>.</xsl:text>
								</xsl:attribute>

								<xsl:element name="thead">
									<xsl:call-template name="ParameterTableHeader"/>
								</xsl:element>

								<xsl:element name="tbody">
									<xsl:for-each select="P:ColumnNames/P:ColumnName">
										<xsl:variable name="columnName" select="text()"/>
										<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>

										<xsl:call-template name="ParameterTableRow">
											<xsl:with-param name="Parameter" select="$column/@FieldName"/>
											<xsl:with-param name="Type">
												<xsl:choose>
													<xsl:when test="$column/P:EnumerationMapping">
														<xsl:value-of select="$column/P:EnumerationMapping/@Name"/>
													</xsl:when>
													<xsl:otherwise>
														<xsl:value-of select="$column/@DataType"/>
													</xsl:otherwise>
												</xsl:choose>
											</xsl:with-param>
											<xsl:with-param name="Description">
												<xsl:text>A unique value.</xsl:text>
											</xsl:with-param>
										</xsl:call-template>
									</xsl:for-each>
								</xsl:element>
							</xsl:element>
						</xsl:element>
					</xsl:element>
				</xsl:for-each>
				<!-- END UX -->
			</xsl:element>
		</xsl:for-each>

		<xsl:element name="h3">
			<xsl:attribute name="class">
				<xsl:text>Collapsible Header</xsl:text>
			</xsl:attribute>

			<xsl:text>Other</xsl:text>
		</xsl:element>

		<xsl:element name="div">
			<xsl:attribute name="class">
				<xsl:text>Collapsible Content Collapsed</xsl:text>
			</xsl:attribute>

			<!--Custom-->
			<xsl:for-each select="msxsl:node-set($Doc-CustomMethods)/Method">
				<xsl:element name="a">
					<xsl:attribute name="name">
						<xsl:value-of select="@AnchorName"/>
					</xsl:attribute>
				</xsl:element>

				<xsl:element name="h4">
					<xsl:attribute name="class">
						<xsl:text>Collapsible Header</xsl:text>
					</xsl:attribute>

					<xsl:value-of select="@Title"/>
				</xsl:element>

				<xsl:element name="div">
					<xsl:attribute name="class">
						<xsl:text>ServiceBlock Collapsible Content Collapsed</xsl:text>
					</xsl:attribute>

					<xsl:element name="p">
						<xsl:value-of select="@Description"/>
					</xsl:element>

					<xsl:element name="div">
						<xsl:attribute name="class">
							<xsl:text>MethodTable</xsl:text>
						</xsl:attribute>

						<xsl:call-template name="OverviewTable">
							<xsl:with-param name="Title">
								<xsl:value-of select="@Title"/>
							</xsl:with-param>
							<xsl:with-param name="RESTURI">
								<xsl:value-of select="@RESTURI"/>
							</xsl:with-param>
							<xsl:with-param name="SOAPMethod">
								<xsl:value-of select="@SOAPMethod"/>
							</xsl:with-param>
							<xsl:with-param name="Output">
								<xsl:choose>
									<xsl:when test="@OutputLink">
										<xsl:element name="a">
											<xsl:attribute name="href">
												<xsl:text>ServiceTypes#</xsl:text>
												<xsl:value-of select="@OutputLink"/>
											</xsl:attribute>

											<xsl:value-of select="@Output"/>
										</xsl:element>
									</xsl:when>
									<xsl:otherwise>
										<xsl:value-of select="@Output"/>
									</xsl:otherwise>
								</xsl:choose>
							</xsl:with-param>
							<xsl:with-param name="CopyOutput" select="true()"/>
						</xsl:call-template>
					</xsl:element>

					<xsl:if test="Parameter">
						<xsl:element name="div">
							<xsl:attribute name="class">
								<xsl:text>MethodParameters</xsl:text>
							</xsl:attribute>

							<xsl:element name="table">
								<xsl:attribute name="summary">
									<xsl:text>Table describing the parameters for </xsl:text>
									<xsl:value-of select="@Title"/>
									<xsl:text>.</xsl:text>
								</xsl:attribute>

								<xsl:element name="thead">
									<xsl:call-template name="ParameterTableHeader"/>
								</xsl:element>

								<xsl:element name="tbody">
									<xsl:for-each select="Parameter">
										<xsl:call-template name="ParameterTableRow">
											<xsl:with-param name="Parameter">
												<xsl:call-template name="Doc-ParameterName"/>
											</xsl:with-param>
											<xsl:with-param name="Type">
												<xsl:call-template name="Doc-ParameterType"/>
											</xsl:with-param>
											<xsl:with-param name="Description">
												<xsl:call-template name="Doc-ParameterDescription"/>
											</xsl:with-param>
										</xsl:call-template>
										<xsl:text> </xsl:text>
									</xsl:for-each>
								</xsl:element>
							</xsl:element>
						</xsl:element>
					</xsl:if>
				</xsl:element>
			</xsl:for-each>
			<!--END Custom-->
		</xsl:element>
			
		<xsl:value-of select="$newLine"/>
		<xsl:value-of select="$newLine"/>
		
		<xsl:element name="script">
			<xsl:attribute name="type">
				<xsl:text>text/javascript</xsl:text>
			</xsl:attribute>
			<xsl:text>$(document).ready(function () { $(".MethodParameters table th:nth-child(2)").addClass("SecondColumn"); });</xsl:text>
		</xsl:element>
	</xsl:template>

  <xsl:template name="Anchor">
    <xsl:param name="resource"/>

    <xsl:element name="a">
      <xsl:attribute name="name">
      	<xsl:value-of select="qc:Replace($resource, ' ', '-')"/>
      </xsl:attribute>

      <xsl:text> </xsl:text>
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
			<xsl:with-param name="Description" select="'The index of the page of data to retrieve. A value of 1 indicates the first page of data.'"/>
		</xsl:call-template>
	</xsl:template>

	<xsl:template name="ParameterTableRow-FK-ID">
		<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
		<xsl:variable name="parentPluralClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
		<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
		<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
		<xsl:variable name="referencedClassName" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>

		<xsl:call-template name="ParameterTableRow">
			<xsl:with-param name="Parameter">
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
			</xsl:with-param>
			<xsl:with-param name="Type" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
			<xsl:with-param name="Description">
				<xsl:text>The foreign key identifier of the </xsl:text>
				<xsl:value-of select="$referencedClassName"/>
				<xsl:text> instance from which to retrieve the child </xsl:text>
				<xsl:value-of select="$parentPluralClassName"/>
				<xsl:text>.</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
	</xsl:template>

	<xsl:template name="ParameterTableRow-Filter-Query">
		<xsl:call-template name="ParameterTableRow">
			<xsl:with-param name="Parameter" select="'query'"/>
			<xsl:with-param name="Type">
				<xsl:element name="a">
					<xsl:attribute name="href">
						<xsl:text>ServiceTypes#SearchGroup</xsl:text>
					</xsl:attribute>
					
					<xsl:text>SearchGroup</xsl:text>
				</xsl:element>
			</xsl:with-param>
			<xsl:with-param name="Description">
				<xsl:text>A query which uses any fields of the </xsl:text>
				<xsl:element name="a">
					<xsl:attribute name="href">
						<xsl:text>ServiceTypes#</xsl:text>
						<xsl:value-of select="@ClassName"/>
					</xsl:attribute>

					<xsl:value-of select="@ClassName"/>
				</xsl:element>
				<xsl:text> type. Must be in JSON or XML format if using the REST API.</xsl:text>
			</xsl:with-param>
			<xsl:with-param name="CopyOutput" select="true()"/>
		</xsl:call-template>
	</xsl:template>

	<xsl:template name="ParameterTableRow">
		<xsl:param name="Parameter"/>
		<xsl:param name="Type"/>
		<xsl:param name="Description"/>
		<xsl:param name="CopyOutput"/>

		<xsl:element name="tr">
			<xsl:call-template name="TableCell">
				<xsl:with-param name="Text" select="$Parameter"/>
				<xsl:with-param name="Copy" select="$CopyOutput"/>
			</xsl:call-template>
			<xsl:call-template name="TableCell">
				<xsl:with-param name="Text" select="$Type"/>
				<xsl:with-param name="Copy" select="$CopyOutput"/>
			</xsl:call-template>
			<xsl:call-template name="TableCell">
				<xsl:with-param name="Text" select="$Description"/>
				<xsl:with-param name="Copy" select="$CopyOutput"/>
			</xsl:call-template>
		</xsl:element>
	</xsl:template>
</xsl:stylesheet>
