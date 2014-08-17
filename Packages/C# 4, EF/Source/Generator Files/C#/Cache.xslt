<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="Common.xslt"/>
	
	<xsl:param name="templateName"/>
	
	<xsl:template match="P:Project">
		<xsl:call-template name="Using-System" />
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Collections.Generic'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'System.Linq'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'S3.Common'"/>
		</xsl:call-template>
		<xsl:call-template name="Using">
			<xsl:with-param name="namespace" select="'S3.Common.Cache'"/>
		</xsl:call-template>
		<xsl:call-template name="Using-Project"/>
		<xsl:call-template name="Using-Template">
			<xsl:with-param name="template" select="P:Templates/P:Template[@Name=$templateName]"/>
		</xsl:call-template>
		 
		<xsl:text>
namespace </xsl:text>
		<xsl:value-of select="@RootNamespace"/>
<xsl:text>.DataAccess.Cache
{</xsl:text>
		<xsl:for-each select="P:TableMappings/P:TableMapping[P:Attributes/P:Attribute/@Key='Cache']">
			<xsl:variable name="pkColumn" select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='true'][1]"/>
			
			<xsl:text>
	/// &lt;summary&gt;Implements caching for the </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> class.&lt;/summary&gt;
	public partial class </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Cache : Cache&lt;</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>, </xsl:text>
			<xsl:value-of select="P:ColumnMappings/P:ColumnMapping[@PrimaryKey='true']/@DataType"/>
			<xsl:text>&gt;
	{
        private static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Cache _instance = null;

        /// &lt;summary&gt;Gets the singleton instance for the cache.&lt;/summary&gt;
        public static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Cache Instance { get { return _instance; } }
        
		static </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Cache()
		{
            _instance = new </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Cache();
			CacheManager.Register(new </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Cache());
			
			// Listen for changes and refresh the cache as needed.
			</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.CacheNeedsRefresh += new ParameterlessDelegate(delegate() { </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>Cache.Instance.Refresh(); });
		}

		/// &lt;summary&gt;This method does not perform any operation but will cause the static initializer to fire.&lt;/summary&gt;
		public void Touch() {}

		/// &lt;summary&gt;Extracts the primary key from the provided </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.&lt;/summary&gt;
		/// &lt;param name="item"&gt;The </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> from which the primary key should be extracted.&lt;/param&gt;
		/// &lt;returns&gt;The primary key of the item.&lt;/returns&gt;
		protected override </xsl:text>
			<xsl:value-of select="$pkColumn/@DataType"/>
			<xsl:text> GetKey(</xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> o)
		{
			return o.</xsl:text>
			<xsl:value-of select="$pkColumn/@FieldName"/>
			<xsl:text>;
		}

		/// &lt;summary&gt;Refreshes the </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text> cache.&lt;/summary&gt;
		protected override void DoRefresh()
		{
			this.CachedItems = </xsl:text>
			<xsl:value-of select="@ClassName"/>
			<xsl:text>.GetAll().ToList();
			DoCustomRefresh();
		}

		partial void DoCustomRefresh();
	}</xsl:text>
			<xsl:if test="position()!=last()">
				<xsl:value-of select="$newLine"/>
			</xsl:if>
		</xsl:for-each>
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>