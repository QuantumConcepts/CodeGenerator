<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>

	<xsl:include href="../CSharp/Common.xslt"/>

	<xsl:param name="templateName"/>
	<xsl:param name="elementName"/>

	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Web.Mvc'"/>
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
				<xsl:text>.Logic</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.Web.Controllers</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.Web.Areas.Administration.Controllers
{</xsl:text>
		
		<xsl:for-each select="P:TableMappings/P:TableMapping[@Exclude='false' and P:Attributes/P:Attribute[@Key='MVC-Admin']]">
			<xsl:variable name="tableName" select="@TableName"/>
			<xsl:variable name="table" select="."/>
			<xsl:variable name="className" select="@ClassName"/>
			<xsl:variable name="allColumns" select="P:ColumnMappings/P:ColumnMapping[@Exclude='false' and P:Attributes/P:Attribute[@Key='MVC-Admin-Show']]"/>
			<xsl:variable name="hasLists" select="$allColumns/P:EnumerationMapping or /P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and @ParentTableMappingSchemaName=$table/@SchemaName and @ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$allColumns/@ColumnName]"/>
			<xsl:variable name="modelNamespace">
				<xsl:value-of select="/P:Project/@RootNamespace"/>
				<xsl:text>.Web.Areas.Administration.Models.</xsl:text>
				<xsl:value-of select="@PluralClassName"/>
			</xsl:variable>
			<xsl:variable name="indexModelName">
				<xsl:value-of select="$modelNamespace"/>
				<xsl:text>.IndexModel</xsl:text>
			</xsl:variable>
			<xsl:variable name="detailModelName">
				<xsl:value-of select="$modelNamespace"/>
				<xsl:text>.</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text>Model</xsl:text>
			</xsl:variable>
			<xsl:variable name="editModelName">
				<xsl:value-of select="$modelNamespace"/>
				<xsl:text>.</xsl:text>
				<xsl:value-of select="$className"/>
				<xsl:text>EditModel</xsl:text>
			</xsl:variable>
			<xsl:variable name="displayName">
				<xsl:choose>
					<xsl:when test="P:Attributes/P:Attribute[@Key='DisplayName']">
						<xsl:value-of select="P:Attributes/P:Attribute[@Key='DisplayName']/@Value"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@ClassName"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:variable>
			<xsl:variable name="readonly" select="$table/@ReadOnly = 'true' or $table/P:Attributes/P:Attribute[@Key='MVC-Admin-Readonly']"/>
			
			<xsl:text>
	[Authorize(Roles = "Administrator")]
	public partial class </xsl:text>
			<xsl:value-of select="@PluralClassName"/>
			<xsl:text>Controller : BaseController
	{
		public ActionResult Index(</xsl:text>
			<xsl:value-of select="$indexModelName"/>
			<xsl:text> model)
		{
			model.QueryData(true);
			
			return this.View(model);
		}
		
		public ActionResult Detail(int id)
		{
			</xsl:text>
				<xsl:value-of select="$detailModelName"/>
				<xsl:text> model = new </xsl:text>
				<xsl:value-of select="$detailModelName"/>
				<xsl:text>(id);
			
			return this.View(model); 
		}</xsl:text>
		
			<xsl:if test="not($readonly)">
				<xsl:text>
		public ActionResult Add()
		{
			</xsl:text>
				<xsl:value-of select="$editModelName"/>
				<xsl:text> model = new </xsl:text>
				<xsl:value-of select="$editModelName"/>
				<xsl:text>();
			
			model.Initialize();
			
			return this.View("Edit", model);
		}
		
		public ActionResult Edit(int id)
		{
			</xsl:text>
				<xsl:value-of select="$editModelName"/>
				<xsl:text> model = new </xsl:text>
				<xsl:value-of select="$editModelName"/>
				<xsl:text>(id);
			
			return this.View(model); 
		}
		
		[HttpPost]
		public ActionResult Edit(</xsl:text>
				<xsl:value-of select="$editModelName"/>
				<xsl:text> model)
		{
			if (this.ModelState.IsValid)
			{
				DA.</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> instance = null;
				bool performEdit = true;
				ActionResult nextAction = null;
				
				if (model.ID.HasValue)
					instance = </xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text>Logic.GetByID(this.DataContext, model.ID.Value);
				
				EditModel(model, instance, ref performEdit, ref nextAction);
				
				if (performEdit)
				{
					if (model.ID.HasValue)
					{</xsl:text>
				
				<xsl:for-each select="$allColumns[@PrimaryKey='false']">
					<xsl:choose>
						<xsl:when test="@EncryptionVectorColumnName">
							<xsl:text>
						if (!model.</xsl:text>
							<xsl:value-of select="@DecryptionPropertyName"/>
							<xsl:text>.IsNullOrEmpty())
							</xsl:text>
						</xsl:when>
						<xsl:otherwise>
							<xsl:text>
						</xsl:text>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text>instance.</xsl:text>
					<xsl:choose>
						<xsl:when test="@EncryptionVectorColumnName">
							<xsl:value-of select="@DecryptionPropertyName"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@FieldName"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text> = model.</xsl:text>
					<xsl:choose>
						<xsl:when test="@EncryptionVectorColumnName">
							<xsl:value-of select="@DecryptionPropertyName"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@FieldName"/>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:text>;</xsl:text>
				</xsl:for-each>
				
				<xsl:text>
					}
					else
						instance = </xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text>Logic.Create(this.DataContext, </xsl:text>
				<xsl:for-each select="P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false' and not(P:Attributes/P:Attribute[@Key='ExcludeFromCreate'])]">
					<xsl:variable name="fieldName" select="@FieldName"/>
					
					<xsl:choose>
						<xsl:when test="$allColumns[@FieldName=$fieldName]">
							<xsl:text>model.</xsl:text>
							<xsl:choose>
								<xsl:when test="@EncryptionVectorColumnName">
									<xsl:value-of select="@DecryptionPropertyName"/>
								</xsl:when>
								<xsl:otherwise>
									<xsl:value-of select="@FieldName"/>
								</xsl:otherwise>
							</xsl:choose>
						</xsl:when>
						<xsl:otherwise>
							<xsl:text>default(</xsl:text>
							<xsl:value-of select="@DataType"/>
							<xsl:if test="@Nullable='true'">
								<xsl:text>?</xsl:text>
							</xsl:if>
							<xsl:text>)</xsl:text>
						</xsl:otherwise>
					</xsl:choose>
					
					<xsl:if test="position()!=last()">
						<xsl:text>, </xsl:text>
					</xsl:if>
				</xsl:for-each>
				<xsl:text>);
			
					try
					{
						this.DataContext.SubmitChanges();
					}
					catch (Exception ex)
					{
						this.Logger.Error(ex);
						this.TempData.SetMessage("An error occurred while updating the </xsl:text>
				<xsl:value-of select="$displayName"/>
				<xsl:text>.");</xsl:text>
				
				<xsl:if test="$hasLists">
					<xsl:text>
						
						model.LoadLists();</xsl:text>
				</xsl:if>
				
				<xsl:text>
						
						return this.View(model);
					}</xsl:text>
				
				<xsl:if test="$table/P:Attributes/P:Attribute[@Key='Cache']">
					<xsl:text>

					DA.</xsl:text>
					<xsl:value-of select="@ClassName"/>
					<xsl:text>.OnCacheNeedsRefresh();</xsl:text>
				</xsl:if>
				
				<xsl:text>
	
					this.TempData.SetMessage("The </xsl:text>
				<xsl:value-of select="$displayName"/>
				<xsl:text> \"{0}\" was {1} successfully.".FormatString(instance, (model.ID.HasValue ? "updated" : "created")));
				}
				
				if (nextAction != null)
					return nextAction;
				else
					return this.RedirectToReturnUrlOrDefault(model, "Index");
			}</xsl:text>
			
				<xsl:if test="$hasLists">
					<xsl:text>
						
						model.LoadLists();</xsl:text>
				</xsl:if>
				
				<xsl:text>
			
			return this.View(model);
		}
		
		<![CDATA[/// <summary>Allows further editing to occur before the changes are submitted.</summary>
		/// <param name="model">The model that was posted.</param>
		/// <param name="instance">The data object that is being updated. Null if the model represents a new instance.</param>
		/// <param name="performEdit">Should be set to true if the default edit should be performed.</param>
		/// <param name="nextAction">The next action, or null to use the default next action.</param>]]>
		partial void EditModel(</xsl:text>
				<xsl:value-of select="$editModelName"/>
				<xsl:text> model, DA.</xsl:text>
				<xsl:value-of select="@ClassName"/>
				<xsl:text> instance, ref bool performEdit, ref ActionResult nextAction);</xsl:text>
		
				<xsl:if test="P:Attributes/P:Attribute[@Key='MVC-Admin-Deletable']">
					<xsl:text>

		[HttpPost]
		public ActionResult Delete(int id, string returnUrl)
		{
			if (this.ModelState.IsValid)
			{
				DA.</xsl:text>
					<xsl:value-of select="@ClassName"/>
					<xsl:text> instance = </xsl:text>
					<xsl:value-of select="@ClassName"/>
					<xsl:text>Logic.GetByID(this.DataContext, id);
				bool performDelete = true;
				ActionResult nextAction = null;
				
				DeleteModel(id, instance, ref performDelete, ref nextAction);
				
				if (performDelete)
				{
					try
					{
						</xsl:text>
						<xsl:value-of select="@ClassName"/>
						<xsl:text>Logic.Delete(this.DataContext, instance);
						this.DataContext.SubmitChanges();
					}
					catch (DeleteConflictException ex)
					{
						HandleDeleteConflict(ex);
						return this.RedirectToAction("Edit", new { id = id });
					}
					catch (Exception ex)
					{
						this.Logger.Error(ex);
						this.TempData.SetMessage("An error occurred while deleting the </xsl:text>
					<xsl:value-of select="$displayName"/>
					<xsl:text>.");
						return this.RedirectToAction("Edit", new { id = id });
					}</xsl:text>
				
					<xsl:if test="$table/P:Attributes/P:Attribute[@Key='Cache']">
						<xsl:text>

					DA.</xsl:text>
						<xsl:value-of select="@ClassName"/>
						<xsl:text>.OnCacheNeedsRefresh();</xsl:text>
					</xsl:if>
					
					<xsl:text>
	
					this.TempData.SetMessage("The </xsl:text>
					<xsl:value-of select="$displayName"/>
					<xsl:text> \"{0}\" was deleted successfully.".FormatString(instance));
				}

				if (nextAction != null)
					return nextAction;
				else
					return this.RedirectToReturnUrlOrDefault(returnUrl, "Index");
			}
			
			return this.RedirectToAction("Edit", new { id = id });
		}
		
		<![CDATA[/// <summary>Allows a delete to be cancelled or altered before the changes are submitted.</summary>
		/// <param name="model">The model that was posted.</param>
		/// <param name="instance">The data object that is being deleted.</param>
		/// <param name="performDelete">Should be set to true if the default delete should be performed.</param>
		/// <param name="nextAction">The next action, or null to use the default next action.</param>]]>
		partial void DeleteModel(int id, DA.</xsl:text>
					<xsl:value-of select="@ClassName"/>
					<xsl:text> instance, ref bool performDelete, ref ActionResult nextAction);</xsl:text>
				</xsl:if>
			</xsl:if>
			
			<xsl:text>
	}
	</xsl:text>
		</xsl:for-each>
		
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>