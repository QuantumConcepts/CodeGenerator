<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>

	<xsl:include href="../CSharp/Common.xslt"/>

	<xsl:param name="templateName"/>

	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.ComponentModel.DataAnnotations'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Web.Mvc'"/>
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
				<xsl:text>.Logic</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute[@Key='MVC-Admin']]">
			<xsl:variable name="table" select="."/>
			<xsl:variable name="tableName" select="$table/@TableName"/>
			<xsl:variable name="className" select="$table/@ClassName"/>
			<xsl:variable name="pluralClassName" select="$table/@PluralClassName"/>
			<xsl:variable name="allColumns" select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false' and P:Attributes/P:Attribute[@Key='MVC-Admin-Show']]"/>
			<xsl:variable name="sortableColumns" select="$allColumns[P:Attributes/P:Attribute[@Key='MVC-Admin-Sortable']]"/>
			<xsl:variable name="hasLists" select="$allColumns/P:EnumerationMapping or /P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$allColumns/@ColumnName]"/>

			<xsl:text>
namespace </xsl:text>
			<xsl:value-of select="/P:Project/@RootNamespace"/>
			<xsl:text>.Web.Areas.Administration.Models.</xsl:text>
			<xsl:value-of select="$pluralClassName"/>
			<xsl:text>
{
	/// &lt;summary&gt;Defines an enumeration of fields which may be used for sorting the </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>Model.&lt;/summary&gt;
	public enum </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>ModelSortField
	{
		</xsl:text>
			<xsl:for-each select="$sortableColumns">
				<xsl:variable name="columnName" select="@ColumnName"/>
				<xsl:variable name="foreignKeyParent" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
				
				<xsl:choose>
					<xsl:when test="$foreignKeyParent">
						<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@FieldName"/>
					</xsl:otherwise>
				</xsl:choose>
				
				<xsl:if test="position()!=last()">
					<xsl:text>,
		</xsl:text>
				</xsl:if>
			</xsl:for-each>
			<xsl:text>
	}
	
	/// &lt;summary&gt;Model class which exposes properties based on the </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text> data object.&lt;/summary&gt;
	public partial class </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>Model : BaseModel
	{
		[HiddenInput]
		[TemplateVisibility(false, true)]
		public int? ID { get; set; }</xsl:text>
			<xsl:for-each select="$allColumns[@PrimaryKey='false']">
				<xsl:variable name="columnName" select="@ColumnName"/>
				<xsl:variable name="fieldName" select="@FieldName"/>
				<xsl:variable name="foreignKeyParent" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
				<xsl:variable name="foreignKeyParentTable" select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$foreignKeyParent/@ReferencedTableMappingName]"/>
				<xsl:variable name="foreignKeyParentName">
					<xsl:choose>
						<xsl:when test="$foreignKeyParent/P:Attributes/P:Attribute[@Key='DisplayName']/@Value">
							<xsl:value-of select="$foreignKeyParent/P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
						</xsl:when>
						<xsl:when test="P:Attributes/P:Attribute[@Key='DisplayName']/@Value">
							<xsl:value-of select="P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
						</xsl:when>
						<xsl:when test="$foreignKeyParentTable/P:Attributes/P:Attribute[@Key='DisplayName']/@Value">
							<xsl:value-of select="$foreignKeyParentTable/P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="$foreignKeyParentTable/@ClassName"/>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:variable>
				
				<xsl:value-of select="$newLine"/>
				<xsl:if test="@NullableInDatabase!='true'">
					<xsl:text>
		[Required]</xsl:text>
				</xsl:if>
				<xsl:text>
		[Display(Name = "</xsl:text>
				<xsl:choose>
					<xsl:when test="$foreignKeyParent">
						<xsl:value-of select="$foreignKeyParentName"/>
					</xsl:when>
					<xsl:when test="P:Attributes/P:Attribute[@Key='DisplayName']/@Value != ''">
						<xsl:value-of select="P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@FieldName"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>")]</xsl:text>
				<xsl:choose>
					<xsl:when test="P:Attributes/P:Attribute[@Key='MVC-Admin-DataType']/@Value != ''">
						<xsl:text>
		[DataType("</xsl:text>
						<xsl:value-of select="P:Attributes/P:Attribute[@Key='MVC-Admin-DataType']/@Value"/>
						<xsl:text>")]</xsl:text>
					</xsl:when>
					<xsl:when test="@DataType='DateTime'">
						<xsl:text>
		[DataType("Date")]</xsl:text>
					</xsl:when>
					<xsl:when test="P:EnumerationMapping or $foreignKeyParent">
						<xsl:text>
		[DataType("DropDownList")]
		[AdditionalMetadata("List", "</xsl:text>
						<xsl:choose>
							<xsl:when test="P:EnumerationMapping">
								<xsl:value-of select="P:EnumerationMapping/@Name"/>
							</xsl:when>
							<xsl:when test="$foreignKeyParent">
								<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
							</xsl:when>
						</xsl:choose>
						<xsl:text>List")]</xsl:text>
					</xsl:when>
				</xsl:choose>
				<xsl:if test="P:Attributes/P:Attribute[@Key='MVC-Admin-Index-Column'] and not(P:EnumerationMapping) and not($foreignKeyParent)">
					<xsl:text>
		[AdditionalMetadata("ShowInTable", true)]</xsl:text>
				</xsl:if>
				<xsl:if test="P:Attributes/P:Attribute[@Key='MVC-Admin-Index-Column-Order'] and not(P:EnumerationMapping) and not($foreignKeyParent)">
					<xsl:text>
		[AdditionalMetadata("TableColumnOrder", </xsl:text>
					<xsl:value-of select="P:Attributes/P:Attribute[@Key='MVC-Admin-Index-Column-Order']/@Value"/>
					<xsl:text>)]</xsl:text>
				</xsl:if>
				<xsl:if test="$sortableColumns[@FieldName=$fieldName] and not($foreignKeyParent)">
					<xsl:text>
		[AdditionalMetadata("Sortable", true)]</xsl:text>
				</xsl:if>
				<xsl:if test="P:Attributes/P:Attribute[@Key='MVC-Admin-Allow-HTML']">
					<xsl:text>
		[AllowHtml]</xsl:text>
				</xsl:if>
				<xsl:if test="@FieldName = 'Created' or @FieldName = 'Modified'">
					<xsl:text>
		[TemplateVisibility(true, false)]</xsl:text>
				</xsl:if>
				<xsl:text>
		public </xsl:text>
				<xsl:choose>
					<xsl:when test="P:EnumerationMapping">
						<xsl:text>DO.</xsl:text>
						<xsl:value-of select="P:EnumerationMapping/@Name"/>
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
				<xsl:text> { get; set; }</xsl:text>
				<xsl:if test="P:EnumerationMapping or $foreignKeyParent">
					<xsl:text>
		
		[TemplateVisibility(false, false)]
		public List&lt;ListItem&gt; </xsl:text>
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:value-of select="P:EnumerationMapping/@Name"/>
						</xsl:when>
						<xsl:when test="$foreignKeyParent">
							<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
						</xsl:when>
					</xsl:choose>
					<xsl:text>List { get; private set; }
		
		[Display(Name = "</xsl:text>
				<xsl:choose>
					<xsl:when test="$foreignKeyParent">
						<xsl:value-of select="$foreignKeyParentName"/>
					</xsl:when>
					<xsl:when test="P:Attributes/P:Attribute[@Key='DisplayName']/@Value">
						<xsl:value-of select="P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@FieldName"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>")]
		[TemplateVisibility(true, false)]</xsl:text>
					<xsl:if test="P:Attributes/P:Attribute[@Key='MVC-Admin-Index-Column']">
						<xsl:text>
		[AdditionalMetadata("ShowInTable", true)]</xsl:text>
					</xsl:if>
				<xsl:if test="$sortableColumns[@FieldName=$fieldName]">
					<xsl:text>
		[AdditionalMetadata("Sortable", true)]</xsl:text>
				</xsl:if>
					<xsl:text>
		public string </xsl:text>
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:value-of select="@FieldName"/>
						</xsl:when>
						<xsl:when test="$foreignKeyParent">
							<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
						</xsl:when>
					</xsl:choose>
					<xsl:text>Name { get; private set; }</xsl:text>
				</xsl:if>
			</xsl:for-each>
		
			<xsl:text>
		
		<![CDATA[/// <summary>Creates a new instance of this class.</summary>]]>
		public </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>Model() { }</xsl:text>
			
			<xsl:text>
		
		<![CDATA[/// <summary>Creates a new instance of this class based on the data object associated with the provided ID.</summary>]]>
		public </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>Model(int id) : this(</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text>Logic.GetByID(id)) { }
		
		<![CDATA[/// <summary>Creates a new instance of this class based on the provided data object.</summary>]]>
		public </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>Model(DA.</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text> instance)
		{
			Initialize(instance);
		}</xsl:text>
			
			<xsl:text>
		
		<![CDATA[/// <summary>Populates the class with data based on the provided ID.</summary>]]>
		public void Initialize()
		{
			DA.</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text> instance = null;
			
			if (this.ID.HasValue)
				instance = </xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text>Logic.GetByID(this.ID.Value);
			
			Initialize(instance);
		}
		
		<![CDATA[/// <summary>Populates the model with data based on the data object.</summary>]]>
		public void Initialize(DA.</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text> instance)
		{
			if (instance != null)
			{
				this.ID = instance.ID;</xsl:text>
				
				<xsl:for-each select="$allColumns">
					<xsl:variable name="columnName" select="@ColumnName"/>
					<xsl:variable name="fieldName" select="@FieldName"/>
					<xsl:variable name="foreignKeyParent" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
					
					<xsl:text>
				this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = instance.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>;</xsl:text>
					<xsl:if test="P:EnumerationMapping or $foreignKeyParent">
						<xsl:text>
				this.</xsl:text>
						<xsl:choose>
							<xsl:when test="P:EnumerationMapping">
								<xsl:value-of select="@FieldName"/>
							</xsl:when>
							<xsl:when test="$foreignKeyParent">
								<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
							</xsl:when>
						</xsl:choose>
						<xsl:text>Name =  instance.</xsl:text>
						<xsl:choose>
							<xsl:when test="P:EnumerationMapping">
								<xsl:value-of select="@FieldName"/>
								<xsl:text>.GetDescription();</xsl:text>
							</xsl:when>
							<xsl:when test="$foreignKeyParent">
								<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
								<xsl:text>.ValueOrDefault(o =&gt; o.ToString());</xsl:text>
							</xsl:when>
						</xsl:choose>
					</xsl:if>
				</xsl:for-each>
				
			<xsl:text>
			}</xsl:text>
			
			<xsl:if test="$hasLists">
				<xsl:text>
			
			LoadLists();</xsl:text>
			</xsl:if>
			
			<xsl:text>
		}</xsl:text>
		
			<xsl:if test="$hasLists">
				<xsl:text>
		<![CDATA[/// <summary>Loads all drop down lists.</summary>]]>
		public void LoadLists()
		{</xsl:text>
				<xsl:for-each select="$allColumns">
					<xsl:variable name="columnName" select="@ColumnName"/>
					<xsl:variable name="fieldName" select="@FieldName"/>
					<xsl:variable name="foreignKeyParent" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
		
					<xsl:if test="P:EnumerationMapping or $foreignKeyParent">
						<xsl:text>
			Load</xsl:text>
						<xsl:choose>
							<xsl:when test="P:EnumerationMapping">
								<xsl:value-of select="P:EnumerationMapping/@Name"/>
							</xsl:when>
							<xsl:when test="$foreignKeyParent">
								<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
							</xsl:when>
						</xsl:choose>
						<xsl:text>List();</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>
		}</xsl:text>
		
				<xsl:for-each select="$allColumns">
					<xsl:variable name="columnName" select="@ColumnName"/>
					<xsl:variable name="fieldName" select="@FieldName"/>
					<xsl:variable name="foreignKeyParent" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
			
					<xsl:if test="P:EnumerationMapping or $foreignKeyParent">
						<xsl:text>
		
		<![CDATA[/// <summary>Loads the drop down list for the ]]></xsl:text>
						<xsl:value-of select="$fieldName"/>
						<xsl:text><![CDATA[ property.</summary>]]>
		public void Load</xsl:text>
							<xsl:choose>
								<xsl:when test="P:EnumerationMapping">
									<xsl:value-of select="P:EnumerationMapping/@Name"/>
								</xsl:when>
								<xsl:when test="$foreignKeyParent">
									<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
								</xsl:when>
							</xsl:choose>
							<xsl:text>List()
		{
			bool loadDefaultList = true;
			
			Override</xsl:text>
							<xsl:choose>
								<xsl:when test="P:EnumerationMapping">
									<xsl:value-of select="P:EnumerationMapping/@Name"/>
								</xsl:when>
								<xsl:when test="$foreignKeyParent">
									<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
								</xsl:when>
							</xsl:choose>
							<xsl:text>List(ref loadDefaultList);
			
			if (loadDefaultList)
				this.</xsl:text>
							<xsl:choose>
								<xsl:when test="P:EnumerationMapping">
									<xsl:value-of select="P:EnumerationMapping/@Name"/>
								</xsl:when>
								<xsl:when test="$foreignKeyParent">
									<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
								</xsl:when>
							</xsl:choose>
							<xsl:text>List = </xsl:text>
							<xsl:choose>
								<xsl:when test="P:EnumerationMapping">
									<xsl:text>EnumUtil.GetEnumValues&lt;DO.</xsl:text>
									<xsl:value-of select="P:EnumerationMapping/@Name"/>
									<xsl:text>&gt;().OrderBy(o =&gt; o.Description).Select(o =&gt; new ListItem(o.Description, o.Value.ToString()))</xsl:text>
								</xsl:when>
								<xsl:when test="$foreignKeyParent">
									<xsl:variable name="referencedTable" select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$foreignKeyParent/@ReferencedTableMappingName]"/>
									
									<xsl:value-of select="$referencedTable/@ClassName"/>
									<xsl:text>Logic.GetAll().AsEnumerable().OrderBy(o =&gt; o.ToString()).Select(o =&gt; new ListItem(o.ToString(), o.ID.ToString()))</xsl:text>
								</xsl:when>
							</xsl:choose>
							<xsl:if test="@Nullable='true'">
								<xsl:text>.AddEmptyListItem()</xsl:text>
							</xsl:if>
							<xsl:text>.ToList();
		}
		
		<![CDATA[/// <summary>Allows for the overriding of the contents of the ]]></xsl:text>
							<xsl:choose>
								<xsl:when test="P:EnumerationMapping">
									<xsl:value-of select="P:EnumerationMapping/@Name"/>
								</xsl:when>
								<xsl:when test="$foreignKeyParent">
									<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
								</xsl:when>
							</xsl:choose>
							<xsl:text><![CDATA[List.</summary>
		/// <param name="loadDefaultList">Should be set to false if overriding occurred and the default list should not be loaded.</param>]]>
		partial void Override</xsl:text>
							<xsl:choose>
								<xsl:when test="P:EnumerationMapping">
									<xsl:value-of select="P:EnumerationMapping/@Name"/>
								</xsl:when>
								<xsl:when test="$foreignKeyParent">
									<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
								</xsl:when>
							</xsl:choose>
							<xsl:text>List(ref bool loadDefaultList);</xsl:text>
						</xsl:if>
					</xsl:for-each>
				</xsl:if>
			<xsl:text>
	}
}
</xsl:text>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>