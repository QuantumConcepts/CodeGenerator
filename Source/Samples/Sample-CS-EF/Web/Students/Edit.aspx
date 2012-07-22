<%@ Page Title="Create or Edit Student" MasterPageFile="~/Main.Master" CodeBehind="Edit.aspx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.Students.Edit" Language="C#" %>
<%@ Register TagPrefix="Sample" TagName="Edit" Src="~/WebControls/EditStudent.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="content">
  <Sample:Edit ID="EditControl" runat="server" OnSaved="EditControl_Saved" OnCancelled="EditControl_Cancelled" />
</asp:Content>