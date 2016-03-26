<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewCode.aspx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.ViewCode" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="App_Resources/Css/shCore.css" />
    <link rel="Stylesheet" type="text/css" href="App_Resources/Css/shCoreDefault.css" />
    <link rel="Stylesheet" type="text/css" href="App_Resources/Css/shThemeDefault.css" />
    <script type="text/javascript" src="App_Resources/JavaScript/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="App_Resources/JavaScript/shCore.js"></script>
    <script type="text/javascript" src="App_Resources/JavaScript/shAutoloader.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <p>Source code for the file <em><asp:Literal ID="pathLiteral" runat="server" /></em> is shown below.</p>
    <asp:PlaceHolder ID="codePlaceHolder" runat="server" />

	<script type="text/javascript">
	    $(document).ready(function ()
	    {
	        SyntaxHighlighter.autoloader(
				"csharp /App_Resources/JavaScript/shBrushCSharp.js",
				"xml /App_Resources/JavaScript/shBrushXml.js");
	        SyntaxHighlighter.all();
	    });
	</script>
</asp:Content>