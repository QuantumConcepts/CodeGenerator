<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:P="http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	
	<xsl:include href="../XSLTCommon.xslt"/>
    
	<xsl:param name="templateName"/>
	<xsl:param name="elementType"/>
	<xsl:param name="elementName"/>
    
	<xsl:template match="P:Project">
		<xsl:param name="table" select="P:TableMappings/P:TableMapping[@TableName=$elementName]"/>
		
		<xsl:text>package supertrition.soap.client;

import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;

import supertrition.soap.client.objects.</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>;
import supertrition.soap.client.objects.</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Factory;

public class </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Methods
{
	public static MultipleResultSoapMethod&lt;</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>&gt; Get</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text>(final int page)
	{
		return new MultipleResultSoapMethod&lt;</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>&gt;()
		{
			public String getMethodName()
			{
				return "Get</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text>";
			}
			
			public void setParameters(SoapObject parameters)
			{
				PropertyInfo pageProperty = new PropertyInfo();
				
				pageProperty.setName("page");
				pageProperty.setNamespace(this.getNamespace());
				pageProperty.setValue(page);
				parameters.addProperty(pageProperty);
			}
        
			public </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> parse(Object object) throws SoapException
			{
				return </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Factory.parse((SoapObject)object);
			}
		};
	}
    
	public static SingleResultSoapMethod&lt;Integer&gt; Get</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text>Count()
	{
		return new SingleResultSoapMethod&lt;Integer&gt;()
		{
			public String getMethodName()
			{
				return "Get</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text>Count";
			}
			
			public Integer parse(Object object) throws SoapException
			{
				return (Integer)Integer.parseInt(object.toString());
			}
		};
	}
    
    public static SingleResultSoapMethod&lt;Integer&gt; Get</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text>PageCount()
	{
		return new SingleResultSoapMethod&lt;Integer&gt;()
		{
			public String getMethodName()
			{
				return "Get</xsl:text>
		<xsl:value-of select="$table/@PluralClassName"/>
		<xsl:text>PageCount";
			}
			
			public Integer parse(Object object) throws SoapException
			{
				return (Integer)Integer.parseInt(object.toString());
			}
		};
	}
	
	public static SingleResultSoapMethod&lt;</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>&gt; Get</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>ByID(final int id)
	{
		return new SingleResultSoapMethod&lt;</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>&gt;()
		{
			public String getMethodName()
			{
				return "Get</xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>ByID";
			}
			
			public void setParameters(SoapObject parameters)
			{
				PropertyInfo idProperty = new PropertyInfo();
				
				idProperty.setName("id");
				idProperty.setNamespace(this.getNamespace());
				idProperty.setValue(id);
				parameters.addProperty(idProperty);
			}
			
			public </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text> parse(Object object) throws SoapException
			{
				return </xsl:text>
		<xsl:value-of select="$table/@ClassName"/>
		<xsl:text>Factory.parse((SoapObject)object);
			}
		};
	}</xsl:text>
        
