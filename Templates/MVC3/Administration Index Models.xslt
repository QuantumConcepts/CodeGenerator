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
			<xsl:with-param name="namespace" select="'System.Linq.Expressions'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Web'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Web.Helpers'"/>
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
			<xsl:variable name="sortableColumns" select="$allColumns[@PrimaryKey='false' and P:Attributes/P:Attribute[@Key='MVC-Admin-Sortable']]"/>
			<xsl:variable name="filterableColumns" select="$allColumns[@PrimaryKey='false' and P:Attributes/P:Attribute[@Key='MVC-Admin-Filterable']]"/>
			<xsl:variable name="hasLists" select="$filterableColumns and ($filterableColumns/P:EnumerationMapping or /P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$filterableColumns/@ColumnName])"/>
			<xsl:variable name="searchableColumns" select="$allColumns[@DataType='string' and not(P:EnumerationMapping)]"/>
		
			<xsl:text>
namespace </xsl:text>
			<xsl:value-of select="/P:Project/@RootNamespace"/>
			<xsl:text>.Web.Areas.Administration.Models.</xsl:text>
			<xsl:value-of select="$pluralClassName"/>
			<xsl:text>
{
	/// &lt;summary&gt;Model class which exposes a filterable list of </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text> data objects.&lt;/summary&gt;
	public partial class IndexModel : ListModel&lt;</xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>ModelSortField, DA.</xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>, </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>Model&gt;
	{
		[HiddenInput]
		[TemplateVisibility(false, true)]
		public string ReturnUrl { get; set; }
	        	</xsl:text>
			<xsl:if test="$searchableColumns">
				<xsl:text>
		public string Search { get; set; }</xsl:text>
			</xsl:if>
			
			<xsl:if test="$filterableColumns">
				<xsl:for-each select="$filterableColumns">
					<xsl:variable name="columnName" select="@ColumnName"/>
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
					<xsl:variable name="listName">
						<xsl:choose>
							<xsl:when test="P:EnumerationMapping">
								<xsl:value-of select="P:EnumerationMapping/@Name"/>
							</xsl:when>
							<xsl:when test="$foreignKeyParent">
								<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="@FieldName"/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:variable>
					
					<xsl:text>
		
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
						<xsl:when test="P:EnumerationMapping or $foreignKeyParent or @DataType='bool'">
							<xsl:text>
		[DataType("DropDownList")]
		[AdditionalMetadata("List", "</xsl:text>
							<xsl:value-of select="$listName"/>
							<xsl:text>List")]</xsl:text>
						</xsl:when>
					</xsl:choose>
					<xsl:text>
		public </xsl:text>
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:text>DO.</xsl:text>
							<xsl:value-of select="P:EnumerationMapping/@Name"/>
							<xsl:text>?</xsl:text>
						</xsl:when>
						<xsl:otherwise>
							<xsl:variable name="dataType" select="@DataType"/>
							
							<xsl:value-of select="@DataType"/>
							
							<xsl:if test="/P:Project/P:DataTypeMappings/P:DataTypeMapping[@ApplicationDataType=$dataType]/@Nullable='true'">
								<xsl:text>?</xsl:text>
							</xsl:if>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text> </xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> { get; set; }</xsl:text>
					
					<xsl:if test="P:EnumerationMapping or $foreignKeyParent or @DataType='bool'">
						<xsl:text>
		
		[TemplateVisibility(false, false)]
		public List&lt;ListItem&gt; </xsl:text>
						<xsl:value-of select="$listName"/>
						<xsl:text>List { get; private set; }</xsl:text>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
				<xsl:text>
		
		<![CDATA[/// <summary>Creates a new instance of this class.</summary>]]>
		public IndexModel()
		{</xsl:text>
			<xsl:if test="$hasLists">
				<xsl:text>
			LoadLists();</xsl:text>
			</xsl:if>
			<xsl:text>
			QueryData(true);
		}
		
		<![CDATA[/// <summary>Initializes the sort functions. This must be called every time this class is instantiated if sorting is to be used.</summary>]]>
		public override void InitializeSortFunctions()
		{</xsl:text>
			<xsl:for-each select="$sortableColumns">
				<xsl:variable name="columnName" select="@ColumnName"/>
				<xsl:variable name="foreignKeyParent" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
				<xsl:variable name="enumName">
					<xsl:choose>
						<xsl:when test="$foreignKeyParent">
								<xsl:value-of select="$foreignKeyParent/@PropertyName"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@FieldName"/>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:variable>
				
				<xsl:text>
			this.SortFunctions.Add(</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text>ModelSortField.</xsl:text>
				<xsl:value-of select="$enumName"/>
				<xsl:text>, new Dictionary&lt;SortDirection, Func&lt;IEnumerable&lt;DA.</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text>&gt;, IEnumerable&lt;DA.</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text>&gt;&gt;&gt;()
			{
				{ SortDirection.Ascending, l => l.OrderBy(o => o.</xsl:text>
				<xsl:value-of select="$enumName"/>
				<xsl:text>) },
				{ SortDirection.Descending, l => l.OrderByDescending(o => o.</xsl:text>
				<xsl:value-of select="$enumName"/>
				<xsl:text>) }
			});</xsl:text>
			</xsl:for-each>
			<xsl:text>
		}
		
		<![CDATA[/// <summary>Queries data using the current filter state, sorting and paging.</summary>]]>
		public override void QueryData(bool applySortingAndPaging)
		{
			IQueryable&lt;DA.</xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>&gt; items = </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>Logic.GetAll();</xsl:text>
				
			<xsl:if test="$searchableColumns">
				<xsl:text>
			
			if (!this.Search.IsNullOrEmpty())
			{
				bool performDefaultSearch = true;
				
				PerformSearch(ref items, ref performDefaultSearch);
			
				if (performDefaultSearch)
				{
					items = items.Where(o =&gt; </xsl:text>
					<xsl:for-each select="$searchableColumns">
						<xsl:text>(o.</xsl:text>
						<xsl:value-of select="@FieldName"/>
						<xsl:text> != null &amp;&amp; o.</xsl:text>
						<xsl:value-of select="@FieldName"/>
						<xsl:text>.Contains(this.Search))</xsl:text>
						
						<xsl:if test="position()!=last()">
							<xsl:text> ||
											 </xsl:text>
						</xsl:if>
					</xsl:for-each>
					<xsl:text>);
				}
			}</xsl:text>
			</xsl:if>
		
			<xsl:for-each select="$filterableColumns">
				<xsl:text>
			
			if (this.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> != null)
				items = items.Where(o =&gt; o.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text> == this.</xsl:text>
				<xsl:value-of select="@FieldName"/>
				<xsl:text>);</xsl:text>
			</xsl:for-each>
			<xsl:text>

            this.TotalCount = items.Count();
            this.Items = (applySortingAndPaging ? ApplySortingAndPaging(items) : items).Select(o => new </xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>Model(o));
		}
		
		<![CDATA[/// <summary>When implemented, allows a search to be performed when the data is queried in order to narrow the results.</summary>]]>
		partial void PerformSearch(ref IQueryable&lt;DA.</xsl:text>
			<xsl:value-of select="$className"/>
			<xsl:text>&gt; items, ref bool performDefaultSearch);</xsl:text>
			
			<xsl:if test="$hasLists">
				<xsl:variable name="columnName" select="@ColumnName"/>
				<xsl:variable name="foreignKeyParent" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
					
				<xsl:text>
		
		<![CDATA[/// <summary>Loads all drop down lists.</summary>]]>
		public void LoadLists()
		{</xsl:text>
				<xsl:for-each select="$filterableColumns">
					<xsl:variable name="filteredColumnName" select="@ColumnName"/>
					<xsl:variable name="fieldName" select="@FieldName"/>
					<xsl:variable name="filteredForeignKeyParent" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$filteredColumnName]"/>
		
					
					<xsl:if test="P:EnumerationMapping or $filteredForeignKeyParent or @DataType='bool'">
						<xsl:text>
			Load</xsl:text>
						<xsl:choose>
							<xsl:when test="P:EnumerationMapping">
								<xsl:value-of select="P:EnumerationMapping/@Name"/>
							</xsl:when>
							<xsl:when test="$filteredForeignKeyParent">
								<xsl:value-of select="$filteredForeignKeyParent/@PropertyName"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="@FieldName"/>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:text>List();</xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>
		}</xsl:text>
		
				<xsl:for-each select="$filterableColumns">
					<xsl:variable name="filteredColumnName" select="@ColumnName"/>
					<xsl:variable name="fieldName" select="@FieldName"/>
					<xsl:variable name="filteredForeignKeyParent" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$filteredColumnName]"/>
					<xsl:variable name="listName">
						<xsl:choose>
							<xsl:when test="P:EnumerationMapping">
								<xsl:value-of select="P:EnumerationMapping/@Name"/>
							</xsl:when>
							<xsl:when test="$filteredForeignKeyParent">
								<xsl:value-of select="$filteredForeignKeyParent/@PropertyName"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="@FieldName"/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:variable>
					
					<xsl:if test="P:EnumerationMapping or $filteredForeignKeyParent or @DataType='bool'">
						<xsl:text>
		
		<![CDATA[/// <summary>Loads the drop down list for the ]]></xsl:text>
						<xsl:value-of select="$fieldName"/>
						<xsl:text><![CDATA[ property.</summary>]]>
		public void Load</xsl:text>
						<xsl:value-of select="$listName"/>
						<xsl:text>List()
		{
			bool loadDefaultList = true;
			
			Override</xsl:text>
						<xsl:value-of select="$listName"/>
						<xsl:text>List(ref loadDefaultList);
			
			if (loadDefaultList)
				this.</xsl:text>
						<xsl:value-of select="$listName"/>
						<xsl:text>List = </xsl:text>
						<xsl:choose>
							<xsl:when test="P:EnumerationMapping">
								<xsl:text>EnumUtil.GetEnumValues&lt;DO.</xsl:text>
								<xsl:value-of select="P:EnumerationMapping/@Name"/>
								<xsl:text>&gt;().OrderBy(o =&gt; o.Description).Select(o =&gt; new ListItem(o.Description, o.ValueString))</xsl:text>
							</xsl:when>
							<xsl:when test="$filteredForeignKeyParent">
								<xsl:variable name="referencedTable" select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$filteredForeignKeyParent/@ReferencedTableMappingName]"/>
								
								<xsl:value-of select="$referencedTable/@ClassName"/>
								<xsl:text>Logic.GetAll().AsEnumerable().OrderBy(o =&gt; o.ToString()).Select(o =&gt; new ListItem(o.ToString(), o.ID.ToString()))</xsl:text>
							</xsl:when>
							<xsl:when test="@DataType='bool'">
								<xsl:text>MvcExtensions.GetYesNoListItems()</xsl:text>
							</xsl:when>
						</xsl:choose>
						<xsl:text>.AddEmptyListItem("(All)").ToList();
		}
		
		<![CDATA[/// <summary>Allows for the overriding of the contents of the ]]></xsl:text>
						<xsl:value-of select="$listName"/>
						<xsl:text><![CDATA[List.</summary>
		/// <param name="loadDefaultList">Should be set to false if overriding occurred and the default list should not be loaded.</param>]]>
		partial void Override</xsl:text>
						<xsl:value-of select="$listName"/>
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