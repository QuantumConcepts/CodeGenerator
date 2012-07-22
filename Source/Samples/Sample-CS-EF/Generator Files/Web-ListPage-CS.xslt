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
	public partial class Default : BasePage
	{
        protected </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>List ListControl;
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
                BindList();
        }

        protected void ListControl_NeedsDataBinding(object sender, EventArgs e)
        {
            BindList();
        }

        protected void ListControl_Edit(object sender, </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj)
        {
            Response.Redirect(string.Format("Edit.aspx?ID={0}", obj.</xsl:text>
		<xsl:value-of select="$pkColumn/@FieldName"/>
		<xsl:text>));
        }

        protected void ListControl_Delete(object sender, </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj)
        {
            </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Logic.Delete</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>(this.DataContext, obj.</xsl:text>
		<xsl:value-of select="$pkColumn/@FieldName"/>
		<xsl:text>);
            this.DataContext.AcceptAllChanges();
            BindList();
        }

        private void BindList()
        {
            ListControl.DataBind(</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Logic.GetAll().ToList());
        }
    }
}</xsl:text>	
	</xsl:template>
</xsl:stylesheet>