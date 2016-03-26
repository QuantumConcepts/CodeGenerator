<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="yes"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	<xsl:param name="elementName"/>
	
	<xsl:template match="P:Project">
		<xsl:variable name="table" select="P:TableMappings/P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
		<xsl:variable name="pkColumn" select="$table/P:ColumnMappings/P:ColumnMapping[@PrimaryKey='true'][1]"/>
		
		<xsl:call-template name="Using-System-All"/>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Web.UI.WebControls'"/>
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
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.Logic</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace">
				<xsl:value-of select="@RootNamespace"/>
				<xsl:text>.Web.WebControls</xsl:text>
			</xsl:with-param>
		</xsl:call-template>
		
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="/P:Project/@RootNamespace"/>
		<xsl:text>.Web.</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text>
{
	public partial class Edit : BasePage
	{
        	protected Edit</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> EditControl;
			
        	private </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> { get; set; }

	        protected override void OnLoad(EventArgs e)
	        {
	            base.OnLoad(e);
	
				string idString = this.Request.QueryString["ID"];
	            int id;
	            
	            if (int.TryParse(idString, out id))
	            {
	            	this.</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> = </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Logic.GetByID(this.DataContext, id);
	
	            	if (!this.IsPostBack)
	                	this.EditControl.DataBind(this.</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>);
				}
	        }
	
	        protected void EditControl_Saved(object sender, </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj)
	        {
	            this.Response.Redirect("Default.aspx");
	        }
	
	        protected void EditControl_Cancelled(object sender, EventArgs e)
	        {
	            this.Response.Redirect("Default.aspx");
	        }
	}
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>