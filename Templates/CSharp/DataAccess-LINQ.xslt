<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="Common.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Data.Linq'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Data.Linq.Mapping'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Data'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Reflection'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Linq.Expressions'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.ComponentModel'"/>
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
				<xsl:text>DA = </xsl:text>
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.DataAccess</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.DataAccess.Cache</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
		<xsl:text>.DataAccess
{
	/// &lt;summary&gt;Exposes all functionality to interact with the database.&lt;/summary&gt;
	[DatabaseAttribute]
	public partial class </xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text> : DataContext
	{
		///&lt;summary&gt;Indicates whether or not data contexts should be instantiated using the default factory. This should be set to false if a specific Factory is provided.&lt;/summary&gt;
		public static bool UseDefaultFactory { get; set;}
		
		///&lt;summary&gt;Defines the factory method that is used to create a new data context.&lt;/summary&gt;
		public static Func&lt;</xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>&gt; Factory { get; set; }
		
		/// &lt;summary&gt;Creates a new DataContext with which to query and update data.&lt;/summary&gt;
		protected </xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>()
			: base(ConfigUtil.Instance.ConnectionString, new AttributeMappingSource())
		{
			Initialize();
		}
		
		partial void OnCreated();</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false'] | P:ViewMappings/P:ViewMapping[@Exclude='false']">
			<xsl:variable name="tableMappingName" select="@TableName"/>
			<xsl:text>
		partial void Insert</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>(DA.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> instance);</xsl:text>
			<xsl:text>
		partial void Update</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>(DA.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> instance);</xsl:text>
			<xsl:text>
		partial void Delete</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>(DA.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> instance);</xsl:text>
		</xsl:for-each>
		
		<xsl:value-of select="$newLine"/>
		
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false'] | P:ViewMappings/P:ViewMapping[@Exclude='false']">
			<xsl:call-template name="GetTableMappingDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			<xsl:text>
		public Table&lt;DA.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt; </xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text> { get; private set; }</xsl:text>
		</xsl:for-each>
		<xsl:text>
		
		private void Initialize()
		{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false'] | P:ViewMappings/P:ViewMapping[@Exclude='false']">
			<xsl:call-template name="GetTableMappingDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			<xsl:text>
			this.</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text> = this.GetTable&lt;DA.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt;();</xsl:text>
		</xsl:for-each>
		<xsl:text>
			
			OnCreated();
		}
		
		public static </xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text> Create()
		{
			if (</xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>.UseDefaultFactory)
				return new </xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>();
			else if (</xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>.Factory == null)
				throw new ApplicationException("</xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>.Factory must be non-null or </xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>.UseDefaultFactory must be set to true.");
			else
				return </xsl:text>
		<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>.Factory();
		}
	}</xsl:text>
	
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false'] | P:ViewMappings/P:ViewMapping[@Exclude='false']">
			<xsl:variable name="table" select="."/>
			<xsl:variable name="tableName" select="@TableName"/>
			<xsl:variable name="className" select="@ClassName"/>
			<xsl:variable name="pluralClassName" select="@PluralClassName"/>
			<xsl:variable name="pkColumns" select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='true']"/>
      <xsl:variable name="parentFKs" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName and @Exclude='false']"/>

      <xsl:value-of select="$newLine"/>
			
			<xsl:call-template name="GetTableMappingDocumentation">
				<xsl:with-param name="spacingBefore" select="$tab"/>
			</xsl:call-template>
			
			<xsl:text>
	[TableAttribute(Name="</xsl:text>
			<xsl:value-of select="@SchemaName"/>
			<xsl:text>.</xsl:text>
			<xsl:value-of select="@TableName"/>
			<xsl:text>")]
	public partial class </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> : DO.</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>, IDataAccessObject, INotifyPropertyChanging, INotifyPropertyChanged
	{
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		/// &lt;summary&gt;This event indicates that the current cache is invalid or stale and should be refreshed.&lt;/summary&gt;
		internal static event ParameterlessDelegate CacheNeedsRefresh;

		/// &lt;summary&gt;This event is raised just before a property is changed.&lt;/summary&gt;
		public event PropertyChangingEventHandler PropertyChanging;
		
		/// &lt;summary&gt;This event is raised when a property has changed.&lt;/summary&gt;
		public event PropertyChangedEventHandler PropertyChanged;
		</xsl:text>
		
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]">
				<xsl:variable name="foreignKey" select="."/>
				<xsl:variable name="parentTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ParentTableMappingSchemaName and @TableName=$foreignKey/@ParentTableMappingName]"/>
				<xsl:variable name="referencedTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ReferencedTableMappingSchemaName and @TableName=$foreignKey/@ReferencedTableMappingName]"/>
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				
				<xsl:if test="$referencedTableMapping/@Exclude='false' and $parentTableMapping/@Exclude='false'">
					<xsl:text>
		private EntitySet&lt;DA.</xsl:text>
					<xsl:value-of select="$parentTableMapping/@ClassName"/>
					<xsl:text>&gt; _</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>;</xsl:text>
				</xsl:if>
				<xsl:if test="position()=last()">
					<xsl:text>
		</xsl:text>
				</xsl:if>
			</xsl:for-each>
		
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName]">
				<xsl:variable name="foreignKey" select="."/>
				<xsl:variable name="parentTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ParentTableMappingSchemaName and @TableName=$foreignKey/@ParentTableMappingName]"/>
				<xsl:variable name="referencedTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ReferencedTableMappingSchemaName and @TableName=$foreignKey/@ReferencedTableMappingName]"/>
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:if test="$parentTableMapping/@Exclude='false' and $referencedTableMapping/@Exclude='false'">
					<xsl:text>
		private EntityRef&lt;DA.</xsl:text>
					<xsl:value-of select="$referencedTableMapping/@ClassName"/>
					<xsl:text>&gt; _</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>;</xsl:text>
				</xsl:if>
				<xsl:if test="position()=last()">
					<xsl:text>
		</xsl:text>
				</xsl:if>
			</xsl:for-each>
		
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
				<xsl:variable name="columnName" select="@ColumnName"/>
				<xsl:variable name="dataType" select="@DataType"/>
				<xsl:variable name="fk" select="../../../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
				
				<xsl:call-template name="GetColumnMappingDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
		[ColumnAttribute(Name="</xsl:text>
				<xsl:value-of select="@ColumnName"/>
				<xsl:text>", Storage="_</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>", DbType="</xsl:text>
				<xsl:value-of select="@DatabaseDataType"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="@Length"/>
				<xsl:text>) </xsl:text>
				<xsl:if test="@NullableInDatabase='false'">
					<xsl:text>NOT </xsl:text>
				</xsl:if>
				<xsl:text>NULL</xsl:text>
				<xsl:if test="@PrimaryKey='true'">
					<xsl:text> IDENTITY</xsl:text>
				</xsl:if>
				<xsl:text>"</xsl:text>
				<xsl:if test="@PrimaryKey='true'">
					<xsl:text>, AutoSync=AutoSync.OnInsert, IsPrimaryKey=true</xsl:text>
					
					<xsl:if test="not(P:Attributes/P:Attribute[@Key='PKNotDBGenerated'])">
						<xsl:text>, IsDbGenerated=true</xsl:text>
					</xsl:if>
				</xsl:if>
				<xsl:text>)]
		public new </xsl:text>
				<xsl:choose>
					<xsl:when test="P:EnumerationMapping">
						<xsl:text>DO.</xsl:text>
						<xsl:value-of select="P:EnumerationMapping/@Name"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@DataType"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:if test="@Nullable='true' and (P:EnumerationMapping or ../../../../P:DataTypeMappings/P:DataTypeMapping[@ApplicationDataType=$dataType]/@Nullable='true')">
					<xsl:text>?</xsl:text>
				</xsl:if>
				<xsl:text> </xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>
		{
			get { return this._</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>; }
			set
			{
				if (!object.Equals(value, this._</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>))
				{</xsl:text>
				<xsl:if test="$fk">
					<xsl:variable name="fkPropertyName" select="$fk/@PropertyName"/>
					<xsl:variable name="fkReferencedTable" select="../../../../P:TableMappings/P:TableMapping[@SchemaName=$fk/@ReferencedTableMappingSchemaName and @TableName=$fk/@ReferencedTableMappingName]"/>
					<xsl:variable name="fkReferencedFieldName" select="$fkReferencedTable/P:ColumnMappings/P:ColumnMapping[@ColumnName=$fk/@ReferencedColumnMappingName]/@FieldName"/>
					
					<xsl:text>
					if (_</xsl:text>
					<xsl:value-of select="$fkPropertyName"/>
					<xsl:text>.HasLoadedOrAssignedValue &amp;&amp; (_</xsl:text>
					<xsl:value-of select="$fkPropertyName"/>
					<xsl:text>.Entity == null || _</xsl:text>
					<xsl:value-of select="$fkPropertyName"/>
					<xsl:text>.Entity.</xsl:text>
					<xsl:value-of select="$fkReferencedFieldName"/>
					<xsl:text> != value))
						throw new ForeignKeyReferenceAlreadyHasValueException();
						</xsl:text>
				</xsl:if>
				<xsl:text>
					this.On</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Changing(value);
					this.OnPropertyChanging();
					this._</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:choose>
					<xsl:when test="P:Attributes/P:Attribute/@Key='LazyLoad'">
						<xsl:text>Link = new Link&lt;</xsl:text>
						<xsl:value-of select="@DataType"/>
						<xsl:text>&gt;(value)</xsl:text>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text> = value</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>;
					this.OnPropertyChanged("</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>");
					this.On</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Changed();
				}
			}
		}
		</xsl:text>
		
				<xsl:if test="@EncryptionVectorColumnName">
					<xsl:text>
		public string </xsl:text>
					<xsl:value-of select="@DecryptionPropertyName"/>
					<xsl:text>
		{
			get
			{
				if (this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>.IsNullOrEmpty() || this.</xsl:text>
					<xsl:value-of select="@EncryptionVectorColumnName"/>
					<xsl:text>.IsNullOrEmpty())
					return null;
				
				return EncryptionUtil.Instance.DecryptTextViaRijndael(this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>, this.</xsl:text>
					<xsl:value-of select="@EncryptionVectorColumnName"/>
					<xsl:text>);
			}
			set
			{
				if (value.IsNullOrEmpty())
					this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = null;
				else
				{
					if (this.</xsl:text>
					<xsl:value-of select="@EncryptionVectorColumnName"/>
					<xsl:text>.IsNullOrEmpty())
						this.</xsl:text>
					<xsl:value-of select="@EncryptionVectorColumnName"/>
					<xsl:text> = EncryptionUtil.GenerateEncryptionVector();
					
					this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = EncryptionUtil.Instance.EncryptTextViaRijndael(value, this.</xsl:text>
					<xsl:value-of select="@EncryptionVectorColumnName"/>
					<xsl:text>);
				}
			}
		}
		</xsl:text>
				</xsl:if>
			</xsl:for-each>
		
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]">
				<xsl:variable name="foreignKey" select="."/>
				<xsl:variable name="parentTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ParentTableMappingSchemaName and @TableName=$foreignKey/@ParentTableMappingName]"/>
				<xsl:variable name="referencedTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ReferencedTableMappingSchemaName and @TableName=$foreignKey/@ReferencedTableMappingName]"/>
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedFieldName" select="$referencedTableMapping/P:ColumnMappings/P:ColumnMapping[@ColumnName=$foreignKey/@ReferencedColumnMappingName]/@FieldName"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				
				<xsl:if test="$referencedTableMapping/@Exclude='false' and $parentTableMapping/@Exclude='false'">
					<xsl:call-template name="GetForeignKeyMappingDocumentation">
						<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
					</xsl:call-template>
					<xsl:text>
		[AssociationAttribute(Name="</xsl:text>
					<xsl:value-of select="@ForeignKeyName"/>
					<xsl:text>", Storage="_</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>", ThisKey="</xsl:text>
					<xsl:value-of select="$referencedFieldName"/>
					<xsl:text>", OtherKey="</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>")]
		public EntitySet&lt;DA.</xsl:text>
					<xsl:value-of select="$parentTableMapping/@ClassName"/>
					<xsl:text>&gt; </xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>
		{
			get { return _</xsl:text>
				<xsl:value-of select="@PluralPropertyName"/>
				<xsl:text>; }
			set { _</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>.Assign(value); }
		}
		</xsl:text>
				</xsl:if>
			</xsl:for-each>
		
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName]">
				<xsl:variable name="foreignKey" select="."/>
				<xsl:variable name="parentTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ParentTableMappingSchemaName and @TableName=$foreignKey/@ParentTableMappingName]"/>
				<xsl:variable name="referencedTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ReferencedTableMappingSchemaName and @TableName=$foreignKey/@ReferencedTableMappingName]"/>
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedFieldName" select="$referencedTableMapping/P:ColumnMappings/P:ColumnMapping[@ColumnName=$foreignKey/@ReferencedColumnMappingName]/@FieldName"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnMappingName" select="@ParentColumnMappingName"/>
				
				<xsl:if test="$parentTableMapping/@Exclude='false' and $referencedTableMapping/@Exclude='false'">
					<xsl:call-template name="GetForeignKeyMappingDocumentation">
						<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
					</xsl:call-template>
					<xsl:text>
		[AssociationAttribute(Name="</xsl:text>
					<xsl:value-of select="@ForeignKeyName"/>
					<xsl:text>", Storage="_</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>", ThisKey="</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>", OtherKey="</xsl:text>
					<xsl:value-of select="$referencedFieldName"/>
					<xsl:text>", IsForeignKey=true)]
		public DA.</xsl:text>
					<xsl:value-of select="$referencedTableMapping/@ClassName"/>
					<xsl:text> </xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>
		{
			</xsl:text>
					<xsl:text>
			get { return _</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>.Entity; }</xsl:text>
					<xsl:text>
			set
			{
				</xsl:text>
					<xsl:value-of select="$referencedTableMapping/@ClassName"/>
					<xsl:text> previousValue = _</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>.Entity;
				
				if (previousValue != value || !_</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>.HasLoadedOrAssignedValue)
				{
					this.OnPropertyChanging();
					
					if (previousValue != null)
					{
						_</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>.Entity = null;
						previousValue.</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>.Remove(this);
					}
				}
				
				_</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>.Entity = value;
				
				if (value != null)
				{
					value.</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>.Add(this);
					this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = value.</xsl:text>
					<xsl:value-of select="$referencedFieldName"/>
					<xsl:text>;
				}
				else
				{
					_</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text> = default(EntityRef&lt;</xsl:text>
					<xsl:value-of select="$referencedTableMapping/@ClassName"/>
					<xsl:text>&gt;);
					this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = default(</xsl:text>
					<xsl:choose>
						<xsl:when test="../../P:TableMappings/P:TableMapping[@SchemaName=$parentTableMapping/@SchemaName and @TableName=$parentTableMapping/@TableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$parentColumnMappingName]/@EnumerationMapping">
							<xsl:value-of select="../../P:TableMappings/P:TableMapping[@SchemaName=$parentTableMapping/@SchemaName and @TableName=$parentTableMapping/@TableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$parentColumnMappingName]/P:EnumerationMapping/Name"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="../../P:TableMappings/P:TableMapping[@SchemaName=$parentTableMapping/@SchemaName and @TableName=$parentTableMapping/@TableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$parentColumnMappingName]/@DataType"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:if test="../../P:TableMappings/P:TableMapping[@SchemaName=$parentTableMapping/@SchemaName and @TableName=$parentTableMapping/@TableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$parentColumnMappingName]/@Nullable='true'">
						<xsl:text>?</xsl:text>
					</xsl:if>
					<xsl:text>);
				}
				
				this.OnPropertyChanged("</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text>");
			}
		}
		</xsl:text>
				</xsl:if>
			</xsl:for-each>
		
			<xsl:text>
		/// &lt;summary&gt;Creates a new instance of the class.&lt;/summary&gt;
		public </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>()
		{</xsl:text>
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]">
				<xsl:variable name="foreignKey" select="."/>
				<xsl:variable name="parentTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ParentTableMappingSchemaName and @TableName=$foreignKey/@ParentTableMappingName]"/>
				<xsl:variable name="referencedTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ReferencedTableMappingSchemaName and @TableName=$foreignKey/@ReferencedTableMappingName]"/>
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:if test="$referencedTableMapping/@Exclude='false' and $parentTableMapping/@Exclude='false'">
					<xsl:text>
			this._</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>= new EntitySet&lt;DA.</xsl:text>
					<xsl:value-of select="$parentTableMapping/@ClassName"/>
					<xsl:text>&gt;(new Action&lt;DA.</xsl:text>
					<xsl:value-of select="$parentTableMapping/@ClassName"/>
					<xsl:text>&gt;(this.Attach</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>), new Action&lt;DA.</xsl:text>
					<xsl:value-of select="$parentTableMapping/@ClassName"/>
					<xsl:text>&gt;(this.Detach</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>));</xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName]">
				<xsl:variable name="foreignKey" select="."/>
				<xsl:variable name="parentTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ParentTableMappingSchemaName and @TableName=$foreignKey/@ParentTableMappingName]"/>
				<xsl:variable name="referencedTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ReferencedTableMappingSchemaName and @TableName=$foreignKey/@ReferencedTableMappingName]"/>
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:if test="$parentTableMapping/@Exclude='false' and $referencedTableMapping/@Exclude='false'">
					<xsl:text>
			this._</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text> = default(EntityRef&lt;DA.</xsl:text>
					<xsl:value-of select="$referencedTableMapping/@ClassName"/>
					<xsl:text>&gt;);</xsl:text>
				</xsl:if>
			</xsl:for-each>
			
			<xsl:for-each select=".//P:ColumnMapping[@EncryptionVectorColumnName]">
				<xsl:text>
			this.</xsl:text>
				<xsl:value-of select="@EncryptionVectorColumnName"/>
				<xsl:text> = EncryptionUtil.GenerateEncryptionVector();</xsl:text>
			</xsl:for-each>
			
			<xsl:text>
		
			OnCreated();
		}
		</xsl:text>

			<xsl:call-template name="GetGetAllDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			<xsl:text>
		public static IQueryable&lt;</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt; GetAll()
		{
			return GetAll</xsl:text>
			<xsl:text>(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text>.Create());</xsl:text>
			<xsl:text>
		}
			</xsl:text>
	
			<xsl:call-template name="GetGetAllDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			<xsl:text>
		public static IQueryable&lt;</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt; GetAll(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context)
		{
			return context.</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>;
		}</xsl:text>
		
			<xsl:if test="$pkColumns">
				<xsl:text>

		/// &lt;summary&gt;Returns the </xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> with the provided primary key value.&lt;/summary&gt;
		/// &lt;param name="id"&gt;The primary key of the </xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> to fetch.&lt;/param&gt;
		/// &lt;returns&gt;A single </xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text>, or null if it does not exist.&lt;/returns&gt;
		public static DA.</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> GetBy</xsl:text>
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@FieldName"/>
					<xsl:if test="position() != last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(</xsl:text>
				
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@DataType"/>
					<xsl:text> </xsl:text>
					<xsl:value-of select="@FieldName"/>
					
					<xsl:if test="position() != last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				
				<xsl:text>)
		{
			return GetBy</xsl:text>
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@FieldName"/>
					<xsl:if test="position() != last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text>.Create(), </xsl:text>
				
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@FieldName"/>
					
					<xsl:if test="position() != last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				
				<xsl:text>);
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
		public static DA.</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> GetBy</xsl:text>
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@FieldName"/>
					<xsl:if test="position() != last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text> context, </xsl:text>
				
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@DataType"/>
					<xsl:text> </xsl:text>
					<xsl:value-of select="@FieldName"/>
					
					<xsl:if test="position() != last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				
				<xsl:text>)
		{
			return GetBy</xsl:text>
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@FieldName"/>
					<xsl:if test="position() != last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(context.</xsl:text>
				<xsl:value-of select="@PluralClassName"/>
				<xsl:text>, </xsl:text>
				
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@FieldName"/>
					
					<xsl:if test="position() != last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				
				<xsl:text>);
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
		public static DA.</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> GetBy</xsl:text>
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@FieldName"/>
					<xsl:if test="position() != last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(IQueryable&lt;</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text>&gt; items, </xsl:text>
				
				<xsl:for-each select="$pkColumns">
					<xsl:value-of select="@DataType"/>
					<xsl:text> </xsl:text>
					<xsl:value-of select="@FieldName"/>
					
					<xsl:if test="position() != last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				
				<xsl:text>)
		{
			return items.SingleOrDefault(o => </xsl:text>
				
				<xsl:for-each select="$pkColumns">
					<xsl:text>object.Equals(o.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>, </xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>)</xsl:text>
					
					<xsl:if test="position() != last()">
						<xsl:text> &amp;&amp; </xsl:text>
					</xsl:if>
				</xsl:for-each>
				
				<xsl:text>);
		}</xsl:text>
			</xsl:if>
	
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName]">
				<xsl:variable name="foreignKey" select="."/>
				<xsl:variable name="parentTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ParentTableMappingSchemaName and @TableName=$foreignKey/@ParentTableMappingName]"/>
				<xsl:variable name="referencedTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ReferencedTableMappingSchemaName and @TableName=$foreignKey/@ReferencedTableMappingName]"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				
				<xsl:value-of select="$newLine"/>
				<xsl:call-template name="GetForeignKeyGetDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
		public static IQueryable&lt;</xsl:text>
				<xsl:value-of select="$parentTableMapping/@ClassName"/>
				<xsl:text>&gt; GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="$referencedTableMapping/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>)
		{
			return GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text>.Create(), </xsl:text>
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
		public static IQueryable&lt;</xsl:text>
				<xsl:value-of select="$parentTableMapping/@ClassName"/>
				<xsl:text>&gt; GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text> context, </xsl:text>
				<xsl:value-of select="$referencedTableMapping/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>)
		{
			return GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="$parentTableMapping/@ClassName"/>
				<xsl:text>.GetAll(), </xsl:text>
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
		public static IQueryable&lt;</xsl:text>
				<xsl:value-of select="$parentTableMapping/@ClassName"/>
				<xsl:text>&gt; GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(IQueryable&lt;</xsl:text>
				<xsl:value-of select="$parentTableMapping/@ClassName"/>
				<xsl:text>&gt; items, </xsl:text>
				<xsl:value-of select="$referencedTableMapping/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>)
		{
			return items.Where( o=&gt; object.Equals(o.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>, </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>));
		}</xsl:text>
			</xsl:for-each>

			<xsl:for-each select="P:UniqueIndexMappings/P:UniqueIndexMapping[@Exclude='false']">
				<xsl:text>
		
		<![CDATA[/// <summary>Gets the ]]></xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text><![CDATA[ matching the unique index using the passed-in values.</summary>]]>
		public static DA.</xsl:text>
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
							<xsl:text>DO.</xsl:text>
							<xsl:value-of select="$column/P:EnumerationMapping/@Name"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="$column/@DataType"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:if test="$column/@Nullable='true'">
						<xsl:text>?</xsl:text>
					</xsl:if>
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
			return GetBy</xsl:text>
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
				<xsl:text>.Create(), </xsl:text>
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
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text> context, </xsl:text>
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
					<xsl:if test="$column/@Nullable='true'">
						<xsl:text>?</xsl:text>
					</xsl:if>
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
			return GetBy</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
	
					<xsl:value-of select="$column/@FieldName"/>
					<xsl:if test="position()!=last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(context.</xsl:text>
				<xsl:value-of select="../../@PluralClassName"/>
				<xsl:text>, </xsl:text>
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
				<xsl:text>(IQueryable&lt;</xsl:text>
				<xsl:value-of select="../../@ClassName"/>
				<xsl:text>&gt; items, </xsl:text>
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
					<xsl:if test="$column/@Nullable='true'">
						<xsl:text>?</xsl:text>
					</xsl:if>
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
			return items.FirstOrDefault(o =&gt; </xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
	
					<xsl:text>object.Equals(o.</xsl:text>
					<xsl:value-of select="$column/@FieldName"/>
					<xsl:text>, </xsl:text>
					<xsl:call-template name="FirstCharacterToLowerCase">
						<xsl:with-param name="input" select="$column/@FieldName"/>
					</xsl:call-template>
					<xsl:text>)</xsl:text>
	
					<xsl:if test="position()!=last()">
						<xsl:text> &amp;&amp; </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>);
		}</xsl:text>
			</xsl:for-each>
			
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ReferencedTableMappingSchemaName=$table/@SchemaName and @ReferencedTableMappingName=$table/@TableName]">
				<xsl:variable name="foreignKey" select="."/>
				<xsl:variable name="parentTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ParentTableMappingSchemaName and @TableName=$foreignKey/@ParentTableMappingName]"/>
				<xsl:variable name="referencedTableMapping" select="//P:TableMapping[@SchemaName=$foreignKey/@ReferencedTableMappingSchemaName and @TableName=$foreignKey/@ReferencedTableMappingName]"/>
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				
				<xsl:if test="$referencedTableMapping/@Exclude='false' and $parentTableMapping/@Exclude='false'">
					<xsl:text>
		
		private void Attach</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>(</xsl:text>
					<xsl:value-of select="$parentTableMapping/@ClassName"/>
					<xsl:text> entity)
		{
			this.OnPropertyChanging();
			entity.</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text> = this;
		}

		private void Detach</xsl:text>
					<xsl:value-of select="@PluralPropertyName"/>
					<xsl:text>(</xsl:text>
					<xsl:value-of select="$parentTableMapping/@ClassName"/>
					<xsl:text> entity)
		{
			this.OnPropertyChanging();
			entity.</xsl:text>
					<xsl:value-of select="@PropertyName"/>
					<xsl:text> = null;
		}</xsl:text>
				</xsl:if>
			</xsl:for-each>

      <xsl:text>

		public IEnumerable&lt;DeleteConflict&gt; GetDeleteConflicts(DA.</xsl:text>
      <xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
      <xsl:text> context)
		{</xsl:text>

      <xsl:choose>
        <xsl:when test="$parentFKs">
          <xsl:for-each select="$parentFKs">
            <xsl:variable name="fk" select="."/>
            <xsl:variable name="fkTable" select="/P:Project/P:TableMappings/P:TableMapping[@Exclude='false' and @SchemaName=$fk/@ParentTableMappingSchemaName and @TableName=$fk/@ParentTableMappingName]"/>
            <xsl:variable name="fkDisplayNameOverride" select="$fkTable/P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
            <xsl:variable name="fkPluralDisplayNameOverride" select="$fkTable/P:Attributes/P:Attribute[@Key='PluralDisplayName']/@Value"/>

            <xsl:if test="$fkTable">
              <xsl:text>
			if (!this.</xsl:text>
              <xsl:value-of select="@PluralFieldName"/>
              <xsl:text>.IsNullOrEmpty())
				yield return new DeleteConflict(typeof(</xsl:text>
              <xsl:value-of select="$fkTable/@ClassName"/>
              <xsl:text>), "</xsl:text>
				 <xsl:choose>
				 	<xsl:when test="$fkDisplayNameOverride">
              		<xsl:value-of select="$fkDisplayNameOverride"/>
          		</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="$fkTable/@ClassName"/>
					</xsl:otherwise>
              </xsl:choose>
              <xsl:text>", "</xsl:text>
				 <xsl:choose>
				 	<xsl:when test="$fkPluralDisplayNameOverride">
              		<xsl:value-of select="$fkPluralDisplayNameOverride"/>
          		</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="$fkTable/@PluralClassName"/>
					</xsl:otherwise>
              </xsl:choose>
              <xsl:text>", this.</xsl:text>
              <xsl:value-of select="@PluralFieldName"/>
              <xsl:text>);
		  </xsl:text>
            </xsl:if>
          </xsl:for-each>
        </xsl:when>
        <xsl:otherwise>
          <xsl:text>
			yield break;</xsl:text>
        </xsl:otherwise>
      </xsl:choose>

      <xsl:text>
		}</xsl:text>
			
		<xsl:text>
		
		/// &lt;summary&gt;Clones this instance into a new instance.&lt;/summary&gt;
		public new </xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text> Clone(bool includePrimaryKey = false, bool includeCreatedAndModifiedDates = false) {
			</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> target = new </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>();
			
			CloneInto(target, includePrimaryKey, includeCreatedAndModifiedDates);
			
			return target;
		}
		
		/// &lt;summary&gt;Clones this instance into the provided instance.&lt;/summary&gt;
		public void CloneInto(</xsl:text>
		<xsl:value-of select="@ClassName"/>
		<xsl:text> target, bool includePrimaryKey = false, bool includeCreatedAndModifiedDates = false) {
			base.CloneInto(target, includePrimaryKey, includeCreatedAndModifiedDates);
		}
		
		/// &lt;summary&gt;
		///     Creates a deep copy of this instance as its base DataObject. This is
		///     useful when the object needs to be passed across a boundary where
		///     the DataAccess layer should not - or cannot - be exposed.
		/// &lt;/summary&gt;
		/// &lt;returns&gt;A deep copy of this instance as its base DataObject.&lt;/returns&gt;
		public DO.</xsl:text>
			<xsl:value-of select="@ClassName"/>
		    <xsl:text> ToBaseDataObject()
		{
			return new DO.</xsl:text>
			<xsl:value-of select="@ClassName"/>
		    <xsl:text>()
			{</xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
				<xsl:text>
					</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> = this.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:if test="position()!=last()">
					<xsl:text>, </xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:text>
			};
		}
        
		/// &lt;summary&gt;Raises the PropertyChanging event (as applicable).&lt;/summary&gt;
		protected virtual void OnPropertyChanging()
		{
			if (this.PropertyChanging != null)
				this.PropertyChanging(this, emptyChangingEventArgs);
		}
		
		/// &lt;summary&gt;Raises the PropertyChanged event (as applicable).&lt;/summary&gt;
		/// &lt;param name="propertyName">The name of the property which changed.&lt;/param&gt;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		
		/// &lt;summary&gt;This should be called whenever some action takes place that may render the cache of this object invalid or stale.&lt;/summary&gt;
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
		
		partial void OnLoaded();
		partial void OnValidate(ChangeAction action);
		partial void OnCreated();</xsl:text>
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
				<xsl:variable name="dataType" select="@DataType"/>
				<xsl:text>
		partial void On</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Changing(</xsl:text>
				<xsl:choose>
					<xsl:when test="P:EnumerationMapping">
						<xsl:text>DO.</xsl:text>
						<xsl:value-of select="P:EnumerationMapping/@Name"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@DataType"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:if test="@Nullable='true' and (P:EnumerationMapping or ../../../../P:DataTypeMappings/P:DataTypeMapping[@ApplicationDataType=$dataType]/@Nullable='true')">
					<xsl:text>?</xsl:text>
				</xsl:if>
				<xsl:text> value);
		partial void On</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Changed();</xsl:text>
			</xsl:for-each>
			<xsl:text>
	}</xsl:text>
		</xsl:for-each>
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>