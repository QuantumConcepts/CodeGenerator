<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="Common.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Data.Entity.Core.Objects'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Data.Entity.Core.Objects.DataClasses'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Data.EntityClient'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Xml.Serialization'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Runtime.Serialization'"/>
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
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.DataAccess.Cache</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:text>
[assembly: EdmSchemaAttribute()]</xsl:text>
		
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:variable name="tableName" select="@TableName"/>
			<xsl:variable name="className" select="@ClassName"/>
			<xsl:variable name="pluralClassName" select="@PluralClassName"/>
			<xsl:variable name="pkColumn" select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='true'][1]"/>
			
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@ReferencedTableMappingName=$tableName]">
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedTableMapping" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableMappingName]"/>
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentTableMapping" select="../../P:TableMappings/P:TableMapping[@TableName=ParentTableMappingName]"/>
				<xsl:if test="$referencedTableMapping/@Exclude='false' and $parentTableMapping/@Exclude='false'">
					<xsl:text>
[assembly: EdmRelationshipAttribute("</xsl:text>
					<xsl:value-of select="@RootNamespace"/>
					<xsl:text>.DataAccess", "</xsl:text>
					<xsl:value-of select="@ForeignKeyName"/>
					<xsl:text>", "</xsl:text>
					<xsl:value-of select="$referencedTableMapping/@ClassName"/>
					<xsl:text>", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(</xsl:text>
					<xsl:value-of select="$referencedTableMapping/@ClassName"/>
					<xsl:text>), "</xsl:text>
					<xsl:value-of select="parentTableMapping/@ClassName"/>
					<xsl:text>", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(</xsl:text>
					<xsl:value-of select="parentTableMapping/@ClassName"/>
					<xsl:text>), true)]
					</xsl:text>
				</xsl:if>
			</xsl:for-each>
		</xsl:for-each>
		
		<xsl:text>

namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.DataAccess
{
	/// &lt;summary&gt;Exposes all functionality to interact with the database.&lt;/summary&gt;
	public partial class </xsl:text>
		<xsl:value-of select="P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text> : ObjectContext
    {
        /// &lt;summary&gt;Initializes a new </xsl:text>
		<xsl:value-of select="P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text> object using the connection string found in the application configuration file.&lt;/summary&gt;
        public </xsl:text>
		<xsl:value-of select="P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>()
        	: base("name=Default", "Default")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// &lt;summary&gt;Initialize a new </xsl:text>
		<xsl:value-of select="P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text> object.&lt;/summary&gt;
        public </xsl:text>
		<xsl:value-of select="P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>(string connectionString)
        	: base(connectionString, "Default")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// &lt;summary&gt;Initialize a new </xsl:text>
		<xsl:value-of select="P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text> object.&lt;/summary&gt;
        public </xsl:text>
		<xsl:value-of select="P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
		<xsl:text>(EntityConnection connection)
        	: base(connection, "Default")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
        
        partial void OnContextCreated();</xsl:text>
		
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:text>
		
		private ObjectSet&lt;</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt; _</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>;
        
        public ObjectSet&lt;</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt; </xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>
        {
            get
            {
                if (_</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text> == null)
                    _</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text> = base.CreateObjectSet&lt;</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt;("</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>");
				
                return _</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>;
            }
        }</xsl:text>
		</xsl:for-each>
		<xsl:text>
	}</xsl:text>
		
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false']">
			<xsl:variable name="tableName" select="@TableName"/>
			<xsl:variable name="className" select="@ClassName"/>
			<xsl:variable name="pluralClassName" select="@PluralClassName"/>
			<xsl:variable name="pkColumn" select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='true'][1]"/>
			
			<xsl:call-template name="GetTableMappingDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			
			<xsl:text>
    [EdmEntityTypeAttribute(NamespaceName="</xsl:text>
			<xsl:value-of select="/P:Project/@RootNamespace"/>
			<xsl:text>.DataAccess", Name="</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> : EntityObject
	{
		
        /// &lt;summary&gt;This event indicates that the current cache is invalid or stale and should be refreshed.&lt;/summary&gt;
        public static event ParameterlessDelegate CacheNeedsRefresh;</xsl:text>
			
			<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
				<xsl:variable name="dataType">
					<xsl:variable name="baseDataType" select="@DataType"/>
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:text></xsl:text>
							<xsl:value-of select="P:EnumerationMapping/@Name"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@DataType"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:if test="@Nullable='true' and (P:EnumerationMapping or ../../../../P:DataTypeMappings/P:DataTypeMapping[@ApplicationDataType=$baseDataType]/@Nullable='true')">
						<xsl:text>?</xsl:text>
					</xsl:if>
				</xsl:variable>
				<xsl:text>
        
       	protected </xsl:text>
				<xsl:value-of select="$dataType"/>
				<xsl:text> _</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=</xsl:text>
				<xsl:value-of select="@NullableInDatabase"/>
				<xsl:text>)]
        [DataMemberAttribute()]
        public </xsl:text>
				<xsl:value-of select="$dataType"/>
				<xsl:text> </xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>
        {
            get { return _</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>; }
            set
            {
                if (_</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> != value)
                {
                    On</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Changing(value);
                    ReportPropertyChanging("</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>");
                    _</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:choose>
					<xsl:when test="P:EnumerationMapping">
						<xsl:text> = value;</xsl:text>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text> = StructuralObject.SetValidValue(value</xsl:text>
						<xsl:if test="$dataType='string'">
							<xsl:text>, </xsl:text>
							<xsl:value-of select="@NullableInDatabase"/>
						</xsl:if>
						<xsl:text>);</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>
                    ReportPropertyChanged("</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>");
                    On</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Changed();
                }
            }
        }
        
        partial void On</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Changing(</xsl:text>
				<xsl:value-of select="$dataType"/>
				<xsl:text> value);
        partial void On</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>Changed();</xsl:text>
			</xsl:for-each>
		
			<xsl:value-of select="$newLine"/>
			
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingName=$tableName]">
				<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedTable" select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]"/>
				<xsl:call-template name="GetSummaryDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("</xsl:text>
				<xsl:value-of select="/P:Project/@RootNamespace"/>
				<xsl:text>.DataAccess", "</xsl:text>
				<xsl:value-of select="@ForeignKeyName"/>
				<xsl:text>", "</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>")]
        public </xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text> </xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference&lt;</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>&gt;("</xsl:text>
				<xsl:value-of select="/P:Project/@RootNamespace"/>
				<xsl:text>.DataAccess.</xsl:text>
				<xsl:value-of select="@ForeignKeyName"/>
				<xsl:text>", "</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>").Value; }
            set { ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference&lt;</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>&gt;("</xsl:text>
				<xsl:value-of select="/P:Project/@RootNamespace"/>
				<xsl:text>.DataAccess.</xsl:text>
				<xsl:value-of select="@ForeignKeyName"/>
				<xsl:text>", "</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>").Value = value; }
        }
        
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference&lt;</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>&gt; </xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>Reference
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference&lt;</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>&gt;("</xsl:text>
				<xsl:value-of select="/P:Project/@RootNamespace"/>
				<xsl:text>.DataAccess.</xsl:text>
				<xsl:value-of select="@ForeignKeyName"/>
				<xsl:text>", "</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference&lt;</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>&gt;("</xsl:text>
				<xsl:value-of select="/P:Project/@RootNamespace"/>
				<xsl:text>.DataAccess.</xsl:text>
				<xsl:value-of select="@ForeignKeyName"/>
				<xsl:text>", "</xsl:text>
				<xsl:value-of select="$referencedTable/@ClassName"/>
				<xsl:text>", value);
            }
        }
				</xsl:text>
			</xsl:for-each>
			
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ReferencedTableMappingName=$tableName]">
				<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				<xsl:variable name="parentTable" select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]"/>
				<xsl:call-template name="GetForeignKeyGetDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("</xsl:text>
				<xsl:value-of select="/P:Project/@RootNamespace"/>
				<xsl:text>.DataAccess", "</xsl:text>
				<xsl:value-of select="@ForeignKeyName"/>
				<xsl:text>", "</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text>")]
        public EntityCollection&lt;</xsl:text>
				<xsl:value-of select="$parentTable/@ClassName"/>
				<xsl:text>&gt; </xsl:text>
				<xsl:value-of select="$parentTable/@PluralClassName"/>
				<xsl:text>
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection&lt;</xsl:text>
				<xsl:value-of select="$parentTable/@ClassName"/>
				<xsl:text>&gt;("</xsl:text>
				<xsl:value-of select="/P:Project/@RootNamespace"/>
				<xsl:text>.DataAccess.</xsl:text>
				<xsl:value-of select="@ForeignKeyName"/>
				<xsl:text>", "</xsl:text>
				<xsl:value-of select="$parentTable/@ClassName"/>
				<xsl:text>"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection&lt;</xsl:text>
				<xsl:value-of select="$parentTable/@ClassName"/>
				<xsl:text>&gt;("</xsl:text>
				<xsl:value-of select="/P:Project/@RootNamespace"/>
				<xsl:text>.DataAccess.</xsl:text>
				<xsl:value-of select="@ForeignKeyName"/>
				<xsl:text>", "</xsl:text>
				<xsl:value-of select="$parentTable/@ClassName"/>
				<xsl:text>", value);
            }
        }
				</xsl:text>
			</xsl:for-each>
			
			<xsl:call-template name="GetGetAllDocumentation">
				<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
			</xsl:call-template>
			<xsl:text>
		public static IEnumerable&lt;</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>&gt; GetAll()
		{
			return GetAll</xsl:text>
			<xsl:text>(new </xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text>());</xsl:text>
			<xsl:text>
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
			return context.</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>;
		}

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
			<xsl:text> GetBy</xsl:text>
			<xsl:value-of select="$pkColumn/@FieldName"/>
			<xsl:text>(</xsl:text>
			<xsl:value-of select="$pkColumn/@DataType"/>
			<xsl:text> </xsl:text>
			<xsl:value-of select="$pkColumn/@FieldName"/>
			<xsl:text>)
		{
			return GetBy</xsl:text>
			<xsl:value-of select="$pkColumn/@FieldName"/>
			<xsl:text>(new </xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text>(), </xsl:text>
			<xsl:value-of select="$pkColumn/@FieldName"/>
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
		public static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> GetBy</xsl:text>
			<xsl:value-of select="$pkColumn/@FieldName"/>
			<xsl:text>(</xsl:text>
			<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
			<xsl:text> context, </xsl:text>
			<xsl:value-of select="$pkColumn/@DataType"/>
			<xsl:text> </xsl:text>
			<xsl:value-of select="$pkColumn/@FieldName"/>
			<xsl:text>)
		{
			return context.</xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>.SingleOrDefault(o => o.</xsl:text>
			<xsl:value-of select="$pkColumn/@FieldName"/>
			<xsl:text> == </xsl:text>
			<xsl:value-of select="$pkColumn/@FieldName"/>
			<xsl:text>);
		}
			</xsl:text>
	
			<xsl:for-each select="../../P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingName=$tableName]">
				<xsl:variable name="parentTableMappingName" select="@ParentTableMappingName"/>
				<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
				<xsl:variable name="referencedTableMappingName" select="@ReferencedTableMappingName"/>
				<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
				<xsl:call-template name="GetForeignKeyGetDocumentation">
					<xsl:with-param name="spacingBefore" select="concat($tab, $tab)"/>
				</xsl:call-template>
				<xsl:text>
		public static IEnumerable&lt;</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableMappingName]/@ClassName"/>
				<xsl:text>&gt; GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableMappingName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>)
		{
            return GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(new </xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text>(), </xsl:text>
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
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableMappingName]/@ClassName"/>
				<xsl:text>&gt; GetBy</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text> context, </xsl:text>
				<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableMappingName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
				<xsl:text> </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>)
		{
				</xsl:text>
				<xsl:choose>
					<xsl:when test="../../P:Attributes/P:Attribute[@Key='Cache']">
						<xsl:text>var source = </xsl:text>
						<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableMappingName]/@ClassName"/>
						<xsl:text>Cache.Instance.All;</xsl:text>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>var source = context.</xsl:text>
						<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableMappingName]/@PluralClassName"/>
						<xsl:text>;</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>
			return (from o in source where o.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> == </xsl:text>
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text> select o);
		}
		</xsl:text>
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
			return GetBy</xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
	
					<xsl:value-of select="$column/@FieldName"/>
					<xsl:if test="position()!=last()">
						<xsl:text>And</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>(new </xsl:text>
				<xsl:value-of select="/P:Project/P:Attributes/P:Attribute[@Key='DataContextName']/@Value"/>
				<xsl:text>(), </xsl:text>
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
			return context.</xsl:text>
				<xsl:value-of select="../../@PluralClassName"/>
				<xsl:text>.FirstOrDefault(o =&gt; </xsl:text>
				<xsl:for-each select="P:ColumnNames/P:ColumnName">
					<xsl:variable name="columnName" select="text()"/>
					<xsl:variable name="column" select="../../../../P:ColumnMappings/P:ColumnMapping[@ColumnName=$columnName]"/>
	
					<xsl:text>o.</xsl:text>
					<xsl:value-of select="$column/@FieldName"/>
					<xsl:text> == </xsl:text>
					<xsl:call-template name="FirstCharacterToLowerCase">
						<xsl:with-param name="input" select="$column/@FieldName"/>
					</xsl:call-template>
	
					<xsl:if test="position()!=last()">
						<xsl:text> &amp;&amp; </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>);
		}
		</xsl:text>
			</xsl:for-each>
			
			<xsl:text>
		
		/// &lt;summary&gt;This should be called whenever some action takes place that may render the cache of this object invalid or stale.&lt;/summary&gt;
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
	}</xsl:text>
		</xsl:for-each>
		
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>