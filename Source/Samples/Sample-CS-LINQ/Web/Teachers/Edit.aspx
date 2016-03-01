<%@ Page Title="Create or Edit Teacher" MasterPageFile="~/Main.Master" CodeBehind="Edit.aspx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.Teachers.Edit" Language="C#" %>
<%@ Register TagPrefix="Sample" TagName="Edit" Src="~/WebControls/EditTeacher.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="content">
  <Sample:Edit ID="EditControl" runat="server" OnSaved="EditControl_Saved" OnCancelled="EditControl_Cancelled" />
</asp:Content>