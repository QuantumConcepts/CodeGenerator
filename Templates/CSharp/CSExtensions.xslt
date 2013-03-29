<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:s3="http://schemas.quantumconceptscorp.com/user-defined">
	<msxsl:script language="C#" implements-prefix="s3">
		<![CDATA[
			public string[] SplitString(string value, char delimiter)
			{
				if (value == null)
					return null;
				
				return value.Split(delimiter);
			}
			
			public object If(bool condition, object trueValue, object falseValue)
			{
				return (condition ? trueValue : falseValue);
			}
		]]>
	</msxsl:script>
</xsl:stylesheet>
