<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Runtime.Serialization'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.ServiceModel'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Text'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.ServiceModel.Activation'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Linq.Expressions'"/>
		</xsl:call-template>
		<xsl:call-template name="Using-Project"/>
		<xsl:call-template name="Using-Template">
			<xsl:with-param name="template" select="P:Templates/P:Template[@Name=$templateName]"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:text>DO = </xsl:text>
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.DataObjects</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:text>SO = </xsl:text>
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.Service.ServiceObjects.SOAP</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:text>DA = </xsl:text>
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.DataAccess</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.Logic</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.Service.Utils</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.Service
{
	<![CDATA[/// <summary>Exposes functionality through one or more service end points.</summary>]]>
	[AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
	public partial class SOAP : ISOAP
	{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed']">
			<xsl:variable name="TableName" select="@TableName"/>
			<xsl:call-template name="GetGetAllDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			<xsl:text>
		public IEnumerable&lt;SO.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt; Get</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>(int page)
		{
			return ServiceUtil.GetPage(</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Logic.GetAll(), page).Select(o =&gt; SO.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.FromDataAccessObject(o));
		}
		</xsl:text>

			<xsl:text>
		/// &lt;summary&gt;Gets how many </xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text> exist.&lt;summary&gt;
		public int Get</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>Count()
		{
			using(DA.</xsl:text>
	<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
	<xsl:text> dataContext = new DA.</xsl:text>
	<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
	<xsl:text>())
			{
				return dataContext.</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>.Count();
			}
		}
		</xsl:text>

			<xsl:text>
		/// &lt;summary&gt;Gets how many pages of data exist for the </xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text> method.&lt;summary&gt;
		public int Get</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>PageCount()
		{
			return ServiceUtil.GetPageCount(Get</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>Count());
		}
		</xsl:text>
			
			<xsl:call-template name="GetGetByIDDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			<xsl:text>
		public SO.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> Get</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>ByID(int id)
		{
			return SO.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.FromDataAccessObject(</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Logic.GetByID(id));
		}</xsl:text>
		
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and P:Attributes/P:Attribute/@Key='ServiceExposed' and @ParentTableMappingName=$TableName]">
				<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				<xsl:value-of select="$newLine"/>
				<xsl:call-template name="GetForeignKeyGetDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
		public IEnumerable&lt;SO.</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
				<xsl:text>&gt; Get</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
				<xsl:text>By</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>, int page)
		{
			IEnumerable&lt;DA.</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
				<xsl:text>&gt; returnValue = </xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
				<xsl:text>Logic.GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>);
			
			if (returnValue != null)
				return ServiceUtil.GetPage(returnValue, page).Select(o =&gt; SO.</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
				<xsl:text>.FromDataAccessObject(o));
			
			return null;
		}
		</xsl:text>

				<xsl:text>
		/// &lt;summary&gt;Gets how many </xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
				<xsl:text> by </xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> exist.&lt;summary&gt;
		public int Get</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
				<xsl:text>By</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Count(</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>)
		{
			return </xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
				<xsl:text>Logic.GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>).Count();
		}
		</xsl:text>

				<xsl:text>
		/// &lt;summary&gt;Gets how many pages of data exist for the </xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
				<xsl:text> by </xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> method.&lt;summary&gt;
		public int Get</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
				<xsl:text>By</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>PageCount(</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>)
		{
			return ServiceUtil.GetPageCount(Get</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
				<xsl:text>By</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Count(</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/@ClassName"/>
				</xsl:call-template>
				<xsl:value-of select="$referencedColumnName"/>
				<xsl:text>));
		}</xsl:text>
			</xsl:for-each>
			
			<xsl:for-each select="P:UniqueIndexMappings/P:UniqueIndexMapping[@Exclude='false']">
				<xsl:value-of select="$newLine"/>
				<xsl:call-template name="GetUniqueIndexMappingDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
		public SO.</xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text> Get</xsl:text>
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
				<xsl:text>(</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
					
					<xsl:choose>
						<xsl:when test="$column/P:EnumerationMapping">
							<xsl:text>DO.</xsl:text>
							<xsl:value-of select="$column/P:EnumerationMapping/@Name"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="$column/@DataType"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text> </xsl:text>
					<xsl:call-template name="FirstCharacterToLowerCase">
						<xsl:with-param name="input" select="$column/@FieldName"/>
					</xsl:call-template>
					
					<xsl:if test="position()!=last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>)
		{
			return SO.</xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text>.FromDataAccessObject(</xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text>Logic.GetBy</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
					
					<xsl:value-of select="$column/@FieldName"/>
					<xsl:if test="position()!=last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
					
					<xsl:call-template name="FirstCharacterToLowerCase">
						<xsl:with-param name="input" select="$column/@FieldName"/>
					</xsl:call-template>
					
					<xsl:if test="position()!=last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>));
		}
		</xsl:text>
			</xsl:for-each>
		</xsl:for-each>
		<xsl:text>
	}
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>