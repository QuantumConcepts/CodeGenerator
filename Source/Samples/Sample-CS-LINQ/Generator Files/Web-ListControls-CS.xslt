<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="yes"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	<xsl:param name="elementName"/>
	
	<xsl:template match="P:Project">
		<xsl:variable name="table" select="P:TableMappings/P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
		<xsl:variable name="pkColumn" select="$table/P:ColumnMappings/P:ColumnMapping[@PrimaryKey='true'][1]"/>
		<xsl:variable name="columncount" select="count($table/P:ColumnMappings/P:ColumnMapping[@Exclude='false'])"/>
		
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
		
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
		<xsl:text>.Web.WebControls
{
	public partial class </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>List : BaseUserControl
	{
        public delegate void EditEventHandler(object sender, </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj);
        public delegate void DeleteEventHandler(object sender, </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj);

        public event EventHandler NeedsDataBinding;
        public event EditEventHandler Edit;
        public event DeleteEventHandler Delete;
        
        protected DataGrid Grid;
        </xsl:text>
		<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false']">
			<xsl:variable name="columnName" select="@ColumnName"/>
			<xsl:variable name="fk" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>

			<xsl:text>
		public bool Show</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>Column { set { this.Grid.Columns[</xsl:text>
			<xsl:value-of select="position() - 1"/>
			<xsl:text>].Visible = value; } }</xsl:text>
		</xsl:for-each>
		
		<xsl:text>
        public bool ShowEditColumn { set { this.Grid.Columns[</xsl:text>
			<xsl:value-of select="$columncount"/>
			<xsl:text>].Visible = value; } }
        public bool ShowDeleteColumn { set { this.Grid.Columns[</xsl:text>
			<xsl:value-of select="$columncount + 1"/>
			<xsl:text>].Visible = value; } }

        protected void Grid_NeedsDataBinding(object sender, EventArgs e)
        {
            this.OnNeedsDataBinding();
        }

        protected void Grid_ItemCommand(object sender, DataGridCommandEventArgs e)
        {
            if ("Edit".Equals(e.CommandName))
            {
				</xsl:text>
				<xsl:value-of select="$pkColumn/@DataType"/>
				<xsl:text> primaryKey = (</xsl:text>
				<xsl:value-of select="$pkColumn/@DataType"/>
				<xsl:text>)this.Grid.DataKeys[e.Item.ItemIndex];

                this.OnEdit(</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Logic.GetByID(this.DataContext, primaryKey));
            }
            else if ("Delete".Equals(e.CommandName))
            {
				</xsl:text>
				<xsl:value-of select="$pkColumn/@DataType"/>
				<xsl:text> primaryKey = (</xsl:text>
				<xsl:value-of select="$pkColumn/@DataType"/>
				<xsl:text>)this.Grid.DataKeys[e.Item.ItemIndex];

                this.OnDelete(</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Logic.GetByID(this.DataContext, primaryKey));
            }
        }

        public void DataBind(IEnumerable&lt;</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>&gt; objects)
        {
            this.Grid.DataSource = objects.ToList();
            this.Grid.DataBind();
        }

        private void OnNeedsDataBinding()
        {
            if (this.NeedsDataBinding != null)
                this.NeedsDataBinding(this, EventArgs.Empty);
        }

        private void OnEdit(</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj)
        {
            if (this.Edit != null)
                this.Edit(this, obj);
        }

        private void OnDelete(</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj)
        {
            if (this.Delete != null)
                this.Delete(this, obj);
        }
	}
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>