		<xsl:for-each select="P:ForeignKeyMappings/P:ForeignKeyMapping[@Exclude='false' and Attributes/P:Attribute/@Key='ServiceExposed' and @ParentTableMappingName=$table/@TableName]">
			<xsl:variable name="parentTableName" select="@ParentTableMappingName"/>
			<xsl:variable name="parentColumnName" select="@ParentColumnMappingName"/>
			<xsl:variable name="referencedTableName" select="@ReferencedTableMappingName"/>
			<xsl:variable name="referencedColumnName" select="@ReferencedColumnMappingName"/>
			<xsl:variable name="propertyName">
				<xsl:call-template name="FirstCharacterToLowerCase">
					<xsl:with-param name="input" select="$referencedColumnName"/>
				</xsl:call-template>
				<xsl:text>Parameter</xsl:text>
			</xsl:variable>
			<xsl:value-of select="$newLine"/>
			<xsl:text>
	public MultipleResultSoapMethod&lt;</xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
			<xsl:text>&gt; Get</xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
			<xsl:text>By</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>(final </xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
			<xsl:text> </xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="$referencedColumnName"/>
			</xsl:call-template>
			<xsl:text>, final int page)
	{
		return new MultipleResultSoapMethod&lt;</xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@ClassName"/>
			<xsl:text>&gt;()
		{
			public String getMethodName()
			{
				return "Get</xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
			<xsl:text>By</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>";
			}
			
			public void setParameters(SoapObject parameters)
			{
				PropertyInfo </xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text> = new PropertyInfo();
				PropertyInfo pageProperty = new PropertyInfo();

				</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>.setName("</xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="$referencedColumnName"/>
			</xsl:call-template>
			<xsl:text>");
				</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>.setNamespace(this.getNamespace());
				</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>.setValue(</xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="$referencedColumnName"/>
			</xsl:call-template>
			<xsl:text>);
			parameters.addProperty(</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>);
            	
				pageProperty.setName("page");
				pageProperty.setNamespace(this.getNamespace());
				pageProperty.setValue(page);
				parameters.addProperty(pageProperty);
			}
			
			public </xsl:text>
			<xsl:value-of select="$table/@ClassName"/>
			<xsl:text> parse(Object object) throws SoapException
			{
				return </xsl:text>
			<xsl:value-of select="$table/@ClassName"/>
			<xsl:text>Factory.parse((SoapObject)object);
			}
		};
	}
	
	public static SingleResultSoapMethod&lt;Integer&gt; Get</xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
			<xsl:text>By</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>Count(final </xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
			<xsl:text> </xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="$referencedColumnName"/>
			</xsl:call-template>
			<xsl:text>)
	{
		return new SingleResultSoapMethod&lt;Integer&gt;()
		{
			public String getMethodName()
			{
				return "Get</xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
			<xsl:text>By</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>Count";
			}
			
			public void setParameters(SoapObject parameters)
			{
				PropertyInfo </xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text> = new PropertyInfo();
			
				</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>.setName("</xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="$referencedColumnName"/>
			</xsl:call-template>
			<xsl:text>");
				</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>.setNamespace(this.getNamespace());
				</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>.setValue(</xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="$referencedColumnName"/>
			</xsl:call-template>
			<xsl:text>);
				parameters.addProperty(</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>);
			}
			
			public Integer parse(Object object) throws SoapException
			{
				return (Integer)Integer.parseInt(object.toString());
			}
		};
	}
	
	public static SingleResultSoapMethod&lt;Integer&gt; Get</xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
			<xsl:text>By</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>PageCount(final </xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$referencedTableName]/P:ColumnMappings/P:ColumnMapping[@ColumnName=$referencedColumnName]/@DataType"/>
			<xsl:text> </xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="$referencedColumnName"/>
			</xsl:call-template>
			<xsl:text>)
	{
		return new SingleResultSoapMethod&lt;Integer&gt;()
		{
			public String getMethodName()
			{
				return "Get</xsl:text>
			<xsl:value-of select="../../P:TableMappings/P:TableMapping[@TableName=$parentTableName]/@PluralClassName"/>
			<xsl:text>By</xsl:text>
			<xsl:value-of select="@FieldName"/>
			<xsl:text>PageCount";
			}
			
			public void setParameters(SoapObject parameters)
			{
				PropertyInfo </xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text> = new PropertyInfo();
			
				</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>.setName("</xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
			<xsl:with-param name="input" select="$referencedColumnName"/>
			</xsl:call-template>
			<xsl:text>");
				</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>.setNamespace(this.getNamespace());
				</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>.setValue(</xsl:text>
			<xsl:call-template name="FirstCharacterToLowerCase">
				<xsl:with-param name="input" select="$referencedColumnName"/>
			</xsl:call-template>
			<xsl:text>);
				parameters.addProperty(</xsl:text>
			<xsl:value-of select="$propertyName"/>
			<xsl:text>);
			}
			
			public Integer parse(Object object) throws SoapException
			{
				return (Integer)Integer.parseInt(object.toString());
			}
		};
	}</xsl:text>
		</xsl:for-each>
		<xsl:text>
}</xsl:text>
	</xsl:template>
</xsl:stylesheet>