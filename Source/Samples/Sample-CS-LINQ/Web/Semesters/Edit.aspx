<%@ Page Title="Create or Edit Semester" MasterPageFile="~/Main.Master" CodeBehind="Edit.aspx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.Semesters.Edit" Language="C#" %>
<%@ Register TagPrefix="Sample" TagName="Edit" Src="~/WebControls/EditSemester.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="content">
  <Sample:Edit ID="EditControl" runat="server" OnSaved="EditControl_Saved" OnCancelled="EditControl_Cancelled" />
</asp:Content>