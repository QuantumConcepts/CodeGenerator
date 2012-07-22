<%@ Page Title="All Teachers" MasterPageFile="~/Main.Master" CodeBehind="Default.aspx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.Teachers.Default" Language="C#" %>
<%@ Register TagPrefix="Sample" TagName="List" Src="~/WebControls/TeacherList.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="content">
  <div id="SubMenu"><a href="Edit.aspx">New...</a></div>
  <Sample:List ID="ListControl" runat="server" OnNeedsDataBinding="ListControl_NeedsDataBinding" OnEdit="ListControl_Edit" OnDelete="ListControl_Delete" />
</asp:Content>