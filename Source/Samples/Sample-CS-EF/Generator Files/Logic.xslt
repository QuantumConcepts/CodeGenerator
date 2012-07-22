<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Data.Objects'"/>
		</xsl:call-template>
		<xsl:call-template name="Using-Project"/>
		<xsl:call-template name="Using-Template">
			<xsl:with-param name="template" select="P:Templates/P:Template[@Name=$templateName]"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.DataAccess</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.Logic
{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:variable name="tableName" select="@TableName"/>
			<xsl:variable name="className" select="@ClassName"/>
			<xsl:variable name="pluralClassName" select="@PluralClassName"/>
			<xsl:text>
	/// &lt;summary&gt;Contains logical functionality related to the </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> class.&lt;/summary&gt;
	public static partial class </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Logic
	{
		/// &lt;summary&gt;Returns the </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> with the provided primary key value.&lt;/summary&gt;
		/// &lt;param name="id"&gt;The primary key of the </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> to fetch.&lt;/param&gt;
		/// &lt;returns&gt;A single </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>, or null if it does not exist.&lt;/returns&gt;
		public static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> GetByID(int id)
		{
			return </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.GetByID(id);
		}
		
		/// &lt;summary&gt;Returns the </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> with the provided primary key value.&lt;/summary&gt;
		/// &lt;param name="id"&gt;The primary key of the </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> to fetch.&lt;/param&gt;
		/// &lt;param name="context"&gt;The data context to use.&lt;/param&gt;
		/// &lt;returns&gt;A single </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>, or null if it does not exist.&lt;/returns&gt;
		public static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> GetByID(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context, int id)
		{
			return </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.GetByID(context, id);
		}
		</xsl:text>
		
			<xsl:call-template name="GetGetAllDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			<xsl:text>
		public static IEnumerable&lt;</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt; GetAll()
		{
			return </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.GetAll</xsl:text>
			<xsl:text>();
		}
		</xsl:text>
		
			<xsl:call-template name="GetGetAllDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			<xsl:text>
		public static IEnumerable&lt;</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt; GetAll(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context)
		{
			return </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.GetAll</xsl:text>
			<xsl:text>(context);
		}
		</xsl:text>
		
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingName=$tableName]">
				<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				<xsl:call-template name="GetForeignKeyGetDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
		public static IEnumerable&lt;</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
				<xsl:text>&gt; GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>)
		{
			return </xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
				<xsl:text>.GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>);
		}
		</xsl:text>
	
				<xsl:call-template name="GetForeignKeyGetDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
		public static IEnumerable&lt;</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
				<xsl:text>&gt; GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text> context, </xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>)
		{
			return </xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
				<xsl:text>.GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(context, </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>);
		}</xsl:text>
				<xsl:if test="position() != last()">
					<xsl:value-of select="$newLine"/>
				</xsl:if>
			</xsl:for-each>

			<xsl:for-each select="P:UniqueIndexMappings/P:UniqueIndexMapping[@Exclude='false']">
				<xsl:text>
		<![CDATA[/// <summary>Gets the ]]></xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text><![CDATA[ matching the unique index using the passed-in values.</summary>]]>
		public static </xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text> GetBy</xsl:text>
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
							<xsl:text></xsl:text>
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
			return </xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text>.GetBy</xsl:text>
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
				<xsl:text>);
		}
		
		public static </xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text> GetBy</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
	
					<xsl:value-of select="$column/@FieldName"/>
					<xsl:if test="position()!=last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text> context, </xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
	
					<xsl:choose>
						<xsl:when test="$column/P:EnumerationMapping">
							<xsl:text></xsl:text>
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
			return </xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text>.GetBy</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
	
					<xsl:value-of select="$column/@FieldName"/>
					<xsl:if test="position()!=last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(context, </xsl:text>
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
				<xsl:text>);
		}</xsl:text>
			</xsl:for-each>
	
			<xsl:for-each select="P:APIs/P:API">
				<xsl:call-template name="GetAPIDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
					<xsl:with-param name="api" select="."/>
				</xsl:call-template>
				<xsl:text>
		public static </xsl:text>
				<xsl:call-template name="GetReturnParameterDataTypeForAPI">
					<xsl:with-param name="prefix">
						<xsl:if test="P:ReturnParameter/@Type='DataObject'">
							<xsl:text></xsl:text>
						</xsl:if>
					</xsl:with-param>
				</xsl:call-template>
				<xsl:text> </xsl:text>
				<xsl:value-of select="@Name"/>
				<xsl:text>(</xsl:text>
				<xsl:call-template name="GetAllParameterDefinitionsForAPI"/>
				<xsl:text>)
		{
			</xsl:text>
				<xsl:if test="P:ReturnParameter/@Type!='Void'">
					<xsl:text>return </xsl:text>
				</xsl:if>
				<xsl:value-of select="@Name"/>
				<xsl:text>(new </xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text>()</xsl:text>
				<xsl:if test="P:Parameters/P:Parameter">
					<xsl:text>, </xsl:text>
				</xsl:if>
				<xsl:call-template name="GetAllParameterModifiersAndNamesForAPI"/>
				<xsl:text>);
		}
		</xsl:text>
				<xsl:call-template name="GetAPIDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
					<xsl:with-param name="api" select="."/>
				</xsl:call-template>
				<xsl:text>
		public static </xsl:text>
				<xsl:call-template name="GetReturnParameterDataTypeForAPI">
					<xsl:with-param name="prefix">
						<xsl:if test="P:ReturnParameter/@Type='DataObject'">
							<xsl:text></xsl:text>
						</xsl:if>
					</xsl:with-param>
				</xsl:call-template>
				<xsl:text> </xsl:text>
				<xsl:value-of select="@Name"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text> context</xsl:text>
				<xsl:if test="P:Parameters/P:Parameter">
					<xsl:text>, </xsl:text>
				</xsl:if>
				<xsl:call-template name="GetAllParameterDefinitionsForAPI"/>
				<xsl:text>)
		{
			</xsl:text>
				<xsl:if test="P:ReturnParameter/@Type!='Void'">
					<xsl:text>return </xsl:text>
				</xsl:if>
				<xsl:value-of select="@Name"/>
				<xsl:text>API(context</xsl:text>
				<xsl:if test="P:Parameters/P:Parameter">
					<xsl:text>, </xsl:text>
				</xsl:if>
				<xsl:call-template name="GetAllParameterModifiersAndNamesForAPI"/>
				<xsl:text>);
		}
		</xsl:text>
			</xsl:for-each>
			<xsl:text>
	    
		public static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> Load</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>FromDataContext(this </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> obj, </xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> dataContext)
		{
			return </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.GetByID(dataContext, </xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='true']">
				<xsl:text>obj.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:if test="position() != last()">
					<xsl:text>, </xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:text>);
		}
    
		public static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> Create</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>(</xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false' and @FieldName != 'Created' and @FieldName != 'Modified']">
				<xsl:choose>
					<xsl:when test="P:EnumerationMapping">
						<xsl:text></xsl:text>
						<xsl:value-of select="P:EnumerationMapping/@Name"/>
					</xsl:when>
					<xsl:when test="@EncryptionVectorColumnName">
						<xsl:text>System.String</xsl:text>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@DataType"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:if test="@Nullable='true'">
					<xsl:text>?</xsl:text>
				</xsl:if>
				<xsl:text> </xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>_Parameter</xsl:text>
				<xsl:if test="position() != last()">
					<xsl:text>, </xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:text>)
		{
			</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context = new </xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text>();
			</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> obj = Create</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>(context, </xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false' and @FieldName != 'Created' and @FieldName != 'Modified']">
				<xsl:value-of select="@FieldName"/>
				<xsl:text>_Parameter</xsl:text>
				<xsl:if test="position() != last()">
					<xsl:text>, </xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:text>);
			
			context.AcceptAllChanges();
			</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> Create</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context, </xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false' and @FieldName != 'Created' and @FieldName != 'Modified']">
				<xsl:choose>
					<xsl:when test="P:EnumerationMapping">
						<xsl:text></xsl:text>
						<xsl:value-of select="P:EnumerationMapping/@Name"/>
					</xsl:when>
					<xsl:when test="@EncryptionVectorColumnName">
						<xsl:text>System.String</xsl:text>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@DataType"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:if test="@Nullable='true'">
					<xsl:text>?</xsl:text>
				</xsl:if>
				<xsl:text> </xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>_Parameter</xsl:text>
				<xsl:if test="position() != last()">
					<xsl:text>, </xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:text>)
		{
			</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> obj = new </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>();
			
			</xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false' and @FieldName != 'Created' and @FieldName != 'Modified']">
				<xsl:text>obj.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> = </xsl:text>
				<xsl:choose>
					<xsl:when test="@EncryptionVectorColumnName">
						<xsl:text>EncryptionUtil.Instance.EncryptTextViaRijndael(</xsl:text>
						<xsl:value-of select="@FieldName"/>
						<xsl:text>_Parameter, </xsl:text>
						<xsl:value-of select="@EncryptionVectorColumnName"/>
						<xsl:text>_Parameter.ToArray())</xsl:text>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@FieldName"/>
						<xsl:text>_Parameter</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>;
			</xsl:text>
			</xsl:for-each>
			<xsl:text>
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.</xsl:text>
			<xsl:value-of select="$pluralClassName"/>
			<xsl:text>.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		</xsl:text>
			<xsl:if test="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName = $tableName]">
				<xsl:text>
		public static </xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> Create</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text>(</xsl:text>
				<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='false' and @FieldName != 'Created' and @FieldName != 'Modified']">
					<xsl:variable name="columnName" select="@ColumnName"/>
					<xsl:variable name="foreignKeyMapping" select="../../../../P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName = $tableName and @ParentColumnMappingName = $columnName]"/>
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:text></xsl:text>
							<xsl:value-of select="P:EnumerationMapping/@Name"/>
							<xsl:if test="@Nullable='true'">
								<xsl:text>?</xsl:text>
							</xsl:if>
						</xsl:when>
						<xsl:when test="@EncryptionVectorColumnName">
							<xsl:text>System.String</xsl:text>
						</xsl:when>
						<xsl:when test="$foreignKeyMapping">
							<xsl:text></xsl:text>
							<xsl:value-of select="../../../P:TableMapping[@TableName = $foreignKeyMapping/@ReferencedTableMappingName]/@ClassName"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@DataType"/>
							<xsl:if test="@Nullable='true'">
								<xsl:text>?</xsl:text>
							</xsl:if>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text> </xsl:text>
					<xsl:choose>
						<xsl:when test="$foreignKeyMapping">
							<xsl:value-of select="$foreignKeyMapping/@PropertyName"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@FieldName"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text>_Parameter</xsl:text>
					<xsl:if test="position() != last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>)
		{
			</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text> context = new </xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text>();
			</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> obj = Create</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text>(context, </xsl:text>
				<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='false' and @FieldName != 'Created' and @FieldName != 'Modified']">
					<xsl:variable name="columnName" select="@ColumnName"/>
					<xsl:variable name="foreignKeyMapping" select="../../../../P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName = $tableName and @ParentColumnMappingName = $columnName]"/>
					<xsl:choose>
						<xsl:when test="$foreignKeyMapping">
							<xsl:value-of select="$foreignKeyMapping/@PropertyName"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@FieldName"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text>_Parameter</xsl:text>
					<xsl:if test="position() != last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>);
			
			context.AcceptAllChanges();
			</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text>.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static </xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> Create</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text> context, </xsl:text>
				<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='false' and @FieldName != 'Created' and @FieldName != 'Modified']">
					<xsl:variable name="columnName" select="@ColumnName"/>
					<xsl:variable name="foreignKeyMapping" select="../../../../P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName = $tableName and @ParentColumnMappingName = $columnName]"/>
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:text></xsl:text>
							<xsl:value-of select="P:EnumerationMapping/@Name"/>
							<xsl:if test="@Nullable='true'">
								<xsl:text>?</xsl:text>
							</xsl:if>
						</xsl:when>
						<xsl:when test="@EncryptionVectorColumnName">
							<xsl:text>System.String</xsl:text>
						</xsl:when>
						<xsl:when test="$foreignKeyMapping">
							<xsl:text></xsl:text>
							<xsl:value-of select="../../../P:TableMapping[@TableName = $foreignKeyMapping/@ReferencedTableMappingName]/@ClassName"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@DataType"/>
							<xsl:if test="@Nullable='true'">
								<xsl:text>?</xsl:text>
							</xsl:if>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text> </xsl:text>
					<xsl:choose>
						<xsl:when test="$foreignKeyMapping">
							<xsl:value-of select="$foreignKeyMapping/@PropertyName"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@FieldName"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text>_Parameter</xsl:text>
					<xsl:if test="position() != last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>)
		{
			</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> obj = new </xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text>();
			
			</xsl:text>
				<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='false' and @FieldName != 'Created' and @FieldName != 'Modified']">
					<xsl:variable name="columnName" select="@ColumnName"/>
					<xsl:variable name="foreignKeyMapping" select="../../../../P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName = $tableName and @ParentColumnMappingName = $columnName]"/>
					<xsl:text>obj.</xsl:text>
					<xsl:choose>
						<xsl:when test="$foreignKeyMapping">
							<xsl:value-of select="$foreignKeyMapping/@PropertyName"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@FieldName"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text> = </xsl:text>
					<xsl:choose>
						<xsl:when test="$foreignKeyMapping">
							<xsl:value-of select="$foreignKeyMapping/@PropertyName"/>
							<xsl:text>_Parameter</xsl:text>
						</xsl:when>
						<xsl:when test="@EncryptionVectorColumnName">
							<xsl:text>EncryptionUtil.Instance.EncryptTextViaRijndael(</xsl:text>
							<xsl:value-of select="@FieldName"/>
							<xsl:text>_Parameter, </xsl:text>
							<xsl:value-of select="@EncryptionVectorColumnName"/>
							<xsl:text>_Parameter.ToArray())</xsl:text>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@FieldName"/>
							<xsl:text>_Parameter</xsl:text>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text>;
			</xsl:text>
				</xsl:for-each>
				<xsl:text>
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.</xsl:text>
				<xsl:value-of select="$pluralClassName"/>
				<xsl:text>.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
		</xsl:text>
			</xsl:if>
			<xsl:text>
		public static void Delete</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>(int id)
		{
			</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context = new </xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text>();
			
			Delete</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>(context, id);
			
			context.AcceptAllChanges();
			</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.OnCacheNeedsRefresh();
		}
		
		public static void Delete</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context, int id)
		{
			</xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text> obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.</xsl:text>
			<xsl:value-of select="$pluralClassName"/>
			<xsl:text>.DeleteObject(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		<![CDATA[/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>]]>
		static partial void Validate(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context, </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text> obj</xsl:text>
			<xsl:text>);
    
		<![CDATA[/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>]]>
		static partial void PerformPreCreateLogic(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context, </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text> obj</xsl:text>
			<xsl:text>);
		
		<![CDATA[/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>]]>
		static partial void PerformPostCreateLogic(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context, </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text> obj</xsl:text>
			<xsl:text>);
    
		<![CDATA[/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>]]>
		static partial void PerformPreDeleteLogic(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context, </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text> obj</xsl:text>
			<xsl:text>);
		
		<![CDATA[/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>]]>
		static partial void PerformPostDeleteLogic(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context, </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text> obj</xsl:text>
			<xsl:text>);
	}</xsl:text>
			<xsl:if test="position() != last()">
				<xsl:value-of select="$newLine"/>
			</xsl:if>
		</xsl:for-each>
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>