<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:qc="http://schemas.quantumconceptscorp.com/user-defined">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="yes"/>
	
	<xsl:include href="XSLTCommon-CS.xslt"/>
	
	<xsl:param name="templateName"/>
	<xsl:param name="elementName"/>
	
	<xsl:template match="P:Project">
		<xsl:variable name="table" select="P:TableMappings/P:TableMapping[@Exclude='false' and @TableName=$elementName]"/>
		
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
	public partial class Edit</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> : BaseUserControl
	{
		private const string ViewState_ID = "ID";
		
		public delegate void SavedEventHandler(object sender, </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj);
		
		public event SavedEventHandler Saved;
		public event EventHandler Cancelled;

		private int? ObjectID { get { return (this.ViewState[ViewState_ID] as int?); } set { this.ViewState[ViewState_ID] = value; } }
</xsl:text>
		
		<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false']">
			<xsl:variable name="columnName" select="@ColumnName"/>
			<xsl:variable name="fk" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
			
			<xsl:choose>
				<xsl:when test="P:EnumerationMapping or $fk">
					<xsl:text>
		protected DropDownList </xsl:text>
					<xsl:choose>
						<xsl:when test="P:EnumerationMapping">
							<xsl:value-of select="P:EnumerationMapping/@Name"/>
						</xsl:when>
						<xsl:when test="$fk">
							<xsl:value-of select="$fk/@PropertyName"/>
						</xsl:when>
					</xsl:choose>
					
					<xsl:text>Field;</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='string'">
					<xsl:text>
		protected TextBox </xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field;</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='bool'">
					<xsl:text>
		protected CheckBox </xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field;</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='DateTime'">
					<xsl:text>
		protected Calendar </xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field;</xsl:text>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
		
		<xsl:text>
		
		protected override void OnLoad(EventArgs e)
		{</xsl:text>
		
		<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false']">
			<xsl:variable name="columnName" select="@ColumnName"/>
			<xsl:variable name="fk" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
			
			<xsl:choose>
				<xsl:when test="P:EnumerationMapping">
					<xsl:text>
			this.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>Field.DataSource = Enum.GetValues(typeof(DataAccess.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>));</xsl:text>
					<xsl:text>
			this.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>Field.DataBind();</xsl:text>
				</xsl:when>
				<xsl:when test="$fk">
					<xsl:variable name="fkReferencedTable" select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$fk/@ReferencedTableMappingName]"/>
					
					<xsl:text>
			this.</xsl:text>
					<xsl:value-of select="$fk/@PropertyName"/>
					<xsl:text>Field.DataSource = </xsl:text>
					<xsl:value-of select="$fkReferencedTable/@ClassName"/>
					<xsl:text>Logic.GetAll();</xsl:text>
					<xsl:text>
			this.</xsl:text>
					<xsl:value-of select="$fk/@PropertyName"/>
					<xsl:text>Field.DataBind();</xsl:text>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
		
		<xsl:text>
		}
		
        public void DataBind(</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj)
        {
            if (obj != null)
            {
                this.ObjectID = obj.ID;</xsl:text>
		
		<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false']">
			<xsl:variable name="columnName" select="@ColumnName"/>
			<xsl:variable name="fk" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
			
			<xsl:choose>
				<xsl:when test="P:EnumerationMapping">
					<xsl:text>
				this.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>Field.SelectedValue = obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>.ToString();</xsl:text>
				</xsl:when>
				<xsl:when test="$fk">
					<xsl:variable name="fkReferencedTable" select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$fk/@ReferencedTableMappingName]"/>
					
					<xsl:text>
				this.</xsl:text>
					<xsl:value-of select="$fk/@PropertyName"/>
					<xsl:text>Field.SelectedValue = obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>.ToString();</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='string'">
					<xsl:text>
				this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field.Text = obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>;</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='bool'">
					<xsl:text>
				this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field.Checked = obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>;</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='DateTime'">
					<xsl:text>
				this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field.SelectedDate = obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>;</xsl:text>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
		
		<xsl:text>
			}
		}

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.ObjectID.HasValue)
            {
            	</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj = </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Logic.GetByID(this.DataContext, this.ObjectID.Value);
		</xsl:text>
		
		<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false']">
			<xsl:variable name="columnName" select="@ColumnName"/>
			<xsl:variable name="fk" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
			
			<xsl:choose>
				<xsl:when test="P:EnumerationMapping">
					<xsl:text>
				obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = (DataAccess.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>)Enum.Parse(typeof(DataAccess.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>), this.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>Field.SelectedValue);</xsl:text>
				</xsl:when>
				<xsl:when test="$fk">
					<xsl:variable name="fkReferencedTable" select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$fk/@ReferencedTableMappingName]"/>
					
					<xsl:text>
				obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = int.Parse(this.</xsl:text>
					<xsl:value-of select="$fk/@PropertyName"/>
					<xsl:text>Field.SelectedValue);</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='string'">
					<xsl:text>
				obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field.Text;</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='bool'">
					<xsl:text>
				obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field.Checked;</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='DateTime'">
					<xsl:text>
				obj.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text> = this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field.SelectedDate;</xsl:text>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
			<xsl:text>
            
				this.DataContext.AcceptAllChanges();
				OnSaved(obj);
            }
            else
            {
            	</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj = </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Logic.Create</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>(this.DataContext</xsl:text>
		
		<xsl:for-each select="$table/P:ColumnMappings/P:ColumnMapping[@Exclude='false' and @PrimaryKey='false']">
			<xsl:variable name="columnName" select="@ColumnName"/>
			<xsl:variable name="fk" select="/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping[@ParentTableMappingName=$table/@TableName and @ParentColumnMappingName=$columnName]"/>
			
			<xsl:text>, </xsl:text>
			
			<xsl:choose>
				<xsl:when test="P:EnumerationMapping">
					<xsl:text>(DataAccess.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>)Enum.Parse(typeof(DataAccess.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>), this.</xsl:text>
					<xsl:value-of select="P:EnumerationMapping/@Name"/>
					<xsl:text>Field.SelectedValue)</xsl:text>
				</xsl:when>
				<xsl:when test="$fk">
					<xsl:variable name="fkReferencedTable" select="/P:Project/P:TableMappings/P:TableMapping[@TableName=$fk/@ReferencedTableMappingName]"/>
					
					<xsl:text>int.Parse(this.</xsl:text>
					<xsl:value-of select="$fk/@PropertyName"/>
					<xsl:text>Field.SelectedValue)</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='string'">
					<xsl:text>this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field.Text</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='bool'">
					<xsl:text>this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field.Checked</xsl:text>
				</xsl:when>
				<xsl:when test="@DataType='DateTime'">
					<xsl:text>this.</xsl:text>
					<xsl:value-of select="@FieldName"/>
					<xsl:text>Field.SelectedDate</xsl:text>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
			<xsl:text>);
				
				this.DataContext.AcceptAllChanges();
				OnSaved(obj);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            OnCancelled();
        }

        private void OnSaved(</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> obj)
        {
            if (this.Saved != null)
                this.Saved(this, obj);
        }

        private void OnCancelled()
        {
            if (this.Cancelled != null)
                this.Cancelled(this, EventArgs.Empty);
        }
    }
}</xsl:text>	
	</xsl:template>
</xsl:stylesheet>